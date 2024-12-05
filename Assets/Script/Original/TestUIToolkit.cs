using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestUIToolkit : EditorWindow
{
    [MenuItem("Window/UI Toolkit/TestUIToolkit")]
    public static void ShowExample()
    {
        TestUIToolkit wnd = GetWindow<TestUIToolkit>();
        wnd.titleContent = new GUIContent("TestUIToolkit");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

    }
}
