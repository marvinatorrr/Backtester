using System.Net.Http.Json;
using Backtester.Core.Models;

namespace Backtester.Core.Services
{
    public class TwelveDataService : ITwelveDataService
    {
        private readonly HttpClient client;
        private readonly string apiKey;

        public TwelveDataService(IHttpClientFactory httpClientFactory, TwelveDataConfig twelveDataConfig)
        {
            client = httpClientFactory.CreateClient();
            apiKey = twelveDataConfig.ApiKey;
        }

        public async Task<TwelveDataResponse> GetData()
        {
            var url = $"https://api.twelvedata.com/time_series?start_date=2020-05-06&outputsize=5&symbol=aapl&interval=1day&apikey={apiKey}";
            return await client.GetFromJsonAsync<TwelveDataResponse>(url);
        }
    }
}
