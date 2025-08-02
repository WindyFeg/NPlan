using System.Collections.Generic;
using LTK268.Interface;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    public class HumanBase : EntityBase, IHuman
    {
        #region Public Properties
        public List<GameObject> HoldItems
        {
            get => holdItems;
            set => holdItems = value;
        }
        public int MaxNumberOfHoldItems
        {
            get => maxNumberOfHoldItems;
            set => maxNumberOfHoldItems = value;
        }
        #endregion

        #region Private Fields
        [SerializeField] private List<GameObject> holdItems = new List<GameObject>();
        [SerializeField] private int maxNumberOfHoldItems = 1;
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

        public void AddHoldItem(GameObject item)
        {
            holdItems.Add(item);
        }

        public GameObject RemoveHoldItem()
        {
            if (holdItems.Count == 0)
            {
                Debug.LogWarning("No items to remove", this);
                return null;
            }
            GameObject item = holdItems[0];
            holdItems.RemoveAt(0);
            return item;
        }
        #endregion
    }

}