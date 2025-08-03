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
        Debug.Log("LumberHouseBlueprint InteractWithEntity");
        OnInteractedByEntity(target);
        throw new System.NotImplementedException();
    }

    public new bool IsNpc()
    {
        throw new System.NotImplementedException();
    }

    public new bool IsObject()
    {
        throw new System.NotImplementedException();
    }

    public new bool IsPlayer()
    {
        throw new System.NotImplementedException();
    }

    public new void LevelUp()
    {
        throw new System.NotImplementedException();
    }

    public new void OnInteractedByEntity(IEntity target)
    {
        Use();
        throw new System.NotImplementedException();
    }

    public new void PickedUpBy(IHuman entity)
    {
        throw new System.NotImplementedException();
    }

    public new void Spawn()
    {
        throw new System.NotImplementedException();
    }

    public new void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public new void Use()
    {
        Debug.Log("LumberHouseBlueprint Use");
        if (ObjectData.buildingPrefabs == null)
        {
            return;
        }
        GameObject newBuilding = Instantiate(ObjectData.buildingPrefabs, PlayerManager.Instance.PlayerModel.transform.position, Quaternion.identity);
        // newBuilding.transform.parent = parentObject.transform;
    }
}
