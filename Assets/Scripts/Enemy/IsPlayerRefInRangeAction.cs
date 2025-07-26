using System;
using LTK268.Manager;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

namespace Enemy.Action
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Is PlayerRef In Range", story: "Is [PlayerRef] In Range", category: "Action", id: "check-player-in-range")]
    public partial class IsPlayerInRangeAction : Unity.Behavior.Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<GameObject> PlayerRef;
        

        public float range = 5f;

        protected override Status OnUpdate()
        {
            // if (Self.Value == null)
            //     return Status.Failure;
            // PlayerRef.Value = (BlackboardVariable<GameObject>)PlayerManager.Instance.playerModel.gameObject;
            // var playerPosition = PlayerManager.Instance.playerModel.transform.position;
            //
            // float distance = Vector3.Distance(Self.Value.transform.position, playerPosition);
            //
            // Debug.Log(" >> " +  (distance <= range));
            // return PlayerRef != null && distance <= range ? Status.Success : Status.Failure;
            return Status.Failure;
        }
    }
}