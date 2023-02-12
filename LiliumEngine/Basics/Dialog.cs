using SFML.Graphics;
using SFML.Window;

namespace LiliumEngine.Basics
{
    /// <summary>
    /// A class whose object contains events that are executed one by one
    /// </summary>
    public class Dialog : IUpdatable
    {
        public enum DialogState
        {
            Running,
            Stopped
        }
        public Queue<Action> Actions { get; set; }
        public DialogState State { get; set; }

        public Dialog()
        {
            Actions = new Queue<Action>();
            this.State = DialogState.Running;
        }
        public void Update(RenderTarget target)
        {
            Timer timer = new Timer(1000);
            timer.Start();

            while (true)
            {
                if ((Keyboard.IsKeyPressed(Keyboard.Key.Enter) || Keyboard.IsKeyPressed(Keyboard.Key.Space)) && State == DialogState.Running)
                {
                    if (timer.Ticked && Actions.Count > 0)
                    {
                        Actions.Dequeue()?.Invoke();
                    }
                }
            }
        }
    }
}
