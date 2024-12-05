using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToggleObjectVisibilityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // ���̃C���X�y�N�^�[��\��
        base.OnInspectorGUI();

        // �ΏۃI�u�W�F�N�g�̎Q�Ƃ��擾
        ToggleObjectVisibility toggleScript = (ToggleObjectVisibility)target;

        // �`�F�b�N�{�b�N�X��\��
        toggleScript.isVisible = EditorGUILayout.Toggle("Is Visible", toggleScript.isVisible);

        // �`�F�b�N�{�b�N�X�̏�Ԃɉ����ăI�u�W�F�N�g��L��/�����ɂ���
        toggleScript.gameObject.SetActive(toggleScript.isVisible);

        // �X�N���v�g�̕ύX���L�^
        if (GUI.changed)
        {
            EditorUtility.SetDirty(toggleScript);
        }
    }
}
