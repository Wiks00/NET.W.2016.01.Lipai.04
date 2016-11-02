using System.Linq;

namespace Task2Interface
{
    public class Min : ISort
    {
        public int DoSort(int[] first, int[] second)
        {
            return first.Min() - second.Min();
        }
    }
}