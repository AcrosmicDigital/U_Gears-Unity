using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateEnvValueMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/Env/Vars/";
        private static string DefaultFileName => "New";
        private static string CustomExtension => "env";
        static string[] file(string fileName) => new string[]
        {
            "",
            "public static partial class Env",
            "{",
            "    public static partial class Vars",
            "    {",
            "",
            "        // Env Value 1",
            "        //public static bool value1 => true;",
            "",
            "        // Env Value 2",
            "        //public static readonly string value2 = "+quote+"Hello"+quote+";",
            "",
            "    }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Env Value")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, file, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}