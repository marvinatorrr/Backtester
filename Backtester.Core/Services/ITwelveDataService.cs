
using Backtester.Core.Services;

namespace Backtester.Core
{
    public interface ITwelveDataService
    {
        Task<TwelveDataResponse> GetData(string symbol, DateTime startDateTime, int size, Interval interval);
        Task<TwelveDataResponse> GetData(string symbol, DateTime startDateTime, DateTime endDateTime, Interval interval);
    }
}
