using UnityEngine;
using System.Collections.Generic;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using Common_Utils;
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
        private EntityBase closestEntity;

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
                        var entityInteractable = closestEntity.GetComponent<EntityInteractable>();
                        EntityUIManager.Instance.ShowEntityUI(entityInteractable);
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
            if (currentInteractable == null || ((MonoBehaviour)currentInteractable) == null) return;
            Debug.Log("OnInteract called" + currentInteractable.Name);
            currentInteractable.InteractWithEntity(playerModel);
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