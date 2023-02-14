using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace LiliumEngine.UI.Elements
{
    /// <summary>
    /// The UI class of the element, which is responsible for defining the Button and modifying it.
    /// </summary>
    public class Button : ElementUI, IClickable
    {
        private RectangleShape area;
        private ColorUI originalColor;
        private Vector2f size;
        private Text Text;
        
        public event ElementUIHandler? Click;
        public event ElementUIHandler? Aimed;

        /// <summary>
        /// Constructor that sets the basic necessary parameters for the Button and initialize it.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="text">Text of button.</param>
        /// <param name="color">Color of button.</param>
        /// <param name="charSize">Size of each character.</param>
        public Button(float x, float y, string text, ColorUI color, uint charSize) : base(x, y)
        {
            Text = new Text(text, Game.GameFont, charSize);
            Text.FillColor = new Color(color.R, color.G, color.B, color.A);
            Text.Position = new Vector2f(x + Text.CharacterSize, y + Text.CharacterSize / 4); // align the text in the middle of the button

            this.size = new Vector2f(text.Length * Text.CharacterSize + Text.CharacterSize, Text.CharacterSize * 2); // determine button size

            this.area = new RectangleShape(size);
            this.area.OutlineThickness = 4;
            this.area.OutlineColor = new Color(color.R, color.G, color.B, color.A);
            this.area.Position = new Vector2f(x, y);
            this.area.FillColor = new Color(0, 0, 0, 0);

            this.originalColor = color;
        }

        public override void Update(RenderTarget target)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && area.GetGlobalBounds().Contains(Mouse.GetPosition((Window)target).X, Mouse.GetPosition((Window)target).Y))
            {
                Click?.Invoke(this, new ElementUIEventArgs("Clicked"));
            }
            if (area.GetGlobalBounds().Contains(Mouse.GetPosition((Window)target).X, Mouse.GetPosition((Window)target).Y))
            {
                this.area.OutlineColor = new Color(0, 0, 0, 0);
                Aimed?.Invoke(this, new ElementUIEventArgs("Button_Aimed"));
            }
            else
            {
                this.area.OutlineColor = new Color(originalColor.R, originalColor.G, originalColor.B, originalColor.A);
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(area);
            target.Draw(Text);
        }
    }
}
