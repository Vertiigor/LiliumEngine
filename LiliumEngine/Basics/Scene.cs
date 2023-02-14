using LiliumEngine.UI;
using LiliumEngine.UI.Elements;
using SFML.Graphics;

namespace LiliumEngine.Basics
{
    /// <summary>
    /// A class that object stores the main UI elements, dialog and updates them.
    /// </summary>
    public class Scene : IUpdatable
    {
        private Thread dialogUpdateThread;
        private string name;

        /// <summary>
        /// All UI element on scene.
        /// </summary>
        public List<ElementUI> UIelements { get; set; }

        /// <summary>
        /// UI elements that will be removed from the next scene rendering frame.
        /// </summary>
        public List<ElementUI> UIelementsToRemove { get; set; }

        /// <summary>
        /// UI elements that will be added on the next scene rendering frame.
        /// </summary>
        public List<ElementUI> UIelementsToAdd { get; set; }

        /// <summary>
        /// Dialogue text on the bottom of the scene.
        /// </summary>
        public Label Text { get; set; }

        /// <summary>
        /// Illustration displayed at coordinate (0, 0).
        /// </summary>
        public ImageBox Illustration { get; set; }

        /// <summary>
        /// A dialogue containing a set of main events, such as a character's line. Updated in a separate thread.
        /// </summary>
        public Dialog Dialog { get; set; }

        /// <summary>
        /// Initializes an object of the Scene class.
        /// </summary>
        /// <param name="game">The object of the game to which Scene is attached.</param>
        /// <param name="name">Scene's name.</param>
        /// <param name="elemnts">UI elements to be added to the scene.</param>
        public Scene(Game game, string name, ElementUI[] elemnts)
        {
            Illustration = new ImageBox(0, 0);

            Text = new Label(30, 780, "", game.MainColor, 35);

            Dialog = new Dialog();

            dialogUpdateThread = new Thread(() => Dialog.Update(game.Window));

            this.name = name;

            this.UIelements = new List<ElementUI>(elemnts) { Text, Illustration };
            this.UIelementsToRemove = new List<ElementUI>();
            this.UIelementsToAdd = new List<ElementUI>();

            game?.Scenes?.Add(name, this);
        }

        public void Update(RenderTarget target)
        {
            if (dialogUpdateThread.ThreadState == ThreadState.Unstarted)
            {
                dialogUpdateThread.Start();
            }

            foreach (ElementUI element in UIelements)
            {
                element.Update(target);
            }

            foreach (var addableObject in UIelementsToAdd)
            {
                UIelements.Add(addableObject);
            }

            UIelementsToAdd.Clear();

            foreach (var removableObject in UIelementsToRemove)
            {
                UIelements.Remove(removableObject);
            }
        }

        public void Draw(RenderTarget target)
        {
            foreach (ElementUI element in UIelements)
            {
                target.Draw(element);
            }
        }
    }
}
