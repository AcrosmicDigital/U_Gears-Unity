using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.ActionsOn;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnStart))]
    public class ActionOnStartInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnStart c = (ActionOnStart)target;
            
            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"), true);
            if (c.enable)
            {
                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onStart"), true);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}
