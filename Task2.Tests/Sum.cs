using System.Collections.Generic;
using System.Linq;

namespace Task2Interface
{
    public class Sum : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, null))
                return 1;
            if (ReferenceEquals(y, null))
                return -1;
            return x.Sum() - y.Sum();
        }
    }
}