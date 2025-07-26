using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EntityShadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private SpriteRenderer shadowSpriteRenderer;
    void Start()
    {

    }

    private void OnValidate()
    {
        if (mainSpriteRenderer == null)
        {
            Debug.LogWarning("Shadow sprite is not assigned. Automatically assigning a default shadow sprite.");
            mainSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (shadowSpriteRenderer == null && mainSpriteRenderer != null)
        {
            InitializationShadowForEntity();
        }
    }

    private void InitializationShadowForEntity()
    {
        Debug.Log("[EntityShadow] Initializing shadow for entity...");
        // create new GameObject for shadow child of current GameObject  rotate 90 x color 00000  a = 150 layer = shadowSpriteRenderer
        // check if child with name "Shadow" already exists if so, destroy it
        Transform existingShadow = transform.Find("Shadow");
        if (existingShadow != null)
        {
            Debug.Log("[EntityShadow] Shadow already exists, destroying old shadow.");
            return;
        }
        GameObject shadowObject = new GameObject("Shadow");
        shadowObject.transform.SetParent(transform);
        shadowObject.transform.localPosition = Vector3.zero + new Vector3(0, 0.1f, 0);
        shadowObject.transform.localRotation = Quaternion.Euler(90, 0, 0);
        shadowObject.transform.localScale = Vector3.one;
        shadowSpriteRenderer = shadowObject.AddComponent<SpriteRenderer>();
        shadowSpriteRenderer.sprite = mainSpriteRenderer.sprite;
        shadowSpriteRenderer.color = new Color(0, 0, 0, 0.6f); // Set shadow color with alpha
        shadowSpriteRenderer.sortingLayerName = "Shadow"; // Set sorting layer to "Shadow
        shadowSpriteRenderer.sortingOrder = 0; // Set sorting order to 0
        Debug.Log("[EntityShadow] Shadow initialized successfully.");
    }
}
