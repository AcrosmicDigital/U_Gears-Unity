using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public class DisableGameObject : MonoBehaviour
    {

        public string scriptName = "";
        public bool disableOnAwake = false;
        public bool disableOnStart = false;
        public GameObject[] cArray = new GameObject[] { };


        private void Awake()
        {
            if (cArray.Length == 0)
                cArray = new GameObject[] { gameObject };

            if (disableOnAwake)
                SetAs(false);

        }

        // Start is called before the first frame update
        void Start()
        {
            if (disableOnStart)
                SetAs(false);
        }

        public void Disable()
        {
            SetAs(false);
        }

        public void Enable()
        {
            SetAs(true);
        }


        private void SetAs(bool state)
        {
            if (cArray == null)
                return;

            foreach (var c in cArray)
            {
                if (c == null)
                    continue;

                c.SetActive(state);
            }
        }
    }
}
