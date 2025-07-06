using LTK268.Interface;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

public class TownHall : BuildingBase
{
    public TownHall(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }
    public new void InteractWithEntity(IEntity target)
    {
        OnInteractedByEntity(target);
    }
    public new void OnInteractedByEntity(IEntity target)
    {
        
    }
}
