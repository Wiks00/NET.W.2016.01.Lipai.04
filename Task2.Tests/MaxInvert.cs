using System.Linq;

namespace Task2Interface
{
    public class MaxInvert : ISort
    {
        public int DoSort(int[] first, int[] second)
        {
            return second.Max() - first.Max();
        }
    }
}