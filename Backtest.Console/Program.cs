using Backtester.Core;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddConsoleBacktest();
var serviceProvider =  services.BuildServiceProvider();
var twelveDataService = serviceProvider.GetService<ITwelveDataService>();
var result = await twelveDataService.GetData();
Console.WriteLine(result);