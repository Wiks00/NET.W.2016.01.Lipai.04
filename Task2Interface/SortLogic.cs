﻿using System;
using System.Collections.Generic;

namespace Task2Interface
{
    public class SortLogic
    {
        /// <summary>
        /// Sort lines of array bubble sort by interface that depends of sort method
        /// </summary>
        /// <param name="array">sort array</param>
        /// <param name="comparer">sort method</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            if (ReferenceEquals(array, null) || ReferenceEquals(comparer, null))
                throw new ArgumentNullException();

            for (var i = 0; i < array.Length; i++)
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0) continue;
                        Swap(ref array[j],ref array[j + 1]);
                }
        }

        /// <summary>
        /// Sort lines of array bubble sort by delegate that depends of sort method
        /// </summary>
        /// <param name="array">sort array</param>
        /// <param name="comparer">sort method</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            if(ReferenceEquals(comparer, null))
                throw new ArgumentNullException();
            Sort(array, new DelegateAdapter(comparer));
        }

        private static void Swap(ref int[] i , ref int[] j)
        {
            var temp = i;
            i = j;
            j = temp;
        }
    }
}