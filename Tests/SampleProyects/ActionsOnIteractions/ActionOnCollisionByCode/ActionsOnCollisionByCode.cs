using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U.Gears.ActionsOn;

public class ActionsOnCollisionByCode : MonoBehaviour
{
    // This is for use in NO monobehaviour classes, this is just an example because use it here have no sense
    private void Awake()
    {
        gameObject.OnCollisionEnter2D(new ActionOnCollisionEnter2D.Properties
        {
            onCollisionEnter = (c) => Debug.Log("OnCollision"),
        });
    }
}
