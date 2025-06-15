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
    }

    public interface IEntityControl
    {
        void TakeDamage(int amount);
        void Heal(int amount);
        void LevelUp();
    }

    public interface IEntity : IEntityModel, IEntityControl
    {
        // This interface combines both IEntityModel and IEntityControl,
        // allowing for a single interface to manage entity data and behavior.
    }
}