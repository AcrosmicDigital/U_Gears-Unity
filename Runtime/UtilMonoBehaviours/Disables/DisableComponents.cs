using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public class DisableComponents : MonoBehaviour
    {

        public SpriteRenderer spriteRendererCmp;
        public Collider2D colliderCmp;
        public Rigidbody2D rigidbody2DCmp;

        public bool disableOnAwake = false;
        public bool disableOnStart = false;


        private void Awake()
        {
            if (disableOnAwake)
                Disable();

        }

        // Start is called before the first frame update
        void Start()
        {
            if (disableOnStart)
                Disable();

        }

        public void Enable()
        {
            if (disableOnAwake)
            {
                if (spriteRendererCmp != null)
                    spriteRendererCmp.enabled = true;
                if (colliderCmp != null)
                    colliderCmp.enabled = true;
                if (rigidbody2DCmp != null)
                    rigidbody2DCmp.isKinematic = true;
            }
        }

        public void Disable()
        {
            if (spriteRendererCmp != null)
                spriteRendererCmp.enabled = false;
            if (colliderCmp != null)
                colliderCmp.enabled = false;
            if (rigidbody2DCmp != null)
                rigidbody2DCmp.isKinematic = true;
        }



        public static DisableComponents FindInGameObjectWithTag(string tag)
        {
            var dd = GameObject.FindGameObjectWithTag(tag);

            if (dd == null)
                return null;

            return dd.GetComponent<DisableComponents>();

        }


    }
}