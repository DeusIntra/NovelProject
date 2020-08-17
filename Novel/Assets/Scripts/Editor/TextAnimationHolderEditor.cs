using UnityEngine;
using Novella.Dialog;
using UnityEditor;

[CustomEditor(typeof(TextRevealHolder))]
public class TextAnimationHolderEditor : Editor
{
    private SerializedProperty _script;
    private SerializedProperty animationIndex;
    private int selected;

    private void OnEnable()
    {
        _script = serializedObject.FindProperty("m_Script");
        animationIndex = serializedObject.FindProperty("animationIndex");
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = false;
        EditorGUILayout.PropertyField(_script, true, new GUILayoutOption[0]);
        GUI.enabled = true;
        EditorGUILayout.Space();

        serializedObject.Update();

        TextRevealHolder script = (TextRevealHolder)target;
        string[] animationNames = script.AnimationNames;
        animationIndex.intValue = EditorGUILayout.Popup("CurrentAnimation", animationIndex.intValue, animationNames);

        serializedObject.ApplyModifiedProperties();

        GUI.enabled = false;
        GUIContent content = new GUIContent("Animation Index", 
            "This is an actual public field which you can modify via script to set current animation." +
            "The popup list above is created just for comfort of editing in the inspector.");
        EditorGUILayout.PropertyField(animationIndex, content);
        GUI.enabled = true;
    }
}
