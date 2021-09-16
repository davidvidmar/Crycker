using System.Collections.Generic;

namespace CryptoTray.Data
{
    public class ApiConfiguration
    {
        public int RefreshInterval { get; set; }
        public int PercentageNotification { get; set; }
        public bool DarkMode { get; set; }
        public bool CheckForUpdates { get; set; }
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public bool FontBold { get; set; }
        public bool LogEnabled { get; set; }
        public TickerProvider SelectedApi { get; set; }
        public IList<ApiEntry> ApiEntries { get; set; }
    }

    public class ApiEntry
    {
        public string Name { get; set; }
        public string ApiUrl { get; set; }
        public string Key { get; set; }
        public List<Ticker> Tickers { get; set; }
    }

    public class Ticker
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
