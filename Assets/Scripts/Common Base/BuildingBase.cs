using System.Collections.Generic;
using Common_Utils;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Model.CommonBase
{
    public class BuildingBase : ObjectBase, IBuilding
    {
        #region Private Field
        [SerializeField] BuildingType buildingType = BuildingType.None;
        [SerializeField] BuildingSize buildingSize = BuildingSize.None;
        [SerializeField] private NPCBase assignedWorker;
        [SerializeField] private List<EntityBase> residents = new List<EntityBase>();
        [SerializeField] private SerializableDictionary<InteractableData, int> buildingMaterials = new SerializableDictionary<InteractableData, int>();
        [SerializeField] private SerializableDictionary<ResourceType, int> buildingStorage = new SerializableDictionary<ResourceType, int>();
        [SerializeField] private BuildingState buildingState = BuildingState.None;
        #endregion

        #region Public Properties
        public BuildingType BuildingType
        {
            get => buildingType;
            set => buildingType = value;
        }
        public BuildingSize BuildingSize
        {
            get => buildingSize;
            set => buildingSize = value;
        }
        public NPCBase AssignedWorker
        {
            get => assignedWorker;
            set => assignedWorker = value;
        }
        public SerializableDictionary<InteractableData, int> BuildingMaterials
        {
            get => buildingMaterials;
            set => buildingMaterials = value;
        }
        public SerializableDictionary<ResourceType, int> BuildingStorage
        {
            get => buildingStorage;
            set => buildingStorage = value;
        }
        public BuildingState BuildingState
        {
            get => buildingState;
            set => buildingState = value;
        }
        public List<EntityBase> Residents
        {
            get => residents;
            set => residents = value;
        }
        #endregion

        #region Public Constructors
        public BuildingBase(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
        {
        }
        #endregion

        #region Public Unity Methods
        void OnValidate()
        {
            if (!gameObject.CompareTag("Building"))
            {
                gameObject.tag = "Building";
            }
        }

        void Start()
        {
            BuildingManager.Instance.RegisterBuilding(this);
        }

        void OnDestroy()
        {
            BuildingManager.Instance.UnregisterBuilding(this);
        }
        #endregion

        #region Public Methods

        #endregion
        public void Build(List<ObjectBase> buildingObject)
        {
            throw new System.NotImplementedException();
        }

        public void Demolish()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void Upgrade(List<ObjectBase> buildingObject)
        {
            throw new System.NotImplementedException();
        }
        public new void InteractWithEntity(IEntity target)
        {
            OnInteractedByEntity(target);
        }
        public new void OnInteractedByEntity(IEntity target)
        {
            LTK268Log.LogNotImplement(this);
        }

        public void Repair()
        {
            throw new System.NotImplementedException();
        }

        public void AssignWorker(NPCBase worker)
        {
            throw new System.NotImplementedException();
        }
    }
}