using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class GcdLogic
    {
        /// <summary>
        /// delegate for speed test
        /// </summary>
        /// <param name="integers">Gcd of that integers</param>      
        public delegate int MyTimerDelegate(params int[] integers);

        #region Euclid GCD
        /// <summary>
        /// Calculete Greatest Common Divisor by Euclid rule
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>Greatest Common Divisor of two numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int EuclidGcd(int a, int b)
        {
            if(a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();
            int t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        /// <summary>
        /// Calculete Greatest Common Divisor by Euclid rule
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <returns>Greatest Common Divisor of three numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int EuclidGcd(int a, int b, int c)
        {
            if(c < 0)
                throw new ArgumentOutOfRangeException();

            return EuclidGcd(EuclidGcd(a, b), c);
        }

        /// <summary>
        /// Calculete Greatest Common Divisor by Euclid rule
        /// </summary>
        /// <param name="integers">array of numbers</param>
        /// <returns>Greatest Common Divisor of array of numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int EuclidGcd(params int[] integers)
        {
            if(integers.Length < 0 || integers.Any(curent => curent < 2))
                throw new ArgumentOutOfRangeException();

            int value = integers[0];
            for (int i = 1; i < integers.Length -1; i++)
            {
                value = EuclidGcd(value, integers[i]);
            }
            return EuclidGcd(value, integers[integers.Length -1]);
        }
        #endregion

        #region Euclid Binary GCD
        /// <summary>
        /// Calculete Greatest Common Divisor by binary Euclid rule
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>Greatest Common Divisor of two numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int BinaryEuclidGcd(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();

            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * BinaryEuclidGcd(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return BinaryEuclidGcd(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return BinaryEuclidGcd(a, b / 2);
            if ((a % 2 != 0) && (b % 2 != 0) && b > a) return BinaryEuclidGcd(a, (b - a) / 2);
            return BinaryEuclidGcd((a - b) / 2, b);
        }

        /// <summary>
        /// Calculete Greatest Common Divisor by binary Euclid rule
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <returns>Greatest Common Divisor of three numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int BinaryEuclidGcd(int a, int b,int c)
        {
            if (c < 0)
                throw new ArgumentOutOfRangeException();

            return BinaryEuclidGcd(BinaryEuclidGcd(a, b), c);
        }

        /// <summary>
        /// Calculete Greatest Common Divisor by binary Euclid rule
        /// </summary>
        /// <param name="integers">array of numbers</param>
        /// <returns>Greatest Common Divisor of array of numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int BinaryEuclidGcd(params int[] integers)
        {
            if (integers.Length < 0 || integers.Any(curent => curent < 2))
                throw new ArgumentOutOfRangeException();

            int value = integers[0];
            for (int i = 1; i < integers.Length - 1; i++)
            {
                value = BinaryEuclidGcd(value, integers[i]);
            }
            return BinaryEuclidGcd(value, integers[integers.Length - 1]);
        }
        #endregion

        #region Speed Tst
       
        /// <summary>
        /// Test speed of method
        /// </summary>
        /// <param name="method">Tested method</param>
        /// <param name="a">first parameter for method</param>
        /// <param name="b">second parameter for method</param>
        /// <returns>Ticks count</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static long TestSpeed(MyTimerDelegate method, int a, int b)
        {
            if(ReferenceEquals(method,null))
                throw new NullReferenceException();
            if(a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            method(a,b);
            watch.Stop();
            return watch.ElapsedTicks;
        }

        /// <summary>
        /// Test speed of method
        /// </summary>
        /// <param name="method">Tested method</param>
        ///<param name="integers">array of parameters</param>
        /// <returns>Ticks count</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static long TestSpeed(MyTimerDelegate method, params int[] integers)
        {
            if (ReferenceEquals(method, null))
                throw new NullReferenceException();
            if (integers.Length < 0 || integers.Any(curent => curent < 0))
                throw new ArgumentOutOfRangeException();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            method(integers);
            watch.Stop();
            return watch.ElapsedTicks;
        }
        #endregion
    }
}
