using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnLateUpdate))]
    public class ActionOnLateUpdateInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnLateUpdate c = (ActionOnLateUpdate)target;
            
            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"), true);
            if (c.enable)
            {
                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("iterations"), true);
                GUILayout.Space(4);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onLateUpdate"), true);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}
