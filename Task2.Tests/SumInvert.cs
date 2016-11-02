using System.Linq;

namespace Task2Interface
{
    public class SumInvert : ISort
    {
        public int DoSort(int[] first, int[] second)
        {
            return second.Sum() - first.Sum();
        }
    }
}