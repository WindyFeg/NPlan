using System;
using UnityEngine;
using UnityEngine.Pool;

namespace LTK268.Enemy
{
    /// <summary>
    /// Handles spawning and pooling of enemies.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [HideInInspector] public int killCounter;

        #region Serialized Fields
        [SerializeField] private EnemyBehaviour enemyPrefab;
        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxCapacity = 50;
        #endregion

        public Action<EnemyBehaviour> onInit;
        public Action<EnemyBehaviour> onDead;

        #region Private Fields
        private ObjectPool<EnemyBehaviour> enemyPool;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            enemyPool = new ObjectPool<EnemyBehaviour>(
                CreateEnemy,
                OnGetEnemy,
                OnReleaseEnemy,
                OnDestroyEnemy,
                collectionCheck: false,
                defaultCapacity,
                maxCapacity);
        }

        #endregion

        #region Public Methods

        public void SpawnEnemy(Vector3 position)
        {
            var enemy = enemyPool.Get();
            enemy.transform.position = position;
            enemy.transform.parent = transform;
            onInit?.Invoke(enemy);
        }

        public void DespawnEnemy(EnemyBehaviour enemy)
        {
            if (enemy) Debug.Log("> Despawn");
            killCounter++;
            onDead?.Invoke(enemy);
            enemyPool.Release(enemy);
        }
        
        #endregion

        #region Pool Callbacks

        private EnemyBehaviour CreateEnemy()
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.Pool = enemyPool;
            return enemy;
        }

        private void OnGetEnemy(EnemyBehaviour enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        private void OnReleaseEnemy(EnemyBehaviour enemy)
        {
            if (enemy) Debug.Log("> OnReleaseEnemy");
            enemy.gameObject.SetActive(false);
        }

        private void OnDestroyEnemy(EnemyBehaviour enemy)
        {
            Destroy(enemy.gameObject);
        }

        #endregion
    }
}
