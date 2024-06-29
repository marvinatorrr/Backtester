using Backtester.Core.Models;

namespace Backtester.Core
{
    public class TwelveDataResponse
    {
        public MetaData Meta { get; set; }
        public List<StockValue> Values { get; set; }
        public string Status { get; set; }
    }
}
