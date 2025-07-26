using System;
using Unity.Behavior;

namespace LTK268.Enemy
{
    [Serializable]
    public enum EnemyType
    {
        None = 0,
        Wolf = 1,
        Boss = 51,
    }

    #region Blackboard

    [BlackboardEnum]
    public enum EnemyState
    {
        Idle,
        Hit,
        Attack,
        Dead
    }
    
    [BlackboardEnum]
    public enum EnemyCombatState
    {
        Chase,
        Attack,
        Retreat
    }
    
    #endregion

}