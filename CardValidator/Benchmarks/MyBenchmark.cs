using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace CardValidator.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
//[SimpleJob(RuntimeMoniker.Net60)]
public class MyBenchmark
{
    //private CreditCard _card;

    //[GlobalSetup]
    //public void GlobalSetup()
    //{
    //    _card = new CreditCard("1234 5678 9012 3456");
    //}

    //[Benchmark]
    //public bool IsValid()
    //{
    //    return _card.IsValid(CardIssuer.AmericanExpress, CardIssuer.ChinaUnionPay, CardIssuer.Dankort, CardIssuer.Hipercard, CardIssuer.Discover, CardIssuer.Maestro, CardIssuer.Visa, CardIssuer.MasterCard);
    //}
}