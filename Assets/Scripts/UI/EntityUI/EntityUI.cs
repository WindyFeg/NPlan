using Common_Utils;
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
        
        public void SetRequiredItemData(RequiredItemInteractable[] requiredItems)
        {
            for (int i = 0; i < requiredItems.Length; i++)
            {
                if (i < requiredItems.Length)
                {
                    RequiredItems[i].SetData(requiredItems[i].ItemId, requiredItems[i].Amount, requiredItems[i].CurrentAmount);
                    RequiredItems[i].SetSprite(requiredItems[i].Icon);
                    RequiredItems[i].gameObject.SetActive(true);
                }
                else
                {
                    RequiredItems[i].gameObject.SetActive(false);
                }
            }
        }
    }
}