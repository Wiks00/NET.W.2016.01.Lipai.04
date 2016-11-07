﻿using System;

namespace Task2Interface
{
    public class SortLogic
    {
        public static void Sort(int[][] array, ISort sorter)
        {
            if (ReferenceEquals(array, null) || ReferenceEquals(sorter, null))
                throw new NullReferenceException();

            for (var i = 0; i < array.Length; i++)
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (sorter.DoSort(array[j], array[j + 1]) > 0) continue;
                    Sort(array, i, j);
                }
        }

        private static void Sort(int[][] array, int i , int j)
        {
            var temp = array[j];
            array[j] = array[j + 1];
            array[j + 1] = temp;
        }
    }
}