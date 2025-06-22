using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class FoodBase : ObjectBase, IFood
    {
        #region Private Field
        #endregion

        #region Public Properties
        #endregion

        #region Public Constructors
        public FoodBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Properties
        #endregion
        public void DroppedBy(IEntity entity)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void EatenBy(IEntity entity)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void PickedUpBy(IEntity entity)
        {
            LTK268Log.LogNotImplement(this);
        }
    }
}