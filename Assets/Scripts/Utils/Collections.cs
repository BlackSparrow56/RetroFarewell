﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Collections
    {
        public static IEnumerable<T> For<T>(Func<int, T> func, int count)
        {
            var list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                list.Add(func(i));
            }

            return list.AsEnumerable();
        }

        public static IEnumerable<T> Append<T>(params IEnumerable<T>[] collections)
        {
            var list = new List<IEnumerable<T>>();
            foreach (var collection in collections)
            {
                list.Add(collection);
            }

            return list.SelectMany(value => value).AsEnumerable();
        }
    }
}
