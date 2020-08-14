using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Novella.Dialog;

[CustomEditor(typeof(DialogNode))]
public class DialogNodeEditor : Editor
{
    private SerializedProperty _script;
    private SerializedProperty _quotesProperty;
    private SerializedProperty _choicesProperty;
    private SerializedProperty _nextNodeProperty;
    private SerializedProperty _onEndNodeProperty;
    private ReorderableList _list;

    private void OnEnable() 
    {
        _script = serializedObject.FindProperty("m_Script");
        _quotesProperty = serializedObject.FindProperty("_quotes");
        _choicesProperty = serializedObject.FindProperty("_choices");
        _nextNodeProperty = serializedObject.FindProperty("_nextNode");
        _onEndNodeProperty = serializedObject.FindProperty("_onEndNode");

        CreateReorderableListOfQuotes();            
    }

    public override void OnInspectorGUI() 
    {
        GUI.enabled = false;
        EditorGUILayout.PropertyField(_script, true, new GUILayoutOption[0]);
        GUI.enabled = true;
        EditorGUILayout.Space();

        serializedObject.Update();
        _list.DoLayoutList();

        EditorGUILayout.PropertyField(_choicesProperty);

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(new GUIContent(
            "Next\u00A0Node field will only be active if Choices size is\u00A00. " +
            "If Choices size is not\u00A00, Dialog\u00A0Node will ignore " +
            "its Next\u00A0Node and use Choice's. Next\u00A0Node may be useful " +
            "to set up an event which occurs while dialog is still playing or " +
            "for a logical separation of the dialog."));

        EditorGUI.BeginDisabledGroup(_choicesProperty.arraySize > 0);
        EditorGUILayout.PropertyField(_nextNodeProperty);
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(_onEndNodeProperty);

        serializedObject.ApplyModifiedProperties();
    }

    private void CreateReorderableListOfQuotes() 
    {
        int heightMultiplier = 5;
        float prefixWidth = 65;
        float padding = 5;
        float paddingInternal = 5;

        float lineHeight = EditorGUIUtility.singleLineHeight;
        float spacing = EditorGUIUtility.standardVerticalSpacing;

        _list = new ReorderableList(serializedObject, _quotesProperty, true, true, true, true);

        _list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = _list.serializedProperty.GetArrayElementAtIndex(index);
            var labelName = new GUIContent("Name");
            var labelText = new GUIContent("Text");
            var labelIcon = new GUIContent("Icon");
            var labelCharacter = new GUIContent("Character");
            SerializedProperty characterName = element.FindPropertyRelative("_characterName");
            SerializedProperty text = element.FindPropertyRelative("_text");
            SerializedProperty faceIcon = element.FindPropertyRelative("_faceIcon");
            SerializedProperty character = element.FindPropertyRelative("_character");

            EditorGUI.LabelField(new Rect(  // Name label
                rect.x,
                rect.y + padding,
                prefixWidth,
                lineHeight
                ), labelName);

            EditorGUI.LabelField(new Rect(  // Icon label
                rect.x + rect.width / 2 + 10,
                rect.y + padding,
                prefixWidth,
                lineHeight
                ), labelIcon);

            EditorGUI.LabelField(new Rect(  // Text label
                rect.x,
                rect.y + padding * 2 + lineHeight,
                prefixWidth,
                lineHeight
                ), labelText);

            EditorGUI.LabelField(new Rect(  // Character label
                rect.x,
                rect.y + padding * 6 + lineHeight * 4,
                prefixWidth,
                lineHeight
                ), labelCharacter);

            // ---------------------------------------------- //

            EditorGUI.PropertyField(new Rect(  // Name field
                rect.x + prefixWidth,
                rect.y + padding,
                rect.width / 2 - prefixWidth,
                lineHeight
                ), characterName, GUIContent.none);

            EditorGUI.PropertyField(new Rect(  // Text field
                rect.x + prefixWidth,
                rect.y + padding * 2,
                rect.width - prefixWidth,
                lineHeight * 5
                ), text, GUIContent.none);

            EditorGUI.PropertyField(new Rect(  // Icon field
                rect.x + prefixWidth + rect.width / 2,
                rect.y + padding,
                rect.width / 2 - prefixWidth,
                lineHeight
                ), faceIcon, GUIContent.none);

            EditorGUI.PropertyField(new Rect(  // Character field
                rect.x + prefixWidth,
                rect.y + padding * 6 + lineHeight * 4,
                rect.width - prefixWidth,
                lineHeight
                ), character, GUIContent.none);

            /*
            Rect[] rects = ListBeautifier(rect, propertyCount, prefixLength);

            EditorGUI.LabelField(rects[0], labelName);
            EditorGUI.PropertyField(rects[1], speakerName, GUIContent.none);
            EditorGUI.LabelField(rects[2], labelSentence);
            EditorGUI.PropertyField(rects[3], sentence, GUIContent.none);
            */


        };

        _list.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Quotes");
        };

        _list.elementHeightCallback = (int index) =>
        {
            return (lineHeight + spacing + paddingInternal) * heightMultiplier + padding * 2;
        };
    }

    /*
    private Rect[] ListBeautifier(Rect rect, int propertyCount, float prefixLength) 
    {
        float spacing = EditorGUIUtility.standardVerticalSpacing;

        Rect[] rects = new Rect[propertyCount * 2];

        for (int i = 0; i < propertyCount; i++)
        {
            // Label               
            float x1 = rect.x;
            float y1 = rect.y + i * ((rect.height + spacing / propertyCount) / propertyCount);
            float w1 = prefixLength;
            float h1 = rect.height / propertyCount;
            rects[i * 2] = new Rect(x1, y1, w1, h1);

            // Field                
            float x2 = x1 + prefixLength;
            float y2 = y1;
            float w2 = rect.width - w1;
            float h2 = h1;
            rects[i * 2 + 1] = new Rect(x2, y2, w2, h2);
        }

        return rects;
    }
    */

}    
