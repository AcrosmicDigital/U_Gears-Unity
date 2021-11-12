using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SetVelocity2D))]
    public class SetVelocity2DCustominspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            SetVelocity2D c = (SetVelocity2D)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rigidbdy2D"), true);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("setVelocityXmin"), true);
            if (c.setVelocityXmin)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityXmin"), true);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("setVelocityXmax"), true);
            if (c.setVelocityXmax)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityXmax"), true);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("setVelocityYmin"), true);
            if (c.setVelocityYmin)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityYmin"), true);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("setVelocityYmax"), true);
            if (c.setVelocityYmax)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityYmax"), true);
                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}