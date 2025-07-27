namespace LTK268.Interface
{
    /// <summary>
    /// Interface for objects that can be interacted with in the game.
    /// </summary>
    public interface IObject : IEntity
    {
        /// <summary>
        /// This current Object will be spawn
        /// </summary>
        void Spawn();

        /// <summary>
        /// This current Object will be destroy (Not public)
        /// </summary>
        void Destroy();

        /// <summary>
        /// Use when this object belong to some entity
        /// </summary>
        void Use();

        /// <summary>
        /// use to inspect the information of the object
        /// </summary>
        void Inspect();
        /// <summary>
        /// called when player needed to pick this up
        /// </summary>
        /// <param name="entity"></param>
        void PickedUpBy(IHuman entity);
        /// <summary>
        /// Drop this current object
        /// </summary>
        /// <param name="entity"></param>
        void DroppedBy(IHuman entity);
    }
}