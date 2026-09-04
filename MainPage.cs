using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotnetWorkerManager;

public partial class MainPage : Form
{
    private readonly BindingList<ServiceItem> _services = new();
    private readonly System.Windows.Forms.Timer _refreshTimer = new();
    private bool _isRefreshing;

    public MainPage()
    {
        InitializeComponent();

        _refreshTimer.Interval = 4000;
        _refreshTimer.Tick += async (s, e) => await RefreshAllStatusesSilentlyAsync();
    }

    private async void MainPage_Load(object sender, EventArgs e)
    {
        ApplyStyling();
        LoadTrackedServicesFromConfig();
        await RefreshAllStatusesAsync();
        _refreshTimer.Start();

        ServiceConfig.ConfigFileChanged += () =>
        {
            if (IsHandleCreated && !IsDisposed)
            {
                BeginInvoke(new Action(async () =>
                {
                    LoadTrackedServicesFromConfig();
                    await RefreshAllStatusesAsync();
                    statusLabel.Text = $"Reloaded services.json ({DateTime.Now:HH:mm:ss})";
                }));
            }
        };
    }

    private void ApplyStyling()
    {
        dgvServices.AutoGenerateColumns = false;
        dgvServices.DataSource = _services;

        dgvServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
        dgvServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
        dgvServices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        dgvServices.ColumnHeadersHeight = 36;

        dgvServices.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvServices.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
        dgvServices.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
        dgvServices.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
        dgvServices.GridColor = Color.FromArgb(229, 231, 235);
    }

    private void LoadTrackedServicesFromConfig()
    {
        var names = ServiceConfig.LoadTrackedServices();
        _services.Clear();

        foreach (var name in names)
        {
            var item = ServiceManagerService.GetServiceItem(name);
            _services.Add(item);
        }

        statusLabel.Text = $"Tracking {_services.Count} service(s)";
    }

    private async Task RefreshAllStatusesAsync()
    {
        if (_isRefreshing) return;
        _isRefreshing = true;

        statusLabel.Text = "Updating service statuses...";
        try
        {
            await Task.Run(() =>
            {
                foreach (var item in _services)
                {
                    if (!item.IsBusy)
                    {
                        ServiceManagerService.RefreshServiceStatus(item);
                    }
                }
            });

            dgvServices.Refresh();
            lastUpdatedLabel.Text = $"Last updated: {DateTime.Now:HH:mm:ss}";
            statusLabel.Text = $"Tracking {_services.Count} service(s)";
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Refresh error: {ex.Message}";
        }
        finally
        {
            _isRefreshing = false;
        }
    }

    private async Task RefreshAllStatusesSilentlyAsync()
    {
        if (_isRefreshing) return;
        _isRefreshing = true;

        try
        {
            await Task.Run(() =>
            {
                foreach (var item in _services)
                {
                    if (!item.IsBusy)
                    {
                        ServiceManagerService.RefreshServiceStatus(item);
                    }
                }
            });

            dgvServices.Refresh();
            lastUpdatedLabel.Text = $"Last updated: {DateTime.Now:HH:mm:ss}";
        }
        catch
        {
            // Silently ignore background polling errors
        }
        finally
        {
            _isRefreshing = false;
        }
    }

