using System.Collections.Generic;
using DG.Tweening;
using LTK268.Enemy;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    /// <summary>
    /// Access EnemyType spawner by EnemyManager.Instance.GetSpawner(EnemyType type);
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {
        #region Public Properties

        public static EnemyManager Instance { get; private set; }
        public List<EnemyBase> EnemyBases => enemyBases;
        #endregion

        #region Private Properties
        [SerializeField] private List<EnemySpawnerEntry> spawnerEntries = new();
        [SerializeField] private List<EnemyBase> enemyBases = new List<EnemyBase>();
        private Dictionary<EnemyType, EnemySpawner> spawnerByType = new();
        private bool isInEvent = false;
        private int nextId = 1;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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
                LTK268Log.ManagerLog($"Enemy spawned: {type} at {position}");
            }
            else
            {
                LTK268Log.ManagerError($"No spawner found for enemy type: {type}");
            }
        }

        public void DespawnEnemy(EnemyType type, EnemyBehaviour enemy)
        {
            if (enemy == null)
            {
                LTK268Log.ManagerError("DespawnEnemy: Enemy parameter is null");
                return;
            }

            if (spawnerByType.TryGetValue(type, out var spawner))
            {
                spawner.DespawnEnemy(enemy);
                LTK268Log.ManagerLog($"Enemy despawned: {type}");
            }
            else
            {
                LTK268Log.ManagerError($"No spawner found for enemy type: {type}");
            }
        }
        /// <summary>
        /// Call this from EnemyBase's OnEnable
        /// </summary>
        /// <param name="enemy"></param>
        public void RegisterEnemy(EnemyBase enemy)
        {
            if (enemy == null)
            {
                LTK268Log.ManagerError("RegisterEnemy: Enemy parameter is null");
                return;
            }

            if (!EnemyBases.Contains(enemy))
            {
                // Check if entity already has an ID
                if (enemy.Id == 0)
                {
                    // Assign next available ID
                    enemy.Id = GetNextAvailableId();
                    LTK268Log.ManagerLog($"Enemy registered with new ID: {enemy.Id} - {enemy.Name}");
                }
                else
                {
                    // Entity already has an ID, use it
                    LTK268Log.ManagerLog($"Enemy registered with existing ID: {enemy.Id} - {enemy.Name}");
                }

                EnemyBases.Add(enemy);
            }
            else
            {
                LTK268Log.ManagerError($"Enemy is already registered: {enemy.Name}");
            }
        }

        /// <summary>
        /// Call this from EnemyBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="npc"></param>
        public void UnregisterEnemy(EnemyBase enemy)
        {
            EnemyBases.Remove(enemy);
        }

        public void CameraPanForEnemies(float panSpeed, float tweenDuration)
        {
            foreach (var enemy in EnemyBases)
            {
                if (enemy == null || enemy.transform == null) continue;

                // Rotate each enemy by the specified pan speed
                try
                {
                    enemy.EntityView.transform.DORotate(
                        new Vector3(panSpeed * 5, 0, 0), // Rotate 5 degrees on X, 0 on Y, 0 on Z
                        tweenDuration,
                        RotateMode.LocalAxisAdd // Add this rotation to the current local rotation
                    ).SetEase(Ease.InOutQuad);
                }
                catch (System.Exception)
                {
                    LTK268Log.ManagerError($"[EnemyManager] CameraPanForEnemies: {enemy.name} has no EntityView assigned.");
                }
            }
        }
        #endregion

        #region Private Methods

        private void InitializeSpawnerDictionary()
        {
            foreach (var entry in spawnerEntries)
            {
                if (entry.spawner == null)
                {
                    LTK268Log.ManagerError($"Spawner is null for enemy type: {entry.type}");
                    continue;
                }

                if (!spawnerByType.ContainsKey(entry.type))
                {
                    spawnerByType.Add(entry.type, entry.spawner);
                    LTK268Log.ManagerLog($"Spawner registered for enemy type: {entry.type}");
                }
                else
                {
                    LTK268Log.ManagerError($"Duplicate spawner entry for {entry.type}");
                }
            }
        }

        private void ResetKillCounter()
        {
            foreach (var entry in spawnerByType)
            {
                var spawner = entry.Value;
                if (spawner != null)
                {
                    spawner.killCounter = 0;
                }
            }
        }

        private void LogKillCounter()
        {
            foreach (var entry in spawnerByType)
            {
                var spawner = entry.Value;
                if (spawner != null)
                {
                    LTK268Log.ManagerLog($"EnemyManager: Kill {entry.Key}: {spawner.killCounter} time(s)");
                }
            }
        }

        /// <summary>
        /// Gets the next available ID by finding the highest ID and adding 1
        /// </summary>
        /// <returns>The next available ID</returns>
        private int GetNextAvailableId()
        {
            int maxId = 0;
            
            // Find the highest ID among all entities
            foreach (var entity in enemyBases)
            {
                if (entity.Id > maxId)
                {
                    maxId = entity.Id;
                }
            }

            // Return the next ID
            return maxId + 1;
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