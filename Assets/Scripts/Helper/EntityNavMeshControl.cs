using UnityEngine;
using UnityEngine.AI;

public class NpcControl : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    void Start()
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        navMeshAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
