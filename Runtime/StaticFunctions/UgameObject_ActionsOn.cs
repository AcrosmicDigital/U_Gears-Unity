using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.ActionsOn
{
    public static partial class UgameObject
    {

        public static GameObject OnStart(this GameObject gameObject, Action action )
        {
            // Add the component
            ActionOnStart.AddComponent(gameObject, new ActionOnStart.Properties { enable = true, onStart = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnStart(this GameObject gameObject, ActionOnStart.Properties p)
        {
            // Add the component
            ActionOnStart.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }



        public static GameObject OnDestroy(this GameObject gameObject, Action action)
        {
            // Add the component
            ActionOnDestroy.AddComponent(gameObject, new ActionOnDestroy.Properties { enable = true, onDestroy = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnDestroy(this GameObject gameObject, ActionOnDestroy.Properties p)
        {
            // Add the component
            ActionOnDestroy.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }



        public static GameObject OnDisable(this GameObject gameObject, Action action)
        {
            // Add the component
            ActionOnDisable.AddComponent(gameObject, new ActionOnDisable.Properties { enable = true, onDisable = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnDisable(this GameObject gameObject, ActionOnDisable.Properties p)
        {
            // Add the component
            ActionOnDisable.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }



        public static GameObject OnEnable(this GameObject gameObject, Action action)
        {
            // Add the component
            ActionOnEnable.AddComponent(gameObject, new ActionOnEnable.Properties { enable = true, onEnable = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnEnable(this GameObject gameObject, ActionOnEnable.Properties p)
        {
            // Add the component
            ActionOnEnable.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }


        public static GameObject OnFixedUpdate(this GameObject gameObject, Action action)
        {
            // Add the component
            ActionOnFixedUpdate.AddComponent(gameObject, new ActionOnFixedUpdate.Properties { enable = true, onFixedUpdate = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnFixedUpdate(this GameObject gameObject, ActionOnFixedUpdate.Properties p)
        {
            // Add the component
            ActionOnFixedUpdate.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }


        public static GameObject OnLateUpdate(this GameObject gameObject, Action action)
        {
            // Add the component
            ActionOnLateUpdate.AddComponent(gameObject, new ActionOnLateUpdate.Properties { enable = true, onLateUpdate = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnLateUpdate(this GameObject gameObject, ActionOnLateUpdate.Properties p)
        {
            // Add the component
            ActionOnLateUpdate.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }


        public static GameObject OnUpdate(this GameObject gameObject, Action action)
        {
            // Add the component
            ActionOnUpdate.AddComponent(gameObject, new ActionOnUpdate.Properties { enable = true, onUpdate = action });

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnUpdate(this GameObject gameObject, ActionOnUpdate.Properties p)
        {
            // Add the component
            ActionOnUpdate.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }




        public static GameObject OnCollisionEnter2D(this GameObject gameObject, ActionOnCollisionEnter2D.Properties p)
        {
            // Add the component
            ActionOnCollisionEnter2D.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnTriggerEnter2D(this GameObject gameObject, ActionOnTriggerEnter2D.Properties p)
        {
            // Add the component
            ActionOnTriggerEnter2D.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }
        public static GameObject OnOverlapCircleEnter2D(this GameObject gameObject, ActionOnOverlapCircleEnter2D.Properties p)
        {
            // Add the component
            ActionOnOverlapCircleEnter2D.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }




        public static GameObject OnTime(this GameObject gameObject, ActionOnTime.Properties p)
        {
            // Add the component
            ActionOnTime.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }


    }
}