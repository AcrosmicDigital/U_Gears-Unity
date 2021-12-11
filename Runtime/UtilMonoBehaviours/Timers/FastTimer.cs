using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears
{

    public class FastTimer : MonoBehaviour
    {
        public float duration = 2;
        public bool playOnAwake = true;
        public TimeMode timeMode = TimeMode.DeltaTime;
        public bool allowUnexpectedEnd = true;  // Allow to be erased without throwing exception
        public bool loop = true;
        [Header("Events")]
        public UnityEvent OnComplete; // Called each time timmer reach the total time


        public bool IsCompleted => isCompleted;
        public bool IsWorking => isWorking;
        public float CurrentTime => time;


        private bool isPaused = false;
        private bool isCompleted = false;
        private bool isWorking = false;
        private float time = 0;  // Time elapsed
        private bool pausedBeforeStart = false;
        private TaskCompletionSource<bool> tks = new TaskCompletionSource<bool>();  // Task to wait for the animation


        private void Start()
        {
            if (!pausedBeforeStart)
                isPaused = !playOnAwake;
        }

        void Update()
        {
            isWorking = false;

            // When is paused or stack is empty return
            if (isPaused || isCompleted)
                return;

            // Add the delta time or unscaled time
            isWorking = true;
            if (timeMode == TimeMode.DeltaTime)
                time += Time.deltaTime;
            else
                time += Time.unscaledDeltaTime;


            // Si se ha completado
            if (time >= duration)
            {
                // Se pone como completado
                isCompleted = true;

                // OncompleteEvent
                try { OnComplete?.Invoke(); } catch (Exception e) { Debug.LogError("Error in OnComplete Event, " + e); }

                // If loop Restart
                if (loop) Restart();
            }
        }


        private void OnDestroy()
        {

            if (isCompleted)
                return;

            isCompleted = true;

            // OncompleteEvent
            try { OnComplete?.Invoke(); } catch (Exception e) { Debug.LogError("Error in OnComplete Event, " + e); }

            // Set error or resut if is allowed unexpected and
            if (!allowUnexpectedEnd)
            {
                var Error = new Exception("Component or GameObject was destroyed before animation completes");
                Debug.LogError(Error);

                if (!tks.Task.IsCompleted)
                    tks.SetException(Error);
            }
            else
            {
                if (!tks.Task.IsCompleted)
                    tks.SetResult(true);
            }

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
            isCompleted = false;
            time = 0;
            tks = new TaskCompletionSource<bool>();

            // Enable the component if disabled
            this.enabled = true;

        }

        public void Restart(float duration)
        {
            if (duration <= 0)
                throw new ArgumentException("Duration must be grater than 0");

            this.duration = duration;
            Restart();
        }

        // Function to get a Task to wait for animation completes or throw error
        public Task Task()
        {
            return tks.Task;
        }

        // Function to get a Coroutine to wait for animation completes or throw error
        public IEnumerator Coroutine()
        {
            var task = tks.Task;

            while (!task.IsCompleted)
                yield return null;

            if (task.Exception != null)
                throw task.Exception;

        }



        #region Enums and classes

        public enum TimeMode
        {
            DeltaTime,
            UnscaledDeltaTime,
        }

        #endregion


        #region Factory

        public class Properties
        {
            public float duration = 2;
            public bool playOnAwake = true;
            public TimeMode timeMode = TimeMode.DeltaTime;
            public bool allowUnexpectedEnd = true;  // Allow to be erased without throwing exception
            public bool loop = true;
            public Action OnComplete; // Called each time timmer reach the total time
        }

        public static FastTimer AddComponent(GameObject gameObject, Properties p)
        {
            if (gameObject == null)
                throw new ArgumentException("GameObject cant be null");

            if (p.duration <= 0)
                throw new ArgumentException("Duration must be grater than 0");


            var ev = new UnityEvent();
            ev.AddListener(() => p.OnComplete?.Invoke());

            var c = gameObject.AddComponent<FastTimer>();

            c.duration = p.duration;
            c.playOnAwake = p.playOnAwake;
            c.timeMode = p.timeMode;
            c.allowUnexpectedEnd = p.allowUnexpectedEnd;
            c.loop = p.loop;
            c.OnComplete = ev;

            return c;

        }

        #endregion

    }

}