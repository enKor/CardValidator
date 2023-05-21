using BenchmarkDotNet.Running;

namespace CardValidator.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<MyBenchmark>();
    }
}