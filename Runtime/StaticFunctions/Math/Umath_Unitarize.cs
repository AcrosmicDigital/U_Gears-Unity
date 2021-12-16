using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.Math
{
    public static partial class Umath
    {

        #region Unitarize => num/abs(num) = -1,0,1   --> int, float, Vector2, Vector3

        public static float Unitarize(this float num)
        {
            if (num < 0) return -1f;
            else if (num > 0) return 1f;
            else return 0f;
        }

        public static Vector2 Unitarize(this Vector2 num)
        {
            return new Vector2(Unitarize(num.x), Unitarize(num.y));
        }

        public static Vector3 Unitarize(this Vector3 num)
        {
            return new Vector3(Unitarize(num.x), Unitarize(num.y), Unitarize(num.z));
        }

        public static Vector4 Unitarize(this Vector4 num)
        {
            return new Vector4(Unitarize(num.x), Unitarize(num.y), Unitarize(num.z), Unitarize(num.w));
        }



        public static int Unitarize(this int num)
        {
            if (num < 0) return -1;
            else if (num > 0) return 1;
            else return 0;
        }

        public static Vector2Int Unitarize(this Vector2Int num)
        {
            return new Vector2Int(Unitarize(num.x), Unitarize(num.y));
        }

        public static Vector3Int Unitarize(this Vector3Int num)
        {
            return new Vector3Int(Unitarize(num.x), Unitarize(num.y), Unitarize(num.z));
        }


        #endregion

    }
}
