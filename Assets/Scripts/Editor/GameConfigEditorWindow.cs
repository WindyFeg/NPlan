using UnityEditor;
using UnityEngine;

namespace LTK268.Editor
{
    public class GameSettingWindow : EditorWindow
    {
        private int mainTabIndex = 0;
        private string[] mainTabs = { "Items" };

        private int subTabIndex = 0;
        private ItemTab itemTab;

        [MenuItem("268LTK/Game Setting &v")]
        
        public static void ShowWindow()
        {
            GetWindow<GameSettingWindow>("Game Setting");
            
            // Set the window size
            var window = GetWindow<GameSettingWindow>();
            window.minSize = new Vector2(800, 600);
            window.maxSize = new Vector2(1920, 1080);
        }
        
        private void OnEnable()
        {
            itemTab = new ItemTab();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            // Main Tabs
            for (int i = 0; i < mainTabs.Length; i++)
            {
                GUIStyle tabStyle = new GUIStyle(GUI.skin.button)
                {
                    fixedWidth = 100,
                    fixedHeight = 50,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter,
                    normal = { textColor = Color.white }
                };

                if (i == mainTabIndex)
                    GUI.backgroundColor = Color.green;
                else
                    GUI.backgroundColor = Color.gray;

                if (GUILayout.Button(mainTabs[i], tabStyle))
                    mainTabIndex = i;
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);

            // Sub Tabs (based on main tab)
            switch (mainTabIndex)
            {
                case 0: // GLOBAL
                    DrawGlobalTab();
                    break;
                case 1: // Items
                    itemTab.Draw();
                    break;
            }

            EditorGUILayout.EndVertical();
        }

        private void DrawGlobalTab()
        {
            EditorGUILayout.Space(5);
            switch (subTabIndex)
            {
                case 0:
                    EditorGUILayout.LabelField("Global Settings content...");
                    break;
            }
        }
    }
}