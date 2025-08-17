using System;
using System.Collections.Generic;
using LTK268.Define;
using LTK268.Popups;
using LTK268.Utils;
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
                if (popup == null)
                {
                    LTK268Log.ManagerError("PopupManager: Found null popup in GetComponentsInChildren");
                    continue;
                }

                popup.Hide(); // hide on init
                if (!string.IsNullOrEmpty(popup.name))
                {
                    popups[popup.name] = popup;
                    LTK268Log.ManagerLog($"Popup registered: {popup.name}");
                }
                else
                {
                    LTK268Log.ManagerError($"Popup has no name: {popup.GetType().Name}");
                }
            }

            LTK268Log.ManagerLog($"PopupManager initialized with {popups.Count} popups");
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
                PopupManager.Instance.Show(
                    PopupType.Template,
                    "Are you sure you want to close the popup?",
                    "Có",
                    "Kó"
                );
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                popups.TryGetValue(PopupType.Toast, out var popup);
                if (popup != null)
                {
                    var toastPopup = (ToastPopup)popup;
                    toastPopup.SetFontSize(TextSize.ExtraLarge); // Set custom duration
                    toastPopup.SetDisplayDuration(3f); // Set custom duration
                    toastPopup.SetBackgroundSize(300, 100); // Set custom background size
                    toastPopup.ShowWithArgs(new object[] { "This is a custom toast message!" });
                }
                else
                {
                    Debug.LogWarning("Can't found popup!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                // PopupManager.Instance.Show(
                //     PopupType.Toast,
                //     "Level up!"
                // );
                popups.TryGetValue(PopupType.Toast, out var popup);
                if (popup != null)
                {
                    var toastPopup = (ToastPopup)popup;
                    toastPopup.ShowWithArgs(new object[] { "Level Up!" });
                    toastPopup.ShowWithArgs(new object[] { "Warning", "Low Health" });
                    toastPopup.ShowWithArgs(new object[] { "Disconnected", "Reconnecting..." });
                }
                else
                {
                    Debug.LogWarning("Can't found popup!");
                }
            }
        }
#endif
    }
}
