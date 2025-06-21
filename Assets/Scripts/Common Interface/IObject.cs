namespace LKT268.Interface
{
    /// <summary>
    /// Interface for objects that can be interacted with in the game.
    /// </summary>
    public interface IObject : IHuman
    {
        /// <summary>
        /// This current Object will be spawn
        /// </summary>
        void Spawn();

        /// <summary>
        /// This current Object will be destroy (Not public)
        /// </summary>
        void Destroy();
    }
}