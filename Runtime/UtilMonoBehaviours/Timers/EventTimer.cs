using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace U.Gears
{

    // Poner los elementos en una cola , ir ejecutando el peek y si es el tiempo ejecutarlo y todos los demas tambien ... 
    public class EventTimer : MonoBehaviour
    {
        public string eventTimerName = "";
        public bool playOnAwake = true;
        public bool allowUnexpectedEnd = true;  // Allow to be erased without throwing exception
        public TimeMode timeMode = TimeMode.UnscaledDeltaTime;
        public OnCompleteMode onCompleteMode = OnCompleteMode.Disable;
        public int iterations = 1;
        public TimeEventInspector[] actionsList;

        private bool isPaused = false;
        private bool isCompleted = false;
        private float time = 0;  // Time elapsed
        private int completedIterations = 0;
        private Queue<TimeEventInspector> actionsStack = new Queue<TimeEventInspector>();
        private TaskCompletionSource<bool> tks = new TaskCompletionSource<bool>();  // Task to wait for the animation
        private bool pausedBeforeStart = false;


        private void Constructor()
        {
            if (actionsList == null)
                throw new ArgumentNullException("Actions List cant be null");

            if (actionsList.Length < 1)
                throw new ArgumentException("Actions List cant be empty");

            if (iterations < 1)
                throw new ArgumentException("Iterations cant be less than one");



            // Clear the stack
            actionsStack.Clear();

            // Add elements to the stack
            foreach (var item in actionsList.OrderBy(a => a.time))
            {
                if (item == null)
                    continue;

                //Debug.Log("Adding element: " + item.time);
                actionsStack.Enqueue(item);
            }

            // If play or not
            time = 0;

        }



        private void Start()
        {
            if (!pausedBeforeStart)
                isPaused = !playOnAwake;
            Constructor();
        }



        void Update()
        {

            // When is paused or stack is empty return
            if (isPaused || isCompleted)
                return;

            // Check if completed
            if (actionsStack.Count() < 1)
            {
                if (onCompleteMode == OnCompleteMode.Loop)
                {
                    Constructor();
                }
                else
                {

                    // Add a completed iteration
                    completedIterations++;

                    // If iterations are completed, timer is completed
                    if (completedIterations >= iterations)
                    {
                        isCompleted = true;

                        // Set the Task
                        if (!tks.Task.IsCompleted)
                            tks.SetResult(true);

                        // Completation form
                        if (onCompleteMode == OnCompleteMode.Disable)
                            this.enabled = false;
                        else if (onCompleteMode == OnCompleteMode.DestroyComponent)
                            Destroy(this);
                        else if (onCompleteMode == OnCompleteMode.DestroyGameObject)
                        {
                            Destroy(this);
                            Destroy(gameObject);
                        }

                        return;
                    }
                    else
                    {
                        Constructor();
                    }
                }
            }

            // Add the delta time or unscaled time
            if (timeMode == TimeMode.DeltaTime)
                time += Time.deltaTime;
            else
                time += Time.unscaledDeltaTime;

            // Check for the actions to excecute
            int i = 0;  // Seguro
            while (actionsStack.Peek().time <= time && i < 1000)
            {
                i++;

                // Execute the delegate
                var action = actionsStack.Dequeue();
                try
                {
                    //Debug.Log("Adding element: " + action.time);
                    action.action?.Invoke();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error in TimeEvent, " + e);
                }

                if (actionsStack.Count() < 1)
                    break;
            }


        }

        private void OnDestroy()
        {

            if (isCompleted)
                return;

            isCompleted = true;

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

            // Completation form
            if (onCompleteMode == OnCompleteMode.Disable)
                this.enabled = false;
            else if (onCompleteMode == OnCompleteMode.DestroyComponent)
                Destroy(this);
            else if (onCompleteMode == OnCompleteMode.DestroyGameObject)
            {
                Destroy(this);
                Destroy(gameObject);
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
            Constructor();

            isPaused = !playOnAwake;
            completedIterations = 0;
            isCompleted = false;
            tks = new TaskCompletionSource<bool>();

            // Enable the component if disabled
            this.enabled = true;

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



        public static EventTimer FindInGameObjectWithTag(string tag ,string eventTimerName = "")
        {
            var dd = GameObject.FindGameObjectWithTag(tag);

            if (dd == null)
                return null;

            var list = dd.GetComponents<EventTimer>();

            if (list.Length == 0)
                return null;
            else if (String.IsNullOrEmpty(eventTimerName))
                return list[0];
            else
                return list.Where(e => e.eventTimerName == eventTimerName).FirstOrDefault();
        }



        #region Factory

        public class Properties
        {
            public GameObject gameObject = new GameObject("EventTimer-Host");
            public TimeEventCode[] actionsList = null;
            public TimeMode timeMode = TimeMode.UnscaledDeltaTime;
            public OnCompleteMode onCompleteMode = OnCompleteMode.Disable;
            public int iterations = 1;
            public bool playOnAwake = true;
            public bool allowUnexpectedEnd = true;
        }

        public static EventTimer AddComponent(Properties properties)
        {
            if (properties.gameObject == null)
                throw new ArgumentException("GameObject cant be null");

            if (properties.actionsList == null)
                throw new ArgumentException("ActionList cant be null");

            if (properties.actionsList.Length < 1)
                throw new ArgumentException("ActionList cant be empty");

            if (properties.iterations < 1)
                throw new ArgumentException("Iterations cant be less than one");


            var eventTimer = properties.gameObject.AddComponent<EventTimer>();

            eventTimer.timeMode = properties.timeMode;
            eventTimer.onCompleteMode = properties.onCompleteMode;
            eventTimer.iterations = properties.iterations;
            eventTimer.playOnAwake = properties.playOnAwake;
            eventTimer.allowUnexpectedEnd = properties.allowUnexpectedEnd;
            eventTimer.actionsList = properties.actionsList.Select(e =>
            {
                var ev = new UnityEvent();
                ev.AddListener(() => e.action?.Invoke());
                return new TimeEventInspector { time = e.time, action = ev };
            }).ToArray();

            return eventTimer;
        }

        #endregion


        #region Enums and classes

        public enum TimeMode
        {
            DeltaTime,
            UnscaledDeltaTime,
        }

        public enum OnCompleteMode
        {
            Disable,
            DestroyComponent,
            DestroyGameObject,
            Loop,
            None,
        }


        [System.Serializable]
        public class TimeEventInspector
        {
            public float time;
            public UnityEvent action;
        }

        [System.Serializable]
        public class TimeEventCode
        {
            public float time;
            public Action action;
        }

        #endregion


    }

}