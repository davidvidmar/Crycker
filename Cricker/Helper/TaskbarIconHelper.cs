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

            //if (percentChanged >= Properties.Settings.Default.NotifyPercentageValue || percentChanged <= -Properties.Settings.Default.NotifyPercentageValue)
            //{
            //    trayIcon.ShowBalloonTip(Math.Round(percentChanged, 2).ToString() + " %", "Old price: " + oldPrice.Last.ToString() + " " + oldPrice.Symbol + ", New price: " + price.Last.ToString() + " " + price.Symbol, BalloonIcon.Info);
            //}
            
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

        public static void HideIcon()
        {
            if (notifyIcon != null && notifyIcon.Visible)
                notifyIcon.Visible = false;
        }

        //public static void updateTrayText(string textTray, string textTooltip)
        //{
        //    Brush brush = new SolidBrush(Color.White);

        //    // Create a bitmap and draw text on it
        //    Bitmap bitmap = new Bitmap(16, 16);
        //    Graphics graphics = Graphics.FromImage(bitmap);

        //    Font myfont = new Font("Verdana", 7);

        //    graphics.DrawString(textTray, myfont, brush, 0, 3);

        //    // Convert the bitmap with text to an Icon
        //    IntPtr hIcon = bitmap.GetHicon();
        //    Icon icon = Icon.FromHandle(hIcon);

        //    TaskbarIcon trayIcon = (TaskbarIcon)Application.Current.FindResource("myTaskbarIcon");

        //    trayIcon.Icon = icon;
        //    trayIcon.ToolTipText = textTooltip;
        //}

        private static void SetText(decimal price, string currency)
        {            
            var myColor = Color.Green;
            //var history = CurrencyData.getSecondToLast(Properties.Settings.Default.SelectedCurrency);
            /*
            if (history != null)
            {
                var oldPrice = history.Prices.SingleOrDefault(x => x.Key == Properties.Settings.Default.SelectedCurrency).Value;
                var percentChanged = CalculateChange(oldPrice.Last, price.Last);

                if (percentChanged > 0)
                {
                    myColor = Color.Green;
                }
                else if (percentChanged < 0)
                {
                    myColor = Color.Red;
                }                
               
                if (percentChanged >= Properties.Settings.Default.NotifyPercentageValue || percentChanged <= -Properties.Settings.Default.NotifyPercentageValue)
                {
                    trayIcon.ShowBalloonTip(Math.Round(percentChanged, 2).ToString() + " %", "Old price: " + oldPrice.Last.ToString() + " " + oldPrice.Symbol + ", New price: " + price.Last.ToString() + " " + price.Symbol, BalloonIcon.Info);                    
                }                              
            }
            */
            var brush = new SolidBrush(myColor);

            var bitmap = new Bitmap(16, 16);
            var graphics = Graphics.FromImage(bitmap);

            int charCount = Math.Round(price, 0).ToString().Length;

            Font myfont = null;
            if (charCount >= 4)
            {
                myfont = new Font("Segoe UI", 5);
            }
            if (charCount == 3)
            {
                myfont = new Font("Segoe UI", 6);
            }
            if (charCount == 2)
            {
                myfont = new Font("Segoe UI", 7);
            }

            graphics.DrawString(Math.Round(price, 0).ToString(), myfont, brush, 0, 3);

            // Convert the bitmap with text to an Icon
            var hIcon = bitmap.GetHicon();
            var icon = Icon.FromHandle(hIcon);

            //Application.Current.Dispatcher.Invoke(new Action(() =>
            //{
                notifyIcon.Icon = icon;
                //notifyIcon.Noti= price + " " + currency;
            //}));
        }
    }
}