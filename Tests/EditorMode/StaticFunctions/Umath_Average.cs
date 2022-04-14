using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;
using U.Gears.Math;


public class Umath_Average
{

    [Test]
    public void Umath_AverageFloat()
    {

        var list = new float[]
        {
            0f,
            .25f,
            .5f,
        };

        Assert.AreEqual(.25f, list.Average());

    }

    [Test]
    public void Umath_AverageVector2()
    {

        var list = new Vector2[]
        {
            new Vector2(-1f,1f),
            new Vector2(0f,0f),
        };

        Assert.AreEqual(new Vector2(-.5f, .5f), list.Average());

    }

    [Test]
    public void Umath_AverageVector3()
    {

        var list = new Vector3[]
        {
            new Vector3(1f,2f,3f),
            new Vector3(2f,3f,4f),
        };

        Assert.AreEqual(new Vector3(1.5f, 2.5f, 3.5f), list.Average());

    }
}
