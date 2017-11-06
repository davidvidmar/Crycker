using System;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Cricker.Data;
using Cricker.Helper;

namespace Cricker.Data
{
    public class BitstampTicker : ITickerProvider
    {
        private static string[] supportedCurrencies = new string[] { "EUR", "USD" };
        private static string[] supportedCoins = new string[] { "BTC" };

        private string _coin = "BTC";
        private string _currency = "EUR";

        public DateTime LastUpdated { get; set; }
        public decimal LastPrice { get; set; }

        private string ServiceUrl
        {
            get {
                return $"https://www.bitstamp.net/api/v2/ticker/{_coin}{_currency}/";
            }
        }

        public BitstampTicker()
        {

        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                var currencyValue = value.ToUpper();

                if (supportedCurrencies.Contains(currencyValue))
                {
                    _currency = currencyValue;
                }
                else
                {
                    _currency = supportedCurrencies[0];
                }
            }
        }

        public string Coin
        {
            get { return _coin; }
            set
            {
                var coinValue = value.ToUpper();

                if (!supportedCoins.Contains(coinValue))
                    throw new NotSupportedException($"Coin {coinValue} not supported.");

                _currency = coinValue;
            }
        }

        public string Provider {
            get { return "Bitstamp"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Bitstamp.");

            try
            {
                var client = new HttpClient();
                var jsonResult = await client.GetStringAsync(ServiceUrl);
                var tickerData = JsonConvert.DeserializeObject<BitstampTickerData>(jsonResult);

                LastUpdated = DateTime.Now;
                LastPrice = tickerData.last;

                Logger.Info($"Bitstamp said {this.Coin} = {tickerData.last} {this.Currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

    }

    public class BitstampTickerData
    {
        public decimal high { get; set; }
        public decimal last { get; set; }
        public string timestamp { get; set; }
        public decimal bid { get; set; }
        public string vwap { get; set; }
        public decimal volume { get; set; }
        public decimal low { get; set; }
        public decimal ask { get; set; }
        public decimal open { get; set; }
    }
}
