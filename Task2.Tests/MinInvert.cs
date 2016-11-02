using System.Linq;

namespace Task2Interface
{
    public class MinInvert : ISort
    {
        public int DoSort(int[] first, int[] second)
        {
            return second.Min() - first.Min();
        }
    }
}