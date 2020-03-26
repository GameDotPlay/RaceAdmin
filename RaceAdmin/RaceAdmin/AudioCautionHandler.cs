using System;
using System.Windows.Forms;

namespace RaceAdmin
{

    public class AudioCautionHandler : ICautionHandler
    {
        private ISoundPlayer player;

        public Panel CautionPanel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AudioCautionHandler(ISoundPlayer player)
        {
            this.player = player;
        }

        public void CautionThresholdReached()
        {
            player.PlayLooping();
        }

        public void YellowFlagThrown()
        {
            player.Stop();
        }

        public void GreenFlagThrown()
        {
            // nothing to do
        }

    }
}
