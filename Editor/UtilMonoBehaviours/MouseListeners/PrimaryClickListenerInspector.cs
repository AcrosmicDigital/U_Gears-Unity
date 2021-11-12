using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.MouseListeners;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PrimaryClickListener))]
    public class PrimaryClickListenerInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
             
            PrimaryClickListener c = (PrimaryClickListener)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("listenOverUI"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("listenOutsideScreen"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("allowedClicks"), true);
            GUILayout.Space(10);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("OnClick"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("OnHold"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }
}
