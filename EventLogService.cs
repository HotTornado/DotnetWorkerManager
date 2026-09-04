using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace DotnetWorkerManager;

public class WorkerLogEntry
{
    public DateTime? TimeCreated { get; set; }
    public string Level { get; set; } = "Info";
    public int? EventId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string LogName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string RawXml { get; set; } = string.Empty;
}

public class EventLogService
{
    public static async Task<List<WorkerLogEntry>> GetRecentLogsAsync(string serviceName, int seconds = 60)
    {
        return await Task.Run(() =>
        {
            var results = new List<WorkerLogEntry>();
            long milliseconds = (long)seconds * 1000;

            // Query both Application and System logs
            string[] logChannels = { "Application", "System" };

            foreach (var channel in logChannels)
            {
                try
                {
                    // XPath query for events within the last N milliseconds
                    string query = $"*[System[TimeCreated[timediff(@SystemTime) <= {milliseconds}]]]";
                    var logQuery = new EventLogQuery(channel, PathType.LogName, query)
                    {
                        ReverseDirection = true // Most recent first
                    };

                    using var reader = new EventLogReader(logQuery);
                    EventRecord? record;

                    while ((record = reader.ReadEvent()) != null)
                    {
                        using (record)
                        {
                            string provider = record.ProviderName ?? string.Empty;
                            string message = string.Empty;

                            try
                            {
                                message = record.FormatDescription() ?? string.Empty;
                            }
                            catch
                            {
                                message = "(Description not formatted by provider)";
                            }

                            // Match if provider name matches service name or message mentions service name
                            bool isRelated = provider.Equals(serviceName, StringComparison.OrdinalIgnoreCase)
                                             || provider.IndexOf(serviceName, StringComparison.OrdinalIgnoreCase) >= 0
                                             || message.IndexOf(serviceName, StringComparison.OrdinalIgnoreCase) >= 0;

                            if (isRelated)
                            {
                                string levelName = record.LevelDisplayName ?? (record.Level switch
                                {
                                    1 => "Critical",
                                    2 => "Error",
                                    3 => "Warning",
                                    4 => "Information",
                                    _ => "Verbose"
                                });

                                string xml = string.Empty;
                                try { xml = record.ToXml(); } catch { }

                                results.Add(new WorkerLogEntry
                                {
                                    TimeCreated = record.TimeCreated?.ToLocalTime(),
                                    Level = levelName,
                                    EventId = record.Id,
                                    ProviderName = provider,
                                    LogName = channel,
                                    Message = string.IsNullOrWhiteSpace(message) ? xml : message,
                                    RawXml = xml
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to query {channel} log: {ex.Message}");
                }
            }

            // Order by timestamp descending (newest first)
            results.Sort((a, b) => (b.TimeCreated ?? DateTime.MinValue).CompareTo(a.TimeCreated ?? DateTime.MinValue));

            return results;
        });
    }
}
