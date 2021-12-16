using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.Math
{
    public static partial class Umath
    {

        #region  Distance betwwen values , a-b

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


        public static Vector2Int Distance(this Vector2Int A, Vector2Int B)
        {
            return new Vector2Int(A.x - B.x, A.y - B.y);
        }

        public static Vector3Int Distance(this Vector3Int A, Vector3Int B)
        {
            return new Vector3Int(A.x - B.x, A.y - B.y, A.z - B.z);
        }



        #endregion Distance betwwen values , a-b



        #region Operate vectors , operation apply to all members of the vector

        public static Vector2 Operate(this Vector2 vec, Func<float,float> operation)
        {
            return new Vector2(operation(vec.x), operation(vec.y));
        }


        #endregion Operate vectors

    }
}
