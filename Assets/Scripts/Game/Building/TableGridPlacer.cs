using UnityEngine;
using System.Collections.Generic;

public class TableGridPlacer : MonoBehaviour
{
    public Transform tableTransform; // Mặt bàn
    public List<GameObject> objectsToPlace;
    public Vector2 padding = new Vector2(0.1f, 0.1f); // khoảng trống biên lề (X, Z)

    void Start()
    {
        tableTransform = this.transform;
        PlaceObjectsOnTable();
    }

    public void PlaceObjectsOnTable()
    {
        int count = objectsToPlace.Count;
        if (count == 0) return;

        int columns = Mathf.CeilToInt(Mathf.Sqrt(count));
        int rows = Mathf.CeilToInt((float)count / columns);

        // Tính kích thước thực tế của bàn (giả sử mặt bàn là mặt phẳng X-Z)
        Vector3 tableScale = tableTransform.localScale;
        float tableWidth = tableScale.x - padding.x * 2f;
        float tableLength = tableScale.z - padding.y * 2f;

        float cellWidth = tableWidth / columns;
        float cellLength = tableLength / rows;

        Vector3 tableCenter = tableTransform.position;

        int index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (index >= count) return;

                float x = (col - (columns - 1) / 2f) * cellWidth;
                float z = (row - (rows - 1) / 2f) * cellLength;

                Vector3 localOffset = new Vector3(x, 0, z);
                Vector3 worldPos = tableCenter + tableTransform.rotation * localOffset;

                GameObject obj = objectsToPlace[index];
                obj.transform.position = worldPos;
                obj.transform.rotation = tableTransform.rotation;

                // Tính scale phù hợp
                Vector3 originalScale = obj.transform.localScale;
                Bounds bounds = GetBounds(obj);
                float scaleX = cellWidth / bounds.size.x;
                float scaleZ = cellLength / bounds.size.z;
                float uniformScale = Mathf.Min(scaleX, scaleZ) * 0.8f;
                obj.transform.localScale = originalScale * uniformScale;

                // Cập nhật lại bounds sau khi scale
                bounds = GetBounds(obj);
                float objectHeight = bounds.extents.y;

                // Cập nhật lại bounds sau khi scale
                bounds = GetBounds(obj);

                // Lấy chiều cao mặt bàn
                Bounds tableBounds = GetBounds(tableTransform.gameObject);
                float tableTopY = tableBounds.max.y;

                // Tính phần chênh giữa đáy object và mặt bàn
                float objectBottomY = bounds.min.y;
                float deltaY = tableTopY - objectBottomY;

                // Đặt lại vị trí theo Y sao cho đáy object trùng mặt bàn
                Vector3 adjustedPos = worldPos + new Vector3(0, deltaY, 0);
                obj.transform.position = adjustedPos;



                index++;
            }
        }
    }

    // Lấy bounds tổng thể của GameObject (kể cả mesh con)
    Bounds GetBounds(GameObject go)
    {
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0)
            return new Bounds(go.transform.position, Vector3.zero);

        Bounds bounds = renderers[0].bounds;
        foreach (var r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }
        return bounds;
    }
}
