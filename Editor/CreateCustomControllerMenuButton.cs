using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateCustomControllerMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/Controllers/";
        private static string DefaultFileName => "New";
        private static string CustomExtension => "controller";
        static string[] file(string fileName) => new string[]
        {
            "using System;",
            "using UnityEngine;",
            "",
            "public static partial class Control",
            "{",
            "    public static partial class "+fileName+"",
            "    {",
            "",
            "        public static void ControlFunction()",
            "        {",
            "            Debug.Log("+quote+""+fileName+"Controller: ControlFunction"+quote+");",
            "            // ...",
            "",
            "",
            "        }",
            "",
            "    }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Controllers/Custom Controller")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, file, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}