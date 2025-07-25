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
            if (building == null)
            {
                LTK268Log.ManagerError("RegisterBuilding: Building parameter is null");
                return;
            }

            if (!BuildingBases.Contains(building))
            {
                BuildingBases.Add(building);
                LTK268Log.ManagerLog($"Building registered: {building.Name}");
            }
            else
            {
                LTK268Log.ManagerError($"Building is already registered: {building.Name}");
            }
        }

        /// <summary>
        /// Call this from BuildingBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="building"></param>
        public void UnregisterBuilding(BuildingBase building)
        {
            if (building == null)
            {
                LTK268Log.ManagerError("UnregisterBuilding: Building parameter is null");
                return;
            }

            if (BuildingBases.Contains(building))
            {
                BuildingBases.Remove(building);
                LTK268Log.ManagerLog($"Building unregistered: {building.Name}");
            }
            else
            {
                LTK268Log.ManagerError($"Building is not registered: {building.Name}");
            }
        }
        #endregion
    }
}