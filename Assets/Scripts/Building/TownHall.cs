using LKT268.Interface;
using LKT268.Model.CommonBase;
using LKT268.Utils;
using UnityEngine;

public class TownHall : BuildingBase, IBuilding
{
    public TownHall(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }
    public new void InteractWithEntity(IEntity target)
    {
        Debug.Log("Town Hall Interacted");
        OnInteractedByEntity(target);
    }
    public new void OnInteractedByEntity(IEntity target)
    {
        Debug.Log("Town Hall Interacted");
    }
}
