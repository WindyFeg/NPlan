using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Navigation randomly", story: "[Agent] Navigate randomly", category: "Action", id: "ff388cbe9301988e1c247d0221e1e303")]
public partial class NavigationRandomlyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    public float wanderRadius = 5f;
    public float wanderTimer = 10f;

    private NavMeshAgent navMeshAgent;
    private float timer;

    protected override Status OnStart()
    {
        if (Agent == null)
        {
            Debug.LogError("WanderTask requires a NavMeshAgent component on the GameObject.");
        }
        navMeshAgent = Agent.Value.GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Agent == null) return Status.Failure;

        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(Agent.Value.transform.position, wanderRadius, -1);
            if (NavMesh.SamplePosition(newPos, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.position);
                timer = 0;
                this.GameObject.GetComponentInChildren<ICharacterAnimation>().PlayWalkingAnimation();
                return Status.Success;
            }
            else
            {
                Debug.LogWarning("Could not find a valid wander destination.");
                timer = 0;
                return Status.Failure;
            }
        }

        return Status.Running;
    }

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
        randDirection += origin;
        return randDirection;
    }

    protected override void OnEnd()
    {
    }
}

