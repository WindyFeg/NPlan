using LTK268.Enemy;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using UnityEngine;

namespace LTK268.Enemy
{
    public class WolfModel : EnemyBase, IEnemy
    {
        [SerializeField] private int speed = 5;
        public WolfModel(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
    }
}