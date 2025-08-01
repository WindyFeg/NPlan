using System;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using UnityEngine;

namespace Common_Utils
{
    #region Support Classes
    
    [Serializable]
    public class ActionInteractable
    {
        public string Key;
        public string Description;
    }
    
    [Serializable]
    public class RequiredItemInteractable
    {
        public InteractableData interactableData;
        public int CurrentAmount;
    }
    
    #endregion

    public class EntityInteractable : MonoBehaviour
    {
        [Tooltip("Adjust the Y position offset to align the UI with the interactable object.")]
        public float YPositionOffset = 0.75f;
        public bool isRequiredItem = true; 
        
        public ActionInteractable[] Actions;
        public RequiredItemInteractable[] RequiredItems;
        
        [Header("Entity Base Components")]
        [SerializeField] private ObjectBase objectBase;
        [SerializeField] private HumanBase humanBase;

        #region Unity Methods

        private void OnValidate()
        {
            if (objectBase == null && humanBase == null)
            {
                if (gameObject.tag == "NPC")
                {
                    humanBase = GetComponent<HumanBase>();
                }
                else
                {
                    objectBase = GetComponent<ObjectBase>();
                }
            }
        }
        
        #endregion
        
        

        // /// <summary>
        // /// Sets the action data for the interactable entity.
        // /// </summary>
        // /// <param name="datas"></param>
        // public void SetInteractableData(InteractableData[] datas)
        // {
        //     if (datas.Length == 0)
        //     {
        //         Debug.LogError("InteractableData is null. Cannot set interactable data.");
        //         return;
        //     }
        //     
        //     // Initialize RequiredItems with the provided interactable data
        //     RequiredItems = new RequiredItemInteractable[datas.Length];
        //     for (var i = 0; i < datas.Length; i++)
        //     {
        //         RequiredItems[i] = new RequiredItemInteractable
        //         {
        //             interactableData = datas[i],
        //             CurrentAmount = 0
        //         };
        //     }
        // }
        //
        // /// <summary>
        // /// Find the required item by its ID and add the specified amount to its current amount.
        // /// </summary>
        // /// <param name="resourceType"></param>
        // /// <param name="addAmount"></param>
        // public void AddRequiredItem(ResourceType resourceType , int addAmount = 1)
        // {
        //     for (var i = 0; i < RequiredItems.Length; i++)
        //     {
        //         if (RequiredItems[i].interactableData.objectData.resourceType == resourceType)
        //         {
        //             RequiredItems[i].CurrentAmount += addAmount;
        //             if (RequiredItems[i].CurrentAmount > RequiredItems[i].interactableData.cost)
        //             {
        //                 RequiredItems[i].CurrentAmount = RequiredItems[i].interactableData.cost;
        //             }
        //             return;
        //         }
        //     }
        //
        //     ChangeRequiredItemState();
        //     Debug.LogWarning($"Item with ResourceType {resourceType} not found in required items.");
        // }
        //
        // /// <summary>
        // /// Loop through all required items and check if player completed the item requirements.
        // /// </summary>
        // public void ChangeRequiredItemState()
        // {
        //     foreach (var item in RequiredItems)
        //     {
        //         if (item.CurrentAmount < item.interactableData.cost)
        //         {
        //             isRequiredItem = true;
        //             return;
        //         }
        //     }
        //     isRequiredItem = false;
        // }
    }
}