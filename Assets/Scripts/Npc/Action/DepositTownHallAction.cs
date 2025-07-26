using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using LTK268.Manager;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DepositTownHall", story: "[Self] Navigate to TownHall", category: "Action", id: "c131d90c81c022e0d0134f39e428b258")]
public partial class DepositTownHallAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private NavMeshAgent navMeshAgent;

    protected override Status OnStart()
    {
        if (Self?.Value == null)
        {
            Debug.LogError("WanderTask: Self BlackboardVariable or its Value is not set.");
            return Status.Failure;
        }

        navMeshAgent = Self.Value.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("WanderTask requires a NavMeshAgent component on the GameObject stored in Self.Value.");
            return Status.Failure;
        }

        if (BuildingManager.Instance?.TownHall == null)
        {
            Debug.LogError("WanderTask: BuildingManager.Instance or TownHall is null. Cannot set destination.");
            return Status.Failure;
        }

        navMeshAgent.SetDestination(BuildingManager.Instance.TownHall.transform.position);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (navMeshAgent == null) return Status.Failure;

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                return Status.Success;
            }
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        if (navMeshAgent != null && navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.isStopped = true;
        }
    }
}

