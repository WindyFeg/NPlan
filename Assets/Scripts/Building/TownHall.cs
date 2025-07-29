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
    [SerializeField] private BuildingData buildingData;
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
        Id = buildingData.id;
        Name = buildingData.buildingName;
        MaxHealth = buildingData.maxHealth;
        Level = buildingData.level;
        Damage = buildingData.damage;
        CurrentHealth = MaxHealth;
        currentModel = Instantiate(buildingData.buildingPrefabs, this.transform);
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
        Debug.Log("Town Hall Interacted");
        // if (this)
        Upgrade();
    }
    public void Upgrade()
    {
        if (buildingData.nextBuildingData == null)
        {
            Debug.Log("No next building data");
            return;
        }
        buildingData = buildingData.nextBuildingData;
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
    private void SetInteractableData()
    {
        entityInteractable.SetInteractableData(buildingData.interactableDatas);
    }
    private void SetUpModel()
    {

    }

    #endregion
}
