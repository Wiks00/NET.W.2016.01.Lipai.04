using System.Collections.Generic;
using System.Linq;

namespace Task2Interface
{
    public class MaxInvert : IComparer<int[]>
    {
        /// <summary>
        /// Compare two sz-arrays by max element in line
        /// </summary>
        /// <param name="x">first array</param>
        /// <param name="y">second array</param>
        /// <returns>defenition betwen</returns>
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, null))
                return -1;
            if (ReferenceEquals(y, null))
                return 1;
            return y.Max() - x.Max();
        }
    }
}