using UnityEngine;

namespace LKT268.Manager
{
    public class PopupManager : MonoBehaviour
    {
        public static PopupManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}