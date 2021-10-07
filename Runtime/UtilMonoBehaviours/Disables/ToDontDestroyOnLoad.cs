using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public class ToDontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

