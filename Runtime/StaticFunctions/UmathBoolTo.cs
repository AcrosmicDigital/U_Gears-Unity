using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {

        public static int BoolToInt(bool value, int ifTrue, int ifFalse)
        {
            if (value)
                return ifTrue;
            else
                return ifFalse;
        }
        public static int ToInt(this bool value, int ifTrue, int ifFalse)
        {
            return BoolToInt(value, ifTrue, ifFalse);
        }

    }
}