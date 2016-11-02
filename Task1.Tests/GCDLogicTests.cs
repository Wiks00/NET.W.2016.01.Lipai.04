using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task1.GcdLogic;

namespace Task1.Tests
{
    [TestFixture]
    public class GCDLogicTests
    {
        private object a = new MyTimerDelegate(EuclidGcd);

        [TestCase(30, 18,ExpectedResult = 6)]
        public int Gcd_FindGreatestCommonDivisor(int par,int par2)
        {
            return EuclidGcd(par, par2);
        }

        [TestCase(5, 10, 0, ExpectedResult = 5)]
        public int Gcd_FindGreatestCommonDivisor(int par, int par2,int par3)
        {
            return EuclidGcd(par, par2,par3);
        }

        [TestCase(5, 10, 1, 5,ExpectedResult = 1)]
        public int Gcd_FindGreatestCommonDivisor(params int[] ingeres)
        {
            return EuclidGcd(ingeres);
        }

        [TestCase(30, 18, ExpectedResult = 6)]
        public int BinaryGcd_FindGreatestCommonDivisor(int par, int par2)
        {
            return BinaryEuclidGcd(par, par2);
        }

        [TestCase(5, 10, 0, ExpectedResult = 5)]
        public int BinaryGcd_FindGreatestCommonDivisor(int par, int par2, int par3)
        {
            return BinaryEuclidGcd(par, par2, par3);
        }

        [TestCase(5, 10, 1, 5, ExpectedResult = 1)]
        public int BinaryGcd_FindGreatestCommonDivisor(params int[] ingeres)
        {
            return BinaryEuclidGcd(ingeres);
        }

        private static readonly object[] sourceListsForSpeedTest = {new object[] {new MyTimerDelegate(EuclidGcd), new[] { 5, 10, 1, 5 }},
                                                                    new object[] {new MyTimerDelegate(EuclidGcd), new[] { 30, 18 }},
                                                                    new object[] {new MyTimerDelegate(BinaryEuclidGcd), new[] { 5, 10, 1, 5 }},
                                                                    new object[] {new MyTimerDelegate(BinaryEuclidGcd), new[] { 30, 18 }}};

        [Test, TestCaseSource(nameof(sourceListsForSpeedTest))]
        public void TestSpeed_TestSpeed(MyTimerDelegate method,params int[] ints)
        {
            Console.WriteLine(ints.Length > 2
                ? TestSpeed(method, ints).ToString()
                : TestSpeed(method, ints[0], ints[1]).ToString());
        }

        [TestCase(-1, 18)]
        public void Gcd_TestForArgumentOutOfRangeException(int par, int par2)
        {
            Assert.That(() => EuclidGcd(par, par2), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(-1, 10, 0)]
        [TestCase(5, 10, -1)]
        public void Gcd_TestForArgumentOutOfRangeExceptiond(int par, int par2, int par3)
        {
            Assert.That(() => EuclidGcd(par, par2, par3), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}
