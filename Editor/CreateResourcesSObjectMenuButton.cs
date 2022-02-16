using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateResourcesSObjectMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/ResourcesClasses/";
        private static string DefaultFileName => "NewCustomResources";
        static string[] file(string fileName) => new string[]
        {
            "using UnityEngine;",
            "",
            "[CreateAssetMenu(fileName = "+quote+""+fileName+""+quote+", menuName = "+quote+"Resources/"+fileName+""+quote+")]",
            "public class "+fileName+" : ScriptableObject",
            "{",
            "    //public Sprite one;",
            "    //public Sprite two;",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Resources Class")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelForceLocation(DefaultFolderName, DefaultFileName, file, FormatLog);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}