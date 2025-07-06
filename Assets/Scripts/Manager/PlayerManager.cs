using System.Collections.Generic;
using LTK268.Model.CommonBase;
using UnityEngine;

namespace LTK268.Manager
{
    [System.Serializable]
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }

        [SerializeField]
        private List<FoodBase> listOfFoods = new List<FoodBase>();
        [SerializeField]
        private List<ObjectBase> listOfObjects = new List<ObjectBase>();

        // Expose lists as public properties for code access
        public List<FoodBase> ListOfFoods => listOfFoods;
        public List<ObjectBase> ListOfObjects => listOfObjects;

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