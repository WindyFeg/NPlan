using LKT268.Utils;

namespace LKT268.Interface
{
    public interface IEntityModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int CurrentHealth { get; set; }
        int MaxHealth { get; set; }
        int Level { get; set; }
        int Damage { get; set; }
        int Armor { get; set; }
        EntityType EntityType { get; set; }
    }

    public interface IEntityControl
    {
        void TakeDamage(int amount);
        void Heal(int amount);
        void LevelUp();
    }

    public interface IEntityCommonChecking
    {
        public bool IsNpc();
        public bool IsPlayer();
        public bool IsObject();
    }

    public interface IEntity : IEntityModel, IEntityControl, IEntityCommonChecking
    {
        // This interface combines both IEntityModel and IEntityControl,
        // allowing for a single interface to manage entity data and behavior.
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