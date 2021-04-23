using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using U.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneMonitor_Selectors
{

    

    [OneTimeSetUp]
    public void OneTimeSetUp() { }


    [SetUp]
    public void SetUp() 
    {
        SceneMonitor.Instance.SetConfig(null);
    }




    [UnityTest]
    public IEnumerator Selectors_OnlyFirstSceneDelegatePassed()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");
        SceneMonitor.Instance.SetConfig(config);


        yield return new WaitForSecondsRealtime(1);

        // Change scene
        var asyncoperation2 = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

    }

    [UnityTest]
    public IEnumerator Selectors_OnlyFirstSceneDelegatePassed_ButDisabled()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = false,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(1);

        // Change scene
        var asyncoperation2 = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

    }

    [UnityTest]
    public IEnumerator Selectors_OnlyFirstSceneDelegatePassed_ButError()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => throw new Exception("First Scene Loaded"),
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Error, new Regex("Error executing delegate onEnableSceneMonitor"));
        SceneMonitor.Instance.SetConfig(config);


        yield return new WaitForSecondsRealtime(1);

        // Change scene
        var asyncoperation2 = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

    }




    [UnityTest]
    public IEnumerator Selectors_SelectorWithNoPatternWontExecute()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
            selectors = new Selector[]
            {
                new Selector
                {
                    onLoad  = () => Debug.LogAssertion("OnLoad"),
                    onUnload  = () => Debug.LogAssertion("OnUnload"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive"),
                },
                new Selector
                {
                    onLoad  = () => Debug.LogAssertion("OnLoad"),
                }
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");
        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(1);

        // Change scene
        var asyncoperation2 = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

    }

    [UnityTest]
    public IEnumerator Selectors_OnePatternByName()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = "Intro",
                    onLoad  = () => Debug.LogAssertion("OnLoad Intro"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Intro"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Intro"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Intro"),
                },
                new Selector
                {
                    pattern = "Menu",
                    onLoad  = () => Debug.LogAssertion("OnLoad Menu"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Menu"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Menu"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Menu"),
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");

        LogAssert.Expect(LogType.Assert, "OnLoad Intro");
        LogAssert.Expect(LogType.Assert, "OnSetActive Intro");
        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(5);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnUnload Intro");
        LogAssert.Expect(LogType.Assert, "OnSetActive Menu");
        LogAssert.Expect(LogType.Assert, "OnLoad Menu");
        var asyncoperation2 = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

       
    }



    [UnityTest]
    public IEnumerator Selectors_OnePatternByName2()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = "Level*",
                    onLoad  = () => Debug.LogAssertion("OnLoad Level"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Level"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Level"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Level"),
                },
                new Selector
                {
                    pattern = "Level22",
                    onLoad  = () => Debug.LogAssertion("OnLoad Level22"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Level22"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Level22"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Level22"),
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");
        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(2);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnSetActive Level");
        LogAssert.Expect(LogType.Assert, "OnLoad Level");
        var asyncoperation2 = SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnUnload Level");
        LogAssert.Expect(LogType.Assert, "OnSetActive Level");
        LogAssert.Expect(LogType.Assert, "OnLoad Level");
        var asyncoperation3 = SceneManager.LoadSceneAsync("Level3", LoadSceneMode.Single);
        while (!asyncoperation3.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnUnload Level");
        LogAssert.Expect(LogType.Assert, "OnSetActive Level");
        LogAssert.Expect(LogType.Assert, "OnSetActive Level22");
        LogAssert.Expect(LogType.Assert, "OnLoad Level");
        LogAssert.Expect(LogType.Assert, "OnLoad Level22");
        var asyncoperation4 = SceneManager.LoadSceneAsync("Level22", LoadSceneMode.Single);
        while (!asyncoperation4.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);
    }

    [UnityTest]
    public IEnumerator Selectors_AndPatternByName3()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = "Level*&&*3*",
                    onLoad  = () => Debug.LogAssertion("OnLoad Level"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Level"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Level"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Level"),
                },
                new Selector
                {
                    pattern = "Level*&&*22",
                    onLoad  = () => Debug.LogAssertion("OnLoad Level22"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Level22"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Level22"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Level22"),
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");
        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(2);

        // Change scene
        var asyncoperation2 = SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnSetActive Level");
        LogAssert.Expect(LogType.Assert, "OnLoad Level");
        var asyncoperation3 = SceneManager.LoadSceneAsync("Level3", LoadSceneMode.Single);
        while (!asyncoperation3.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnUnload Level");
        LogAssert.Expect(LogType.Assert, "OnSetActive Level22");
        LogAssert.Expect(LogType.Assert, "OnLoad Level22");
        var asyncoperation4 = SceneManager.LoadSceneAsync("Level22", LoadSceneMode.Single);
        while (!asyncoperation4.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);
    }


    [UnityTest]
    public IEnumerator Selectors_OneByIndex()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = "#0",
                    onLoad  = () => Debug.LogAssertion("OnLoad 0"),
                    onUnload  = () => Debug.LogAssertion("OnUnload 0"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive 0"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive 0"),
                },
                new Selector
                {
                    pattern = "#>=1",
                    onLoad  = () => Debug.LogAssertion("OnLoad 1"),
                    onUnload  = () => Debug.LogAssertion("OnUnload 1"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive 1"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive 1"),
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");

        LogAssert.Expect(LogType.Assert, "OnLoad 0");
        LogAssert.Expect(LogType.Assert, "OnSetActive 0");
        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(5);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnUnload 0");
        LogAssert.Expect(LogType.Assert, "OnSetActive 1");
        LogAssert.Expect(LogType.Assert, "OnLoad 1");
        var asyncoperation2 = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);


    }



    [UnityTest]
    public IEnumerator Selectors_OnePatternByPath()
    {
        SelectorsConfig config = new SelectorsConfig
        {
            enable = true,
            onEnableSceneMonitor = () => Debug.LogAssertion("First Scene Loaded"),
            selectors = new Selector[]
            {
                new Selector
                {
                    pattern = ".*/Tests.PlayMode.U.Universal/SceneMonitoring/Intro",
                    onLoad  = () => Debug.LogAssertion("OnLoad Intro"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Intro"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Intro"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Intro"),
                },
                new Selector
                {
                    pattern = ".*/Tests.PlayMode.U.Universal/SceneMonitoring/Menu",
                    onLoad  = () => Debug.LogAssertion("OnLoad Menu"),
                    onUnload  = () => Debug.LogAssertion("OnUnload Menu"),
                    onSetActive  = () => Debug.LogAssertion("OnSetActive Menu"),
                    onSetInactive  = () => Debug.LogAssertion("OnSetInactive Menu"),
                },
            }
        };

        // All test must start in intro scene
        var asyncoperation = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        while (!asyncoperation.isDone) yield return null;

        LogAssert.Expect(LogType.Assert, "First Scene Loaded");

        LogAssert.Expect(LogType.Assert, "OnLoad Intro");
        LogAssert.Expect(LogType.Assert, "OnSetActive Intro");
        SceneMonitor.Instance.SetConfig(config);

        yield return new WaitForSecondsRealtime(5);

        // Change scene
        LogAssert.Expect(LogType.Assert, "OnUnload Intro");
        LogAssert.Expect(LogType.Assert, "OnSetActive Menu");
        LogAssert.Expect(LogType.Assert, "OnLoad Menu");
        var asyncoperation2 = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!asyncoperation2.isDone) yield return null;

        yield return new WaitForSecondsRealtime(1);


    }



}
