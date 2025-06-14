using LKT268.BehaviourTree;
using LKT268.Enemy;
using UnityEngine;

namespace LTK268.BehaviourTree.Actions
{
    /// <summary>
    /// Action node that handles moving an enemy to a specified point.
    /// </summary>
    public class MoveToPoint : BTNode
    {
        #region Private Field

        private readonly EnemyBehaviour enemy;
        private readonly Vector3 targetPoint;
        private NodeState state;

        #endregion

        #region Constructor

        public MoveToPoint(EnemyBehaviour enemy, Vector3 targetPoint)
        {
            this.enemy = enemy;
            this.targetPoint = targetPoint;
        }

        #endregion

        #region Public Properties

        public override NodeState State => state;

        #endregion

        #region Delegate
        
        public delegate NodeState MoveToPointDelegate(EnemyBehaviour enemy, Vector3 targetPoint);

        #endregion

        #region Public Method

        /// <summary>
        /// Moves the enemy towards the target point until it reaches within a threshold distance.
        /// </summary>
        public override NodeState Run()
        {
            if (Vector3.Distance(enemy.transform.position, targetPoint) > 0.1f)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPoint,
                    enemy.Speed * Time.deltaTime);
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