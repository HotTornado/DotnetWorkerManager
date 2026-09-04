using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DotnetWorkerManager;

public class ServiceManagerService
{
    public static string GetServiceImagePath(string serviceName)
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}");
            if (key == null) return "Service not found in registry";

            var rawPath = key.GetValue("ImagePath") as string;
            if (string.IsNullOrWhiteSpace(rawPath)) return "N/A";

            rawPath = Environment.ExpandEnvironmentVariables(rawPath).Trim();

            // Extract executable path if surrounded by quotes or followed by arguments
            if (rawPath.StartsWith("\""))
            {
                int nextQuote = rawPath.IndexOf('\"', 1);
                if (nextQuote > 0)
                {
                    return rawPath.Substring(1, nextQuote - 1);
                }
            }
            else
            {
                int exeIndex = rawPath.IndexOf(".exe", StringComparison.OrdinalIgnoreCase);
                if (exeIndex > 0)
                {
                    return rawPath.Substring(0, exeIndex + 4);
                }
            }

            return rawPath;
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public static ServiceItem GetServiceItem(string serviceName)
    {
        var item = new ServiceItem
        {
            ServiceName = serviceName,
            FullPath = GetServiceImagePath(serviceName)
        };

        try
        {
            using var sc = new ServiceController(serviceName);
            item.DisplayName = sc.DisplayName;
            item.Status = sc.Status;
        }
        catch (InvalidOperationException)
        {
            item.DisplayName = serviceName;
            item.Status = null;
            item.StatusMessage = "Not Found";
        }
        catch (Exception ex)
        {
            item.DisplayName = serviceName;
            item.Status = null;
            item.StatusMessage = ex.Message;
        }

        return item;
    }

    public static void RefreshServiceStatus(ServiceItem item)
    {
        try
        {
            using var sc = new ServiceController(item.ServiceName);
            item.DisplayName = sc.DisplayName;
            item.Status = sc.Status;
            item.FullPath = GetServiceImagePath(item.ServiceName);
            item.StatusMessage = string.Empty;
        }
        catch (InvalidOperationException)
        {
            item.Status = null;
            item.StatusMessage = "Not Found";
        }
        catch (Exception ex)
        {
            item.Status = null;
            item.StatusMessage = ex.Message;
        }
    }

    public static async Task<(bool success, string message)> StartServiceAsync(string serviceName, TimeSpan? timeout = null)
    {
        var waitTimeout = timeout ?? TimeSpan.FromSeconds(30);
        return await Task.Run(() =>
        {
            try
            {
                using var sc = new ServiceController(serviceName);
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    return (true, "Already running.");
                }

                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running, waitTimeout);
                return (true, "Service started successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Failed to start: {ex.Message}");
            }
        });
    }

    public static async Task<(bool success, string message)> StopServiceAsync(string serviceName, TimeSpan? timeout = null)
    {
        var waitTimeout = timeout ?? TimeSpan.FromSeconds(30);
        return await Task.Run(() =>
        {
            try
            {
                using var sc = new ServiceController(serviceName);
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    return (true, "Already stopped.");
                }

                if (!sc.CanStop)
                {
                    return (false, "Service reports it cannot be stopped.");
                }

                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped, waitTimeout);
                return (true, "Service stopped successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Failed to stop: {ex.Message}");
            }
        });
    }

    public static async Task<(bool success, string message)> RestartServiceAsync(string serviceName, TimeSpan? timeout = null)
    {
        var waitTimeout = timeout ?? TimeSpan.FromSeconds(30);
        return await Task.Run(() =>
        {
            try
            {
                using var sc = new ServiceController(serviceName);
                if (sc.Status != ServiceControllerStatus.Stopped)
                {
                    if (sc.CanStop)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, waitTimeout);
                    }
                }

                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running, waitTimeout);
                return (true, "Service restarted successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Failed to restart: {ex.Message}");
            }
        });
    }

    public static async Task<(bool success, string message)> RegisterServiceAsync(
        string serviceName,
        string exePath,
        string displayName = "",
        string startType = "auto",
        string description = "")
    {
        return await Task.Run(() =>
        {
            try
            {
                if (!File.Exists(exePath))
                {
                    return (false, $"Executable file not found: {exePath}");
                }

                if (string.IsNullOrWhiteSpace(displayName))
                {
                    displayName = serviceName;
                }

                // Note: sc.exe requires spaces after 'binPath=', 'start=', 'DisplayName='
                string args = $"create \"{serviceName}\" binPath= \"\\\"{exePath}\\\"\" start= {startType} DisplayName= \"{displayName}\"";

                var psi = new ProcessStartInfo
                {
                    FileName = "sc.exe",
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(psi);
                if (process == null)
                {
                    return (false, "Could not start sc.exe process.");
                }

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    string fullError = !string.IsNullOrWhiteSpace(error) ? error : output;
                    return (false, $"sc.exe registration failed: {fullError.Trim()}");
                }

                // If description is provided, configure it
                if (!string.IsNullOrWhiteSpace(description))
                {
                    var descPsi = new ProcessStartInfo
                    {
                        FileName = "sc.exe",
                        Arguments = $"description \"{serviceName}\" \"{description}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    using var descProcess = Process.Start(descPsi);
                    descProcess?.WaitForExit();
                }

                return (true, "Service registered successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Exception registering service: {ex.Message}");
            }
        });
    }
}
