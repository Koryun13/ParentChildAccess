using BenchmarkDotNet.Running;
using DatabaseBenchmarking;

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkSwitcher.FromTypes(new[] {
            typeof(DatabaseOperationBenchmark),
            typeof(PathBasedAccessBenchmark),
            typeof(ClosureTableAccessBenchmark)
        }).Run();
    }
}