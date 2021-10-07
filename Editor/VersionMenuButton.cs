using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR

public class VersionMenuButton : EditorWindow
{

    [MenuItem("U/Gears/Version")]
    public static void PrintVersion()
    {

        Debug.Log(" U Framework: Gears v1.0.0 for Unity");

    }
}


#endif
