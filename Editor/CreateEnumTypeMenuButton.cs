using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateEnumTypeMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/CustomTypes/";
        private static string DefaultFileName => "NewEnumType";
        private static string CustomExtension => "etype";
        static string[] file(string fileName) => new string[]
        {
            "",
            "public enum "+fileName+"",
            "{",
            "    //value1,",
            "    //value2,",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Types/Enum")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, file, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}