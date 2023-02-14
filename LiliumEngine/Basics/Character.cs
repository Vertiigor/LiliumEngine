namespace LiliumEngine.Basics
{
    /// <summary>
    /// A class intended for the basic functions of a character in a novel.
    /// </summary>
    public class Character
    {
        private Game targetGame;
        private string name;

        /// <summary>
        /// Initializes a story character.
        /// </summary>
        /// <param name="targetGame">The object of the game to which Character is attached.</param>
        /// <param name="name">Character's name.</param>
        public Character(Game targetGame, string name)
        {
            this.targetGame = targetGame;
            this.name = name;
        }

        /// <summary>
        /// Displays text from the name of the character in the form {name: message}.
        /// </summary>
        /// <param name="message">Character's message.</param>
        public void Say(string message)
        {
            targetGame.Scenes["Main"].Dialog.Actions.Enqueue(() =>
            {
                string temp = $"{name}: \"";
                message += "\"";

                foreach (var symbol in message)
                {
                    temp += symbol;
                    targetGame.Scenes["Main"].Text.Text = temp;
                    Thread.Sleep(30);
                }
            });
        }
    }
}
