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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceAdminMain));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			this.incidentsRequiredForCautionLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
			this.debugSettingsGroupbox = new System.Windows.Forms.GroupBox();
			this.filterNotInWorldCheckBox = new System.Windows.Forms.CheckBox();
			this.telemetryPollRateTextBox = new System.Windows.Forms.TextBox();
			this.hzLabel = new System.Windows.Forms.Label();
			this.telemetryPollRateLabel = new System.Windows.Forms.Label();
			this.debugTable = new System.Windows.Forms.DataGridView();
			this.debugCarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.debugCarNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.overallPositionInRace = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.classPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.carClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.carClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.currentDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.percentAroundTrack = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.betweenPitCones = new System.Windows.Forms.DataGridViewImageColumn();
			this.currentLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lapsCompleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.trackSurface = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.trackSurfaceMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mainTab = new System.Windows.Forms.TabPage();
			this.incidentsSinceCautionNum = new System.Windows.Forms.Label();
			this.incidentsSinceCautionLabel = new System.Windows.Forms.Label();
			this.totalIncidentCountLabel = new System.Windows.Forms.Label();
			this.totalIncidentCountNum = new System.Windows.Forms.Label();
			this.incidentsView = new Zuby.ADGV.AdvancedDataGridView();
			this.cautionPanel = new System.Windows.Forms.Panel();
			this.sessionLabel = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.debugTab.SuspendLayout();
			this.debugSettingsGroupbox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.debugTable)).BeginInit();
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
			// versionLabel
			// 
			this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(114, 659);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(37, 13);
			this.versionLabel.TabIndex = 11;
			this.versionLabel.Text = "v1.0.0";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.Location = new System.Drawing.Point(9, 656);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(99, 25);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
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
			// 
			// debugTab
			// 
			this.debugTab.Controls.Add(this.debugSettingsGroupbox);
			this.debugTab.Controls.Add(this.debugTable);
			this.debugTab.Location = new System.Drawing.Point(4, 22);
			this.debugTab.Name = "debugTab";
			this.debugTab.Padding = new System.Windows.Forms.Padding(3);
			this.debugTab.Size = new System.Drawing.Size(1256, 631);
			this.debugTab.TabIndex = 3;
			this.debugTab.Text = "Debug";
			this.debugTab.UseVisualStyleBackColor = true;
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
			this.debugSettingsGroupbox.Location = new System.Drawing.Point(0, 0);
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
			// debugTable
			// 
			this.debugTable.AllowUserToAddRows = false;
			this.debugTable.AllowUserToDeleteRows = false;
			this.debugTable.AllowUserToOrderColumns = true;
			this.debugTable.AllowUserToResizeRows = false;
			this.debugTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.debugTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.debugTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.debugTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.debugTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.debugTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.debugCarID,
            this.debugCarNum,
            this.overallPositionInRace,
            this.classPosition,
            this.carClassID,
            this.carClassName,
            this.currentDriver,
            this.percentAroundTrack,
            this.betweenPitCones,
            this.currentLap,
            this.lapsCompleted,
            this.trackSurface,
            this.trackSurfaceMaterial});
			this.debugTable.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.debugTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.debugTable.EnableHeadersVisualStyles = false;
			this.debugTable.Location = new System.Drawing.Point(0, 62);
			this.debugTable.Margin = new System.Windows.Forms.Padding(1);
			this.debugTable.MinimumSize = new System.Drawing.Size(1200, 250);
			this.debugTable.Name = "debugTable";
			this.debugTable.ReadOnly = true;
			this.debugTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.debugTable.RowHeadersVisible = false;
			this.debugTable.RowHeadersWidth = 4;
			this.debugTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.debugTable.RowTemplate.ReadOnly = true;
			this.debugTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.debugTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.debugTable.ShowCellErrors = false;
			this.debugTable.ShowCellToolTips = false;
			this.debugTable.ShowEditingIcon = false;
			this.debugTable.ShowRowErrors = false;
			this.debugTable.Size = new System.Drawing.Size(1256, 569);
			this.debugTable.TabIndex = 8;
			this.debugTable.TabStop = false;
			// 
			// debugCarID
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.debugCarID.DefaultCellStyle = dataGridViewCellStyle2;
			this.debugCarID.DividerWidth = 1;
			this.debugCarID.HeaderText = "CarIDx";
			this.debugCarID.Name = "debugCarID";
			this.debugCarID.ReadOnly = true;
			this.debugCarID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.debugCarID.ToolTipText = "iRacing CarIDx";
			this.debugCarID.Width = 61;
			// 
			// debugCarNum
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.debugCarNum.DefaultCellStyle = dataGridViewCellStyle3;
			this.debugCarNum.DividerWidth = 1;
			this.debugCarNum.HeaderText = "Car Num";
			this.debugCarNum.Name = "debugCarNum";
			this.debugCarNum.ReadOnly = true;
			this.debugCarNum.ToolTipText = "Car number";
			this.debugCarNum.Width = 61;
			// 
			// overallPositionInRace
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.overallPositionInRace.DefaultCellStyle = dataGridViewCellStyle4;
			this.overallPositionInRace.DividerWidth = 1;
			this.overallPositionInRace.HeaderText = "Position";
			this.overallPositionInRace.Name = "overallPositionInRace";
			this.overallPositionInRace.ReadOnly = true;
			this.overallPositionInRace.ToolTipText = "Overall position";
			this.overallPositionInRace.Width = 61;
			// 
			// classPosition
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.classPosition.DefaultCellStyle = dataGridViewCellStyle5;
			this.classPosition.DividerWidth = 1;
			this.classPosition.HeaderText = "Class Position";
			this.classPosition.Name = "classPosition";
			this.classPosition.ReadOnly = true;
			this.classPosition.ToolTipText = "Position in class";
			this.classPosition.Width = 61;
			// 
			// carClassID
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.carClassID.DefaultCellStyle = dataGridViewCellStyle6;
			this.carClassID.DividerWidth = 1;
			this.carClassID.HeaderText = "Class ID";
			this.carClassID.Name = "carClassID";
			this.carClassID.ReadOnly = true;
			this.carClassID.ToolTipText = "iRacing class ID";
			this.carClassID.Width = 61;
			// 
			// carClassName
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.carClassName.DefaultCellStyle = dataGridViewCellStyle7;
			this.carClassName.DividerWidth = 1;
			this.carClassName.HeaderText = "Class";
			this.carClassName.Name = "carClassName";
			this.carClassName.ReadOnly = true;
			this.carClassName.ToolTipText = "Short class name";
			// 
			// currentDriver
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
			this.currentDriver.DefaultCellStyle = dataGridViewCellStyle8;
			this.currentDriver.DividerWidth = 1;
			this.currentDriver.HeaderText = "Driver";
			this.currentDriver.Name = "currentDriver";
			this.currentDriver.ReadOnly = true;
			this.currentDriver.ToolTipText = "Current driver";
			this.currentDriver.Width = 250;
			// 
			// percentAroundTrack
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.Format = "N4";
			dataGridViewCellStyle9.NullValue = null;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.percentAroundTrack.DefaultCellStyle = dataGridViewCellStyle9;
			this.percentAroundTrack.DividerWidth = 1;
			this.percentAroundTrack.HeaderText = "%";
			this.percentAroundTrack.Name = "percentAroundTrack";
			this.percentAroundTrack.ReadOnly = true;
			this.percentAroundTrack.ToolTipText = "Percent around track";
			// 
			// betweenPitCones
			// 
			this.betweenPitCones.DataPropertyName = "betweenPitCones";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle10.NullValue")));
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.betweenPitCones.DefaultCellStyle = dataGridViewCellStyle10;
			this.betweenPitCones.Description = "Displays a pit cone icon when true";
			this.betweenPitCones.DividerWidth = 1;
			this.betweenPitCones.HeaderText = "Pit";
			this.betweenPitCones.Image = global::RaceAdmin.Properties.Resources.ConeEmpty;
			this.betweenPitCones.MinimumWidth = 25;
			this.betweenPitCones.Name = "betweenPitCones";
			this.betweenPitCones.ReadOnly = true;
			this.betweenPitCones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.betweenPitCones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.betweenPitCones.ToolTipText = "Car is currently between the pit cones";
			this.betweenPitCones.Width = 25;
			// 
			// currentLap
			// 
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.currentLap.DefaultCellStyle = dataGridViewCellStyle11;
			this.currentLap.DividerWidth = 1;
			this.currentLap.HeaderText = "Current Lap";
			this.currentLap.Name = "currentLap";
			this.currentLap.ReadOnly = true;
			this.currentLap.ToolTipText = "Current lap number in progress";
			// 
			// lapsCompleted
			// 
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.lapsCompleted.DefaultCellStyle = dataGridViewCellStyle12;
			this.lapsCompleted.DividerWidth = 1;
			this.lapsCompleted.HeaderText = "Laps Completed";
			this.lapsCompleted.Name = "lapsCompleted";
			this.lapsCompleted.ReadOnly = true;
			this.lapsCompleted.ToolTipText = "Number of laps completed";
			// 
			// trackSurface
			// 
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.trackSurface.DefaultCellStyle = dataGridViewCellStyle13;
			this.trackSurface.DividerWidth = 1;
			this.trackSurface.HeaderText = "Track Surface";
			this.trackSurface.Name = "trackSurface";
			this.trackSurface.ReadOnly = true;
			this.trackSurface.ToolTipText = "Current track surface value";
			// 
			// trackSurfaceMaterial
			// 
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.trackSurfaceMaterial.DefaultCellStyle = dataGridViewCellStyle14;
			this.trackSurfaceMaterial.DividerWidth = 1;
			this.trackSurfaceMaterial.HeaderText = "Surface Material";
			this.trackSurfaceMaterial.Name = "trackSurfaceMaterial";
			this.trackSurfaceMaterial.ReadOnly = true;
			this.trackSurfaceMaterial.ToolTipText = "Current track surface material value";
			// 
			// mainTab
			// 
			this.mainTab.BackColor = System.Drawing.SystemColors.Control;
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
			// incidentsSinceCautionNum
			// 
			this.incidentsSinceCautionNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.incidentsSinceCautionNum.BackColor = System.Drawing.Color.Transparent;
			this.incidentsSinceCautionNum.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incidentsSinceCautionNum.Location = new System.Drawing.Point(914, 2);
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
			this.incidentsSinceCautionLabel.Location = new System.Drawing.Point(668, 2);
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
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
			this.incidentsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.incidentsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.incidentsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
			this.incidentsView.ColumnHeadersHeight = 25;
			this.incidentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsView.DefaultCellStyle = dataGridViewCellStyle17;
			this.incidentsView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.incidentsView.FilterAndSortEnabled = true;
			this.incidentsView.Location = new System.Drawing.Point(1, 78);
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
			this.incidentsView.Size = new System.Drawing.Size(1254, 553);
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
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(1280, 720);
			this.Name = "RaceAdminMain";
			this.Text = "Race Administrator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaceAdminMain_FormClosing);
			this.Load += new System.EventHandler(this.RaceAdminMain_Load);
			this.ResizeEnd += new System.EventHandler(this.RaceAdminMain_ResizeEnd);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.debugTab.ResumeLayout(false);
			this.debugSettingsGroupbox.ResumeLayout(false);
			this.debugSettingsGroupbox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.debugTable)).EndInit();
			this.mainTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.incidentsView)).EndInit();
			this.cautionPanel.ResumeLayout(false);
			this.cautionPanel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label incidentsRequiredForCautionLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
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
		private System.Windows.Forms.DataGridView debugTable;
		private System.Windows.Forms.DataGridViewTextBoxColumn debugCarID;
		private System.Windows.Forms.DataGridViewTextBoxColumn debugCarNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn overallPositionInRace;
		private System.Windows.Forms.DataGridViewTextBoxColumn classPosition;
		private System.Windows.Forms.DataGridViewTextBoxColumn carClassID;
		private System.Windows.Forms.DataGridViewTextBoxColumn carClassName;
		private System.Windows.Forms.DataGridViewTextBoxColumn currentDriver;
		private System.Windows.Forms.DataGridViewTextBoxColumn percentAroundTrack;
		private System.Windows.Forms.DataGridViewImageColumn betweenPitCones;
		private System.Windows.Forms.DataGridViewTextBoxColumn currentLap;
		private System.Windows.Forms.DataGridViewTextBoxColumn lapsCompleted;
		private System.Windows.Forms.DataGridViewTextBoxColumn trackSurface;
		private System.Windows.Forms.DataGridViewTextBoxColumn trackSurfaceMaterial;
		private System.Windows.Forms.TabPage mainTab;
		private System.Windows.Forms.Label incidentsSinceCautionNum;
		private System.Windows.Forms.Label incidentsSinceCautionLabel;
		private System.Windows.Forms.Label totalIncidentCountLabel;
		private System.Windows.Forms.Label totalIncidentCountNum;
		private Zuby.ADGV.AdvancedDataGridView incidentsView;
		private System.Windows.Forms.Panel cautionPanel;
		private System.Windows.Forms.Label sessionLabel;
		private System.Windows.Forms.TabControl tabControl;
	}
}

