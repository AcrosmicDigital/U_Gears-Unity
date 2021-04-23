using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using U.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneMonitor_SelectorsAndTransitions
{


    [OneTimeSetUp]
    public void OneTimeSetUp() { }


    [SetUp]
    public void SetUp()
    {
        SceneMonitor.Instance.SetConfig(null);
    }




    [UnityTest]
    public IEnumerator Selectors_TransitionOnSetActive()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = "Intro",
                    onSetActive = () => {
                        Debug.Log("Intro Set Active");

                        // Transition
                        SceneMonitor.Instance.Transtion(2, "Menu").Then(Reject: e => Debug.LogError(e), Resolve: o => Debug.Log(o + ""));
                    },
                    onLoad = () =>  {
                        Debug.Log("Intro Load");
                    },
                },
                new Selector
                {
                    pattern = "Menu",
                    onSetActive = () => {
                        Debug.Log("Menu Set Active");

                        // Transition
                        SceneMonitor.Instance.Transtion(3, "Game").Then(Reject: e => Debug.LogError(e), Resolve: o => Debug.Log(o + ""));
                    },
                    onLoad = () =>  {
                        Debug.Log("Menu Load");
                    },
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        // Start the scene Monitor, equivalent to Startup
        SceneMonitor.Instance.SetConfig(config);

        

        yield return new WaitForSecondsRealtime(3);
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(3);
        Assert.AreEqual("Game", SceneManager.GetActiveScene().name);


    }


    [UnityTest]
    public IEnumerator Selectors_TransitionOnLoad()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = "Intro",
                    onLoad = () => {
                        Debug.Log("Intro Set Active");

                        // Transition
                        SceneMonitor.Instance.Transtion(2, "Menu").Then(Reject: e => Debug.LogError(e), Resolve: o => Debug.Log(o + ""));
                    },
                    onSetActive = () =>  {
                        Debug.Log("Intro Load");
                    },
                },
                new Selector
                {
                    pattern = "Menu",
                    onLoad = () => {
                        Debug.Log("Menu Set Active");

                        // Transition
                        SceneMonitor.Instance.Transtion(3, "Game").Then(Reject: e => Debug.LogError(e), Resolve: o => Debug.Log(o + ""));
                    },
                    onSetActive = () =>  {
                        Debug.Log("Menu Load");
                    },
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        // Start the scene Monitor, equivalent to Startup
        SceneMonitor.Instance.SetConfig(config);



        yield return new WaitForSecondsRealtime(3);
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(3);
        Assert.AreEqual("Game", SceneManager.GetActiveScene().name);


    }

}
