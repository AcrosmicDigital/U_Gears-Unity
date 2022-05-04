using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateCustomStartupMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/Control/Startup/";
        private static string DefaultFileName => "NewStartup";
        private static string CustomExtension => "startup";
        static string[] file(string fileName) => new string[]
        {
            "using UnityEngine;",
            "",
            "public static partial class Startup",
            "{",
            "    public static bool is"+fileName+"Ready { get; private set; } = false;",
            "",
            "    public static void "+fileName+"()",
            "    {",
            "        if (is"+fileName+"Ready) return;",
            "",
            "        // Code here",
            "        // ...",
            "",
            "        // End code",
            "        is"+fileName+"Ready = true;",
            "    }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Control/Startup")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, file, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}