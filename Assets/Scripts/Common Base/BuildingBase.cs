using System.Collections.Generic;
using Common_Utils;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Popups;
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
        [SerializeField] private SerializableDictionary<Common_Utils.InteractableData, int> buildingMaterials = new SerializableDictionary<Common_Utils.InteractableData, int>();
        [SerializeField] private SerializableDictionary<LTK268.Utils.ResourceType, int> buildingStorage = new SerializableDictionary<LTK268.Utils.ResourceType, int>();
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
        public SerializableDictionary<Common_Utils.InteractableData, int> BuildingMaterials
        {
            get => buildingMaterials;
            set => buildingMaterials = value;
        }
        public SerializableDictionary<LTK268.Utils.ResourceType, int> BuildingStorage
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

        public void Upgrade()
        {
            if (ObjectData.nextBuildingData == null)
            {
                Debug.Log("No next building data");
                return;
            }
            ObjectData = ObjectData.nextBuildingData;
            Initialization();
            // throw new System.NotImplementedException();
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
        public void AddBuildingMaterial(IHuman target)
        {
            if (BuildingMaterials.Count == 0)
            {
                LTK268Log.LogWarning("No building materials defined for this building.");
                return;
            }
            ObjectBase oldItem = target.HoldItems[0].gameObject.GetComponent<ObjectBase>();

            var humanBase = target as HumanBase;
            if (humanBase != null)
            {
                var objectBase = humanBase.RemoveHoldItem().GetComponent<ObjectBase>();
                foreach (var material in BuildingMaterials)
                {
                    if (material.Value > material.Key.cost)
                    {
                        // Send back the item to the human
                        humanBase.AddHoldItem(objectBase.gameObject);
                        PopupManager.Instance.Show(
                            PopupType.Ok,
                            $"You can't use {objectBase.ObjectData.Name}",
                            "Close"
                        );
                        return;
                    }

                    // Add the material to the building
                    if (material.Key.objectData.resourceType == objectBase.ObjectData.resourceType && material.Value < material.Key.cost)
                    {
                        BuildingMaterials[material.Key] += 1;
                        if (CheckComplete())
                        {
                            Upgrade();
                        }
                        return;
                    }
                    else
                    {
                        // Send back the item to the human
                        continue;
                    }
                }
                humanBase.AddHoldItem(objectBase.gameObject);
                LTK268Log.LogWarning($"Material {objectBase.ObjectData.resourceType} does not match required types");
            }
        }
            #region Private Methods

    /// <summary>
    /// Set interactable data for the Town Hall.
    /// Could be used to Update when the building is upgraded or changed.
    /// </summary>

    private bool CheckComplete()
    {
        foreach (var material in BuildingMaterials)
        {
            if (material.Value < material.Key.cost)
            {
                return false;
            }
        }
        return true;
    }

    #endregion
        
    }
}