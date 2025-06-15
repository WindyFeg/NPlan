namespace LKT268.Interface
{
    /// <summary>
    /// Interface for human control, extending IEntityControl.
    /// </summary>
    public interface IHumanControl : IEntityControl
    {
        /// <summary>
        /// Method to interact with other entities.
        /// </summary>
        /// <param name="target">The target entity to interact with.</param>
        void InteractWithEntity(IEntity target);

        /// <summary>
        /// Method to interact with objects in the game world.
        /// </summary>
        /// <param name="target">The target object to interact with.</param>
        void InteractWithObject(IEntity target);

        /// <summary>
        /// Method to handle interaction with an entity.
        /// </summary>
        ///    <param name="target">The target entity to interact with.</param>
        void OnInteractedByEntity(IEntity target);

        /// <summary>
        /// Method to handle interaction with an object.
        /// </summary>
        /// <param name="target">The target object to interact with.</param>
        void OnInteractedByObject(IEntity target);
    }
}