using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Cricker.Helper;

namespace Cricker.Data
{
    class CoinbaseTicker : BaseTickerProvider, ITickerProvider
    {
        public CoinbaseTicker()
        {
            supportedCurrencies = new List<string>(new string[] { "EUR", "USD" });
            supportedCoins = new List<string>(new string[] { "BTC" });

            _currency = supportedCurrencies[0];
            _coin = supportedCoins[0];
        }

        public string Provider
        {
            get { return "Coinbase"; }
        }

        protected string BaseUrl
        {
            get { return $"https://api.coinbase.com/v2/prices/{_coin}-{_currency}/spot"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Coinbase.");

            try
            {
                var client = new HttpClient();
                var jsonResult = await client.GetStringAsync(BaseUrl);
                var tickerData = JsonConvert.DeserializeObject<CoinbaseTickerData>(jsonResult);

                LastUpdated = DateTime.Now;
                LastPrice = tickerData.data.amount;

                Logger.Info($"Coinbase said {this.Coin} = {tickerData.data.amount} {tickerData.data.currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }

    public class Data
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class CoinbaseTickerData
    {
        public Data data { get; set; }
    }
}
