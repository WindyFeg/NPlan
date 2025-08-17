using LTK268.Interface;
using LTK268.Manager;
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

    #region Unity Methods
    void Start()
    {
        if (ObjectData == null)
        {
            Debug.LogError("ObjectData is not assigned in ResourceObject.");
            return;
        }

        Initialization();
        // Register the resource object with the ResourceManager
        ResourceManager.Instance.RegisterObject(this);
    }

    private void OnValidate() {
        if (EntitySpriteRenderer == null)
        {
            EntitySpriteRenderer = GetComponent<SpriteRenderer>();
            if (EntitySpriteRenderer == null)
            {
                EntitySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            }            
        }    
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Initializes the resource object from its associated data.
    /// </summary>
    public override void Initialization()
    {
        if (ObjectData != null)
        {
            Id = ObjectData.id;
            Name = ObjectData.Name;
            MaxHealth = ObjectData.maxHealth;
            CurrentHealth = ObjectData.maxHealth;
            EntityType = EntityType.Object;
        }
        else
        {
            Debug.LogError("ResourceData is not assigned.");
        }
    }

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
        if (PlayerManager.Instance.PlayerModel.HoldItems.Count > 0) return;
        PickedUpBy((IHuman)target);
    }

    #endregion
}
