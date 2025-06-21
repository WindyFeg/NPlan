namespace LKT268.Utils
{
    /// <summary>
    /// Enumeration for different types of entities in the game.
    /// </summary>
    public enum EntityType
    {
        None = 0,
        Player = 1,
        NPC = 2,
        Enemy = 3,
        Object = 4,
    }

    #region NPC
    /// <summary>
    /// Enumeration for different types of NPCs (Non-Player Characters).
    /// </summary>
    public enum NPCType
    {
        Sickness = 0,
        Function = 1,
        Warrior = 2,
        Jobless = 3,
    }

    /// <summary>
    /// Enumeration for different function jobs that NPCs can perform.
    /// </summary>
    public enum NPCFunctionType
    {
        None = 0,
        Lumber = 1,
        Builder = 2,
        Farmer = 3,
        Blacksmith = 4,
        Healer = 5,
        Miner = 6,
    }

    /// <summary>
    /// Enumeration for different types of NPC soldiers.
    /// </summary>
    public enum NPCWarriorType
    {
        None = 0,
        Archer = 1,
        Warrior = 2,
    }

    #endregion

    /// <summary>
    /// Enumeration for different types of objects in the game.
    /// </summary>
    #region Object
    public enum ObjectType
    {
        None = 0,
        House = 1,
        PickableObject = 2,
        NonPickableObject = 3,
        Resource = 4,
        Weapon = 5,
    }
    #endregion

}