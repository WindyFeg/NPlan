using LKT268.Model.CommonBase;
using UnityEngine;
using LKT268.Interface;
using LKT268.Utils;

public class PlayerModel : HumanBase
{
    public PlayerModel(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }

    public override void Initialization()
    {
        // This is temp initialization all if the init will be handle by game manager
        Id = 1;
        Name = "Default Player";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Level = 1;
        Damage = 10;
        Armor = 0;
        EntityType = EntityType.Player;
    }
}
