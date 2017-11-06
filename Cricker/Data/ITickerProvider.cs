using System;
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
        
        Task UpdateData();        
    }
}
