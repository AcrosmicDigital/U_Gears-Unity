using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;
using System.Text.RegularExpressions;

public class EventTimer_General
{

    // Falta provar los eventos y Tasks
    // Anu Monobeha
    class Abehaviour: MonoBehaviour { }
    
    [UnityTest]
    public IEnumerator EventTimer_BasicPassingEventList()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () => 
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);

    }

    [UnityTest]
    public IEnumerator EventTimer_UnscaledDeltaTime_WithTimeScaleToHalf_WillRunNormally()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // Time to half
        Time.timeScale = .5f;

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);

    }

    [UnityTest]
    public IEnumerator EventTimer_DeltaTime_WithTimeScaleToHalf_WillRunSlowly()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            timeMode = EventTimer.TimeMode.DeltaTime,
        });

        // Time to half
        Time.timeScale = .5f;

        // .1
        yield return new WaitForSecondsRealtime(.12f);
        Assert.IsFalse(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsFalse(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsFalse(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsFalse(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsFalse(ev5);

        yield return new WaitForSecondsRealtime(9f);
        Assert.IsTrue(ev1);
        Assert.IsTrue(ev2);
        Assert.IsTrue(ev3);
        Assert.IsTrue(ev4);
        Assert.IsTrue(ev5);
    }

    [UnityTest]
    public IEnumerator EventTimer_PlayOnAwakeFalse_WillWaitUnitilManualPlay()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties 
        {
            gameObject = go,
            actionsList = eventsList,
            playOnAwake = false,
        });

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsFalse(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsFalse(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsFalse(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsFalse(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsFalse(ev5);




        // Play the component
        eventTimer.Play();


        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);



    }

    [UnityTest]
    public IEnumerator EventTimer_Pause_WillPauseExecution()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // Pause
        eventTimer.Pause();

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsFalse(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsFalse(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsFalse(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsFalse(ev5);




        // Play the component
        eventTimer.Play();


        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);



    }

    [UnityTest]
    public IEnumerator EventTimer_Restart()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);


        // Variables
        ev1 = false;
        ev2 = false;
        ev3 = false;
        ev4 = false;
        ev5 = false;

        // Restart
        eventTimer.Restart();


        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);



    }

    [UnityTest]
    public IEnumerator EventTimer_ErrorInEvents_WillBePrintedAndContinue()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                    ev1 = true;
                    throw new System.Exception("Expected Exception");
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                    ev2 = true;
                    throw new System.Exception("Expected Exception");
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                    ev3 = true;
                    //throw new System.Exception("Expected Exception");
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                    ev4 = true;
                    //throw new System.Exception("Expected Exception");
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                    ev5 = true;
                    //throw new System.Exception("Expected Exception");
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // Error Logs
        LogAssert.Expect(LogType.Error, new Regex("Expected Exception"));
        LogAssert.Expect(LogType.Error, new Regex("Expected Exception"));
        LogAssert.Expect(LogType.Error, new Regex("Expected Exception"));

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);

    }

    [UnityTest]
    public IEnumerator EventTimer_DestroyGamoObjectBeforeEnd_WillNotThrowError()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // Destroy
        UnityEngine.Object.Destroy(go);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsFalse(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsFalse(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsFalse(ev5);

    }

    [UnityTest]
    public IEnumerator EventTimer_DestroyGamoObjectBeforeEnd_WillThrowErrorIfNotAllowunexpectedEnd()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            allowUnexpectedEnd = false,
        });

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // Destroy
        LogAssert.Expect(LogType.Error, new Regex("System.Exception: Component or GameObject was destroyed before animation completes"));
        UnityEngine.Object.Destroy(go);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsFalse(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsFalse(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsFalse(ev5);

    }

    [UnityTest]
    public IEnumerator IterationsCount_WillCountIteratios()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            iterations = 4,
        });

        // Wait for 4 iterations 
        yield return new WaitForSecondsRealtime(7f);
        Assert.IsTrue(ev1 == 4);
        Assert.IsTrue(ev2 == 4);
        Assert.IsTrue(ev3 == 4);
        Assert.IsTrue(ev4 == 4);
        Assert.IsTrue(ev5 == 4);

    }

    [UnityTest]
    public IEnumerator OnCompleteMode_Loop_WillLoopForever()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            onCompleteMode = EventTimer.OnCompleteMode.Loop,
        });

        // Wait for 4 iterations 
        yield return new WaitForSecondsRealtime(8.2f);
        eventTimer.Pause();
        Assert.IsTrue(ev1 > 6);
        Assert.IsTrue(ev2 > 6);
        Assert.IsTrue(ev3 > 6);
        Assert.IsTrue(ev4 > 6);
        Assert.IsTrue(ev5 > 6);

    }

    [UnityTest]
    public IEnumerator OnCompleteMode_Disable_WillDisableComponent()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            // onCompleteMode = EventTimer.OnCompleteMode.Disable, // Is default
        });

        // Wait for 4 iterations 
        yield return new WaitForSecondsRealtime(1.2f);

        // Is disabled
        Assert.IsFalse(eventTimer.enabled);

    }


    [UnityTest]
    public IEnumerator OnCompleteMode_None_WontDisableComponent()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            onCompleteMode = EventTimer.OnCompleteMode.None,
        });

        // Wait for 4 iterations 
        yield return new WaitForSecondsRealtime(1.2f);

        // Is disabled
        Assert.IsTrue(eventTimer.enabled);

    }

    [UnityTest]
    public IEnumerator OnCompleteMode_DestroyComponent_WillDestroyTheComponent()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            onCompleteMode = EventTimer.OnCompleteMode.DestroyComponent,
        });

        // Wait for 4 iterations 
        yield return new WaitForSecondsRealtime(1.2f);

        // Is disabled
        Assert.IsTrue(eventTimer == null);

    }

    [UnityTest]
    public IEnumerator OnCompleteMode_DestroyGameObject_WillDestroyTheGameobject()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            onCompleteMode = EventTimer.OnCompleteMode.DestroyGameObject,
        });

        // Wait for 4 iterations 
        yield return new WaitForSecondsRealtime(1.2f);

        // Is destroyed
        Assert.IsTrue(eventTimer == null);
        Assert.IsTrue(go == null);

    }


    [UnityTest]
    public IEnumerator WaitAsTask_WillReturnATask()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        async void WaitFunc()
        {
            await eventTimer.Task();

            Assert.IsTrue(ev1 == 1);
            Assert.IsTrue(ev2 == 1);
            Assert.IsTrue(ev3 == 1);
            Assert.IsTrue(ev4 == 1);
            Assert.IsTrue(ev5 == 1);

            Debug.LogAssertion("Finished");
        }

        // Wait for 
        WaitFunc();
        LogAssert.Expect(LogType.Assert, new Regex("Finished"));
        yield return new WaitForSecondsRealtime(1.2f);

    }

    [UnityTest]
    public IEnumerator WaitAsCorroutine_WillReturnACoroutine()
    {
        // Crate a GameObject
        var go = new GameObject("Test");
        var cmp = go.AddComponent<Abehaviour>();

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        IEnumerator WaitFunc()
        {
            yield return eventTimer.Coroutine();

            Assert.IsTrue(ev1 == 1);
            Assert.IsTrue(ev2 == 1);
            Assert.IsTrue(ev3 == 1);
            Assert.IsTrue(ev4 == 1);
            Assert.IsTrue(ev5 == 1);

            Debug.LogAssertion("Finished");
        }

        // Wait for 
        cmp.StartCoroutine(WaitFunc());
        LogAssert.Expect(LogType.Assert, new Regex("Finished"));
        yield return new WaitForSecondsRealtime(1.2f);

    }


    [UnityTest]
    public IEnumerator WaitAsTask_AndDestroyGameObject_WontThrowException()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        async void WaitFunc()
        {
            Debug.Log("Started");
            await eventTimer.Task();
            Debug.Log("Finished");

            Debug.LogAssertion("Finished");
        }

        // Wait for 
        WaitFunc();
        LogAssert.Expect(LogType.Assert, new Regex("Finished"));
        UnityEngine.Object.Destroy(go);
        yield return new WaitForSecondsRealtime(1.2f);

    }

    [UnityTest]
    public IEnumerator WaitAsCorroutine_AndDestroyGameObject_WontThrowException()
    {
        // Crate a GameObject
        var go = new GameObject("Test");
        var cmp = new GameObject().AddComponent<Abehaviour>();

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        IEnumerator WaitFunc()
        {
            Debug.Log("Started");
            yield return eventTimer.Coroutine();
            Debug.Log("Finished");

            Debug.LogAssertion("Finished");
        }

        // Wait for 
        cmp.StartCoroutine(WaitFunc());
        LogAssert.Expect(LogType.Assert, new Regex("Finished"));
        UnityEngine.Object.Destroy(go);
        yield return new WaitForSecondsRealtime(1.2f);

    }

    [UnityTest]
    public IEnumerator WaitAsTask_AndDestroyGameObjectWithDontAllow_WillThrowException()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        LogAssert.ignoreFailingMessages = true;

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            allowUnexpectedEnd = false,
        });

        async void WaitFunc()
        {

            await eventTimer.Task();

            Debug.LogAssertion("Finished");
        }

        // Wait for two logs one from Timer, and One from Task
        WaitFunc();
        //LogAssert.Expect(LogType.Exception, new Regex("Exception: Component or GameObject was destroyed before animation completes"));
        //LogAssert.Expect(LogType.Error, new Regex("System.Exception: Component or GameObject was destroyed before animation complete"));
        UnityEngine.Object.Destroy(go);
        yield return new WaitForSecondsRealtime(1.2f);

    }

    [UnityTest]
    public IEnumerator WaitAsCorroutine_AndDestroyGameObjectWithDontAllow_WillThrowException()
    {
        // Crate a GameObject
        var go = new GameObject("Test");
        var cmp = go.AddComponent<Abehaviour>();

        // Variables
        var ev1 = 0;
        var ev2 = 0;
        var ev3 = 0;
        var ev4 = 0;
        var ev5 = 0;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .2f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .4f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = .8f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4++;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5++;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
            allowUnexpectedEnd = false,
        });

        IEnumerator WaitFunc()
        {
            yield return eventTimer.Coroutine();

            Debug.LogAssertion("Finished");
        }

        // Wait for 
        cmp.StartCoroutine(WaitFunc());
        LogAssert.Expect(LogType.Error, new Regex("System.Exception: Component or GameObject was destroyed before animation completes"));
        UnityEngine.Object.Destroy(go);
        yield return new WaitForSecondsRealtime(1.2f);

    }



    [UnityTest]
    public IEnumerator EventTimer_PauseAndPlayOnStart()
    {
        // Crate a GameObject
        var go = new GameObject("Test");

        // Variables
        var ev1 = false;
        var ev2 = false;
        var ev3 = false;
        var ev4 = false;
        var ev5 = false;

        // ActionList
        // .1  1.6  2  4  8
        EventTimer.TimeEventCode[] eventsList = new EventTimer.TimeEventCode[]
        {
            new EventTimer.TimeEventCode
            {
                time = .1f,
                action = () =>
                {
                    Debug.Log("Time .1f");
                     ev1 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 1.6f,
                action = () =>
                {
                    Debug.Log("Time 1.6f");
                     ev2 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 2f,
                action = () =>
                {
                    Debug.Log("Time 2f");
                     ev3 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 4f,
                action = () =>
                {
                    Debug.Log("Time 4f");
                     ev4 = true;
                },
            },
            new EventTimer.TimeEventCode
            {
                time = 8f,
                action = () =>
                {
                    Debug.Log("Time 8f");
                     ev5 = true;
                },
            },
        };

        var eventTimer = EventTimer.AddComponent(new EventTimer.Properties
        {
            gameObject = go,
            actionsList = eventsList,
        });

        // pause the events
        eventTimer.Pause();
        // Wait a minute
        yield return new WaitForSecondsRealtime(3f);

        // Check event dont ocurr yet
        Assert.IsFalse(ev1);
        Assert.IsFalse(ev2);
        Assert.IsFalse(ev3);
        Assert.IsFalse(ev4);
        Assert.IsFalse(ev5);

        // Play the events
        eventTimer.Play();

        // .1
        yield return new WaitForSecondsRealtime(.2f);
        Assert.IsTrue(ev1);

        // 1.6
        yield return new WaitForSecondsRealtime(1.6f);
        Assert.IsTrue(ev2);

        // 2
        yield return new WaitForSecondsRealtime(.3f);
        Assert.IsTrue(ev3);

        // 4
        yield return new WaitForSecondsRealtime(2f);
        Assert.IsTrue(ev4);

        // 8
        yield return new WaitForSecondsRealtime(4f);
        Assert.IsTrue(ev5);

    }

}
