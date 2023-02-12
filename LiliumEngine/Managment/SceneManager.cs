namespace LiliumEngine.Managment
{
    /// <summary>
    /// A class designed to switch between scenes.
    /// </summary>
    public static class SceneManager
    {
        /// <summary>
        /// Loads scene that was registered.
        /// </summary>
        /// <param name="game">Current game.</param>
        /// <param name="sceneName">Scene's name.</param>
        public static void LoadScene(Game game, string sceneName)
        {
            game.CurrentScene = game?.Scenes?.First(s => s.Key.Contains(sceneName)).Value;
        }
    }
}
