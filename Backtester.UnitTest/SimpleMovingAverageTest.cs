using Backtester.Core.Strategies;

namespace Backtester.UnitTest
{
    public class SimpleMovingAverageTest
    {
        [Fact]
        public void SimpleMovingAverage()
        {
            var prices = new List<decimal> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var period = 2;
            var expected = new List<decimal?> { null, 15, 25, 35, 45, 55, 65, 75, 85, 95 };
            var sut = new StrategyHelpers();
            var result = sut.CalculateMovingAverage(prices, period); 
            Assert.Equal(expected, result);
        }
    }
}