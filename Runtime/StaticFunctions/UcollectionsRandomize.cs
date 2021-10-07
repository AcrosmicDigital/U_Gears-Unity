using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace U.Gears
{
    public static partial class Ucollections
    {
        
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            // Create a random number generator
            System.Random rnd = new System.Random(DateTime.Now.Millisecond);
            return collection
                .Select(item => new { item, order = rnd.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.item);
        }

        public static Queue<T> ToQueue<T>(this IEnumerable<T> collection)
        {
            // Create the queue
            var queue = new Queue<T>();

            // Create a random number generator
            collection
                .Select(x => { queue.Enqueue(x); return true; })
                .ToArray();

            return queue;
        }

        public static Stack<T> ToStack<T>(this IEnumerable<T> collection)
        {
            // Create the queue
            var stack = new Stack<T>();

            // Create a random number generator
            collection
                .Select(x => { stack.Push(x); return true; })
                .ToArray();

            return stack;
        }

        // Recorre una colo x posiciones, poniendo los que quita al inicio
        internal static Queue<T> Jump<T>(this Queue<T> queue, int positions)
        {
            // Create the queue
            var outQueue = new Queue<T>(queue);

            // Create a random number generator
            for (int i = 0; i < positions; i++)
            {
                if (outQueue.Count() < 1)
                    break;

                var bk = outQueue.Dequeue();
                outQueue.Enqueue(bk);
            }

            return outQueue;
        }

    }
}
