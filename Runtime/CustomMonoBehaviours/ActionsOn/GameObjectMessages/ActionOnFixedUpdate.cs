using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnFixedUpdate : MonoBehaviour
    {

        public bool enable = true;
        public int iterations = 0;  // 0 or less is infinite
        public UnityEvent onFixedUpdate = new UnityEvent();

        private int iterationsCount = 0;

        private void FixedUpdate()
        {

            if (enable)
            {
                try
                {
                    onFixedUpdate?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnFixedUpdate: Error in UnityEvent, " + e);
                }

                iterationsCount++;
            }

            if (iterations > 0 && iterationsCount >= iterations) Destroy(this);

        }




        public class Properties
        {
            public bool enable = true;
            public int iterations = 0;
            public Action onFixedUpdate;
        }


        public static ActionOnFixedUpdate AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnFixedUpdate>();

            c.enable = p.enable;
            c.iterations = p.iterations;
            c.onFixedUpdate.AddListener(() => p.onFixedUpdate?.Invoke());

            return c;
        }

    }
}
