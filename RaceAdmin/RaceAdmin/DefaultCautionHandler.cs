using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RaceAdmin
{
    /// <summary>
    /// Provides default caution handling by flashing the provided cautionPanel.
    /// Alternating colors provided via the Properties of the RaceAdmin project.
    /// The colors used are configured under the following properties:
    ///     normal/default: RaceAdmin.Properties.Resources.ColorName_Control
    ///     yellow/caution: RaceAdmin.Properties.Resources.ColorName_Gold
    /// </summary>
    public class DefaultCautionHandler : ICautionHandler
    {
        private static readonly Color control, gold;

        private System.Threading.Timer timer;

        private Panel cautionPanel;

        /// <summary>
        /// The interval at which the panel's colors are alternated. Defaults to 500 ms.
        /// </summary>
        public uint Interval { get; set; } = 500; // ms

        static DefaultCautionHandler()
        {
            control = Color.FromName("Control");
            gold = Color.Yellow;
        }

        /// <summary>
        /// Constructs a new DefaultCautionHandler which will use the provided
        /// panel to visually notify the user when the caution threshold has 
        /// been reached.
        /// </summary>
        /// <param name="cautionPanel">the panel used to provide visual notifications</param>
        public DefaultCautionHandler(Panel cautionPanel)
        {
            this.cautionPanel = cautionPanel;
        }

        /// <summary>
        /// Flashes the caution panel. The panel will continue to flash until a green
        /// flag is detected.
        /// </summary>
        public void CautionThresholdReached()
        {
            // start a timer to flash the caution panel
            timer = new System.Threading.Timer(
                callback: new System.Threading.TimerCallback(o =>
                {
                    cautionPanel.BackColor = NextColor(cautionPanel.BackColor);
                }),
                state: null,
                dueTime: 0,
                period: Interval);
        }

        private static Color NextColor(Color current)
        {
            return current == control ? gold : control;
        }

        /// <summary>
        /// This implementation does nothing.
        /// </summary>
        public void YellowFlagThrown()
        {
            // nothing to do
        }

        /// <summary>
        /// Stops flashing the caution panel and resets the panel to the configured
        /// background color.
        /// </summary>
        public void GreenFlagThrown()
        {
            // stop the timer and wait for for any in-progress callbacks
            var handle = new ManualResetEvent(false);
            timer.Dispose(handle);
            handle.WaitOne();
            handle.Dispose();

            // reset panel to original color
            cautionPanel.BackColor = control;
        }

    }

}