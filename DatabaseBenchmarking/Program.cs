﻿using BenchmarkDotNet.Running;
using DatabaseBenchmarking;

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkSwitcher.FromTypes(new[] {
            typeof(NestedSetsAccessBenchmark),
            typeof(PathBasedAccessBenchmark),
            typeof(ClosureTableAccessBenchmark)
        }).Run();
    }
}