using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnUpdate : MonoBehaviour
    {

        public bool enable = true;
        public int iterations = 0;  // 0 or less is infinite
        public UnityEvent onUpdate = new UnityEvent();

        private int iterationsCount = 0;

        private void Update()
        {

            if (enable)
            {
                try
                {
                    onUpdate?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnUpdate: Error in UnityEvent, " + e);
                }

                iterationsCount++;
            }

            if (iterations > 0 && iterationsCount >= iterations) Destroy(this);

        }




        public class Properties
        {
            public bool enable = true;
            public int iterations = 0;
            public Action onUpdate;
        }


        public static ActionOnUpdate AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnUpdate>();

            c.enable = p.enable;
            c.iterations = p.iterations;
            c.onUpdate.AddListener(() => p.onUpdate.Invoke());

            return c;
        }

    }
}
