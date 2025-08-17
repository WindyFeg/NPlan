using System.Collections.Generic;
using LTK268.Interface;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    public class HumanBase : EntityBase, IHuman, IEntity
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
        public SpriteRenderer HoldItemIcon
        {
            get => holdItemIcon;
            set => holdItemIcon = value;
        }
        #endregion

        #region Private Fields
        [SerializeField] private List<GameObject> holdItems = new List<GameObject>();
        [SerializeField] private int maxNumberOfHoldItems = 1;
        [SerializeField] private SpriteRenderer holdItemIcon;
        [SerializeField] private SpriteRenderer weaponSpriteRenderer;
        [SerializeField] private WeaponBehaviour weaponBehaviour;
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
            if (holdItemIcon != null)
            {
                Debug.Log("Hold item icon is set", this);
                holdItemIcon.sprite = item.GetComponent<SpriteRenderer>().sprite;
            }
            holdItems.Add(item);
        }

        public GameObject RemoveHoldItem()
        {
            if (holdItems.Count == 0)
            {
                Debug.LogWarning("No items to remove", this);
                return null;
            }
            if (holdItemIcon != null)
            {
                holdItemIcon.sprite = null; // Clear the icon when removing an item
            }
            GameObject item = holdItems[0];
            holdItems.RemoveAt(0);
            return item;
        }

        
        public void EquipWeapon(WeaponObject weaponObject)
        {
            if (weaponObject == null)
            {
                LTK268Log.LogError("Weapon object is null.");
                return;
            }

            Sprite weaponSprite = weaponObject.ObjectData.resourceIcon;
            if (weaponSpriteRenderer != null)
            {
                weaponSpriteRenderer.sprite = weaponSprite;
                weaponBehaviour.SetWeaponProperties(this, weaponObject);
                weaponSpriteRenderer.gameObject.SetActive(true);
            }
            else
            {
                LTK268Log.LogError("Weapon sprite renderer is not assigned.");
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        // public void ToString(string prefix = "")
        // {
        //     Debug.Log($"{prefix}HumanBase: HoldItems Count={HoldItems.Count}, MaxHoldItems={MaxNumberOfHoldItems}");
        //     foreach (var item in HoldItems)
        //     {
        //         Debug.Log($"{prefix} - Item: {item.name}");
        //     }
        // }
        #endregion
    }

}