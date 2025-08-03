using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set AnimState", story: "Set [CharacterAnim] to [AnimState]", category: "Action", id: "0a3312f2eb0e3768d4ea05c848b116b7")]
public partial class SetAnimStateAction : Action
{
    [SerializeReference] public BlackboardVariable<CharacterAnimation> characterAnim;
    [SerializeReference] public BlackboardVariable<AnimState> animState;

    protected override Status OnStart()
    {
        characterAnim.Value.SetAnimState(animState);
        return Status.Success;
    }
}