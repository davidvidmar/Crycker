using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Crycker.Helper;

namespace Crycker.Data
{
    public class BlockchainTickerProvider : BaseTickerProvider, ITickerProvider
    {
        public BlockchainTickerProvider(string coin, string currency)
        {
            supportedCurrencies = new string[] { "EUR", "USD" };
            supportedCoins = new string[] { "BTC" };

            Coin = coin;
            Currency = currency;
        }        

        public string Provider
        {
            get { return "Blockhain"; }
        }

        protected string BaseUrl
        {
            get { return $"https://www.blockchain.info/.../"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Blockhain.");

            try
            {
                var client = new HttpClient();
                var jsonResult = await client.GetStringAsync(BaseUrl);
                var tickerData = JsonConvert.DeserializeObject<BlockchainTickerData>(jsonResult);

                LastUpdated = DateTime.Now;
                LastPrice = tickerData.last;

                Logger.Info($"Blockhain said {this.Coin} = {tickerData.last} {this.Currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating data.", ex);
            }
        }

    }

    internal class BlockchainTickerData
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
