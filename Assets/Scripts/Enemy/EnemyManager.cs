using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace LKT268.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        #region Public Properties

        public static EnemyManager Instance { get; private set; }

        public EnemySpawner[] enemySpawners;

        #endregion

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                enemySpawners[0].SpawnEnemy(new Vector3(0, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                var enemy = enemySpawners[0].transform.GetChild(0).GetComponent<EnemyBehaviour>();
                enemySpawners[0].DespawnEnemy(enemy);
            }
        }
#endif
    }
}