using LTK268.Interface;
using LTK268.Manager;
using LTK268.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    [System.Serializable]
    public class EnemyBase : AnimalBase, IEnemy
    {
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
    }
}