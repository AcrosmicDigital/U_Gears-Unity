using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public static partial class Umath
    {
        #region  Distance betwwen Vectors 2

        public static float DistanceFloat(float A, float B)
        {
            return A - B;
        }

        public static Vector2 DistanceVector2(Vector2 A, Vector2 B)
        {
            return new Vector2(A.x - B.x, A.y - B.y);
        }

        public static Vector3 DistanceVector3(Vector3 A, Vector3 B)
        {
            return new Vector3(A.x - B.x, A.y - B.y, A.z - B.z);
        }

        public static Vector4 DistanceVector4(Vector4 A, Vector4 B)
        {
            return new Vector4(A.x - B.x, A.y - B.y, A.z - B.z, A.w - B.w);
        }



        public static int DistanceInt(int A, int B)
        {
            return A - B;
        }

        public static Vector2Int DistanceVector2Int(Vector2Int A, Vector2Int B)
        {
            return new Vector2Int(A.x - B.x, A.y - B.y);
        }

        public static Vector3Int DistanceVector3Int(Vector3Int A, Vector3Int B)
        {
            return new Vector3Int(A.x - B.x, A.y - B.y, A.z - B.z);
        }





        public static double DistanceDouble(double A, double B)
        {
            return A - B;
        }

        #endregion

    }
}
