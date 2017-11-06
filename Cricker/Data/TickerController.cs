using System;
using System.Timers;
using Cricker.Helper;
using Cricker.Types;

namespace Cricker.Data
{
    public class TickerController
    {
        private static ITickerProvider _ticker;
        private static Timer _timer;

        decimal lastPrice;        

        public event EventHandler<TickerEventArgs> DataUpdated = delegate { };

        public void SetCurrency(string currency)
        {
            if (_ticker.Currency == currency)
                return;

            _ticker.Currency = currency;

            if (_ticker.Currency == currency) 
                Logger.Info($"Currency set to {currency}.");
            else
                Logger.Error($"Currency {currency} not supported.");

            lastPrice = 0;
        }

        public void SetRefreshInterval(int value)
        {
            Logger.Info($"Refresh interval set to {value} s");
            _timer.Interval = value * 1000;            
        }

        public TickerController(string provider, string coin, string currency, int refreshInterval)
        {
            Logger.Info($"Controller initialized: {provider} - {coin} {currency}");

            _ticker = new BitstampTicker
            {
                Coin = coin,
                Currency = currency
            };            

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
