using LTK268.Interface;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

/// <summary>
/// Represents a resource object in the game world that can be interacted with by entities (e.g., the player).
/// On interaction, it supplies resources and decreases its own health. Destroys itself when depleted.
/// </summary>
public class ResourceObject : ObjectBase, IObject
{
    #region Serialized Fields

    [Tooltip("Data configuration for this resource object.")]
    [SerializeField] private ResourceData resourceData;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor to initialize basic stats via inheritance.
    /// </summary>
    /// <param name="id">Unique ID of the object.</param>
    /// <param name="name">Name of the object.</param>
    /// <param name="maxHealth">Maximum health of the object.</param>
    /// <param name="level">Level of the object.</param>
    /// <param name="damage">Damage value (if applicable).</param>
    public ResourceObject(int id, string name, int maxHealth, int level, int damage)
        : base(id, name, maxHealth, level, damage)
    {
    }

    #endregion

    #region Initialization

    /// <summary>
    /// Initializes the resource object from its associated data.
    /// </summary>
    public override void Initialization()
    {
        if (resourceData != null)
        {
            Id = resourceData.Id;
            Name = resourceData.Name;
            MaxHealth = resourceData.MaxHealth;
            CurrentHealth = resourceData.CurrentHealth;
        }
        else
        {
            Debug.LogError("ResourceData is not assigned.");
        }
    }

    #endregion

    #region Interaction Methods

    /// <summary>
    /// Called when an entity interacts with this resource.
    /// </summary>
    /// <param name="target">The interacting entity (e.g., player).</param>
    public new void InteractWithEntity(IEntity target)
    {
        OnInteractedByEntity(target);
    }

    /// <summary>
    /// Processes the interaction effect with the entity, updates storage, and reduces health.
    /// </summary>
    /// <param name="target">The interacting entity.</param>
    public new void OnInteractedByEntity(IEntity target)
    {
        // Update storage with the resource provided
        StorageManager.Instance.UpdateResource(resourceData.SupplyQuantity, resourceData.ResourceType);

        // Reduce health and check for destruction
        CurrentHealth -= 1;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
