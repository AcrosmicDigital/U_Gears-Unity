using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public class DisableRigidBody2D : MonoBehaviour
    {

        public Rigidbody2D[] cArray = new Rigidbody2D[] { };

        public bool staticOnAwake = false;
        public bool staticOnStart = false;

        public bool kinematicOnAwake = false;
        public bool kinematicOnStart = false;

        public bool dynamicOnAwake = false;
        public bool dynamicOnStart = false;


        private void Awake()
        {
            if (cArray.Length == 0)
                cArray = new Rigidbody2D[] { gameObject.GetComponent<Rigidbody2D>() };

            if (staticOnAwake)
            {
                Static();
                return;
            }

            if (kinematicOnAwake)
            {
                Kinematic();
                return;
            }

            if (dynamicOnAwake)
            {
                Dynamic();
                return;
            }

        }

        // Start is called before the first frame update
        void Start()
        {
            if (staticOnStart)
            {
                Static();
                return;
            }

            if (kinematicOnStart)
            {
                Kinematic();
                return;
            }

            if (dynamicOnStart)
            {
                Dynamic();
                return;
            }
        }

        public void Static() => SetAs(RigidbodyType2D.Static);
        public void Dynamic() => SetAs(RigidbodyType2D.Dynamic);
        public void Kinematic() => SetAs(RigidbodyType2D.Kinematic);


        private void SetAs(RigidbodyType2D rigidbodyType2D)
        {
            if (cArray == null)
                return;

            foreach (var c in cArray)
            {
                if (c == null)
                    continue;

                c.bodyType = rigidbodyType2D;
            }
        }



        public static DisableRigidBody2D FindInGameObjectWithTag(string tag)
        {
            var dd = GameObject.FindGameObjectWithTag(tag);

            if (dd == null)
                return null;

            return dd.GetComponent<DisableRigidBody2D>();

        }


    }
}