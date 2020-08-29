using UnityEditor;
using UnityEngine;

public class ExtendedEditorWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty currentProperty;
    protected SerializedProperty selectedProperty;

    private string _selectedPropertyPath;

    protected void DrawProperties(SerializedProperty serializedProperty, bool drawChildren)
    {
        string lastPropertyPath = string.Empty;
        foreach (SerializedProperty property in serializedProperty)
        {
            if (property.isArray && property.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, property.displayName);
                EditorGUILayout.EndHorizontal();

                if (property.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    DrawProperties(property, drawChildren);
                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lastPropertyPath) && property.propertyPath.Contains(lastPropertyPath)) { continue; }
                lastPropertyPath = property.propertyPath;
                EditorGUILayout.PropertyField(property, drawChildren);
            }
        }
    }

    protected void DrawSidebar(SerializedProperty serializedProperty)
    {
        bool selected = false;

        foreach (SerializedProperty property in serializedProperty)
        {
            if (GUILayout.Button(property.displayName))
            {
                _selectedPropertyPath = property.propertyPath;
                selected = true;
            }
        }

        if (!string.IsNullOrEmpty(_selectedPropertyPath))
        {
            selectedProperty = serializedObject.FindProperty(_selectedPropertyPath);
            if (selected)
            {
                selected = false;
                OnPropertySelected();
            }
        }
    }

    protected void DrawField(string propertyName, bool isRelative = true)
    {
        SerializedProperty serializedProperty = FindPropertyByName(propertyName, isRelative);

        if (serializedProperty != null)
        {
            EditorGUILayout.PropertyField(serializedProperty, true);
        }
    }

    // useless crap for now
    protected void DrawChildren(string propertyName, bool isRelative = true)
    {
        SerializedProperty serializedProperty = FindPropertyByName(propertyName, isRelative);

        foreach (SerializedProperty property in serializedProperty)
        {
            EditorGUILayout.PropertyField(property, false);
        }
    }

    protected virtual void OnPropertySelected()
    {

    }

    private SerializedProperty FindPropertyByName(string propertyName, bool isRelative)
    {
        SerializedProperty serializedProperty = null;

        if (isRelative && currentProperty != null)
        {
            serializedProperty = currentProperty.FindPropertyRelative(propertyName);
        }
        else if (serializedObject != null)
        {
            serializedProperty = serializedObject.FindProperty(propertyName);
        }

        return serializedProperty;
    }
}
