using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cricker.Data
{
    interface ITickerProvider
    {
        string Provider { get; }
        string Coin { get; set; }
        string Currency { get; set; }
        decimal LastPrice { get; set; }

        DateTime LastUpdated { get; set; }

        string[] SupportedCurrencies { get; }
        string[] SupportedCoins { get; }

        Task UpdateData();        
    }
}
