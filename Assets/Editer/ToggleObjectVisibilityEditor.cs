using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToggleObjectVisibilityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // 元のインスペクターを表示
        base.OnInspectorGUI();

        // 対象オブジェクトの参照を取得
        ToggleObjectVisibility toggleScript = (ToggleObjectVisibility)target;

        // チェックボックスを表示
        toggleScript.isVisible = EditorGUILayout.Toggle("Is Visible", toggleScript.isVisible);

        // チェックボックスの状態に応じてオブジェクトを有効/無効にする
        toggleScript.gameObject.SetActive(toggleScript.isVisible);

        // スクリプトの変更を記録
        if (GUI.changed)
        {
            EditorUtility.SetDirty(toggleScript);
        }
    }
}
