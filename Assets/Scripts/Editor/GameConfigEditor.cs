using LTK268.Define;
using UnityEditor;
using UnityEngine;

namespace LTK268.Editor
{
    [CustomEditor(typeof(GameConfig))]
    public class GameConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Open Editor")) GameSettingWindow.ShowWindow();
        }
    }
}