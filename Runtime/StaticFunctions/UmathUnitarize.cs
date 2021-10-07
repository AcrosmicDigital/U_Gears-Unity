using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {

        #region Unitarize => num/abs(num) = -1,0,-1   --> int, float, Vector2, Vector3


        public static float UnitarizeFloat(float num)
        {
            if (num < 0) return -1f;
            else if (num > 0) return 1f;
            else return 0f;
        }

        public static Vector2 UnitarizeVector2(Vector2 num)
        {
            return new Vector2(UnitarizeFloat(num.x), UnitarizeFloat(num.y));
        }

        public static Vector3 UnitarizeVector3(Vector3 num)
        {
            return new Vector3(UnitarizeFloat(num.x), UnitarizeFloat(num.y), UnitarizeFloat(num.z));
        }

        public static Vector4 UnitarizeVector4(Vector4 num)
        {
            return new Vector4(UnitarizeFloat(num.x), UnitarizeFloat(num.y), UnitarizeFloat(num.z), UnitarizeFloat(num.w));
        }



        public static int UnitarizeInt(int num)
        {
            if (num < 0) return -1;
            else if (num > 0) return 1;
            else return 0;
        }

        public static Vector2Int UnitarizeVector2Int(Vector2Int num)
        {
            return new Vector2Int(UnitarizeInt(num.x), UnitarizeInt(num.y));
        }

        public static Vector3Int UnitarizeVector3Int(Vector3Int num)
        {
            return new Vector3Int(UnitarizeInt(num.x), UnitarizeInt(num.y), UnitarizeInt(num.z));
        }



        public static double UnitarizeDouble(double num)
        {
            if (num < 0) return -1;
            else if (num > 0) return 1;
            else return 0;
        }

        #endregion

    }
}
