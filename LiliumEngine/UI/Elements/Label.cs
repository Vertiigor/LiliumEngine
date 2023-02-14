using SFML.Graphics;
using SFML.System;

namespace LiliumEngine.UI.Elements
{
    /// <summary>
    /// The UI class of the element, which is responsible for defining the text and modifying it.
    /// </summary>
    public class Label : ElementUI
    {
        private Text? text;
        private string? value;
        private Color color;
        private Font? font;

        /// <summary>
        /// Size of each character.
        /// </summary>
        public uint CharSize { get; set; }

        /// <summary>
        /// Property that sets a text value and returns it.
        /// </summary>
        public string? Text
        {
            get => this.value;
            set
            {
                this.value = value;
                this.text = new Text(value, font, CharSize);
                this.text.Position = new Vector2f(Origin.X, Origin.Y);
                this.text.FillColor = this.color;
            }
        }

        /// <summary>
        /// Constructor that sets the basic necessary parameters for the Label and initialize it.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="text">Text to be displayed.</param>
        /// <param name="color">The color of the displayed text.</param>
        /// <param name="charSize">Size of each character.</param>
        public Label(float x, float y, string text, ColorUI color, uint charSize) : base(x, y)
        {
            this.CharSize = charSize;
            this.font = Game.GameFont;
            this.color = new Color(color.R, color.G, color.B, color.A);
            Text = text;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(text);
        }
    }
}
