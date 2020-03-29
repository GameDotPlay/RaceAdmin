using System.Threading;

namespace RaceAdmin
{
    /// <summary>
    /// A caution handler that plays a sound when notified that the caution threshold
    /// has been reached.
    /// </summary>
    public class AudioCautionHandler : ICautionHandler
    {
        private ISoundPlayer player;
        private Timer timer;

        /// <summary>
        /// The number of times to repeat the sound. The default is one time.
        /// </summary>
        public uint Repeat { get; set; } = 1;

        /// <summary>
        /// The interval in milliseconds at which the sound will be played
        /// when Repeat is greater than zero. Defaults to 1000 ms.
        /// </summary>
        public uint Interval { get; set; } = 1000;

        /// <summary>
        /// Constructs a new AudioCautionHandler which will use the supplied
        /// ISoundPlayer to play the caution threshold sound.
        /// </summary>
        /// <param name="player">the player used to actually play the sound</param>
        public AudioCautionHandler(ISoundPlayer player)
        {
            this.player = player;
        }

        /// <summary>
        /// Plays the caution sound. The sound is repeated at the configured interval.
        /// </summary>
        public void CautionThresholdReached()
        {
            var count = 0;
            timer = new Timer(
                callback: new TimerCallback(o =>
                {
                    if (count++ < Repeat)
                    {
                        player.Play();
                    }
                }),
                state: null,
                dueTime: 0,
                period: Interval);
        }

        /// <summary>
        /// Stops the caution sound from playing (if it is still repeating).
        /// </summary>
        public void YellowFlagThrown()
        {
            var handle = new ManualResetEvent(false);
            timer.Dispose(handle);
            handle.WaitOne();
            handle.Dispose();
        }

        /// <summary>
        /// This implementation does nothing.
        /// </summary>
        public void GreenFlagThrown()
        {
            // nothing to do
        }

    }
}
