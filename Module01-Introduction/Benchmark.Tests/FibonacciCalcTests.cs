using Dotnetos.AsyncExpert.Homework.Module01.Benchmark;
using System;
using System.Collections.Generic;
using Xunit;

namespace Benchmark.Tests
{
    public class FibonacciCalcTests
    {
        [Theory]
        [MemberData(nameof(FibonacciTestData))]
        public void Recursive(ulong input, ulong expected)
        {
            var sut = new FibonacciCalc();
            var actual = sut.Recursive(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FibonacciTestData))]
        public void RecursiveWithMemoization(ulong input, ulong expected)
        {
            var sut = new FibonacciCalc();
            var actual = sut.RecursiveWithMemoization(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FibonacciTestData))]
        public void Iterative(ulong input, ulong expected)
        {
            var sut = new FibonacciCalc();
            var actual = sut.Iterative(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> FibonacciTestData
        {
            get
            {
                yield return new object[] { 1, 1 };
                yield return new object[] { 2, 1 };
                yield return new object[] { 3, 2 };
                yield return new object[] { 4, 3 };
                yield return new object[] { 5, 5 };
                yield return new object[] { 6, 8 };
                yield return new object[] { 7, 13 };
                yield return new object[] { 8, 21 };
                yield return new object[] { 9, 34 };
                yield return new object[] { 10, 55 };
            }
        }
    }
}
