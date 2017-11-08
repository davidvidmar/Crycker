using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Crycker.Helper
{
    static class TaskbarIconHelper
    {
        public static NotifyIcon notifyIcon;

        static TaskbarIconHelper()
        {

        }

        public static void SetPrice(decimal lastPrice, decimal previousPrice, string coin, string currency, string provider, DateTime lastUpdated)
        {
            var percentChange = 0.0M;
            var brush = new SolidBrush(Color.White); ;

            if (lastPrice > 0)
            {
                percentChange = (lastPrice - previousPrice) / lastPrice * 100;
                Logger.Info($"Change since last: {percentChange:N2}%");
                if (percentChange != 0)
                {
                    Color priceColor = (percentChange >= 0) ? Color.Green : Color.OrangeRed;
                    brush = new SolidBrush(priceColor);
                }
            }

            var bitmap = new Bitmap(16, 16);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font("Segoe UI", 7);

            string line1;
            string line2;

            if (lastPrice == 0)
            {
                line1 = "";
                line2 = "";
            } else if (lastPrice < 1)
            {                
                var s = lastPrice.ToString("F3").Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                line1 = s[0];
                line2 = s[1];
            } else if (lastPrice > 1000)
            {
                var s = lastPrice.ToString("F0");
                if (s.Length > 5) s = s.Substring(0, 6);
                line1 = s.Substring(0, s.Length / 2);
                line2 = s.Substring(s.Length / 2);
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

            graphics.DrawString(line1, font, brush, bitmap.Size.Width / 2 - w2, -4 + bitmap.Size.Width / 2 - h2);

            m = graphics.MeasureString(line2, font);
            w2 = (int)Math.Round(m.Width / 2);
            h2 = (int)Math.Round(m.Height / 2);
            graphics.DrawString(line2, font, brush, bitmap.Size.Width / 2 - w2, 4 + bitmap.Size.Width / 2 - h2);

            var hIcon = bitmap.GetHicon();
            var icon = Icon.FromHandle(hIcon);
            notifyIcon.Icon = icon;

            notifyIcon.Text = $"{provider} {coin}/{currency}: {lastPrice} ({percentChange:N2}%) @ {lastUpdated.ToLongTimeString()}";
        }        
    }
}