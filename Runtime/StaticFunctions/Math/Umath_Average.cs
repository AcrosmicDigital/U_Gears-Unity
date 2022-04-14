using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.Math
{
    public static partial class Umath
    {

        public static float Average(this IEnumerable<float> list)
        {
            float sum = 0f;
            float count = 0f;

            foreach (var value in list)
            {
                sum += value;
                count += 1;
            }

            return sum / count;
        }

        public static Vector2 Average(this IEnumerable<Vector2> list)
        {
            float sumX = 0f;
            float sumY = 0f;
            float count = 0f;

            foreach (var value in list)
            {
                sumX += value.x;
                sumY += value.y;
                count += 1;
            }

            return new Vector2(sumX/count, sumY/count);
        }

        public static Vector3 Average(this IEnumerable<Vector3> list)
        {
            float sumX = 0f;
            float sumY = 0f;
            float sumZ = 0f;
            float count = 0f;

            foreach (var value in list)
            {
                sumX += value.x;
                sumY += value.y;
                sumZ += value.z;
                count += 1;
            }

            return new Vector3(sumX / count, sumY / count, sumZ / count);
        }

    }
}