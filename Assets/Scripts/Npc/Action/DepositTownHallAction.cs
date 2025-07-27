using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LTK268.Interface;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DepositTownHall", story: "[Self] deposit to [TownHall]", category: "Action", id: "a23a31d418737f2db160e3b639416dfe")]
public partial class DepositTownHallAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> TownHall;

    protected override Status OnStart()
    {
        if (Self == null || TownHall == null)
        {
            Debug.LogError("DepositTownHallAction requires both Self and TownHall variables to be set.");
            return Status.Failure;
        }

        var npcBase = Self.Value.GetComponent<IHuman>();
        TownHall.Value.GetComponent<TownHall>().Deposit(npcBase);
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

