namespace DotnetWorkerManager;

partial class RegisterWorkerForm
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
        lblSubtitle = new Label();
        lblTitle = new Label();
        lblServiceName = new Label();
        txtServiceName = new TextBox();
        lblExePath = new Label();
        txtExePath = new TextBox();
        btnBrowse = new Button();
        lblDisplayName = new Label();
        txtDisplayName = new TextBox();
        lblStartupType = new Label();
        cmbStartupType = new ComboBox();
        lblDescription = new Label();
        txtDescription = new TextBox();
        chkStartImmediately = new CheckBox();
        bottomPanel = new Panel();
        lblStatus = new Label();
        btnCancel = new Button();
        btnRegister = new Button();
        lblServiceHint = new Label();

        topPanel.SuspendLayout();
        bottomPanel.SuspendLayout();
        SuspendLayout();

        // 
        // topPanel
        // 
        topPanel.BackColor = Color.FromArgb(245, 247, 250);
        topPanel.Controls.Add(lblSubtitle);
        topPanel.Controls.Add(lblTitle);
        topPanel.Dock = DockStyle.Top;
        topPanel.Location = new Point(0, 0);
        topPanel.Name = "topPanel";
        topPanel.Padding = new Padding(20, 14, 20, 14);
        topPanel.Size = new Size(580, 68);
        topPanel.TabIndex = 0;

        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblSubtitle.ForeColor = Color.FromArgb(108, 117, 125);
        lblSubtitle.Location = new Point(20, 38);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(331, 13);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Creates a Windows Service from executable and adds to services.json";

        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
        lblTitle.Location = new Point(19, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(244, 20);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Register Worker / API as Service";

        // 
        // lblServiceName
        // 
        lblServiceName.AutoSize = true;
        lblServiceName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblServiceName.Location = new Point(24, 82);
        lblServiceName.Name = "lblServiceName";
        lblServiceName.Size = new Size(119, 15);
        lblServiceName.TabIndex = 1;
        lblServiceName.Text = "Service Identifier: *";

        // 
        // txtServiceName
        // 
        txtServiceName.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        txtServiceName.Location = new Point(24, 102);
        txtServiceName.Name = "txtServiceName";
        txtServiceName.PlaceholderText = "e.g. MyWorkerService";
        txtServiceName.Size = new Size(530, 24);
        txtServiceName.TabIndex = 2;

        // 
        // lblServiceHint
        // 
        lblServiceHint.AutoSize = true;
        lblServiceHint.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
        lblServiceHint.ForeColor = Color.FromArgb(108, 117, 125);
        lblServiceHint.Location = new Point(148, 83);
        lblServiceHint.Name = "lblServiceHint";
        lblServiceHint.Size = new Size(207, 13);
        lblServiceHint.TabIndex = 3;
        lblServiceHint.Text = "(Alphanumeric service name, no spaces)";

        // 
        // lblExePath
        // 
        lblExePath.AutoSize = true;
        lblExePath.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblExePath.Location = new Point(24, 136);
        lblExePath.Name = "lblExePath";
        lblExePath.Size = new Size(185, 15);
        lblExePath.TabIndex = 4;
        lblExePath.Text = "Worker Executable (.exe) Path: *";

        // 
        // txtExePath
        // 
        txtExePath.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        txtExePath.Location = new Point(24, 156);
        txtExePath.Name = "txtExePath";
        txtExePath.PlaceholderText = "C:\\Path\\To\\YourWorker.exe";
        txtExePath.Size = new Size(430, 24);
        txtExePath.TabIndex = 5;

        // 
        // btnBrowse
        // 
        btnBrowse.BackColor = Color.FromArgb(240, 242, 245);
        btnBrowse.Cursor = Cursors.Hand;
        btnBrowse.FlatStyle = FlatStyle.Flat;
        btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnBrowse.ForeColor = Color.FromArgb(33, 37, 41);
        btnBrowse.Location = new Point(464, 154);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new Size(90, 28);
        btnBrowse.TabIndex = 6;
        btnBrowse.Text = "Browse...";
        btnBrowse.UseVisualStyleBackColor = false;
        btnBrowse.Click += btnBrowse_Click;

        // 
        // lblDisplayName
        // 
        lblDisplayName.AutoSize = true;
        lblDisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblDisplayName.Location = new Point(24, 192);
        lblDisplayName.Name = "lblDisplayName";
        lblDisplayName.Size = new Size(137, 15);
        lblDisplayName.TabIndex = 7;
        lblDisplayName.Text = "Display Name (optional):";

        // 
        // txtDisplayName
        // 
        txtDisplayName.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        txtDisplayName.Location = new Point(24, 212);
        txtDisplayName.Name = "txtDisplayName";
        txtDisplayName.PlaceholderText = "Defaults to Service Identifier if empty";
        txtDisplayName.Size = new Size(530, 24);
        txtDisplayName.TabIndex = 8;

        // 
        // lblStartupType
        // 
        lblStartupType.AutoSize = true;
        lblStartupType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblStartupType.Location = new Point(24, 248);
        lblStartupType.Name = "lblStartupType";
        lblStartupType.Size = new Size(76, 15);
        lblStartupType.TabIndex = 9;
        lblStartupType.Text = "Startup Type:";

        // 
        // cmbStartupType
        // 
        cmbStartupType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStartupType.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        cmbStartupType.FormattingEnabled = true;
        cmbStartupType.Items.AddRange(new object[] {
            "Automatic (starts with Windows)",
            "Manual (start on demand)",
            "Disabled"
        });
        cmbStartupType.Location = new Point(24, 268);
        cmbStartupType.Name = "cmbStartupType";
        cmbStartupType.Size = new Size(240, 23);
        cmbStartupType.TabIndex = 10;

        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblDescription.Location = new Point(24, 302);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(124, 15);
        lblDescription.TabIndex = 11;
        lblDescription.Text = "Description (optional):";

        // 
        // txtDescription
        // 
        txtDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        txtDescription.Location = new Point(24, 322);
        txtDescription.Name = "txtDescription";
        txtDescription.PlaceholderText = "Brief description of the worker service";
        txtDescription.Size = new Size(530, 24);
        txtDescription.TabIndex = 12;

        // 
        // chkStartImmediately
        // 
        chkStartImmediately.AutoSize = true;
        chkStartImmediately.Checked = true;
        chkStartImmediately.CheckState = CheckState.Checked;
        chkStartImmediately.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        chkStartImmediately.ForeColor = Color.FromArgb(33, 37, 41);
        chkStartImmediately.Location = new Point(24, 360);
        chkStartImmediately.Name = "chkStartImmediately";
        chkStartImmediately.Size = new Size(251, 19);
        chkStartImmediately.TabIndex = 13;
        chkStartImmediately.Text = "Start service immediately after registration";
        chkStartImmediately.UseVisualStyleBackColor = true;

        // 
        // bottomPanel
        // 
        bottomPanel.BackColor = Color.FromArgb(248, 249, 250);
        bottomPanel.Controls.Add(lblStatus);
        bottomPanel.Controls.Add(btnCancel);
        bottomPanel.Controls.Add(btnRegister);
        bottomPanel.Dock = DockStyle.Bottom;
        bottomPanel.Location = new Point(0, 396);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Padding = new Padding(20, 12, 20, 12);
        bottomPanel.Size = new Size(580, 56);
        bottomPanel.TabIndex = 14;

        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
        lblStatus.ForeColor = Color.FromArgb(108, 117, 125);
        lblStatus.Location = new Point(24, 21);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 13);
        lblStatus.TabIndex = 2;

        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCancel.BackColor = Color.FromArgb(240, 242, 245);
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnCancel.ForeColor = Color.FromArgb(33, 37, 41);
        btnCancel.Location = new Point(464, 12);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 32);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = false;

        // 
        // btnRegister
        // 
        btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRegister.BackColor = Color.FromArgb(25, 135, 84);
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.FlatStyle = FlatStyle.Flat;
        btnRegister.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnRegister.ForeColor = Color.White;
        btnRegister.Location = new Point(318, 12);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(136, 32);
        btnRegister.TabIndex = 0;
        btnRegister.Text = "Register Service";
        btnRegister.UseVisualStyleBackColor = false;
        btnRegister.Click += btnRegister_Click;

        // 
        // RegisterWorkerForm
        // 
        AcceptButton = btnRegister;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(580, 452);
        Controls.Add(bottomPanel);
        Controls.Add(chkStartImmediately);
        Controls.Add(txtDescription);
        Controls.Add(lblDescription);
        Controls.Add(cmbStartupType);
        Controls.Add(lblStartupType);
        Controls.Add(txtDisplayName);
        Controls.Add(lblDisplayName);
        Controls.Add(btnBrowse);
        Controls.Add(txtExePath);
        Controls.Add(lblExePath);
        Controls.Add(lblServiceHint);
        Controls.Add(txtServiceName);
        Controls.Add(lblServiceName);
        Controls.Add(topPanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RegisterWorkerForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Register Worker Service";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel topPanel;
    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblServiceName;
    private TextBox txtServiceName;
    private Label lblServiceHint;
    private Label lblExePath;
    private TextBox txtExePath;
    private Button btnBrowse;
    private Label lblDisplayName;
    private TextBox txtDisplayName;
    private Label lblStartupType;
    private ComboBox cmbStartupType;
    private Label lblDescription;
    private TextBox txtDescription;
    private CheckBox chkStartImmediately;
    private Panel bottomPanel;
    private Button btnRegister;
    private Button btnCancel;
    private Label lblStatus;
}
