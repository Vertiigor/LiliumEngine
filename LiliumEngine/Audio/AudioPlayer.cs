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
        /// Volume value from 0 (muted) to 100 (maximum value).
        /// </summary>
        public int Volume
        {
            get => (int)currentMusic.Volume;
            set => currentMusic.Volume = value <= 100 && value >= 0 ? value : throw new ArgumentException("Value must be between 0 and 100.");
        }

        /// <summary>
        /// A flag that determines whether the music will be played again after the end.
        /// </summary>
        public bool Loop
        {
            get => currentMusic.Loop;
            set => currentMusic.Loop = value;
        }
        
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
        public void PlayMusic(string path)
        {
            targetGame.Scenes["MainScene"].Dialog.Actions.Enqueue(() =>
            {
                currentMusic = new Music(path);
                currentMusic.Play();
            });
        }

        /// <summary>
        /// Stops current music.
        /// </summary>
        public void StopMusic()
        {
            targetGame.Scenes["MainScene"].Dialog.Actions.Enqueue(() =>
            {
                currentMusic?.Stop();
            });
        }
    }
}
