using UnityEngine;

namespace LTK268.Manager
{
    public class TutorialManager : MonoBehaviour
    {
        // Singleton instance (optional)
        public static TutorialManager Instance { get; private set; }

        private void Awake()
        {
            // Singleton pattern (optional)
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

    }
}