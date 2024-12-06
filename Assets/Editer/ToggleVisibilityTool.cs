using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToggleVisibilityTool : EditorWindow
{
    private GameObject selectedObject;
    private bool isVisible = true;

    [MenuItem("Tools/Toggle Visibility")]
    public static void ShowWindow()
    {
        GetWindow<ToggleVisibilityTool>("Toggle Visibility");
    }

    private void OnGUI()
    {
        GUILayout.Label("Toggle Object Visibility", EditorStyles.boldLabel);

        selectedObject = (GameObject)EditorGUILayout.ObjectField("Target Object", selectedObject, typeof(GameObject), true);

        if (selectedObject != null)
        {
            isVisible = EditorGUILayout.Toggle("Is Visible", selectedObject.activeSelf);

            if (GUILayout.Button("Apply"))
            {
                selectedObject.SetActive(isVisible);
            }
        }
    }
}

