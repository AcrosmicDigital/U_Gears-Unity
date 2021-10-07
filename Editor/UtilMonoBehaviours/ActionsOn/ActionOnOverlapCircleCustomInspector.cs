using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace U.Gears
{
#if UNITY_EDITOR

    [CustomEditor(typeof(ActionOnOverlapCircle))]
    public class ActionOnOverlapCircleCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnOverlapCircle c = (ActionOnOverlapCircle)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("scriptName"), true);
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
            if (c.minTimeMode != ActionOnOverlapCircle.MinTimeMode.Disabled)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minTime"), new GUIContent("Time"), true);
            EditorGUI.indentLevel--;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onOverlapCircle"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }
#endif
}


