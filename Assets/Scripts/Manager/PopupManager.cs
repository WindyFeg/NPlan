using System;
using System.Collections.Generic;
using LTK268.Popups;
using UnityEngine;

namespace LTK268.Manager
{
    public class PopupManager : MonoBehaviour
    {
        public static PopupManager Instance { get; private set; }

        private Dictionary<string, BasePopup> popups = new Dictionary<string, BasePopup>();
        private List<BasePopup> showedPopups = new List<BasePopup>();

        public static bool HasPopupShown => Instance != null && Instance.showedPopups.Count > 0;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Load all child popups in the scene
            var popupList = GetComponentsInChildren<BasePopup>(true); // true to include inactive
            foreach (var popup in popupList)
            {
                popup.Hide(); // hide on init
                if (!string.IsNullOrEmpty(popup.name))
                    popups[popup.name] = popup;
                else
                    Debug.LogWarning($"{popup.name} has no PopupName.");
            }

            foreach (var popup in popups)
            {
                Debug.Log($">> {popup.Key}: {popup.Value}");
            }
        }

        public BasePopup Find(string popupName)
        {
            return popups.TryGetValue(popupName, out var popup) ? popup : null;
        }

        public BasePopup Show(string popupName, params object[] args)
        {
            if (popups.TryGetValue(popupName, out var popup))
            {
                popup.ShowWithArgs(args);
                if (!showedPopups.Contains(popup))
                    showedPopups.Add(popup);

                return popup;
            }
            return null;
        }


        public void Hide(string popupName)
        {
            if (popups.TryGetValue(popupName, out var popup))
            {
                popup.Hide();
                showedPopups.Remove(popup);
            }
        }

        public void HideAll()
        {
            foreach (var popup in showedPopups)
            {
                popup.Hide();
            }
            showedPopups.Clear();
        }
        
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Show(
                    PopupType.Template,
                    "Are you sure you want to close the popup?",
                    "Có",
                    "Kó"
                );
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                Show(
                    PopupType.Ok,
                    "Are you ok?",
                    "Super ok!"
                );
            }
        }
#endif
    }
}
