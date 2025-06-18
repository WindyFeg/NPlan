using LKT268.Interface;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour, IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int Level { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }

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
        throw new System.NotImplementedException();
    }
}
