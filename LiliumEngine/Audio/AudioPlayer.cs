using SFML.Audio;

namespace LiliumEngine.Audio
{
    /// <summary>
    /// A class intended for the basic functions of an audio in a novel.
    /// </summary>
    public class AudioPlayer
    {
        private static Music? currentMusic;
        private Game targetGame;
        
        /// <summary>
        /// Initializes an audio player.
        /// </summary>
        /// <param name="targetGame">The object of the game to which AudioPlayer is attached.</param>
        public AudioPlayer(Game targetGame)
        {
            this.targetGame = targetGame;
        }

        /// <summary>
        /// Plays msuic.Supports formats: WAV, OGG/Vorbis and FLAC.
        /// </summary>
        /// <param name="path">Music file path.</param>
        /// <param name="volume">Music volume value.</param>
        /// <param name="looped">Is it looped.</param>
        public void PlayMusic(string path, int volume, bool looped=false)
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                currentMusic = new Music(path);
                currentMusic.Volume = volume;
                currentMusic.Loop = looped;
                currentMusic.Play();
            });
        }

        /// <summary>
        /// Stops current music.
        /// </summary>
        public void StopMusic()
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                currentMusic?.Stop();
            });
        }
    }
}
