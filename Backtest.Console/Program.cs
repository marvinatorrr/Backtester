using Backtester.Core;
using Backtester.Core.Strategies;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddConsoleBacktest();
var serviceProvider =  services.BuildServiceProvider();
var twelveDataService = serviceProvider.GetService<ITwelveDataService>();
var strategy = serviceProvider.GetService<ISimpleMovingAverage>();
var result = await twelveDataService.GetData("aapl", new DateTime(2016,1,1), 2500, Backtester.Core.Services.Interval._1Day);
var prices = result.Values.Select(x => x.Open).ToList();
var signals = strategy.GenerateSignals(prices).ToList();

var n = signals.Count();
var startingCapital = 10_000m;
var cash = startingCapital;
var trades = 0;
var position = 0m;

for(var i = 0; i < n; i++)
{
    if (signals[i] == Signal.Buy && cash >= prices[i])
    {
        position = cash / prices[i];
        trades++;
        cash = 0;
    }
    else if (signals[i] == Signal.Sell && position > 0)
    {
        cash = position * prices[i];
        trades++;
    }
}

var portfolioValue = cash + position * prices.Last();
var profit = portfolioValue - startingCapital;

Console.WriteLine($"starting capital: ${startingCapital}");
Console.WriteLine($"profit: {profit}");
Console.WriteLine($"returns: {profit / startingCapital}");
