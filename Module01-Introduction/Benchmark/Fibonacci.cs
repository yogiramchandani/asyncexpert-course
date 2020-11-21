using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Dotnetos.AsyncExpert.Homework.Module01.Benchmark
{
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true)]
    [MemoryDiagnoser]
    public class FibonacciCalc
    {
        // HOMEWORK:
        // 1. Write implementations for RecursiveWithMemoization and Iterative solutions
        // 2. Add MemoryDiagnoser to the benchmark
        // 3. Run with release configuration and compare results
        // 4. Open disassembler report and compare machine code
        // 
        // You can use the discussion panel to compare your results with other students

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public ulong Recursive(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong RecursiveWithMemoization(ulong n)
        {
            var lookup = new ulong[n + 1];
            return RecursiveWithMemoization(n, lookup);
        }

        private ulong RecursiveWithMemoization(ulong n, ulong[] lookup)
        {
            if (n == 1 || n == 2) return 1;
            if (lookup[n] == default) lookup[n] = RecursiveWithMemoization(n - 2, lookup) + RecursiveWithMemoization(n - 1, lookup);
            return lookup[n];
        }
        
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong Iterative(ulong n)
        {
            ulong prev = 1;
            ulong result = 1;
            for(ulong i = 3; i <= n; i++)
            {
                var temp = result;
                result += prev;
                prev = temp;
            }
            return result;
        }

        public IEnumerable<ulong> Data()
        {
            yield return 15;
            yield return 35;
        }
    }
}
