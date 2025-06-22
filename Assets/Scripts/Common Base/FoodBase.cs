using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
{
    public class FoodBase : ObjectBase, IFood
    {
        #region Private Field
        [SerializeField] ObjectType objectType = ObjectType.Food;
        #endregion

        #region Public Properties
        public ObjectType ObjectType { set => objectType = ObjectType.Food; get => ObjectType.Food; }
        #endregion

        #region Public Constructors
        public FoodBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Unity Methods
        void OnValidate()
        {
            if (!gameObject.CompareTag("Food"))
            {
                gameObject.tag = "Food";
            }
        }
        #endregion

        #region Public Methods
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
            this.Destroy();
        }
    }
}