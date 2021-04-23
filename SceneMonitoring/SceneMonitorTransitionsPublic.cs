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


        public async Task<Operation> Transtion(
            )
        {
            return await DoTranstion(
                sceneName: SceneManager.GetActiveScene().name,
                delay: 0,
                startDelay: 0,
                endDelay: 0,
                setUp: null,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: null,
                cancelString: "",
                transitionMode: TransitionMode.Absolute);
        }

        public async Task<Operation> Transtion(
            Action beforeSceneUnload,
            Action afterSceneLoad
            )
        {
            return await DoTranstion(
                sceneName: SceneManager.GetActiveScene().name,
                delay: 0,
                startDelay: 0,
                endDelay: 0,
                setUp: beforeSceneUnload,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: afterSceneLoad,
                cancelString: "",
                transitionMode: TransitionMode.Absolute);
        }

        public async Task<Operation> Transtion(
            string sceneName
            )
        {
            return await DoTranstion(
                sceneName, 
                delay: 0, 
                startDelay: 0, 
                endDelay: 0, 
                setUp: null, 
                setUpProgress: null, 
                setUpReady: null, 
                loadProgress: null, 
                tearDown: null, 
                tearDownProgress: null, 
                tearDownReady: null, 
                cancelString: "", 
                transitionMode: TransitionMode.Absolute);
        }

        public async Task<Operation> Transtion(
            string sceneName,
            Action beforeSceneUnload,
            Action afterSceneLoad
            )
        {
            return await DoTranstion(
                sceneName,
                delay: 0,
                startDelay: 0,
                endDelay: 0,
                setUp: beforeSceneUnload,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: afterSceneLoad,
                cancelString: "",
                transitionMode: TransitionMode.Absolute);
        }

        public async Task<Operation> Transtion(
            float delay,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                SceneManager.GetActiveScene().name,
                delay,
                startDelay: 0,
                endDelay: 0,
                setUp: null,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: null,
                cancelString,
                transitionMode);
        }

        public async Task<Operation> Transtion(
            float delay,
            Action beforeSceneUnload,
            Action afterSceneLoad,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                SceneManager.GetActiveScene().name,
                delay,
                startDelay: 0,
                endDelay: 0,
                setUp: beforeSceneUnload,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: afterSceneLoad,
                cancelString,
                transitionMode);
        }

        public async Task<Operation> Transtion(
            float delay,
            string sceneName,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                sceneName,
                delay,
                startDelay: 0,
                endDelay: 0,
                setUp: null,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: null,
                cancelString,
                transitionMode);
        }

        public async Task<Operation> Transtion(
            float delay,
            string sceneName,
            Action beforeSceneUnload,
            Action afterSceneLoad,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                sceneName,
                delay,
                startDelay: 0,
                endDelay: 0,
                setUp: beforeSceneUnload,
                setUpProgress: null,
                setUpReady: null,
                loadProgress: null,
                tearDown: null,
                tearDownProgress: null,
                tearDownReady: afterSceneLoad,
                cancelString,
                transitionMode);
        }






        public async Task<Operation> Transtion(
            float delay,
            string sceneName,
            float startDelay,
            float endDelay,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            Action setUp = null,
            Action<float> setUpProgress = null,
            Action setUpReady = null,
            Action<float> loadProgress = null,
            Action tearDown = null,
            Action<float> tearDownProgress = null,
            Action tearDownReady = null,
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                sceneName,
                delay,
                startDelay,
                endDelay,
                setUp,
                setUpProgress,
                setUpReady,
                loadProgress,
                tearDown,
                tearDownProgress,
                tearDownReady,
                cancelString,
                transitionMode);
        }

        public async Task<Operation> Transtion(
            string sceneName,
            float startDelay,
            float endDelay,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            Action setUp = null,
            Action<float> setUpProgress = null,
            Action setUpReady = null,
            Action<float> loadProgress = null,
            Action tearDown = null,
            Action<float> tearDownProgress = null,
            Action tearDownReady = null,
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                sceneName,
                delay: 0,
                startDelay,
                endDelay,
                setUp,
                setUpProgress,
                setUpReady,
                loadProgress,
                tearDown,
                tearDownProgress,
                tearDownReady,
                cancelString,
                transitionMode);
        }

        public async Task<Operation> Transtion(
            float delay,
            float startDelay,
            float endDelay,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            Action setUp = null,
            Action<float> setUpProgress = null,
            Action setUpReady = null,
            Action<float> loadProgress = null,
            Action tearDown = null,
            Action<float> tearDownProgress = null,
            Action tearDownReady = null,
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                SceneManager.GetActiveScene().name,
                delay,
                startDelay,
                endDelay,
                setUp,
                setUpProgress,
                setUpReady,
                loadProgress,
                tearDown,
                tearDownProgress,
                tearDownReady,
                cancelString,
                transitionMode);
        }


        public async Task<Operation> Transtion(
            float startDelay,
            float endDelay,
            TransitionMode transitionMode = TransitionMode.Relative,  // If true the scene transiion is not canceled when other transition is performed
            Action setUp = null,
            Action<float> setUpProgress = null,
            Action setUpReady = null,
            Action<float> loadProgress = null,
            Action tearDown = null,
            Action<float> tearDownProgress = null,
            Action tearDownReady = null,
            string cancelString = ""    // An id string that allows tocancel the operation 
            )
        {
            return await DoTranstion(
                SceneManager.GetActiveScene().name,
                delay: 0,
                startDelay,
                endDelay,
                setUp,
                setUpProgress,
                setUpReady,
                loadProgress,
                tearDown,
                tearDownProgress,
                tearDownReady,
                cancelString,
                transitionMode);
        }




        // Using ITransition Interface

        public async Task<Operation> Transtion(
           float delay,
           string sceneName,
           float startDelay,
           float endDelay,
           TransitionMode transitionMode,  // If true the scene load is not when other active scene load
           ITransition sceneTransition,
           string cancelString = ""    // An id string that allows tocancel the operation 
           )
        {
            return await DoTranstion(
                sceneName, 
                delay, 
                startDelay, 
                endDelay, 
                sceneTransition.TransitionSetUp, 
                sceneTransition.TransitionSetUpProgress, 
                sceneTransition.TransitionSetUpReady, 
                sceneTransition.TransitionLoadProgres, 
                sceneTransition.TransitionTearDown, 
                sceneTransition.TransitionTearDownProgress, 
                sceneTransition.TransitionTearDownReady,
                cancelString,
                transitionMode
                );

        }

        public async Task<Operation> Transtion(
           float delay,
           float startDelay,
           float endDelay,
           TransitionMode transitionMode,  // If true the scene load is not when other active scene load
           ITransition sceneTransition,
           string cancelString = ""    // An id string that allows tocancel the operation 
           )
        {
            return await DoTranstion(
                SceneManager.GetActiveScene().name,
                delay,
                startDelay,
                endDelay,
                sceneTransition.TransitionSetUp,
                sceneTransition.TransitionSetUpProgress,
                sceneTransition.TransitionSetUpReady,
                sceneTransition.TransitionLoadProgres,
                sceneTransition.TransitionTearDown,
                sceneTransition.TransitionTearDownProgress,
                sceneTransition.TransitionTearDownReady,
                cancelString,
                transitionMode
                );

        }

        public async Task<Operation> Transtion(
           string sceneName,
           float startDelay,
           float endDelay,
           TransitionMode transitionMode,  // If true the scene load is not when other active scene load
           ITransition sceneTransition,
           string cancelString = ""    // An id string that allows tocancel the operation 
           )
        {
            return await DoTranstion(
                sceneName,
                delay: 0,
                startDelay,
                endDelay,
                sceneTransition.TransitionSetUp,
                sceneTransition.TransitionSetUpProgress,
                sceneTransition.TransitionSetUpReady,
                sceneTransition.TransitionLoadProgres,
                sceneTransition.TransitionTearDown,
                sceneTransition.TransitionTearDownProgress,
                sceneTransition.TransitionTearDownReady,
                cancelString,
                transitionMode
                );

        }

        public async Task<Operation> Transtion(
           float startDelay,
           float endDelay,
           TransitionMode transitionMode,  // If true the scene load is not when other active scene load
           ITransition sceneTransition,
           string cancelString = ""    // An id string that allows tocancel the operation 
           )
        {
            return await DoTranstion(
                SceneManager.GetActiveScene().name,
                delay: 0,
                startDelay,
                endDelay,
                sceneTransition.TransitionSetUp,
                sceneTransition.TransitionSetUpProgress,
                sceneTransition.TransitionSetUpReady,
                sceneTransition.TransitionLoadProgres,
                sceneTransition.TransitionTearDown,
                sceneTransition.TransitionTearDownProgress,
                sceneTransition.TransitionTearDownReady,
                cancelString,
                transitionMode
                );

        }





        // Cancel Transition

        public Operation CancelTransition(string cancelString)
        {
            return DoCancelTransition(cancelString, TransitionMode.Relative);
        }

        public Operation CancelAbsoluteTransition(string cancelString)
        {
            return DoCancelTransition(cancelString, TransitionMode.Absolute);
        }



        // Cancel All Transitions

        public void CancelAllTransitions()
        {
            DoCancelAllTransitions(TransitionMode.Relative);
        }

        public void CancelAllAbsoluteTransitions()
        {
            DoCancelAllTransitions(TransitionMode.Absolute);
        }




    }
}