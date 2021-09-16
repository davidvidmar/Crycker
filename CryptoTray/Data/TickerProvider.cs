namespace CryptoTray.Data
{
    public class TickerProvider : ITickerProvider
    {
        public string TickerName { get; set; }

        public string TickerUrl { get; set; }

        public string TickerKey { get; set; }
    }
}
