using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace DotnetWorkerManager;

public class ServiceConfigFile
{
    public List<string> Services { get; set; } = new();
    public int AutoRefreshIntervalSeconds { get; set; } = 3;
}

public static class ServiceConfig
{
    private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "services.json");
    private static FileSystemWatcher? _watcher;
    private static FileSystemWatcher? _devWatcher;
    private static System.Threading.Timer? _debounceTimer;

    public static event Action? ConfigFileChanged;

    public static string GetConfigFilePath() => ConfigPath;

    static ServiceConfig()
    {
        InitializeFileWatchers();
    }

    public static List<string> LoadTrackedServices()
    {
        for (int attempt = 0; attempt < 3; attempt++)
        {
            try
            {
                if (!File.Exists(ConfigPath))
                {
                    CreateDefaultConfig();
                }

                // Use FileShare.ReadWrite so we can read even while text editor is saving
                using var fs = new FileStream(ConfigPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = new StreamReader(fs);
                string json = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<string>();
                }

                json = json.Trim();
                if (json.StartsWith("["))
                {
                    var list = JsonSerializer.Deserialize<List<string>>(json);
                    return list ?? new List<string>();
                }

                var configObj = JsonSerializer.Deserialize<ServiceConfigFile>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return configObj?.Services ?? new List<string>();
            }
            catch (IOException) when (attempt < 2)
            {
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading services.json: {ex.Message}");
                return new List<string>();
            }
        }

        return new List<string>();
    }

    public static void SaveTrackedServices(List<string> services)
    {
        try
        {
            var configObj = new ServiceConfigFile
            {
                Services = services,
                AutoRefreshIntervalSeconds = 3
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(configObj, options);

            // Temporarily disable watcher to prevent self-triggering
            if (_watcher != null) _watcher.EnableRaisingEvents = false;

            File.WriteAllText(ConfigPath, json);

            // If in dev environment, also mirror changes to project root services.json
            string devPath = GetDevProjectPath();
            if (File.Exists(devPath))
            {
                if (_devWatcher != null) _devWatcher.EnableRaisingEvents = false;
                File.WriteAllText(devPath, json);
                if (_devWatcher != null) _devWatcher.EnableRaisingEvents = true;
            }
        }
        finally
        {
            if (_watcher != null) _watcher.EnableRaisingEvents = true;
        }
    }

    public static void CreateDefaultConfig()
    {
        var defaultConfig = new ServiceConfigFile
        {
            Services = new List<string>
            {
                "Spooler",
                "W32Time"
            },
            AutoRefreshIntervalSeconds = 3
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(defaultConfig, options);
        File.WriteAllText(ConfigPath, json);
    }

    private static void InitializeFileWatchers()
    {
        try
        {
            string dir = Path.GetDirectoryName(ConfigPath) ?? string.Empty;
            if (Directory.Exists(dir))
            {
                _watcher = new FileSystemWatcher(dir, "services.json")
                {
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size,
                    EnableRaisingEvents = true
                };

                _watcher.Changed += OnWatcherFileEvent;
                _watcher.Created += OnWatcherFileEvent;
                _watcher.Renamed += (s, e) => OnWatcherFileEvent(s, e);
            }

            // Also watch project root if running from bin\Debug during development
            string devPath = GetDevProjectPath();
            string devDir = Path.GetDirectoryName(devPath) ?? string.Empty;
            if (File.Exists(devPath) && Directory.Exists(devDir) && !string.Equals(devDir, dir, StringComparison.OrdinalIgnoreCase))
            {
                _devWatcher = new FileSystemWatcher(devDir, "services.json")
                {
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size,
                    EnableRaisingEvents = true
                };

                _devWatcher.Changed += (s, e) =>
                {
                    // Copy updated dev file to output directory and trigger reload
                    Thread.Sleep(100);
                    try
                    {
                        File.Copy(devPath, ConfigPath, true);
                    }
                    catch { }
                    OnWatcherFileEvent(s, e);
                };
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to initialize FileSystemWatcher: {ex.Message}");
        }
    }

    private static void OnWatcherFileEvent(object sender, FileSystemEventArgs e)
    {
        // Debounce to prevent duplicate reloads when editor writes in chunks
        _debounceTimer?.Dispose();
        _debounceTimer = new System.Threading.Timer(_ =>
        {
            ConfigFileChanged?.Invoke();
        }, null, 350, Timeout.Infinite);
    }

    private static string GetDevProjectPath()
    {
        return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\services.json"));
    }
}
