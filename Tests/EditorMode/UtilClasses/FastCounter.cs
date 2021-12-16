using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using U.Gears;
public class Counter_Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void Counter_LimitTopBottom()
    {

        var counter = new Counter(new Counter.Properties 
        {
            // Default
            //from = 0,
            //to = 10,
            //current = 0,
            //countMode = Counter.CountMode.LimitTopBottom,
        });

        Assert.IsTrue(counter.IsBottom);

        Assert.AreEqual(0, counter.Current);
        Assert.AreEqual(1, counter.Next());

        Assert.AreEqual(1, counter.Current);
        Assert.AreEqual(2, counter.Next());

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(3, counter.Next(1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(0));

        Assert.IsFalse(counter.IsBottom);
        Assert.IsFalse(counter.IsTop);

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-2));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(5, counter.Next(2));

        Assert.AreEqual(5, counter.Current);
        Assert.AreEqual(10, counter.Next(5));

        Assert.IsTrue(counter.IsTop);

        Assert.AreEqual(10, counter.Current);
        Assert.AreEqual(10, counter.Next(5));

        Assert.AreEqual(10, counter.Current);
        Assert.AreEqual(8, counter.Prev(2));

        Assert.AreEqual(8, counter.Current);
        Assert.AreEqual(8, counter.Prev(0));

        Assert.AreEqual(8, counter.Current);
        Assert.AreEqual(8, counter.Prev(-2));

        Assert.IsFalse(counter.IsBottom);
        Assert.IsFalse(counter.IsTop);

        Assert.AreEqual(8, counter.Current);
        Assert.AreEqual(7, counter.Prev());

        Assert.AreEqual(7, counter.Current);
        Assert.AreEqual(6, counter.Prev());

        Assert.AreEqual(6, counter.Current);
        Assert.AreEqual(0, counter.Prev(8));

        Assert.AreEqual(0, counter.Current);
        Assert.AreEqual(0, counter.Prev(8));
    }


    [Test]
    public void Counter_LimitTop()
    {

        var counter = new Counter(new Counter.Properties
        {
            // Default
            //from = 0,
            //to = 10,
            //current = 0,
            countMode = Counter.CountMode.LimitTop,
        });

        Assert.IsTrue(counter.IsBottom);

        Assert.AreEqual(0, counter.Current);
        Assert.AreEqual(1, counter.Next());

        Assert.AreEqual(1, counter.Current);
        Assert.AreEqual(2, counter.Next());

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(3, counter.Next(1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(0));

        Assert.IsFalse(counter.IsBottom);
        Assert.IsFalse(counter.IsTop);

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-2));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(5, counter.Next(2));

        Assert.AreEqual(5, counter.Current);
        Assert.AreEqual(10, counter.Next(5));

        Assert.IsTrue(counter.IsTop);

        Assert.AreEqual(10, counter.Current);
        Assert.AreEqual(10, counter.Next(5));

        Assert.AreEqual(10, counter.Current);
        Assert.AreEqual(8, counter.Prev(2));

        Assert.AreEqual(8, counter.Current);
        Assert.AreEqual(8, counter.Prev(0));

        Assert.AreEqual(8, counter.Current);
        Assert.AreEqual(8, counter.Prev(-2));

        Assert.IsFalse(counter.IsBottom);
        Assert.IsFalse(counter.IsTop);

        Assert.AreEqual(8, counter.Current);
        Assert.AreEqual(7, counter.Prev());

        Assert.AreEqual(7, counter.Current);
        Assert.AreEqual(6, counter.Prev());

        Assert.AreEqual(6, counter.Current);
        Assert.AreEqual(9, counter.Prev(8));

        Assert.AreEqual(9, counter.Current);
        Assert.AreEqual(9, counter.Prev(11));

        counter.ToBottom();
        Assert.IsTrue(counter.IsBottom);

        Assert.AreEqual(10, counter.Prev(1));

    }


    [Test]
    public void Counter_LimitBottom()
    {

        var counter = new Counter(new Counter.Properties
        {
            // Default
            //from = 0,
            //to = 10,
            //current = 0,
            countMode = Counter.CountMode.LimitBottom,
        });

        Assert.IsTrue(counter.IsBottom);

        Assert.AreEqual(0, counter.Current);
        Assert.AreEqual(1, counter.Next());

        Assert.AreEqual(1, counter.Current);
        Assert.AreEqual(2, counter.Next());

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(3, counter.Next(1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(0));

        Assert.IsFalse(counter.IsBottom);
        Assert.IsFalse(counter.IsTop);

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-2));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(3, counter.Next(-1));

        Assert.AreEqual(3, counter.Current);
        Assert.AreEqual(5, counter.Next(2));

        Assert.AreEqual(5, counter.Current);
        Assert.AreEqual(10, counter.Next(5));

        Assert.IsTrue(counter.IsTop);

        Assert.AreEqual(10, counter.Current);
        Assert.AreEqual(4, counter.Next(5));

        Assert.AreEqual(4, counter.Current);
        Assert.AreEqual(2, counter.Prev(2));

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(2, counter.Prev(0));

        Assert.AreEqual(2, counter.Current);
        Assert.AreEqual(2, counter.Prev(-2));

        Assert.IsFalse(counter.IsBottom);
        Assert.IsFalse(counter.IsTop);

        counter.ToTop();
        Assert.IsTrue(counter.IsTop);

        Assert.AreEqual(0, counter.Next());

    }



    [Test]
    public void Counter_NoLimit()
    {

        var counter = new Counter(new Counter.Properties
        {
            // Default
            //from = 0,
            //to = 10,
            //current = 0,
            countMode = Counter.CountMode.NoLimits,
        });

        counter.ToTop();
        Assert.IsTrue(counter.IsTop);

        Assert.AreEqual(0, counter.Next());


        counter.ToBottom();
        Assert.IsTrue(counter.IsBottom);

        Assert.AreEqual(10, counter.Prev());

    }


}
