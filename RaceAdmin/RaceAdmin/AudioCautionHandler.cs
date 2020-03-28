using System.Threading;

namespace RaceAdmin
{

    public class AudioCautionHandler : ICautionHandler
    {
        private ISoundPlayer player;
        private Timer timer;

        public int Repeat { get; set; }
        public uint Interval { get; set; }

        public AudioCautionHandler(ISoundPlayer player)
        {
            this.player = player;
        }

        public void CautionThresholdReached()
        {
            var count = 0;
            timer = new Timer(
                callback: new TimerCallback((o) =>
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

        public void YellowFlagThrown()
        {
            var handle = new ManualResetEvent(false);
            timer.Dispose(handle);
            handle.WaitOne();
            handle.Dispose();
        }

        public void GreenFlagThrown()
        {
            // nothing to do
        }

    }
}
