using System.Collections;
using System.Collections.Generic;
using U.Gears.Math;
using UnityEngine;

namespace U.Gears
{
    public abstract class CustomFrequencyUpdate : MonoBehaviour
    {
        public enum TimeModeOptions
        {
            DeltaTime,
            UnscaledDeltaTime,
        }

        [Header("Frequency")]
        [SerializeField] protected float period = .1f;
        [SerializeField] private TimeModeOptions timeMode = TimeModeOptions.DeltaTime;

        public float Period { get { return period; } set { period = value; } }

        private float time = 0;

        // Update is called once per frame
        void Update()
        {
            // Add the delta time or unscaled time
            if (timeMode == TimeModeOptions.DeltaTime)
                time += Time.deltaTime;
            else
                time += Time.unscaledDeltaTime;

            // Si se ha completadof
            if (time >= period)
            {

                // OncompleteEvent
                try { CustomUpdate(); } catch (System.Exception e) { Debug.LogError(e); }

                // Restart
                time -= period.Min(0f);
            }
        }

        protected abstract void CustomUpdate();

    }
}