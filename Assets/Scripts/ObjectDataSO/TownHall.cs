using System.Collections.Generic;
using Common_Utils;
using LTK268;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
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
        BuildingMaterials = new Dictionary<InteractableData, int>();
        foreach (var item in ObjectData.interactableData)
        {
            BuildingMaterials.Add(item, 0);

        }

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
        BuildingManager.Instance.TownHall = this;
    }

    #region Public Methods
    public new void InteractWithEntity(IEntity target)
    {
        OnInteractedByEntity(target);
    }
    public new void OnInteractedByEntity(IEntity target)
    {
        //check if player has enough resources
        if (PlayerManager.Instance.PlayerModel.HoldItems.Count == 0) return;
        Debug.Log("Town Hall Interacted");
        AddMaterialToBuilding();
        // if (this)
    }
    public void Upgrade()
    {
        if (ObjectData.nextBuildingData == null)
        {
            Debug.Log("No next building data");
            return;
        }
        ObjectData = ObjectData.nextBuildingData;
        Initialization();

    }
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
    #endregion
    #region Private Methods

    /// <summary>
    /// Set interactable data for the Town Hall.
    /// Could be used to Update when the building is upgraded or changed.
    /// </summary>
    private void AddMaterialToBuilding()
    {
        ObjectBase item = PlayerManager.Instance.PlayerModel.HoldItems[0].gameObject.GetComponent<ObjectBase>();
        foreach (var material in BuildingMaterials)
        {   
            Debug.Log(material.Key.objectData.resourceType);
            Debug.Log(item.ObjectData.resourceType);
            if (material.Key.objectData.resourceType == item.ObjectData.resourceType)
            {
                BuildingMaterials[material.Key] += 1;
                PlayerManager.Instance.PlayerModel.RemoveHoldItem();
                LTK268Log.LogInfo($"Added {item.Name} to {Name}. Total: {BuildingMaterials[material.Key]}");
                if (CheckComplete())
                {
                    Upgrade();
                }
                return;
            }
        }
    }
    private bool CheckComplete()
    {
        foreach (var material in BuildingMaterials)
        {
            if (material.Value < material.Key.cost)
            {
                return false;
            }
        }
        return true;
    }

    #endregion
}
