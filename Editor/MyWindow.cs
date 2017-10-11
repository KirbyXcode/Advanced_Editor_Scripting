using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow {

    [MenuItem("Window/show mywindow")]
    static void ShowMyWindow()
    {
        MyWindow window= EditorWindow.GetWindow<MyWindow>();
        window.Show();
    }

    private string name="";
    void OnGUI()
    {
        GUILayout.Label("这是我的窗口");
        name = GUILayout.TextField(name);
        if (GUILayout.Button("创建"))
        {
            GameObject go = new GameObject(name);
            Undo.RegisterCreatedObjectUndo(go, "create gameobject");
        }
    }

}