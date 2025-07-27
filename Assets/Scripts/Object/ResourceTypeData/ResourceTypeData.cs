using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Scriptable Objects/ResourceTypeData")]
public class ResourceTypeData : ScriptableObject
{
    public ResourceType ResourceType;
    public Sprite Icon;

}
