using System;

namespace LTK268.Utils
{
    /// <summary>
    /// Enumeration for different types of entities in the game.
    /// </summary>
    [Serializable]
    public enum EntityType
    {
        None = 0,
        Player = 1,
        NPC = 2,
        Enemy = 3,
        Object = 4,
        Animal = 5,
        Building = 6,
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
        Food = 6,
    }

    public enum BuildingType
    {
        None = 0,
        Base = 1,
        NormalHouse = 2,
    }

    public enum BuildingSize
    {
        None = 0,
        Size_1X1 = 1,
        Size_1X2 = 2,
        Size_2X1 = 3,
        Size_2X2 = 4,
        Size_1X3 = 5,
        Size_2X3 = 6,
        Size_3X1 = 7,
        Size_3X2 = 8,
        Size_3X3 = 9,

    }

    public enum BuildingState
    {
        None = 0,
        Blueprint = 1,
        Building = 2,
        Destroyed = 3,
        Complete = 4,
    }

    public enum ResourceType
    {
        None = 0,
        Wood = 1,
        Stone = 2,
        Iron = 3,
        Food = 4,
        Gold = 5,
        Blueprint = 6,
        Sword = 7,
    }
    #endregion

}