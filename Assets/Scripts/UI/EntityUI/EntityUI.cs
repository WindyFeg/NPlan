using System.Collections.Generic;
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

        public void SetRequiredItemData(SerializableDictionary<Common_Utils.InteractableData, int> mats)
        {
            var idx = 0;
            foreach (var mat in mats)
            {
                Debug.Log("Required Item: " + mat.Key.objectData.Name);
                RequiredItems[idx].SetData(mat.Key.cost, mat.Value);
                RequiredItems[idx].SetSprite(mat.Key.objectData.resourceIcon);
                RequiredItems[idx].gameObject.SetActive(true);
                idx += 1;
            }
        }

        public void ClearRequiredItemData()
        {
            foreach (var item in RequiredItems)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}