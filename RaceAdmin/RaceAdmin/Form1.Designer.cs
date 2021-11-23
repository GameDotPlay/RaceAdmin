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
			this.ObscurePanel2 = new System.Windows.Forms.Panel();
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
			this.IncidentsSinceCautionNum = new System.Windows.Forms.Label();
			this.IncidentsSinceCautionLabel = new System.Windows.Forms.Label();
			this.incidentCountPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.incidentsTableView)).BeginInit();
			this.cautionPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.incidentCountPanel.SuspendLayout();
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
			this.incidentsTableView.Location = new System.Drawing.Point(9, 303);
			this.incidentsTableView.MinimumSize = new System.Drawing.Size(878, 345);
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
			this.incidentsTableView.Size = new System.Drawing.Size(1249, 345);
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
			this.TotalIncidentCountLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalIncidentCountLabel.Location = new System.Drawing.Point(0, 0);
			this.TotalIncidentCountLabel.Margin = new System.Windows.Forms.Padding(0);
			this.TotalIncidentCountLabel.Name = "TotalIncidentCountLabel";
			this.TotalIncidentCountLabel.Size = new System.Drawing.Size(365, 42);
			this.TotalIncidentCountLabel.TabIndex = 3;
			this.TotalIncidentCountLabel.Text = "Total Incidents";
			this.TotalIncidentCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TotalIncidentCountNum
			// 
			this.TotalIncidentCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TotalIncidentCountNum.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalIncidentCountNum.Location = new System.Drawing.Point(0, 46);
			this.TotalIncidentCountNum.Margin = new System.Windows.Forms.Padding(0);
			this.TotalIncidentCountNum.Name = "TotalIncidentCountNum";
			this.TotalIncidentCountNum.Size = new System.Drawing.Size(365, 84);
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
			this.cautionPanel.Location = new System.Drawing.Point(9, 27);
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
			this.pictureBox1.Location = new System.Drawing.Point(9, 651);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(99, 25);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// ObscurePanel2
			// 
			this.ObscurePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ObscurePanel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ObscurePanel2.Location = new System.Drawing.Point(9, 303);
			this.ObscurePanel2.MinimumSize = new System.Drawing.Size(878, 345);
			this.ObscurePanel2.Name = "ObscurePanel2";
			this.ObscurePanel2.Size = new System.Drawing.Size(878, 345);
			this.ObscurePanel2.TabIndex = 11;
			this.ObscurePanel2.Visible = false;
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
            this.viewToolStripMenuItem});
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
			this.settingsMenuItem.Size = new System.Drawing.Size(180, 22);
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
			// IncidentsSinceCautionNum
			// 
			this.IncidentsSinceCautionNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IncidentsSinceCautionNum.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncidentsSinceCautionNum.Location = new System.Drawing.Point(0, 172);
			this.IncidentsSinceCautionNum.Margin = new System.Windows.Forms.Padding(0);
			this.IncidentsSinceCautionNum.Name = "IncidentsSinceCautionNum";
			this.IncidentsSinceCautionNum.Size = new System.Drawing.Size(365, 98);
			this.IncidentsSinceCautionNum.TabIndex = 6;
			this.IncidentsSinceCautionNum.Text = "0";
			this.IncidentsSinceCautionNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IncidentsSinceCautionLabel
			// 
			this.IncidentsSinceCautionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IncidentsSinceCautionLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncidentsSinceCautionLabel.Location = new System.Drawing.Point(0, 130);
			this.IncidentsSinceCautionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.IncidentsSinceCautionLabel.Name = "IncidentsSinceCautionLabel";
			this.IncidentsSinceCautionLabel.Size = new System.Drawing.Size(365, 42);
			this.IncidentsSinceCautionLabel.TabIndex = 5;
			this.IncidentsSinceCautionLabel.Text = "Since Last Caution";
			this.IncidentsSinceCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// incidentCountPanel
			// 
			this.incidentCountPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.incidentCountPanel.Controls.Add(this.IncidentsSinceCautionNum);
			this.incidentCountPanel.Controls.Add(this.TotalIncidentCountLabel);
			this.incidentCountPanel.Controls.Add(this.IncidentsSinceCautionLabel);
			this.incidentCountPanel.Controls.Add(this.TotalIncidentCountNum);
			this.incidentCountPanel.Location = new System.Drawing.Point(893, 27);
			this.incidentCountPanel.Name = "incidentCountPanel";
			this.incidentCountPanel.Size = new System.Drawing.Size(365, 270);
			this.incidentCountPanel.TabIndex = 13;
			// 
			// RaceAdminMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.incidentCountPanel);
			this.Controls.Add(this.incidentsTableView);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.cautionPanel);
			this.Controls.Add(this.ObscurePanel2);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
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
        private System.Windows.Forms.Panel ObscurePanel2;
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
	}
}

