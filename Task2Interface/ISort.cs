using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Interface
{
    public interface ISort
    {
        bool DoSort(int[] first, int[] second, bool invert);
    }
}
