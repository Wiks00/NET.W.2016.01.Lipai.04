using System.Linq;

namespace Task2Interface
{
    public class Max : ISort
    {
        public int DoSort(int[] first, int[] second)
        {
            return first.Max() - second.Max();
        }
    }
}