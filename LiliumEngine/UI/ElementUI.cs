using LiliumEngine.Basics;
using SFML.Graphics;

namespace LiliumEngine.UI
{
    public delegate void ElementUIHandler(object sender, EventArgs e);

    /// <summary>
    /// An abstract class that describes the main functionality of each UI element.
    /// </summary>
    public abstract class ElementUI : IUpdatable, Drawable
    {
        /// <summary>
        /// The location of the element on the coordinate plane.
        /// </summary>
        public Point Origin { get; protected set; }

        /// <summary>
        /// Constructor applied to all descendants, defines the starting point.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        public ElementUI(float x, float y)
        {
            Origin = new Point(x, y);
        }

        /// <summary>
        /// Draws an object.
        /// </summary>
        /// <param name="target">Object that will render the UI object.</param>
        /// <param name="states">Define the states used to draw.</param>
        public virtual void Draw(RenderTarget target, RenderStates states) { }

        /// <summary>
        /// Updates the state of an object.
        /// </summary>
        /// <param name="target">Object that will render the UI object.</param>
        public virtual void Update(RenderTarget target) { }
    }
}
