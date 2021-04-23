using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Universal;

public class Uscenes_SearchPatterns
{



    private static SelectorsConfig configDev = new SelectorsConfig
    {
        enable = true,
        onEnableSceneMonitor = () => { },
        selectors = new Selector[]
        {

            // By name
            new Selector
            {
                pattern = "Start",
            },
            new Selector
            {
                pattern = "Intro",
            },
            new Selector
            {
                pattern = "Game",
            },
            new Selector
            {
                pattern = "*",
            },
            new Selector
            {
                pattern = "*Nitro",
            },
            new Selector
            {
                pattern = "*Vector",
            },
            new Selector
            {
                pattern = "Level*",
            },
            new Selector
            {
                pattern = "Menu*",
            },
            new Selector
            {
                pattern = "Level*s",
            },
            new Selector
            {
                pattern = "Menu*Intro",
            },
            new Selector
            {
                pattern = "*Game*",
            },
            new Selector
            {
                pattern = "*Menu*",
            },
            new Selector
            {
                pattern = "**",
            },
            new Selector
            {
                pattern = "**Game",
            },
            new Selector
            {
                pattern = "Game**",
            },
            new Selector
            {
                pattern = "**re*",
            },
            new Selector
            {
                pattern = "*Vector*Level*",
            },
            new Selector
            {
                pattern = "*re**",
            },
            new Selector
            {
                pattern = "yu**",
            },
            new Selector
            {
                pattern = "Ga**me",
            },
            new Selector
            {
                pattern = "*Game==",
            },

            // By Index
            new Selector
            {
                pattern = "#0",
            },
            new Selector
            {
                pattern = "#3",
            },
            new Selector
            {
                pattern = "#11",
            },
            new Selector
            {
                pattern = "#<3",
            },
            new Selector
            {
                pattern = "#>10",
            },
            new Selector
            {
                pattern = "#<=3",
            },
            new Selector
            {
                pattern = "#>=3",
            },
            new Selector
            {
                pattern = "#3ee3",
            },
            new Selector
            {
                pattern = "#>pooo",
            },
            new Selector
            {
                pattern = "#>=3.22",
            },
            new Selector
            {
                pattern = "#>=3s222s",
            },

            // By path
            new Selector
            {
                pattern = ".Assets/*",
            },
            new Selector
            {
                pattern = ".Assets/Scenes/*",
            },
            new Selector
            {
                pattern = ".Assets/Scenes/Intro",
            },
            new Selector
            {
                pattern = ".*",
            },
            new Selector
            {
                pattern = ".",
            },
            new Selector
            {
                pattern = ".*Scenes/Intro",
            },

            new Selector
            {
                pattern = "*Game|||#2",
            },
            new Selector
            {
                pattern = "*Game&&&#2",
            },

        },

        // Scenes para solo dar el path y que haga referencia a solo una esena y haga lo de
        // solo cargar una a la vez y todo eso ... que sea aparte de los scenes patterns

    };





    // A Test behaves as an ordinary method
    [Test]
    [TestCase("Intro", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Start", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Game", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("SuperNitro", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("VectorLevel", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("wVectorLevel", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("VectorwLevel", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("VectorLevelw", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("LevelVector", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("MegaVector", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Level11", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Level21", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Menu3", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Level222", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("23Levels", 2, "Assets/Scenes/Intro.Unity")]

    [TestCase("Dog", 0, "Assets/Scenes/Intro.Unity")]
    [TestCase("Dog", 3, "Assets/Scenes/Intro.Unity")]
    [TestCase("Dog", 11, "Assets/Scenes/Intro.Unity")]
    [TestCase("Dog", 2, "Assets/Scenes/Intro.Unity")]
    [TestCase("Dog", 40, "Assets/Scenes/Intro.Unity")]

    [TestCase("Dog", 40, "Assets/Intro.unity")]
    [TestCase("Dog", 40, "Assets/Scenes/Menu.unity")]
    [TestCase("Dog", 40, "Assets/Scenes/Intro.unity")]
    [TestCase("Dog", 40, "Assets/Perro/Gato/ScenesIntro.unity")]
    [TestCase("Dog", 40, "Perro/Scenes/Intro.unity")]
    public void Uscenes_SearchPatternsSimplePasses(string name, int buildIndex, string path)
    {

        var search = SceneMonitor.Instance.SearchScenePattern(name, buildIndex, path, configDev);

        Debug.Log("Scene: " + name + " " + buildIndex + " " + path);

        foreach (var item in search)
        {
            Debug.Log("PSelector: " + item.pattern);
        }

    }


}
