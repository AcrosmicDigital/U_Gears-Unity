using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace U.Gears
{

#if UNITY_EDITOR

    [CustomEditor(typeof(ActionOnDestroy))]
    public class ActionOnDestroyCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnDestroy c = (ActionOnDestroy)target;
            
            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("scriptName"), true);
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"), true);
            if (c.enable)
            {
                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onDestroy"), true);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }

#endif
}
