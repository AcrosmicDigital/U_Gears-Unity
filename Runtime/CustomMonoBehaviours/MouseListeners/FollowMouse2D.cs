using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U.Gears.MouseListeners;
using U.Gears;
using U.Gears.Math;

namespace U.Gears.MouseListeners
{
    public class FollowMouse2D : MonoBehaviour
    {
        public enum FollowMode
        {
            OnHold,
            Always,
            OnClick,
        }

        //                       repeel radio          no action radio        desaceelration radio    maxspeed radio           outside Radio
        //                         v                    v                        v                     v                       v
        // Object )    repeel      /        noAction    /     desaceleration     /    max velocity     /     aceleration       /   noAction           

        [Header("Listener")]
        [SerializeField] private PrimaryClickListener clickListener;
        [SerializeField] private PrimaryClickInTriggerListener clickListenerInTrigger;
        [Header("Settings")]
        [SerializeField] private FollowMode faceMode = FollowMode.OnHold;
        [SerializeField] private float moveSpeed = 50f;
        [SerializeField] private float desacelerationSpeed = .5f;
        [Header("Radius")]
        [SerializeField] private float noActionRadio = 1f; // Inside this area wont move


        private IClickListener l;
        private Rigidbody2D rb;
        private bool isClick;


        private void Start()
        {
            if (clickListener == null)
            {
                clickListener = GetComponent<PrimaryClickListener>();
                if (clickListener == null)
                {
                    if (clickListenerInTrigger == null)
                    {
                        clickListenerInTrigger = GetComponent<PrimaryClickInTriggerListener>();
                        if (clickListenerInTrigger == null)
                        {
                            throw new System.ArgumentNullException("FollowMouse2D: Cant find a valid click listener");
                        }
                        else l = clickListenerInTrigger;
                    }
                    else l = clickListenerInTrigger;
                }
                else l = clickListener;
            }
            else l = clickListener;

            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
                if (rb == null) throw new System.NullReferenceException("FollowMouse2D: Cant find a valid rigidBody2D");
            }

        }

        private void Update()
        {

            // Distance between mouse and object
            var distance = l.currentMousePoss.Distance(transform.position).magnitude;
            var normDistance = l.currentMousePoss.Distance(transform.position).normalized;

            // Si debe moverse
            if ((faceMode == FollowMode.Always) || (faceMode == FollowMode.OnHold && l.isHold) || (faceMode == FollowMode.OnClick && isClick))
            {
                // If no action radio desacelerate
                if (distance < noActionRadio)
                {
                    Desacelerate();
                    return;
                }

                rb.velocity = new Vector2(moveSpeed * Time.deltaTime * normDistance.x, moveSpeed * Time.deltaTime * normDistance.y);
            }
            // If moust dont move just desacelerate
            else
            {
                Desacelerate();
            }

            void Desacelerate()
            {
                rb.velocity = new Vector2(rb.velocity.x * desacelerationSpeed * Time.deltaTime * normDistance.x, rb.velocity.y * desacelerationSpeed * Time.deltaTime * normDistance.y);
            }

        }


        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, noActionRadio);
        }

    }
}