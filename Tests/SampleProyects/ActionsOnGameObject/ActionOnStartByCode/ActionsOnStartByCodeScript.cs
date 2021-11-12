using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U.Gears.ActionsOn;

public class ActionsOnStartByCodeScript : MonoBehaviour
{

    // This is for use in NO monobehaviour classes, this is just an example because use it here have no sense
    private void Awake()
    {
        gameObject
            .OnStart(() => Debug.Log("OnStart"))
            .OnStart(() => Debug.Log("OnStart"))
            .OnDestroy(() => Debug.Log("OnDestroy"))
            .OnDisable(() => Debug.Log("OnDisable"))
            .OnEnable(() => Debug.Log("OnEnable"))
            //.OnFixedUpdate(() => Debug.Log("OnFixedUpdate"))
            //.OnLateUpdate(() => Debug.Log("OnLateUpdate"))
            //.OnUpdate(() => Debug.Log("OnUpdate"))
            ;
    }
}
