namespace LKT268.BehaviourTree.Condition
{
    /// <summary>
    /// Checks if the enemy is dead.
    /// </summary>
    public class IsDead : BTNode
    {
        #region Private Field
        private readonly Enemy enemy;

        #endregion

        #region Constructor

        public IsDead(Enemy enemy)
        {
            this.enemy = enemy;
        }

        #endregion

        #region Public Properties

        public override NodeState State => state;

        #endregion

        #region Private Field

        private NodeState state;

        #endregion

        #region Public Method

        /// <summary>
        /// Checks if the enemy is dead and returns Success if true, otherwise Failure.
        /// </summary>
        public override NodeState Run()
        {
            if (enemy.IsDead)
            {
                state = NodeState.Success;
            }
            else
            {
                state = NodeState.Failure;
            }

            return state;
        }

        #endregion
    }
}
