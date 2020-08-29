using Novella.Dialog.Act;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class ActNodeEditorWindow : ExtendedEditorWindow
{
    ReorderableList _list;

    public static void Open(ActNode actNode)
    {
        ActNodeEditorWindow window = GetWindow<ActNodeEditorWindow>("Act Node Editor");
        window.serializedObject = new SerializedObject(actNode);
    }

    protected override void OnPropertySelected()
    {
        CreateReorderableListOfTransitions();
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("actorsToCreate");

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(200), GUILayout.ExpandHeight(true));
        DrawSidebar(currentProperty);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        if (selectedProperty != null)
        {
            currentProperty = selectedProperty;

            EditorGUILayout.BeginVertical();
            DrawField("_character");
            DrawField("_initialState");
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            _list.DoLayoutList();
        }
        else
        {
            EditorGUILayout.LabelField("Select an item from the list");
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }

    private void CreateReorderableListOfTransitions()
    {
        SerializedProperty transitionsProperty = selectedProperty.FindPropertyRelative("_transitions");
        _list = new ReorderableList(serializedObject, transitionsProperty, true, true, true, true);

        _list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            SerializedProperty element = _list.serializedProperty.GetArrayElementAtIndex(index);

            EditorGUI.PropertyField(rect, element, true);
        };

        _list.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Transitions");
        };

        _list.elementHeightCallback = (int index) =>
        {           
            float propertyHeight = EditorGUI.GetPropertyHeight(_list.serializedProperty.GetArrayElementAtIndex(index), true);

            float spacing = EditorGUIUtility.singleLineHeight / 2;

            return propertyHeight + spacing;            
        };
    }
}
