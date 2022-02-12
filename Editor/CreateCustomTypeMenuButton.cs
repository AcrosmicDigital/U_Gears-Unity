using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateCustomTypeMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/CustomTypes/";
        private static string DefaultFileName => "NewCustomType";
        private static string CustomExtension => "ctype";
        static string[] file(string fileName) => new string[]
        {
            "using System;",
            "using UnityEngine;",
            "using System.Collections.Generic;",
            "",
            "public class "+fileName+"",
            "{",
            "    //public int id;",
            "    //public string title { get; set; }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Types/Custom")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, file, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}