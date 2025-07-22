using System.Collections.Generic;
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
    public float buildTime;
    public int costGold;
    public int costWood;
    public int costStone;

    [Header("Building Requirements")]
    public Requirements requirements;
    [Header("Building Model")]
    public List<Mesh> modelPresets;
    public List<Sprite> spritePresets;
    [Header("Building Config")]
    public BuildingData nextBuildingData;

}
