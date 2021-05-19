using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Helpers
{
    public class Array
    {
        public static IEnumerable<TResult> Map<T,TResult>(IEnumerable<T> list, Func<T, TResult> fn)
        {
            return list.Select(fn);
        }
        
        public static void ForEach<T>(IEnumerable<T> list, Action<T> fn)
        {
            foreach (var el in list)
            {
                fn(el);
            }
        }
        
        public static IEnumerable<T> Filter<T>(IEnumerable<T> list, Func<T, bool> fn)
        {
            return list.Where(fn);
        }
        
        /*Не работает как надо*/
        public static T Find<T>(IEnumerable<T> list, Func<T, bool> fn)
        {
            var newList = list.Where(fn);

            return newList.FirstOrDefault();
        }
    }
}