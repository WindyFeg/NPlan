using UnityEngine;

namespace LKT268.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }

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