using System;
using Common_Utils;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using UI.EntityUI;
using UnityEngine;

namespace LTK268.Manager
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private EntityUI entityUIPrefab;

        private EntityUI entityUIInstance;
        private Transform originalParent;
        private int test = 0;

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

        /// <summary>
        /// Show entity UI on a specific interactable entity.
        /// </summary>
        public void ShowEntityUI(EntityInteractable target)
        {
            if (!target) return;

            entityUIInstance.transform.SetParent(target.transform);
            entityUIInstance.transform.localPosition = new Vector3(0, target.YPositionOffset, 0);
            entityUIInstance.SetActionData(target.Actions);
            entityUIInstance.SetRequiredItemData(target.RequiredItems);
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

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                EntityInteractable[] interactables = FindObjectsOfType<EntityInteractable>();
                if (interactables.Length > 0)
                {
                    ShowEntityUI(interactables[test]); // Just show for the first one for testing
                }
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                HideEntityUI(null);
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                test++;
                EntityInteractable[] interactables = FindObjectsOfType<EntityInteractable>();
                if (test >= interactables.Length)
                {
                    test = 0; // Reset to first interactable
                }
                ShowEntityUI(interactables[test]);
            }
        }
#endif
    }
}
