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
        window.titleContent = new GUIContent("�I���W�i���̃E�B���h�E");
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("�I���W�i���̃E�B���h�E����낤�I");
        EditorGUILayout.LabelField("EditorGUILayout.BeginVertical���g���Əc�ɕ��т܂��B");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("EditorGUILayout.BeginHorizontal���g����");
        EditorGUILayout.LabelField("���ɕ��ׂ邱�Ƃ��ł��܂��B");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("������̓X�^�C���Ȃ��o�[�W�����B");
        EditorGUILayout.LabelField("���肪�͂��Ă��܂���B");
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.ToggleLeft("�e�X�g", true);
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
