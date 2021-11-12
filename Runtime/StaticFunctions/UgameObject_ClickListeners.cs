using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.MouseListeners
{
    public static partial class UgameObject
    {

        public static GameObject OnMousePrimaryClick(this GameObject gameObject, PrimaryClickListener.Properties p)
        {
            // Add the component
            PrimaryClickListener.AddComponent(gameObject, p);

            // Return to fluent design
            return gameObject;
        }
    }
}