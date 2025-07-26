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
    [SerializeField] private BuildingData buildingData;
    private GameObject currentModel;
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
    #endregion
    #region Private Methods
    private void SetUpModel()
    {

    }
    #endregion
}
