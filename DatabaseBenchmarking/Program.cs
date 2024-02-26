using BenchmarkDotNet.Running;
using DatabaseBenchmarking;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<DatabaseOperationBenchmark>();
    }
}
