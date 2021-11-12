using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnDisable : MonoBehaviour
    {

        public bool enable = true;
        public int iterations = 0;  // 0 or less is infinite
        public UnityEvent onDisable = new UnityEvent();

        private int iterationsCount = 0;

        private void OnDisable()
        {

            if (enable)
            {
                try
                {
                    onDisable?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnDisable: Error in UnityEvent, " + e);
                }

                iterationsCount++;
            }

            if(iterations > 0 && iterationsCount >= iterations) Destroy(this);

        }




        public class Properties
        {
            public bool enable = true;
            public int iterations = 0;
            public Action onDisable;
        }


        public static ActionOnDisable AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnDisable>();

            c.enable = p.enable;
            c.iterations = p.iterations;
            c.onDisable.AddListener(() => p.onDisable.Invoke());

            return c;
        }

    }
}
