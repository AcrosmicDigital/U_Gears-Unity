using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.ActionsOn;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnOverlapCircleEnter2D))]
    public class ActionOnOverlapCircleEnter2DInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnOverlapCircleEnter2D c = (ActionOnOverlapCircleEnter2D)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("damageMask"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("damagedRadius"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("overlapsToAction"), true);

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("infinityCount"), true);
            EditorGUI.indentLevel++;
            if (!c.infinityCount)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("totalActions"), new GUIContent("Count"), true);
            EditorGUI.indentLevel--;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("minTimeMode"), true);
            EditorGUI.indentLevel++;
            if (c.minTimeMode != ActionOnOverlapCircleEnter2D.MinTimeMode.Disabled)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minTime"), new GUIContent("Time"), true);
            EditorGUI.indentLevel--;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onOverlapCircle"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }
}


