using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;
using U.Gears.Math;

public class Umath_VectorsTests
{

    [Test]
    public void Umath_Vectors_SetVector2()
    {

        var position = new Vector2(1, 1);

        Assert.AreEqual(new Vector2(2,1), position.SetX(2));
        Assert.AreEqual(new Vector2(1,2), position.SetY(2));

    }

    [Test]
    public void Umath_Vectors_SetVector3()
    {

        var position = new Vector3(1, 1, 1);

        Assert.AreEqual(new Vector3(2, 1, 1), position.SetX(2));
        Assert.AreEqual(new Vector3(1, 2, 1), position.SetY(2));
        Assert.AreEqual(new Vector3(1, 1, 2), position.SetZ(2));
        Assert.AreEqual(new Vector3(2, 2, 1), position.SetXY(2,2));
        Assert.AreEqual(new Vector3(2, 1, 2), position.SetXZ(2,2));
        Assert.AreEqual(new Vector3(1, 2, 2), position.SetYZ(2,2));

    }


    [Test]
    public void Umath_Vectors_OppVector2()
    {

        var position = new Vector2(1, 1);

        Assert.AreEqual(new Vector2(.9f, 1), position.OppX(x => x-.1f));
        Assert.AreEqual(new Vector2(1, .9f), position.OppY(y => y-.1f));
        Assert.AreEqual(new Vector2(.9f, .9f), position.Opp(v => v-.1f));

    }

    [Test]
    public void Umath_Vectors_OppVector3()
    {

        var position = new Vector3(1, 1, 1);

        Assert.AreEqual(new Vector3(.9f, 1, 1), position.OppX(x => x - .1f));
        Assert.AreEqual(new Vector3(1, .9f, 1), position.OppY(y => y - .1f));
        Assert.AreEqual(new Vector3(1, 1, .9f), position.OppZ(z => z - .1f));
        Assert.AreEqual(new Vector3(.9f, .9f, 1), position.OppXY(x => x - .1f, y => y - .1f));
        Assert.AreEqual(new Vector3(.9f, 1, .9f), position.OppXZ(x => x - .1f, z => z - .1f));
        Assert.AreEqual(new Vector3(1, .9f, .9f), position.OppYZ(y => y - .1f, z => z - .1f));
        Assert.AreEqual(new Vector3(.9f, .9f, .9f), position.Opp(v => v - .1f));

    }

}
