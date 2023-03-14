using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace TestApp.MVC.Hubs
{
    [HubName("stockTickerMini")]
    public class StockHub : Hub
    {
        private readonly Stock _stockTicker;

        public StockHub() : this(Stock.Instance) { }

        public StockHub(Stock stock)
        {
            _stockTicker = stock;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockTicker.GetAllStocks();
        }
    }
}
