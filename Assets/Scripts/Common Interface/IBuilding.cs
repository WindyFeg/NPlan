using System.Collections.Generic;
using LTK268.Model.CommonBase;
using UnityEngine;

namespace LTK268.Interface
{

    public interface IBuilding : IObject
    {

        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as building
        /// </summary>
        void Build(List<ObjectBase> buildingObject);
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as Upgrade
        /// </summary>
        void Upgrade(List<ObjectBase> buildingObject);
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as Destroy
        /// </summary>
        void Demolish();
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as moving
        /// </summary>
        void Move();
        /// <summary>
        /// Defines the basic operations that can be performed on a building entity,
        /// such as repairing
        /// </summary>
        void Repair();

        /// <summary>
        /// Assigns a worker to the building for tasks such as construction, repair, or operation.
        /// </summary>
        /// <param name="worker"></param>
        void AssignWorker(NPCBase worker);
    }

    public interface IBuildingStorage
    {
        Dictionary<GameObject, int> StoredItems { get; set; }

        /// <summary>
        /// Stores an item in the building's storage.
        /// </summary>
        void StoreItem(IHuman item);
    }
}