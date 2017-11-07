using System;
using System.Collections.Generic;

namespace Cricker.Data
{
    public class BaseTickerProvider
    {
        protected List<string> supportedCurrencies;
        protected List<string> supportedCoins;

        protected string _coin;
        protected string _currency;

        public DateTime LastUpdated { get; set; }
        public decimal LastPrice { get; set; }

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
    }
}
