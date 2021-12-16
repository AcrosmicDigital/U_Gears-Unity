using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.Math
{
    public static partial class Umath
    {


        public static Vector2 ToVector2(this float value) => new Vector2(value, value);
        public static Vector2 ToVector3(this float value) => new Vector3(value, value, value);


        //Assert.AreEqual(12f, 12.46665f.TruncateFloat());
        //Assert.AreEqual(0f, 0.46665f.TruncateFloat());
        //Assert.AreEqual(0f, 0f.TruncateFloat());
        //Assert.AreEqual(1f, 1.46665f.TruncateFloat());
        //Assert.AreEqual(3f, 3.065f.TruncateFloat());
        //Assert.AreEqual(-1f, -1f.TruncateFloat());
        //Assert.AreEqual(1f, 1f.TruncateFloat());
        //Assert.AreEqual(-3f, -3.065f.TruncateFloat());
        public static float Truncate(this float num) // Regresa la parte entera
        {
            return (float)((int)num);
        }

        //Assert.AreEqual(.46665f, 12.46665f.TruncateInverseFloat());
        //Assert.AreEqual(.46665f, 0.46665f.TruncateInverseFloat());
        //Assert.AreEqual(0f, 0f.TruncateInverseFloat());
        //Assert.AreEqual(.46665f, 0.46665f.TruncateInverseFloat());
        //Assert.AreEqual(.46665f, 3.46665f.TruncateInverseFloat());
        //Assert.AreEqual(0f, -1f.TruncateInverseFloat());
        //Assert.AreEqual(0f, 1f.TruncateInverseFloat());
        //Assert.AreEqual(-.46665f, -3.46665f.TruncateInverseFloat());
        public static float InverseTruncate(this float num) // Regresa la parte decimal
        {
            return num % 1;
        }


        //Assert.AreEqual(4, 12.46665f.ElevateInt(1));
        //Assert.AreEqual(46, 0.46665f.ElevateInt(2));
        //Assert.AreEqual(0, 0f.ElevateInt(0));
        //Assert.AreEqual(466, 0.46665f.ElevateInt(3));
        //Assert.AreEqual(0, 3.46665f.ElevateInt(0));
        //Assert.AreEqual(0, -1f.ElevateInt(0));
        //Assert.AreEqual(0, 1f.ElevateInt(0));
        //Assert.AreEqual(-46, -3.46665f.ElevateInt(2));
        public static float Elevate(this float num, int positions) // Regresa laparte decimal multiplicada y como entero
        {
            return ((num - num.Truncate()) * Mathf.Pow(10, positions.MinMax(1, 6))).Truncate();
        }


        //Assert.AreEqual(12.46f, 12.46665f.Trim(2));
        //Assert.AreEqual(0.466f, 0.46665f.Trim(3));
        //Assert.AreEqual(0f, 0f.Trim(2));
        //Assert.AreEqual(0.4f, 0.46665f.Trim(1));
        //Assert.AreEqual(3.4f, 3.46665f.Trim(0)); // Min 1
        //Assert.AreEqual(-1f, -1f.Trim(10));
        //Assert.AreEqual(1f, 1f.Trim(10));
        //Assert.AreEqual(-3.46665f, -3.46665f.Trim(7));
        public static float Trim(this float num, int positions) // Recorta los decimales del float x posiciones
        {
            var multiplier = Mathf.Pow(10, positions.MinMax(1, 6));

            return ((num * multiplier).Truncate()) / multiplier;
        }


    }
}