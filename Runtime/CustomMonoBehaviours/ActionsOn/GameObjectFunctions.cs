using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears.ActionsOn
{
    public class GameObjectFunctions : MonoBehaviour
    {

        public void ToDontdDestroyOnLoad()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

    }
}

