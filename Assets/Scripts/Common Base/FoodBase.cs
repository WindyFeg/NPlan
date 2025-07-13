using LTK268.Interface;
using LTK268.Manager;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    [System.Serializable]
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
        public new void DroppedBy(IEntity entity)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void EatenBy(IEntity entity)
        {
            LTK268Log.LogNotImplement(this);
        }

        public new void PickedUpBy(IEntity entity)
        {
            PlayerManager.Instance.ListOfFoods.Add(this);
            LTK268Log.LogEntityAction(this, $"Picked up by {entity.Name}");
            this.gameObject.SetActive(false);
        }
    }
}