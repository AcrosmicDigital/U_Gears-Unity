using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustPrint : MonoBehaviour
{
    public void Print()
    {
        Debug.Log("Log Now");
    }

    public void Print(GameObject gameObject)
    {
        Debug.Log("Log Name: " + gameObject.name);
    }
}
