using CryptoTray.Data;
using CryptoTray.Helper;
using CryptoTray.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CryptoTray.Controls
{
    public partial class ContextMenuControl : UserControl
    {
        private readonly ILogger<ContextMenuControl> _logger;

        public ContextMenuControl(ILogger<ContextMenuControl> logger, ApiConfiguration configuration)
        {
            _logger = logger;
            InitializeComponent();
            ConfigureControl(configuration);
        }

        private void ConfigureControl(ApiConfiguration configuration)
        {
            // init Context Menu
            SetRefreshInterval(configuration.RefreshInterval);
            SetPercentageNotification(configuration.PercentageNotification);
            SetDarkMode(configuration.DarkMode);
            SetAutorun(AutoRunHelper.Get());
            SetCurrentVersion();

            FillAvailableTickers(configuration);
        }

        public event EventHandler OpenUrlClicked = delegate { };
        public event EventHandler<StringEventArgs> NewVersionAvailableClicked = delegate { };

        public event EventHandler<ProviderEventArgs> TickerChanged = delegate { };

        public event EventHandler<IntEventArgs> RefreshIntervalChanged = delegate { };
        public event EventHandler<IntEventArgs> PercentageNotificationChanged = delegate { };

        public event EventHandler AutorunChanged = delegate { };
        public event EventHandler DarkModeChanged = delegate { };
        public event EventHandler ExitClicked = delegate { };

        private void newVersionIsAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            _logger.LogInformation($"New version available clicked ({menu.Tag})");
            NewVersionAvailableClicked(sender, new StringEventArgs((string)menu.Tag));
        }

        private void RefreshIntervalClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            var value = Convert.ToInt32(menu.Tag);
            _logger.LogInformation($"Refresh Interval menu clicked -> {value}");

            RefreshIntervalChanged(sender, new IntEventArgs(value));
        }

        private void PercentageNotificationClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            var value = Convert.ToInt32(menu.Tag);
            _logger.LogInformation($"Percentage notification menu clicked -> {value}");

            PercentageNotificationChanged(sender, new IntEventArgs(value));
        }

        internal void SetCurrentVersion()
        {
            var updateCheck = new UpdateCheckHelper("davidvidmar", "CryptoTray");
            var version = updateCheck.GetCurrentVersion();
            var versionString =
                $"v{version.Major}.{version.Minor}" +
                (version.Build > 0 ? "." + version.Build + (version.Revision > 0 ? "." + version.Revision : "") : "");
            versionToolStripMenuItem.Text = $"CryptoTray {versionString}";
        }

        private void AutorunClick(object sender, EventArgs e)
        {
            _logger.LogInformation($"Autorun menu clicked");
            AutorunChanged(sender, e);
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.LogInformation($"Dark mode menu clicked");
            DarkModeChanged(sender, e);
        }

        private void ExitClick(object sender, EventArgs e)
        {
            _logger.LogInformation($"Exit menu clicked");
            ExitClicked(sender, e);
        }

        private void clickToOpenWebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.LogInformation($"Open URL menu clicked");
            OpenUrlClicked(sender, e);
        }

        public void SetNewVersionAvailable(string version, string url)
        {
            _logger.LogInformation($"New version {version} is available at {url}");
            newVersionIsAvailableToolStripMenuItem.Text = $"Hey, lucky you! New version is available: v{version}";
            newVersionIsAvailableToolStripMenuItem.Tag = url;
            newVersionIsAvailableToolStripMenuItem.Visible = true;
        }

        internal void FillAvailableTickers(ApiConfiguration configuration)
        {
            foreach (ApiEntry entry in configuration.ApiEntries)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem(entry.Name);
                foreach (Ticker ticker in entry.Tickers)
                {
                    ToolStripMenuItem subTsi = new ToolStripMenuItem(ticker.Name);
                    ITickerProvider provider = new TickerProvider
                    {
                        TickerName = $"{entry.Name} {ticker.Name}",
                        TickerUrl = string.Format(entry.ApiUrl, ticker.Code),
                        TickerKey = entry.Key
                    };
                    subTsi.Tag = provider;
                    subTsi.Click += SetTicker_Click;
                    tsi.DropDownItems.Add(subTsi);
                }
                providerToolStripMenuItem.DropDownItems.Add(tsi);
            }
        }

        private void SetTicker_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if (menuItem.Tag is ITickerProvider provider)
                {
                    TickerChanged(sender, new ProviderEventArgs(provider));
                }
            }
        }

        public void SetRefreshInterval(int value)
        {
            SelectDropDownItem(refreshIntervalToolStripMenuItem, value.ToString());
        }

        public void SetPercentageNotification(int value)
        {
            SelectDropDownItem(priceChangeNotificationToolStripMenuItem, value.ToString());
        }

        internal void SetDarkMode(bool value)
        {
            darkModeToolStripMenuItem.Checked = value;
        }

        internal void SetAutorun(bool value)
        {
            autoRunToolStripMenuItem.Checked = value;
        }

        private void SelectDropDownItem(ToolStripMenuItem toolStripMenuItem, string tagValue)
        {
            foreach (var item in toolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
            {
                item.Checked = item.Tag?.ToString() == tagValue;
            }
        }

        private void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;
            // Select the other MenuItens from the ParentMenu(OwnerItens) and unchecked this,
            // The current Linq Expression verify if the item is a real ToolStripMenuItem
            // and if the item is a another ToolStripMenuItem to uncheck this.  
            // It only looks for items inside the same separator zone.
            ToolStripSeparator separator1 = null, separator2 = null;
            bool itemFound = false;
            foreach (ToolStripItem item in selectedMenuItem.Owner.Items)
                if (item is ToolStripSeparator sep)
                    if (itemFound)
                    {
                        separator2 = sep;
                        break;
                    }
                    else
                        separator1 = sep;
                else if (item == selectedMenuItem)
                    itemFound = true;

            var e = selectedMenuItem.Owner.Items.GetEnumerator();
            while (e.MoveNext())
                if (separator1 == null || separator1 == e.Current && e.MoveNext())
                    do
                    {
                        if (e.Current == separator2)
                            return;

                        if (e.Current != selectedMenuItem)
                            ((ToolStripMenuItem)e.Current).Checked = false;
                    } while (e.MoveNext());
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vidmar.net/CryptoTray");
        }
    }
}
