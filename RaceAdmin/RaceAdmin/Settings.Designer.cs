
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
			this.autoThrowCaution = new System.Windows.Forms.CheckBox();
			this.lastMinutes = new System.Windows.Forms.NumericUpDown();
			this.lastLaps = new System.Windows.Forms.NumericUpDown();
			this.incidentsRequiredForCautionNumericSelector = new System.Windows.Forms.NumericUpDown();
			this.incidentsRequiredForCautionLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.useTotalIncidentsForCautionCheckBox = new System.Windows.Forms.CheckBox();
			this.detectTowForCautionCheckBox = new System.Windows.Forms.CheckBox();
			this.audioNotification = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.driverIncidentThresholdLabel = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.highlightCautionIncidentColorPanel = new System.Windows.Forms.Panel();
			this.highlight4xIncidentsColorPanel = new System.Windows.Forms.Panel();
			this.driverIncidentThresholdSelectedColorPanel = new System.Windows.Forms.Panel();
			this.driverIncidentThresholdNumericSelector = new System.Windows.Forms.NumericUpDown();
			this.highlightDriverIfIncidentThresholdCheckBox = new System.Windows.Forms.CheckBox();
			this.highlightIncidentThatTriggeredCautionCheckBox = new System.Windows.Forms.CheckBox();
			this.highlight4xIncidentsCheckBox = new System.Windows.Forms.CheckBox();
			this.hideIncidentsCheckBox = new System.Windows.Forms.CheckBox();
			this.driverIncidentThresholdColorDialog = new System.Windows.Forms.ColorDialog();
			this.highlight4xIncidentsColorDialog = new System.Windows.Forms.ColorDialog();
			this.highlightCautionIncidentColorDialog = new System.Windows.Forms.ColorDialog();
			this.driverIncidentThresholdAudioToneCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lastMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lastLaps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.incidentsRequiredForCautionNumericSelector)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.driverIncidentThresholdNumericSelector)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.autoThrowCaution);
			this.groupBox1.Controls.Add(this.lastMinutes);
			this.groupBox1.Controls.Add(this.lastLaps);
			this.groupBox1.Controls.Add(this.incidentsRequiredForCautionNumericSelector);
			this.groupBox1.Controls.Add(this.incidentsRequiredForCautionLabel);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.useTotalIncidentsForCautionCheckBox);
			this.groupBox1.Controls.Add(this.detectTowForCautionCheckBox);
			this.groupBox1.Controls.Add(this.audioNotification);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F);
			this.groupBox1.Location = new System.Drawing.Point(422, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(331, 244);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Full Course Cautions";
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
			this.lastMinutes.Location = new System.Drawing.Point(91, 208);
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
			this.lastLaps.Location = new System.Drawing.Point(91, 180);
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
			// incidentsRequiredForCautionNumericSelector
			// 
			this.incidentsRequiredForCautionNumericSelector.Font = new System.Drawing.Font("Arial", 9.75F);
			this.incidentsRequiredForCautionNumericSelector.Location = new System.Drawing.Point(11, 126);
			this.incidentsRequiredForCautionNumericSelector.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.incidentsRequiredForCautionNumericSelector.Name = "incidentsRequiredForCautionNumericSelector";
			this.incidentsRequiredForCautionNumericSelector.Size = new System.Drawing.Size(48, 22);
			this.incidentsRequiredForCautionNumericSelector.TabIndex = 0;
			this.incidentsRequiredForCautionNumericSelector.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.incidentsRequiredForCautionNumericSelector.ValueChanged += new System.EventHandler(this.IncidentsRequired_ValueChanged);
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
			this.label5.Location = new System.Drawing.Point(145, 210);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(162, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "minutes (timed races only)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 196);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "During last";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(145, 182);
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
			this.audioNotification.Size = new System.Drawing.Size(126, 20);
			this.audioNotification.TabIndex = 2;
			this.audioNotification.Text = "Audio notification";
			this.audioNotification.UseVisualStyleBackColor = true;
			this.audioNotification.CheckedChanged += new System.EventHandler(this.AudioNotification_CheckedChanged);
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
			// driverIncidentThresholdLabel
			// 
			this.driverIncidentThresholdLabel.AutoSize = true;
			this.driverIncidentThresholdLabel.Location = new System.Drawing.Point(28, 132);
			this.driverIncidentThresholdLabel.Name = "driverIncidentThresholdLabel";
			this.driverIncidentThresholdLabel.Size = new System.Drawing.Size(64, 16);
			this.driverIncidentThresholdLabel.TabIndex = 5;
			this.driverIncidentThresholdLabel.Text = "Incidents:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.highlightCautionIncidentColorPanel);
			this.groupBox2.Controls.Add(this.highlight4xIncidentsColorPanel);
			this.groupBox2.Controls.Add(this.driverIncidentThresholdSelectedColorPanel);
			this.groupBox2.Controls.Add(this.driverIncidentThresholdNumericSelector);
			this.groupBox2.Controls.Add(this.highlightDriverIfIncidentThresholdCheckBox);
			this.groupBox2.Controls.Add(this.highlightIncidentThatTriggeredCautionCheckBox);
			this.groupBox2.Controls.Add(this.highlight4xIncidentsCheckBox);
			this.groupBox2.Controls.Add(this.driverIncidentThresholdAudioToneCheckBox);
			this.groupBox2.Controls.Add(this.hideIncidentsCheckBox);
			this.groupBox2.Controls.Add(this.driverIncidentThresholdLabel);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(404, 201);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
			// 
			// highlightCautionIncidentColorPanel
			// 
			this.highlightCautionIncidentColorPanel.BackgroundImage = global::RaceAdmin.Properties.Resources.ColorPickerIcon;
			this.highlightCautionIncidentColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.highlightCautionIncidentColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.highlightCautionIncidentColorPanel.Location = new System.Drawing.Point(254, 71);
			this.highlightCautionIncidentColorPanel.Name = "highlightCautionIncidentColorPanel";
			this.highlightCautionIncidentColorPanel.Size = new System.Drawing.Size(48, 22);
			this.highlightCautionIncidentColorPanel.TabIndex = 7;
			this.highlightCautionIncidentColorPanel.Click += new System.EventHandler(this.highlightCautionIncidentColorPanel_Click);
			this.highlightCautionIncidentColorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.highlightCautionIncidentColorPanel_MouseDown);
			this.highlightCautionIncidentColorPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.highlightCautionIncidentColorPanel_MouseUp);
			// 
			// highlight4xIncidentsColorPanel
			// 
			this.highlight4xIncidentsColorPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("highlight4xIncidentsColorPanel.BackgroundImage")));
			this.highlight4xIncidentsColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.highlight4xIncidentsColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.highlight4xIncidentsColorPanel.Location = new System.Drawing.Point(154, 45);
			this.highlight4xIncidentsColorPanel.Name = "highlight4xIncidentsColorPanel";
			this.highlight4xIncidentsColorPanel.Size = new System.Drawing.Size(48, 22);
			this.highlight4xIncidentsColorPanel.TabIndex = 7;
			this.highlight4xIncidentsColorPanel.Click += new System.EventHandler(this.highlight4xIncidentsColorPanel_Click);
			this.highlight4xIncidentsColorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.highlight4xIncidentsColorPanel_MouseDown);
			this.highlight4xIncidentsColorPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.highlight4xIncidentsColorPanel_MouseUp);
			// 
			// driverIncidentThresholdSelectedColorPanel
			// 
			this.driverIncidentThresholdSelectedColorPanel.BackgroundImage = global::RaceAdmin.Properties.Resources.ColorPickerIcon;
			this.driverIncidentThresholdSelectedColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.driverIncidentThresholdSelectedColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.driverIncidentThresholdSelectedColorPanel.Location = new System.Drawing.Point(335, 97);
			this.driverIncidentThresholdSelectedColorPanel.Name = "driverIncidentThresholdSelectedColorPanel";
			this.driverIncidentThresholdSelectedColorPanel.Size = new System.Drawing.Size(48, 22);
			this.driverIncidentThresholdSelectedColorPanel.TabIndex = 7;
			this.driverIncidentThresholdSelectedColorPanel.Click += new System.EventHandler(this.driverIncidentThresholdSelectedColorPanel_Click);
			this.driverIncidentThresholdSelectedColorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.driverIncidentThresholdSelectedColorPanel_MouseDown);
			this.driverIncidentThresholdSelectedColorPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.driverIncidentThresholdSelectedColorPanel_MouseUp);
			// 
			// driverIncidentThresholdNumericSelector
			// 
			this.driverIncidentThresholdNumericSelector.Font = new System.Drawing.Font("Arial", 9.75F);
			this.driverIncidentThresholdNumericSelector.Location = new System.Drawing.Point(88, 130);
			this.driverIncidentThresholdNumericSelector.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.driverIncidentThresholdNumericSelector.Name = "driverIncidentThresholdNumericSelector";
			this.driverIncidentThresholdNumericSelector.Size = new System.Drawing.Size(48, 22);
			this.driverIncidentThresholdNumericSelector.TabIndex = 0;
			this.driverIncidentThresholdNumericSelector.ValueChanged += new System.EventHandler(this.driverIncidentThresholdNumericSelector_ValueChanged);
			// 
			// highlightDriverIfIncidentThresholdCheckBox
			// 
			this.highlightDriverIfIncidentThresholdCheckBox.AutoSize = true;
			this.highlightDriverIfIncidentThresholdCheckBox.Checked = true;
			this.highlightDriverIfIncidentThresholdCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.highlightDriverIfIncidentThresholdCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.highlightDriverIfIncidentThresholdCheckBox.Location = new System.Drawing.Point(6, 99);
			this.highlightDriverIfIncidentThresholdCheckBox.Name = "highlightDriverIfIncidentThresholdCheckBox";
			this.highlightDriverIfIncidentThresholdCheckBox.Size = new System.Drawing.Size(333, 20);
			this.highlightDriverIfIncidentThresholdCheckBox.TabIndex = 0;
			this.highlightDriverIfIncidentThresholdCheckBox.Text = "Highlight driver if individual incident threshold reached";
			this.highlightDriverIfIncidentThresholdCheckBox.UseVisualStyleBackColor = true;
			this.highlightDriverIfIncidentThresholdCheckBox.CheckedChanged += new System.EventHandler(this.highlightDriverIfIncidentThresholdCheckBox_CheckedChanged);
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
			this.highlight4xIncidentsCheckBox.Checked = true;
			this.highlight4xIncidentsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
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
			// driverIncidentThresholdColorDialog
			// 
			this.driverIncidentThresholdColorDialog.AnyColor = true;
			this.driverIncidentThresholdColorDialog.Color = System.Drawing.Color.White;
			this.driverIncidentThresholdColorDialog.FullOpen = true;
			// 
			// highlight4xIncidentsColorDialog
			// 
			this.highlight4xIncidentsColorDialog.AnyColor = true;
			this.highlight4xIncidentsColorDialog.Color = System.Drawing.Color.IndianRed;
			this.highlight4xIncidentsColorDialog.FullOpen = true;
			// 
			// highlightCautionIncidentColorDialog
			// 
			this.highlightCautionIncidentColorDialog.AnyColor = true;
			this.highlightCautionIncidentColorDialog.Color = System.Drawing.Color.LemonChiffon;
			this.highlightCautionIncidentColorDialog.FullOpen = true;
			// 
			// driverIncidentThresholdAudioToneCheckBox
			// 
			this.driverIncidentThresholdAudioToneCheckBox.AutoSize = true;
			this.driverIncidentThresholdAudioToneCheckBox.Font = new System.Drawing.Font("Arial", 9.75F);
			this.driverIncidentThresholdAudioToneCheckBox.Location = new System.Drawing.Point(142, 131);
			this.driverIncidentThresholdAudioToneCheckBox.Name = "driverIncidentThresholdAudioToneCheckBox";
			this.driverIncidentThresholdAudioToneCheckBox.Size = new System.Drawing.Size(126, 20);
			this.driverIncidentThresholdAudioToneCheckBox.TabIndex = 0;
			this.driverIncidentThresholdAudioToneCheckBox.Text = "Audio notification";
			this.driverIncidentThresholdAudioToneCheckBox.UseVisualStyleBackColor = true;
			this.driverIncidentThresholdAudioToneCheckBox.CheckedChanged += new System.EventHandler(this.driverIncidentThresholdAudioToneCheckBox_CheckedChanged);
			// 
			// SettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(765, 327);
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
			((System.ComponentModel.ISupportInitialize)(this.lastMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lastLaps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.incidentsRequiredForCautionNumericSelector)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.driverIncidentThresholdNumericSelector)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.NumericUpDown incidentsRequiredForCautionNumericSelector;
		public System.Windows.Forms.CheckBox autoThrowCaution;
		public System.Windows.Forms.NumericUpDown lastMinutes;
		public System.Windows.Forms.NumericUpDown lastLaps;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.CheckBox useTotalIncidentsForCautionCheckBox;
		public System.Windows.Forms.CheckBox detectTowForCautionCheckBox;
		public System.Windows.Forms.CheckBox audioNotification;
		public System.Windows.Forms.Label driverIncidentThresholdLabel;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label incidentsRequiredForCautionLabel;
		public System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.CheckBox hideIncidentsCheckBox;
		public System.Windows.Forms.CheckBox highlightIncidentThatTriggeredCautionCheckBox;
		public System.Windows.Forms.CheckBox highlight4xIncidentsCheckBox;
		public System.Windows.Forms.CheckBox highlightDriverIfIncidentThresholdCheckBox;
		private System.Windows.Forms.ColorDialog driverIncidentThresholdColorDialog;
		private System.Windows.Forms.Panel driverIncidentThresholdSelectedColorPanel;
		private System.Windows.Forms.Panel highlightCautionIncidentColorPanel;
		private System.Windows.Forms.Panel highlight4xIncidentsColorPanel;
		private System.Windows.Forms.ColorDialog highlight4xIncidentsColorDialog;
		private System.Windows.Forms.ColorDialog highlightCautionIncidentColorDialog;
		public System.Windows.Forms.NumericUpDown driverIncidentThresholdNumericSelector;
		public System.Windows.Forms.CheckBox driverIncidentThresholdAudioToneCheckBox;
	}
}