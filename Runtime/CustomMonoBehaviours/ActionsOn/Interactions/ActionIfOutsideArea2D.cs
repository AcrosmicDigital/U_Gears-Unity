using System;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{

    public class ActionIfOutsideArea2D : MonoBehaviour
    {

        public Vector2 downLeft = new Vector2(-10, -10);
        public Vector2 upRight = new Vector2(10, 10);

        public int totalActions = 1; // Number of times the action will be triggered each time is outside area, 0 for infinite

        public UnityEvent<Vector2> onOutsideArea = new UnityEvent<Vector2>();


        private int actionsCounted = 0;


        void Update()
        {
            if ((transform.position.y < downLeft.y) || (transform.position.y > upRight.y))
            {
                actionsCounted++;

            }
            else if ((transform.position.x < downLeft.x) || (transform.position.x > upRight.x))
            {
                actionsCounted++;

            }
            else
            {
                actionsCounted = 0;
                return;
            }

            if (totalActions > 0 && actionsCounted > totalActions) return;

            try
            {
                onOutsideArea?.Invoke(transform.position);
            }
            catch (Exception e)
            {
                Debug.LogError("ActionIfOutsideArea2D: Error in UnityEvent, " + e);
            }

        }





        public class Properties
        {
            public Vector2 downLeft = new Vector2(-10, -10);
            public Vector2 upRight = new Vector2(10, 10);
            public int totalActions = 1;
            public Action<Vector2> onOutsideArea;
        }


        public static ActionIfOutsideArea2D AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionIfOutsideArea2D>();

            c.downLeft = p.downLeft;
            c.upRight = p.upRight;
            c.totalActions = p.totalActions;
            c.onOutsideArea.AddListener((c) => p.onOutsideArea?.Invoke(c));

            return c;
        }


    }

}
