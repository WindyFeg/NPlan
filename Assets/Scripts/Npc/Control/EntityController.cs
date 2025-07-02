using LKT268.Utils;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private bool showDebugVisuals = true;

    public GameObject DetectedTarget
    {
        get;
        set;
    }

    public GameObject UpdateDetector()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionMask);

        LTK268Log.LogInfo(colliders.Length.ToString());
        if (colliders.Length > 0)
        {
            int randomIndex = Random.Range(0, colliders.Length);
            DetectedTarget = colliders[randomIndex].gameObject;
        }
        else
        {
            DetectedTarget = null;
        }

        return DetectedTarget;
    }

    private void OnDrawGizmosSelected()
    {
        if (showDebugVisuals)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
