using System.Collections.Generic;
using Common_Utils;
using LTK268;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Popups;
using LTK268.Utils;
using Unity.VisualScripting;
using UnityEngine;

public class TownHall : BuildingBase, IBuilding, IBuildingStorage
{
    #region Public Properties


    #endregion

    #region Private Field
    private GameObject currentModel;
    private EntityInteractable entityInteractable;

    public Dictionary<GameObject, int> StoredItems { get; set; } = new Dictionary<GameObject, int>();
    #endregion

    public override void Initialization()
    {
        if (currentModel != null)
        {
            Destroy(currentModel);
        }
        Id = ObjectData.id;
        Name = ObjectData.Name;
        MaxHealth = ObjectData.maxHealth;
        Level = ObjectData.level;
        Damage = ObjectData.damage;
        CurrentHealth = MaxHealth;
        EntityType = EntityType.Building;
        BuildingMaterials = new SerializableDictionary<Common_Utils.InteractableData, int>();
        foreach (var item in ObjectData.interactableData)
        {
            BuildingMaterials.Add(item, 0);
        }
        BuildingState = BuildingState.Building;

        // Initialize building materials if needed;
        // BuildingMaterials = buildingData.buildingMaterials;
        currentModel = Instantiate(ObjectData.buildingPrefabs, this.transform);
    }
    public TownHall(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }
    void Start()
    {
        Initialization();
        entityInteractable = GetComponent<EntityInteractable>();
        // BuildingManager.Instance.TownHall = this;
        BuildingManager.Instance.RegisterBuilding(this);
    }

    #region Public Methods
    public new void InteractWithEntity(IEntity target)
    {
        OnInteractedByEntity(target);
    }
    public new void OnInteractedByEntity(IEntity target)
    {
        EntityResrouceCheck(target);

        if (BuildingState == BuildingState.Building)
        {
            AddBuildingMaterial((IHuman)target);
        }
        else if (BuildingState == BuildingState.Complete)
        {
            StoreItem((IHuman)target);
        }
        else
        {
            PopupManager.Instance.Show(PopupType.Ok, $"This Building state is {BuildingState} and can't be interacted", "OK");
        }
    }

    private void EntityResrouceCheck(IEntity entity)
    {
        if (entity.IsNpc())
        {
            var model = (NpcModel)entity;
            if (model.HoldItems.Count == 0)
            {
                Debug.LogWarning("NPC has no items to store");
                return;
            }
        }
        else if (entity.IsPlayer())
        {
            var playerModel = (PlayerModel)entity;
            if (playerModel.HoldItems.Count == 0)
            {
                Debug.LogWarning("Player has no items to store");
                PopupManager.Instance.Show(
                    PopupType.Ok,
                    $"Player has no items to store",
                    "OK"
                );
                return;
            }
        }
        else
        {
            Debug.LogError("Invalid entity type interacting with Town Hall");
            return;
        }
    }

    // public void Upgrade()
    // {
    //     if (ObjectData.nextBuildingData == null)
    //     {
    //         Debug.Log("No next building data");
    //         return;
    //     }
    //     ObjectData = ObjectData.nextBuildingData;
    //     Initialization();

    // }
    /// <summary>
    /// Crafting Blueprint
    /// </summary>
    public void CraftingBlueprint()
    {
        // Show crafting Blueprint UI
        LTK268Log.LogNotImplement(this);
    }

    public void StoreItem(IHuman human)
    {
        var item = human.RemoveHoldItem();
        if (item != null)
        {
            if (StoredItems.ContainsKey(item))
            {
                StoredItems[item]++;
            }
            else
            {
                StoredItems.Add(item, 1);
            }
            LTK268Log.LogInfo($"Item {item.name} stored in {Name}. Total: {StoredItems[item]}");
        }
        else
        {
            LTK268Log.LogWarning("No item to store");
        }
    }

    public new void PickedUpBy(IHuman human)
    {
        OnInteractedByEntity((IEntity)human);
    }
    #endregion

}
