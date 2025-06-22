using UnityEngine;
using UnityEngine.Pool;

namespace LKT268.Enemy
{
    /// <summary>
    /// Handles spawning and pooling of enemies.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private EnemyBehaviour enemyPrefab;
        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxCapacity = 50;
        #endregion

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

        public void SpawnEnemy(Vector3 position, System.Action<EnemyBehaviour> onInit = null)
        {
            var enemy = enemyPool.Get();
            enemy.transform.position = position;
            enemy.transform.parent = transform;
            onInit?.Invoke(enemy);
        }

        public void DespawnEnemy(EnemyBehaviour enemy)
        {
            if (enemyPool != null)
                enemyPool.Release(enemy);
        }

        public int ActiveCount => enemyPool?.CountActive ?? 0;
        public int InactiveCount => enemyPool?.CountInactive ?? 0;

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
            enemy.gameObject.SetActive(false);
        }

        private void OnDestroyEnemy(EnemyBehaviour enemy)
        {
            Destroy(enemy.gameObject);
        }

        #endregion
    }
}
