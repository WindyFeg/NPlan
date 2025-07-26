using System.Collections.Generic;
using LTK268.Utils;
using UnityEngine;

public class EntityDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask detectionMask = LayerMask.GetMask("NPC", "Food", "Object");
    [SerializeField] private bool showDebugVisuals = true;

    public GameObject DetectedTarget
    {
        get;
        set;
    }

    #region Public Properties
    /// <summary>
    /// Updates the detector to find all entities within the detection radius.
    /// </summary>
    /// <returns></returns>
    public List<GameObject> UpdateDetector()
    {
        // Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionMask);
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        // Filter colliders by tag
        var filtered = System.Array.FindAll(
            colliders,
            c =>
                c.gameObject.CompareTag("NPC") ||
                c.gameObject.CompareTag("Food") ||
                c.gameObject.CompareTag("Object")
        );

        return new List<GameObject>(System.Array.ConvertAll(filtered, c => c.gameObject));
    }


    /// <summary>
    /// Gets a random entity from the detected objects within the detection radius.
    /// </summary>
    /// <returns></returns>
    public GameObject GetRandomEntity()
    {
        List<GameObject> detectedObjects = UpdateDetector();

        LTK268Log.LogInfo(detectedObjects.Count.ToString());
        if (detectedObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, detectedObjects.Count);
            DetectedTarget = detectedObjects[randomIndex];
        }
        else
        {
            DetectedTarget = null;
        }
        return DetectedTarget;
    }

    /// <summary>
    /// Updates the closest entity in the detection radius.
    /// </summary>
    /// <returns>Returns the closest entity GameObject or null if none found.</returns>
    public GameObject GetClosestEntity()
    {
        List<GameObject> detectedObjects = UpdateDetector();
        GameObject closestEntity = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject entity in detectedObjects)
        {
            float distance = Vector3.Distance(transform.position, entity.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEntity = entity;
            }
        }

        DetectedTarget = closestEntity;
        return DetectedTarget;
    }
    #endregion

    #region Private Methods
    private void OnDrawGizmosSelected()
    {
        if (showDebugVisuals)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
    #endregion
}
