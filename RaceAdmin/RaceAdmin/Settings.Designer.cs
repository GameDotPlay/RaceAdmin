
namespace RaceAdmin
{
	partial class SettingsDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.incidentsRequiredForCaution = new System.Windows.Forms.NumericUpDown();
			this.autoThrowCaution = new System.Windows.Forms.CheckBox();
			this.lastMinutes = new System.Windows.Forms.NumericUpDown();
			this.lastLaps = new System.Windows.Forms.NumericUpDown();
			this.incidentsRequiredForCautionLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.useTotalIncidentsForCautionCheckBox = new System.Windows.Forms.CheckBox();
			this.detectTowForCautionCheckBox = new System.Windows.Forms.CheckBox();
			this.audioNotification = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.highlightIncidentThatTriggeredCautionCheckBox = new System.Windows.Forms.CheckBox();
			this.highlight4xIncidentsCheckBox = new System.Windows.Forms.CheckBox();
			this.hideIncidentsCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidentsRequiredForCaution)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lastMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lastLaps)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.incidentsRequiredForCaution);
			this.groupBox1.Controls.Add(this.autoThrowCaution);
			this.groupBox1.Controls.Add(this.lastMinutes);
			this.groupBox1.Controls.Add(this.lastLaps);
			this.groupBox1.Controls.Add(this.incidentsRequiredForCautionLabel);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.useTotalIncidentsForCautionCheckBox);
			this.groupBox1.Controls.Add(this.detectTowForCautionCheckBox);
			this.groupBox1.Controls.Add(this.audioNotification);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F);
			this.groupBox1.Location = new System.Drawing.Point(274, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(355, 257);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Full Course Cautions";
			// 
			// incidentsRequiredForCaution
			// 
			this.incidentsRequiredForCaution.Font = new System.Drawing.Font("Arial", 9.75F);
			this.incidentsRequiredForCaution.Location = new System.Drawing.Point(11, 125);
			this.incidentsRequiredForCaution.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.incidentsRequiredForCaution.Name = "incidentsRequiredForCaution";
			this.incidentsRequiredForCaution.Size = new System.Drawing.Size(48, 22);
			this.incidentsRequiredForCaution.TabIndex = 0;
			this.incidentsRequiredForCaution.ValueChanged += new System.EventHandler(this.IncidentsRequired_ValueChanged);
			// 
			// autoThrowCaution
			// 
			this.autoThrowCaution.AutoSize = true;
			this.autoThrowCaution.Font = new System.Drawing.Font("Arial", 9.75F);
			this.autoThrowCaution.Location = new System.Drawing.Point(11, 73);
			this.autoThrowCaution.Name = "autoThrowCaution";
			this.autoThrowCaution.Size = new System.Drawing.Size(249, 20);
			this.autoThrowCaution.TabIndex = 3;
			this.autoThrowCaution.Text = "Throw caution flag automatically (beta)";
			this.autoThrowCaution.UseVisualStyleBackColor = true;
			this.autoThrowCaution.CheckedChanged += new System.EventHandler(this.AutoThrowCaution_CheckedChanged);
			// 
			// lastMinutes
			// 
			this.lastMinutes.Font = new System.Drawing.Font("Arial", 9.75F);
			this.lastMinutes.Location = new System.Drawing.Point(102, 207);
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
			this.lastLaps.Location = new System.Drawing.Point(102, 179);
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
			// incidentsRequiredForCautionLabel
			// 
			this.incidentsRequiredForCautionLabel.Font = new System.Drawing.Font("Arial", 9.75F);
			this.incidentsRequiredForCautionLabel.Location = new System.Drawing.Point(62, 125);
			this.incidentsRequiredForCautionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.incidentsRequiredForCautionLabel.Name = "incidentsRequiredForCautionLabel";
			this.incidentsRequiredForCautionLabel.Size = new System.Drawing.Size(179, 23);
			this.incidentsRequiredForCautionLabel.TabIndex = 1;
			this.incidentsRequiredForCautionLabel.Text = "Incidents required for caution";
			this.incidentsRequiredForCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(156, 209);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(162, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "minutes (timed races only)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 209);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "During last";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(156, 181);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(161, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "laps (lap count races only)";
			// 
			// useTotalIncidentsForCautionCheckBox
			// 
			this.useTotalIncidentsForCautionCheckBox.AutoSize = true;
			this.useTotalIncidentsForCautionCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.useTotalIncidentsForCautionCheckBox.Location = new System.Drawing.Point(11, 47);
			this.useTotalIncidentsForCautionCheckBox.Name = "useTotalIncidentsForCautionCheckBox";
			this.useTotalIncidentsForCautionCheckBox.Size = new System.Drawing.Size(236, 20);
			this.useTotalIncidentsForCautionCheckBox.TabIndex = 2;
			this.useTotalIncidentsForCautionCheckBox.Text = "Use total incidents to trigger caution";
			this.useTotalIncidentsForCautionCheckBox.UseVisualStyleBackColor = true;
			this.useTotalIncidentsForCautionCheckBox.CheckedChanged += new System.EventHandler(this.UseTotalIncidentsForCaution_CheckChanged);
			// 
			// detectTowForCautionCheckBox
			// 
			this.detectTowForCautionCheckBox.AutoSize = true;
			this.detectTowForCautionCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.detectTowForCautionCheckBox.Location = new System.Drawing.Point(11, 21);
			this.detectTowForCautionCheckBox.Name = "detectTowForCautionCheckBox";
			this.detectTowForCautionCheckBox.Size = new System.Drawing.Size(190, 20);
			this.detectTowForCautionCheckBox.TabIndex = 2;
			this.detectTowForCautionCheckBox.Text = "Detect tow for caution (beta)";
			this.detectTowForCautionCheckBox.UseVisualStyleBackColor = true;
			this.detectTowForCautionCheckBox.CheckedChanged += new System.EventHandler(this.DetectTowForCaution_CheckChanged);
			// 
			// audioNotification
			// 
			this.audioNotification.AutoSize = true;
			this.audioNotification.Font = new System.Drawing.Font("Arial", 9.75F);
			this.audioNotification.Location = new System.Drawing.Point(11, 99);
			this.audioNotification.Name = "audioNotification";
			this.audioNotification.Size = new System.Drawing.Size(151, 20);
			this.audioNotification.TabIndex = 2;
			this.audioNotification.Text = "Use audio notification";
			this.audioNotification.UseVisualStyleBackColor = true;
			this.audioNotification.CheckedChanged += new System.EventHandler(this.AudioNotification_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 181);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "During last";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 162);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "No cautions:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.highlightIncidentThatTriggeredCautionCheckBox);
			this.groupBox2.Controls.Add(this.highlight4xIncidentsCheckBox);
			this.groupBox2.Controls.Add(this.hideIncidentsCheckBox);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(256, 119);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
			// 
			// highlightIncidentThatTriggeredCautionCheckBox
			// 
			this.highlightIncidentThatTriggeredCautionCheckBox.AutoSize = true;
			this.highlightIncidentThatTriggeredCautionCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.highlightIncidentThatTriggeredCautionCheckBox.Location = new System.Drawing.Point(6, 73);
			this.highlightIncidentThatTriggeredCautionCheckBox.Name = "highlightIncidentThatTriggeredCautionCheckBox";
			this.highlightIncidentThatTriggeredCautionCheckBox.Size = new System.Drawing.Size(252, 20);
			this.highlightIncidentThatTriggeredCautionCheckBox.TabIndex = 0;
			this.highlightIncidentThatTriggeredCautionCheckBox.Text = "Highlight incident that triggered caution";
			this.highlightIncidentThatTriggeredCautionCheckBox.UseVisualStyleBackColor = true;
			this.highlightIncidentThatTriggeredCautionCheckBox.CheckedChanged += new System.EventHandler(this.highlightIncidentThatTriggeredCautionCheckBox_CheckedChanged);
			// 
			// highlight4xIncidentsCheckBox
			// 
			this.highlight4xIncidentsCheckBox.AutoSize = true;
			this.highlight4xIncidentsCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.highlight4xIncidentsCheckBox.Location = new System.Drawing.Point(6, 47);
			this.highlight4xIncidentsCheckBox.Name = "highlight4xIncidentsCheckBox";
			this.highlight4xIncidentsCheckBox.Size = new System.Drawing.Size(151, 20);
			this.highlight4xIncidentsCheckBox.TabIndex = 0;
			this.highlight4xIncidentsCheckBox.Text = "Highlight 4x incidents";
			this.highlight4xIncidentsCheckBox.UseVisualStyleBackColor = true;
			this.highlight4xIncidentsCheckBox.CheckedChanged += new System.EventHandler(this.highlight4xIncidentsCheckBox_CheckedChanged);
			// 
			// hideIncidentsCheckBox
			// 
			this.hideIncidentsCheckBox.AutoSize = true;
			this.hideIncidentsCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.hideIncidentsCheckBox.Location = new System.Drawing.Point(6, 21);
			this.hideIncidentsCheckBox.Name = "hideIncidentsCheckBox";
			this.hideIncidentsCheckBox.Size = new System.Drawing.Size(177, 20);
			this.hideIncidentsCheckBox.TabIndex = 0;
			this.hideIncidentsCheckBox.Text = "Hide incidents during race";
			this.hideIncidentsCheckBox.UseVisualStyleBackColor = true;
			this.hideIncidentsCheckBox.CheckedChanged += new System.EventHandler(this.hideIncidentsCheckBox_CheckedChanged);
			// 
			// SettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 327);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(660, 366);
			this.Name = "SettingsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDialog_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidentsRequiredForCaution)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lastMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lastLaps)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.NumericUpDown incidentsRequiredForCaution;
		public System.Windows.Forms.CheckBox autoThrowCaution;
		public System.Windows.Forms.NumericUpDown lastMinutes;
		public System.Windows.Forms.NumericUpDown lastLaps;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.CheckBox useTotalIncidentsForCautionCheckBox;
		public System.Windows.Forms.CheckBox detectTowForCautionCheckBox;
		public System.Windows.Forms.CheckBox audioNotification;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label incidentsRequiredForCautionLabel;
		public System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.CheckBox hideIncidentsCheckBox;
		public System.Windows.Forms.CheckBox highlightIncidentThatTriggeredCautionCheckBox;
		public System.Windows.Forms.CheckBox highlight4xIncidentsCheckBox;
	}
}