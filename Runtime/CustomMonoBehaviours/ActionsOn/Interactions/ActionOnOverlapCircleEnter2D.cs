using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace U.Gears.ActionsOn
{
    public class ActionOnOverlapCircleEnter2D : MonoBehaviour
    {
        public enum MinTimeMode
        {
            Disabled,
            DeltaTime,
            UnscaledDeltaTime,
        }

        public LayerMask damageMask = ~0;
        public float damagedRadius = 1f;
        public bool infinityCount = false;
        public int overlapsToAction = 1; // Number of triggers to trigger an action
        public int totalActions = 1; // Number of times the action will be triggered
        public MinTimeMode minTimeMode = MinTimeMode.Disabled;
        public float minTime = 1f;
        public UnityEvent onOverlapCircle = new UnityEvent();

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
                    onOverlapCircle?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError("ActionOnOverlapCircleEnter2D: Error in UnityEvent, " + e);
                }

                actionsCounted++;
                time = 0;
            }


        }





        public class Properties
        {
            public LayerMask damageMask = ~0;
            public float damagedRadius = 1f;
            public bool infinityCount = false;
            public int overlapsToAction = 1; // Number of triggers to trigger an action
            public int totalActions = 1; // Number of times the action will be triggered
            public MinTimeMode minTimeMode = MinTimeMode.Disabled;
            public float minTime = 1f;
            public Action onOverlapCircle;
        }


        public static ActionOnOverlapCircleEnter2D AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<ActionOnOverlapCircleEnter2D>();

            c.damageMask = p.damageMask;
            c.damagedRadius = p.damagedRadius;
            c.infinityCount = p.infinityCount;
            c.overlapsToAction = p.overlapsToAction;
            c.totalActions = p.totalActions;
            c.minTimeMode = p.minTimeMode;
            c.minTime = p.minTime;
            c.onOverlapCircle.AddListener(() => p.onOverlapCircle?.Invoke());

            return c;
        }







        #region GIZMOS

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, damagedRadius);
        }

        #endregion



    }
}