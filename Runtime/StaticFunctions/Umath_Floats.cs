using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {

        public static Vector2 ToVector2(this float value) => new Vector2(value, value);
        public static Vector2 ToVector3(this float value) => new Vector3(value, value, value);

    }
}