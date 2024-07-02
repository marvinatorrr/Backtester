namespace Backtester.Core.Strategies
{
    public class SimpleMovingAverage : ISimpleMovingAverage
    {
        private readonly IStrategyHelpers _helpers;

        public SimpleMovingAverage(IStrategyHelpers helpers)
        {
            _helpers = helpers;
        }

        public IEnumerable<Signal> GenerateSignals(List<decimal> prices)
        {
            var signals = new List<Signal>();

            var movingAverages = _helpers.CalculateMovingAverage(prices, 10).ToList();

            for (var i = 0; i < prices.Count; i++)
            {
                if (movingAverages[i] is not null && prices[i] > movingAverages[i] && prices[i - 1] <= movingAverages[i - 1])
                {
                    signals.Add(Signal.Buy);
                }
                else if (movingAverages[i] is not null && prices[i] < movingAverages[i] && prices[i - 1] >= movingAverages[i - 1])
                {
                    signals.Add(Signal.Sell);
                }
                else
                {
                    signals.Add(Signal.Hold);
                }
            }

            return signals;
        }
    }

    public enum Signal
    {
        Buy,
        Sell,
        Hold
    }

    public class StrategyHelpers : IStrategyHelpers
    {
        public IEnumerable<decimal?> CalculateMovingAverage(List<decimal> prices, int period)
        {
            var simpleMovingAverages = new List<decimal?>();
            var sum = 0m;
            for (var i = 0; i < period; i++)
            {
                sum += prices[i];
            }
            for (var i = 0; i < period - 1; i++)
            {
                simpleMovingAverages.Add(null);
            }
            simpleMovingAverages.Add(sum / period);
            for (var i = period; i < prices.Count; i++)
            {
                sum -= prices[i - period];
                sum += prices[i];
                simpleMovingAverages.Add(sum / period);
            }
            return simpleMovingAverages;
        }
    }
}

