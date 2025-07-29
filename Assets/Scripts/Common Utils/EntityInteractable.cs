using System;
using UnityEngine;

namespace Common_Utils
{
    [Serializable]
    public class ActionInteractable
    {
        public string Key;
        public string Description;
    }
    
    [Serializable]
    public class RequiredItemInteractable
    {
        // Sửa itemId, icon thành resourceData
        public BuildingData buildingData;
        public int ItemId;
        public Sprite Icon;
        public int Amount;
        public int CurrentAmount;
    }
    
    public class EntityInteractable : MonoBehaviour
    {
        RequiredItemInteractable icon;
        public float YPositionOffset = 0.75f;
        public bool isRequiredItem = true;
        public ActionInteractable[] Actions;
        public RequiredItemInteractable[] RequiredItems;

        /// <summary>
        /// Find the required item by its ID and add the specified amount to its current amount.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="addAmount"></param>
        public void AddRequiredItem(int itemId, int addAmount = 1)
        {
            for (var i = 0; i < RequiredItems.Length; i++)
            {
                if (RequiredItems[i].ItemId == itemId)
                {
                    RequiredItems[i].CurrentAmount += addAmount;
                    if (RequiredItems[i].CurrentAmount > RequiredItems[i].Amount)
                    {
                        RequiredItems[i].CurrentAmount = RequiredItems[i].Amount;
                    }
                    return;
                }
            }

            ChangeRequiredItemState();
            Debug.LogWarning($"Item with ID {itemId} not found in required items.");
        }

        /// <summary>
        /// Loop through all required items and check if player completed the item requirements.
        /// </summary>
        public void ChangeRequiredItemState()
        {
            foreach (var item in RequiredItems)
            {
                if (item.CurrentAmount < item.Amount)
                {
                    isRequiredItem = true;
                    return;
                }
            }
            isRequiredItem = false;
        }
    }
}