using LKT268.BehaviourTree;
using LKT268.Enemy;
using UnityEngine;

namespace LTK268.BehaviourTree.Actions
{
    /// <summary>
    /// Action node that handles moving an enemy to a specified point.
    /// </summary>
    public class Chase : BTNode
    {
        #region Private Field

        private readonly EnemyBehaviour enemy;
        private readonly GameObject target;

        #endregion

        #region Constructor

        public Chase(EnemyBehaviour enemy, GameObject target)
        {
            this.enemy = enemy;
            this.target = target;
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
        /// Moves the enemy towards the target point until it reaches within a threshold distance.
        /// </summary>
        public override NodeState Run()
        {
            if (target == null)
            {
                state = NodeState.Failure;
                return state;
            }

            Vector3 targetPosition = target.transform.position;

            if (Vector3.Distance(enemy.transform.position, targetPosition) > 0.1f)
            {
                enemy.MoveTo(targetPosition);
                state = NodeState.Running;
            }
            else
            {
                state = NodeState.Success;
            }

            return state;
        }

        #endregion
    }
}