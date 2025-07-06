using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

namespace Enemy.Action
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Is PlayerRef In Range", story: "Is [PlayerRef] In [Range]", category: "Action", id: "check-player-in-range")]
    public partial class IsPlayerInRangeAction : Unity.Behavior.Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<GameObject> PlayerRef;

        public float range = 5f;

        protected override Status OnUpdate()
        {
            if (Self.Value == null || PlayerRef.Value == null)
                return Status.Failure;

            float distance = Vector3.Distance(Self.Value.transform.position, PlayerRef.Value.transform.position);

            return distance <= range ? Status.Success : Status.Failure;
        }
    }
}