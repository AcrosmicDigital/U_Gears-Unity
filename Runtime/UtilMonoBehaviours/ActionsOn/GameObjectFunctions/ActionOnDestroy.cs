using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnDestroy : MonoBehaviour
    {

        public bool enable = true;
        public UnityEvent onDestroy = new UnityEvent();


        private void OnDestroy()
        {
            if (enable)
            {
                try
                {
                    onDestroy?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnDestroy: Error in UnityEvent, " + e);
                }
            }

        }




        public class Properties
        {
            public bool enable = true;
            public Action onDestroy;
        }

        public static ActionOnDestroy AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnDestroy>();

            c.enable = p.enable;
            c.onDestroy.AddListener(() => p.onDestroy.Invoke());

            return c;
        }

    }

}
