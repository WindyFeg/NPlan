using UnityEngine;

namespace LKT268.Manager
{
    public class NpcManager : MonoBehaviour
    {
        public static NpcManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                // Uncomment if you want this to persist across scenes
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Initialization logic here
        }
    }
}