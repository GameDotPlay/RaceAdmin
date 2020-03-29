namespace RaceAdmin
{
    /// <summary>
    /// Provides a thin interface over System.Media.SoundPlayer.
    /// </summary>
    public interface ISoundPlayer
    {
        void Play();
        void Stop();

    }
}
