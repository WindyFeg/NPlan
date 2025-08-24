using UnityEngine;
using System.Collections.Generic;

public class CraftingTableDisplay : MonoBehaviour
{
    private int currentItem = 0;

    [SerializeField] private List<GameObject> displayPrefabs = new List<GameObject>();
    [SerializeField] private Transform surfacePoint;

    [SerializeField] private Vector3 localOffset = Vector3.zero;
    [SerializeField] private float yRotationOffset = 0f;
    [SerializeField] private bool keepPrefabRotation = false;

    // NEW: tuỳ chọn xoay nằm ngang
    [SerializeField] private bool layFlatOnTable = true;
    public enum FlatAxis { X, Z }             // X: lật về “nằm ngửa/ngửa”, Z: lật sang “nằm nghiêng”
    [SerializeField] private FlatAxis flatAxis = FlatAxis.X;

    private GameObject previewInstance;

    public void ShowItem()
    {
        if (displayPrefabs == null || displayPrefabs.Count == 0)
        {
            ClearPreview();
            Debug.Log("[CraftingTableDisplay] Không có prefab nào trong list để hiển thị.");
            return;
        }

        if (currentItem >= displayPrefabs.Count) currentItem = 0;
        if (currentItem < 0) currentItem = displayPrefabs.Count - 1;

        var prefab = displayPrefabs[currentItem];
        if (prefab == null) return;

        ClearPreview();

        Vector3 spawnPos = surfacePoint != null
            ? surfacePoint.TransformPoint(localOffset)
            : transform.position + localOffset;

        // rotation cơ bản theo surfacePoint (hoặc giữ nguyên prefab)
        Quaternion rot = keepPrefabRotation
            ? prefab.transform.rotation
            : (surfacePoint != null ? surfacePoint.rotation : Quaternion.identity);

        // NEW: xoay 90° để “nằm ngang”
        if (layFlatOnTable)
        {
            rot *= (flatAxis == FlatAxis.X)
                ? Quaternion.Euler(90f, 0f, 0f)
                : Quaternion.Euler(0f, 0f, 90f);
        }

        // tinh chỉnh quay theo trục Y (xoay quanh tâm khi đã nằm)
        rot *= Quaternion.Euler(0f, yRotationOffset, 0f);

        previewInstance = Instantiate(prefab, spawnPos, rot, surfacePoint != null ? surfacePoint : transform);

        var rb = previewInstance.GetComponent<Rigidbody>();
        if (rb) { rb.isKinematic = true; rb.useGravity = false; }
    }

    public void NextItem()
    {
        if (displayPrefabs.Count == 0) return;
        currentItem = (currentItem + 1) % displayPrefabs.Count;
        ShowItem();
    }

    public void PrevItem()
    {
        if (displayPrefabs.Count == 0) return;
        currentItem = (currentItem - 1 + displayPrefabs.Count) % displayPrefabs.Count;
        ShowItem();
    }

    public GameObject GetCurrentItem()
    {
        return displayPrefabs[currentItem];
    }

    public void ClearPreview()
    {
        if (previewInstance != null)
        {
            Destroy(previewInstance);
            previewInstance = null;
        }
    }
}
