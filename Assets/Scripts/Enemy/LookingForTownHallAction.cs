using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LTK268.Manager;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "LookingForTownHall", story: "Looking for TownHall and assign to [Target]", category: "Action", id: "4255dc07d818ff2db9919e6062e5e093")]
public partial class LookingForTownHallAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnStart()
    {
        if (BuildingManager.Instance.TownHall == null)
        {
            Debug.LogWarning("TownHall is not available.");
            return Status.Failure;
        }
        Target.Value = BuildingManager.Instance.TownHall.gameObject;
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

