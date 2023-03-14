using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace TestApp.MVC.Hubs
{

    public class Stock
    {
        private decimal _price;

        public static Stock Instance { get; internal set; }
        public string Symbol { get; set; }

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price == value)
                {
                    return;
                }

                _price = value;

                if (DayOpen == 0)
                {
                    DayOpen = _price;
                }
            }
        }

        public decimal DayOpen { get; private set; }

        public decimal Change
        {
            get
            {
                return Price - DayOpen;
            }
        }

        public double PercentChange
        {
            get
            {
                return (double)Math.Round(Change / Price, 4);
            }
        }

        internal IEnumerable<Stock> GetAllStocks()
        {
            throw new NotImplementedException();
        }
    }
}