using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.Math
{
    public static partial class Umath
    {

        #region Convert to other types

        // Return a int value if is true and other if is false
        public static float ToFloat(this bool value, float ifTrue, float ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }

        // Return a int value if is true and other if is false
        public static Vector2 ToVector2(this bool value, Vector2 ifTrue, Vector2 ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }

        // Return a int value if is true and other if is false
        public static Vector3 ToVector3(this bool value, Vector3 ifTrue, Vector3 ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }

        // Return a int value if is true and other if is false
        public static Vector4 ToVector4(this bool value, Vector4 ifTrue, Vector4 ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }




        // Return a int value if is true and other if is false
        public static int ToInt(this bool value, int ifTrue, int ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }


        // Return a int value if is true and other if is false
        public static string ToStringText(this bool value, string ifTrue, string ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }


        #endregion Convert to other types


    }
}