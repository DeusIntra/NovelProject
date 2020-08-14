using UnityEngine;
using Novella.Dialog;
using UnityEditor;

[CustomEditor(typeof(TextAnimationHolder))]
public class TextAnimationHolderEditor : Editor
{
    private SerializedProperty animationIndex;
    private int selected = 0;

    private void OnEnable()
    {
        animationIndex = serializedObject.FindProperty("animationIndex");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        TextAnimationHolder script = (TextAnimationHolder)target;
        string[] animationNames = script.AnimationNames;
        selected = EditorGUILayout.Popup("CurrentAnimation", selected, animationNames);
        script.animationIndex = selected;
        serializedObject.ApplyModifiedProperties();

        GUI.enabled = false;
        GUIContent content = new GUIContent("Animation Index", 
            "This is an actual public field which you can modify via script to set current animation." +
            "The popup list above is created just for comfort of editing in the inspector.");
        EditorGUILayout.PropertyField(animationIndex, content);
        GUI.enabled = true;
    }
}
