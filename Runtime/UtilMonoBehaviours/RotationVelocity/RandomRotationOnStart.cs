using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationOnStart : MonoBehaviour
{

    public int rotationMin = -20;
    public int rotationMax = 20;

    void Start() => transform.rotation = Quaternion.Euler(0, 0, Random.Range(rotationMin, rotationMax));

}
