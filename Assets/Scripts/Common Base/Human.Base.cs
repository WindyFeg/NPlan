using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class HumanBase : EntityBase, IHuman
    {
        #region Public Properties
        #endregion

        #region Private Fields
        #endregion

        #region Public Constructors
        public HumanBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Methods
        public EntityType GetEntityType() => EntityType;
        public new void InteractWithEntity(IEntity target)
        {
            OnInteractedByEntity(target);
        }


        public new void OnInteractedByEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public override string ToString()
        {
            return base.ToString() + "HumanBase: \n";
        }

        public bool IsHuman() => this.EntityType == EntityType.Player || this.EntityType == EntityType.NPC;

        public void Dead()
        {
            LTK268Log.LogNotImplement(this);
        }
        #endregion
    }

}