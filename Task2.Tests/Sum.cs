using System.Linq;

namespace Task2Interface
{
    public class Sum : ISort
    {
        public int DoSort(int[] first, int[] second)
        {
            return first.Sum() - second.Sum();
        }
    }
}