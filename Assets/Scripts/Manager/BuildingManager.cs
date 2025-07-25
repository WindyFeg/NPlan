using System.Collections.Generic;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    public class BuildingManager : MonoBehaviour
    {
        #region Public Properties
        public static BuildingManager Instance { get; private set; }
        public List<BuildingBase> BuildingBases => buildingBases;
        #endregion

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
            EntityIDManager.RegisterEntity(building, buildingBases, "Building");
        }

        /// <summary>
        /// Call this from BuildingBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="building"></param>
        public void UnregisterBuilding(BuildingBase building)
        {
            EntityIDManager.UnregisterEntity(building, buildingBases, "Building");
        }
        #endregion
    }
}