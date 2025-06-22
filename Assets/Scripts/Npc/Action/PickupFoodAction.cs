using LKT268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEditor.UI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pickup Food", story: "[Agent] pickup [Food]", category: "Action", id: "130400e302f197d8369aeffb424eb05a")]
public partial class PickupFoodAction : Action
{
    [SerializeReference] public BlackboardVariable<NpcModel> Agent;
    [SerializeReference] public BlackboardVariable<FoodModel> Food;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Food.Value != null && Agent.Value != null)
        {
            Food.Value.PickedUpBy(Agent.Value);
            return Status.Success;
        }
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

