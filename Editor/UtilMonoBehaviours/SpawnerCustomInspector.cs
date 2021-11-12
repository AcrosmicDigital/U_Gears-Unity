using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace U.Gears.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Spawner))]
    //[CanEditMultipleObjects]
    public class SpawnerCustomInspector : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {

            Spawner spawner = (Spawner)target;

            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnMode"), true);

            EditorGUI.indentLevel++;
            if (spawner.minSpawns < 0) spawner.minSpawns = 0;
            if (spawner.maxSpawns < 0) spawner.maxSpawns = 0;
            if (spawner.spawnMode == Spawner.SpawnMode.RandomCount || spawner.spawnMode == Spawner.SpawnMode.RandomTrack)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minSpawns"), true);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxSpawns"), true);

                if (spawner.maxSpawns < spawner.minSpawns) spawner.minSpawns = spawner.maxSpawns;
            }
            else if (spawner.spawnMode == Spawner.SpawnMode.Count || spawner.spawnMode == Spawner.SpawnMode.Track)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxSpawns"), true);
            }
            EditorGUI.indentLevel--;

            GUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sortBetwenPoints"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sortBetwenObjects"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("setAsChildOf"), true);

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("objectsList"), true);

            GUILayout.Space(8);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnPoints"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnTransforms"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnInChildsOf"), true);

            GUILayout.Space(10);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onSpawn"), true);

            serializedObject.ApplyModifiedProperties();

        }
    }
}
