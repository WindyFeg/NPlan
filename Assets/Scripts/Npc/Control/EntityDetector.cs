using LKT268.Utils;
using UnityEngine;

public class EntityDetector : MonoBehaviour
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

        // Filter colliders by tag
        var filtered = System.Array.FindAll(
            colliders,
            c =>
                c.gameObject.CompareTag("NPC") ||
                c.gameObject.CompareTag("Food") ||
                c.gameObject.CompareTag("Object")
        );

        LTK268Log.LogInfo(filtered.Length.ToString());
        if (filtered.Length > 0)
        {
            int randomIndex = Random.Range(0, filtered.Length);
            DetectedTarget = filtered[randomIndex].gameObject;
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
