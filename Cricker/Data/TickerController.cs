using System;
using System.Timers;
using Crycker.Helper;
using Crycker.Types;

namespace Crycker.Data
{
    public class TickerController
    {
        private static ITickerProvider _ticker;
        private static Timer _timer;

        private string coin;
        private string currency;

        decimal lastPrice;        

        public event EventHandler<TickerEventArgs> DataUpdated = delegate { };

        public string[] SupportedCurrencies
        {
            get { return _ticker.SupportedCurrencies; }
        }

        public string[] SupportedCoins
        {
            get { return _ticker.SupportedCoins; }
        }

        public void SetProvider(string provider)
        {
            switch (provider.ToLower())
            {
                case "bitstamp":
                    _ticker = new BitstampTickerProvider(coin, currency);                                        
                    break;
                case "blockchain":
                    _ticker = new BlockchainTickerProvider(coin, currency);
                    break;
                case "coinbase":
                    _ticker = new CoinbaseTickerProvider(coin, currency);
                    break;
                default:
                    throw new InvalidOperationException($"{provider} not supported.");
            }
        }

        public void SetCoin(string coin)
        {
            if (_ticker == null)
                return;

            if (_ticker.Coin == coin)
                return;

            _ticker.Coin = coin;

            if (_ticker.Coin == coin)
            {
                Logger.Info($"Coin set to {coin}.");
                this.coin = coin;
            }
            else
                Logger.Error($"Coin {coin} not supported.");

            //lastPrice = 0;            
        }

        public void SetCurrency(string currency)
        {
            if (_ticker == null)
                return;

            if (_ticker.Currency == currency)
                return;

            _ticker.Currency = currency;

            if (_ticker.Currency == currency)
            {
                Logger.Info($"Currency set to {currency}.");
                this.currency = currency;
            }
            else
                Logger.Error($"Currency {currency} not supported.");

            //lastPrice = 0;            
        }

        public void SetRefreshInterval(int value)
        {
            Logger.Info($"Refresh interval set to {value}s");
            _timer.Interval = value * 1000;            
        }

        public TickerController(string provider, string coin, string currency, int refreshInterval)
        {
            Logger.Info($"Controller initialized: {provider} - {coin} {currency}");

            SetProvider(provider);
            SetCoin(coin);
            SetCurrency(currency);
            
            _timer = new Timer();
            _timer.Elapsed += Timer_Elapsed;            
            _timer.Start();

            SetRefreshInterval(refreshInterval);

            UpdateData();
        }

        public async void UpdateData()
        {
            await _ticker.UpdateData();

            Logger.Info($"Data Updated: {_ticker.LastPrice} {_ticker.Currency}");

            DataUpdated(this, new TickerEventArgs() {
                Provider = _ticker.Provider,
                Coin = _ticker.Coin,
                Currency = _ticker.Currency,
                LastPrice = _ticker.LastPrice,
                PreviousPrice = lastPrice,
                LastUpdated = _ticker.LastUpdated
            });

            lastPrice = _ticker.LastPrice;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Logger.Info($"Timer elapsed: {_timer.Interval} ms");

            UpdateData();
        }
    }    
}