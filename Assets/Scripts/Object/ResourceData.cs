using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Scriptable Objects/ResourceData")]
public class ResourceData : ScriptableObject
{
    public ResourceType ResourceType;
    public int Id;
    public string Name;
    public int CurrentHealth;
    public int MaxHealth;


}
