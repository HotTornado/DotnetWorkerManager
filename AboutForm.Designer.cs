namespace DotnetWorkerManager;

partial class AboutForm
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
        lblAppTitle = new Label();
        lblVersion = new Label();
        lblDescription = new Label();
        lblAuthor = new Label();
        lnkWebsite = new LinkLabel();
        btnOk = new Button();
        pnlDivider = new Panel();
        SuspendLayout();

        // 
        // lblAppTitle
        // 
        lblAppTitle.AutoSize = true;
        lblAppTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblAppTitle.ForeColor = Color.FromArgb(33, 37, 41);
        lblAppTitle.Location = new Point(24, 20);
        lblAppTitle.Name = "lblAppTitle";
        lblAppTitle.Size = new Size(278, 21);
        lblAppTitle.TabIndex = 0;
        lblAppTitle.Text = "DBK Custom Windows Service Manager";

        // 
        // lblVersion
        // 
        lblVersion.AutoSize = true;
        lblVersion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblVersion.ForeColor = Color.FromArgb(108, 117, 125);
        lblVersion.Location = new Point(25, 45);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new Size(76, 15);
        lblVersion.TabIndex = 1;
        lblVersion.Text = "Version 1.0.0";

        // 
        // lblDescription
        // 
        lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblDescription.ForeColor = Color.FromArgb(73, 80, 87);
        lblDescription.Location = new Point(25, 75);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(395, 36);
        lblDescription.TabIndex = 2;
        lblDescription.Text = "Custom service manager for .NET APIs and Workers with real-time Event Viewer log streaming.";

        // 
        // pnlDivider
        // 
        pnlDivider.BackColor = Color.FromArgb(222, 226, 230);
        pnlDivider.Location = new Point(25, 122);
        pnlDivider.Name = "pnlDivider";
        pnlDivider.Size = new Size(395, 1);
        pnlDivider.TabIndex = 3;

        // 
        // lblAuthor
        // 
        lblAuthor.AutoSize = true;
        lblAuthor.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblAuthor.ForeColor = Color.FromArgb(33, 37, 41);
        lblAuthor.Location = new Point(24, 136);
        lblAuthor.Name = "lblAuthor";
        lblAuthor.Size = new Size(204, 17);
        lblAuthor.TabIndex = 4;
        lblAuthor.Text = "Made by Deniz Berkay KALKAN";

        // 
        // lnkWebsite
        // 
        lnkWebsite.AutoSize = true;
        lnkWebsite.Cursor = Cursors.Hand;
        lnkWebsite.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        lnkWebsite.LinkColor = Color.FromArgb(13, 110, 253);
        lnkWebsite.Location = new Point(24, 160);
        lnkWebsite.Name = "lnkWebsite";
        lnkWebsite.Size = new Size(183, 17);
        lnkWebsite.TabIndex = 5;
        lnkWebsite.TabStop = true;
        lnkWebsite.Text = "https://denizberkaykalkan.com";
        lnkWebsite.LinkClicked += lnkWebsite_LinkClicked;

        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnOk.BackColor = Color.FromArgb(13, 110, 253);
        btnOk.Cursor = Cursors.Hand;
        btnOk.DialogResult = DialogResult.OK;
        btnOk.FlatStyle = FlatStyle.Flat;
        btnOk.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnOk.ForeColor = Color.White;
        btnOk.Location = new Point(335, 200);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(85, 30);
        btnOk.TabIndex = 6;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = false;

        // 
        // AboutForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnOk;
        ClientSize = new Size(445, 246);
        Controls.Add(btnOk);
        Controls.Add(lnkWebsite);
        Controls.Add(lblAuthor);
        Controls.Add(pnlDivider);
        Controls.Add(lblDescription);
        Controls.Add(lblVersion);
        Controls.Add(lblAppTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "About";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblAppTitle;
    private Label lblVersion;
    private Label lblDescription;
    private Panel pnlDivider;
    private Label lblAuthor;
    private LinkLabel lnkWebsite;
    private Button btnOk;
}
