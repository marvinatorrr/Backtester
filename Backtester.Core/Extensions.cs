using Backtester.Core.Models;
using Backtester.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backtester.Core
{
    public static class Extensions
    {
        public static void AddConsoleBacktest(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<ITwelveDataService, TwelveDataService>();
            var twelveDataConfig = new TwelveDataConfig()
            {
                ApiKey = Environment.GetEnvironmentVariable("TWELVE_DATA_API_KEY") ?? throw new ArgumentNullException("Twelve Data API key cannot be null")
            };
            services.AddSingleton(twelveDataConfig);
        }
    }
}
