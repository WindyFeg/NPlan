using System.Collections.Generic;
using LTK268;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

public class TownHall : BuildingBase, IBuilding
{
    #region Public Properties
    #endregion

    #region Private Field
    [SerializeField] private List<GameObject> spriteModelPresets;
    [SerializeField] private List<GameObject> meshModelPresets;

    [SerializeField] private BuildingData buildingData;
    #endregion

    public override void Initialization()
    {
        Id = buildingData.id;
        Name = buildingData.buildingName;
        MaxHealth = buildingData.maxHealth;
        Level = buildingData.level;
        Damage = buildingData.damage;
        CurrentHealth = MaxHealth;
    }
    public TownHall(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }
    #region Public Methods
    public new void InteractWithEntity(IEntity target)
    {
        Debug.Log("Town Hall Interacted");
        OnInteractedByEntity(target);
    }
    public new void OnInteractedByEntity(IEntity target)
    {
        //check if player has enough resources
        Debug.Log("Town Hall Interacted");
        Upgrade();
    }
    public void Upgrade()
    {
        SetUpModel();
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
    #endregion
    #region Private Methods
    private void SetUpModel()
    {
        if (spriteModelPresets == null || meshModelPresets == null)
        {
            return;
        }
        for (int i = 0; i < spriteModelPresets.Count; i++)
        {
            spriteModelPresets[i].sr().sprite = buildingData.spritePresets[i];
        }
        for (int i = 0; i < meshModelPresets.Count; i++)
        {
            meshModelPresets[i].mf().mesh = buildingData.modelPresets[i];
        }
    }
    #endregion
}
