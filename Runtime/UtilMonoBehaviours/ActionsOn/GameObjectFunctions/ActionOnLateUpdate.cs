using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnLateUpdate : MonoBehaviour
    {

        public bool enable = true;
        public int iterations = 0;  // 0 or less is infinite
        public UnityEvent onLateUpdate = new UnityEvent();

        private int iterationsCount = 0;

        private void LateUpdate()
        {

            if (enable)
            {
                try
                {
                    onLateUpdate?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnLateUpdate: Error in UnityEvent, " + e);
                }

                iterationsCount++;
            }

            if (iterations > 0 && iterationsCount >= iterations) Destroy(this);

        }




        public class Properties
        {
            public bool enable = true;
            public int iterations = 0;
            public Action onLateUpdate;
        }


        public static ActionOnLateUpdate AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnLateUpdate>();

            c.enable = p.enable;
            c.iterations = p.iterations;
            c.onLateUpdate.AddListener(() => p.onLateUpdate?.Invoke());

            return c;
        }

    }
}
