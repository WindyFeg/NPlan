using LKT268.BehaviourTree;
using LKT268.Enemy;

namespace LTK268.BehaviourTree.Actions
{
    /// <summary>
    /// Logic for performing a normal attack.
    /// </summary>
    
    public class NormalAttack : BTNode
    {
        #region Private Field

        private readonly EnemyBehaviour enemy;
        private NodeState state;

        #endregion

        #region Constructor

        public NormalAttack(EnemyBehaviour enemy)
        {
            this.enemy = enemy;
        }

        #endregion

        #region Public Properties

        public override NodeState State => state;

        #endregion
        
        #region Delegate

        public delegate NodeState NormalAttackDelegate();
        
        #endregion

        #region Public Method

        /// <summary>
        /// Executes the normal attack logic.
        /// </summary>
        public override NodeState Run()
        {
            enemy.Attack(); // Assuming this method handles the attack logic, such as playing animations and dealing damage.
            state = NodeState.Success;
            return state;
        }

        #endregion
    }
}