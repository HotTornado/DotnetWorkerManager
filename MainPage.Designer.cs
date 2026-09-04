namespace DotnetWorkerManager
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editConfigFileToolStripMenuItem = new ToolStripMenuItem();
            reloadServicesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            servicesToolStripMenuItem = new ToolStripMenuItem();
            registerNewWorkerToolStripMenuItem = new ToolStripMenuItem();
            trackExistingServiceToolStripMenuItem = new ToolStripMenuItem();
            refreshAllToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            topPanel = new Panel();
            btnRefreshAll = new Button();
            btnAddService = new Button();
            btnOpenConfig = new Button();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            dgvServices = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colFullPath = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colStart = new DataGridViewButtonColumn();
            colRestart = new DataGridViewButtonColumn();
            colStop = new DataGridViewButtonColumn();
            colLogs = new DataGridViewButtonColumn();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            lblSpacer = new ToolStripStatusLabel();
            lastUpdatedLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(248, 249, 250);
            menuStrip1.Font = new Font("Segoe UI", 9F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, servicesToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1060, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editConfigFileToolStripMenuItem, reloadServicesToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // editConfigFileToolStripMenuItem
            // 
            editConfigFileToolStripMenuItem.Name = "editConfigFileToolStripMenuItem";
            editConfigFileToolStripMenuItem.Size = new Size(203, 22);
            editConfigFileToolStripMenuItem.Text = "Open / Edit services.json";
            editConfigFileToolStripMenuItem.Click += editConfigFileToolStripMenuItem_Click;
            // 
            // reloadServicesToolStripMenuItem
            // 
            reloadServicesToolStripMenuItem.Name = "reloadServicesToolStripMenuItem";
            reloadServicesToolStripMenuItem.Size = new Size(203, 22);
            reloadServicesToolStripMenuItem.Text = "Reload services.json";
            reloadServicesToolStripMenuItem.Click += reloadServicesToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(200, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(203, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // servicesToolStripMenuItem
            // 
            servicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registerNewWorkerToolStripMenuItem, trackExistingServiceToolStripMenuItem, refreshAllToolStripMenuItem });
            servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            servicesToolStripMenuItem.Size = new Size(61, 20);
            servicesToolStripMenuItem.Text = "Services";
            // 
            // registerNewWorkerToolStripMenuItem
            // 
            registerNewWorkerToolStripMenuItem.Name = "registerNewWorkerToolStripMenuItem";
            registerNewWorkerToolStripMenuItem.Size = new Size(244, 22);
            registerNewWorkerToolStripMenuItem.Text = "Register New Worker (.exe)...";
            registerNewWorkerToolStripMenuItem.Click += registerNewWorkerToolStripMenuItem_Click;
            // 
            // trackExistingServiceToolStripMenuItem
            // 
            trackExistingServiceToolStripMenuItem.Name = "trackExistingServiceToolStripMenuItem";
            trackExistingServiceToolStripMenuItem.Size = new Size(244, 22);
            trackExistingServiceToolStripMenuItem.Text = "Track Existing Service...";
            trackExistingServiceToolStripMenuItem.Click += trackExistingServiceToolStripMenuItem_Click;
            // 
            // refreshAllToolStripMenuItem
            // 
            refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
            refreshAllToolStripMenuItem.Size = new Size(244, 22);
            refreshAllToolStripMenuItem.Text = "Refresh All Statuses";
            refreshAllToolStripMenuItem.Click += refreshAllToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(btnRefreshAll);
            topPanel.Controls.Add(btnAddService);
            topPanel.Controls.Add(btnOpenConfig);
            topPanel.Controls.Add(lblHeaderSubtitle);
            topPanel.Controls.Add(lblHeaderTitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 24);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(16, 12, 16, 12);
            topPanel.Size = new Size(1060, 64);
            topPanel.TabIndex = 1;
            // 
            // btnRefreshAll
            // 
            btnRefreshAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshAll.BackColor = Color.FromArgb(13, 110, 253);
            btnRefreshAll.Cursor = Cursors.Hand;
            btnRefreshAll.FlatStyle = FlatStyle.Flat;
            btnRefreshAll.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRefreshAll.ForeColor = Color.White;
            btnRefreshAll.Location = new Point(948, 16);
            btnRefreshAll.Name = "btnRefreshAll";
            btnRefreshAll.Size = new Size(96, 32);
            btnRefreshAll.TabIndex = 4;
            btnRefreshAll.Text = "Refresh All";
            btnRefreshAll.UseVisualStyleBackColor = false;
            btnRefreshAll.Click += btnRefreshAll_Click;
            // 
            // btnAddService
            // 
            btnAddService.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddService.BackColor = Color.FromArgb(240, 242, 245);
            btnAddService.Cursor = Cursors.Hand;
            btnAddService.FlatStyle = FlatStyle.Flat;
            btnAddService.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddService.ForeColor = Color.FromArgb(33, 37, 41);
            btnAddService.Location = new Point(810, 16);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(130, 32);
            btnAddService.TabIndex = 3;
            btnAddService.Text = "+ Register Worker";
            btnAddService.UseVisualStyleBackColor = false;
            btnAddService.Click += btnAddService_Click;
            // 
            // btnOpenConfig
            // 
            btnOpenConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenConfig.BackColor = Color.FromArgb(240, 242, 245);
            btnOpenConfig.Cursor = Cursors.Hand;
            btnOpenConfig.FlatStyle = FlatStyle.Flat;
            btnOpenConfig.Font = new Font("Segoe UI", 9F);
            btnOpenConfig.ForeColor = Color.FromArgb(33, 37, 41);
            btnOpenConfig.Location = new Point(690, 16);
            btnOpenConfig.Name = "btnOpenConfig";
            btnOpenConfig.Size = new Size(114, 32);
            btnOpenConfig.TabIndex = 2;
            btnOpenConfig.Text = "Edit services.json";
            btnOpenConfig.UseVisualStyleBackColor = false;
            btnOpenConfig.Click += btnOpenConfig_Click;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.25F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblHeaderSubtitle.Location = new Point(16, 36);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(254, 13);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Dedicated Windows Service & API Worker Control";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblHeaderTitle.Location = new Point(14, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(200, 21);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Custom Service Manager";
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.AllowUserToResizeRows = false;
            dgvServices.BackgroundColor = Color.White;
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { colName, colFullPath, colStatus, colStart, colRestart, colStop, colLogs });
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.EnableHeadersVisualStyles = false;
            dgvServices.Location = new Point(0, 88);
            dgvServices.MultiSelect = false;
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersVisible = false;
            dgvServices.RowTemplate.Height = 36;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(1060, 484);
            dgvServices.TabIndex = 2;
            dgvServices.CellContentClick += dgvServices_CellContentClick;
            dgvServices.CellPainting += dgvServices_CellPainting;
            // 
            // colName
            // 
            colName.DataPropertyName = "ServiceName";
            colName.HeaderText = "Name";
            colName.MinimumWidth = 120;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 160;
            // 
            // colFullPath
            // 
            colFullPath.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFullPath.DataPropertyName = "FullPath";
            colFullPath.HeaderText = "Full Path";
            colFullPath.MinimumWidth = 200;
            colFullPath.Name = "colFullPath";
            colFullPath.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "StatusText";
            colStatus.HeaderText = "Current Status";
            colStatus.MinimumWidth = 110;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 130;
            // 
            // colStart
            // 
            colStart.HeaderText = "Start";
            colStart.Name = "colStart";
            colStart.ReadOnly = true;
            colStart.Resizable = DataGridViewTriState.False;
            colStart.Text = "Start";
            colStart.UseColumnTextForButtonValue = true;
            colStart.Width = 90;
            // 
            // colRestart
            // 
            colRestart.HeaderText = "Restart";
            colRestart.Name = "colRestart";
            colRestart.ReadOnly = true;
            colRestart.Resizable = DataGridViewTriState.False;
            colRestart.Text = "Restart";
            colRestart.UseColumnTextForButtonValue = true;
            colRestart.Width = 90;
            // 
            // colStop
            // 
            colStop.HeaderText = "Stop";
            colStop.Name = "colStop";
            colStop.ReadOnly = true;
            colStop.Resizable = DataGridViewTriState.False;
            colStop.Text = "Stop";
            colStop.UseColumnTextForButtonValue = true;
            colStop.Width = 90;
            // 
            // colLogs
            // 
            colLogs.HeaderText = "Logs";
            colLogs.Name = "colLogs";
            colLogs.ReadOnly = true;
            colLogs.Resizable = DataGridViewTriState.False;
            colLogs.Text = "Show Logs";
            colLogs.UseColumnTextForButtonValue = true;
            colLogs.Width = 110;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(248, 249, 250);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel, lblSpacer, lastUpdatedLabel });
            statusStrip1.Location = new Point(0, 572);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1060, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI", 8.25F);
            statusLabel.ForeColor = Color.FromArgb(73, 80, 87);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(38, 17);
            statusLabel.Text = "Ready";
            // 
            // lblSpacer
            // 
            lblSpacer.Name = "lblSpacer";
            lblSpacer.Size = new Size(907, 17);
            lblSpacer.Spring = true;
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            lastUpdatedLabel.ForeColor = Color.FromArgb(108, 117, 125);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new Size(100, 17);
            lastUpdatedLabel.Text = "Last updated: Never";
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 594);
            Controls.Add(dgvServices);
            Controls.Add(statusStrip1);
            Controls.Add(topPanel);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(850, 400);
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DBK - Custom Service Manager";
            Load += MainPage_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editConfigFileToolStripMenuItem;
        private ToolStripMenuItem reloadServicesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem registerNewWorkerToolStripMenuItem;
        private ToolStripMenuItem trackExistingServiceToolStripMenuItem;
        private ToolStripMenuItem refreshAllToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel topPanel;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Button btnRefreshAll;
        private Button btnAddService;
        private Button btnOpenConfig;
        private DataGridView dgvServices;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel lblSpacer;
        private ToolStripStatusLabel lastUpdatedLabel;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colFullPath;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn colStart;
        private DataGridViewButtonColumn colRestart;
        private DataGridViewButtonColumn colStop;
        private DataGridViewButtonColumn colLogs;
    }
}
