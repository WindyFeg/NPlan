using LTK268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using LTK268.Interface;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pickup Food", story: "[Agent] pickup [Object] or [Food]", category: "Action", id: "130400e302f197d8369aeffb424eb05a")]
public partial class PickupFoodAction : Action
{
    [SerializeReference] public BlackboardVariable<NpcModel> Agent;
    [SerializeReference] public BlackboardVariable<ObjectBase> Object;
    [SerializeReference] public BlackboardVariable<FoodBase> Food;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Agent.Value == null)
        {
            return Status.Failure;
        }

        if (Object.Value != null)
        {
            var distanceToObject = Vector3.Distance(Agent.Value.transform.position, Object.Value.transform.position);
            if (distanceToObject <= Agent.Value.PickupDistance)
            {
                Object.Value.PickedUpBy((IHuman)Agent.Value);
                return Status.Success;
            }
        }

        if (Food.Value != null)
        {
            var distanceToFood = Vector3.Distance(Agent.Value.transform.position, Food.Value.transform.position);
            if (distanceToFood <= Agent.Value.PickupDistance)
            {
                Food.Value.PickedUpBy((IHuman)Agent.Value);
                return Status.Success;
            }
        }

        if (Object.Value != null || Food.Value != null)
        {
            return Status.Running;
        }

        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

