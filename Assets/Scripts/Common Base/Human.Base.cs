using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class HumanBase : EntityBase, IHumanControl
    {
        public HumanBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }

        public void InteractWithEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void InteractWithObject(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void OnInteractedByEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void OnInteractedByObject(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }
    }
}