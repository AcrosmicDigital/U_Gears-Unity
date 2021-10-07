using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears
{
    public class Print : MonoBehaviour
    {


        public void Log()
        {
            Debug.Log(gameObject.name + ": ");
        }

        public void Log(string mesage)
        {
            Debug.Log(gameObject.name + ": " + mesage);
        }

    }
}
