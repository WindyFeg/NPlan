using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class AnimalBase : EntityBase, IAnimal
    {
        public AnimalBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }

        public void DropLoot()
        {
            throw new System.NotImplementedException();
        }
    }
}