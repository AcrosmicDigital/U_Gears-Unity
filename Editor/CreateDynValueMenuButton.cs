using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateDynValueMenuButton : EditorWindow
    {

        #region DynValue File
        private static string FolderName => "/Scripts/Dyn/";
        private static string DefaultFileName => "NewDynValue";
        static string[] file(string fileName) => new string[]
        {
            "",
            "public static partial class Dyn",
            "{",
            "    /// <summary>",
            "    /// This is a template of a dynamic global value, you can modify the type and value",
            "    /// </summary>",
            "    public static class "+fileName+"",
            "    {",
            "",
            "        #region Dyn",
            "        private static int _value = initialValue;  // Change type",
            "        public static int Value => _value;  // Change type",
            "        public static void Reset() => _value = initialValue;",
            "        private static int initialValue => 1;  // Change value and type",
            "        #endregion Dyn",
            "",
            "",
            "        public static void Set(int newValue)  // Change type or function",
            "        {",
            "            _value = newValue;",
            "        }",
            "",
            "    }",
            "}",
        };
        #endregion DynValue File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Dyn Value")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelForceLocation(FolderName, DefaultFileName, file, FormatLog);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}