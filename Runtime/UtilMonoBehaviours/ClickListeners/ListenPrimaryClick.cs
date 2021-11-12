using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListenPrimaryClick : MonoBehaviour
{

    #region PROPS-INSPECTOR

    [Header("Settings")]
    public bool listenOverUI = false;
    //[Header("Movement")]
    //[Header("Constraints")]
    //[Header("Required")]
    //[Space(8)] 
    //[Range(1, 6)]

    #endregion

    





    // CODE PROPERTIES

    [HideInInspector] public bool isInside { get; private set; }
    [HideInInspector]  public bool isClicked { get; private set; }
    [HideInInspector] public Vector2 currentMousePoss { get; private set; }
    [HideInInspector]  public Vector2 lastClickPoss { get; private set; }
    [HideInInspector] public bool isFirstClick { get; private set; } // True only in update frame that is start click



    private int clickCounter = 0;



    // Update is called once per frame
    void Update()
    {

        // Guarda la posicion del mouse
        Vector2 mousePossInScren = Input.mousePosition;


        // CHECL - if mouse in in screen or return and not update anything
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (!screenRect.Contains(mousePossInScren)) return;
        else isInside = true;


        // UPDATE MOUSE POSITION
        currentMousePoss = Camera.main.ScreenToWorldPoint(mousePossInScren);



        // CHECK FOR CLICKS
        isClicked = false;

        
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
            
            isClicked = true;
        }
        // Revisar si hay touches
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Si no se debe reconozer sobre el UI
            if (!listenOverUI)
            {
                // Check if finger is over a UI element
                if (EventSystem.current != null) if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return;
                //Debug.Log("TouchClicked");
            }
            isClicked = true;
        }
        


        // CHECK FOR FIRST CLICK
        if (isClicked) clickCounter++;
        else clickCounter = 0;


        // Set true only in the first click
        if (clickCounter == 1)
        {
            isFirstClick = true;
            lastClickPoss = currentMousePoss;
        }
        else
        {
            isFirstClick = false;
        }




        //Debug.Log(isInsideScreen + " " + isInsideSubScreen + " " + isClicked + " " + isClickedInColl + " " + isInsideColl + " " +isClickedInSubScreen);
        //Debug.Log(lastClickPoss + " " + lastClickPossInsideColl + " " + currentPoss + " " + lastPossInsideColl + " " + lastPossInsideSubScreen);

    }

}
