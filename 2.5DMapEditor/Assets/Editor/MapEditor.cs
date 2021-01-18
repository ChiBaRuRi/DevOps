using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow
{
    int x = 0;
    int y = 0;
    public static GameObject game;
    [MenuItem("Map Editor/Draw A Map")]
    public static void OpenMap()
    {

        if (EditorApplication.isPlaying)
        {
            game = GameObject.Find("GameObject");
            MapEditor win = GetWindow<MapEditor>("MapEditor");
            win.Show();
        }

    }
    private void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Please input line number");
        x = EditorGUILayout.IntField(x);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Please input list number");
        y = EditorGUILayout.IntField(y);
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Start"))
        {
            MapEditor win = GetWindow<MapEditor>("MapEditor");
            Map map = game.AddComponent<Map>();
            map.Init(x, y);
            win.Close();
        }
        GUILayout.EndVertical();
    }
}
