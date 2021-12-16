using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.Math
{
    public static partial class Umath
    {

        public static int RandomInt(int min, int max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }

        public static float RandomFloat(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public static Vector2 RandomVector2(Vector2 min, Vector2 max)
        {
            return new Vector2(RandomFloat(min.x, max.x), RandomFloat(min.y, max.y));
        }

        public static Vector3 RandomVector3(Vector3 min, Vector3 max)
        {
            return new Vector3(RandomFloat(min.x, max.x), RandomFloat(min.y, max.y), RandomFloat(min.z, max.z));
        }

        public static Vector4 RandomVector4(Vector4 min, Vector4 max)
        {
            return new Vector4(RandomFloat(min.x, max.x), RandomFloat(min.y, max.y), RandomFloat(min.z, max.z), RandomFloat(min.w, max.w));
        }

        public static Vector2Int RandomVector2Int(Vector2Int min, Vector2Int max)
        {
            return new Vector2Int(RandomInt(min.x, max.x), RandomInt(min.y, max.y));
        }

        public static Vector3Int RandomVector3Int(Vector3Int min, Vector3Int max)
        {
            return new Vector3Int(RandomInt(min.x, max.x), RandomInt(min.y, max.y), RandomInt(min.z, max.z));
        }

        public static bool RandomBool()
        {
            var n = UnityEngine.Random.Range(0, 2);

            if (n == 0) return true;
            else return false;

        }

    }
}
