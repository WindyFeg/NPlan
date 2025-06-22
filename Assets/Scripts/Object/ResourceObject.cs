using LKT268.Interface;
using UnityEngine;

public class ResourceObject : MonoBehaviour, IEntity
{
    [SerializeField] private ResourceData resourceData;

    public int Id { get; set; }
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int Level { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }

    void Start()
    {
        LoadData();
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
        StorageManager.Instance.UpdateResource(amount, resourceData.ResourceType);
        // throw new System.NotImplementedException();
    }
    private void LoadData()
    {
        if (resourceData != null)
        {
            Id = resourceData.Id;
            Name = resourceData.Name;
            CurrentHealth = resourceData.CurrentHealth;
            MaxHealth = resourceData.MaxHealth;
        }
        else
        {
            Debug.LogError("ResourceData is not assigned.");
        }
    }
}
