using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace U.Universal
{
    public static class ByteArrayExtensions
    {

        public static string ToStringUFT8(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static TResult ToJsonUTF8<TResult>(this byte[] bytes)
        {
            return JsonUtility.FromJson<TResult>(bytes.ToStringUFT8());
        }




    }
}
