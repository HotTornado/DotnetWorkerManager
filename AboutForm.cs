using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DotnetWorkerManager;

public partial class AboutForm : Form
{
    private const string TargetUrl = "https://denizberkaykalkan.com";

    public AboutForm()
    {
        InitializeComponent();
    }

    private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var result = MessageBox.Show(
            $"You are about to be redirected to an external website:\n\n{TargetUrl}\n\nDo you want to open this page in your default browser?",
            "Redirect Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = TargetUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not open default browser: {ex.Message}",
                    "Browser Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
