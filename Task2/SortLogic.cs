using System;
using System.Linq;

namespace Task2
{
    public static class SortLogic
    {
        /// <summary>
        /// delegate for sort method .
        /// </summary>
        /// <param name="first">first array</param>
        /// <param name="second">second array</param>
        /// <param name="invert">sorting order</param>
        public delegate bool SortMethod(int[] first, int[] second, bool invert);

        /// <summary>
        /// Sort lines of array bubble sort that  depends of sort method
        /// </summary>
        /// <param name="array">sort array</param>
        /// <param name="func">sort method</param>
        /// <param name="invert">sorting order</param>
        /// <returns>link to sorted array (need to foreach)</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static int[][] Sort(int[][] array, SortMethod func, bool invert = false)
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

        /// <summary>
        /// Method that allows to sort by sum of values in line
        /// </summary>
        /// <param name="first">first array</param>
        /// <param name="second">second array</param>
        /// <param name="invert">sorting order</param>
        /// <returns>true if first bigger and e.c.</returns>
        public static bool Sum(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Sum() > second.Sum();
            }
            return first.Sum() < second.Sum();
        }

        /// <summary>
        /// Method that allows to sort by max value in line
        /// </summary>
        /// <param name="first">first array</param>
        /// <param name="second">second array</param>
        /// <param name="invert">sorting order</param>
        /// <returns>true if first bigger and e.c.</returns>
        public static bool Min(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Min() > second.Min();
            }
            return first.Min() < second.Min();
        }

        /// <summary>
        /// Method that allows to sort by min value in line
        /// </summary>
        /// <param name="first">first array</param>
        /// <param name="second">second array</param>
        /// <param name="invert">sorting order</param>
        /// <returns>true if first bigger and e.c.</returns>
        public static bool Max(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Max() > second.Max();
            }
            return first.Max() < second.Max();
        }
    }
}
