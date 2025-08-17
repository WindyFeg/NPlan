// using System;
// using LTK268.Model.CommonBase;
// using LTK268.Utils;
// using LTK268.Define;
// using UnityEngine;
// using UnityEngine.Pool;
//
// namespace LTK268.Enemy
// {
//     public class EnemyBehaviour : MonoBehaviour
//     {
//         #region Public Properties
//         public EntityBase entityBase;
//         // public EnemyBase enemyBase;
//         public IObjectPool<EnemyBehaviour> Pool { get; set; }
//         public EntityType entityType = EntityType.Enemy;
//         public EnemyType enemyType;
//         public EnemyStats stats;
//         public int speed = 5; // Default speed for the enemy
//         #endregion
//
//         #region Private Fields
//
//         private int spawnPos;
//         private bool isTrigger;
//         private bool isDead;
//         private bool isHit;
//         private EnemyPhase enemyPhase;
//         private Action returnToPool;
//
//         #endregion
//         
//         #region Public Methods
//
//         /// <summary>
//         /// Get dead state of enemy
//         /// </summary>
//         public bool GetIsDead()
//         {
//             return isDead;
//         }
//         
//         /// <summary>
//         /// Set return-to-pool callback for when this enemy is despawned.
//         /// </summary>
//         public void SetPoolReference(Action callback)
//         {
//             returnToPool = callback;
//         }
//         
//         /// <summary>
//         /// Moves the enemy towards a target position.
//         /// </summary>
//         public void MoveTo(Vector3 targetPosition)
//         {
//             if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
//             {
//                 transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
//             }
//         }
//         
//         /// <summary>
//         /// Enemy perform an attack action.
//         /// </summary>
//         public void Attack()
//         {
//         }
//         
//         /// <summary>
//         /// Enemy die and release back to Pool
//         /// </summary>
//         public void Die()
//         {
//             returnToPool?.Invoke();
//         }
//         
//         #endregion
//     }
// }