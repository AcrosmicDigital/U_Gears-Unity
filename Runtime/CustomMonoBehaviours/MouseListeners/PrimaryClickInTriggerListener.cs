using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace U.Gears.MouseListeners
{
    public class PrimaryClickInTriggerListener : MonoBehaviour, IClickListener
    {

        #region PROPS-INSPECTOR

        [Header("Settings")]
        public bool listenOverUI = true;
        public bool listenOutsideScreen = false;
        public int allowedClicks = 0;  // 0 or less is infinite, When is completed, will destroy the object
        [InspectorName("Collider")] public Collider2D cl;

        [Space(10)]
        [SerializeField] private UnityEvent OnClick_ = new UnityEvent();
        [SerializeField] private UnityEvent OnHold_ = new UnityEvent();

        #endregion


        private int allowedClicksCount = 0;




        // CODE PROPERTIES

        [HideInInspector] public bool isInside { get; private set; }  // True if is inside screen
        [HideInInspector] public bool isHold { get; private set; } // True while mouse button is down
        [HideInInspector] public Vector2 currentMousePoss { get; private set; }
        [HideInInspector] public Vector2 lastClickPoss { get; private set; }
        [HideInInspector] public bool isClick { get; private set; } // True only in update frame that start click
        [HideInInspector] public UnityEvent OnClick => OnClick_;
        [HideInInspector] public UnityEvent OnHold => OnHold_;


        private int clickCounter = 0;


        private void Start()
        {
            if (cl == null) throw new System.ArgumentNullException("PrmClkInsideTriggerListener: needs a collider as trigger");
            cl.isTrigger = true;
        }


        // Update is called once per frame
        void Update()
        {
            // Reset values
            isHold = false;
            isClick = false;



            // If no collider return
            if (cl == null) return;

            // Guarda la posicion del mouse
            Vector2 mousePossInScren = Input.mousePosition;


            // CHECL - if mouse in in screen or return and not update anything
            Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
            isInside = screenRect.Contains(mousePossInScren);
            if (!isInside && !listenOutsideScreen) return;


            // Convert to world position
            var mousePossInWorld = Camera.main.ScreenToWorldPoint(mousePossInScren);


            // Check if is inside collider
            var isInsideCollider = false;
            foreach (Collider2D colider in Physics2D.OverlapPointAll(mousePossInWorld))
            {
                if (colider == cl) isInsideCollider = true;
            }
            if (!isInsideCollider) return;


            // UPDATE MOUSE POSITION only if is inside
            currentMousePoss = mousePossInWorld;





            // Si hay botones de mouse apretados y no touches
            if (Input.GetMouseButton(0) && !(Input.touchCount > 0))
            {
                // Si no se debe reconozer sobre el UI
                if (!listenOverUI)
                {
                    // Si es el mou
                    if (EventSystem.current != null) if (EventSystem.current.IsPointerOverGameObject() && !listenOverUI) return;
                    //Debug.Log("Mouseclicked");
                }

                isHold = true;
            }
            // Revisar si hay touches
            else if (Input.touchCount > 0)
            {
                // Si no se debe reconozer sobre el UI
                if (!listenOverUI)
                {
                    // Check if finger is over a UI element
                    if (EventSystem.current != null) if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return;
                    //Debug.Log("TouchClicked");
                }
                isHold = true;
            }



            // CHECK FOR FIRST CLICK
            if (isHold) clickCounter++;
            else clickCounter = 0;


            // Set true only in the first click
            if (clickCounter == 1)
            {
                isClick = true;
                lastClickPoss = currentMousePoss;
            }



            // Trigger events
            if (isClick)
            {
                try
                {
                    OnClick_?.Invoke();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("PrimaryClickListener.OnClick: Exception in listener, " + e);
                }

                allowedClicksCount++;

            }
            if (isHold)
            {
                try
                {
                    OnHold_?.Invoke();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("PrimaryClickListener.OnHold: Exception in listener, " + e);
                }
            }

            if (allowedClicks > 0 && allowedClicksCount >= allowedClicks) Destroy(this);
        }


        public class Properties
        {
            public bool listenOverUI = true;
            public bool listenOutsideScreen = false;
            public int allowedClicks = 0;
            public Collider2D collider;

            public Action OnClick;
            public Action OnHold;
        }


        public static PrimaryClickInTriggerListener AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<PrimaryClickInTriggerListener>();

            c.listenOverUI = p.listenOverUI;
            c.listenOutsideScreen = p.listenOutsideScreen;
            c.allowedClicks = p.allowedClicks;
            c.cl = p.collider;

            c.OnClick_.AddListener(() => p.OnClick?.Invoke());
            c.OnHold_.AddListener(() => p.OnHold?.Invoke());

            return c;
        }


    }
}