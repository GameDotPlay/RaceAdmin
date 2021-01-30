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
            this.IncidentsTableView = new System.Windows.Forms.DataGridView();
            this.CarNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Incident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverLapNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalIncidentCountLabel = new System.Windows.Forms.Label();
            this.TotalIncidentCountNum = new System.Windows.Forms.Label();
            this.IncidentsSinceCautionLabel = new System.Windows.Forms.Label();
            this.IncidentsSinceCautionNum = new System.Windows.Forms.Label();
            this.IncsRequiredForCautionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CautionPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.AudioNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IncidentsTableView
            // 
            this.IncidentsTableView.AllowUserToAddRows = false;
            this.IncidentsTableView.AllowUserToDeleteRows = false;
            this.IncidentsTableView.AllowUserToResizeRows = false;
            this.IncidentsTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IncidentsTableView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.IncidentsTableView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.IncidentsTableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.IncidentsTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.IncidentsTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarNum,
            this.DriverName,
            this.Incident,
            this.Total,
            this.DriverLapNum});
            this.IncidentsTableView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IncidentsTableView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.IncidentsTableView.EnableHeadersVisualStyles = false;
            this.IncidentsTableView.Location = new System.Drawing.Point(12, 291);
            this.IncidentsTableView.MinimumSize = new System.Drawing.Size(568, 309);
            this.IncidentsTableView.Name = "IncidentsTableView";
            this.IncidentsTableView.ReadOnly = true;
            this.IncidentsTableView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.IncidentsTableView.RowHeadersVisible = false;
            this.IncidentsTableView.RowHeadersWidth = 4;
            this.IncidentsTableView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.IncidentsTableView.RowTemplate.ReadOnly = true;
            this.IncidentsTableView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IncidentsTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.IncidentsTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IncidentsTableView.ShowCellErrors = false;
            this.IncidentsTableView.ShowCellToolTips = false;
            this.IncidentsTableView.ShowEditingIcon = false;
            this.IncidentsTableView.ShowRowErrors = false;
            this.IncidentsTableView.Size = new System.Drawing.Size(591, 329);
            this.IncidentsTableView.TabIndex = 0;
            this.IncidentsTableView.TabStop = false;
            this.IncidentsTableView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.IncidentsTableView_SortCompare);
            // 
            // CarNum
            // 
            this.CarNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CarNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.CarNum.DividerWidth = 1;
            this.CarNum.HeaderText = "Car #";
            this.CarNum.MinimumWidth = 75;
            this.CarNum.Name = "CarNum";
            this.CarNum.ReadOnly = true;
            this.CarNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CarNum.Width = 75;
            // 
            // DriverName
            // 
            this.DriverName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DriverName.DefaultCellStyle = dataGridViewCellStyle3;
            this.DriverName.DividerWidth = 1;
            this.DriverName.HeaderText = "Driver Name";
            this.DriverName.MinimumWidth = 250;
            this.DriverName.Name = "DriverName";
            this.DriverName.ReadOnly = true;
            this.DriverName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Incident
            // 
            this.Incident.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Incident.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DriverLapNum.DefaultCellStyle = dataGridViewCellStyle6;
            this.DriverLapNum.HeaderText = "Driver Lap #";
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
            this.TotalIncidentCountLabel.TabIndex = 2;
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
            this.TotalIncidentCountNum.TabIndex = 2;
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
            this.IncidentsSinceCautionLabel.TabIndex = 2;
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
            this.IncidentsSinceCautionNum.TabIndex = 2;
            this.IncidentsSinceCautionNum.Text = "0";
            this.IncidentsSinceCautionNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncsRequiredForCautionTextBox
            // 
            this.IncsRequiredForCautionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncsRequiredForCautionTextBox.Location = new System.Drawing.Point(766, 338);
            this.IncsRequiredForCautionTextBox.Name = "IncsRequiredForCautionTextBox";
            this.IncsRequiredForCautionTextBox.Size = new System.Drawing.Size(74, 20);
            this.IncsRequiredForCautionTextBox.TabIndex = 3;
            this.IncsRequiredForCautionTextBox.Text = "0";
            this.IncsRequiredForCautionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IncsRequiredForCautionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IncsRequiredForCautionTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(663, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Enter to confirm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CautionPanel
            // 
            this.CautionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CautionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.CautionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CautionPanel.Location = new System.Drawing.Point(12, 12);
            this.CautionPanel.MinimumSize = new System.Drawing.Size(568, 273);
            this.CautionPanel.Name = "CautionPanel";
            this.CautionPanel.Size = new System.Drawing.Size(591, 273);
            this.CautionPanel.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(663, 312);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Incs required for caution";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioNotificationCheckBox
            // 
            this.AudioNotificationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioNotificationCheckBox.AutoSize = true;
            this.AudioNotificationCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.AudioNotificationCheckBox.Location = new System.Drawing.Point(739, 628);
            this.AudioNotificationCheckBox.Name = "AudioNotificationCheckBox";
            this.AudioNotificationCheckBox.Size = new System.Drawing.Size(151, 20);
            this.AudioNotificationCheckBox.TabIndex = 6;
            this.AudioNotificationCheckBox.Text = "Use audio notification";
            this.AudioNotificationCheckBox.UseVisualStyleBackColor = true;
            this.AudioNotificationCheckBox.CheckedChanged += new System.EventHandler(this.AudioNotificationCheckBox_CheckedChanged);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.ExportButton.Location = new System.Drawing.Point(506, 626);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(97, 23);
            this.ExportButton.TabIndex = 7;
            this.ExportButton.Text = "Export...";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 631);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "1.1.0";
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
            // RaceAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(977, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.AudioNotificationCheckBox);
            this.Controls.Add(this.CautionPanel);
            this.Controls.Add(this.IncsRequiredForCautionTextBox);
            this.Controls.Add(this.IncidentsSinceCautionNum);
            this.Controls.Add(this.IncidentsSinceCautionLabel);
            this.Controls.Add(this.TotalIncidentCountNum);
            this.Controls.Add(this.TotalIncidentCountLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IncidentsTableView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(993, 700);
            this.Name = "RaceAdminMain";
            this.Text = "Race Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView IncidentsTableView;
        private System.Windows.Forms.Label TotalIncidentCountLabel;
        private System.Windows.Forms.Label TotalIncidentCountNum;
        private System.Windows.Forms.Label IncidentsSinceCautionLabel;
        private System.Windows.Forms.Label IncidentsSinceCautionNum;
        private System.Windows.Forms.TextBox IncsRequiredForCautionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CautionPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox AudioNotificationCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incident;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverLapNum;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

