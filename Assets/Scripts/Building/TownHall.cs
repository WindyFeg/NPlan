using LTK268.Interface;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

public class TownHall : BuildingBase, IBuilding
{
    #region Public Properties
    #endregion

    #region Private Field
    #endregion
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
        Debug.Log("Town Hall Interacted");
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
}
