using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LTK268.Interface;
using LTK268.Manager;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DepositTownHall", story: "[Self] deposit to TownHall", category: "Action", id: "a23a31d418737f2db160e3b639416dfe")]
public partial class DepositTownHallAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    protected override Status OnStart()
    {
        if (Self == null)
        {
            Debug.LogError("DepositTownHallAction requires both Self variables to be set.");
            return Status.Failure;
        }

        var npcBase = Self.Value.GetComponent<IHuman>();
        // BuildingManager.Instance.TownHall.InteractWithEntity((IEntity)npcBase);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

