using SFML.Graphics;

namespace LiliumEngine.Basics
{
    /// <summary>
    /// Interface defining an object that can be updated.
    /// </summary>
    public interface IUpdatable
    {
        public void Update(RenderTarget target);
    }
}
