using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnCollisionEnter2D : MonoBehaviour
    {
        public enum MinTimeMode
        {
            Disabled,
            DeltaTime,
            UnscaledDeltaTime,
        }

        public string scriptName = "";
        public bool enable = true;
        public LayerMask damageMask;
        public float damagedVelocity = 0;
        public bool infinityCount = false;
        public int collisionsToAction = 1; // Number of triggers to trigger an action
        public int totalActions = 1; // Number of times the action will be triggered
        public MinTimeMode minTimeMode = MinTimeMode.Disabled;
        public float minTime = 1f;
        public UnityEvent<GameObject> onCollisionEnter;

        private int collisionsCounted = 0;
        private int actionsCounted = 0;
        private float time = 0;

        private void Update()
        {
            if (minTimeMode == MinTimeMode.Disabled) return;
            else if (minTimeMode == MinTimeMode.DeltaTime) time += Time.deltaTime;
            else if (minTimeMode == MinTimeMode.UnscaledDeltaTime) time += Time.unscaledDeltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!enable)
                return;

            if(minTimeMode != MinTimeMode.Disabled)
                if (time < minTime) return;

            // Check velocity of colision
            if (collision.relativeVelocity.magnitude < damagedVelocity)
                return;

            // Si esta en la mascara que deberia detectar
            if (((1 << collision.gameObject.layer) & damageMask) != 0)
            {
                collisionsCounted++;

                if (collisionsCounted >= collisionsToAction && (actionsCounted < totalActions || infinityCount))
                {
                    try
                    {
                        onCollisionEnter?.Invoke(gameObject);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("OnDestroyEventImplementer: Error in UnityEvent, " + e);
                    }

                    actionsCounted++;
                    time = 0;
                }
            }
        }

    }
}
