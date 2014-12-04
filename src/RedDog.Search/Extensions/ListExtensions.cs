using System;
using System.Collections.Generic;
using System.Linq;

namespace RedDog.Search
{
    /// <summary>
    /// Provides extensions methods for the <see cref="List{T}"/> generic type.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Chunk a list into a number of parts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<List<T>> Chunk<T>(this List<T> source, int num)
        {
            if (num <= 0)
            {
                throw new ArgumentException("num should be positive", "num");
            }

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / num)
                .Select(x => x.Select(y => y.Value).ToList())
                .ToList();
        }
    }
}
