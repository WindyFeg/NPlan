using LKT268.BehaviourTree;
using LKT268.Enemy;
using UnityEngine;

namespace LTK268.BehaviourTree.Actions
{
    /// <summary>
    /// Handles the logic for taking damage.
    /// </summary>
    public class ReturnToRespawn : BTNode
    {
        #region Public Field

        private readonly EnemyBehaviour enemy;
        private Vector3 respawnPosition;
        private NodeState state;

        #endregion

        #region Constructor

        public ReturnToRespawn(EnemyBehaviour enemy, Vector3 respawnPosition)
        {
            this.enemy = enemy;
            this.respawnPosition = respawnPosition;
        }

        #endregion

        #region Public Properties

        public override NodeState State => state;

        #endregion

        #region Delegate
        
        public delegate NodeState ReturnToRespawnDelegate(EnemyBehaviour enemy, Vector3 respawnPosition);

        #endregion

        #region Public Method

        /// <summary>
        /// Repeat until the enemy reaches the respawn position.
        /// </summary>
        public override NodeState Run()
        {
            if (Vector3.Distance(enemy.transform.position, respawnPosition) > 0.1f)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, respawnPosition,
                    enemy.speed * Time.deltaTime);
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