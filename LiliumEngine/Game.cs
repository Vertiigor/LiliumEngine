using LiliumEngine.Basics;
using LiliumEngine.UI;
using SFML.Graphics;
using SFML.Window;

namespace LiliumEngine
{
    /// <summary>
    /// The main class responsible for initializing and starting the game.
    /// Contains a list of scenes between which the transition is possible during the game.
    /// </summary>
    public class Game
    {
        private const int WindowWidth = 1920;
        private const int WindowHeight = 1080;
        private Basics.Timer timer;
        private ContextSettings contextSettings;

        /// <summary>
        /// The window where all game content will be displayed. Expands to full screen.
        /// </summary>
        public RenderWindow Window { get; set; }

        /// <summary>
        /// Font applied to all UI elements that have text.
        /// </summary>
        public static Font? GameFont { get; set; }

        /// <summary>
        /// The color of the main elements: the text of the dialogues of the characters, the buttons for selecting the player.
        /// </summary>
        public ColorUI MainColor { get; set; }

        /// <summary>
        /// All registered game's scenes.
        /// </summary>
        public Dictionary<string, Scene> Scenes { get; set; }

        /// <summary>
        /// Current updating game scene.
        /// </summary>
        public Scene? CurrentScene { get; set; }

        /// <summary>
        /// Initializes the current game session. Initializes the list of scenes, the game window.
        /// Defines the game font, the main color.
        /// Sets the current scene as the "Menu", and the main one as the "MainScene"
        /// </summary>
        /// <param name="title">Name of the game.</param>
        /// <param name="fontPath">Path as font file.</param>
        /// <param name="color">Game's main color.</param>
        public Game(string title, string fontPath, ColorUI color)
        {
            MainColor = color;

            this.timer = new Basics.Timer(16.6f);

            this.contextSettings = new ContextSettings(1, 1, 8);

            GameFont = new Font(fontPath);

            Window = new RenderWindow(new SFML.Window.VideoMode(WindowWidth, WindowHeight), title, SFML.Window.Styles.Fullscreen, contextSettings);

            Window.Closed += Close;
            Window.SetKeyRepeatEnabled(false);

            Scenes = new Dictionary<string, Scene>();

            Scene menu = new Scene(this, "Menu", Array.Empty<ElementUI>());
            Scene main = new Scene(this, "MainScene", Array.Empty<ElementUI>());
            CurrentScene = menu;
        }

        public void AddElementsUI(string sceneName, params ElementUI[] elements)
        {
            foreach (var element in elements)
            {
                Scenes[sceneName].UIelementsToAdd.Add(element);
            }
        }

        /// <summary>
        /// Starts game session.
        /// Clicking the Esc button will close the window.
        /// </summary>
        public void Run()
        {
            timer.Start();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear(SFML.Graphics.Color.Black);

                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    Close(this, new EventArgs());
                }

                if (timer.Ticked)
                {
                    CurrentScene?.Update(Window); // updating the current scene every certain period of time
                }

                CurrentScene?.Draw(Window);

                Window.Display();
            }
        }

        public void Close(object? sender, EventArgs e)
        {
            this.Window.Close();
            Environment.Exit(Environment.ExitCode);
        }
    }
}
