namespace LiliumEngine.UI
{
    /// <summary>
    /// Interface defining an object that can clicked.
    /// </summary>
    public interface IClickable
    {
        public event ElementUIHandler? Click; // click event
        public event ElementUIHandler? Aimed; // hover event on the object with the mouse cursor.
    }
}
