using System.Collections.Generic;
using Common_Utils;
using UnityEngine;
public enum Requirements
{
    None,
    HasTownHall_1,
    HasTownHall_2,

}
[CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/ObjectData")]
public class ObjectData : ScriptableObject
{
    [Header("Object Data")]
    public int id;
    public string Name;
    public int maxHealth;
    public int level;
    public int damage;

    [Header("Resource Types")]
    public ResourceType resourceType;
    public Sprite resourceIcon;

    [Header("Building Properties")]
    public Requirements requirements;
    public GameObject buildingPrefabs;
    public ObjectData nextBuildingData;

    [Header("Object")]
    public InteractableData[] interactableData;

}
