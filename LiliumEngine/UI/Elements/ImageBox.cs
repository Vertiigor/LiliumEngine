using SFML.Graphics;
using System.Security.Cryptography.X509Certificates;

namespace LiliumEngine.UI.Elements
{
    /// <summary>
    /// The UI class of the element, which is responsible for defining the ImageBox and modifying it.
    /// </summary>
    public class ImageBox : ElementUI
    {
        private Texture? texture;
        private Sprite? sprite;

        /// <summary>
        /// Path to the file containing the image.
        /// </summary>
        public string? ImagePath { get; private set; }

        /// <summary>
        /// A property that accepts and returns a path to a file.
        /// By specifying the path to the file, the image will be loaded at this path
        /// </summary>
        public string? Image
        {
            get => ImagePath;
            set
            {
                texture = new Texture(value);
                sprite = new Sprite(texture);
                sprite.Position = new SFML.System.Vector2f(Origin.X, Origin.Y);
                ImagePath = value;
            }
        }

        /// <summary>
        /// Constructor that sets the basic necessary parameters for the ImageBox and initialize it.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="imagePath">The path where the image will be loaded.</param>
        public ImageBox(float x, float y, string imagePath) : base(x, y)
        {
            Image = imagePath;
        }

        /// <summary>
        /// Constructor that sets the basic necessary parameters for the empty ImageBox and initialize it.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        public ImageBox(float x, float y) : base(x, y) { }

        /// <summary>
        /// Loads an image from the specified file.
        /// </summary>
        /// <param name="path">Image file path.</param>
        public void LoadFrom(string path)
        {
            Image = path;
        }

        internal void LoadFromSfmlImage(Image image, string imagePath)
        {
            if (texture != null)
            {
                texture.Update(image);
                sprite.Texture = texture;
                ImagePath = imagePath;
            }
            else
            {
                texture = new Texture(image);
                sprite = new Sprite(texture);
                ImagePath = imagePath;
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (sprite != null)
                target.Draw(sprite);
        }
    }
}
