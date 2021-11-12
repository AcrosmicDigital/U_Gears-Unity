using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnEnable : MonoBehaviour
    {

        public bool enable = true;
        public int iterations = 0;  // 0 or less is infinite
        public UnityEvent onEnable = new UnityEvent();

        private int iterationsCount = 0;

        private void OnEnable()
        {

            if (enable)
            {
                try
                {
                    onEnable?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnEnable: Error in UnityEvent, " + e);
                }

                iterationsCount++;
            }

            if (iterations > 0 && iterationsCount >= iterations) Destroy(this);

        }




        public class Properties
        {
            public bool enable = true;
            public int iterations = 0;
            public Action onEnable;
        }


        public static ActionOnEnable AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnEnable>();

            c.enable = p.enable;
            c.iterations = p.iterations;
            c.onEnable.AddListener(() => p.onEnable.Invoke());

            return c;
        }

    }
}
