using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnStart : MonoBehaviour
    {

        public bool enable = true;
        public UnityEvent onStart = new UnityEvent();


        private void Start()
        {

            if (enable)
            {
                try
                {
                    onStart?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnStart: Error in UnityEvent, " + e);
                }
            }

            Destroy(this);

        }




        public class Properties
        {
            public bool enable = true;
            public Action onStart;
        }


        public static ActionOnStart AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnStart>();

            c.enable = p.enable;
            c.onStart.AddListener(() => p.onStart?.Invoke());

            return c;
        }

    }
}
