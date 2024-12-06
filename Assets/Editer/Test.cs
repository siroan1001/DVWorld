using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : EditorWindow
{
    [MenuItem("Tools/Test")]
    static void Open()
    {
        var window = GetWindow<Test>();
        window.titleContent = new GUIContent("オリジナルのウィンドウ");
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("オリジナルのウィンドウを作ろう！");
        EditorGUILayout.LabelField("EditorGUILayout.BeginVerticalを使うと縦に並びます。");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("EditorGUILayout.BeginHorizontalを使えば");
        EditorGUILayout.LabelField("横に並べることもできます。");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("こちらはスタイルなしバージョン。");
        EditorGUILayout.LabelField("周りが囲われていません。");
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.ToggleLeft("テスト", true);
        EditorGUILayout.Toggle(true);
        EditorGUILayout.Toggle(true);
        EditorGUILayout.EndHorizontal(); 
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Toggle(true);
        EditorGUILayout.Toggle(true);
        EditorGUILayout.Toggle(true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
    }
}
