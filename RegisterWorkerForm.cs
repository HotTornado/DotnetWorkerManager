using System;
using System.IO;
using System.Windows.Forms;

namespace DotnetWorkerManager;

public partial class RegisterWorkerForm : Form
{
    public string RegisteredServiceName { get; private set; } = string.Empty;

    public RegisterWorkerForm()
    {
        InitializeComponent();
        cmbStartupType.SelectedIndex = 0; // Default: Automatic
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Select Worker or API Executable",
            Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*",
            CheckFileExists = true
        };

        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            txtExePath.Text = ofd.FileName;

            // Auto-populate Service Name and Display Name if empty
            string baseName = Path.GetFileNameWithoutExtension(ofd.FileName);
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                txtServiceName.Text = CleanServiceName(baseName);
            }

            if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                txtDisplayName.Text = baseName;
            }
        }
    }

    private async void btnRegister_Click(object sender, EventArgs e)
    {
        string serviceName = txtServiceName.Text.Trim();
        string exePath = txtExePath.Text.Trim();
        string displayName = txtDisplayName.Text.Trim();
        string description = txtDescription.Text.Trim();

        // Validation
        if (string.IsNullOrWhiteSpace(serviceName))
        {
            MessageBox.Show("Please enter a Service Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtServiceName.Focus();
            return;
        }

        if (serviceName.Contains(" ") || serviceName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            MessageBox.Show("Service Name should not contain spaces or special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtServiceName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(exePath))
        {
            MessageBox.Show("Please select or enter the executable path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtExePath.Focus();
            return;
        }

        if (!File.Exists(exePath))
        {
            MessageBox.Show($"File not found at path:\n{exePath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtExePath.Focus();
            return;
        }

        string startType = cmbStartupType.SelectedIndex switch
        {
            1 => "demand",   // Manual
            2 => "disabled", // Disabled
            _ => "auto"      // Automatic
        };

        SetFormBusy(true, "Registering Windows Service...");

        try
        {
            var (success, message) = await ServiceManagerService.RegisterServiceAsync(
                serviceName,
                exePath,
                displayName,
                startType,
                description);

            if (!success)
            {
                SetFormBusy(false, "");
                MessageBox.Show(message, "Service Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add to tracked services.json
            var currentTracked = ServiceConfig.LoadTrackedServices();
            if (!currentTracked.Contains(serviceName))
            {
                currentTracked.Add(serviceName);
                ServiceConfig.SaveTrackedServices(currentTracked);
            }

            // Start immediately if checked
            if (chkStartImmediately.Checked)
            {
                lblStatus.Text = "Starting service...";
                var (startSuccess, startMsg) = await ServiceManagerService.StartServiceAsync(serviceName);
                if (!startSuccess)
                {
                    MessageBox.Show(
                        $"Service registered and added to services.json, but failed to start:\n{startMsg}",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            RegisteredServiceName = serviceName;
            MessageBox.Show(
                $"Worker '{serviceName}' registered as Windows Service and added to services.json successfully!",
                "Registration Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error registering service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetFormBusy(false, "");
        }
    }

    private void SetFormBusy(bool busy, string status)
    {
        btnRegister.Enabled = !busy;
        btnCancel.Enabled = !busy;
        btnBrowse.Enabled = !busy;
        txtServiceName.Enabled = !busy;
        txtExePath.Enabled = !busy;
        txtDisplayName.Enabled = !busy;
        cmbStartupType.Enabled = !busy;
        txtDescription.Enabled = !busy;
        chkStartImmediately.Enabled = !busy;
        lblStatus.Text = status;
        Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
    }

    private static string CleanServiceName(string name)
    {
        var chars = name.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsWhiteSpace(chars[i]))
            {
                chars[i] = '_';
            }
        }
        return new string(chars);
    }
}
