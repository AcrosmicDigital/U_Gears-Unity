using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U.Gears
{
    public class DestroyGameObject : MonoBehaviour
    {
        public float delay = 0f;
        public TimeMode timeMode = TimeMode.DeltaTime;
        public bool destroyOnAwake = false;
        public bool destroyOnStart = false;

        private void Awake()
        {
            if (destroyOnAwake)
                Destroy();
        }

        private void Start()
        {
            if (destroyOnStart)
                Destroy();
        }


        public void Destroy()
        {
            StartCoroutine(DestroyWithDelay());
        }

        private IEnumerator DestroyWithDelay()
        {
            if(delay > 0)
            {
                if (timeMode == TimeMode.DeltaTime)
                    yield return new WaitForSeconds(delay);
                else
                    yield return new WaitForSecondsRealtime(delay);
            }

            if (gameObject != null)
                Destroy(gameObject);
        }

        public enum TimeMode
        {
            DeltaTime,
            DeltaUnscaledTime,
        }

    }
}
