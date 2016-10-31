using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Interface
{
    public class Min: ISort
    {
        public bool DoSort(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Min() > second.Min();
            }
            return first.Min() < second.Min();
        }
    }
}
