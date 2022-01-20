using UnityEngine;
using UnityEditor;

namespace U.Gears.Editor
{
    public class VersionMenuButton : EditorWindow
    {

        [MenuItem("Universal/Gears/Version")]
        public static void PrintVersion()
        {

            Debug.Log(" U Framework: Gears v1.0.0 for Unity");

        }
    }
}

