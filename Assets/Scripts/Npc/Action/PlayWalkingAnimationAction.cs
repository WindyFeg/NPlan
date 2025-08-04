using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayWalkingAnimation", story: "[CharactorAnimation] Walking", category: "Action", id: "4919c1335e62982733d1aee9213854b0")]
public partial class PlayWalkingAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<CharacterAnimation> CharactorAnimation;

    protected override Status OnStart()
    {
        CharactorAnimation.Value.SetAnimState(AnimState.Walking);
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

