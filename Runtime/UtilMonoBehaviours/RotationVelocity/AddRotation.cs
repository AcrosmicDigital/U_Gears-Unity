using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public class AddRotation : MonoBehaviour
    {

        #region PROPS-INSPECTOR

        [Header("Settings")]
        public bool rotateSprite = true;
        public GameObject spriteGO;
        public bool invert = false;
        public float currentRotation = 0;

        #endregion

        private void Awake()
        {
            if (spriteGO == null)
                spriteGO = gameObject;
        }


        private void Update()
        {
            if (rotateSprite)
            {
                // Aplica la rotacion
                spriteGO.transform.Rotate(0, 0, currentRotation * Time.deltaTime * invert.ToInt(1, -1));

            }
        }


    }
}
