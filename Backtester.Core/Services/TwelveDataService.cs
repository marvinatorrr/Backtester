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

        public async Task<TwelveDataResponse> GetData(string symbol, DateTime startDateTime, int size, Interval interval)
        {
            if(size < 1 || size > 5000)
            {
                throw new ArgumentException("Output size must be in the range from 1 to 5000");
            }
            var formatStartDate = startDateTime.ToString("yyyy-MM-dd");
            var url = $"https://api.twelvedata.com/time_series?start_date={formatStartDate}&outputsize={size}&symbol={symbol}&interval={interval.ToIntervalString()}&apikey={apiKey}";
            return await client.GetFromJsonAsync<TwelveDataResponse>(url);
        }

        public async Task<TwelveDataResponse> GetData(string symbol, DateTime startDateTime, DateTime endDateTime, Interval interval)
        {
            var formatStartDate = startDateTime.ToString("yyyy-MM-dd");
            var formatEndDate = endDateTime.ToString("yyyy-MM-dd");
            var url = $"https://api.twelvedata.com/time_series?start_date={formatStartDate}&end_date={formatEndDate}&symbol={symbol}&interval={interval.ToIntervalString()}day&apikey={apiKey}";
            return await client.GetFromJsonAsync<TwelveDataResponse>(url);
        }
    }

    public enum Interval
    {
        _1Minute,
        _5Minute,
        _15Minute,
        _30Minute,
        _45Minute,
        _1Hour,
        _2Hour,
        _4Hour,
        _1Day,
        _1Week,
        _1Month
    }

    public static class IntervalExtensions
    {
        public static string ToIntervalString(this Interval interval)
        {
            switch (interval)
            {
                case Interval._1Minute:
                    return "1min";
                case Interval._5Minute:
                    return "5min";
                case Interval._15Minute:
                    return "15min";
                case Interval._30Minute:
                    return "30min";
                case Interval._45Minute:
                    return "45min";
                case Interval._1Hour:
                    return "1h";
                case Interval._2Hour:
                    return "2h";
                case Interval._4Hour:
                    return "4h";
                case Interval._1Day:
                    return "1day";
                case Interval._1Week:
                    return "1week";
                case Interval._1Month:
                    return "1month";
                default:
                    throw new ArgumentException("Unsupported interval");
                }
        }
    }
}