    private void dgvServices_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null) return;

        var item = _services[e.RowIndex];

        // Custom paint button columns: Start (green), Restart (yellow), Stop (red), Show Logs (blue)
        if (e.ColumnIndex == colStart.Index ||
            e.ColumnIndex == colRestart.Index ||
            e.ColumnIndex == colStop.Index ||
            e.ColumnIndex == colLogs.Index)
        {
            e.PaintBackground(e.CellBounds, true);

            string buttonText = "";
            Color backColor = Color.LightGray;
            Color textColor = Color.White;
            bool isEnabled = true;

            if (e.ColumnIndex == colStart.Index)
            {
                buttonText = "Start";
                isEnabled = item.CanStart;
                backColor = isEnabled ? Color.FromArgb(40, 167, 69) : Color.FromArgb(200, 230, 201);
                textColor = isEnabled ? Color.White : Color.FromArgb(120, 120, 120);
            }
            else if (e.ColumnIndex == colRestart.Index)
            {
                buttonText = "Restart";
                isEnabled = item.CanRestart;
                backColor = isEnabled ? Color.FromArgb(255, 193, 7) : Color.FromArgb(255, 243, 205);
                textColor = isEnabled ? Color.FromArgb(33, 37, 41) : Color.FromArgb(160, 160, 160);
            }
            else if (e.ColumnIndex == colStop.Index)
            {
                buttonText = "Stop";
                isEnabled = item.CanStop;
                backColor = isEnabled ? Color.FromArgb(220, 53, 69) : Color.FromArgb(248, 215, 218);
                textColor = isEnabled ? Color.White : Color.FromArgb(120, 120, 120);
            }
            else if (e.ColumnIndex == colLogs.Index)
            {
                buttonText = "Show Logs";
                isEnabled = true;
                backColor = Color.FromArgb(13, 110, 253);
                textColor = Color.White;
            }

            // Draw button background inside cell padding
            var rect = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 4, e.CellBounds.Width - 12, e.CellBounds.Height - 8);
            using (var brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Draw border
            using (var pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }

            // Draw text
            using (var font = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (var textBrush = new SolidBrush(textColor))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(buttonText, font, textBrush, rect, sf);
            }

            e.Handled = true;
            return;
        }

        // Custom paint Current Status column
        if (e.ColumnIndex == colStatus.Index)
        {
            e.PaintBackground(e.CellBounds, true);

            string status = item.StatusText;
            Color badgeBg = Color.FromArgb(243, 244, 246);
            Color badgeText = Color.FromArgb(55, 65, 81);

            if (item.Status == ServiceControllerStatus.Running)
            {
                badgeBg = Color.FromArgb(209, 250, 229);
                badgeText = Color.FromArgb(6, 95, 70);
            }
            else if (item.Status == ServiceControllerStatus.Stopped)
            {
                badgeBg = Color.FromArgb(254, 226, 226);
                badgeText = Color.FromArgb(153, 27, 27);
            }
            else if (item.IsBusy || item.Status == ServiceControllerStatus.StartPending || item.Status == ServiceControllerStatus.StopPending)
            {
                badgeBg = Color.FromArgb(254, 243, 199);
                badgeText = Color.FromArgb(146, 64, 14);
            }

            var badgeRect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);
            using (var brush = new SolidBrush(badgeBg))
            {
                e.Graphics.FillRectangle(brush, badgeRect);
            }

            using (var font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold))
            using (var brush = new SolidBrush(badgeText))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(status, font, brush, badgeRect, sf);
            }

            e.Handled = true;
        }
    }

    private async void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var item = _services[e.RowIndex];

        // Start
        if (e.ColumnIndex == colStart.Index)
        {
            if (!item.CanStart) return;

            item.IsBusy = true;
            item.StatusMessage = "Starting...";
            dgvServices.InvalidateRow(e.RowIndex);

            var (success, msg) = await ServiceManagerService.StartServiceAsync(item.ServiceName);
            ServiceManagerService.RefreshServiceStatus(item);
            item.IsBusy = false;
            dgvServices.InvalidateRow(e.RowIndex);

            if (!success)
            {
                MessageBox.Show(msg, $"Start Failed - {item.ServiceName}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Restart
        else if (e.ColumnIndex == colRestart.Index)
        {
            if (!item.CanRestart) return;

            item.IsBusy = true;
            item.StatusMessage = "Restarting...";
            dgvServices.InvalidateRow(e.RowIndex);

            var (success, msg) = await ServiceManagerService.RestartServiceAsync(item.ServiceName);
            ServiceManagerService.RefreshServiceStatus(item);
            item.IsBusy = false;
            dgvServices.InvalidateRow(e.RowIndex);

            if (!success)
            {
                MessageBox.Show(msg, $"Restart Failed - {item.ServiceName}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Stop
        else if (e.ColumnIndex == colStop.Index)
        {
            if (!item.CanStop) return;

            item.IsBusy = true;
            item.StatusMessage = "Stopping...";
            dgvServices.InvalidateRow(e.RowIndex);

            var (success, msg) = await ServiceManagerService.StopServiceAsync(item.ServiceName);
            ServiceManagerService.RefreshServiceStatus(item);
            item.IsBusy = false;
            dgvServices.InvalidateRow(e.RowIndex);

            if (!success)
            {
                MessageBox.Show(msg, $"Stop Failed - {item.ServiceName}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Show Logs
        else if (e.ColumnIndex == colLogs.Index)
        {
            var logPage = new LogPage(item.ServiceName);
            logPage.Show(this);
        }
    }

    private async void btnRefreshAll_Click(object sender, EventArgs e)
    {
        await RefreshAllStatusesAsync();
    }

    private void btnOpenConfig_Click(object sender, EventArgs e)
    {
        OpenConfigFileInEditor();
    }

    private void btnAddService_Click(object sender, EventArgs e)
    {
        OpenRegisterWorkerDialog();
    }

    private void registerNewWorkerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenRegisterWorkerDialog();
    }

    private void trackExistingServiceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        PromptAddService();
    }

    private async void OpenRegisterWorkerDialog()
    {
        using var form = new RegisterWorkerForm();
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            LoadTrackedServicesFromConfig();
            await RefreshAllStatusesAsync();
        }
    }

    private void editConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenConfigFileInEditor();
    }

    private async void reloadServicesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadTrackedServicesFromConfig();
        await RefreshAllStatusesAsync();
    }

    private async void refreshAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await RefreshAllStatusesAsync();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var aboutForm = new AboutForm();
        aboutForm.ShowDialog(this);
    }

    private void OpenConfigFileInEditor()
    {
        try
        {
            string configPath = ServiceConfig.GetConfigFilePath();
            if (!File.Exists(configPath))
            {
                ServiceConfig.CreateDefaultConfig();
            }

            var psi = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = $"\"{configPath}\"",
                UseShellExecute = true
            };
            var proc = Process.Start(psi);
            if (proc != null)
            {
                proc.EnableRaisingEvents = true;
                proc.Exited += (s, ev) =>
                {
                    if (IsHandleCreated && !IsDisposed)
                    {
                        BeginInvoke(new Action(async () =>
                        {
                            LoadTrackedServicesFromConfig();
                            await RefreshAllStatusesAsync();
                        }));
                    }
                };
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not open services.json: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PromptAddService()
    {
        using var prompt = new Form
        {
            Width = 420,
            Height = 170,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "Add Tracked Service",
            StartPosition = FormStartPosition.CenterParent,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var textLabel = new Label { Left = 20, Top = 15, Text = "Enter Windows Service Name (e.g. MyWorkerService):", AutoSize = true };
        var textBox = new TextBox { Left = 20, Top = 42, Width = 360 };
        var btnOk = new Button { Text = "Add", Left = 210, Width = 80, Top = 80, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel", Left = 300, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };

        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(btnOk);
        prompt.Controls.Add(btnCancel);
        prompt.AcceptButton = btnOk;
        prompt.CancelButton = btnCancel;

        if (prompt.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text))
        {
            string newService = textBox.Text.Trim();

            // Check if already in list
            foreach (var item in _services)
            {
                if (item.ServiceName.Equals(newService, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Service '{newService}' already in tracked list.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            var currentList = ServiceConfig.LoadTrackedServices();
            if (!currentList.Contains(newService))
            {
                currentList.Add(newService);
                ServiceConfig.SaveTrackedServices(currentList);
            }

            var newItem = ServiceManagerService.GetServiceItem(newService);
            _services.Add(newItem);
            statusLabel.Text = $"Tracking {_services.Count} service(s)";
        }
    }
}
