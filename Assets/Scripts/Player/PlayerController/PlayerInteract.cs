using UnityEngine;
using System.Collections.Generic;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using Common_Utils;
using LTK268.Popups;
namespace LTK268
{
    /// <summary>
    /// Handles player interactions with nearby interactable entities (e.g., NPCs, items).
    /// Uses Physics.OverlapSphere to detect nearby interactables.
    /// </summary>
    public class PlayerInteract : MonoBehaviour
    {
        #region Serialized Fields

        [Tooltip("Reference to the player's data model.")]
        [SerializeField] private PlayerModel playerModel;

        [Tooltip("LayerMask to detect which objects are interactable.")]
        [SerializeField] private LayerMask interactableLayer;

        [Tooltip("EntityDetector to manage entity detection.")]
        [SerializeField] private EntityDetector entityDetector;

        #endregion

        #region Private Fields

        private IEntity currentInteractable;
        [SerializeField] private EntityBase closestEntity;

        #endregion

        #region Unity Methods
        List<Collider> objectsInTrigger = new List<Collider>();
        private void Start()
        {
            if (playerModel == null)
            {
                Debug.LogError("PlayerModel is not assigned in PlayerInteract.");
                return;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!objectsInTrigger.Contains(other))
            {
                objectsInTrigger.Add(other);
                if (other.gameObject.layer != LayerMask.NameToLayer("Default"))
                {
                    var go = entityDetector.GetClosestEntity();
                    closestEntity = go?.GetComponent<EntityBase>();
                    currentInteractable = closestEntity as IEntity;
                    if (currentInteractable != null)
                    {
                        if (playerModel.HoldItems.Count > 0)
                        {
                            EntityUIManager.Instance.ShowChangeItemUI(currentInteractable, go?.transform);
                        }
                        else
                        {
                            EntityUIManager.Instance.ShowEntityUI(currentInteractable, go?.transform);
                        }
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (objectsInTrigger.Contains(other))
            {
                EntityUIManager.Instance.HideEntityUI(null);
                objectsInTrigger.Remove(other);
            }
        }
        #endregion

        #region Interaction Events

        public void OnInteract()
        {
            // if (playerModel.HoldItems.Count > playerModel.MaxNumberOfHoldItems) return;
            if (currentInteractable == null) return;
            Debug.Log("OnInteract called" + currentInteractable.Name);
            if (currentInteractable.EntityType == EntityType.Object && playerModel.HoldItems.Count > 0)
            {
                var item = playerModel.GetComponent<IHuman>().RemoveHoldItem();
                item.GetComponent<IObject>().DroppedBy(this.playerModel);
            }
            currentInteractable.InteractWithEntity(playerModel);

            EntityUIManager.Instance.ShowEntityUI(currentInteractable, closestEntity?.transform);
            currentInteractable = null;
        }

        public void OnDrop()
        {
            if (playerModel.HoldItems.Count == 0) return;
            var item = playerModel.GetComponent<IHuman>().RemoveHoldItem();
            item.GetComponent<IObject>().DroppedBy(this.playerModel);
        }
        public void OnUse()
        {
            if (currentInteractable != null)
            {
                var item = currentInteractable as ObjectBase;
                item.Use();
                currentInteractable = null;
                return;
            }
            else if (playerModel.HoldItems.Count > 0 && currentInteractable == null)
            {
                var item = playerModel.GetComponent<IHuman>().RemoveHoldItem();
                item.GetComponent<IObject>().Use();
                return;
            }
            currentInteractable = null;
        }

        public void OnAttack()
        {
            // this.notify_event((int)EventID.Game.OnOpenJobList, NPCFunctionType.Lumber);
            // Implement attack logic if needed.
        }

        public void OnPrevious()
        {
            // Implement logic for previous interaction if needed.
            // this.notify_event((int)EventID.Game.OnSwipeLeftJobList);
        }
        public void OnNext()
        {
            // Implement logic for next interaction if needed.
            // this.notify_event((int)EventID.Game.OnSwipeRightJobList);
        }

        #endregion
    }
}