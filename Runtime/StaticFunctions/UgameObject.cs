using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class UgameObject
    {
        public static Transform[] GetChilds(this Transform transform)
        {
            var childsList = new List<Transform>();

            foreach (Transform child in transform)  // Cant use Linq here
            {
                if (child == null)
                    continue;

                childsList.Add(child);
            }

            return childsList.ToArray();
        }
    }
}