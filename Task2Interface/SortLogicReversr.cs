using System;
using System.Collections.Generic;

namespace Task2Interface
{
    public class SortLogicReverse
    {
        /// <summary>
        /// Sort lines of array bubble sort by delegate that depends of sort method
        /// </summary>
        /// <param name="array">sort array</param>
        /// <param name="comparer">sort method</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
            => Sort(array, comparer.Compare);

        /// <summary>
        /// Sort lines of array bubble sort by interface that depends of sort method
        /// </summary>
        /// <param name="array">sort array</param>
        /// <param name="comparer">sort method</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            if (ReferenceEquals(array, null) || ReferenceEquals(comparer, null))
                throw new ArgumentNullException();

            for (var i = 0; i < array.Length; i++)
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer(array[j], array[j + 1]) > 0) continue;
                    Swap(ref array[j], ref array[j + 1]);
                }
        }

        private static void Swap(ref int[] i , ref int[] j)
        {
            var temp = i;
            i = j;
            j = temp;
        }
    }
}