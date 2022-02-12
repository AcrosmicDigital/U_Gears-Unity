using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateSerializableTypeMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/CustomTypes/";
        private static string DefaultFileName => "NewSerializableType";
        private static string CustomExtension => "stype";
        static string[] file(string fileName) => new string[]
        {
            "using System;",
            "using UnityEngine;",
            "using System.Collections.Generic;",
            "",
            "[Serializable]",
            "public class "+fileName+"",
            "{",
            "    //public int id;",
            "    //public string title { get; set; }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Types/Serializable")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, file, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}