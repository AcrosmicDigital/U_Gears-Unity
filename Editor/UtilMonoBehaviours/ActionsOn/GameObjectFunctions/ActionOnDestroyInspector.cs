using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.ActionsOn;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnDestroy))]
    public class ActionOnDestroyInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnDestroy c = (ActionOnDestroy)target;
            
            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("enable"), true);
            if (c.enable)
            {
                GUILayout.Space(8);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onDestroy"), true);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}
