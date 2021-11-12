using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.ActionsOn;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnFixedUpdate))]
    public class ActionOnFixedUpdateInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnFixedUpdate c = (ActionOnFixedUpdate)target;
            
            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"), true);
            if (c.enable)
            {
                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("iterations"), true);
                GUILayout.Space(4);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onFixedUpdate"), true);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}
