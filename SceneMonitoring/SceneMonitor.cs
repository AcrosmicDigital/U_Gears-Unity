using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace U.Universal
{
    public sealed partial class SceneMonitor
    {

        // <Singleton Pattern>
        private readonly static SceneMonitor _instance = new SceneMonitor();
        private SceneMonitor() { }
        public static SceneMonitor Instance => _instance;
        // </Singleton Pattern>



        // <Host>
        private GameObject _host; // Go to host all coroutines used here
        private GameObject host { get 
            {
                if (_host == null)
                {
                    _host = new GameObject("SceneMonitor-Host");
                    UnityEngine.Object.DontDestroyOnLoad(_host);
                }

                return _host;
                    
            } } // Go to host all coroutines used here

        // </Host>

    }

}