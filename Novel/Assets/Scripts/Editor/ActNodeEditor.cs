using Novella.Dialog.Act;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActNode))]
public class ActNodeEditor : Editor
{
    private SerializedProperty _script;

    private void OnEnable()
    {
        _script = serializedObject.FindProperty("m_Script");
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = false;
        EditorGUILayout.PropertyField(_script, true, new GUILayoutOption[0]);
        GUI.enabled = true;
        EditorGUILayout.Space();

        if (GUILayout.Button("Open Editor"))
        {
            ActNodeEditorWindow.Open((ActNode)target);
        }
    }
}
