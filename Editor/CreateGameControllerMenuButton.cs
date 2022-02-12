using UnityEditor;
using static U.Gears.Editor.UE;

namespace U.Gears.Editor
{
    public class CreateGameControllerMenuButton : EditorWindow
    {

        #region File
        private static string FolderName => "/Scripts/Controllers/";
        private static string FileName => "Game.controller.cs";
        private readonly static string[] file =
        {
            "using System;",
            "using UnityEngine;",
            "",
            "public static partial class Control",
            "{",
            "    public static partial class Game",
            "    {",
            "",
            "        public static void ReadyToStart()",
            "        {",
            "            Debug.Log("+quote+"GameController: Ready To Start"+quote+");",
            "            // ...",
            "        }",
            "",
            "        public static void StartGame()",
            "        {",
            "            Debug.Log("+quote+"GameController: Start Game"+quote+");",
            "            // ...",
            "        }",
            "",
            "        public static void GameOver()",
            "        {",
            "            Debug.Log("+quote+"GameController: Game Over"+quote+");",
            "            // ...",
            "        }",
            "",
            "        public static void Continue()",
            "        {",
            "            Debug.Log("+quote+"GameController: Continue"+quote+");",
            "            // ...",
            "        }",
            "",
            "        public static void Pause()",
            "        {",
            "            Debug.Log("+quote+"GameController: Pause"+quote+");",
            "            // ...",
            "        }",
            "",
            "        public static void Resume()",
            "        {",
            "            Debug.Log("+quote+"GameController: Resume"+quote+");",
            "            // ...",
            "        }",
            "",
            "        public static void Reset()",
            "        {",
            "            Debug.Log("+quote+"GameController: Reset"+quote+");",
            "            // ...",
            "        }",
            "",
            "    }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "UniversalGears: " + text;


        [MenuItem("Universal/Gears/Create/Controllers/Game Controller")]
        public static void ShowWindow()
        {

            // Create files
            CreateFile(FolderName, FileName, file, FormatLog);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}