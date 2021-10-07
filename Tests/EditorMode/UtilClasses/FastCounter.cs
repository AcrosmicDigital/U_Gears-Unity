using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;
public class FastCounter_Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void FastCounterSimplePasses()
    {

        var counter = new FastCounter(0, 10);

        Assert.AreEqual(0, counter.Current);
        Assert.AreEqual(1, counter.Next());

        Assert.AreEqual(1, counter.Current);
        Assert.AreEqual(2, counter.Next());

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(3, counter.Next(1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(0));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-2));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(5, counter.Next(2));

        Assert.AreEqual(5, counter.Current);
        Assert.AreEqual(10, counter.Next(5));

        Assert.AreEqual(10, counter.Current);
        Assert.AreEqual(5, counter.Prev(5));

        Assert.AreEqual(5, counter.Current);
        Assert.AreEqual(3, counter.Prev(2));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Prev(0));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-2));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(2, counter.Prev());

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(1, counter.Prev());

        Assert.AreEqual(1, counter.Current);
        Assert.AreEqual(0, counter.Prev());
    }

}
