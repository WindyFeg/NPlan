using System.IO;
using UnityEditor;
using UnityEngine;

public class ItemTab : EditorWindow
{
    private const string SaveFilePath = "Assets/Resources/items.json";

    public void Draw()
    {
        EditorGUILayout.LabelField("Items", EditorStyles.boldLabel);
    }
}