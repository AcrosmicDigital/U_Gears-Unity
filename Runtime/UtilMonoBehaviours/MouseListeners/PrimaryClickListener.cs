using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace U.Gears.MouseListeners
{
    public class PrimaryClickListener : MonoBehaviour
    {

        #region PROPS-INSPECTOR

        [Header("Settings")]
        public bool listenOverUI = true;
        public bool listenOutsideScreen = false;
        public int allowedClicks = 0;  // 0 or less is infinite, When is completed, will destroy the object

        public UnityEvent OnClick = new UnityEvent();
        public UnityEvent OnHold = new UnityEvent();

        #endregion


        private int allowedClicksCount = 0;




        // CODE PROPERTIES

        [HideInInspector] public bool isInside { get; private set; }  // True if is inside screen
        [HideInInspector] public bool isHold { get; private set; } // True while mouse button is down
        [HideInInspector] public Vector2 currentMousePoss { get; private set; }
        [HideInInspector] public Vector2 lastClickPoss { get; private set; }
        [HideInInspector] public bool isClick { get; private set; } // True only in update frame that start click



        private int clickCounter = 0;



        // Update is called once per frame
        void Update()
        {

            // Guarda la posicion del mouse
            Vector2 mousePossInScren = Input.mousePosition;


            // CHECL - if mouse in in screen or return and not update anything
            Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
            isInside = screenRect.Contains(mousePossInScren);
            if (!isInside && !listenOutsideScreen) return;


            // UPDATE MOUSE POSITION
            currentMousePoss = Camera.main.ScreenToWorldPoint(mousePossInScren);



            // CHECK FOR CLICKS
            isHold = false;


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
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
            else
            {
                isClick = false;
            }



            // Trigger events
            if (isClick)
            {
                try
                {
                    OnClick?.Invoke();
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
                    OnHold?.Invoke();
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

            public Action OnClick;
            public Action OnHold;
        }


        public static PrimaryClickListener AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<PrimaryClickListener>();

            c.listenOverUI = p.listenOverUI;
            c.listenOutsideScreen = p.listenOutsideScreen;
            c.allowedClicks = p.allowedClicks;

            c.OnClick.AddListener(() => p.OnClick.Invoke());
            c.OnHold.AddListener(() => p.OnHold.Invoke());

            return c;
        }


    }

}