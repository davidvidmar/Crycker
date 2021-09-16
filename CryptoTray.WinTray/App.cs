using CryptoTray.Controls;
using CryptoTray.Data;
using CryptoTray.Helper;
using CryptoTray.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CryptoTray
{
    class App : ApplicationContext
    {
        private NotifyIcon TrayIcon;
        private TickerController tickerController;
        private readonly ContextMenuControl _contextMenuControl;
        private readonly ApiConfiguration _apiConfiguration;
        private readonly ILogger<App> _logger;
        private readonly TaskbarIconHelper _taskbar;

        private DateTime lastUpdateCheck;

        public App(ILogger<App> logger, ApiConfiguration configuration, TaskbarIconHelper taskbar, ContextMenuControl menuControl)
        {
            _logger = logger;
            _logger.LogInformation("App starting...");

            _apiConfiguration = configuration;

            _contextMenuControl = menuControl;

            _taskbar = taskbar;

            tickerController = new TickerController(_apiConfiguration.RefreshInterval);
            tickerController.DataUpdated += DataUpdated;

            tickerController.SetTicker(_apiConfiguration.SelectedApi);
            InitializeComponent();
        }

        private async void DataUpdated(object sender, TickerEventArgs e)
        {
            _taskbar.SetPrice(e.LastPrice, e.PreviousPrice, e.LastUpdated, e.ProviderName);

            await CheckForUpdates();
        }

        private async System.Threading.Tasks.Task CheckForUpdates()
        {
            if (!_apiConfiguration.CheckForUpdates) return;

            if (DateTime.Now.Subtract(lastUpdateCheck).Days > 1)
            {
                _logger.LogInformation("Checking for updates.");
                try
                {
                    var updateCheck = new UpdateCheckHelper("davidvidmar", "CryptoTray");
                    var updateAvailable = await updateCheck.UpdateAvailable();

                    if (!string.IsNullOrEmpty(updateAvailable))
                    {
                        _logger.LogInformation($"Update is available: {updateAvailable}");
                        _contextMenuControl.SetNewVersionAvailable(updateAvailable, updateCheck.LatestVersionUrl);
                    }
                    lastUpdateCheck = DateTime.Now;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Update check failed: {ex.Message}");
                }
            }
        }

        private void InitializeComponent()
        {
            Application.ApplicationExit += Application_ApplicationExit;

            // init Event fired from Context Menu
            _contextMenuControl.NewVersionAvailableClicked += ContextMenuControl_NewVersionAvailableClicked;
            _contextMenuControl.TickerChanged += ContextMenuControl_TickerChanged;
            _contextMenuControl.RefreshIntervalChanged += ContextMenuControl_RefreshIntervalChanged;
            _contextMenuControl.PercentageNotificationChanged += ContextMenuControl_PercentageNotificationChanged;
            _contextMenuControl.DarkModeChanged += ContextMenuControl_DarkModeChanged;
            _contextMenuControl.AutorunChanged += ContextMenuControl_AutorunChanged;
            _contextMenuControl.ExitClicked += ContextMenuControl_ExitClicked;

            // Init Tray Icon
            TrayIcon = new NotifyIcon
            {
                ContextMenuStrip = _contextMenuControl.ContextMenuStrip
            };
            
            _taskbar.notifyIcon = TrayIcon;
            _taskbar.DarkMode = _apiConfiguration.DarkMode;

            TrayIcon.Click += TrayIcon_Click;

            TrayIcon.Visible = true;
        }

        private void ContextMenuControl_TickerChanged(object sender, ProviderEventArgs e)
        {
            if (e.Provider == null)
            {
                return;
            }
            _apiConfiguration.SelectedApi = e.Provider as TickerProvider;
            _apiConfiguration.SaveConfiguration();
            tickerController.SetTicker(e.Provider);
        }

        private void ContextMenuControl_NewVersionAvailableClicked(object sender, StringEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Value);
        }

        private void ContextMenuControl_RefreshIntervalChanged(object sender, IntEventArgs e)
        {
            tickerController.SetRefreshInterval(e.Value);
            tickerController.UpdateData();

            _apiConfiguration.RefreshInterval = e.Value;
            _apiConfiguration.SaveConfiguration();
        }

        private void ContextMenuControl_PercentageNotificationChanged(object sender, IntEventArgs e)
        {
            _apiConfiguration.PercentageNotification= e.Value;
            _apiConfiguration.SaveConfiguration();
        }

        private void ContextMenuControl_DarkModeChanged(object sender, EventArgs e)
        {
            _apiConfiguration.DarkMode = !_apiConfiguration.DarkMode;
            _apiConfiguration.SaveConfiguration();

            _contextMenuControl.SetDarkMode(_apiConfiguration.DarkMode);
            _taskbar.DarkMode = _apiConfiguration.DarkMode;

            tickerController.UpdateData();
        }

        private void ContextMenuControl_AutorunChanged(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            if (AutoRunHelper.Get())
            {
                AutoRunHelper.Clear();
                menu.Checked = false;
            }
            else
            {
                AutoRunHelper.Set();
                menu.Checked = true;
            }
        }

        private void ContextMenuControl_ExitClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "CryptoTray",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {            
            TrayIcon.Visible = false;
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            // TODO - show chart
        }
    }

}