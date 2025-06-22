using LKT268.Interface;
using LKT268.Utils;
using UnityEngine;

public class TownHall : MonoBehaviour, IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int Level { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public EntityType EntityType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    void Start()
    {
        Name = "TownHall";
    }
    public void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void LevelUp()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        StorageManager.Instance.UpdateResource(amount, ResourceType.Stone);
    }

    public bool IsNpc()
    {
        throw new System.NotImplementedException();
    }

    public bool IsPlayer()
    {
        throw new System.NotImplementedException();
    }

    public bool IsObject()
    {
        throw new System.NotImplementedException();
    }
}
