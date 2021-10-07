using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {
        
        public static int MinInt(this int value, int min)
        {
            if (value < min) return min;
            else return value;
        }

         
        public static float MinFloat(this float value, float min)
        {
            if (value < min) return min;
            else return value;
        }


        public static int MaxInt(this int value, int max)
        {
            if (value > max) return max;
            else return value;
        }


        public static float MaxFloat(this float value, float max)
        {
            if (value > max) return max;
            else return value;
        }




        internal static float MinMaxFloat(this float num, float min, float max)
        {
            if (num < min) return min;
            else if (num > max) return max;
            else return num;
        }


        internal static int MinMaxInt(this int num, int min, int max)
        {
            if (num < min) return min;
            else if (num > max) return max;
            else return num;
        }


    }
}