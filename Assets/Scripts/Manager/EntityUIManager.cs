using System;
using System.Collections.Generic;
using Common_Utils;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using UI.EntityUI;
using UnityEngine;

namespace LTK268.Manager
{
    public class EntityUIManager : MonoBehaviour
    {
        #region Public Properties
        public static EntityUIManager Instance { get; private set; }
        #endregion

        #region Private Fields
        [SerializeField] private EntityUI entityUIPrefab;

        private EntityUI entityUIInstance;
        private Transform originalParent;
        private int test = 0;

        private Transform lastUIPosition;
        private GameObject lastUIParent;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            entityUIInstance = Instantiate(entityUIPrefab, transform);
            entityUIInstance.gameObject.SetActive(false);
            originalParent = transform;
        }
        #endregion


#if UNITY_EDITOR
        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.F1))
        //     {
        //         EntityInteractable[] interactables = FindObjectsOfType<EntityInteractable>();
        //         if (interactables.Length > 0)
        //         {
        //             ShowEntityUI(interactables[test]); // Just show for the first one for testing
        //         }
        //     }
        //     else if (Input.GetKeyDown(KeyCode.F2))
        //     {
        //         HideEntityUI(null);
        //     }
        //     else if (Input.GetKeyDown(KeyCode.F3))
        //     {
        //         test++;
        //         EntityInteractable[] interactables = FindObjectsOfType<EntityInteractable>();
        //         if (test >= interactables.Length)
        //         {
        //             test = 0; // Reset to first interactable
        //         }
        //         ShowEntityUI(interactables[test], );
        //     }
        // }
#endif
        #region Public Methods
        /// <summary>
        /// Show entity UI on a specific interactable entity.
        /// </summary>
        public void ShowEntityUI(IEntity target, Transform tf = null)
        {
            // Check NULL
            if (tf == null)
            {
                Debug.LogError("Transform is null. Cannot show Entity UI without a valid transform.");
            }
            if (target == null)
            {
                Debug.LogError("Target entity is null. Cannot show Entity UI.");
                return;
            }

            entityUIInstance.ClearRequiredItemData();
            if (target.IsBuilding())
            {
                var objectBase = (BuildingBase)target;
                entityUIInstance.SetRequiredItemData(objectBase.BuildingMaterials);
            }
            else if (target.IsObject())
            {
                var ActionInteractable = new ActionInteractable
                {
                    Key = "E",
                    Description = "Interact"
                };
                entityUIInstance.SetActionData(new ActionInteractable[] { ActionInteractable });
            }
            else if (target.IsNpc())
            {
                var ActionInteractable = new ActionInteractable
                {
                    Key = "E",
                    Description = "Interact"
                };
                entityUIInstance.SetActionData(new ActionInteractable[] { ActionInteractable });
            }
            else
            {
                Debug.LogError("Invalid entity type for EntityUIManager: " + target.GetType());
                return;
            }

            // Set entity UI data
            lastUIPosition = tf;
            lastUIParent = tf.gameObject;
            entityUIInstance.transform.SetParent(tf ? tf : lastUIParent?.transform);
            entityUIInstance.transform.localPosition = new Vector3(0, 0.75f, 0);
            entityUIInstance.transform.localScale = Vector3.one / 100f; // Adjust scale as needed
            entityUIInstance.gameObject.SetActive(true);
        }

        /// <summary>
        /// Hide the entity UI and return it to the UIManager.
        /// </summary>
        public void HideEntityUI(EntityInteractable target)
        {
            if (!entityUIInstance || !entityUIInstance.gameObject.activeSelf) return;

            entityUIInstance.gameObject.SetActive(false);
            entityUIInstance.transform.SetParent(originalParent);
        }
        #endregion
    }
}
