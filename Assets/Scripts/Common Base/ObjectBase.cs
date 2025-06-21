using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class ObjectBase : EntityBase, IHumanControl
    {
        public ObjectBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }

        public void InteractWithEntity(IEntity target)
        {
            OnInteractedByEntity(target);
        }

        public void InteractWithObject(IEntity target)
        {
            OnInteractedByObject(target);
        }

        protected void OnInteractedByEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        protected void OnInteractedByObject(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }
    }
}