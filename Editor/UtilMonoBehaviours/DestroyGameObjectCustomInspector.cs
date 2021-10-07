using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace U.Gears
{

#if UNITY_EDITOR

    [CustomEditor(typeof(DestroyGameObject))]
    public class DestroyGameObjectCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {

            DestroyGameObject c = (DestroyGameObject)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("destroyOnAwake"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("destroyOnStart"), true);
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("delay"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeMode"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }

#endif
}
