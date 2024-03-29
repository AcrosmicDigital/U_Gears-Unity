﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using U.Gears.ActionsOn;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ActionOnTime))]
    public class ActionOnTimeInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            ActionOnTime c = (ActionOnTime)target;

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("playOnAwake"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeMode"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("betweenActions"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("iterateMode"), true);

            GUILayout.Space(5);
            GUILayout.Label("Duration");
            EditorGUI.indentLevel++;
            if (c.maxDuration <= 0) c.maxDuration = .0001f;
            if (c.minDuration <= 0) c.minDuration = .0001f;
            if (c.betweenActions == ActionOnTime.TimeBetweenActions.Random)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minDuration"), true);

                if (c.maxDuration < c.minDuration) c.minDuration = c.maxDuration;
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("maxDuration"), true);
            EditorGUI.indentLevel--;
            

            GUILayout.Space(5);
            if (c.minIterations <= 0) c.minIterations = 1;
            if (c.maxIterations <= 0) c.maxIterations = 1;
            if (c.iterateMode == ActionOnTime.IterateMode.Count)
            {
                GUILayout.Label("Iterations");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxIterations"), true);
                EditorGUI.indentLevel--;
            }
            else if (c.iterateMode == ActionOnTime.IterateMode.RandomCount)
            {
                GUILayout.Label("Iterations");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minIterations"), true);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxIterations"), true);
                EditorGUI.indentLevel--;

                if (c.maxIterations < c.minIterations) c.minIterations = c.maxIterations;
            }
            

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onTimeEvent"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }
}
