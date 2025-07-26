using UnityEngine;
using System.Collections.Generic;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
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

        [Tooltip("Detection radius around the player.")]
        [SerializeField] private float detectionRadius = 0.5f;

        #endregion

        #region Private Fields

        private IEntity currentInteractable;
        private EntityBase closestEntity;

        #endregion

        #region Unity Lifecycle

        private void Update()
        {
            DetectNearbyInteractables();
        }

        #endregion

        #region Interaction Events

        public void OnInteract()
        {
            if (currentInteractable == null || ((MonoBehaviour)currentInteractable) == null) return;

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

        #region Detection Logic

        private void DetectNearbyInteractables()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, interactableLayer);

            if (hits.Length > 0)
            {
                if (currentInteractable != null)
                {
                    // If we already have an interactable, we can skip the notification
                    // to avoid redundant updates.
                    return;
                }
                // Find the closest interactable (optional)
                float minDistance = float.MaxValue;
                IEntity closestInteractable = null;
                Transform objectTransform = null;

                foreach (var hit in hits)
                {
                    var entity = hit.GetComponent<IEntity>();
                    if (entity != null)
                    {
                        float dist = Vector3.Distance(transform.position, hit.transform.position);
                        if (dist < minDistance)
                        {
                            minDistance = dist;
                            closestInteractable = entity;
                            objectTransform = hit.transform;
                            
                            // Show interactable UI
                            // Tách thành 1 function
                            // var entityBase = hit.GetComponent<EntityBase>();
                            // if (entityBase != null && entityBase != closestEntity)
                            // {
                            //     // Destroy the previous entity UI if it exists
                            //     if (closestEntity != null && closestEntity.EntityView != null)
                            //     {
                            //         LTK268Log.LogInfo($"Hiding UI for {closestEntity.Name}");
                            //         UIManager.Instance.HideEntityUI(closestEntity);
                            //     }
                            //     closestEntity = entityBase;
                            //     // Notify UIManager to show the entity UI
                            //     if (closestEntity != null && closestEntity.EntityView != null)
                            //     {
                            //         LTK268Log.LogInfo($"Showing UI for {closestEntity.Name}");
                            //         UIManager.Instance.ShowEntityUI(closestEntity);
                            //     }
                            //     else
                            //     {
                            //         Debug.LogWarning("Closest entity is null or has no EntityView.");
                            //     }
                            // }
                        }
                    }
                }
                // this.notify_event((int)EventID.Game.OnObjectInOfRange, closestInteractable.Name, objectTransform);
                currentInteractable = closestInteractable;

            }
            else
            {
                currentInteractable = null;
                // this.notify_event((int)EventID.Game.OnObjectOutOfRange);
            }
        }

        #endregion

        #region Debug

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

        #endregion
    }
}