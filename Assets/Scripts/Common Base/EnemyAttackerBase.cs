using LTK268.Interface;
using LTK268.Manager;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    [System.Serializable]
    public class EnemyAttackerBase : ObjectBase, IEnemy, IEnemyAttacker
    {
        public EnemyAttackerBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }

        public void DropLoot()
        {
            throw new System.NotImplementedException();
        }

        public void Looting()
        {
            throw new System.NotImplementedException();
        }
    }
}