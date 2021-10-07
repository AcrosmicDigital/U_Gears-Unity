using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears
{
    public class ActionOnStart : MonoBehaviour
    {
        public string scriptName = "";
        public bool enable = true;
        public UnityEvent<GameObject> onStart;

        private void Start()
        {
            if (!enable)
                return;

            try
            {
                onStart?.Invoke(gameObject);
            }
            catch (Exception e)
            {
                Debug.LogError("OnDestroyEventImplementer: Error in UnityEvent, " + e);
            }

        }




        public class Properties
        {
            public bool enable = true;
            public Action<GameObject> onStart;
        }

        public static ActionOnStart AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnStart>();

            c.enable = p.enable;

            var ev = new UnityEvent<GameObject>();
            ev.AddListener(g => p.onStart?.Invoke(g));
            c.onStart = ev;

            return c;
        }
    }
}
