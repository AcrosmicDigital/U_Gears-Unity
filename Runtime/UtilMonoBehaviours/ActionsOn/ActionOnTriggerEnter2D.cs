using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.ActionsOn
{
    public class ActionOnTriggerEnter2D : MonoBehaviour
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
        public bool infinityCount = false;
        public int triggersToAction = 1; // Number of triggers to trigger an action
        public int totalActions = 1; // Number of times the action will be triggered
        public MinTimeMode minTimeMode = MinTimeMode.Disabled;
        public float minTime = 1f;
        public UnityEvent<GameObject> onTriggerEnter;

        private int triggersCounted = 0;
        private int actionsCounted = 0;
        private float time = 0;


        private void Update()
        {
            if (minTimeMode == MinTimeMode.Disabled) return;
            else if (minTimeMode == MinTimeMode.DeltaTime) time += Time.deltaTime;
            else if (minTimeMode == MinTimeMode.UnscaledDeltaTime) time += Time.unscaledDeltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!enable)
                return;

            if (minTimeMode != MinTimeMode.Disabled)
                if (time < minTime) return;

            // Si esta en la mascara que deberia detectar
            if (((1 << collision.gameObject.layer) & damageMask) != 0)
            {
                triggersCounted++;

                if (triggersCounted >= triggersToAction && (actionsCounted < totalActions) || infinityCount)
                {
                    try
                    {
                        onTriggerEnter?.Invoke(gameObject);
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

