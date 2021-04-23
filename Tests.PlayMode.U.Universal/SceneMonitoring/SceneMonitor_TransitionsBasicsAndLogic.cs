using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using U.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneMonitor_TransitionsBasicsAndLogic
{

    [OneTimeSetUp]
    public void OneTimeSetUp() { }


    [SetUp]
    public void SetUp()
    {
        // All test must start in intro scene
        SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
        SceneMonitor.Instance.SetConfig(null);
    }





    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneInmediately()
    {
        
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion("Menu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        
        SceneMonitor.Instance.Transtion(3, "Menu").Then(Reject: e => Debug.LogError(e));
        
        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelay_ButCalcelIt()
    {
        
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Relative, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        SceneMonitor.Instance.CancelTransition("cargaMenu");

        yield return new WaitForSecondsRealtime(2);
        
        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelay_ButCalcelItLoadingOtherScene()
    {
        
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Relative, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion("Level1").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelayButAbsolute_LoadingOtherSceneCantCancelIt()
    {

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion("Level1").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelayButAbsolute_ButCancelIt()
    {

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.CancelAbsoluteTransition("cargaMenu");

        yield return new WaitForSecondsRealtime(2);
        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelay_ButCalcelAllTransitions()
    {

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Relative, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        SceneMonitor.Instance.CancelAllTransitions();

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelayButAbsolute_CalcelAllTransitionsDontCancelIt()
    {

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        SceneMonitor.Instance.CancelAllTransitions();

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_LoadOtherSceneWithDelayButAbsolute_CalcelAllTransitionsAbsoluteCanCancel()
    {

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        SceneMonitor.Instance.CancelAllAbsoluteTransitions();

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_IfManyTransitionsOnlyFirstWillBePerformed()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_IfManyTransitionsModeAbsoluteAllWillBePerformed()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_AnAbsoluteTransitionIsNotCanceled()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_ManyTransitionsCanBeCanceled()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Relative).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Relative).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1", SceneMonitor.TransitionMode.Relative).Then(Reject: e => Debug.LogError(e));

        SceneMonitor.Instance.CancelAllTransitions();

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_ManyAbsoluteTransitionsCantBeCanceledLikeRelativeTransitions()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));

        SceneMonitor.Instance.CancelAllTransitions();

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_ManyAbsoluteTransitionsCanBeCancel()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, "Menu", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));

        SceneMonitor.Instance.CancelAllAbsoluteTransitions();

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_ManyTransitionsCanBeCanceledWithCancelString()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(2, "Menu", SceneMonitor.TransitionMode.Relative, "cancelString").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(3, "Game", SceneMonitor.TransitionMode.Relative, "cancelString").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Relative).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1", SceneMonitor.TransitionMode.Relative, "cancelString").Then(Reject: e => Debug.LogError(e));

        SceneMonitor.Instance.CancelTransition("cancelString");

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_ManyAbsoluteTransitionsCanBeCanceledWithCancelString()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(2, "Menu", SceneMonitor.TransitionMode.Absolute, "cancelString").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(3, "Game", SceneMonitor.TransitionMode.Absolute, "cancelString").Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(4, "Menu1", SceneMonitor.TransitionMode.Absolute).Then(Reject: e => Debug.LogError(e));
        SceneMonitor.Instance.Transtion(5, "Level1", SceneMonitor.TransitionMode.Absolute, "cancelString").Then(Reject: e => Debug.LogError(e));

        SceneMonitor.Instance.CancelAbsoluteTransition("cancelString");

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Menu1", SceneManager.GetActiveScene().name);

    }


    [UnityTest]
    public IEnumerator Transition_ReloadSceneInmediately()
    {
        var go = new GameObject("Tester");

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion().Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.IsTrue(go == null);

    }


    [UnityTest]
    public IEnumerator Transition_ReloadSceneWithDelay()
    {
        var go = new GameObject("Tester");

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3).Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.IsFalse(go == null);
        yield return new WaitForSecondsRealtime(2);
        Assert.IsTrue(go == null);

    }


    [UnityTest]
    public IEnumerator Transition_ReloadSceneWithDelay_ButCalcelIt()
    {
        var go = new GameObject("Tester");

        yield return new WaitForSecondsRealtime(2);

        SceneMonitor.Instance.Transtion(3, SceneMonitor.TransitionMode.Relative, "cargaMenu").Then(Reject: e => Debug.LogError(e));

        yield return new WaitForSecondsRealtime(2);

        Assert.IsFalse(go == null);

        SceneMonitor.Instance.CancelTransition("cargaMenu");

        yield return new WaitForSecondsRealtime(2);
        Assert.IsFalse(go == null);

    }


    [UnityTest]
    public IEnumerator Transition_OnlyOnetransitionAtTimeWillBeDone()
    {
        yield return new WaitForSecondsRealtime(2);

        var operationOne = SceneMonitor.Instance.Transtion(3, "Menu", 3, 3, SceneMonitor.TransitionMode.Absolute);
        var operationTwo = SceneMonitor.Instance.Transtion(4, "Menu1", 3, 3, SceneMonitor.TransitionMode.Absolute);
        var operationThree = SceneMonitor.Instance.Transtion(5, "Level1", 3, 3, SceneMonitor.TransitionMode.Absolute);

        yield return new WaitForSecondsRealtime(3.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(1);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(2);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        yield return new WaitForSecondsRealtime(4);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        Debug.Log("Op1: " + operationOne.Result);
        Debug.Log("Op2: " + operationTwo.Result);
        Debug.Log("Op3: " + operationThree.Result);

    }

}
