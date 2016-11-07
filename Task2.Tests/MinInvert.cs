using System.Collections.Generic;
using System.Linq;

namespace Task2Interface
{
    public class MinInvert : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, null))
                return -1;
            if (ReferenceEquals(y, null))
                return 1;
            return y.Min() - x.Min();
        }
    }
}