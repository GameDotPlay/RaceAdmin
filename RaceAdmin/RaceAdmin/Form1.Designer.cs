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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceAdminMain));
            this.IncidentsTableView = new System.Windows.Forms.DataGridView();
            this.CarNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Incident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverLapNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarNumLabel = new System.Windows.Forms.Label();
            this.DriverNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalIncidentCountLabel = new System.Windows.Forms.Label();
            this.TotalIncidentCountNum = new System.Windows.Forms.Label();
            this.IncidentsSinceCautionLabel = new System.Windows.Forms.Label();
            this.IncidentsSinceCautionNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.IncsRequiredForCautionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CautionPanel = new System.Windows.Forms.Panel();
            this.ExportToCsvCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AudioNotificationCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // IncidentsTableView
            // 
            this.IncidentsTableView.AllowUserToAddRows = false;
            this.IncidentsTableView.AllowUserToDeleteRows = false;
            this.IncidentsTableView.AllowUserToResizeColumns = false;
            this.IncidentsTableView.AllowUserToResizeRows = false;
            this.IncidentsTableView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IncidentsTableView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.IncidentsTableView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.IncidentsTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.IncidentsTableView.ColumnHeadersVisible = false;
            this.IncidentsTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarNum,
            this.DriverName,
            this.Incident,
            this.Total,
            this.DriverLapNum});
            this.IncidentsTableView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IncidentsTableView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.IncidentsTableView.EnableHeadersVisualStyles = false;
            this.IncidentsTableView.Location = new System.Drawing.Point(12, 328);
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
            this.IncidentsTableView.Size = new System.Drawing.Size(568, 272);
            this.IncidentsTableView.TabIndex = 0;
            this.IncidentsTableView.TabStop = false;
            // 
            // CarNum
            // 
            this.CarNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CarNum.DefaultCellStyle = dataGridViewCellStyle1;
            this.CarNum.HeaderText = "CarNum";
            this.CarNum.MinimumWidth = 75;
            this.CarNum.Name = "CarNum";
            this.CarNum.ReadOnly = true;
            this.CarNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CarNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CarNum.Width = 75;
            // 
            // DriverName
            // 
            this.DriverName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DriverName.DefaultCellStyle = dataGridViewCellStyle2;
            this.DriverName.HeaderText = "DriverName";
            this.DriverName.MinimumWidth = 250;
            this.DriverName.Name = "DriverName";
            this.DriverName.ReadOnly = true;
            this.DriverName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DriverName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DriverName.Width = 250;
            // 
            // Incident
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Incident.DefaultCellStyle = dataGridViewCellStyle3;
            this.Incident.HeaderText = "Incident";
            this.Incident.MinimumWidth = 75;
            this.Incident.Name = "Incident";
            this.Incident.ReadOnly = true;
            this.Incident.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Incident.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Incident.Width = 75;
            // 
            // Total
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 75;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 75;
            // 
            // DriverLapNum
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DriverLapNum.DefaultCellStyle = dataGridViewCellStyle5;
            this.DriverLapNum.HeaderText = "DriverLapNum";
            this.DriverLapNum.MinimumWidth = 95;
            this.DriverLapNum.Name = "DriverLapNum";
            this.DriverLapNum.ReadOnly = true;
            this.DriverLapNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DriverLapNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DriverLapNum.Width = 95;
            // 
            // CarNumLabel
            // 
            this.CarNumLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNumLabel.Location = new System.Drawing.Point(11, 302);
            this.CarNumLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CarNumLabel.Name = "CarNumLabel";
            this.CarNumLabel.Size = new System.Drawing.Size(75, 23);
            this.CarNumLabel.TabIndex = 2;
            this.CarNumLabel.Text = "Car #";
            this.CarNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DriverNameLabel
            // 
            this.DriverNameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriverNameLabel.Location = new System.Drawing.Point(90, 302);
            this.DriverNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DriverNameLabel.Name = "DriverNameLabel";
            this.DriverNameLabel.Size = new System.Drawing.Size(250, 23);
            this.DriverNameLabel.TabIndex = 2;
            this.DriverNameLabel.Text = "Driver Name";
            this.DriverNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(490, 302);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Driver Lap #";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalIncidentCountLabel
            // 
            this.TotalIncidentCountLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalIncidentCountLabel.Location = new System.Drawing.Point(640, 31);
            this.TotalIncidentCountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TotalIncidentCountLabel.Name = "TotalIncidentCountLabel";
            this.TotalIncidentCountLabel.Size = new System.Drawing.Size(288, 42);
            this.TotalIncidentCountLabel.TabIndex = 2;
            this.TotalIncidentCountLabel.Text = "Total Incidents";
            this.TotalIncidentCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalIncidentCountNum
            // 
            this.TotalIncidentCountNum.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalIncidentCountNum.Location = new System.Drawing.Point(640, 73);
            this.TotalIncidentCountNum.Margin = new System.Windows.Forms.Padding(0);
            this.TotalIncidentCountNum.Name = "TotalIncidentCountNum";
            this.TotalIncidentCountNum.Size = new System.Drawing.Size(288, 100);
            this.TotalIncidentCountNum.TabIndex = 2;
            this.TotalIncidentCountNum.Text = "0";
            this.TotalIncidentCountNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncidentsSinceCautionLabel
            // 
            this.IncidentsSinceCautionLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncidentsSinceCautionLabel.Location = new System.Drawing.Point(640, 172);
            this.IncidentsSinceCautionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IncidentsSinceCautionLabel.Name = "IncidentsSinceCautionLabel";
            this.IncidentsSinceCautionLabel.Size = new System.Drawing.Size(288, 42);
            this.IncidentsSinceCautionLabel.TabIndex = 2;
            this.IncidentsSinceCautionLabel.Text = "Since Last Caution";
            this.IncidentsSinceCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncidentsSinceCautionNum
            // 
            this.IncidentsSinceCautionNum.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncidentsSinceCautionNum.Location = new System.Drawing.Point(640, 214);
            this.IncidentsSinceCautionNum.Margin = new System.Windows.Forms.Padding(0);
            this.IncidentsSinceCautionNum.Name = "IncidentsSinceCautionNum";
            this.IncidentsSinceCautionNum.Size = new System.Drawing.Size(288, 100);
            this.IncidentsSinceCautionNum.TabIndex = 2;
            this.IncidentsSinceCautionNum.Text = "0";
            this.IncidentsSinceCautionNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(346, 302);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Inc.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncsRequiredForCautionTextBox
            // 
            this.IncsRequiredForCautionTextBox.Location = new System.Drawing.Point(743, 338);
            this.IncsRequiredForCautionTextBox.Name = "IncsRequiredForCautionTextBox";
            this.IncsRequiredForCautionTextBox.Size = new System.Drawing.Size(74, 20);
            this.IncsRequiredForCautionTextBox.TabIndex = 3;
            this.IncsRequiredForCautionTextBox.Text = "0";
            this.IncsRequiredForCautionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IncsRequiredForCautionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IncsRequiredForCautionTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(640, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Enter to confirm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CautionPanel
            // 
            this.CautionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.CautionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CautionPanel.Location = new System.Drawing.Point(12, 12);
            this.CautionPanel.Name = "CautionPanel";
            this.CautionPanel.Size = new System.Drawing.Size(568, 273);
            this.CautionPanel.TabIndex = 4;
            // 
            // ExportToCsvCheckBox
            // 
            this.ExportToCsvCheckBox.AutoSize = true;
            this.ExportToCsvCheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportToCsvCheckBox.Location = new System.Drawing.Point(661, 580);
            this.ExportToCsvCheckBox.Name = "ExportToCsvCheckBox";
            this.ExportToCsvCheckBox.Size = new System.Drawing.Size(237, 20);
            this.ExportToCsvCheckBox.TabIndex = 5;
            this.ExportToCsvCheckBox.Text = "Export incident table to csv on close";
            this.ExportToCsvCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(417, 302);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(640, 312);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Incs required for caution";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioNotificationCheckBox
            // 
            this.AudioNotificationCheckBox.AutoSize = true;
            this.AudioNotificationCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.AudioNotificationCheckBox.Location = new System.Drawing.Point(661, 557);
            this.AudioNotificationCheckBox.Name = "AudioNotificationCheckBox";
            this.AudioNotificationCheckBox.Size = new System.Drawing.Size(151, 20);
            this.AudioNotificationCheckBox.TabIndex = 6;
            this.AudioNotificationCheckBox.Text = "Use audio notification";
            this.AudioNotificationCheckBox.UseVisualStyleBackColor = true;
            this.AudioNotificationCheckBox.CheckedChanged += new System.EventHandler(this.AudioNotificationCheckBox_CheckedChanged);
            // 
            // RaceAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(954, 612);
            this.Controls.Add(this.AudioNotificationCheckBox);
            this.Controls.Add(this.ExportToCsvCheckBox);
            this.Controls.Add(this.CautionPanel);
            this.Controls.Add(this.IncsRequiredForCautionTextBox);
            this.Controls.Add(this.IncidentsSinceCautionNum);
            this.Controls.Add(this.IncidentsSinceCautionLabel);
            this.Controls.Add(this.TotalIncidentCountNum);
            this.Controls.Add(this.TotalIncidentCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DriverNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CarNumLabel);
            this.Controls.Add(this.IncidentsTableView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RaceAdminMain";
            this.Text = "Race Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView IncidentsTableView;
        private System.Windows.Forms.Label CarNumLabel;
        private System.Windows.Forms.Label DriverNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalIncidentCountLabel;
        private System.Windows.Forms.Label TotalIncidentCountNum;
        private System.Windows.Forms.Label IncidentsSinceCautionLabel;
        private System.Windows.Forms.Label IncidentsSinceCautionNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox IncsRequiredForCautionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CautionPanel;
        private System.Windows.Forms.CheckBox ExportToCsvCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incident;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverLapNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox AudioNotificationCheckBox;
    }
}

