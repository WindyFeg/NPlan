using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;


/// <summary>
/// Represents a weapon object in the game.
/// </summary>
public class WeaponObject : ObjectBase, IObject
{
    #region Serialized Fields
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor to initialize basic stats via inheritance.
    /// </summary>
    public WeaponObject(int id, string name, int maxHealth, int level, int damage)
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

    public void Use(IHuman entity)
    {
        Debug.Log($"Weapon used by {((EntityBase)entity).Name}");
        if (((IEntity)entity).IsPlayer())
        {
            PlayerManager.Instance.PlayerModel.EquipWeapon(this);
        }
        else
        {
            Debug.LogWarning($"Weapon used by non-player entity: {((EntityBase)entity).Name}");
        }
    }
    #endregion
}
