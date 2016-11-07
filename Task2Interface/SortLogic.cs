using System;
using System.Collections.Generic;

namespace Task2Interface
{
    public class SortLogic
    {
        public static void Sort(int[][] array, IComparer<int[]> sorter)
        {
            if (ReferenceEquals(array, null) || ReferenceEquals(sorter, null))
                throw new ArgumentNullException();

            for (var i = 0; i < array.Length; i++)
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (sorter.Compare(array[j], array[j + 1]) > 0) continue;
                        Swap(ref array[j],ref array[j + 1]);
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