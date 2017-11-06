using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cricker.Helper
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

            if (previousPrice > 0)
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

            var iconText = lastPrice.ToString("F0");
            if (iconText.Length < 4)
            {
                var font = new Font("Segoe UI", 9);
                graphics.DrawString(iconText, font, brush, 0, 2);
            }
            else
            {
                var font = new Font("Segoe UI", 7);
                graphics.DrawString(iconText.Substring(0, 2), font, brush, 0, -2);
                graphics.DrawString(iconText.Substring(2), font, brush, 0, 6);
            }
            
            var hIcon = bitmap.GetHicon();
            var icon = Icon.FromHandle(hIcon);
            notifyIcon.Icon = icon;

            notifyIcon.Text = $"{coin} / {currency}: {lastPrice} ({percentChange:N2}%) @ {lastUpdated.ToLongTimeString()}";
        }
        
    }

}