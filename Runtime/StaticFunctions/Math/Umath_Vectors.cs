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


        #region Set . Change OnlyOne member of the Vector

        public static Vector2 SetX(this Vector2 v, float x) => new Vector2(x, v.y);
        public static Vector2 SetY(this Vector2 v, float y) => new Vector2(v.x, y);
        public static Vector3 SetX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
        public static Vector3 SetY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
        public static Vector3 SetZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);
        public static Vector3 SetXY(this Vector3 v, float x, float y) => new Vector3(x, y, v.z);
        public static Vector3 SetXZ(this Vector3 v, float x, float z) => new Vector3(x, v.y, z);
        public static Vector3 SetYZ(this Vector3 v, float y, float z) => new Vector3(v.x, y, z);


        public static Vector2 Opp(this Vector2 v, Func<float, float> vOpp) => new Vector2(vOpp(v.x), vOpp(v.y));
        public static Vector2 OppX(this Vector2 v, Func<float, float> xOpp) => new Vector2(xOpp(v.x), v.y);
        public static Vector2 OppY(this Vector2 v, Func<float, float> yOpp) => new Vector2(v.x, yOpp(v.y));
        public static Vector3 Opp(this Vector3 v, Func<float, float> vOpp) => new Vector3(vOpp(v.x), vOpp(v.y), vOpp(v.z));
        public static Vector3 OppX(this Vector3 v, Func<float, float> xOpp) => new Vector3(xOpp(v.x), v.y, v.z);
        public static Vector3 OppY(this Vector3 v, Func<float, float> yOpp) => new Vector3(v.x, yOpp(v.y), v.z);
        public static Vector3 OppZ(this Vector3 v, Func<float, float> zOpp) => new Vector3(v.x, v.y, zOpp(v.z));
        public static Vector3 OppXY(this Vector3 v, Func<float, float> xOpp, Func<float, float> yOpp) => new Vector3(xOpp(v.x), yOpp(v.y), v.z);
        public static Vector3 OppXZ(this Vector3 v, Func<float, float> xOpp, Func<float, float> zOpp) => new Vector3(xOpp(v.x), v.y, zOpp(v.z));
        public static Vector3 OppYZ(this Vector3 v, Func<float, float> yOpp, Func<float, float> zOpp) => new Vector3(v.x, yOpp(v.y), zOpp(v.z));

        #endregion Set

    }
}
