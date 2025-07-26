using LTK268.Interface;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
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