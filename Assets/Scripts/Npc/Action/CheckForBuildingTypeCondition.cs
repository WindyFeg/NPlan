using LTK268.Interface;
using LTK268.Model.CommonBase;
using LTK268.Utils;
using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check for Building Type", story: "Check if [Object] is building with specific [BuildingType]", category: "Variable Conditions", id: "937c774bc70201b41e7e995a78450e12")]
public partial class CheckForBuildingType : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Object;
    [SerializeReference] public BlackboardVariable<BuildingType> TargetBuildingType;

    public override bool IsTrue()
    {
        var obj = Object.Value;

        if (obj == null)
            return false;

        var building = obj.GetComponent<IBuilding>();
        if (building == null)
            return false;

        if (TargetBuildingType == null || TargetBuildingType.Value == BuildingType.None)
            return true;

        // Check if it the correct building type
        var buildingBase = obj.GetComponent<BuildingBase>();
        if (buildingBase != null)
        {
            return buildingBase.BuildingType == TargetBuildingType.Value;
        }

        return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
