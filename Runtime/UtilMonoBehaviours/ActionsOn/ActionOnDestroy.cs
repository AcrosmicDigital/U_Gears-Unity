using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears
{
    public class ActionOnDestroy : MonoBehaviour
    {

        public string scriptName = "";
        public bool enable = true;
        public UnityEvent<GameObject> onDestroy;

        private void OnDestroy()
        {
            if (!enable)
                return;

            try
            {
                onDestroy?.Invoke(gameObject);
            }
            catch (Exception e)
            {
                Debug.LogError("OnDestroyEventImplementer: Error in UnityEvent, " + e);
            }

        }




        public class Properties
        {
            public bool enable = true;
            public Action<GameObject> onDestroy;
        }

        public static ActionOnDestroy AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnDestroy>();

            c.enable = p.enable;

            var ev = new UnityEvent<GameObject>();
            ev.AddListener(g => p.onDestroy?.Invoke(g));
            c.onDestroy = ev;

            return c;
        }
    }

}
