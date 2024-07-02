
namespace Backtester.Core.Strategies
{
    public interface ISimpleMovingAverage
    {
        IEnumerable<Signal> GenerateSignals(List<decimal> prices);
    }
}