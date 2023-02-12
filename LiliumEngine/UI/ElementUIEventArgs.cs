namespace LiliumEngine.UI
{
    public class ElementUIEventArgs : EventArgs
    {
        private string message { get; set; }

        public ElementUIEventArgs(string message)
        {
            this.message = message;
        }
    }
}
