using System;
using System.Collections.Generic;

namespace Task2Interface
{
    internal class DelegateAdapter : IComparer<int[]>
    {
        /// <summary>
        /// delegate hendler
        /// </summary>
        public Func<int[], int[], int> CompareMethodFunc { get; }

        /// <summary>
        /// Construct adapter object
        /// </summary>
        /// <param name="comparer">ouer delegete method</param>
        public DelegateAdapter(Func<int[], int[], int> comparer)
        {
            CompareMethodFunc = comparer;
        }

        /// <summary>
        /// Compare two sz-arrays
        /// </summary>
        /// <param name="x">first array</param>
        /// <param name="y">second array</param>
        /// <returns>defenition betwen</returns>
        public int Compare(int[] x, int[] y)
        {
            return CompareMethodFunc(x, y);
        }
    }
}
