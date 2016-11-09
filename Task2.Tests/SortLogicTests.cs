using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task2Interface;

namespace Task2.Tests
{
    [TestFixture]
    public class SortLogicTests
    {
        private static readonly int[][] testArray =
        {
            new[] {1, -2, 3},
            new[] {0, 2, 13, 4},
            new[] {1, 3},
            new[] {14}
        };

        private static readonly object[] sourceListsForInterfaceMethod =
        {
            new object[] {testArray, SelectSort.Sum, 0},
            new object[] {testArray, SelectSort.MinInvert, 1},
            new object[] {testArray, SelectSort.Max, 14}
        };

        private static readonly object[] sourceListsForDelegeteToInterfaceMethod =
        {
            new object[] {testArray, (Func<int[], int[], int>)SelectSort.Sum.Compare, 0},
            new object[] {testArray, (Func<int[], int[], int>)SelectSort.MinInvert.Compare, 1},
            new object[] {testArray, (Func<int[], int[], int>)SelectSort.Max.Compare, 14}
        };

        private static readonly object[] sourceListsForInterfaceToDelegeteMethod =
      {
            new object[] {testArray, SelectSort.Sum, 0},
            new object[] {testArray, SelectSort.MinInvert, 1},
            new object[] {testArray, SelectSort.Max, 14}
        };

        private static readonly object[] sourceListsForDelegeteMethod =
        {
            new object[] {testArray, (Func<int[],int[],int>)SelectSort.Sum.Compare, 0},
            new object[] {testArray, (Func<int[], int[], int>)SelectSort.MinInvert.Compare, 1},
            new object[] {testArray, (Func<int[], int[], int>)SelectSort.Max.Compare, 14}
        };

        private static readonly object[] sourceListsForNullReferenceException =
        {
            new object[] {null, SelectSort.Sum},
            new object[] {testArray, null}
        };

        private class SelectSort
        {
            public static IComparer<int[]> Sum { get; } = new Sum();
            public static IComparer<int[]> SumInvert { get; } = new SumInvert();
            public static IComparer<int[]> Min { get; } = new Min();
            public static IComparer<int[]> MinInvert { get; } = new MinInvert();
            public static IComparer<int[]> Max { get; } = new Max();
            public static IComparer<int[]> MaxInvert { get; } = new MaxInvert();
        }


        [Test]
        [TestCaseSource(nameof(sourceListsForInterfaceMethod))]
        public void Sort_SortJaggedArrayWithFewSolutionsByInterface(int[][] array, IComparer<int[]> sorter, int returnValue)
        {
            SortLogic.Sort(array, sorter);
            Assert.AreEqual(array[0][0], returnValue);
        }

        [Test]
        [TestCaseSource(nameof(sourceListsForDelegeteToInterfaceMethod))]
        public void Sort_SortJaggedArrayWithFewSolutionsByDelegateToInterface(int[][] array, Func<int[],int[],int> func, int returnValue)
        {
            SortLogic.Sort(array, func);
            Assert.AreEqual(array[0][0], returnValue);
        }

        [Test]
        [TestCaseSource(nameof(sourceListsForInterfaceToDelegeteMethod))]
        public void Sort_SortJaggedArrayWithFewSolutionsByInterfaceToDelegete(int[][] array, IComparer<int[]> sorter, int returnValue)
        {
            SortLogicReverse.Sort(array, sorter);
            Assert.AreEqual(array[0][0], returnValue);
        }

        [Test]
        [TestCaseSource(nameof(sourceListsForDelegeteMethod))]
        public void Sort_SortJaggedArrayWithFewSolutionsByDelegate(int[][] array, Func<int[], int[], int> func, int returnValue)
        {
            SortLogicReverse.Sort(array, func);
            Assert.AreEqual(array[0][0], returnValue);
        }

        [Test]
        [TestCaseSource(nameof(sourceListsForNullReferenceException))]
        public void Sort_TestForArgumentNullException(int[][] array, IComparer<int[]> sorter)
        {
            Assert.That(() => Task2Interface.SortLogic.Sort(array, sorter),
                Throws.TypeOf<ArgumentNullException>());
        }
    }
}