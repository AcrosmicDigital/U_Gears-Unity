using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears
{
    public class ActionOnTime : MonoBehaviour
    {

        public string scriptName = "";
        public bool playOnAwake = true;
        public TimeMode timeMode = TimeMode.DeltaTime; // Time between functions calls
        public IterateMode iterateMode = IterateMode.Loop;
        public TimeBetweenActions betweenActions = TimeBetweenActions.Fixed;
        public float minDuration = .5f; // Time between functions calls
        public float maxDuration = 2; // Time between functions calls
        public int minIterations = 2; // Time between functions calls
        public int maxIterations = 5; // Time between functions calls
        public UnityEvent<GameObject> onTime;


        private bool isPaused = false;
        private float time = 0;
        private float duration = 2; // Time between functions calls
        private float iterations = 2; // Number of iterations
        private int completedIterations = 0;
        private bool pausedBeforeStart = false;


        private void Start()
        {
            
            if (!pausedBeforeStart)
                isPaused = !playOnAwake;

            // Set the duration
            if (betweenActions == TimeBetweenActions.Random)
                duration = Umath.RandomFloat(minDuration, maxDuration);
            else
                duration = maxDuration;

            // Set the iterations
            if (iterateMode == IterateMode.RandomCount)
                iterations = Umath.RandomInt(minIterations, maxIterations);
            else
                iterations = maxIterations;

        }

        protected void Update()
        {
            if (isPaused)
                return;

            // If iterations are completed
            if (iterateMode == IterateMode.Count || iterateMode == IterateMode.RandomCount)
            {
                if (completedIterations >= iterations)
                {
                    enabled = false;
                    return;
                }
            }

            // If the current time count is completed
            if (time >= duration)
            {
                completedIterations++;
                time -= duration;

                if (betweenActions == TimeBetweenActions.Random)
                    duration = Umath.RandomFloat(minDuration, maxDuration);
                else
                    duration = maxDuration;

                // Execute the delegates
                try
                {
                    onTime?.Invoke(gameObject);
                }
                catch (Exception e)
                {
                    Debug.LogError("OnTimeEventImplementer: Error in OnTime, " + e);
                }

            }

            if (timeMode == TimeMode.DeltaTime)
                time += Time.deltaTime;
            else
                time += Time.unscaledDeltaTime;
          
        }



        public void Play()
        {
            isPaused = false;
            pausedBeforeStart = true;
        }
        public void Pause()
        {
            isPaused = true;
            pausedBeforeStart = true;
        }

        public void Restart()
        {

            isPaused = !playOnAwake;
            time = 0;

            // Set the duration
            if (betweenActions == TimeBetweenActions.Random)
                duration = Umath.RandomFloat(minDuration, maxDuration);
            else
                duration = maxDuration;

            // Enable the component if disabled
            this.enabled = true;

        }

        public enum TimeMode
        {
            DeltaTime,
            DeltaUnscaledTime,
        }

        public enum IterateMode
        {
            Count,
            RandomCount,
            Loop,
        }

        public enum TimeBetweenActions
        {
            Random,
            Fixed,
        }




        public class Properties
        {
            public bool playOnAwake = true;
            public TimeMode timeMode = TimeMode.DeltaTime; // Time between functions calls
            public IterateMode iterateMode = IterateMode.Loop;
            public TimeBetweenActions betweenActions = TimeBetweenActions.Fixed;
            public float minDuration = .5f; // Time between functions calls
            public float maxDuration = 2; // Time between functions calls
            public int minIterations = 2; // Time between functions calls
            public int maxIterations = 5; // Time between functions calls
            public UnityEvent<GameObject> onTime;
        }


        public static ActionOnTime AddComponent(GameObject gameObject, Properties p)
        {
            if (p.betweenActions == TimeBetweenActions.Fixed && p.maxDuration <= 0)
            {
                throw new ArgumentOutOfRangeException("ActionOnTime: MaxDuration must be greater than 0");
            }
            else if (p.betweenActions == TimeBetweenActions.Random && (p.maxDuration < p.minDuration || p.minDuration <= 0))
            {
                throw new ArgumentOutOfRangeException("ActionOnTime: MinDuration must be greater than 0 and MaxDuration must be grater or equal that MinDuration");
            }

            if (p.iterateMode == IterateMode.Count && p.maxIterations <= 0)
            {
                throw new ArgumentOutOfRangeException("ActionOnTime: maxIterations must be greater than 0");
            }
            else if (p.iterateMode == IterateMode.Count && (p.maxIterations < p.minIterations || p.minIterations <= 0))
            {
                throw new ArgumentOutOfRangeException("ActionOnTime: Iterations must be greater than 0");
            }



            var c = gameObject.AddComponent<ActionOnTime>();

            c.playOnAwake = p.playOnAwake;
            c.timeMode = p.timeMode;
            c.iterateMode = p.iterateMode;
            c.betweenActions = p.betweenActions;
            c.minDuration = p.minDuration;
            c.maxDuration = p.maxDuration;
            c.minIterations = p.minIterations;
            c.maxIterations = p.maxIterations;

            var ev = new UnityEvent<GameObject>();
            ev.AddListener(g => p.onTime?.Invoke(g));
            c.onTime = ev;

            return c;
        }


    }

}
