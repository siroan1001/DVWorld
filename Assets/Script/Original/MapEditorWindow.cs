using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapEditorWindow : EditorWindow
{
    private enum Mode { Select, Add, Remove }
    private Mode currentMode = Mode.Select;

    private GameObject prefabToPlace;
    private GameObject selectedObject;

    [MenuItem("Tools/Map Editor")]
    public static void ShowWindow()
    {
        GetWindow<MapEditorWindow>("Map Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Map Editor", EditorStyles.boldLabel);

        // ���[�h�I��
        GUILayout.Label("Mode", EditorStyles.label);
        currentMode = (Mode)GUILayout.Toolbar((int)currentMode, new string[] { "Select", "Add", "Remove" });

        // �ǉ����[�h�̃v���n�u�I��
        if (currentMode == Mode.Add)
        {
            prefabToPlace = (GameObject)EditorGUILayout.ObjectField("Prefab to Place", prefabToPlace, typeof(GameObject), false);
        }

        // ���ݑI�𒆂̃I�u�W�F�N�g��\��
        if (currentMode == Mode.Select && selectedObject != null)
        {
            GUILayout.Label("Selected Object: " + selectedObject.name, EditorStyles.helpBox);
        }
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;

        // �V�[���r���[�ŃN���b�N�C�x���g�����o
        if (e.type == EventType.MouseDown && e.button == 0)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                HandleClick(hit.point);
                e.Use();
            }
        }
    }

    private void HandleClick(Vector3 position)
    {
        switch (currentMode)
        {
            case Mode.Select:
                SelectObject(position);
                break;
            case Mode.Add:
                AddPrefab(position);
                break;
            case Mode.Remove:
                RemoveObject(position);
                break;
        }
    }

    private void SelectObject(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, 0.5f);
        if (hits.Length > 0)
        {
            selectedObject = hits[0].gameObject;
            Debug.Log("Selected: " + selectedObject.name);
        }
        else
        {
            selectedObject = null;
        }
    }

    private void AddPrefab(Vector3 position)
    {
        if (prefabToPlace == null)
        {
            Debug.LogWarning("Prefab is not assigned.");
            return;
        }

        Vector3 gridPosition = SnapToGrid(position);
        GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefabToPlace);
        newObject.transform.position = gridPosition;
        Undo.RegisterCreatedObjectUndo(newObject, "Add Prefab");
    }

    private void RemoveObject(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, 0.5f);
        if (hits.Length > 0)
        {
            GameObject toRemove = hits[0].gameObject;
            Undo.DestroyObjectImmediate(toRemove);
        }
    }

    private Vector3 SnapToGrid(Vector3 position)
    {
        float gridSize = 1.0f; // �O���b�h�T�C�Y�𒲐��\
        return new Vector3(
            Mathf.Round(position.x / gridSize) * gridSize,
            Mathf.Round(position.y / gridSize) * gridSize,
            Mathf.Round(position.z / gridSize) * gridSize
        );
    }
}

