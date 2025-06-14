using LKT268.CommonBase;
using LKT268.CommonConst;
using LTK268.Define;
using UnityEngine;

namespace LKT268.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        #region Public Properties
        
        public EntityType EntityType => EntityType.Enemy;
        public EntityBase EntityBase { get; protected set; }
        public int Speed { get; set; } = 5; // Default speed for the enemy
            
        #endregion

        #region Private Fields

        private int spawnPos;
        private bool isTrigger;
        private bool isDead;
        private bool isHit;
        private EnemyPhase enemyPhase;

        #endregion
        
        #region Public Methods
        
        /// <summary>
        /// Moves the enemy towards a target position.
        /// </summary>
        public void MoveTo(Vector3 targetPosition)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
            }
        }
        
        /// <summary>
        /// Enemy perform an attack action.
        /// </summary>
        public void Attack()
        {
        }
        
        /// <summary>
        /// Handles the death logic of the enemy (e.g., play animation, disable components).
        /// </summary>
        public void Die()
        {
            // Implement death logic here, such as playing an animation or disabling components.
            Debug.Log($"{EntityBase.Name} has died.");
            gameObject.SetActive(false); // Example: disable the enemy GameObject.
        }
        
        #endregion
    }
}