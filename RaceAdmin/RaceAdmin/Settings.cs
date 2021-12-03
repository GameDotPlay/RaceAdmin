using System;
using System.Media;
using System.Windows.Forms;

namespace RaceAdmin
{
	public partial class SettingsDialog : Form
	{
        private RaceAdminMain parent;

		public SettingsDialog(RaceAdminMain parent)
		{
			InitializeComponent();
            this.parent = parent;

            // Full course yellow settings
            detectTowForCautionCheckBox.Checked = Properties.Settings.Default.detectTowForCaution;
            useTotalIncidentsForCautionCheckBox.Checked = Properties.Settings.Default.useTotalIncidentsForCaution;
            incidentsRequiredForCautionNumericSelector.Value = Properties.Settings.Default.incidentsRequired;
            audioNotification.Checked = Properties.Settings.Default.audioNotification;
            autoThrowCaution.Checked = Properties.Settings.Default.autoThrowCaution;
            lastLaps.Value = Properties.Settings.Default.lastLaps;
            lastMinutes.Value = Properties.Settings.Default.lastMinutes;
            UseTotalIncidentsForCaution_CheckChanged(null, null);

            // General settings
            hideIncidentsCheckBox.Checked = Properties.Settings.Default.hideIncidents;
            highlight4xIncidentsCheckBox.Checked = Properties.Settings.Default.highlight4xIncidents;
            highlightIncidentThatTriggeredCautionCheckBox.Checked = Properties.Settings.Default.highlightIncidentThatTriggeredCaution;
            highlightDriverIfIncidentThresholdCheckBox.Checked = Properties.Settings.Default.highlightDriverIfIncidentThreshold;
            highlight4xIncidentsCheckBox_CheckedChanged(null, null);
            highlightIncidentThatTriggeredCautionCheckBox_CheckedChanged(null, null);
            highlightDriverIfIncidentThresholdCheckBox_CheckedChanged(null, null);
            driverIncidentThresholdNumericSelector.Value = Properties.Settings.Default.highlightDriverIncidentThreshold;
        }

        private void DetectTowForCaution_CheckChanged(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.detectTowForCaution = detectTowForCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void UseTotalIncidentsForCaution_CheckChanged(object sender, EventArgs e)
        {
            if(useTotalIncidentsForCautionCheckBox.Checked)
			{
                incidentsRequiredForCautionLabel.Enabled = true;
                incidentsRequiredForCautionNumericSelector.Enabled = true;
            }
            else
			{
                incidentsRequiredForCautionLabel.Enabled = false;
                incidentsRequiredForCautionNumericSelector.Enabled = false;
            }

            Properties.Settings.Default.useTotalIncidentsForCaution = useTotalIncidentsForCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void hideIncidentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hideIncidents = hideIncidentsCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void IncidentsRequired_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.incidentsRequired = (int)incidentsRequiredForCautionNumericSelector.Value;
            Properties.Settings.Default.Save();
        }

        private void AudioNotification_CheckedChanged(object sender, EventArgs e)
        {
            if (audioNotification.Checked)
            {
                var player = new SoundPlayer(RaceAdmin.Resources.Caution);
                var handler = new AudioCautionHandler(new SoundPlayerProxy(player))
                {
                    Repeat = 5, // times
                    Interval = 1000 // ms
                };

                parent.CautionHandlers.Add("audio", handler);
            }
            else
            {
                parent.CautionHandlers.Remove("audio");
            }

            Properties.Settings.Default.audioNotification = audioNotification.Checked;
            Properties.Settings.Default.Save();
        }

        private void AutoThrowCaution_CheckedChanged(object sender, EventArgs e)
        {
            if (autoThrowCaution.Checked)
            {
                parent.CautionHandlers.Add("throw", new ThrowCautionHandler());
            }
            else
            {
                parent.CautionHandlers.Remove("throw");
            }

            Properties.Settings.Default.autoThrowCaution = autoThrowCaution.Checked;
            Properties.Settings.Default.Save();
        }

        private void LastLaps_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastLaps = (int)lastLaps.Value;
            Properties.Settings.Default.Save();
        }

        private void LastMinutes_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastMinutes = (int)lastMinutes.Value;
            Properties.Settings.Default.Save();
        }

