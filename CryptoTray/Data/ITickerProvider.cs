namespace CryptoTray.Data
{
    public interface ITickerProvider
    {
        string TickerName { get; }
        string TickerUrl { get; }
        string TickerKey { get; }
    }
}