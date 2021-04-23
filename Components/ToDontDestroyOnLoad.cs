using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Universal
{
    public class ToDontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

