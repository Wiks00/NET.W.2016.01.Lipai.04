using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Interface
{
    public class SortLogic
    {
        public static int[][] Sort(int[][] array, ISort sorter, bool invert = false)
        {
            if (ReferenceEquals(array, null) || ReferenceEquals(sorter, null))
                throw new NullReferenceException();

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (!sorter.DoSort(array[j], array[j + 1], invert)) continue;
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }

            return array;
        }
    }
}