		private void SettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
            Properties.Settings.Default.Save();
            this.parent.SettingsChanged();
            parent.ApplyIncidentTableColorHighlighting(null);
        }

		private void highlight4xIncidentsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
            if(highlight4xIncidentsCheckBox.Checked)
			{
                highlight4xIncidentsColorPanel.Enabled = true;
                highlight4xIncidentsColorPanel.BackColor = Properties.Settings.Default.highlight4xIncidentsSelectedColor;
            }
            else
			{
                highlight4xIncidentsColorPanel.Enabled = false;
                highlight4xIncidentsColorPanel.BackColor = System.Drawing.Color.Transparent;
            }

            Properties.Settings.Default.highlight4xIncidents = highlight4xIncidentsCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

		private void highlightIncidentThatTriggeredCautionCheckBox_CheckedChanged(object sender, EventArgs e)
		{
            if(highlightIncidentThatTriggeredCautionCheckBox.Checked)
			{
                highlightCautionIncidentColorPanel.Enabled = true;
                highlightCautionIncidentColorPanel.BackColor = Properties.Settings.Default.highlightCautionIncidentSelectedColor;
            }
            else
			{
                highlightCautionIncidentColorPanel.Enabled = false;
                highlightCautionIncidentColorPanel.BackColor = System.Drawing.Color.Transparent;
            }

            Properties.Settings.Default.highlightIncidentThatTriggeredCaution = highlightIncidentThatTriggeredCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

		private void highlightDriverIfIncidentThresholdCheckBox_CheckedChanged(object sender, EventArgs e)
		{
            if (highlightDriverIfIncidentThresholdCheckBox.Checked)
			{
                driverIncidentThresholdSelectedColorPanel.BackColor = Properties.Settings.Default.driverIncidentThresholdSelectedColor;

                driverIncidentThresholdLabel.Enabled = true;
                driverIncidentThresholdNumericSelector.Enabled = true;
                driverIncidentThresholdSelectedColorPanel.Enabled = true;
                driverIncidentThresholdSelectedColorPanel.BackColor = Properties.Settings.Default.driverIncidentThresholdSelectedColor;
            }
            else
			{
                driverIncidentThresholdSelectedColorPanel.BackColor = System.Drawing.Color.Transparent;
                driverIncidentThresholdLabel.Enabled = false;
                driverIncidentThresholdNumericSelector.Enabled = false;
                driverIncidentThresholdSelectedColorPanel.Enabled = false;
            }

            Properties.Settings.Default.highlightDriverIfIncidentThreshold = highlightDriverIfIncidentThresholdCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

		private void driverIncidentThresholdSelectedColorPanel_Click(object sender, EventArgs e)
		{
            driverIncidentThresholdColorDialog.ShowDialog();
            Properties.Settings.Default.driverIncidentThresholdSelectedColor = driverIncidentThresholdColorDialog.Color;
            driverIncidentThresholdSelectedColorPanel.BackColor = Properties.Settings.Default.driverIncidentThresholdSelectedColor;
            Properties.Settings.Default.Save();
        }

		private void driverIncidentThresholdNumericSelector_ValueChanged(object sender, EventArgs e)
		{
            Properties.Settings.Default.highlightDriverIncidentThreshold = (int)driverIncidentThresholdNumericSelector.Value;
            Properties.Settings.Default.Save();
        }

		private void driverIncidentThresholdSelectedColorPanel_MouseDown(object sender, MouseEventArgs e)
		{
            driverIncidentThresholdSelectedColorPanel.BorderStyle = BorderStyle.Fixed3D;
        }

		private void driverIncidentThresholdSelectedColorPanel_MouseUp(object sender, MouseEventArgs e)
		{
            driverIncidentThresholdSelectedColorPanel.BorderStyle = BorderStyle.FixedSingle;
        }

		private void highlight4xIncidentsColorPanel_Click(object sender, EventArgs e)
		{
            highlight4xIncidentsColorDialog.ShowDialog();
            Properties.Settings.Default.highlight4xIncidentsSelectedColor = highlight4xIncidentsColorDialog.Color;
            highlight4xIncidentsColorPanel.BackColor = Properties.Settings.Default.highlight4xIncidentsSelectedColor;
            Properties.Settings.Default.Save();
        }

		private void highlight4xIncidentsColorPanel_MouseDown(object sender, MouseEventArgs e)
		{
           highlight4xIncidentsColorPanel.BorderStyle = BorderStyle.Fixed3D;
        }

		private void highlight4xIncidentsColorPanel_MouseUp(object sender, MouseEventArgs e)
		{
            highlight4xIncidentsColorPanel.BorderStyle = BorderStyle.FixedSingle;
        }

		private void highlightCautionIncidentColorPanel_Click(object sender, EventArgs e)
		{
            highlightCautionIncidentColorDialog.ShowDialog();
            Properties.Settings.Default.highlightCautionIncidentSelectedColor = highlightCautionIncidentColorDialog.Color;
            highlightCautionIncidentColorPanel.BackColor = Properties.Settings.Default.highlightCautionIncidentSelectedColor;
            Properties.Settings.Default.Save();
        }

		private void highlightCautionIncidentColorPanel_MouseDown(object sender, MouseEventArgs e)
		{
            highlightCautionIncidentColorPanel.BorderStyle = BorderStyle.Fixed3D;
		}

		private void highlightCautionIncidentColorPanel_MouseUp(object sender, MouseEventArgs e)
		{
            highlightCautionIncidentColorPanel.BorderStyle = BorderStyle.FixedSingle;
        }
	}
}
