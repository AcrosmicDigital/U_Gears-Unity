using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {
        #region  Distance betwwen values , a-b

        public static float Distance(this float A, float B)
        {
            return A - B;
        }

        public static Vector2 Distance(this Vector2 A, Vector2 B)
        {
            return new Vector2(A.x - B.x, A.y - B.y);
        }

        public static Vector3 Distance(this Vector3 A, Vector3 B)
        {
            return new Vector3(A.x - B.x, A.y - B.y, A.z - B.z);
        }

        public static Vector4 Distance(this Vector4 A, Vector4 B)
        {
            return new Vector4(A.x - B.x, A.y - B.y, A.z - B.z, A.w - B.w);
        }



        public static int Distance(this int A, int B)
        {
            return A - B;
        }

        public static Vector2Int Distance(this Vector2Int A, Vector2Int B)
        {
            return new Vector2Int(A.x - B.x, A.y - B.y);
        }

        public static Vector3Int Distance(this Vector3Int A, Vector3Int B)
        {
            return new Vector3Int(A.x - B.x, A.y - B.y, A.z - B.z);
        }





        public static double Distance(this double A, double B)
        {
            return A - B;
        }

        #endregion

    }
}
