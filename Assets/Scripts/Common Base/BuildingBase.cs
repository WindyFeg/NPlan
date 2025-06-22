using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

namespace LKT268.Model.CommonBase
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

        #region Public Properties

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
    }
}