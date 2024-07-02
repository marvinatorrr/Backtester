
namespace Backtester.Core.Strategies
{
    public interface IStrategyHelpers
    {
        IEnumerable<decimal?> CalculateMovingAverage(List<decimal> prices, int period);
    }
}