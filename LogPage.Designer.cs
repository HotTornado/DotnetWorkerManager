namespace DotnetWorkerManager;

partial class LogPage
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        topPanel = new Panel();
        lblTitle = new Label();
        lblTimeRange = new Label();
        cmbTimeRange = new ComboBox();
        btnRefresh = new Button();
        chkAutoRefresh = new CheckBox();
        btnCopyAll = new Button();
        lblStatus = new Label();
        splitContainer = new SplitContainer();
        dgvLogs = new DataGridView();
        txtDetails = new TextBox();
        lblDetailsHeader = new Label();

        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
        SuspendLayout();

        // 
        // topPanel
        // 
        topPanel.BackColor = Color.FromArgb(245, 247, 250);
        topPanel.Controls.Add(lblStatus);
        topPanel.Controls.Add(btnCopyAll);
        topPanel.Controls.Add(chkAutoRefresh);
        topPanel.Controls.Add(btnRefresh);
        topPanel.Controls.Add(cmbTimeRange);
        topPanel.Controls.Add(lblTimeRange);
        topPanel.Controls.Add(lblTitle);
        topPanel.Dock = DockStyle.Top;
        topPanel.Location = new Point(0, 0);
        topPanel.Name = "topPanel";
        topPanel.Padding = new Padding(12, 10, 12, 10);
        topPanel.Size = new Size(950, 60);
        topPanel.TabIndex = 0;

        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
        lblTitle.Location = new Point(12, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(160, 20);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Worker: [ServiceName]";

        // 
        // lblTimeRange
        // 
        lblTimeRange.AutoSize = true;
        lblTimeRange.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblTimeRange.ForeColor = Color.FromArgb(73, 80, 87);
        lblTimeRange.Location = new Point(280, 20);
        lblTimeRange.Name = "lblTimeRange";
        lblTimeRange.Size = new Size(74, 15);
        lblTimeRange.TabIndex = 1;
        lblTimeRange.Text = "Time Range:";

        // 
        // cmbTimeRange
        // 
        cmbTimeRange.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTimeRange.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        cmbTimeRange.FormattingEnabled = true;
        cmbTimeRange.Items.AddRange(new object[] {
            "Last 60 Seconds",
            "Last 5 Minutes",
            "Last 15 Minutes",
            "Last 1 Hour"
        });
        cmbTimeRange.Location = new Point(360, 16);
        cmbTimeRange.Name = "cmbTimeRange";
        cmbTimeRange.Size = new Size(135, 23);
        cmbTimeRange.TabIndex = 2;
        cmbTimeRange.SelectedIndex = 0;
        cmbTimeRange.SelectedIndexChanged += cmbTimeRange_SelectedIndexChanged;

        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.FromArgb(13, 110, 253);
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.Location = new Point(505, 14);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(95, 28);
        btnRefresh.TabIndex = 3;
        btnRefresh.Text = "Refresh";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;

        // 
        // chkAutoRefresh
        // 
        chkAutoRefresh.AutoSize = true;
        chkAutoRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        chkAutoRefresh.ForeColor = Color.FromArgb(73, 80, 87);
        chkAutoRefresh.Location = new Point(612, 19);
        chkAutoRefresh.Name = "chkAutoRefresh";
        chkAutoRefresh.Size = new Size(125, 19);
        chkAutoRefresh.TabIndex = 4;
        chkAutoRefresh.Text = "Auto-refresh (3s)";
        chkAutoRefresh.UseVisualStyleBackColor = true;
        chkAutoRefresh.CheckedChanged += chkAutoRefresh_CheckedChanged;

        // 
        // btnCopyAll
        // 
        btnCopyAll.BackColor = Color.FromArgb(108, 117, 125);
        btnCopyAll.Cursor = Cursors.Hand;
        btnCopyAll.FlatStyle = FlatStyle.Flat;
        btnCopyAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnCopyAll.ForeColor = Color.White;
        btnCopyAll.Location = new Point(745, 14);
        btnCopyAll.Name = "btnCopyAll";
        btnCopyAll.Size = new Size(80, 28);
        btnCopyAll.TabIndex = 5;
        btnCopyAll.Text = "Copy All";
        btnCopyAll.UseVisualStyleBackColor = false;
        btnCopyAll.Click += btnCopyAll_Click;

        // 
        // lblStatus
        // 
        lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
        lblStatus.ForeColor = Color.FromArgb(108, 117, 125);
        lblStatus.Location = new Point(835, 22);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(90, 13);
        lblStatus.TabIndex = 6;
        lblStatus.Text = "Ready";

        // 
        // splitContainer
        // 
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 60);
        splitContainer.Name = "splitContainer";
        splitContainer.Orientation = Orientation.Horizontal;

        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.Controls.Add(dgvLogs);

        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.Controls.Add(txtDetails);
        splitContainer.Panel2.Controls.Add(lblDetailsHeader);
        splitContainer.Size = new Size(950, 540);
        splitContainer.SplitterDistance = 330;
        splitContainer.SplitterWidth = 6;
        splitContainer.TabIndex = 1;

        // 
        // dgvLogs
        // 
        dgvLogs.AllowUserToAddRows = false;
        dgvLogs.AllowUserToDeleteRows = false;
        dgvLogs.AllowUserToResizeRows = false;
        dgvLogs.BackgroundColor = Color.White;
        dgvLogs.BorderStyle = BorderStyle.None;
        dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvLogs.Dock = DockStyle.Fill;
        dgvLogs.Location = new Point(0, 0);
        dgvLogs.MultiSelect = false;
        dgvLogs.Name = "dgvLogs";
        dgvLogs.ReadOnly = true;
        dgvLogs.RowHeadersVisible = false;
        dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvLogs.Size = new Size(950, 330);
        dgvLogs.TabIndex = 0;
        dgvLogs.SelectionChanged += dgvLogs_SelectionChanged;
        dgvLogs.CellFormatting += dgvLogs_CellFormatting;

        // 
        // lblDetailsHeader
        // 
        lblDetailsHeader.BackColor = Color.FromArgb(233, 236, 239);
        lblDetailsHeader.Dock = DockStyle.Top;
        lblDetailsHeader.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblDetailsHeader.ForeColor = Color.FromArgb(73, 80, 87);
        lblDetailsHeader.Location = new Point(0, 0);
        lblDetailsHeader.Name = "lblDetailsHeader";
        lblDetailsHeader.Padding = new Padding(8, 4, 8, 4);
        lblDetailsHeader.Size = new Size(950, 24);
        lblDetailsHeader.TabIndex = 0;
        lblDetailsHeader.Text = "Event Log Details & Stack Trace";

        // 
        // txtDetails
        // 
        txtDetails.BackColor = Color.FromArgb(248, 249, 250);
        txtDetails.BorderStyle = BorderStyle.None;
        txtDetails.Dock = DockStyle.Fill;
        txtDetails.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txtDetails.Location = new Point(0, 24);
        txtDetails.Multiline = true;
        txtDetails.Name = "txtDetails";
        txtDetails.ReadOnly = true;
        txtDetails.ScrollBars = ScrollBars.Vertical;
        txtDetails.Size = new Size(950, 180);
        txtDetails.TabIndex = 1;

        // 
        // LogPage
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 600);
        Controls.Add(splitContainer);
        Controls.Add(topPanel);
        MinimumSize = new Size(800, 450);
        Name = "LogPage";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Event Viewer Logs";
        Load += LogPage_Load;
        FormClosing += LogPage_FormClosing;
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        splitContainer.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel topPanel;
    private Label lblTitle;
    private Label lblTimeRange;
    private ComboBox cmbTimeRange;
    private Button btnRefresh;
    private CheckBox chkAutoRefresh;
    private Button btnCopyAll;
    private Label lblStatus;
    private SplitContainer splitContainer;
    private DataGridView dgvLogs;
    private Label lblDetailsHeader;
    private TextBox txtDetails;
}
