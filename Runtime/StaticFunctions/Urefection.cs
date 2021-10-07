using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace U.Gears
{
    public static partial class Urefection
    {
        public static IEnumerable<T> GetNoAbstractSubClassesOf<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            objects.Sort();
            return objects;
        }
    }
}
