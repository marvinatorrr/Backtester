using Backtester.Core.Models;
using Backtester.Core.Services;
using Backtester.Core.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace Backtester.Core
{
    public static class Extensions
    {
        public static void AddConsoleBacktest(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<ITwelveDataService, TwelveDataService>();
            services.AddSingleton<IStrategyHelpers, StrategyHelpers>();
            services.AddSingleton<ISimpleMovingAverage, SimpleMovingAverage>();
            var twelveDataConfig = new TwelveDataConfig()
            {
                ApiKey = Environment.GetEnvironmentVariable("TWELVE_DATA_API_KEY") ?? throw new ArgumentNullException("Twelve Data API key cannot be null")
            };
            services.AddSingleton(twelveDataConfig);
        }
    }
}
