using LTK268.Model.CommonBase;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack target", story: "[Enemy] attack [target]", category: "Action", id: "5e0f825f82fd63bdeab827e0decc77dc")]
public partial class AttackTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<EnemyBase> enemy;
    [SerializeReference] public BlackboardVariable<GameObject> target;

    protected override Status OnStart()
    {
        if (target.Value == null)
        {
            Debug.LogError("Target is null, cannot perform attack action.");
            return Status.Failure;
        }

        var targetEntity = target.Value.GetComponent<EntityBase>();
        if (targetEntity == null)
        {
            Debug.LogError("Target does not have an EntityBase component, cannot perform attack action.");
            return Status.Failure;
        }

        targetEntity.TakeDamage(enemy.Value.Damage);
        return Status.Success;
    }
}