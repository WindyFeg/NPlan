using System.Collections.Generic;
using LTK268;
using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingTable : BuildingBase, IBuilding
{
    #region Public Properties
    #endregion

    #region Private Field
    private CraftingTableDisplay craftingTableDisplay;
    private GameObject currentModel;
    private bool isUsing = false;
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
        craftingTableDisplay = GetComponent<CraftingTableDisplay>();
        this.GetComponent<PlayerInput>().DeactivateInput();
        // Initialize building materials if needed;
        // BuildingMaterials = buildingData.buildingMaterials;
        // currentModel = Instantiate(ObjectData.buildingPrefabs, this.transform);
    }
    public CraftingTable(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
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
        if (target.IsPlayer())
        {
            if (isUsing) return;
            isUsing = true;
            craftingTableDisplay.ShowItem();
            this.GetComponent<PlayerInput>().ActivateInput();
        }
    }
    public void OnSubmit()
    {
        PlayerManager.Instance.PlayerModel.GetComponent<IHuman>().AddHoldItem(craftingTableDisplay.GetCurrentItem());
        isUsing = false;
        this.GetComponent<PlayerInput>().DeactivateInput();
        craftingTableDisplay.ClearPreview();
    }
    public void OnNext()
    {
        craftingTableDisplay.NextItem();
    }
    public void OnPrevious()
    {
        craftingTableDisplay.PrevItem();
    }
    public void OnCancel()
    {
        isUsing = false;
        this.GetComponent<PlayerInput>().DeactivateInput();
        craftingTableDisplay.ClearPreview();
    }

    /// <summary>
    /// Crafting Blueprint
    /// </summary>
    #endregion
    #region Private Methods
    #endregion
}
