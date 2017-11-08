using System;
using System.Collections.Generic;

namespace Cricker.Data
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

        protected string _coin;
        protected string _currency;

        public DateTime LastUpdated { get; set; }
        public decimal LastPrice { get; set; }

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
    }
}