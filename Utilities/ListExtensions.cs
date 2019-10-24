using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.Utilities
{
    public static class ListExtensions
    {
        /// <summary>
        ///     Performs a binary search on a sorted list.
        /// </summary>
        public static int BinarySearch<T>(this List<T> list, T item, Func<T, T, int> compare)
        {
            return list.BinarySearch(item, new ComparisonComparer<T>(compare));
        }

        /// <summary>
        ///     Checks if this list is null or is empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        ///     Concatinates the ToString() value of each item in this list.  Each string will be
        ///     separated by the value in the <paramref name="separator"/> parameter.
        /// </summary>
        /// 
        /// <param name="list">
        ///     The calling list.
        /// </param>
        /// 
        /// <param name="separator">
        ///     The separator to insert between each string.
        /// </param>
        public static string ToConcatinatedString<T>(this List<T> list, string separator = ", ")
        {
            string result = string.Empty;

            foreach (T item in list)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += separator;
                }
                result += item.ToString();
            }

            return result;
        }

        /// <summary>
        ///     Concatinates the ToString() value of each item in this list, prefixes that string 
        ///     with the specified title, and returns the result.  Each concatinated string will be
        ///     separated by the value in the <paramref name="separator"/> parameter.
        /// </summary>
        /// 
        /// <param name="list">
        ///     The calling list.
        /// </param>
        /// 
        /// <param name="title">
        ///     The title to append to the returned string.
        /// </param>
        /// 
        /// <param name="separator">
        ///     The separator to insert between each string.
        /// </param>
        public static string ToConcatinatedStringWithTitle<T>(this List<T> list, string title, string separator = ", ")
        {
            string concatinated = string.Empty;

            foreach (T item in list)
            {
                if (!string.IsNullOrEmpty(concatinated))
                {
                    concatinated += separator;
                }
                concatinated += item.ToString();
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(title);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(concatinated);

            return stringBuilder.ToString();
        }
    }

    /// <summary>
    ///     Utility class used for binary searches.
    /// </summary>
    public class ComparisonComparer<T> : IComparer<T>
    {
        private readonly Comparison<T> comparison;

        public ComparisonComparer(Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new ArgumentNullException("comparison");
            }
            comparison = new Comparison<T>(compare);
        }

        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }
    }
}
