// using System.Collections.Generic;
// using LTK268.Model.CommonBase;
// using LTK268.Utils;

// namespace LTK268.Manager
// {
//     /// <summary>
//     /// Utility class for managing entity IDs automatically
//     /// </summary>
//     public static class EntityIDManager
//     {
//         /// <summary>
//         /// Registers an entity and assigns an ID if needed
//         /// </summary>
//         /// <typeparam name="T">Type of entity</typeparam>
//         /// <param name="entity">The entity to register</param>
//         /// <param name="entities">List of existing entities</param>
//         /// <param name="entityTypeName">Name of the entity type for logging</param>
//         public static void RegisterEntity<T>(T entity, List<T> entities, string entityTypeName) where T : EntityBase
//         {
//             if (entity == null)
//             {
//                 LTK268Log.ManagerError($"RegisterEntity: {entityTypeName} parameter is null");
//                 return;
//             }

//             if (!entities.Contains(entity))
//             {
//                 // Check if entity already has an ID
//                 if (entity.Id == 0)
//                 {
//                     // Assign next available ID
//                     entity.Id = GetNextAvailableId(entities);
//                     LTK268Log.ManagerLog($"{entityTypeName} registered with new ID: {entity.Id} - {entity.Name}");
//                 }
//                 else
//                 {
//                     // Entity already has an ID, use it
//                     LTK268Log.ManagerLog($"{entityTypeName} registered with existing ID: {entity.Id} - {entity.Name}");
//                 }

//                 entities.Add(entity);
//             }
//             else
//             {
//                 LTK268Log.ManagerError($"{entityTypeName} is already registered: {entity.Name}");
//             }
//         }

//         /// <summary>
//         /// Unregisters an entity
//         /// </summary>
//         /// <typeparam name="T">Type of entity</typeparam>
//         /// <param name="entity">The entity to unregister</param>
//         /// <param name="entities">List of existing entities</param>
//         /// <param name="entityTypeName">Name of the entity type for logging</param>
//         public static void UnregisterEntity<T>(T entity, List<T> entities, string entityTypeName) where T : EntityBase
//         {
//             if (entity == null)
//             {
//                 LTK268Log.ManagerError($"UnregisterEntity: {entityTypeName} parameter is null");
//                 return;
//             }

//             if (entities.Remove(entity))
//             {
//                 LTK268Log.ManagerLog($"{entityTypeName} unregistered: {entity.Name}");
//             }
//             else
//             {
//                 LTK268Log.ManagerError($"{entityTypeName} was not registered: {entity.Name}");
//             }
//         }

//         /// <summary>
//         /// Gets the next available ID by finding the highest ID and adding 1
//         /// </summary>
//         /// <typeparam name="T">Type of entity</typeparam>
//         /// <param name="entities">List of entities to check</param>
//         /// <returns>The next available ID</returns>
//         public static int GetNextAvailableId<T>(List<T> entities) where T : EntityBase
//         {
//             int maxId = 0;

//             // Find the highest ID among all entities
//             foreach (var entity in entities)
//             {
//                 if (entity.Id > maxId)
//                 {
//                     maxId = entity.Id;
//                 }
//             }

//             // Return the next ID
//             return maxId + 1;
//         }

//         /// <summary>
//         /// Checks if an ID is already in use
//         /// </summary>
//         /// <typeparam name="T">Type of entity</typeparam>
//         /// <param name="id">The ID to check</param>
//         /// <param name="entities">List of entities to check</param>
//         /// <returns>True if the ID is already in use</returns>
//         public static bool IsIdInUse<T>(int id, List<T> entities) where T : EntityBase
//         {
//             foreach (var entity in entities)
//             {
//                 if (entity.Id == id)
//                 {
//                     return true;
//                 }
//             }
//             return false;
//         }
//     }
// } 