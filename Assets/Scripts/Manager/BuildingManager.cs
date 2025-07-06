using System.Collections.Generic;
using LTK268.Model.CommonBase;
using UnityEngine;

namespace LTK268.Manager
{
    public class BuildingManager : MonoBehaviour
    {
        #region Public Properties
        public static BuildingManager Instance { get; private set; }
        #endregion
        public List<BuildingBase> BuildingBases => buildingBases;
        #region Private Properties
        [SerializeField] private List<BuildingBase> buildingBases = new List<BuildingBase>();
        #endregion

        #region Unity Methods
        private void Awake()
        {
            // Ensure only one instance exists
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Call this from BuildingBase's Awake/OnEnable
        /// </summary>
        /// <param name="building"></param>
        public void RegisterBuilding(BuildingBase building)
        {
            if (!BuildingBases.Contains(building))
            {
                BuildingBases.Add(building);
            }
        }

        /// <summary>
        /// Call this from BuildingBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="building"></param>
        public void UnregisterBuilding(BuildingBase building)
        {
            BuildingBases.Remove(building);
        }
        #endregion
    }
}