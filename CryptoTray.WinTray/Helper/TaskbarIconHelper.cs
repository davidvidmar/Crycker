using CryptoTray.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CryptoTray.Helper
{
    sealed class TaskbarIconHelper
    {
        public NotifyIcon notifyIcon;

        public bool DarkMode { get; set; }

        private readonly Font font;
        private readonly ILogger<TaskbarIconHelper> _logger;
        private readonly ApiConfiguration _configuration;

        public TaskbarIconHelper(ILogger<TaskbarIconHelper> logger, ApiConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            font = new Font(_configuration.FontName, _configuration.FontSize, _configuration.FontBold ? FontStyle.Bold : FontStyle.Regular);
            if (string.Compare(_configuration.FontName, font.Name, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                _logger.LogWarning($"Font '{_configuration.FontName}' not found, '{font.Name}' selected. Backing down to 'Tahoma'.");
                font = new Font("Tahoma", 7, FontStyle.Bold);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        private IntPtr lastIcon;

        public void SetPrice(decimal lastPrice, decimal previousPrice, DateTime lastUpdated, string providerName)
        {
            DestroyIcon(lastIcon);
            var percentChange = 0.0M;
            var brush = new SolidBrush(DarkMode ? Color.White : Color.Black);

            if (lastPrice > 0)
            {
                percentChange = (lastPrice - previousPrice) / lastPrice * 100;
                _logger.LogInformation($"Change since last: {percentChange:N2}%");
                if (percentChange != 0)
                {
                    Color priceColor = (percentChange >= 0) ? Color.Green : Color.OrangeRed;
                    brush.Dispose();
                    brush = new SolidBrush(priceColor);
                    var absolutePercent = Math.Abs(percentChange);                    
                    if (_configuration.PercentageNotification > 0 && absolutePercent > _configuration.PercentageNotification)
                        notifyIcon.ShowBalloonTip(5000, "CryptoTray", $"{(percentChange > 0 ? "rose above" : "fell under")} {absolutePercent:N2}% in the last {_configuration.RefreshInterval} seconds!", ToolTipIcon.Info);
                }
            }

            // Get the systray icon size (because of DPI)
            var size = SystemInformation.SmallIconSize;
            using (var bitmap = new Bitmap(size.Width, size.Height))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                string line1;
                string line2;

                if (lastPrice == 0)
                {
                    line1 = "?";
                    line2 = "";
                }
                else if (lastPrice < 1)
                {
                    var s = lastPrice.ToString("F3").Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                    line1 = s[0];
                    line2 = s[1];
                }
                else if (lastPrice >= 1000)
                {
                    var s = lastPrice.ToString("F0");
                    if (s.Length > 5) s = s.Substring(0, 6);
                    line1 = s.Substring(0, s.Length - 3) + "k";
                    line2 = s.Substring(s.Length - 3, 3);
                }
                else
                {
                    var s = lastPrice.ToString("F2").Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                    line1 = s[0];
                    line2 = s[1];
                }

                var m = graphics.MeasureString(line1, font);
                var w2 = (int)Math.Round(m.Width / 2);
                var h2 = (int)Math.Round(m.Height / 2);
                graphics.DrawString(line1, font, brush, bitmap.Size.Width / 2 - w2, -3 + bitmap.Size.Height / 2 - h2);

                m = graphics.MeasureString(line2, font);
                w2 = (int)Math.Round(m.Width / 2);
                h2 = (int)Math.Round(m.Height / 2);
                graphics.DrawString(line2, font, brush, bitmap.Size.Width / 2 - w2, 5 + bitmap.Size.Height / 2 - h2);

                lastIcon = bitmap.GetHicon();
                var icon = Icon.FromHandle(lastIcon);
                notifyIcon.Icon = icon;                
            }
            brush.Dispose();
            notifyIcon.Text = $"{providerName} - {lastPrice} ({percentChange:N2}%) @ {lastUpdated.ToLongTimeString()}";
        }        
    }
}
