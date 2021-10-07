using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;


public class Umath_Random
{

    [Test]
    public void Umath_RandomInt()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomInt(0,5));
        }
    }

    [Test]
    public void Umath_RandomInt_Negative()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomInt(-5, 0));
        }
    }

    [Test]
    public void Umath_RandomFloat()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomFloat(0, 5));
        }
    }

    [Test]
    public void Umath_RandomVector2()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomVector2(new Vector2(1,5), new Vector2(3, 7)));
        }
    }

    [Test]
    public void Umath_RandomVector3()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomVector3(new Vector3(1, 5, 10), new Vector3(3, 7, 12)));
        }
    }

    [Test]
    public void Umath_RandomVector4()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomVector4(new Vector4(1, 5, 10, 15), new Vector4(3, 7, 12, 17)));
        }
    }


    [Test]
    public void Umath_RandomVector2Int()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomVector2Int(new Vector2Int(1, 5), new Vector2Int(3, 7)));
        }
    }

    [Test]
    public void Umath_RandomVector3Int()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("RandomInt: " + Umath.RandomVector3Int(new Vector3Int(1, 5, 10), new Vector3Int(3, 7, 12)));
        }
    }

}
