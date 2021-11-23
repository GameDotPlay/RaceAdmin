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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceAdminMain));
			this.incidentsTableView = new System.Windows.Forms.DataGridView();
			this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CarNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Incident = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DriverLapNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalIncidentCountLabel = new System.Windows.Forms.Label();
			this.TotalIncidentCountNum = new System.Windows.Forms.Label();
			this.cautionPanel = new System.Windows.Forms.Panel();
			this.sessionLabel = new System.Windows.Forms.Label();
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
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideIncidentTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideIncidentsCountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideCautionPanelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutRaceAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.IncidentsSinceCautionNum = new System.Windows.Forms.Label();
			this.IncidentsSinceCautionLabel = new System.Windows.Forms.Label();
			this.incidentCountPanel = new System.Windows.Forms.Panel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.mainTab = new System.Windows.Forms.TabPage();
			this.incidentsTab = new System.Windows.Forms.TabPage();
			this.incidentFiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.filterTimeComboBox = new System.Windows.Forms.ComboBox();
			this.filterIncidentsComboBox = new System.Windows.Forms.ComboBox();
			this.filterTimeLabel = new System.Windows.Forms.Label();
			this.filterIncidentsLabel = new System.Windows.Forms.Label();
			this.filterEntriesLabel = new System.Windows.Forms.Label();
			this.driverFilterRadio = new System.Windows.Forms.RadioButton();
			this.carFilterRadio = new System.Windows.Forms.RadioButton();
			this.allIncidentsTable = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CarClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.liveStandingsTab = new System.Windows.Forms.TabPage();
			this.liveStandingsFilterGroupBox = new System.Windows.Forms.GroupBox();
			this.filterClassComboBox = new System.Windows.Forms.ComboBox();
			this.filterClassLabel = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.OverallPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Make = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.incidentsTableView)).BeginInit();
			this.cautionPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.incidentCountPanel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.mainTab.SuspendLayout();
			this.incidentsTab.SuspendLayout();
			this.incidentFiltersGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allIncidentsTable)).BeginInit();
			this.liveStandingsTab.SuspendLayout();
			this.liveStandingsFilterGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// incidentsTableView
			// 
			this.incidentsTableView.AllowUserToAddRows = false;
			this.incidentsTableView.AllowUserToDeleteRows = false;
			this.incidentsTableView.AllowUserToResizeRows = false;
			this.incidentsTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.incidentsTableView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.incidentsTableView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.incidentsTableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.incidentsTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.incidentsTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.CarNum,
            this.Team,
            this.DriverName,
            this.Incident,
            this.Total,
            this.DriverLapNum});
			this.incidentsTableView.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.incidentsTableView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.incidentsTableView.EnableHeadersVisualStyles = false;
			this.incidentsTableView.Location = new System.Drawing.Point(0, 273);
			this.incidentsTableView.Margin = new System.Windows.Forms.Padding(1);
			this.incidentsTableView.MinimumSize = new System.Drawing.Size(1200, 250);
			this.incidentsTableView.Name = "incidentsTableView";
			this.incidentsTableView.ReadOnly = true;
			this.incidentsTableView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.incidentsTableView.RowHeadersVisible = false;
			this.incidentsTableView.RowHeadersWidth = 4;
			this.incidentsTableView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.incidentsTableView.RowTemplate.ReadOnly = true;
			this.incidentsTableView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.incidentsTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.incidentsTableView.ShowCellErrors = false;
			this.incidentsTableView.ShowCellToolTips = false;
			this.incidentsTableView.ShowEditingIcon = false;
			this.incidentsTableView.ShowRowErrors = false;
			this.incidentsTableView.Size = new System.Drawing.Size(1256, 358);
			this.incidentsTableView.TabIndex = 1;
			this.incidentsTableView.TabStop = false;
			this.incidentsTableView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.IncidentsTableView_SortCompare);
			// 
			// Time
			// 
			this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			this.Time.DefaultCellStyle = dataGridViewCellStyle2;
			this.Time.DividerWidth = 1;
			this.Time.HeaderText = "Time";
			this.Time.Name = "Time";
			this.Time.ReadOnly = true;
			// 
			// CarNum
			// 
			this.CarNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.CarNum.DefaultCellStyle = dataGridViewCellStyle3;
			this.CarNum.DividerWidth = 1;
			this.CarNum.HeaderText = "Car #";
			this.CarNum.MinimumWidth = 75;
			this.CarNum.Name = "CarNum";
			this.CarNum.ReadOnly = true;
			this.CarNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.CarNum.Width = 75;
			// 
			// Team
			// 
			this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
			this.Team.DefaultCellStyle = dataGridViewCellStyle4;
			this.Team.DividerWidth = 1;
			this.Team.FillWeight = 50F;
			this.Team.HeaderText = "Team";
			this.Team.MinimumWidth = 250;
			this.Team.Name = "Team";
			this.Team.ReadOnly = true;
			// 
			// DriverName
			// 
			this.DriverName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DriverName.DefaultCellStyle = dataGridViewCellStyle5;
			this.DriverName.DividerWidth = 1;
			this.DriverName.FillWeight = 50F;
			this.DriverName.HeaderText = "Driver";
			this.DriverName.MinimumWidth = 250;
			this.DriverName.Name = "DriverName";
			this.DriverName.ReadOnly = true;
			this.DriverName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// Incident
			// 
			this.Incident.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Incident.DefaultCellStyle = dataGridViewCellStyle6;
			this.Incident.DividerWidth = 1;
			this.Incident.HeaderText = "Inc.";
			this.Incident.MinimumWidth = 75;
			this.Incident.Name = "Incident";
			this.Incident.ReadOnly = true;
			this.Incident.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Incident.Width = 75;
			// 
			// Total
			// 
			this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Total.DefaultCellStyle = dataGridViewCellStyle7;
			this.Total.DividerWidth = 1;
			this.Total.HeaderText = "Total";
			this.Total.MinimumWidth = 75;
			this.Total.Name = "Total";
			this.Total.ReadOnly = true;
			this.Total.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Total.Width = 75;
			// 
			// DriverLapNum
			// 
			this.DriverLapNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DriverLapNum.DefaultCellStyle = dataGridViewCellStyle8;
			this.DriverLapNum.HeaderText = "Car Lap #";
			this.DriverLapNum.MinimumWidth = 110;
			this.DriverLapNum.Name = "DriverLapNum";
			this.DriverLapNum.ReadOnly = true;
			this.DriverLapNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.DriverLapNum.Width = 110;
			// 
			// TotalIncidentCountLabel
			// 
			this.TotalIncidentCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TotalIncidentCountLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalIncidentCountLabel.Location = new System.Drawing.Point(0, 0);
			this.TotalIncidentCountLabel.Margin = new System.Windows.Forms.Padding(0);
			this.TotalIncidentCountLabel.Name = "TotalIncidentCountLabel";
			this.TotalIncidentCountLabel.Size = new System.Drawing.Size(374, 33);
			this.TotalIncidentCountLabel.TabIndex = 3;
			this.TotalIncidentCountLabel.Text = "Total Incidents";
			this.TotalIncidentCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TotalIncidentCountNum
			// 
			this.TotalIncidentCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TotalIncidentCountNum.Font = new System.Drawing.Font("Arial", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalIncidentCountNum.Location = new System.Drawing.Point(-3, 35);
			this.TotalIncidentCountNum.Margin = new System.Windows.Forms.Padding(0);
			this.TotalIncidentCountNum.Name = "TotalIncidentCountNum";
			this.TotalIncidentCountNum.Size = new System.Drawing.Size(374, 82);
			this.TotalIncidentCountNum.TabIndex = 4;
			this.TotalIncidentCountNum.Text = "0";
			this.TotalIncidentCountNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cautionPanel
			// 
			this.cautionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cautionPanel.BackColor = System.Drawing.SystemColors.Control;
			this.cautionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cautionPanel.Controls.Add(this.sessionLabel);
			this.cautionPanel.Location = new System.Drawing.Point(0, 0);
			this.cautionPanel.Margin = new System.Windows.Forms.Padding(1);
			this.cautionPanel.MinimumSize = new System.Drawing.Size(878, 270);
			this.cautionPanel.Name = "cautionPanel";
			this.cautionPanel.Size = new System.Drawing.Size(878, 270);
			this.cautionPanel.TabIndex = 0;
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
			this.pictureBox1.Image = global::RaceAdmin.Properties.Resources._2021_vApex_Flag_Logo4_RG_Black;
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
            this.toolStripMenuItem1,
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
            this.exportTableMenuItem});
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
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideIncidentTableMenuItem,
            this.hideIncidentsCountMenuItem,
            this.hideCautionPanelMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// hideIncidentTableMenuItem
			// 
			this.hideIncidentTableMenuItem.Checked = true;
			this.hideIncidentTableMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hideIncidentTableMenuItem.Name = "hideIncidentTableMenuItem";
			this.hideIncidentTableMenuItem.Size = new System.Drawing.Size(158, 22);
			this.hideIncidentTableMenuItem.Text = "Incident Table";
			this.hideIncidentTableMenuItem.CheckedChanged += new System.EventHandler(this.hideIncidentTableMenuItem_CheckedChanged);
			this.hideIncidentTableMenuItem.Click += new System.EventHandler(this.hideIncidentTableMenuItem_Click);
			// 
			// hideIncidentsCountMenuItem
			// 
			this.hideIncidentsCountMenuItem.Checked = true;
			this.hideIncidentsCountMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hideIncidentsCountMenuItem.Name = "hideIncidentsCountMenuItem";
			this.hideIncidentsCountMenuItem.Size = new System.Drawing.Size(158, 22);
			this.hideIncidentsCountMenuItem.Text = "Incidents Count";
			this.hideIncidentsCountMenuItem.CheckedChanged += new System.EventHandler(this.hideIncidentsCountMenuItem_CheckedChanged);
			this.hideIncidentsCountMenuItem.Click += new System.EventHandler(this.hideIncidentsCountMenuItem_Click);
			// 
			// hideCautionPanelMenuItem
			// 
			this.hideCautionPanelMenuItem.Checked = true;
			this.hideCautionPanelMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hideCautionPanelMenuItem.Name = "hideCautionPanelMenuItem";
			this.hideCautionPanelMenuItem.Size = new System.Drawing.Size(158, 22);
			this.hideCautionPanelMenuItem.Text = "Caution Panel";
			this.hideCautionPanelMenuItem.CheckedChanged += new System.EventHandler(this.hideCautionPanelMenuItem_CheckedChanged);
			this.hideCautionPanelMenuItem.Click += new System.EventHandler(this.hideCautionPanelMenuItem_Click);
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
			// IncidentsSinceCautionNum
			// 
			this.IncidentsSinceCautionNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IncidentsSinceCautionNum.Font = new System.Drawing.Font("Arial", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncidentsSinceCautionNum.Location = new System.Drawing.Point(0, 161);
			this.IncidentsSinceCautionNum.Margin = new System.Windows.Forms.Padding(0);
			this.IncidentsSinceCautionNum.Name = "IncidentsSinceCautionNum";
			this.IncidentsSinceCautionNum.Size = new System.Drawing.Size(374, 96);
			this.IncidentsSinceCautionNum.TabIndex = 6;
			this.IncidentsSinceCautionNum.Text = "0";
			this.IncidentsSinceCautionNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IncidentsSinceCautionLabel
			// 
			this.IncidentsSinceCautionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IncidentsSinceCautionLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncidentsSinceCautionLabel.Location = new System.Drawing.Point(0, 119);
			this.IncidentsSinceCautionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.IncidentsSinceCautionLabel.Name = "IncidentsSinceCautionLabel";
			this.IncidentsSinceCautionLabel.Size = new System.Drawing.Size(374, 40);
			this.IncidentsSinceCautionLabel.TabIndex = 5;
			this.IncidentsSinceCautionLabel.Text = "Since Last Caution";
			this.IncidentsSinceCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// incidentCountPanel
			// 
			this.incidentCountPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.incidentCountPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.incidentCountPanel.Controls.Add(this.IncidentsSinceCautionNum);
			this.incidentCountPanel.Controls.Add(this.TotalIncidentCountLabel);
			this.incidentCountPanel.Controls.Add(this.IncidentsSinceCautionLabel);
			this.incidentCountPanel.Controls.Add(this.TotalIncidentCountNum);
			this.incidentCountPanel.Location = new System.Drawing.Point(880, 0);
			this.incidentCountPanel.Margin = new System.Windows.Forms.Padding(1);
			this.incidentCountPanel.Name = "incidentCountPanel";
			this.incidentCountPanel.Size = new System.Drawing.Size(376, 270);
			this.incidentCountPanel.TabIndex = 13;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.mainTab);
			this.tabControl.Controls.Add(this.incidentsTab);
			this.tabControl.Controls.Add(this.liveStandingsTab);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 24);
			this.tabControl.Margin = new System.Windows.Forms.Padding(1);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1264, 657);
			this.tabControl.TabIndex = 1;
			// 
			// mainTab
			// 
			this.mainTab.BackColor = System.Drawing.SystemColors.Control;
			this.mainTab.Controls.Add(this.cautionPanel);
			this.mainTab.Controls.Add(this.incidentCountPanel);
			this.mainTab.Controls.Add(this.incidentsTableView);
			this.mainTab.Location = new System.Drawing.Point(4, 22);
			this.mainTab.Name = "mainTab";
			this.mainTab.Padding = new System.Windows.Forms.Padding(1);
			this.mainTab.Size = new System.Drawing.Size(1256, 631);
			this.mainTab.TabIndex = 0;
			this.mainTab.Text = "Main";
			// 
			// incidentsTab
			// 
			this.incidentsTab.BackColor = System.Drawing.SystemColors.Control;
			this.incidentsTab.Controls.Add(this.incidentFiltersGroupBox);
			this.incidentsTab.Controls.Add(this.allIncidentsTable);
			this.incidentsTab.Location = new System.Drawing.Point(4, 22);
			this.incidentsTab.Name = "incidentsTab";
			this.incidentsTab.Padding = new System.Windows.Forms.Padding(3);
			this.incidentsTab.Size = new System.Drawing.Size(1256, 631);
			this.incidentsTab.TabIndex = 1;
			this.incidentsTab.Text = "Incidents";
			// 
			// incidentFiltersGroupBox
			// 
			this.incidentFiltersGroupBox.Controls.Add(this.filterTimeComboBox);
			this.incidentFiltersGroupBox.Controls.Add(this.filterIncidentsComboBox);
			this.incidentFiltersGroupBox.Controls.Add(this.filterTimeLabel);
			this.incidentFiltersGroupBox.Controls.Add(this.filterIncidentsLabel);
			this.incidentFiltersGroupBox.Controls.Add(this.filterEntriesLabel);
			this.incidentFiltersGroupBox.Controls.Add(this.driverFilterRadio);
			this.incidentFiltersGroupBox.Controls.Add(this.carFilterRadio);
			this.incidentFiltersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.incidentFiltersGroupBox.Location = new System.Drawing.Point(3, 3);
			this.incidentFiltersGroupBox.Name = "incidentFiltersGroupBox";
			this.incidentFiltersGroupBox.Size = new System.Drawing.Size(1250, 58);
			this.incidentFiltersGroupBox.TabIndex = 5;
			this.incidentFiltersGroupBox.TabStop = false;
			this.incidentFiltersGroupBox.Text = "Filters";
			// 
			// filterTimeComboBox
			// 
			this.filterTimeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterTimeComboBox.FormattingEnabled = true;
			this.filterTimeComboBox.Items.AddRange(new object[] {
            "Forever",
            "30 Minutes",
            "60 Minutes",
            "90 Minutes",
            "120 Minutes",
            "180 Minutes"});
			this.filterTimeComboBox.Location = new System.Drawing.Point(494, 18);
			this.filterTimeComboBox.Name = "filterTimeComboBox";
			this.filterTimeComboBox.Size = new System.Drawing.Size(121, 24);
			this.filterTimeComboBox.TabIndex = 1;
			this.filterTimeComboBox.Text = "30 Minutes";
			// 
			// filterIncidentsComboBox
			// 
			this.filterIncidentsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterIncidentsComboBox.FormattingEnabled = true;
			this.filterIncidentsComboBox.Items.AddRange(new object[] {
            "All",
            "1x",
            "2x",
            "4x"});
			this.filterIncidentsComboBox.Location = new System.Drawing.Point(79, 18);
			this.filterIncidentsComboBox.Name = "filterIncidentsComboBox";
			this.filterIncidentsComboBox.Size = new System.Drawing.Size(121, 24);
			this.filterIncidentsComboBox.TabIndex = 1;
			this.filterIncidentsComboBox.Text = "All";
			// 
			// filterTimeLabel
			// 
			this.filterTimeLabel.AutoSize = true;
			this.filterTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterTimeLabel.Location = new System.Drawing.Point(455, 21);
			this.filterTimeLabel.Name = "filterTimeLabel";
			this.filterTimeLabel.Size = new System.Drawing.Size(33, 16);
			this.filterTimeLabel.TabIndex = 4;
			this.filterTimeLabel.Text = "Last";
			// 
			// filterIncidentsLabel
			// 
			this.filterIncidentsLabel.AutoSize = true;
			this.filterIncidentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterIncidentsLabel.Location = new System.Drawing.Point(6, 21);
			this.filterIncidentsLabel.Name = "filterIncidentsLabel";
			this.filterIncidentsLabel.Size = new System.Drawing.Size(67, 16);
			this.filterIncidentsLabel.TabIndex = 0;
			this.filterIncidentsLabel.Text = "Filter Incs:";
			// 
			// filterEntriesLabel
			// 
			this.filterEntriesLabel.AutoSize = true;
			this.filterEntriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterEntriesLabel.Location = new System.Drawing.Point(210, 21);
			this.filterEntriesLabel.Name = "filterEntriesLabel";
			this.filterEntriesLabel.Size = new System.Drawing.Size(84, 16);
			this.filterEntriesLabel.TabIndex = 0;
			this.filterEntriesLabel.Text = "Filter Entries:";
			// 
			// driverFilterRadio
			// 
			this.driverFilterRadio.AutoSize = true;
			this.driverFilterRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.driverFilterRadio.Location = new System.Drawing.Point(360, 19);
			this.driverFilterRadio.Name = "driverFilterRadio";
			this.driverFilterRadio.Size = new System.Drawing.Size(69, 20);
			this.driverFilterRadio.TabIndex = 2;
			this.driverFilterRadio.TabStop = true;
			this.driverFilterRadio.Text = "Drivers";
			this.driverFilterRadio.UseVisualStyleBackColor = true;
			// 
			// carFilterRadio
			// 
			this.carFilterRadio.AutoSize = true;
			this.carFilterRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.carFilterRadio.Location = new System.Drawing.Point(300, 19);
			this.carFilterRadio.Name = "carFilterRadio";
			this.carFilterRadio.Size = new System.Drawing.Size(54, 20);
			this.carFilterRadio.TabIndex = 2;
			this.carFilterRadio.TabStop = true;
			this.carFilterRadio.Text = "Cars";
			this.carFilterRadio.UseVisualStyleBackColor = true;
			// 
			// allIncidentsTable
			// 
			this.allIncidentsTable.AllowUserToAddRows = false;
			this.allIncidentsTable.AllowUserToDeleteRows = false;
			this.allIncidentsTable.AllowUserToResizeRows = false;
			this.allIncidentsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.allIncidentsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.allIncidentsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allIncidentsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.allIncidentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.allIncidentsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.CarClass,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
			this.allIncidentsTable.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.allIncidentsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.allIncidentsTable.EnableHeadersVisualStyles = false;
			this.allIncidentsTable.Location = new System.Drawing.Point(0, 65);
			this.allIncidentsTable.Margin = new System.Windows.Forms.Padding(1);
			this.allIncidentsTable.MinimumSize = new System.Drawing.Size(1200, 250);
			this.allIncidentsTable.Name = "allIncidentsTable";
			this.allIncidentsTable.ReadOnly = true;
			this.allIncidentsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.allIncidentsTable.RowHeadersVisible = false;
			this.allIncidentsTable.RowHeadersWidth = 4;
			this.allIncidentsTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.allIncidentsTable.RowTemplate.ReadOnly = true;
			this.allIncidentsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.allIncidentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.allIncidentsTable.ShowCellErrors = false;
			this.allIncidentsTable.ShowCellToolTips = false;
			this.allIncidentsTable.ShowEditingIcon = false;
			this.allIncidentsTable.ShowRowErrors = false;
			this.allIncidentsTable.Size = new System.Drawing.Size(1256, 566);
			this.allIncidentsTable.TabIndex = 3;
			this.allIncidentsTable.TabStop = false;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn2.DividerWidth = 1;
			this.dataGridViewTextBoxColumn2.HeaderText = "Car #";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 75;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.ToolTipText = "Car number";
			this.dataGridViewTextBoxColumn2.Width = 75;
			// 
			// CarClass
			// 
			this.CarClass.DividerWidth = 1;
			this.CarClass.HeaderText = "Class";
			this.CarClass.Name = "CarClass";
			this.CarClass.ReadOnly = true;
			this.CarClass.ToolTipText = "The car class";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewTextBoxColumn3.DividerWidth = 1;
			this.dataGridViewTextBoxColumn3.FillWeight = 50F;
			this.dataGridViewTextBoxColumn3.HeaderText = "Team";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 250;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.ToolTipText = "The team name";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewTextBoxColumn4.DividerWidth = 1;
			this.dataGridViewTextBoxColumn4.FillWeight = 50F;
			this.dataGridViewTextBoxColumn4.HeaderText = "Driver";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 250;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn4.ToolTipText = "The name of the driver currently driving this car";
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewTextBoxColumn6.DividerWidth = 1;
			this.dataGridViewTextBoxColumn6.HeaderText = "Incidents";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 75;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn6.ToolTipText = "The total number of incidents for this entry";
			this.dataGridViewTextBoxColumn6.Width = 75;
			// 
			// liveStandingsTab
			// 
			this.liveStandingsTab.BackColor = System.Drawing.SystemColors.Control;
			this.liveStandingsTab.Controls.Add(this.dataGridView1);
			this.liveStandingsTab.Controls.Add(this.liveStandingsFilterGroupBox);
			this.liveStandingsTab.Location = new System.Drawing.Point(4, 22);
			this.liveStandingsTab.Name = "liveStandingsTab";
			this.liveStandingsTab.Padding = new System.Windows.Forms.Padding(3);
			this.liveStandingsTab.Size = new System.Drawing.Size(1256, 631);
			this.liveStandingsTab.TabIndex = 2;
			this.liveStandingsTab.Text = "Live Standings";
			// 
			// liveStandingsFilterGroupBox
			// 
			this.liveStandingsFilterGroupBox.Controls.Add(this.filterClassComboBox);
			this.liveStandingsFilterGroupBox.Controls.Add(this.filterClassLabel);
			this.liveStandingsFilterGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.liveStandingsFilterGroupBox.Location = new System.Drawing.Point(3, 3);
			this.liveStandingsFilterGroupBox.Name = "liveStandingsFilterGroupBox";
			this.liveStandingsFilterGroupBox.Size = new System.Drawing.Size(1250, 58);
			this.liveStandingsFilterGroupBox.TabIndex = 6;
			this.liveStandingsFilterGroupBox.TabStop = false;
			this.liveStandingsFilterGroupBox.Text = "Filters";
			// 
			// filterClassComboBox
			// 
			this.filterClassComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterClassComboBox.FormattingEnabled = true;
			this.filterClassComboBox.Location = new System.Drawing.Point(89, 18);
			this.filterClassComboBox.Name = "filterClassComboBox";
			this.filterClassComboBox.Size = new System.Drawing.Size(121, 24);
			this.filterClassComboBox.TabIndex = 1;
			// 
			// filterClassLabel
			// 
			this.filterClassLabel.AutoSize = true;
			this.filterClassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterClassLabel.Location = new System.Drawing.Point(6, 21);
			this.filterClassLabel.Name = "filterClassLabel";
			this.filterClassLabel.Size = new System.Drawing.Size(77, 16);
			this.filterClassLabel.TabIndex = 0;
			this.filterClassLabel.Text = "Filter Class:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OverallPosition,
            this.dataGridViewTextBoxColumn5,
            this.Make,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
			this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new System.Drawing.Point(3, 61);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
			this.dataGridView1.MinimumSize = new System.Drawing.Size(1200, 250);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 4;
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView1.RowTemplate.ReadOnly = true;
			this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.ShowCellErrors = false;
			this.dataGridView1.ShowCellToolTips = false;
			this.dataGridView1.ShowEditingIcon = false;
			this.dataGridView1.ShowRowErrors = false;
			this.dataGridView1.Size = new System.Drawing.Size(1256, 570);
			this.dataGridView1.TabIndex = 7;
			this.dataGridView1.TabStop = false;
			// 
			// OverallPosition
			// 
			this.OverallPosition.DividerWidth = 1;
			this.OverallPosition.HeaderText = "Position";
			this.OverallPosition.Name = "OverallPosition";
			this.OverallPosition.ReadOnly = true;
			this.OverallPosition.ToolTipText = "Overall position of this entry";
			this.OverallPosition.Width = 60;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DividerWidth = 1;
			this.dataGridViewTextBoxColumn5.HeaderText = "Class";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.ToolTipText = "The car class";
			this.dataGridViewTextBoxColumn5.Width = 60;
			// 
			// Make
			// 
			this.Make.DividerWidth = 1;
			this.Make.HeaderText = "Make";
			this.Make.Name = "Make";
			this.Make.ReadOnly = true;
			this.Make.ToolTipText = "The car make of this entry";
			this.Make.Width = 60;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewTextBoxColumn1.DividerWidth = 1;
			this.dataGridViewTextBoxColumn1.HeaderText = "Car #";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn1.ToolTipText = "Car number of this entry";
			this.dataGridViewTextBoxColumn1.Width = 60;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewTextBoxColumn7.DividerWidth = 1;
			this.dataGridViewTextBoxColumn7.FillWeight = 50F;
			this.dataGridViewTextBoxColumn7.HeaderText = "Team";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.ToolTipText = "The team name";
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewTextBoxColumn8.DividerWidth = 1;
			this.dataGridViewTextBoxColumn8.FillWeight = 50F;
			this.dataGridViewTextBoxColumn8.HeaderText = "Driver";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn8.ToolTipText = "The name of the driver currently driving this car";
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewTextBoxColumn9.DividerWidth = 1;
			this.dataGridViewTextBoxColumn9.HeaderText = "Incidents";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn9.ToolTipText = "The total number of incidents for this entry";
			this.dataGridViewTextBoxColumn9.Width = 60;
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
			((System.ComponentModel.ISupportInitialize)(this.incidentsTableView)).EndInit();
			this.cautionPanel.ResumeLayout(false);
			this.cautionPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.incidentCountPanel.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.mainTab.ResumeLayout(false);
			this.incidentsTab.ResumeLayout(false);
			this.incidentFiltersGroupBox.ResumeLayout(false);
			this.incidentFiltersGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.allIncidentsTable)).EndInit();
			this.liveStandingsTab.ResumeLayout(false);
			this.liveStandingsFilterGroupBox.ResumeLayout(false);
			this.liveStandingsFilterGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView incidentsTableView;
        private System.Windows.Forms.Label TotalIncidentCountLabel;
        private System.Windows.Forms.Label TotalIncidentCountNum;
        private System.Windows.Forms.Panel cautionPanel;
        private System.Windows.Forms.Label incidentsRequiredForCautionLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incident;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverLapNum;
        private System.Windows.Forms.Label sessionLabel;
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
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideIncidentTableMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideIncidentsCountMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideCautionPanelMenuItem;
		private System.Windows.Forms.Label IncidentsSinceCautionNum;
		private System.Windows.Forms.Label IncidentsSinceCautionLabel;
		private System.Windows.Forms.Panel incidentCountPanel;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage mainTab;
		private System.Windows.Forms.TabPage incidentsTab;
		private System.Windows.Forms.TabPage liveStandingsTab;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutRaceAdministratorToolStripMenuItem;
		private System.Windows.Forms.ComboBox filterIncidentsComboBox;
		private System.Windows.Forms.Label filterIncidentsLabel;
		private System.Windows.Forms.RadioButton driverFilterRadio;
		private System.Windows.Forms.RadioButton carFilterRadio;
		private System.Windows.Forms.Label filterEntriesLabel;
		private System.Windows.Forms.DataGridView allIncidentsTable;
		private System.Windows.Forms.GroupBox incidentFiltersGroupBox;
		private System.Windows.Forms.Label filterTimeLabel;
		private System.Windows.Forms.ComboBox filterTimeComboBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn CarClass;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.GroupBox liveStandingsFilterGroupBox;
		private System.Windows.Forms.ComboBox filterClassComboBox;
		private System.Windows.Forms.Label filterClassLabel;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn OverallPosition;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewImageColumn Make;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
	}
}

