using CryptoTray.Data;
using System;

namespace CryptoTray.Types
{
    public class ProviderEventArgs : EventArgs
    {
        public ITickerProvider Provider { get; }

        public ProviderEventArgs(ITickerProvider provider)
        {
            Provider = provider;
        }
    }
}
