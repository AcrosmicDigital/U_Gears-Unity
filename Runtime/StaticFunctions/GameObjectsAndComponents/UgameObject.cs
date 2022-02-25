using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class UgameObject
    {

        // Return an array with the childs transforms
        public static Transform[] GetChildsTransforms(this GameObject gameObject)
        {
            var childsList = new List<Transform>();

            foreach (Transform childTransform in gameObject.transform)  // Cant use Linq here
            {
                if (childTransform == null)
                    continue;

                childsList.Add(childTransform);
            }

            return childsList.ToArray();
        }

        // Return an array with the childs gameobjects
        public static GameObject[] GetChilds(this GameObject gameObject)
        {
            var childsList = new List<GameObject>();

            foreach (Transform child in gameObject.transform)  // Cant use Linq here
            {
                if (child == null)
                    continue;

                childsList.Add(child.gameObject);
            }

            return childsList.ToArray();
        }

        public static void OppChilds(this GameObject gameObject, Action<GameObject> action)
        {
            foreach (Transform child in gameObject.transform)  // Cant use Linq here
            {
                if (child == null)
                    continue;

                try
                {
                    action.Invoke(child.gameObject);
                }
                catch (Exception e)
                {
                    Debug.Log("Exeption executing Opp in child, " + e);
                }

            }
        }

    }
}