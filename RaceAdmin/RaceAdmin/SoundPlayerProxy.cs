using System.Media;

namespace RaceAdmin
{
    internal class SoundPlayerProxy : ISoundPlayer
    {
        private SoundPlayer player;

        public SoundPlayerProxy(SoundPlayer player)
        {
            this.player = player;
        }

        public void Play()
        {
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}