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
    public void Umath_Vectors_Operate()
    {

        Assert.AreEqual(new Vector2(4,8), new Vector2(2,4).Operate((p) => p*2));
        Assert.AreEqual(new Vector2(4, 8), new Vector2(2, 4).Operate((p) => p * 2));


        // Value is passed by copy
        var a = 3.444f;
        a.Truncate();
        Assert.AreNotEqual(3f, a);
    }

}
