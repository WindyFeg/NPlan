using LTK268.Interface;
using LTK268.Manager;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using UnityEngine;

public class LumberHouseBlueprint : ObjectBase, IObject
{
    // This class is a placeholder for building blueprints.
    [SerializeField] private GameObject buildingPrefab;
    // [SerializeField] private GameObject parentObject;

    public LumberHouseBlueprint(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }
    public override void Initialization()
    {
        // Initialize the LumberHouseBlueprint with default values or from a data source.
        Id = 1; // Example ID
        Name = "Lumber House Blueprint";
        MaxHealth = 100; // Example max health
        CurrentHealth = MaxHealth;
        Level = 1; // Example level
        Damage = 0; // Blueprints typically don't have damage
        EntityType = EntityType.Object; // Set entity type to Object
    }
    public new void Attack()
    {
        throw new System.NotImplementedException();
    }

    public new void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public new void DroppedBy(IEntity entity)
    {
        throw new System.NotImplementedException();
    }

    public new void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }

    public new void Inspect()
    {
        throw new System.NotImplementedException();
    }

    public new void InteractWithEntity(IEntity target)
    {
        if (PlayerManager.Instance.PlayerModel.HoldItems.Count > 0) return;
        OnInteractedByEntity(target);
    }


    public new void OnInteractedByEntity(IEntity target)
    {
        PickedUpBy((IHuman)target);
    }


    // public new void Use(IHuman entity
    // {
    //     Debug.Log("LumberHouseBlueprint Use");
    // }
}
