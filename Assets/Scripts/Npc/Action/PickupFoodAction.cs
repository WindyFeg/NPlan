using LKT268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LKT268.Interface;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pickup Food", story: "[Agent] pickup [PickupObject]", category: "Action", id: "130400e302f197d8369aeffb424eb05a")]
public partial class PickupFoodAction : Action
{
    [SerializeReference] public BlackboardVariable<NpcModel> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> PickupObject;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (PickupObject.Value != null && Agent.Value != null)
        {
            var food = PickupObject.Value.GetComponent<IFood>();
            if (food != null)
            {
                food.PickedUpBy(Agent.Value);
                return Status.Success;
            }
        }
        return Status.Failure;
    }
    protected override void OnEnd()
    {
    }
}

