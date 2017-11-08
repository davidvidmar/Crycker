using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Cricker.Helper;

namespace Cricker.Data
{
    class CoinbaseTickerProvider : BaseTickerProvider, ITickerProvider
    {
        public CoinbaseTickerProvider(string coin, string currency)
        {
            supportedCurrencies = new string[] { "EUR", "USD" };
            supportedCoins = new string[] { "BTC", "LTH", "ETH" };

            Coin = coin;
            Currency = currency;
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
                Logger.Error("Error updating data.", ex);
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
