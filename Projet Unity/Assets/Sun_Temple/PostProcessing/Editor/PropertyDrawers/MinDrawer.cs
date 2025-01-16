using UnityEngine;
using UnityEngine.PostProcessing;

using UnityEditor;
using UnityEngine;

using UnityEngine;

namespace UnityEditor.PostProcessing
{
    [CustomPropertyDrawer(typeof(UnityEngine.MinAttribute))] // Namespace explicite
    sealed class MinDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (attribute is UnityEngine.MinAttribute minAttribute) // Namespace explicite
            {
                if (property.propertyType == SerializedPropertyType.Integer)
                {
                    int value = EditorGUI.IntField(position, label, property.intValue);
                    property.intValue = Mathf.Max(value, (int)minAttribute.min);
                }
                else if (property.propertyType == SerializedPropertyType.Float)
                {
                    float value = EditorGUI.FloatField(position, label, property.floatValue);
                    property.floatValue = Mathf.Max(value, minAttribute.min);
                }
                else
                {
                    EditorGUI.LabelField(position, label.text, "Use Min with float or int.");
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Invalid MinAttribute.");
            }
        }
    }
}

