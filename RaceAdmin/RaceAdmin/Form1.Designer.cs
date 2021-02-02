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
            this.IncidentsSinceCautionLabel = new System.Windows.Forms.Label();
            this.IncidentsSinceCautionNum = new System.Windows.Forms.Label();
            this.CautionPanel = new System.Windows.Forms.Panel();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.audioNotification = new System.Windows.Forms.CheckBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ObscurePanel1 = new System.Windows.Forms.Panel();
            this.ObscurePanel2 = new System.Windows.Forms.Panel();
            this.hideIncidents = new System.Windows.Forms.CheckBox();
            this.autoThrowCaution = new System.Windows.Forms.CheckBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.incidentsRequired = new System.Windows.Forms.NumericUpDown();
            this.lastMinutes = new System.Windows.Forms.NumericUpDown();
            this.lastLaps = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsTableView)).BeginInit();
            this.CautionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastLaps)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
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
            this.incidentsTableView.Location = new System.Drawing.Point(12, 291);
            this.incidentsTableView.MinimumSize = new System.Drawing.Size(568, 309);
            this.incidentsTableView.Name = "incidentsTableView";
            this.incidentsTableView.ReadOnly = true;
            this.incidentsTableView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.incidentsTableView.RowHeadersVisible = false;
            this.incidentsTableView.RowHeadersWidth = 4;
            this.incidentsTableView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.incidentsTableView.RowTemplate.ReadOnly = true;
            this.incidentsTableView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.incidentsTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.incidentsTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.incidentsTableView.ShowCellErrors = false;
            this.incidentsTableView.ShowCellToolTips = false;
            this.incidentsTableView.ShowEditingIcon = false;
            this.incidentsTableView.ShowRowErrors = false;
            this.incidentsTableView.Size = new System.Drawing.Size(591, 329);
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
            this.TotalIncidentCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalIncidentCountLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalIncidentCountLabel.Location = new System.Drawing.Point(663, 31);
            this.TotalIncidentCountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TotalIncidentCountLabel.Name = "TotalIncidentCountLabel";
            this.TotalIncidentCountLabel.Size = new System.Drawing.Size(288, 42);
            this.TotalIncidentCountLabel.TabIndex = 3;
            this.TotalIncidentCountLabel.Text = "Total Incidents";
            this.TotalIncidentCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalIncidentCountNum
            // 
            this.TotalIncidentCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalIncidentCountNum.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalIncidentCountNum.Location = new System.Drawing.Point(663, 73);
            this.TotalIncidentCountNum.Margin = new System.Windows.Forms.Padding(0);
            this.TotalIncidentCountNum.Name = "TotalIncidentCountNum";
            this.TotalIncidentCountNum.Size = new System.Drawing.Size(288, 100);
            this.TotalIncidentCountNum.TabIndex = 4;
            this.TotalIncidentCountNum.Text = "0";
            this.TotalIncidentCountNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncidentsSinceCautionLabel
            // 
            this.IncidentsSinceCautionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncidentsSinceCautionLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncidentsSinceCautionLabel.Location = new System.Drawing.Point(663, 172);
            this.IncidentsSinceCautionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IncidentsSinceCautionLabel.Name = "IncidentsSinceCautionLabel";
            this.IncidentsSinceCautionLabel.Size = new System.Drawing.Size(288, 42);
            this.IncidentsSinceCautionLabel.TabIndex = 5;
            this.IncidentsSinceCautionLabel.Text = "Since Last Caution";
            this.IncidentsSinceCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncidentsSinceCautionNum
            // 
            this.IncidentsSinceCautionNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncidentsSinceCautionNum.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncidentsSinceCautionNum.Location = new System.Drawing.Point(663, 214);
            this.IncidentsSinceCautionNum.Margin = new System.Windows.Forms.Padding(0);
            this.IncidentsSinceCautionNum.Name = "IncidentsSinceCautionNum";
            this.IncidentsSinceCautionNum.Size = new System.Drawing.Size(288, 100);
            this.IncidentsSinceCautionNum.TabIndex = 6;
            this.IncidentsSinceCautionNum.Text = "0";
            this.IncidentsSinceCautionNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CautionPanel
            // 
            this.CautionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CautionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.CautionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CautionPanel.Controls.Add(this.sessionLabel);
            this.CautionPanel.Location = new System.Drawing.Point(12, 12);
            this.CautionPanel.MinimumSize = new System.Drawing.Size(568, 273);
            this.CautionPanel.Name = "CautionPanel";
            this.CautionPanel.Size = new System.Drawing.Size(591, 273);
            this.CautionPanel.TabIndex = 0;
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label4.Location = new System.Drawing.Point(64, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "incidents required for caution";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // audioNotification
            // 
            this.audioNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.audioNotification.AutoSize = true;
            this.audioNotification.Font = new System.Drawing.Font("Arial", 9.75F);
            this.audioNotification.Location = new System.Drawing.Point(13, 51);
            this.audioNotification.Name = "audioNotification";
            this.audioNotification.Size = new System.Drawing.Size(151, 20);
            this.audioNotification.TabIndex = 2;
            this.audioNotification.Text = "Use audio notification";
            this.audioNotification.UseVisualStyleBackColor = true;
            this.audioNotification.CheckedChanged += new System.EventHandler(this.AudioNotification_CheckedChanged);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.exportButton.Location = new System.Drawing.Point(506, 626);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(97, 23);
            this.exportButton.TabIndex = 10;
            this.exportButton.Text = "Export...";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(117, 631);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(37, 13);
            this.versionLabel.TabIndex = 11;
            this.versionLabel.Text = "v1.0.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::RaceAdmin.Properties.Resources._2021_vApex_Flag_Logo4_RG_Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 624);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ObscurePanel1
            // 
            this.ObscurePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ObscurePanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ObscurePanel1.CausesValidation = false;
            this.ObscurePanel1.Enabled = false;
            this.ObscurePanel1.Location = new System.Drawing.Point(610, 13);
            this.ObscurePanel1.Name = "ObscurePanel1";
            this.ObscurePanel1.Size = new System.Drawing.Size(355, 301);
            this.ObscurePanel1.TabIndex = 2;
            this.ObscurePanel1.Visible = false;
            // 
            // ObscurePanel2
            // 
            this.ObscurePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObscurePanel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ObscurePanel2.Location = new System.Drawing.Point(12, 291);
            this.ObscurePanel2.Name = "ObscurePanel2";
            this.ObscurePanel2.Size = new System.Drawing.Size(591, 329);
            this.ObscurePanel2.TabIndex = 11;
            this.ObscurePanel2.Visible = false;
            // 
            // hideIncidents
            // 
            this.hideIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hideIncidents.AutoSize = true;
            this.hideIncidents.Font = new System.Drawing.Font("Arial", 9.75F);
            this.hideIncidents.Location = new System.Drawing.Point(13, 21);
            this.hideIncidents.Name = "hideIncidents";
            this.hideIncidents.Size = new System.Drawing.Size(177, 20);
            this.hideIncidents.TabIndex = 0;
            this.hideIncidents.Text = "Hide incidents during race";
            this.hideIncidents.UseVisualStyleBackColor = true;
            this.hideIncidents.CheckedChanged += new System.EventHandler(this.HideIncidents_CheckedChanged);
            // 
            // autoThrowCaution
            // 
            this.autoThrowCaution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoThrowCaution.AutoSize = true;
            this.autoThrowCaution.Font = new System.Drawing.Font("Arial", 9.75F);
            this.autoThrowCaution.Location = new System.Drawing.Point(13, 77);
            this.autoThrowCaution.Name = "autoThrowCaution";
            this.autoThrowCaution.Size = new System.Drawing.Size(249, 20);
            this.autoThrowCaution.TabIndex = 3;
            this.autoThrowCaution.Text = "Throw caution flag automatically (beta)";
            this.autoThrowCaution.UseVisualStyleBackColor = true;
            this.autoThrowCaution.CheckedChanged += new System.EventHandler(this.AutoThrowCaution_CheckedChanged);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.applyButton.Location = new System.Drawing.Point(890, 626);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.incidentsRequired);
            this.groupBox1.Controls.Add(this.autoThrowCaution);
            this.groupBox1.Controls.Add(this.lastMinutes);
            this.groupBox1.Controls.Add(this.lastLaps);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.audioNotification);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(610, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 196);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full Course Cautions";
            // 
            // incidentsRequired
            // 
            this.incidentsRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.incidentsRequired.Font = new System.Drawing.Font("Arial", 9.75F);
            this.incidentsRequired.Location = new System.Drawing.Point(13, 23);
            this.incidentsRequired.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.incidentsRequired.Name = "incidentsRequired";
            this.incidentsRequired.Size = new System.Drawing.Size(48, 22);
            this.incidentsRequired.TabIndex = 0;
            this.incidentsRequired.ValueChanged += new System.EventHandler(this.IncidentsRequired_ValueChanged);
            // 
            // lastMinutes
            // 
            this.lastMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lastMinutes.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lastMinutes.Location = new System.Drawing.Point(95, 165);
            this.lastMinutes.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.lastMinutes.Name = "lastMinutes";
            this.lastMinutes.Size = new System.Drawing.Size(48, 22);
            this.lastMinutes.TabIndex = 9;
            this.lastMinutes.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.lastMinutes.ValueChanged += new System.EventHandler(this.LastMinutes_ValueChanged);
            // 
            // lastLaps
            // 
            this.lastLaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lastLaps.Location = new System.Drawing.Point(95, 139);
            this.lastLaps.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.lastLaps.Name = "lastLaps";
            this.lastLaps.Size = new System.Drawing.Size(48, 22);
            this.lastLaps.TabIndex = 6;
            this.lastLaps.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.lastLaps.ValueChanged += new System.EventHandler(this.LastLaps_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "minutes (timed races only)";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "During last";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "laps (lap count races only)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "During last";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Do not throw cautions:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.hideIncidents);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(610, 522);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 98);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // RaceAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(977, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.CautionPanel);
            this.Controls.Add(this.IncidentsSinceCautionNum);
            this.Controls.Add(this.IncidentsSinceCautionLabel);
            this.Controls.Add(this.TotalIncidentCountNum);
            this.Controls.Add(this.incidentsTableView);
            this.Controls.Add(this.ObscurePanel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TotalIncidentCountLabel);
            this.Controls.Add(this.ObscurePanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(993, 700);
            this.Name = "RaceAdminMain";
            this.Text = "Race Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaceAdminMain_FormClosing);
            this.Load += new System.EventHandler(this.RaceAdminMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incidentsTableView)).EndInit();
            this.CautionPanel.ResumeLayout(false);
            this.CautionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastLaps)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView incidentsTableView;
        private System.Windows.Forms.Label TotalIncidentCountLabel;
        private System.Windows.Forms.Label TotalIncidentCountNum;
        private System.Windows.Forms.Label IncidentsSinceCautionLabel;
        private System.Windows.Forms.Label IncidentsSinceCautionNum;
        private System.Windows.Forms.Panel CautionPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox audioNotification;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incident;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverLapNum;
        private System.Windows.Forms.Panel ObscurePanel1;
        private System.Windows.Forms.Panel ObscurePanel2;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.CheckBox hideIncidents;
        private System.Windows.Forms.CheckBox autoThrowCaution;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown lastMinutes;
        private System.Windows.Forms.NumericUpDown incidentsRequired;
        private System.Windows.Forms.NumericUpDown lastLaps;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

