namespace RaceAdmin
{
    public partial class RaceAdminMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceAdminMain));
			this.incidentsRequiredForCautionLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewIncidentTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewIncidentsCountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewCautionPanelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutRaceAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugTab = new System.Windows.Forms.TabPage();
			this.debugTable = new Zuby.ADGV.AdvancedDataGridView();
			this.debugSettingsGroupbox = new System.Windows.Forms.GroupBox();
			this.filterNotInWorldCheckBox = new System.Windows.Forms.CheckBox();
			this.telemetryPollRateTextBox = new System.Windows.Forms.TextBox();
			this.hzLabel = new System.Windows.Forms.Label();
			this.telemetryPollRateLabel = new System.Windows.Forms.Label();
			this.mainTab = new System.Windows.Forms.TabPage();
			this.visibleIncidentsLabel = new System.Windows.Forms.Label();
			this.visibleIncidentsNum = new System.Windows.Forms.Label();
			this.visibleRowsLabel = new System.Windows.Forms.Label();
			this.visibleRowsNum = new System.Windows.Forms.Label();
			this.addTestRowButton = new System.Windows.Forms.Button();
			this.timeFrameFilterComboBox2 = new System.Windows.Forms.ComboBox();
			this.timeFrameFilterComboBox1 = new System.Windows.Forms.ComboBox();
			this.incidentsTimeFilterComboBox = new System.Windows.Forms.ComboBox();
			this.timeFrameFilterLabel2 = new System.Windows.Forms.Label();
			this.timeFrameFilterErrorText = new System.Windows.Forms.Label();
			this.timeFrameFilterLabel1 = new System.Windows.Forms.Label();
			this.incidentsTimeFilterLabel = new System.Windows.Forms.Label();
			this.incidentsSinceCautionNum = new System.Windows.Forms.Label();
			this.incidentsSinceCautionLabel = new System.Windows.Forms.Label();
			this.totalIncidentCountLabel = new System.Windows.Forms.Label();
			this.totalIncidentCountNum = new System.Windows.Forms.Label();
			this.incidentsView = new Zuby.ADGV.AdvancedDataGridView();
			this.cautionPanel = new System.Windows.Forms.Panel();
			this.resetIncidentsSinceLastCautionButton = new System.Windows.Forms.Button();
			this.resetTotalIncidentCountButton = new System.Windows.Forms.Button();
			this.sessionLabel = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.menuStrip.SuspendLayout();
			this.debugTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.debugTable)).BeginInit();
			this.debugSettingsGroupbox.SuspendLayout();
			this.mainTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidentsView)).BeginInit();
			this.cautionPanel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// incidentsRequiredForCautionLabel
			// 
			this.incidentsRequiredForCautionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.incidentsRequiredForCautionLabel.Font = new System.Drawing.Font("Arial", 9.75F);
			this.incidentsRequiredForCautionLabel.Location = new System.Drawing.Point(64, 70);
			this.incidentsRequiredForCautionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.incidentsRequiredForCautionLabel.Name = "incidentsRequiredForCautionLabel";
			this.incidentsRequiredForCautionLabel.Size = new System.Drawing.Size(179, 23);
			this.incidentsRequiredForCautionLabel.TabIndex = 1;
			this.incidentsRequiredForCautionLabel.Text = "incidents required for caution";
			this.incidentsRequiredForCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(144, 215);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(162, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "minutes (timed races only)";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 215);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "During last";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(144, 189);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(161, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "laps (lap count races only)";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 189);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "During last";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 165);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "No cautions:";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1264, 24);
			this.menuStrip.TabIndex = 12;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fIleToolStripMenuItem
			// 
			this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTableMenuItem,
            this.exitMenuItem});
			this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
			this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fIleToolStripMenuItem.Text = "FIle";
			// 
			// exportTableMenuItem
			// 
			this.exportTableMenuItem.Name = "exportTableMenuItem";
			this.exportTableMenuItem.Size = new System.Drawing.Size(138, 22);
			this.exportTableMenuItem.Text = "Export Table";
			this.exportTableMenuItem.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Size = new System.Drawing.Size(138, 22);
			this.exitMenuItem.Text = "Exit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.settingsToolStripMenuItem.Text = "Edit";
			// 
			// settingsMenuItem
			// 
			this.settingsMenuItem.Name = "settingsMenuItem";
			this.settingsMenuItem.Size = new System.Drawing.Size(116, 22);
			this.settingsMenuItem.Text = "Settings";
			this.settingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewIncidentTableMenuItem,
            this.viewIncidentsCountMenuItem,
            this.viewCautionPanelMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// viewIncidentTableMenuItem
			// 
			this.viewIncidentTableMenuItem.Checked = true;
			this.viewIncidentTableMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewIncidentTableMenuItem.Name = "viewIncidentTableMenuItem";
			this.viewIncidentTableMenuItem.Size = new System.Drawing.Size(158, 22);
			this.viewIncidentTableMenuItem.Text = "Incident Table";
			this.viewIncidentTableMenuItem.CheckedChanged += new System.EventHandler(this.viewIncidentTableMenuItem_CheckedChanged);
			this.viewIncidentTableMenuItem.Click += new System.EventHandler(this.viewIncidentTableMenuItem_Click);
			// 
			// viewIncidentsCountMenuItem
			// 
			this.viewIncidentsCountMenuItem.Checked = true;
			this.viewIncidentsCountMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewIncidentsCountMenuItem.Name = "viewIncidentsCountMenuItem";
			this.viewIncidentsCountMenuItem.Size = new System.Drawing.Size(158, 22);
			this.viewIncidentsCountMenuItem.Text = "Incidents Count";
			this.viewIncidentsCountMenuItem.CheckedChanged += new System.EventHandler(this.viewIncidentsCountMenuItem_CheckedChanged);
			this.viewIncidentsCountMenuItem.Click += new System.EventHandler(this.viewIncidentsCountMenuItem_Click);
			// 
			// viewCautionPanelMenuItem
			// 
			this.viewCautionPanelMenuItem.Checked = true;
			this.viewCautionPanelMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewCautionPanelMenuItem.Name = "viewCautionPanelMenuItem";
			this.viewCautionPanelMenuItem.Size = new System.Drawing.Size(158, 22);
			this.viewCautionPanelMenuItem.Text = "Caution Panel";
			this.viewCautionPanelMenuItem.CheckedChanged += new System.EventHandler(this.viewCautionPanelMenuItem_CheckedChanged);
			this.viewCautionPanelMenuItem.Click += new System.EventHandler(this.viewCautionPanelMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutRaceAdministratorToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// aboutRaceAdministratorToolStripMenuItem
			// 
			this.aboutRaceAdministratorToolStripMenuItem.Name = "aboutRaceAdministratorToolStripMenuItem";
			this.aboutRaceAdministratorToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			this.aboutRaceAdministratorToolStripMenuItem.Text = "About Race Administrator";
			this.aboutRaceAdministratorToolStripMenuItem.Click += new System.EventHandler(this.aboutRaceAdministratorToolStripMenuItem_Click);
			// 
			// debugTab
			// 
			this.debugTab.Controls.Add(this.debugTable);
			this.debugTab.Controls.Add(this.debugSettingsGroupbox);
			this.debugTab.Location = new System.Drawing.Point(4, 22);
			this.debugTab.Name = "debugTab";
			this.debugTab.Padding = new System.Windows.Forms.Padding(3);
			this.debugTab.Size = new System.Drawing.Size(1256, 631);
			this.debugTab.TabIndex = 3;
			this.debugTab.Text = "Cars Live";
			this.debugTab.UseVisualStyleBackColor = true;
			// 
			// debugTable
			// 
			this.debugTable.AllowUserToAddRows = false;
			this.debugTable.AllowUserToDeleteRows = false;
			this.debugTable.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.debugTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.debugTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.debugTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.debugTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.debugTable.ColumnHeadersHeight = 25;
			this.debugTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.debugTable.DefaultCellStyle = dataGridViewCellStyle3;
			this.debugTable.FilterAndSortEnabled = true;
			this.debugTable.Location = new System.Drawing.Point(1, 60);
			this.debugTable.Margin = new System.Windows.Forms.Padding(1);
			this.debugTable.MinimumSize = new System.Drawing.Size(1254, 568);
			this.debugTable.Name = "debugTable";
			this.debugTable.ReadOnly = true;
			this.debugTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.debugTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.debugTable.RowHeadersVisible = false;
			this.debugTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.debugTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.debugTable.ShowCellErrors = false;
			this.debugTable.ShowCellToolTips = false;
			this.debugTable.ShowEditingIcon = false;
			this.debugTable.ShowRowErrors = false;
			this.debugTable.Size = new System.Drawing.Size(1254, 568);
			this.debugTable.TabIndex = 10;
			this.debugTable.TabStop = false;
			// 
			// debugSettingsGroupbox
			// 
			this.debugSettingsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.debugSettingsGroupbox.BackColor = System.Drawing.SystemColors.Control;
			this.debugSettingsGroupbox.Controls.Add(this.filterNotInWorldCheckBox);
			this.debugSettingsGroupbox.Controls.Add(this.telemetryPollRateTextBox);
			this.debugSettingsGroupbox.Controls.Add(this.hzLabel);
			this.debugSettingsGroupbox.Controls.Add(this.telemetryPollRateLabel);
			this.debugSettingsGroupbox.Location = new System.Drawing.Point(1, 1);
			this.debugSettingsGroupbox.Name = "debugSettingsGroupbox";
			this.debugSettingsGroupbox.Size = new System.Drawing.Size(1256, 58);
			this.debugSettingsGroupbox.TabIndex = 9;
			this.debugSettingsGroupbox.TabStop = false;
			this.debugSettingsGroupbox.Text = "Settings";
			// 
			// filterNotInWorldCheckBox
			// 
			this.filterNotInWorldCheckBox.AutoSize = true;
			this.filterNotInWorldCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterNotInWorldCheckBox.Location = new System.Drawing.Point(195, 24);
			this.filterNotInWorldCheckBox.Name = "filterNotInWorldCheckBox";
			this.filterNotInWorldCheckBox.Size = new System.Drawing.Size(130, 21);
			this.filterNotInWorldCheckBox.TabIndex = 2;
			this.filterNotInWorldCheckBox.Text = "Hide NotInWorld";
			this.filterNotInWorldCheckBox.UseVisualStyleBackColor = true;
			this.filterNotInWorldCheckBox.CheckedChanged += new System.EventHandler(this.filterNotInWorldCheckBox_CheckedChanged);
			// 
			// telemetryPollRateTextBox
			// 
			this.telemetryPollRateTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.telemetryPollRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.telemetryPollRateTextBox.Location = new System.Drawing.Point(131, 22);
			this.telemetryPollRateTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.telemetryPollRateTextBox.MaxLength = 2;
			this.telemetryPollRateTextBox.Name = "telemetryPollRateTextBox";
			this.telemetryPollRateTextBox.Size = new System.Drawing.Size(32, 23);
			this.telemetryPollRateTextBox.TabIndex = 1;
			this.telemetryPollRateTextBox.Text = "4";
			this.telemetryPollRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.telemetryPollRateTextBox.TextChanged += new System.EventHandler(this.telemetryPollRateTextBox_TextChanged);
			// 
			// hzLabel
			// 
			this.hzLabel.AutoSize = true;
			this.hzLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hzLabel.Location = new System.Drawing.Point(163, 25);
			this.hzLabel.Margin = new System.Windows.Forms.Padding(0);
			this.hzLabel.Name = "hzLabel";
			this.hzLabel.Size = new System.Drawing.Size(29, 17);
			this.hzLabel.TabIndex = 0;
			this.hzLabel.Text = "Hz.";
			this.hzLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// telemetryPollRateLabel
			// 
			this.telemetryPollRateLabel.AutoSize = true;
			this.telemetryPollRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.telemetryPollRateLabel.Location = new System.Drawing.Point(6, 25);
			this.telemetryPollRateLabel.Margin = new System.Windows.Forms.Padding(0);
			this.telemetryPollRateLabel.Name = "telemetryPollRateLabel";
			this.telemetryPollRateLabel.Size = new System.Drawing.Size(134, 17);
			this.telemetryPollRateLabel.TabIndex = 0;
			this.telemetryPollRateLabel.Text = "Telemetry poll rate: ";
			this.telemetryPollRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mainTab
			// 
			this.mainTab.BackColor = System.Drawing.SystemColors.Control;
			this.mainTab.Controls.Add(this.resetIncidentsSinceLastCautionButton);
			this.mainTab.Controls.Add(this.resetTotalIncidentCountButton);
			this.mainTab.Controls.Add(this.visibleIncidentsLabel);
			this.mainTab.Controls.Add(this.visibleIncidentsNum);
			this.mainTab.Controls.Add(this.visibleRowsLabel);
			this.mainTab.Controls.Add(this.visibleRowsNum);
			this.mainTab.Controls.Add(this.addTestRowButton);
			this.mainTab.Controls.Add(this.timeFrameFilterComboBox2);
			this.mainTab.Controls.Add(this.timeFrameFilterComboBox1);
			this.mainTab.Controls.Add(this.incidentsTimeFilterComboBox);
			this.mainTab.Controls.Add(this.timeFrameFilterLabel2);
			this.mainTab.Controls.Add(this.timeFrameFilterErrorText);
			this.mainTab.Controls.Add(this.timeFrameFilterLabel1);
			this.mainTab.Controls.Add(this.incidentsTimeFilterLabel);
			this.mainTab.Controls.Add(this.incidentsSinceCautionNum);
			this.mainTab.Controls.Add(this.incidentsSinceCautionLabel);
			this.mainTab.Controls.Add(this.totalIncidentCountLabel);
			this.mainTab.Controls.Add(this.totalIncidentCountNum);
			this.mainTab.Controls.Add(this.incidentsView);
			this.mainTab.Controls.Add(this.cautionPanel);
			this.mainTab.Location = new System.Drawing.Point(4, 22);
			this.mainTab.Margin = new System.Windows.Forms.Padding(1);
			this.mainTab.Name = "mainTab";
			this.mainTab.Padding = new System.Windows.Forms.Padding(1);
			this.mainTab.Size = new System.Drawing.Size(1256, 631);
			this.mainTab.TabIndex = 0;
			this.mainTab.Text = "Main";
			// 
			// visibleIncidentsLabel
			// 
			this.visibleIncidentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.visibleIncidentsLabel.AutoSize = true;
			this.visibleIncidentsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.visibleIncidentsLabel.Location = new System.Drawing.Point(851, 85);
			this.visibleIncidentsLabel.Name = "visibleIncidentsLabel";
			this.visibleIncidentsLabel.Size = new System.Drawing.Size(125, 18);
			this.visibleIncidentsLabel.TabIndex = 11;
			this.visibleIncidentsLabel.Text = "Visible Incidents:";
			this.visibleIncidentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// visibleIncidentsNum
			// 
			this.visibleIncidentsNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.visibleIncidentsNum.AutoSize = true;
			this.visibleIncidentsNum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.visibleIncidentsNum.Location = new System.Drawing.Point(973, 85);
			this.visibleIncidentsNum.Name = "visibleIncidentsNum";
			this.visibleIncidentsNum.Size = new System.Drawing.Size(47, 18);
			this.visibleIncidentsNum.TabIndex = 10;
			this.visibleIncidentsNum.Text = "0 of 0";
			// 
			// visibleRowsLabel
			// 
			this.visibleRowsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.visibleRowsLabel.AutoSize = true;
			this.visibleRowsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.visibleRowsLabel.Location = new System.Drawing.Point(656, 85);
			this.visibleRowsLabel.Name = "visibleRowsLabel";
			this.visibleRowsLabel.Size = new System.Drawing.Size(103, 18);
			this.visibleRowsLabel.TabIndex = 11;
			this.visibleRowsLabel.Text = "Visible Rows:";
			this.visibleRowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// visibleRowsNum
			// 
			this.visibleRowsNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.visibleRowsNum.AutoSize = true;
			this.visibleRowsNum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.visibleRowsNum.Location = new System.Drawing.Point(756, 85);
			this.visibleRowsNum.Name = "visibleRowsNum";
			this.visibleRowsNum.Size = new System.Drawing.Size(47, 18);
			this.visibleRowsNum.TabIndex = 10;
			this.visibleRowsNum.Text = "0 of 0";
			// 
			// addTestRowButton
			// 
			this.addTestRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addTestRowButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addTestRowButton.Location = new System.Drawing.Point(1088, 79);
			this.addTestRowButton.Name = "addTestRowButton";
			this.addTestRowButton.Size = new System.Drawing.Size(160, 30);
			this.addTestRowButton.TabIndex = 9;
			this.addTestRowButton.Text = "Populate Incidents";
			this.addTestRowButton.UseVisualStyleBackColor = true;
			this.addTestRowButton.Click += new System.EventHandler(this.addTestRowButton_Click);
			// 
			// timeFrameFilterComboBox2
			// 
			this.timeFrameFilterComboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.timeFrameFilterComboBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timeFrameFilterComboBox2.Items.AddRange(new object[] {
            "None",
            "0:00",
            "1:00",
            "2:00",
            "3:00",
            "4:00",
            "5:00",
            "6:00",
            "7:00",
            "8:00",
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00",
            "24:00"});
			this.timeFrameFilterComboBox2.Location = new System.Drawing.Point(341, 82);
			this.timeFrameFilterComboBox2.MaxDropDownItems = 6;
			this.timeFrameFilterComboBox2.Name = "timeFrameFilterComboBox2";
			this.timeFrameFilterComboBox2.Size = new System.Drawing.Size(70, 26);
			this.timeFrameFilterComboBox2.TabIndex = 8;
			this.timeFrameFilterComboBox2.TabStop = false;
			this.timeFrameFilterComboBox2.SelectedIndexChanged += new System.EventHandler(this.timeFrameFilterComboBox2_SelectedIndexChanged);
			// 
			// timeFrameFilterComboBox1
			// 
			this.timeFrameFilterComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.timeFrameFilterComboBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timeFrameFilterComboBox1.Items.AddRange(new object[] {
            "None",
            "0:00",
            "1:00",
            "2:00",
            "3:00",
            "4:00",
            "5:00",
            "6:00",
            "7:00",
            "8:00",
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00",
            "24:00"});
			this.timeFrameFilterComboBox1.Location = new System.Drawing.Point(246, 82);
			this.timeFrameFilterComboBox1.MaxDropDownItems = 6;
			this.timeFrameFilterComboBox1.Name = "timeFrameFilterComboBox1";
			this.timeFrameFilterComboBox1.Size = new System.Drawing.Size(70, 26);
			this.timeFrameFilterComboBox1.TabIndex = 8;
			this.timeFrameFilterComboBox1.TabStop = false;
			this.timeFrameFilterComboBox1.SelectedIndexChanged += new System.EventHandler(this.timeFrameFilterComboBox1_SelectedIndexChanged);
			// 
			// incidentsTimeFilterComboBox
			// 
			this.incidentsTimeFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.incidentsTimeFilterComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incidentsTimeFilterComboBox.Items.AddRange(new object[] {
            "Forever",
            "30 Minutes",
            "60 Minutes",
            "90 Minutes",
            "120 Minutes",
            "180 Minutes"});
			this.incidentsTimeFilterComboBox.Location = new System.Drawing.Point(53, 82);
			this.incidentsTimeFilterComboBox.MaxDropDownItems = 6;
			this.incidentsTimeFilterComboBox.Name = "incidentsTimeFilterComboBox";
			this.incidentsTimeFilterComboBox.Size = new System.Drawing.Size(121, 26);
			this.incidentsTimeFilterComboBox.TabIndex = 8;
			this.incidentsTimeFilterComboBox.TabStop = false;
			this.incidentsTimeFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.incidentsTimeFilterComboBox_SelectedIndexChanged);
			// 
			// timeFrameFilterLabel2
			// 
			this.timeFrameFilterLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.timeFrameFilterLabel2.AutoSize = true;
			this.timeFrameFilterLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timeFrameFilterLabel2.Location = new System.Drawing.Point(318, 85);
			this.timeFrameFilterLabel2.Name = "timeFrameFilterLabel2";
			this.timeFrameFilterLabel2.Size = new System.Drawing.Size(21, 18);
			this.timeFrameFilterLabel2.TabIndex = 7;
			this.timeFrameFilterLabel2.Text = "to";
			// 
			// timeFrameFilterErrorText
			// 
			this.timeFrameFilterErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.timeFrameFilterErrorText.AutoSize = true;
			this.timeFrameFilterErrorText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timeFrameFilterErrorText.Location = new System.Drawing.Point(413, 85);
			this.timeFrameFilterErrorText.Name = "timeFrameFilterErrorText";
			this.timeFrameFilterErrorText.Size = new System.Drawing.Size(53, 18);
			this.timeFrameFilterErrorText.TabIndex = 7;
			this.timeFrameFilterErrorText.Text = "NONE";
			this.timeFrameFilterErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// timeFrameFilterLabel1
			// 
			this.timeFrameFilterLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.timeFrameFilterLabel1.AutoSize = true;
			this.timeFrameFilterLabel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timeFrameFilterLabel1.Location = new System.Drawing.Point(201, 85);
			this.timeFrameFilterLabel1.Name = "timeFrameFilterLabel1";
			this.timeFrameFilterLabel1.Size = new System.Drawing.Size(45, 18);
			this.timeFrameFilterLabel1.TabIndex = 7;
			this.timeFrameFilterLabel1.Text = "From";
			// 
			// incidentsTimeFilterLabel
			// 
			this.incidentsTimeFilterLabel.AutoSize = true;
			this.incidentsTimeFilterLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incidentsTimeFilterLabel.Location = new System.Drawing.Point(5, 85);
			this.incidentsTimeFilterLabel.Name = "incidentsTimeFilterLabel";
			this.incidentsTimeFilterLabel.Size = new System.Drawing.Size(42, 18);
			this.incidentsTimeFilterLabel.TabIndex = 7;
			this.incidentsTimeFilterLabel.Text = "Last:";
			// 
			// incidentsSinceCautionNum
			// 
			this.incidentsSinceCautionNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.incidentsSinceCautionNum.BackColor = System.Drawing.Color.Transparent;
			this.incidentsSinceCautionNum.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incidentsSinceCautionNum.Location = new System.Drawing.Point(953, 2);
			this.incidentsSinceCautionNum.Margin = new System.Windows.Forms.Padding(1);
			this.incidentsSinceCautionNum.Name = "incidentsSinceCautionNum";
			this.incidentsSinceCautionNum.Size = new System.Drawing.Size(150, 73);
			this.incidentsSinceCautionNum.TabIndex = 6;
			this.incidentsSinceCautionNum.Text = "0";
			this.incidentsSinceCautionNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// incidentsSinceCautionLabel
			// 
			this.incidentsSinceCautionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.incidentsSinceCautionLabel.BackColor = System.Drawing.Color.Transparent;
			this.incidentsSinceCautionLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incidentsSinceCautionLabel.Location = new System.Drawing.Point(707, 2);
			this.incidentsSinceCautionLabel.Margin = new System.Windows.Forms.Padding(1);
			this.incidentsSinceCautionLabel.Name = "incidentsSinceCautionLabel";
			this.incidentsSinceCautionLabel.Size = new System.Drawing.Size(253, 73);
			this.incidentsSinceCautionLabel.TabIndex = 5;
			this.incidentsSinceCautionLabel.Text = "Since Last Caution:";
			this.incidentsSinceCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// totalIncidentCountLabel
			// 
			this.totalIncidentCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.totalIncidentCountLabel.BackColor = System.Drawing.Color.Transparent;
			this.totalIncidentCountLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.totalIncidentCountLabel.Location = new System.Drawing.Point(307, 2);
			this.totalIncidentCountLabel.Margin = new System.Windows.Forms.Padding(1);
			this.totalIncidentCountLabel.Name = "totalIncidentCountLabel";
			this.totalIncidentCountLabel.Size = new System.Drawing.Size(200, 73);
			this.totalIncidentCountLabel.TabIndex = 3;
			this.totalIncidentCountLabel.Text = "Total Incidents:";
			this.totalIncidentCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// totalIncidentCountNum
			// 
			this.totalIncidentCountNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.totalIncidentCountNum.BackColor = System.Drawing.Color.Transparent;
			this.totalIncidentCountNum.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.totalIncidentCountNum.Location = new System.Drawing.Point(498, 2);
			this.totalIncidentCountNum.Margin = new System.Windows.Forms.Padding(1);
			this.totalIncidentCountNum.Name = "totalIncidentCountNum";
			this.totalIncidentCountNum.Size = new System.Drawing.Size(150, 73);
			this.totalIncidentCountNum.TabIndex = 4;
			this.totalIncidentCountNum.Text = "0";
			this.totalIncidentCountNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// incidentsView
			// 
			this.incidentsView.AllowUserToAddRows = false;
			this.incidentsView.AllowUserToDeleteRows = false;
			this.incidentsView.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.incidentsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.incidentsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.incidentsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.incidentsView.ColumnHeadersHeight = 25;
			this.incidentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsView.DefaultCellStyle = dataGridViewCellStyle6;
			this.incidentsView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.incidentsView.FilterAndSortEnabled = true;
			this.incidentsView.Location = new System.Drawing.Point(1, 112);
			this.incidentsView.Margin = new System.Windows.Forms.Padding(1);
			this.incidentsView.MinimumSize = new System.Drawing.Size(1254, 270);
			this.incidentsView.Name = "incidentsView";
			this.incidentsView.ReadOnly = true;
			this.incidentsView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.incidentsView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.incidentsView.RowHeadersVisible = false;
			this.incidentsView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.incidentsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.incidentsView.ShowCellErrors = false;
			this.incidentsView.ShowCellToolTips = false;
			this.incidentsView.ShowEditingIcon = false;
			this.incidentsView.ShowRowErrors = false;
			this.incidentsView.Size = new System.Drawing.Size(1254, 519);
			this.incidentsView.TabIndex = 1;
			this.incidentsView.TabStop = false;
			// 
			// cautionPanel
			// 
			this.cautionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cautionPanel.BackColor = System.Drawing.SystemColors.Control;
			this.cautionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cautionPanel.Controls.Add(this.sessionLabel);
			this.cautionPanel.Location = new System.Drawing.Point(1, 1);
			this.cautionPanel.Margin = new System.Windows.Forms.Padding(1);
			this.cautionPanel.MinimumSize = new System.Drawing.Size(1254, 75);
			this.cautionPanel.Name = "cautionPanel";
			this.cautionPanel.Size = new System.Drawing.Size(1254, 75);
			this.cautionPanel.TabIndex = 0;
			this.cautionPanel.BackColorChanged += new System.EventHandler(this.cautionPanel_BackColorChanged);
			this.cautionPanel.VisibleChanged += new System.EventHandler(this.cautionPanel_VisibleChanged);
			// 
			// resetIncidentsSinceLastCautionButton
			// 
			this.resetIncidentsSinceLastCautionButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resetIncidentsSinceLastCautionButton.BackgroundImage = global::RaceAdmin.Properties.Resources.ResetArrow;
			this.resetIncidentsSinceLastCautionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.resetIncidentsSinceLastCautionButton.Location = new System.Drawing.Point(671, 22);
			this.resetIncidentsSinceLastCautionButton.Name = "resetIncidentsSinceLastCautionButton";
			this.resetIncidentsSinceLastCautionButton.Size = new System.Drawing.Size(30, 30);
			this.resetIncidentsSinceLastCautionButton.TabIndex = 1;
			this.resetIncidentsSinceLastCautionButton.UseVisualStyleBackColor = true;
			this.resetIncidentsSinceLastCautionButton.Click += new System.EventHandler(this.resetIncidentsSinceLastCautionButton_Click);
			// 
			// resetTotalIncidentCountButton
			// 
			this.resetTotalIncidentCountButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resetTotalIncidentCountButton.BackgroundImage = global::RaceAdmin.Properties.Resources.ResetArrow;
			this.resetTotalIncidentCountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.resetTotalIncidentCountButton.Location = new System.Drawing.Point(271, 22);
			this.resetTotalIncidentCountButton.Name = "resetTotalIncidentCountButton";
			this.resetTotalIncidentCountButton.Size = new System.Drawing.Size(30, 30);
			this.resetTotalIncidentCountButton.TabIndex = 1;
			this.resetTotalIncidentCountButton.UseVisualStyleBackColor = true;
			this.resetTotalIncidentCountButton.Click += new System.EventHandler(this.resetTotalIncidentCountButton_Click);
			// 
			// sessionLabel
			// 
			this.sessionLabel.AutoSize = true;
			this.sessionLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sessionLabel.Location = new System.Drawing.Point(3, 3);
			this.sessionLabel.Name = "sessionLabel";
			this.sessionLabel.Size = new System.Drawing.Size(105, 18);
			this.sessionLabel.TabIndex = 0;
			this.sessionLabel.Text = "NO SESSION";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.mainTab);
			this.tabControl.Controls.Add(this.debugTab);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 24);
			this.tabControl.Margin = new System.Windows.Forms.Padding(1);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1264, 657);
			this.tabControl.TabIndex = 1;
			// 
			// RaceAdminMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(1280, 720);
			this.Name = "RaceAdminMain";
			this.Text = "Race Administrator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaceAdminMain_FormClosing);
			this.Load += new System.EventHandler(this.RaceAdminMain_Load);
			this.ResizeEnd += new System.EventHandler(this.RaceAdminMain_ResizeEnd);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.debugTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.debugTable)).EndInit();
			this.debugSettingsGroupbox.ResumeLayout(false);
			this.debugSettingsGroupbox.PerformLayout();
			this.mainTab.ResumeLayout(false);
			this.mainTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidentsView)).EndInit();
			this.cautionPanel.ResumeLayout(false);
			this.cautionPanel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label incidentsRequiredForCautionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportTableMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewIncidentTableMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewCautionPanelMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutRaceAdministratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewIncidentsCountMenuItem;
		private System.Windows.Forms.TabPage debugTab;
		private System.Windows.Forms.GroupBox debugSettingsGroupbox;
		private System.Windows.Forms.CheckBox filterNotInWorldCheckBox;
		private System.Windows.Forms.TextBox telemetryPollRateTextBox;
		private System.Windows.Forms.Label hzLabel;
		private System.Windows.Forms.Label telemetryPollRateLabel;
		private System.Windows.Forms.TabPage mainTab;
		private System.Windows.Forms.Label incidentsSinceCautionNum;
		private System.Windows.Forms.Label incidentsSinceCautionLabel;
		private System.Windows.Forms.Label totalIncidentCountLabel;
		private System.Windows.Forms.Label totalIncidentCountNum;
		private Zuby.ADGV.AdvancedDataGridView incidentsView;
		private System.Windows.Forms.Panel cautionPanel;
		private System.Windows.Forms.Label sessionLabel;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ComboBox incidentsTimeFilterComboBox;
		private System.Windows.Forms.Label incidentsTimeFilterLabel;
		private System.Windows.Forms.Button addTestRowButton;
		private System.Windows.Forms.Label visibleRowsLabel;
		private System.Windows.Forms.Label visibleRowsNum;
		private System.Windows.Forms.ComboBox timeFrameFilterComboBox2;
		private System.Windows.Forms.ComboBox timeFrameFilterComboBox1;
		private System.Windows.Forms.Label timeFrameFilterLabel2;
		private System.Windows.Forms.Label timeFrameFilterErrorText;
		private System.Windows.Forms.Label timeFrameFilterLabel1;
		private System.Windows.Forms.Label visibleIncidentsLabel;
		private System.Windows.Forms.Label visibleIncidentsNum;
		private Zuby.ADGV.AdvancedDataGridView debugTable;
		private System.Windows.Forms.Button resetTotalIncidentCountButton;
		private System.Windows.Forms.Button resetIncidentsSinceLastCautionButton;
	}
}

