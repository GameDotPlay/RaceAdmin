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
            incidentsRequiredForCaution.Value = Properties.Settings.Default.incidentsRequired;
            audioNotification.Checked = Properties.Settings.Default.audioNotification;
            autoThrowCaution.Checked = Properties.Settings.Default.autoThrowCaution;
            lastLaps.Value = Properties.Settings.Default.lastLaps;
            lastMinutes.Value = Properties.Settings.Default.lastMinutes;
            incidentsRequiredForCaution.Value = Properties.Settings.Default.incidentsRequired;

            // General settings
            hideIncidents.Checked = Properties.Settings.Default.hideIncidents;
        }

        private void DetectTowForCaution_CheckChanged(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.detectTowForCaution = detectTowForCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void UseTotalIncidentsForCaution_CheckChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useTotalIncidentsForCaution = useTotalIncidentsForCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void HideIncidents_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hideIncidents = hideIncidents.Checked;
            Properties.Settings.Default.Save();
        }

        private void IncidentsRequired_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.incidentsRequired = (int)incidentsRequiredForCaution.Value;
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

                RaceAdminMain.CautionHandlers.Add("audio", handler);
            }
            else
            {
                RaceAdminMain.CautionHandlers.Remove("audio");
            }

            Properties.Settings.Default.audioNotification = audioNotification.Checked;
            Properties.Settings.Default.Save();
        }

        private void AutoThrowCaution_CheckedChanged(object sender, EventArgs e)
        {
            if (autoThrowCaution.Checked)
            {
                RaceAdminMain.CautionHandlers.Add("throw", new ThrowCautionHandler());
            }
            else
            {
                RaceAdminMain.CautionHandlers.Remove("throw");
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
            this.parent.SettingsChanged();
		}
	}
}
