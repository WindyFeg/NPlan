using System.Collections.Generic;
using Common_Utils;
using UnityEngine;
public enum Requirements
{
    None,
    HasTownHall_1,
    HasTownHall_2,

}
[CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/BuildingData")]
public class BuildingData : ScriptableObject
{
    [Header("Building Data")]
    public int id;
    public string buildingName;
    public int maxHealth;
    public int level;
    public int damage;

    [Header("Building Properties")]
    public InteractableData[] interactableDatas;
    // public ResourceTypeData foodResource;
    // public int costFood;
    // public ResourceTypeData woodResource;
    // public int costWood;
    // public ResourceTypeData stoneResource;
    // public int costStone;

    [Header("Building Requirements")]
    public Requirements requirements;
    [Header("Building Prefab")]
    public GameObject buildingPrefabs;
    [Header("Building Upgrade Data")]
    public BuildingData nextBuildingData;
}
