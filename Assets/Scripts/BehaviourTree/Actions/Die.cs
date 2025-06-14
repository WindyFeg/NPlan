using LKT268.BehaviourTree;
using LKT268.Enemy;

namespace LTK268.BehaviourTree.Actions
{
    /// <summary>
    /// Handles the death logic of the enemy (e.g., play animation, disable components).
    /// </summary>
    public class Die : BTNode
    {
        #region Private Field

        private readonly EnemyBehaviour enemy;
        private bool hasDied;
        private NodeState state;
        
        #endregion

        #region Constructor

        public Die(EnemyBehaviour enemy)
        {
            this.enemy = enemy;
            hasDied = false;
        }

        #endregion

        #region Public Properties

        public override NodeState State => state;

        #endregion
        
        #region Delegate

        public delegate NodeState DieDelegate();
        
        #endregion

        #region Public Method

        /// <summary>
        /// Executes the death logic once, then returns Success.
        /// </summary>
        public override NodeState Run()
        {
            if (!hasDied)
            {
                enemy.Die(); // Should handle animation, cleanup, disabling colliders etc.
                hasDied = true;
            }

            state = NodeState.Success;
            return state;
        }

        #endregion
    }
}