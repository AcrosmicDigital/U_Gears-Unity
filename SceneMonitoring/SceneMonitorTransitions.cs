using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace U.Universal
{
    public sealed partial class SceneMonitor
    {

        public enum TransitionMode
        {
            Relative,  // Transitions waiting are canceled when any transition is performed
            Absolute,  // Transitions are not canceled when a transition in performed
        }


        private List<string> relativeTransitionsList = new List<string>(); // List of autoLoadids
        private List<string> absoluteTransitionsList = new List<string>(); // List of autoLoadids
        private bool isInTransition = false;


        private async Task<bool> AwitForDelay(float delay, string cancelString, TransitionMode transitionMode, List<string> relativeList, List<string> absoluteList)
        {

            // All Transitions will have a token
            if (string.IsNullOrEmpty(cancelString))
                cancelString = Ids.NewIdShort() + "";

            // Add the cancel token to the list
            if (transitionMode == TransitionMode.Absolute && !absoluteList.Contains(cancelString))
                absoluteList.Add(cancelString);
            if (transitionMode == TransitionMode.Relative && !relativeList.Contains(cancelString))
                relativeList.Add(cancelString);

            // Await for the delay
            await UnityTask.WaitForSecondsRealtime(host, delay);

            // Check if still the cancell token in the list
            if (transitionMode == TransitionMode.Absolute)
            {
                if (absoluteList.Contains(cancelString))
                    absoluteList.Remove(cancelString);
                else
                    return false;
            }
            else if (transitionMode == TransitionMode.Relative)
            {
                if (relativeList.Contains(cancelString))
                    relativeList.Remove(cancelString);
                else
                    return false;
            }

            return true;

        }


        private Operation CancelAwaitForDelay(string cancelString, TransitionMode transitionMode, List<string> relativeList, List<string> absoluteList)
        {
            // Create the operation
            var operation = new Operation();

            // Add the cancel token to the list
            if (!string.IsNullOrEmpty(cancelString))
            {
                if (transitionMode == TransitionMode.Absolute)
                {
                    if (absoluteList.Contains(cancelString))
                    {
                        absoluteList.Remove(cancelString);
                        return operation.Successful("1");
                    }
                }
                else if(transitionMode == TransitionMode.Relative)
                {
                    if (relativeList.Contains(cancelString))
                    {
                        relativeList.Remove(cancelString);
                        return operation.Successful("1");
                    }
                }
            }

            return operation.Fails(new Exception("Cant Cancel Transition"));
        }






        private class TransitionTimer : MonoBehaviour
        {

            private float time = 0;
            private float duration = 0;
            private bool inverse = false;
            private Action<float> animate = null;
            private TaskCompletionSource<bool> tks = new TaskCompletionSource<bool>();


            public TransitionTimer Set(float duration, Action<float> animate, bool inverse)
            {
                this.duration = duration;
                this.animate = animate;
                this.inverse = inverse;

                return this;
            }

            public Task Task()
            {
                return tks.Task;
            }

            private void Update()
            {
                if (time > duration)
                {
                    tks.SetResult(true);
                    Destroy(this);
                    return;
                }

                time += Time.unscaledDeltaTime;

                try
                {
                    if (inverse)
                    {
                        animate?.Invoke(1f - Mathf.Clamp01(time / duration));
                    }
                    else
                    {
                        animate?.Invoke(Mathf.Clamp01(time / duration));
                    }

                }
                catch (Exception e)
                {
                    tks.SetResult(false);
                    Debug.LogError("Error in transition function " + e);
                    Destroy(this);
                }
            }

        }




        // Creates a transition between the current active scene and the next active scene, unloadind the current active
        // and set as active the new scene
        private async Task<Operation> DoTranstion(
            string sceneName,
            float delay,
            float startDelay,
            float endDelay,
            Action setUp,
            Action<float> setUpProgress,
            Action setUpReady,
            Action<float> loadProgress,
            Action tearDown,
            Action<float> tearDownProgress,
            Action tearDownReady,
            string cancelString,    // An id string that allows tocancel the operation 
            TransitionMode transitionMode  // If true the scene transiion is not canceled when other transition is performed
            )
        {

            // Create the operation
            var operation = new Operation();

            if (!await AwitForDelay(delay, cancelString, transitionMode, relativeTransitionsList, absoluteTransitionsList))
                return operation.Fails(new Exception("AutoLoadScene canceled"));

            // If is in transition any other must be done
            if (isInTransition)
                return operation.Fails(new Exception("Other transition in in progress"));
            else
                isInTransition = true;

            // Clear the relatives transitions
            relativeTransitionsList.Clear();

            // SetUp
            try { setUp?.Invoke(); }
            catch (Exception e) { Debug.LogError("Transition SetUp Error: " + e); }

            try
            {
                // SetUpProgress
                await host.AddComponent<TransitionTimer>().Set(startDelay, setUpProgress, false).Task();

                // SetUpReady
                try { setUpReady?.Invoke(); }
                catch (Exception e) { Debug.LogError("Transition SetUpReady Error: " + e); }

                // Load the new scene and if load download the prev
                var prevScene = SceneManager.GetActiveScene();

                // LoadProgess, load and unload
                await UnityTask.LoadSceneAsync(host, sceneName, LoadSceneMode.Additive, loadProgress);

                // Sets as active
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

                // Unload the prev
                await UnityTask.UnloadSceneAsync(host, prevScene.name);

                // TearDown
                try { tearDown?.Invoke(); }
                catch (Exception e) { Debug.LogError("Transition TearDown Error: " + e); }

                // TearDownProgress
                await host.AddComponent<TransitionTimer>().Set(endDelay, tearDownProgress, true).Task();

            }
            catch (Exception e)
            {
                Debug.Log("Transition Error: " + e);
                return operation.Fails(e);
            }

            isInTransition = false;

            // TearDownReady
            try { tearDownReady?.Invoke(); }
            catch (Exception e) { Debug.LogError("Transition TearDownReady Error: " + e); }

            return operation.Successful("1");

        }


        private Operation DoCancelTransition(string cancelString, TransitionMode transitionMode)
        {
            return CancelAwaitForDelay(cancelString, transitionMode, relativeTransitionsList, absoluteTransitionsList);
        }


        // Cancel all autoload next
        private void DoCancelAllTransitions(TransitionMode transitionMode)
        {

            if (transitionMode == TransitionMode.Absolute)
                absoluteTransitionsList.Clear();
            else if (transitionMode == TransitionMode.Relative)
                relativeTransitionsList.Clear();

        }


    }
}