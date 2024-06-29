namespace Backtester.Core
{
    public interface ITwelveDataService
    {
        Task<TwelveDataResponse> GetData();
    }
}
