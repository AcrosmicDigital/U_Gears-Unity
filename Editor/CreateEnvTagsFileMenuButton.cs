using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateEnvTagsFileMenuButton : EditorWindow
    {

        #region Tags File
        private static string FolderName => "/Scripts/Env/";
        private static string FileName => "Tags.cs";
        private readonly static string[] file =
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
        #endregion Tags File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Tags File")]
        public static void ShowWindow()
        {

            // Create files
            CreateFile(FolderName, FileName, file, FormatLog);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}