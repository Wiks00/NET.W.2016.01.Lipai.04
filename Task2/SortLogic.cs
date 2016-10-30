using System;
using System.Linq;

namespace Task2
{
    public static class SortLogic
    {
        public delegate bool method(int[] first, int[] second, bool invert);


        public static int[][] Sort(int[][] array, Func<int[], int[], bool, bool> func, bool invert = false)
        {
            if(ReferenceEquals(array, null) || ReferenceEquals(func, null))
                throw new NullReferenceException();

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (!func(array[j], array[j + 1], invert)) continue;
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }

            return array;
        }

        public static bool Sum(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Sum() > second.Sum();
            }
            else
            {
                return first.Sum() < second.Sum();
            }

        }


        public static bool Min(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Min() > second.Min();
            }
            else
            {
                return first.Min() < second.Min();
            }

        }

        public static bool Max(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Max() > second.Max();
            }
            else
            {
                return first.Max() < second.Max();
            }

        }
    }
}
