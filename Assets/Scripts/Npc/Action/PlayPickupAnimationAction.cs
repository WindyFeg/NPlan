using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayPickupAnimation", story: "[CharactorAnimation] Pickup", category: "Action", id: "4919c1835e62982733d1aee9213854b0")]
public partial class PlayPickupAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<CharacterAnimation> CharactorAnimation;

    protected override Status OnStart()
    {
        CharactorAnimation.Value.SetAnimState(AnimState.Pickup);
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

