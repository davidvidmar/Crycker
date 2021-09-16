using CryptoTray.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Timers;

namespace CryptoTray.Data
{
    public class TickerController : IDisposable
    {
        private static Timer _timer;

        private readonly NumberFormatInfo _cultureInfo;

        private readonly HttpClient _client;

        private decimal lastPrice;

        public event EventHandler<TickerEventArgs> DataUpdated = delegate { };

        public ITickerProvider Provider { get; private set; }

        public TickerController(int refreshInterval)
        {
            _cultureInfo = new CultureInfo("en-US", false).NumberFormat;
            _cultureInfo.NumberDecimalSeparator = ".";

            _client = new HttpClient();

            _timer = new Timer();
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();

            SetRefreshInterval(refreshInterval);

            UpdateData();
        }

        public void SetTicker(ITickerProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("TickerProvider");
            }
            Provider = provider;
            lastPrice = 0;
            UpdateData();
        }

        public void SetRefreshInterval(int value)
        {
            Debug.WriteLine($"Refresh interval set to {value}s");
            _timer.Interval = value * 1000;
        }

        public async void UpdateData()
        {
            if (Provider != null)
            {
                try
                {
                    var keysValues = await _client.GetFromJsonAsync<Dictionary<string, object>>(Provider.TickerUrl);
                    if (keysValues.ContainsKey(Provider.TickerKey))
                    {
                        if (decimal.TryParse(keysValues[Provider.TickerKey].ToString(), NumberStyles.Float, _cultureInfo, out decimal price))
                        {
                            DataUpdated(this, new TickerEventArgs
                            {
                                LastPrice = price,
                                PreviousPrice = lastPrice,
                                LastUpdated = DateTime.UtcNow,
                                ProviderName = Provider.TickerName
                            });
                            lastPrice = price;
                        }
                    }
                }
                catch { }
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.WriteLine($"Timer elapsed: {_timer.Interval} ms");

            UpdateData();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}