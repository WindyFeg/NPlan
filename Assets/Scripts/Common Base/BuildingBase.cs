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
        #endregion

        #region Public Properties
        public BuildingType BuildingType
        {
            get => buildingType;
            set => buildingType = value;
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
        public void Build()
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
    }
}