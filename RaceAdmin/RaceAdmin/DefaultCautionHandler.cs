using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RaceAdmin
{
    public class DefaultCautionHandler : ICautionHandler
    {
        private static readonly Color control, gold;

        private System.Threading.Timer timer;

        public Panel CautionPanel { get; set; }
        public uint Interval { get; set; } = 500; // ms

        static DefaultCautionHandler()
        {
            control = Color.FromName(RaceAdmin.Properties.Resources.ColorName_Control);
            gold = Color.FromName(RaceAdmin.Properties.Resources.ColorName_Gold);
        }


        public void CautionThresholdReached()
        {
            // start a timer to flash the caution panel
            timer = new System.Threading.Timer(
                callback: new System.Threading.TimerCallback(OnTick),
                state: CautionPanel,
                dueTime: 0,
                period: Interval);
        }

        private static void OnTick(object cautionPanel)
        {
            // set the panel to the next color in the rotation
            var panel = cautionPanel as Panel;
            panel.BackColor = NextColor(panel.BackColor);
        }

        private static Color NextColor(Color current)
        {
            return current == control ? gold : control;
        }

        public void YellowFlagThrown()
        {
            // nothing to do
        }

        public void GreenFlagThrown()
        {
            // stop the timer and wait for for any in-progress callbacks
            var dispose = new ManualResetEvent(false);
            timer.Dispose(dispose);
            dispose.WaitOne();
            dispose.Dispose();

            // reset panel to original color
            CautionPanel.BackColor = control;
        }

    }

}