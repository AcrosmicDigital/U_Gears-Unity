using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace U.Gears
{
    public class SetVelocity2D : MonoBehaviour
    {
        public Rigidbody2D rigidbdy2D;

        public bool setVelocityXmin = false;
        public float velocityXmin = 0;
        public bool setVelocityXmax = false;
        public float velocityXmax = 0;

        public bool setVelocityYmin = false;
        public float velocityYmin = 0;
        public bool setVelocityYmax = false;
        public float velocityYmax = 0;

        private void Start()
        {
            if (rigidbdy2D == null)
                rigidbdy2D = GetComponent<Rigidbody2D>();

            if (rigidbdy2D == null)
                throw new NullReferenceException("DenyVelocity2D: No rigidbody");
        }

        private void FixedUpdate()
        {
            Debug.Log("Velocity is: " + rigidbdy2D.velocity);
            Debug.Log("Max: " + rigidbdy2D.velocity.x.Max(velocityYmax));

            if (setVelocityXmin)
                rigidbdy2D.velocity = new Vector2(rigidbdy2D.velocity.x.Min(velocityXmin), rigidbdy2D.velocity.y);

            if (setVelocityXmax)
                rigidbdy2D.velocity = new Vector2(rigidbdy2D.velocity.x.Max(velocityXmax), rigidbdy2D.velocity.y);


            if (setVelocityYmin)
                rigidbdy2D.velocity = new Vector2(rigidbdy2D.velocity.x, rigidbdy2D.velocity.y.Min(velocityYmin));

            if (setVelocityYmax)
                rigidbdy2D.velocity = new Vector2(rigidbdy2D.velocity.x, rigidbdy2D.velocity.y.Max(velocityYmax));

        }
    }
}
