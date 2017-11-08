using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Crycker.Helper;

namespace Crycker.Data
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
                var result = await CallRestApi(BaseUrl);
                var tickerData = ParseJsonResult<BitstampTickerData>(result);

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

    [DataContract]
    internal class BitstampTickerData
    {
        [DataMember]
        public decimal high { get; set; }
        [DataMember]
        public decimal last { get; set; }
        [DataMember]
        public string timestamp { get; set; }
        [DataMember]
        public decimal bid { get; set; }
        [DataMember]
        public string vwap { get; set; }
        [DataMember]
        public decimal volume { get; set; }
        [DataMember]
        public decimal low { get; set; }
        [DataMember]
        public decimal ask { get; set; }
        [DataMember]
        public decimal open { get; set; }
    }
}
