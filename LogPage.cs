using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotnetWorkerManager;

public partial class LogPage : Form
{
    private readonly string _serviceName;
    private readonly System.Windows.Forms.Timer _autoRefreshTimer = new();
    private List<WorkerLogEntry> _currentLogs = new();
    private bool _isLoading;

    public LogPage(string serviceName)
    {
        InitializeComponent();
        _serviceName = serviceName;
        Text = $"{_serviceName} - Event Viewer Logs";
        lblTitle.Text = $"Worker: {_serviceName}";

        ConfigureGrid();

        _autoRefreshTimer.Interval = 3000;
        _autoRefreshTimer.Tick += async (s, e) => await LoadLogsAsync();
    }

    private void ConfigureGrid()
    {
        dgvLogs.AutoGenerateColumns = false;
        dgvLogs.Columns.Clear();

        dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(WorkerLogEntry.TimeCreated),
            HeaderText = "Time",
            Width = 140,
            DefaultCellStyle = { Format = "yyyy-MM-dd HH:mm:ss" }
        });

        dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(WorkerLogEntry.Level),
            HeaderText = "Level",
            Width = 85
        });

        dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(WorkerLogEntry.EventId),
            HeaderText = "Event ID",
            Width = 70
        });

        dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(WorkerLogEntry.LogName),
            HeaderText = "Log",
            Width = 90
        });

        dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(WorkerLogEntry.ProviderName),
            HeaderText = "Source",
            Width = 130
        });

        dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(WorkerLogEntry.Message),
            HeaderText = "Message",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        dgvLogs.EnableHeadersVisualStyles = false;
        dgvLogs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 242, 245);
        dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
        dgvLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        dgvLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvLogs.RowTemplate.Height = 26;
    }

    private async void LogPage_Load(object sender, EventArgs e)
    {
        await LoadLogsAsync();
    }

    private int GetSelectedSeconds()
    {
        return cmbTimeRange.SelectedIndex switch
        {
            0 => 60,       // Last 60 seconds
            1 => 300,      // Last 5 minutes
            2 => 900,      // Last 15 minutes
            3 => 3600,     // Last 1 hour
            _ => 60
        };
    }

    private async Task LoadLogsAsync()
    {
        if (_isLoading) return;
        _isLoading = true;

        try
        {
            lblStatus.Text = "Querying Event Viewer...";
            int seconds = GetSelectedSeconds();
            var logs = await EventLogService.GetRecentLogsAsync(_serviceName, seconds);

            _currentLogs = logs;
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = _currentLogs;

            lblStatus.Text = $"Found {logs.Count} entries ({DateTime.Now:HH:mm:ss})";

            if (logs.Count == 0)
            {
                txtDetails.Text = $"No Event Viewer logs found for '{_serviceName}' in the last {seconds} seconds.\r\nLogs will appear here when the service emits events to Application or System event logs.";
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Query error";
            txtDetails.Text = $"Error reading Event Viewer logs: {ex.Message}";
        }
        finally
        {
            _isLoading = false;
        }
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await LoadLogsAsync();
    }

    private async void cmbTimeRange_SelectedIndexChanged(object sender, EventArgs e)
    {
        await LoadLogsAsync();
    }

    private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAutoRefresh.Checked)
        {
            _autoRefreshTimer.Start();
        }
        else
        {
            _autoRefreshTimer.Stop();
        }
    }

    private void dgvLogs_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvLogs.CurrentRow?.DataBoundItem is WorkerLogEntry entry)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Timestamp] {entry.TimeCreated:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"[Level]     {entry.Level}");
            sb.AppendLine($"[Log Name]  {entry.LogName}");
            sb.AppendLine($"[Source]    {entry.ProviderName}");
            sb.AppendLine($"[Event ID]  {entry.EventId}");
            sb.AppendLine(new string('-', 80));
            sb.AppendLine("[Message]");
            sb.AppendLine(entry.Message);

            if (!string.IsNullOrWhiteSpace(entry.RawXml))
            {
                sb.AppendLine();
                sb.AppendLine(new string('-', 80));
                sb.AppendLine("[Raw XML]");
                sb.AppendLine(entry.RawXml);
            }

            txtDetails.Text = sb.ToString();
        }
    }

    private void dgvLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex < _currentLogs.Count)
        {
            var entry = _currentLogs[e.RowIndex];
            string level = entry.Level.ToLowerInvariant();

            if (e.ColumnIndex == 1 && e.CellStyle != null) // Level column
            {
                if (level.Contains("error") || level.Contains("critical"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                    e.CellStyle.Font = new Font(dgvLogs.Font, FontStyle.Bold);
                }
                else if (level.Contains("warning"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(224, 138, 0);
                    e.CellStyle.Font = new Font(dgvLogs.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(13, 110, 253);
                }
            }
        }
    }

    private void btnCopyAll_Click(object sender, EventArgs e)
    {
        if (_currentLogs.Count == 0)
        {
            MessageBox.Show("No logs to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var sb = new StringBuilder();
        foreach (var item in _currentLogs)
        {
            sb.AppendLine($"[{item.TimeCreated:yyyy-MM-dd HH:mm:ss}] [{item.Level}] [{item.ProviderName} (ID: {item.EventId})]: {item.Message}");
        }

        Clipboard.SetText(sb.ToString());
        MessageBox.Show($"Copied {_currentLogs.Count} log entries to clipboard.", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void LogPage_FormClosing(object sender, FormClosingEventArgs e)
    {
        _autoRefreshTimer.Stop();
    }
}
