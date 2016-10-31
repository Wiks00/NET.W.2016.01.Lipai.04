using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Interface
{
    public class Max : ISort
    {
        public bool DoSort(int[] first, int[] second, bool invert)
        {
            if (invert)
            {
                return first.Max() > second.Max();
            }
            return first.Max() < second.Max();
        }
    }
}
