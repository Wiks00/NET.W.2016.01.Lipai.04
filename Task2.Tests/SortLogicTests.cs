using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task2.SortLogic;

namespace Task2.Tests
{
    [TestFixture]
    public class SortLogicTests
    {

        [TestCase(arg1: new int[][]{new[]{1,-2,3},new[]{0,2,13,4},new[]{1,3},new[]{14}}, arg2: new method(Sum),ExpectedResult = 0)]              
        public int Sort_SortJaggedArrayWithFewSolutions(int[][] array, Func<int[], int[], bool, bool> func,bool invert = false)
        {
            string str = string.Empty;
            foreach (var item in Sort(array, func, invert))
            {
                str = item.Aggregate(string.Empty, (current, number) => current + number.ToString());
            }
            Console.WriteLine(str);

            return 0;
        }
    }
}
