using System;
using LTK268.Enemy;
using LTK268.Interface;
using LTK268.Manager;
using UnityEngine.Pool;

namespace LTK268.Model.CommonBase
{
    [System.Serializable]
    public class EnemyBase : AnimalBase, IEnemy
    {
        public EnemyType EnemyType;
        public IObjectPool<EnemyBase> Pool { get; set; }
        public event Action<EnemyBase> OnDead;
        
        public EnemyBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }

        #region Public Unity Methods
        void Start()
        {
            EnemyManager.Instance.RegisterEnemy(this);
        }

        void OnDestroy()
        {
            EnemyManager.Instance.UnregisterEnemy(this);
        }
        
        void OnValidate()
        {
            if (!gameObject.CompareTag("Enemy"))
            {
                gameObject.tag = "Enemy";
            }
        }
        #endregion
        
        public void Death()
        {
            OnDead?.Invoke(this);
        }
    }
}