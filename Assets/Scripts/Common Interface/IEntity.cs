using LTK268.Utils;

namespace LTK268.Interface
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
        // int AttackRange { get; set; }
        EntityType EntityType { get; set; }
    }

    public interface IEntityControl
    {
        /// <summary>
        /// Play attack 
        /// </summary>
        void Attack();
        /// <summary>
        /// Handle logic for getting damage
        /// </summary>
        /// <param name="amount"></param>
        void TakeDamage(int amount);
        /// <summary>
        /// Heal current player
        /// </summary>
        /// <param name="amount"></param>
        void Heal(int amount);
        /// <summary>
        /// Upgrade player model
        /// </summary>
        void LevelUp();
    }

    public interface IEntityCommonChecking
    {
        /// <summary>
        /// Check if current entity is  NPC
        /// </summary>
        /// <returns></returns>
        public bool IsNpc();
        /// <summary>
        /// Check if current entity is Player
        /// </summary>
        /// <returns></returns>
        public bool IsPlayer();
        /// <summary>
        /// Check if current entity is Object
        /// </summary>
        /// <returns></returns>
        public bool IsObject();

        /// <summary>
        /// Check if current entity is Object
        /// </summary>
        /// <returns></returns>
        public bool IsBuilding();
    }

    public interface IEntity : IEntityModel, IEntityControl, IEntityCommonChecking
    {
        // This interface combines both IEntityModel and IEntityControl,
        // allowing for a single interface to manage entity data and behavior.
        /// <summary>
        /// Method to interact with other entities.
        /// <param name="target">The target entity to interact with.</param>
        /// </summary>
        void InteractWithEntity(IEntity target);

        /// <summary>
        /// Method to handle interaction with an entity.
        /// </summary>
        ///    <param name="target">The target entity to interact with.</param>
        void OnInteractedByEntity(IEntity target);

    }
}