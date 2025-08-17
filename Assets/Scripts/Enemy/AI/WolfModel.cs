using System.Collections.Generic;
using LTK268.Enemy;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using Unity.Behavior;
using UnityEngine;

namespace LTK268.Enemy
{
    public class WolfModel : EnemyBase, IEnemy
    {
        [SerializeField] private int speed = 5;
        [SerializeField] private BehaviorGraphAgent behaviorGraphAgent;
        
        [SerializeField] private float patrolRadius = 10f;
        [SerializeField] private int pointCount = 3;

        public List<Vector3> waypoints = new List<Vector3>();
        public Transform target;
        
        public WolfModel(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        { }

        public void Start()
        {
            GetRandomPatrolWaypoints();
            GetAttackTarget();
        }
        
        /// <summary>
        /// Generate random patrol waypoints around this GameObject within a radius.
        /// </summary>
        public void GetRandomPatrolWaypoints()
        {
            waypoints.Clear();

            for (int i = 0; i < pointCount; i++)
            {
                // Pick a random point inside a circle, then scale to 3D
                Vector2 randomCircle = Random.insideUnitCircle * patrolRadius;

                Vector3 randomPoint = new Vector3(
                    transform.position.x + randomCircle.x,
                    transform.position.y,
                    transform.position.z + randomCircle.y
                );

                waypoints.Add(randomPoint);
            }

            // Debug draw waypoints
            foreach (var wp in waypoints)
            {
                Debug.DrawLine(transform.position, wp, Color.green, 5f);
            }
        }

        public void GetAttackTarget()
        {
            
        }

    }
}