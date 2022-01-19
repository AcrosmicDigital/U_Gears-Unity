using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;
using System.IO;


#if UNITY_EDITOR

public class CreateEnvTagsFileMenuButton : EditorWindow
{

    private static string EnvFolderName => "/Scripts/Env/";
    private static string ScenesFileName => "Tags.cs";
    private static string FormatLog(string text) => "UniversalGears: " + text;


    [MenuItem("U/Universal Gears/Create Tags File")]
    public static void ShowWindow()
    {

        // Check if Env folder exist or create it
        if (!Directory.Exists(Application.dataPath + EnvFolderName))
        {
            Debug.Log(FormatLog("Creating Assets/" + EnvFolderName + " directory"));
            Directory.CreateDirectory(Application.dataPath + EnvFolderName);
        }
        else
        {
            Debug.Log(FormatLog("Assets/" + EnvFolderName + " already exist"));
        }

        // check if scenes file exist or create it
        if (!File.Exists(Application.dataPath + EnvFolderName + ScenesFileName))
        {
            Debug.Log(FormatLog("Creating Assets/" + EnvFolderName + ScenesFileName + " file"));

            // Write the file
            File.WriteAllLines(Application.dataPath + EnvFolderName + ScenesFileName, file); // This should be async when is available

            // Compile
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError(FormatLog("Assets/" + EnvFolderName + ScenesFileName + " already exist"));
        }

    }

    const string quote = "\"";
    static string[] file =
    {
        "",
        "public static partial class Env",
        "{",
        "    public static partial class Tags",
        "    {",
        "        //public static string MainCamera => " + quote + "MainCamera" + quote + ";",
        "",
        "    }",
        "}",
    };

}



#endif
