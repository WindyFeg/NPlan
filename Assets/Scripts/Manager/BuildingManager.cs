using System.Collections.Generic;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    public class BuildingManager : IDManager<BuildingBase>
    {
        #region Public Properties
        public static BuildingManager Instance { get; private set; }
        public List<BuildingBase> BuildingBases => buildingBases;
        // public TownHall TownHall
        // {
        //     get => townHall;
        //     set
        //     {
        //         if (townHall == null)
        //         {
        //             townHall = value;
        //         }
        //         else
        //         {
        //             LTK268Log.LogFalseConfig("Town Hall already assigned", this);
        //         }
        //     }
        // }
        #endregion

        #region Private Properties
        [SerializeField] private List<BuildingBase> buildingBases = new List<BuildingBase>();
        // [SerializeField] private TownHall townHall;
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
            RegisterEntity(building);
        }

        /// <summary>
        /// Call this from BuildingBase's OnDisable/OnDestroy
        /// </summary>
        /// <param name="building"></param>
        public void UnregisterBuilding(BuildingBase building)
        {
            UnregisterEntity(building);
        }
        #endregion
    }
}