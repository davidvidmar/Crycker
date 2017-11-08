using Crycker.Helper;
using Crycker.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Crycker.Controls
{
    public partial class ContextMenuControl : UserControl
    {
        public ContextMenuControl()
        {
            InitializeComponent();
        }

        public event EventHandler OpenUrlClicked = delegate { };

        public event EventHandler<StringEventArgs> ProviderChanged = delegate { };
        public event EventHandler<StringEventArgs> CoinChanged = delegate { };
        public event EventHandler<StringEventArgs> CurrencyChanged = delegate { };
        
        public event EventHandler<IntEventArgs> RefreshIntervalChanged = delegate { };

        public event EventHandler AutorunChanged = delegate { };
        public event EventHandler ExitClicked = delegate { };

        private void RefreshIntervalClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            var value = Convert.ToInt32(menu.Tag);
            Logger.Info($"Refresh Interval menu clicked -> {value}");
            
            RefreshIntervalChanged(sender, new IntEventArgs(value));
        }

        private void CoinClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;            
            UncheckOtherToolStripMenuItems(menu);

            string value = (string)menu.Tag;
            Logger.Info($"Coin menu clicked -> {value}");

            CoinChanged(sender, new StringEventArgs(value));
        }

        private void CurrencyClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;            

            UncheckOtherToolStripMenuItems(menu);

            string value = (string)menu.Tag;
            Logger.Info($"Currency menu clicked -> {value}");

            CurrencyChanged(sender, new StringEventArgs(value));
        }

        private void ProviderClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            string value = (string)menu.Tag;
            Logger.Info($"Provider menu clicked -> {value}");

            ProviderChanged(sender, new StringEventArgs(value));
        }

        private void AutorunClick(object sender, EventArgs e)
        {
            AutorunChanged(sender, e);
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Logger.Info($"Exit menu clicked");
            ExitClicked(sender, e);
        }

        private void clickToOpenWebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Info($"Open URL menu clicked");
            OpenUrlClicked(sender, e);
        }

        public void SetProvider(string value)
        {
            SelectDropDownItem(providerToolStripMenuItem, value);
        }

        internal void SetValidCoins(string[] supportedCoins)
        {
            var list = new List<string>(supportedCoins);
            foreach (ToolStripMenuItem item in coinToolStripMenuItem.DropDownItems)
            {
                item.Enabled = list.Contains(item.Tag);
            }
        }

        internal void SetValidCurrencies(string[] supportedCurrencies)
        {
            var list = new List<string>(supportedCurrencies);
            foreach (ToolStripMenuItem item in currencyToolStripMenuItem.DropDownItems)
            {
                item.Enabled = list.Contains(item.Tag);
            }
        }

        public void SetCoin(string value)
        {
            SelectDropDownItem(coinToolStripMenuItem, value);
        }

        public void SetCurrency(string value)
        {
            SelectDropDownItem(currencyToolStripMenuItem, value);
        }

        public void SetRefreshInterval(int value)
        {
            SelectDropDownItem(refreshIntervalToolStripMenuItem, value.ToString());
        }

        internal void SetAutorun(bool value)
        {
            autoRunToolStripMenuItem.Checked = value;
        }

        private void SelectDropDownItem(ToolStripMenuItem toolStripMenuItem, string tagValue)
        {
            foreach (ToolStripMenuItem item in toolStripMenuItem.DropDownItems)
            {
                item.Checked = item.Tag.ToString() == tagValue;
            }            
        }       

        private void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;

            // Select the other MenuItens from the ParentMenu(OwnerItens) and unchecked this,
            // The current Linq Expression verify if the item is a real ToolStripMenuItem
            // and if the item is a another ToolStripMenuItem to uncheck this.
            foreach (var ltoolStripMenuItem in (from object item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }        
    }
}
