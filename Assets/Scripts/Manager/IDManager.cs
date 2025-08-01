using System.Collections.Generic;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

namespace LTK268.Manager
{
    /// <summary>
    /// Base class for managing entity IDs automatically
    /// </summary>
    public abstract class IDManager<T> : MonoBehaviour where T : EntityBase
    {
        #region Protected Fields
        [SerializeField] protected List<T> entities = new List<T>();
        protected int nextId = 1;
        #endregion

        #region Public Properties
        public List<T> Entities => entities;
        #endregion

        #region Protected Methods
        /// <summary>
        /// Registers an entity and assigns an ID if needed
        /// </summary>
        /// <param name="entity">The entity to register</param>
        protected virtual void RegisterEntity(T entity)
        {
            if (entity == null)
            {
                LTK268Log.ManagerError($"RegisterEntity: {typeof(T).Name} parameter is null");
                return;
            }

            if (!entities.Contains(entity))
            {
                // Check if entity already has an ID
                if (entity.Id == 0)
                {
                    // Assign next available ID
                    entity.Id = GetNextAvailableId();
                    LTK268Log.ManagerLog($"{typeof(T).Name} registered with new ID: {entity.Id} - {entity.Name}");
                }
                else
                {
                    // Entity already has an ID, use it
                    LTK268Log.ManagerLog($"{typeof(T).Name} registered with existing ID: {entity.Id} - {entity.Name}");
                }

                entities.Add(entity);
            }
            else
            {
                LTK268Log.ManagerError($"{typeof(T).Name} is already registered: {entity.Name}");
            }
        }

        /// <summary>
        /// Unregisters an entity
        /// </summary>
        /// <param name="entity">The entity to unregister</param>
        protected virtual void UnregisterEntity(T entity)
        {
            if (entity == null)
            {
                LTK268Log.ManagerError($"UnregisterEntity: {typeof(T).Name} parameter is null");
                return;
            }

            if (entities.Remove(entity))
            {
                LTK268Log.ManagerLog($"{typeof(T).Name} unregistered: {entity.Name}");
            }
            else
            {
                LTK268Log.ManagerError($"{typeof(T).Name} was not registered: {entity.Name}");
            }
        }

        /// <summary>
        /// Gets the next available ID by finding the highest ID and adding 1
        /// </summary>
        /// <returns>The next available ID</returns>
        protected virtual int GetNextAvailableId()
        {
            int maxId = 0;
            
            // Find the highest ID among all entities
            foreach (var entity in entities)
            {
                if (entity.Id > maxId)
                {
                    maxId = entity.Id;
                }
            }

            // Return the next ID
            return maxId + 1;
        }

        /// <summary>
        /// Checks if an ID is already in use
        /// </summary>
        /// <param name="id">The ID to check</param>
        /// <returns>True if the ID is already in use</returns>
        protected virtual bool IsIdInUse(int id)
        {
            foreach (var entity in entities)
            {
                if (entity.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
} 