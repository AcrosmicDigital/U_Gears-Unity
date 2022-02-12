using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateLayersFileMenuButton : EditorWindow
    {

        #region File
        private static string FolderName => "/Extras/";
        private static string FileName => "Layers.desc.txt";
        private readonly static string[] file =
        {
            "",
            "Layers",
            "",
            "# -1 Background",
            "",
            "   -1 Black screen",
            "	0 Background",
            "	5 Name",
            "",
            "",
            "# 20 House",
            "",
            "	25 shield",
            "",
            "	39 When explodes",
            "",
            "",
            "# 39 House",
            "",
            "",
            "# 50 Asteroids",
            "",
            "	55 Mega Asteroids",
            "",
            "	59 Normal & Mini Asteroids Trail",
            "	60 Normal & Mini Asteroids",
            "",
            "	64 Micro Asteroids Trail",
            "	65 Micro Asteroids",
            "",
            "",
            "# 200 Intro Animation",
            "",
            "	200 Background",
            "	210 Planet",
            "	215 Flag",
            "	220 Asteroids",
            "	230 Maximo",
            "",
            "",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Extras/Render Layers Desc")]
        public static void ShowWindow()
        {

            // Create files
            CreateFile(FolderName, FileName, file, FormatLog);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}