using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {
        public static int TruncateInt(this float num) // Regresa la parte entera como int
        {
            return (int)num;
        }

        public static float TruncateFloat(this float num) // Regresa la parte enter como float
        {
            return (float)((int)num);
        }

        public static float TruncateInverseFloat(this float num) // Regresa la parte decimal
        {
            return num % 1;
        }

        public static float ElevateFloat(this float num, int multiplier) // Regresa la parte decimal
        {
            return (float)num.ElevateInt(multiplier);
        }


        public static int ElevateInt(this float num, int multiplier) // Regresa laparte decimal multiplicada y como entero
        {
            return (int)((num - num.TruncateFloat()) * multiplier);
        }


    }
}




