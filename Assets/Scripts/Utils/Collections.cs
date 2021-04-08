using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Collections
    {
        /// <summary>
        /// Заполняет коллекцию из метода заполняя числами от 0 до count.
        /// </summary>
        public static IEnumerable<T> For<T>(Func<int, T> func, int count)
        {
            var list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                list.Add(func(i));
            }

            return list.AsEnumerable();
        }
    }
}
