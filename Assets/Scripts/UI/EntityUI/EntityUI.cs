using Common_Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace UI.EntityUI
{
    public class EntityUI : MonoBehaviour
    {
        public UIAction[] Actions;
        public UIRequiredItem[] RequiredItems;

        public void SetActionData(ActionInteractable[] actionInteractable)
        {
            for (int i = 0; i < actionInteractable.Length; i++)
            {
                if (i < Actions.Length)
                {
                    Actions[i].SetData(actionInteractable[i].Key, actionInteractable[i].Description);
                    Actions[i].gameObject.SetActive(true);
                }
                else
                {
                    Actions[i].gameObject.SetActive(false);
                }
            }
        }
        
        public void SetRequiredItemData(RequiredItemInteractable[] requiredItems, bool isRequiredItem)
        
        {
            // for (int i = 0; i < RequiredItems.Length; i++)
            // {
            //     if (i < requiredItems.Length && isRequiredItem)
            //     {
            //         var interactableData = requiredItems[i].interactableData;
            //         RequiredItems[i].SetData(interactableData.cost, requiredItems[i].CurrentAmount);
            //         RequiredItems[i].SetSprite(interactableData.objectData.resourceIcon);
            //         RequiredItems[i].gameObject.SetActive(true);
            //     }
            //     else
            //     {
            //         RequiredItems[i].gameObject.SetActive(false);
            //     }
            // }
        }
    }
}