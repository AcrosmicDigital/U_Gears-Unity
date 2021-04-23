using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using U.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneMonitor_TransitionFunctionsAndTime
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
    public IEnumerator Transition_TransitionFunctionsOrder()
    {

        yield return new WaitForSecondsRealtime(2);

        void SetUpTransition()
        {
            Debug.LogAssertion("Set Up");
        }

        void SetUpProgressTransition(float p)
        {
            Debug.Log("Set Up P: " + p);
        }

        void SetUpReadyTransition()
        {
            Debug.LogAssertion("Set Up ready");
        }

        void LoadProgressTransition(float p)
        {
            Debug.Log("Load P: " + p);
        }

        void TearDownTransition()
        {
            Debug.LogAssertion("Tear Down");
        }

        void TearDownProgressTransition(float p)
        {
            Debug.Log("Tear Down P: " + p);
        }

        void TearDownReadyTransition()
        {
            Debug.LogAssertion("Tear Down Ready");
        }

        SceneMonitor.Instance.Transtion("Menu", 3, 3, SceneMonitor.TransitionMode.Relative, 
            SetUpTransition, 
            SetUpProgressTransition,
            SetUpReadyTransition,
            LoadProgressTransition,
            TearDownTransition,
            TearDownProgressTransition,
            TearDownReadyTransition
            ).Then(Reject: e => Debug.LogError(e));

        LogAssert.Expect(LogType.Assert, "Set Up");
        LogAssert.Expect(LogType.Assert, "Set Up ready");
        LogAssert.Expect(LogType.Assert, "Tear Down");
        LogAssert.Expect(LogType.Assert, "Tear Down Ready");

        yield return new WaitForSecondsRealtime(6.1f);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }

    [UnityTest]
    public IEnumerator Transition_TransitionFunctionsThrowsError_AllFuntionsWillRunAndSceneWillBechanged()
    {

        yield return new WaitForSecondsRealtime(2);
        bool f1 = false;
        bool f2 = false;
        bool f3 = false;
        bool f4 = false;
        bool f5 = false;
        bool f6 = false;
        bool f7 = false;

        void SetUpTransition()
        {
            f1 = true;
            throw new Exception("Set Up");
        }

        void SetUpProgressTransition(float p)
        {
            f2 = true;
            throw new Exception("Set Up P: " + p);
        }

        void SetUpReadyTransition()
        {
            f3 = true;
            throw new Exception("Set Up ready");
        }

        void LoadProgressTransition(float p)
        {
            f4 = true;
            throw new Exception("Load P: " + p);
        }

        void TearDownTransition()
        {
            f5 = true;
            throw new Exception("Tear Down");
        }

        void TearDownProgressTransition(float p)
        {
            f6 = true;
            throw new Exception("Tear Down P: " + p);
        }

        void TearDownReadyTransition()
        {
            f7 = true;
            throw new Exception("Tear Down Ready");
        }

        SceneMonitor.Instance.Transtion("Menu", 3, 3, SceneMonitor.TransitionMode.Relative,
            SetUpTransition,
            SetUpProgressTransition,
            SetUpReadyTransition,
            LoadProgressTransition,
            TearDownTransition,
            TearDownProgressTransition,
            TearDownReadyTransition
            ).Then(Reject: e => Debug.LogError(e));

        LogAssert.ignoreFailingMessages = true;

        yield return new WaitForSecondsRealtime(6.1f);

        Assert.IsTrue(f1 && f2 && f3 && f4 && f5 && f6 && f7);
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }

    [UnityTest]
    public IEnumerator Transition_TransitionReload()
    {

        yield return new WaitForSecondsRealtime(2);

        void SetUpTransition()
        {
            Debug.LogAssertion("Set Up");
        }

        void SetUpProgressTransition(float p)
        {
            Debug.Log("Set Up P: " + p);
        }

        void SetUpReadyTransition()
        {
            Debug.LogAssertion("Set Up ready");
        }

        void LoadProgressTransition(float p)
        {
            Debug.Log("Load P: " + p);
        }

        void TearDownTransition()
        {
            Debug.LogAssertion("Tear Down");
        }

        void TearDownProgressTransition(float p)
        {
            Debug.Log("Tear Down P: " + p);
        }

        void TearDownReadyTransition()
        {
            Debug.LogAssertion("Tear Down Ready");
        }

        SceneMonitor.Instance.Transtion(3, 3, SceneMonitor.TransitionMode.Relative,
            SetUpTransition,
            SetUpProgressTransition,
            SetUpReadyTransition,
            LoadProgressTransition,
            TearDownTransition,
            TearDownProgressTransition,
            TearDownReadyTransition
            ).Then(Reject: e => Debug.LogError(e));

        LogAssert.Expect(LogType.Assert, "Set Up");
        LogAssert.Expect(LogType.Assert, "Set Up ready");
        LogAssert.Expect(LogType.Assert, "Tear Down");
        LogAssert.Expect(LogType.Assert, "Tear Down Ready");

        yield return new WaitForSecondsRealtime(6.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }




    class TrsncitionProveError : ITransition
    {

        public bool f1 = false;
        public bool f2 = false;
        public bool f3 = false;
        public bool f4 = false;
        public bool f5 = false;
        public bool f6 = false;
        public bool f7 = false;



        public void TransitionLoadProgres(float p)
        {
            f4 = true;
            throw new Exception("Load P: " + p);
        }

        public void TransitionSetUp()
        {
            f1 = true;
            throw new Exception("Set Up");
        }

        public void TransitionSetUpProgress(float p)
        {
            f2 = true;
            throw new Exception("Set Up P: " + p);
        }

        public void TransitionSetUpReady()
        {
            f3 = true;
            throw new Exception("Set Up ready");
        }

        public void TransitionTearDown()
        {
            f5 = true;
            throw new Exception("Tear Down");
        }

        public void TransitionTearDownProgress(float p)
        {
            f6 = true;
            throw new Exception("Tear Down P: " + p);
        }

        public void TransitionTearDownReady()
        {
            f7 = true;
            throw new Exception("Tear Down Ready");
        }
    }

    class TrsncitionProve : ITransition
    {

        public void TransitionLoadProgres(float p)
        {
            Debug.Log("Load P: " + p);
        }

        public void TransitionSetUp()
        {
            Debug.LogAssertion("Set Up");
        }

        public void TransitionSetUpProgress(float p)
        {
            Debug.Log("Set Up P: " + p);
        }

        public void TransitionSetUpReady()
        {
            Debug.LogAssertion("Set Up ready");
        }

        public void TransitionTearDown()
        {
            Debug.LogAssertion("Tear Down");
        }

        public void TransitionTearDownProgress(float p)
        {
            Debug.Log("Tear Down P: " + p);
        }

        public void TransitionTearDownReady()
        {
            Debug.LogAssertion("Tear Down Ready");
        }
    }

    [UnityTest]
    public IEnumerator Transition_TransitionITransitionOrder()
    {

        yield return new WaitForSecondsRealtime(2);

        var transition = new TrsncitionProve();

        SceneMonitor.Instance.Transtion("Menu", 3, 3, SceneMonitor.TransitionMode.Relative, transition
            ).Then(Reject: e => Debug.LogError(e));

        LogAssert.Expect(LogType.Assert, "Set Up");
        LogAssert.Expect(LogType.Assert, "Set Up ready");
        LogAssert.Expect(LogType.Assert, "Tear Down");
        LogAssert.Expect(LogType.Assert, "Tear Down Ready");

        yield return new WaitForSecondsRealtime(6.1f);

        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }

    [UnityTest]
    public IEnumerator Transition_TransitionITransitionThrowsError_AllFuntionsWillRunAndSceneWillBechanged()
    {

        yield return new WaitForSecondsRealtime(2);

        var transition = new TrsncitionProveError();


        SceneMonitor.Instance.Transtion("Menu", 3, 3, SceneMonitor.TransitionMode.Relative, transition).Then(Reject: e => Debug.LogError(e));

        LogAssert.ignoreFailingMessages = true;

        yield return new WaitForSecondsRealtime(6.1f);

        Assert.IsTrue(transition.f1 && transition.f2 && transition.f3 && transition.f4 && transition.f5 && transition.f6 && transition.f7);
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

    }

    [UnityTest]
    public IEnumerator Transition_TransitionITransitionReload()
    {

        yield return new WaitForSecondsRealtime(2);

        var transition = new TrsncitionProve();

        SceneMonitor.Instance.Transtion(3, 3, SceneMonitor.TransitionMode.Relative, transition
            ).Then(Reject: e => Debug.LogError(e));

        LogAssert.Expect(LogType.Assert, "Set Up");
        LogAssert.Expect(LogType.Assert, "Set Up ready");
        LogAssert.Expect(LogType.Assert, "Tear Down");
        LogAssert.Expect(LogType.Assert, "Tear Down Ready");

        yield return new WaitForSecondsRealtime(6.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);

    }
}
