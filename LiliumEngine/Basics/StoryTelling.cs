using LiliumEngine.UI.Elements;
using System.IO;

namespace LiliumEngine.Basics
{
    /// <summary>
    /// The class is intended for basic storytelling functions.
    /// </summary>
    public class StoryTelling
    {
        private Game targetGame;

        /// <summary>
        /// Initializes an object of the Storytelling class.
        /// </summary>
        /// <param name="targetGame">The object of the game to which Storytelling is attached.</param>
        public StoryTelling(Game targetGame)
        {
            this.targetGame = targetGame;
        }

        /// <summary>
        /// Shows the player's selection menu as a list of buttons. The text of the options is separated by the symbol "|".
        /// </summary>
        /// <param name="options">options that separated by the symbol "|".</param>
        /// <param name="actions">Lambda functions refer respectively to variants.</param>
        public void ShowMenu(string options, params Action[] actions)
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                var optionButtons = new List<Button>();
                var labels = options.Split('|');
                int i = 0;

                foreach (var action in actions)
                {
                    Button optionButton = new Button(200, i * 100 + 30, labels[i], targetGame.MainColor, 35);
                    optionButton.Click += (object sender, EventArgs e) =>
                    {
                        var newActions = new Queue<Action>();

                        while (targetGame.Scenes["Main"].Dialog.Actions.Count > 0)
                        {
                            newActions.Enqueue(targetGame.Scenes["Main"].Dialog.Actions.Dequeue());
                        }

                        targetGame.Scenes["Main"].Dialog.Actions.Clear();

                        action?.Invoke();

                        while (newActions.Count > 0)
                        {
                            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(newActions.Dequeue());
                        }

                        foreach (var button in optionButtons)
                        {
                            targetGame.Scenes["Main"].UIelementsToRemove.Add(button);
                        }

                        targetGame.Scenes["Main"].Dialog.State = Dialog.DialogState.Running;

                        targetGame.Scenes["Main"].Dialog.Actions.Dequeue()?.Invoke();
                    };

                    optionButtons.Add(optionButton);
                    i++;
                }

                foreach (var btn in optionButtons)
                {
                    targetGame.Scenes["Main"].UIelementsToAdd.Add(btn);
                }

                targetGame.Scenes["Main"].Dialog.State = Dialog.DialogState.Stopped;
            });
        }

        /// <summary>
        /// Writes the text on behalf of the author (without quotes and name).
        /// </summary>
        /// <param name="message">Text that will be shown.</param>
        public void Write(string message)
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                string temp = string.Empty;

                foreach (var symbol in message)
                {
                    temp += symbol;
                    targetGame.Scenes["Main"].Text.Text = temp;
                    Thread.Sleep(40);
                }
            });
        }

        /// <summary>
        /// Stops the dialogue for a certain number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds the dialog will be paused for.</param>
        public void WaitFor(uint seconds)
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                Thread.Sleep((int)seconds * 1000);
            });
        }

        /// <summary>
        /// Loads an illustration on scene.
        /// </summary>
        /// <param name="path">Illustration file path.</param>
        public void LoadIllustration(string path)
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                targetGame.Scenes["Main"].Illustration.Image = path;
            });
        }
    }
}
