using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Cricker.Helper;

namespace Cricker.Data
{
    public class BitstampTickerProvider : BaseTickerProvider, ITickerProvider
    {
        public BitstampTickerProvider(string coin, string currency)
        {
            supportedCurrencies = new string[] { "EUR", "USD" };
            supportedCoins = new string[] { "BTC", "XRP", "LTC", "ETH" };

            Coin = coin;
            Currency = currency;
        }

        public string Provider
        {
            get { return "Bitstamp"; }
        }

        protected string BaseUrl
        {
            get { return $"https://www.bitstamp.net/api/v2/ticker/{_coin}{_currency}/"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Bitstamp.");

            try
            {
                var client = new HttpClient();
                var jsonResult = await client.GetStringAsync(BaseUrl);
                var tickerData = JsonConvert.DeserializeObject<BitstampTickerData>(jsonResult);

                LastUpdated = DateTime.Now;
                LastPrice = tickerData.last;

                Logger.Info($"Bitstamp said {this.Coin} = {tickerData.last} {this.Currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating data.", ex);
            }
        }

    }

    internal class BitstampTickerData
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
