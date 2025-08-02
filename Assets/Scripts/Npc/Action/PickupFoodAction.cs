using LTK268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LTK268.Interface;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pickup Food", story: "[Agent] pickup [Object] or Food", category: "Action", id: "130400e302f197d8369aeffb424eb05a")]
public partial class PickupFoodAction : Action
{
    [SerializeReference] public BlackboardVariable<NpcModel> Agent;
    [SerializeReference] public BlackboardVariable<ObjectBase> Object;
    protected override Status OnStart()
    {
        if (Agent.Value == null)
        {
            return Status.Failure;
        }

        if (Object.Value == null)
        {
            Debug.LogWarning("Object is null, cannot pick up.");
            return Status.Failure;
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Object.Value.IsBuilding())
        {
            Debug.LogWarning("Cannot pick up a building.");
            return Status.Failure;
        }
        var distanceToObject = Vector3.Distance(Agent.Value.transform.position, Object.Value.transform.position);
        if (distanceToObject <= Agent.Value.PickupDistance)
        {
            Object.Value.PickedUpBy((IHuman)Agent.Value);
            return Status.Success;
        }

        if (Object.Value != null)
        {
            return Status.Running;
        }
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

