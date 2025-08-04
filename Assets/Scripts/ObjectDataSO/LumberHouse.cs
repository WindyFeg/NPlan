using System.Collections.Generic;
using LTK268;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

public class LumberHouse : BuildingBase, IBuilding
{
    #region Public Properties
    #endregion

    #region Private Field
    private GameObject currentModel;
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

        // Initialize building materials if needed;
        // BuildingMaterials = buildingData.buildingMaterials;
        currentModel = Instantiate(ObjectData.buildingPrefabs, this.transform);
    }
    public LumberHouse(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }
    void Start()
    {
        Initialization();
        BuildingManager.Instance.RegisterBuilding(this);
        
    }
    #region Public Methods
    public new void InteractWithEntity(IEntity target)
    {
        OnInteractedByEntity(target);
    }
    public new void OnInteractedByEntity(IEntity target)
    {
        //check if player has enough resources
        // if (PlayerManager.Instance.PlayerModel.HoldItems.Count == 0) return;
        if (target.IsNpc())
        {
            var model = (NpcModel)target;
            if (model.HoldItems.Count == 0)
            {
                Debug.LogWarning("NPC has no items to store");
                return;
            }
        }
        else if (target.IsPlayer())
        {
            var playerModel = (PlayerModel)target;
            if (playerModel.HoldItems.Count == 0)
            {
                Debug.LogWarning("Player has no items to store");
                return;
            }
        }
        else
        {
            Debug.LogError("Invalid entity type interacting with Town Hall");
            return;
        }


        AddBuildingMaterial((IHuman)target);
    }

    /// <summary>
    /// Crafting Blueprint
    /// </summary>
    public void CraftingBlueprint()
    {
        // Show crafting Blueprint UI
        LTK268Log.LogNotImplement(this);
    }
    #endregion
    #region Private Methods
    #endregion
}
