using System.Collections.Generic;
using UnityEngine;

namespace LTK268.Enemy
{
    /// <summary>
    /// Access EnemyType spawner by EnemyManager.Instance.GetSpawner(EnemyType type);
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {
        #region Public Properties

        public static EnemyManager Instance { get; private set; }

        [SerializeField] private List<EnemySpawnerEntry> spawnerEntries = new();

        #endregion

        #region Private Properties

        private Dictionary<EnemyType, EnemySpawner> spawnerByType = new();
        private bool isInEvent = false;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeSpawnerDictionary();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Public Methods

        public void SetIsInEvent(bool isInEvent)
        {
            this.isInEvent = isInEvent;
            ResetKillCounter();
        }

        public void SpawnEnemy(EnemyType type, Vector3 position)
        {
            if (spawnerByType.TryGetValue(type, out var spawner))
            {
                spawner.SpawnEnemy(position);
            }
            else
            {
                Debug.LogError($"[EnemyManager] No spawner found for enemy type: {type}");
            }
        }

        public void DespawnEnemy(EnemyType type, EnemyBehaviour enemy)
        {
            if (spawnerByType.TryGetValue(type, out var spawner))
            {
                spawner.DespawnEnemy(enemy);
            }
            else
            {
                Debug.LogError($"[EnemyManager] No spawner found for enemy type: {type}");
            }
        }

        #endregion

        #region Private Methods

        private void InitializeSpawnerDictionary()
        {
            foreach (var entry in spawnerEntries)
            {
                if (!spawnerByType.ContainsKey(entry.type))
                {
                    spawnerByType.Add(entry.type, entry.spawner);
                }
                else
                {
                    Debug.LogWarning($"[EnemyManager] Duplicate spawner entry for {entry.type}.");
                }
            }
        }

        private void ResetKillCounter()
        {
            foreach (var entry in spawnerByType)
            {
                var spawner = entry.Value;
                spawner.killCounter = 0;
            }
        }

        private void LogKillCounter()
        {
            foreach (var entry in spawnerByType)
            {
                var spawner = entry.Value;
                Debug.LogWarning($"EnemyManager: Kill {entry.Key}: {spawner.killCounter} time(s)");
            }
        }

        #endregion

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                var rnd = Random.Range(0f, 5f);
                SpawnEnemy(EnemyType.Wolf, new Vector3(rnd, 0f, rnd));
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                var spawner = spawnerByType[EnemyType.Wolf];
                for (var i = 0; i < spawner.transform.childCount; i++)
                {
                    var enemy = spawner.transform.GetChild(i).gameObject;
                    if (enemy.activeSelf)
                    {
                        DespawnEnemy(EnemyType.Wolf, enemy.GetComponent<EnemyBehaviour>());
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                LogKillCounter();
            }
        }
#endif
    }

    [System.Serializable]
    public struct EnemySpawnerEntry
    {
        public EnemyType type;
        public EnemySpawner spawner;
    }
}