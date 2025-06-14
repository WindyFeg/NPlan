namespace LKT268.Utils
{
    /// <summary>
    /// Enumeration for different types of entities in the game.
    /// </summary>
    public enum EntityType
    {
        None = -1,
        Player = 0,
        NPC = 1,
        Enemy = 2,
    }

    #region NPC
    /// <summary>
    /// Enumeration for different types of NPCs (Non-Player Characters).
    /// </summary>
    public enum NPCType
    {
        Jobless = -1,
        Function = 0,
        Warrior = 1,
    }

    /// <summary>
    /// Enumeration for different function jobs that NPCs can perform.
    /// </summary>
    public enum NPCFunctionType
    {
        None = -1,
        Lumber = 0,
        Miner = 1,
        Builder = 2,
        Farmer = 3,
        Blacksmith = 4,
        Healer = 5,
    }

    /// <summary>
    /// Enumeration for different types of NPC soldiers.
    /// </summary>
    public enum NPCWarriorType
    {
        None = -1,
        Archer = 0,
        Warrior = 1,
    }
    #endregion

}