using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.ActionsOn;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnCollisionEnter2D))]
    public class ActionOnCollicionEnter2DInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnCollisionEnter2D c = (ActionOnCollisionEnter2D)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("scriptName"), true);
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"), true);
            if (c.enable)
            {
                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("damageMask"), true);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("damagedVelocity"), true);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("collisionsToAction"), true);

                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("infinityCount"), true);
                EditorGUI.indentLevel++;
                if(!c.infinityCount)
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("totalActions"), new GUIContent("Count"), true);
                EditorGUI.indentLevel--;

                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minTimeMode"), true);
                EditorGUI.indentLevel++;
                if (c.minTimeMode != ActionOnCollisionEnter2D.MinTimeMode.Disabled)
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("minTime"), new GUIContent("Time"), true);
                EditorGUI.indentLevel--;

                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onCollisionEnter"), true);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}

