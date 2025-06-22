using LKT268.Interface;
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
}
