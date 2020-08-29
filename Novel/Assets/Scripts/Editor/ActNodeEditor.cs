using Novella.Dialog.Act;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActNode))]
public class ActNodeEditor : Editor
{
    public override void OnInspectorGUI()
    {

        if (GUILayout.Button("Open Editor"))
        {
            ActNodeEditorWindow.Open((ActNode)target);
        }

        DrawDefaultInspector();
    }
}
