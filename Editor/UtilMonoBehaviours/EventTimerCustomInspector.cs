using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.Timers;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(EventTimer))]
    //[CanEditMultipleObjects]
    public class EventTimerCustomInspector : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {

            EventTimer tweenTransform = (EventTimer)target;

            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("eventTimerName"), true);
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("playOnAwake"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeMode"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onCompleteMode"), true);
            if(tweenTransform.onCompleteMode != EventTimer.OnCompleteMode.Loop)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("iterations"), true);
            GUILayout.Space(10);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("actionsList"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("allowUnexpectedEnd"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }
}
