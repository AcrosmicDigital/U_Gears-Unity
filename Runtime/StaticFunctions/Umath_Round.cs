using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {
        //Assert.AreEqual(12, 12.46665f.TruncateInt());
        //Assert.AreEqual(0, 0.46665f.TruncateInt());
        //Assert.AreEqual(0, 0f.TruncateInt());
        //Assert.AreEqual(1, 1.46665f.TruncateInt());
        //Assert.AreEqual(3, 3.065f.TruncateInt());
        //Assert.AreEqual(-1, -1f.TruncateInt());
        //Assert.AreEqual(1, 1f.TruncateInt());
        //Assert.AreEqual(-3, -3.065f.TruncateInt());
        public static int TruncateInt(this float num) // Regresa la parte entera como int
        {
            return (int)num;
        }

        //Assert.AreEqual(12f, 12.46665f.TruncateFloat());
        //Assert.AreEqual(0f, 0.46665f.TruncateFloat());
        //Assert.AreEqual(0f, 0f.TruncateFloat());
        //Assert.AreEqual(1f, 1.46665f.TruncateFloat());
        //Assert.AreEqual(3f, 3.065f.TruncateFloat());
        //Assert.AreEqual(-1f, -1f.TruncateFloat());
        //Assert.AreEqual(1f, 1f.TruncateFloat());
        //Assert.AreEqual(-3f, -3.065f.TruncateFloat());
        public static float TruncateFloat(this float num) // Regresa la parte entera como float
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
        public static float TruncateInverseFloat(this float num) // Regresa la parte decimal
        {
            return num % 1;
        }

        //Assert.AreEqual(4f, 12.46665f.ElevateFloat(10));
        //Assert.AreEqual(46f, 0.46665f.ElevateFloat(100));
        //Assert.AreEqual(0f, 0f.ElevateFloat(100));
        //Assert.AreEqual(466f, 0.46665f.ElevateFloat(1000));
        //Assert.AreEqual(0f, 3.46665f.ElevateFloat(1));
        //Assert.AreEqual(0f, -1f.ElevateFloat(10));
        //Assert.AreEqual(0f, 1f.ElevateFloat(10));
        //Assert.AreEqual(-46f, -3.46665f.ElevateFloat(100));
        public static float ElevateFloat(this float num, int multiplier) // Regresa la parte decimal
        {
            return (float)num.ElevateInt(multiplier);
        }

        //Assert.AreEqual(4, 12.46665f.ElevateInt(10));
        //Assert.AreEqual(46, 0.46665f.ElevateInt(100));
        //Assert.AreEqual(0, 0f.ElevateInt(100));
        //Assert.AreEqual(466, 0.46665f.ElevateInt(1000));
        //Assert.AreEqual(0, 3.46665f.ElevateInt(1));
        //Assert.AreEqual(0, -1f.ElevateInt(10));
        //Assert.AreEqual(0, 1f.ElevateInt(10));
        //Assert.AreEqual(-46, -3.46665f.ElevateInt(100));
        public static int ElevateInt(this float num, int multiplier) // Regresa laparte decimal multiplicada y como entero
        {
            return (int)((num - num.TruncateFloat()) * multiplier);
        }


    }
}




