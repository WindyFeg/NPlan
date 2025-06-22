using LKT268.BehaviourTree;
using LKT268.Enemy;

namespace LTK268.BehaviourTree.Actions
{
    /// <summary>
    /// Handles the logic for taking damage.
    /// </summary>
    public class TakeDamage : BTNode
    {
        #region Private Field

        private readonly EnemyBehaviour enemy;
        private readonly int damageAmount;
        private NodeState state;

        #endregion

        #region Constructor

        public TakeDamage(EnemyBehaviour enemy, int damageAmount)
        {
            this.enemy = enemy;
            this.damageAmount = damageAmount;
        }

        #endregion

        #region Public Properties

        public override NodeState State => state;

        #endregion
        
        #region Delegate

        public delegate NodeState TakeDamageDelegate(EnemyBehaviour enemy, int damageAmount);
        
        #endregion

        #region Public Method

        /// <summary>
        /// Applies damage to the enemy and returns Success.
        /// </summary>
        public override NodeState Run()
        {
            enemy.entityBase.TakeDamage(damageAmount);
            state = NodeState.Success;
            return state;
        }

        #endregion
    }
}