using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;
using U.Gears.Math;

public class Umath_FloatsTests
{

    [Test]
    public void Umath_Round_Truncate()
    {
        Assert.AreEqual(12f, 12.46665f.Truncate());
        Assert.AreEqual(0f, 0.46665f.Truncate());
        Assert.AreEqual(0f, 0f.Truncate());
        Assert.AreEqual(1f, 1.46665f.Truncate());
        Assert.AreEqual(3f, 3.065f.Truncate());
        Assert.AreEqual(-1f, -1f.Truncate());
        Assert.AreEqual(1f, 1f.Truncate());
        Assert.AreEqual(-3f, -3.065f.Truncate());

        // Value is passed by copy
        var a = 3.444f;
        a.Truncate();
        Assert.AreNotEqual(3f, a);
    }


    [Test]
    public void Umath_Round_InverseTruncate()
    {
        Assert.AreEqual(.46665f, 12.46665f.InverseTruncate());
        Assert.AreEqual(.46665f, 0.46665f.InverseTruncate());
        Assert.AreEqual(0f, 0f.InverseTruncate());
        Assert.AreEqual(.46665f, 0.46665f.InverseTruncate());
        Assert.AreEqual(.46665f, 3.46665f.InverseTruncate());
        Assert.AreEqual(0f, -1f.InverseTruncate());
        Assert.AreEqual(0f, 1f.InverseTruncate());
        Assert.AreEqual(-.46665f, -3.46665f.InverseTruncate());

        // Value is passed by copy
        var a = 3.444f;
        a.InverseTruncate();
        Assert.AreNotEqual(0.444f, a);
    }


    [Test]
    public void Umath_Round_Elevate()
    {
        Assert.AreEqual(4f, 12.46665f.Elevate(1));
        Assert.AreEqual(46f, 0.46665f.Elevate(2));
        Assert.AreEqual(0f, 0f.Elevate(2));
        Assert.AreEqual(466f, 0.46665f.Elevate(3));
        Assert.AreEqual(4f, 3.46665f.Elevate(0));  // Min 1
        Assert.AreEqual(0f, -1f.Elevate(4));
        Assert.AreEqual(0f, 1f.Elevate(1));
        Assert.AreEqual(-46f, -3.46665f.Elevate(2));


        // Value is passed by copy
        var a = 3.444f;
        a.Elevate(2);
        Assert.AreNotEqual(44f, a);
    }


    [Test]
    public void Umath_Round_Trim()
    {
        Assert.AreEqual(12.46f, 12.46665f.Trim(2));
        Assert.AreEqual(0.466f, 0.46665f.Trim(3));
        Assert.AreEqual(0f, 0f.Trim(2));
        Assert.AreEqual(0.4f, 0.46665f.Trim(1));
        Assert.AreEqual(3.4f, 3.46665f.Trim(0)); // Min 1
        Assert.AreEqual(-1f, -1f.Trim(10));
        Assert.AreEqual(1f, 1f.Trim(10));
        Assert.AreEqual(-3.46665f, -3.46665f.Trim(7));


        // Value is passed by copy
        var a = 3.444f;
        a.Trim(2);
        Assert.AreNotEqual(3.44f, a);

    }

}
