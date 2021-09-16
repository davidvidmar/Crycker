using System;

namespace CryptoTray.Types
{
    public class TickerEventArgs : EventArgs
    {
        public DateTime LastUpdated { get; set; }
        public decimal LastPrice { get; set; }
        public decimal PreviousPrice { get; set; }
        public string ProviderName { get; set; }
    }
}