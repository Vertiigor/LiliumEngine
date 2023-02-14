using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace LiliumEngine.UI.Elements
{
    /// <summary>
    /// The UI class of the element, which is responsible for defining the CheckBox and modifying it.
    /// </summary>
    public class CheckBox : ElementUI, IClickable
    {
        private RectangleShape border, isChecked;
        private bool value, selected;
        private string text;
        private RectangleShape area;
        private Vector2f size;
        private Text Text;

        public event ElementUIHandler? Click;
        public event ElementUIHandler? Aimed;

        /// <summary>
        /// Property that sets a bool value and returns it.
        /// </summary>
        public bool Value
        {
            get => this.value;
            set
            {
                this.value = value;

                isChecked.FillColor = Value == true ? Color.White : new Color(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Constructor that sets the basic necessary parameters for the CheckBox and initialize it.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="text">Text displayed to the right of the checkmark.</param>
        /// <param name="color">The color of the displayed text.</param>
        /// <param name="charSize">Size of each character.</param>
        /// <param name="value">Bool value. Equals False by default.</param>
        public CheckBox(float x, float y, string text, ColorUI color, uint charSize, bool value = false) : base(x, y)
        {
            this.border = new RectangleShape(new Vector2f(50, 50));
            this.border.FillColor = new Color(0, 0, 0, 0);
            this.border.OutlineThickness = 2;
            this.border.OutlineColor = new Color(102, 102, 102, 255);
            this.border.Position = new Vector2f(x, y);

            this.isChecked = new RectangleShape(new Vector2f(50, 50));
            this.isChecked.FillColor = new Color(0, 0, 0, 0);
            this.isChecked.Position = new Vector2f(x, y);

            this.text = text;
            
            Value = value;

            Text = new Text(text, Game.GameFont, charSize);
            Text.Position = new Vector2f(Origin.X + 60, Origin.Y);
            Text.FillColor = new Color(color.R, color.G, color.B, color.A);

            this.size = new Vector2f(text.Length * Text.CharacterSize + Text.CharacterSize, Text.CharacterSize * 2); // determine button size

            this.area = new RectangleShape(size);
        }
        public override void Update(RenderTarget target)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && area.GetGlobalBounds().Contains(Mouse.GetPosition((Window)target).X, Mouse.GetPosition((Window)target).Y) && selected == false)
            {
                Value = !Value;
                Click?.Invoke(this, new ElementUIEventArgs("Clicked"));
                selected = true;
            }
            if (area.GetGlobalBounds().Contains(Mouse.GetPosition((Window)target).X, Mouse.GetPosition((Window)target).Y))
            {
                border.OutlineColor = Color.Cyan;
                Aimed?.Invoke(this, new ElementUIEventArgs("CheckBox_Aimed"));
            }
            else
            {
                border.OutlineColor = new Color(102, 102, 102, 255);
                selected = false;
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(isChecked);
            target.Draw(border);
            target.Draw(Text);
        }

    }
}
