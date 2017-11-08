using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Crycker.Data
{
    public class BaseTickerProvider
    {
        protected string[] supportedCurrencies;
        public string[] SupportedCurrencies
        {
            get
            {
                return supportedCurrencies;
            }
            private set
            {
                supportedCurrencies = value;
            }
        }

        protected string[] supportedCoins;
        public string[] SupportedCoins
        {
            get
            {
                return supportedCoins;
            }
            private set
            {
                supportedCoins = value;
            }
        }

        public DateTime LastUpdated { get; set; }
        public decimal LastPrice { get; set; }

        protected string _coin;
        protected string _currency;
        
        public string Currency
        {
            get { return _currency; }
            set
            {
                if (value == null)
                    return;

                var currencyValue = value.ToUpper();

                if (new List<string>(supportedCurrencies).Contains(currencyValue))
                {
                    _currency = currencyValue;
                }
                else
                {
                    throw new NotSupportedException($"Currency {currencyValue} not supported.");                    
                }
            }
        }

        public string Coin
        {
            get { return _coin; }
            set
            {
                if (value == null)
                    return;

                var coinValue = value.ToUpper();

                if (new List<string>(supportedCoins).Contains(coinValue))
                {
                    _coin = coinValue;
                }
                else
                {
                    throw new NotSupportedException($"Coin {coinValue} not supported.");
                }                              
            }
        }

        protected async Task<string> CallRestApi(string baseUrl)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(baseUrl);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        protected T ParseJsonResult<T>(string jsonData) where T : new()
        {
            var data = new T();
            var serializer = new DataContractJsonSerializer(data.GetType());
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
            var tickerData = (T)serializer.ReadObject(ms);
            ms.Close();
            return tickerData;
        }
    }
}