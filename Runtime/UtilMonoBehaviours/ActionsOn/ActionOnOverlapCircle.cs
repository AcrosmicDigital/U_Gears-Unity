using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace U.Gears.ActionsOn
{
    public class ActionOnOverlapCircle : MonoBehaviour
    {
        public enum MinTimeMode
        {
            Disabled,
            DeltaTime,
            UnscaledDeltaTime,
        }

        public string scriptName = "";
        public LayerMask damageMask;
        public float damagedRadius = 1f;
        public bool infinityCount = false;
        public int overlapsToAction = 1; // Number of triggers to trigger an action
        public int totalActions = 1; // Number of times the action will be triggered
        public MinTimeMode minTimeMode = MinTimeMode.Disabled;
        public float minTime = 1f;
        public UnityEvent<GameObject> onOverlapCircle;

        private int overlapsCounted = 0;
        private int actionsCounted = 0;
        private float time = 0;


        // Update is called once per frame
        void Update()
        {

            //if (minTimeMode == MinTimeMode.Disabled) return;
            if (minTimeMode == MinTimeMode.DeltaTime) time += Time.deltaTime;
            else if (minTimeMode == MinTimeMode.UnscaledDeltaTime) time += Time.unscaledDeltaTime;

            if (minTimeMode != MinTimeMode.Disabled)
                if (time < minTime) return;

            // Check for collisions
            int totalContacts = Physics2D.OverlapCircleAll(transform.position, damagedRadius, damageMask).Length;

            // If no collisions return
            if (totalContacts < 1)
                return;

            overlapsCounted++;

            if (overlapsCounted >= overlapsToAction && (actionsCounted < totalActions || infinityCount))
            {
                try
                {
                    onOverlapCircle?.Invoke(gameObject);
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnOverlapCircle: Error in UnityEvent, " + e);
                }

                actionsCounted++;
                time = 0;
            }


        }


        #region GIZMOS

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, damagedRadius);
        }

        #endregion

    }
}