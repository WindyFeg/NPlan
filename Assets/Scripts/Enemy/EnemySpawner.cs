using System;
using LTK268.Model.CommonBase;
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
        [SerializeField] private EnemyBase enemyPrefab;
        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxCapacity = 50;
        #endregion

        public Action<EnemyBase> onInit;
        // public Action<EnemyBase> onDead;

        #region Private Fields
        private ObjectPool<EnemyBase> enemyPool;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            enemyPool = new ObjectPool<EnemyBase>(
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

        public EnemyBase SpawnEnemy(Vector3 position)
        {
            var enemy = enemyPool.Get();
            enemy.transform.position = position;
            enemy.transform.parent = transform;
            // onInit?.Invoke(enemy);
            return enemy;
        }

        public void DespawnEnemy(EnemyBase enemy)
        {
            if (enemy) Debug.Log("> Despawn");
            enemy.Death();
            killCounter++;
            // onDead?.Invoke(enemy);
            enemyPool.Release(enemy);
        }
        
        #endregion

        #region Pool Callbacks

        private EnemyBase CreateEnemy()
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.Pool = enemyPool;
            return enemy;
        }

        private void OnGetEnemy(EnemyBase enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        private void OnReleaseEnemy(EnemyBase enemy)
        {
            if (enemy) Debug.Log("> OnReleaseEnemy");
            enemy.gameObject.SetActive(false);
        }

        private void OnDestroyEnemy(EnemyBase enemy)
        {
            Destroy(enemy.gameObject);
        }

        #endregion
    }
}
