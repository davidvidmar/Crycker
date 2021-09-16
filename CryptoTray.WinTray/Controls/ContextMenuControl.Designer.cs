namespace CryptoTray.Controls
{
    partial class ContextMenuControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newVersionIsAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickToOpenWebPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.providerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconsLookAndFeelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceChangeNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._1perctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._3perctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._5perctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._10perctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autoRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.newVersionIsAvailableToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.clickToOpenWebPageToolStripMenuItem,
            this.toolStripMenuItem2,
            this.providerToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshIntervalToolStripMenuItem,
            this.iconsLookAndFeelToolStripMenuItem,
            this.priceChangeNotificationToolStripMenuItem,
            this.toolStripSeparator1,
            this.autoRunToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip";
            this.contextMenu.Size = new System.Drawing.Size(295, 296);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Enabled = false;
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.versionToolStripMenuItem.Text = "CryptoTray **version**";
            // 
            // newVersionIsAvailableToolStripMenuItem
            // 
            this.newVersionIsAvailableToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newVersionIsAvailableToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.newVersionIsAvailableToolStripMenuItem.Name = "newVersionIsAvailableToolStripMenuItem";
            this.newVersionIsAvailableToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.newVersionIsAvailableToolStripMenuItem.Text = "Newer version is available! (??)";
            this.newVersionIsAvailableToolStripMenuItem.Visible = false;
            this.newVersionIsAvailableToolStripMenuItem.Click += new System.EventHandler(this.newVersionIsAvailableToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.donateToolStripMenuItem.Text = "Home page and donation link";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // clickToOpenWebPageToolStripMenuItem
            // 
            this.clickToOpenWebPageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clickToOpenWebPageToolStripMenuItem.Name = "clickToOpenWebPageToolStripMenuItem";
            this.clickToOpenWebPageToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.clickToOpenWebPageToolStripMenuItem.Text = "Open ticker web page";
            this.clickToOpenWebPageToolStripMenuItem.Click += new System.EventHandler(this.clickToOpenWebPageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(291, 6);
            // 
            // providerToolStripMenuItem
            // 
            this.providerToolStripMenuItem.Name = "providerToolStripMenuItem";
            this.providerToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.providerToolStripMenuItem.Text = "&Provider";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(291, 6);
            // 
            // refreshIntervalToolStripMenuItem
            // 
            this.refreshIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secToolStripMenuItem,
            this.minToolStripMenuItem,
            this.minToolStripMenuItem1,
            this.minToolStripMenuItem2,
            this.minToolStripMenuItem3,
            this.minToolStripMenuItem4,
            this.hToolStripMenuItem});
            this.refreshIntervalToolStripMenuItem.Name = "refreshIntervalToolStripMenuItem";
            this.refreshIntervalToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.refreshIntervalToolStripMenuItem.Text = "Refresh &Interval";
            // 
            // secToolStripMenuItem
            // 
            this.secToolStripMenuItem.Name = "secToolStripMenuItem";
            this.secToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.secToolStripMenuItem.Tag = "15";
            this.secToolStripMenuItem.Text = "15 sec";
            this.secToolStripMenuItem.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // minToolStripMenuItem
            // 
            this.minToolStripMenuItem.Name = "minToolStripMenuItem";
            this.minToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.minToolStripMenuItem.Tag = "60";
            this.minToolStripMenuItem.Text = "1 min";
            this.minToolStripMenuItem.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // minToolStripMenuItem1
            // 
            this.minToolStripMenuItem1.CheckOnClick = true;
            this.minToolStripMenuItem1.Name = "minToolStripMenuItem1";
            this.minToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.minToolStripMenuItem1.Tag = "180";
            this.minToolStripMenuItem1.Text = "3 min";
            this.minToolStripMenuItem1.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // minToolStripMenuItem2
            // 
            this.minToolStripMenuItem2.CheckOnClick = true;
            this.minToolStripMenuItem2.Name = "minToolStripMenuItem2";
            this.minToolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.minToolStripMenuItem2.Tag = "300";
            this.minToolStripMenuItem2.Text = "5 min";
            this.minToolStripMenuItem2.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // minToolStripMenuItem3
            // 
            this.minToolStripMenuItem3.CheckOnClick = true;
            this.minToolStripMenuItem3.Name = "minToolStripMenuItem3";
            this.minToolStripMenuItem3.Size = new System.Drawing.Size(224, 26);
            this.minToolStripMenuItem3.Tag = "900";
            this.minToolStripMenuItem3.Text = "15 min";
            this.minToolStripMenuItem3.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // minToolStripMenuItem4
            // 
            this.minToolStripMenuItem4.CheckOnClick = true;
            this.minToolStripMenuItem4.Name = "minToolStripMenuItem4";
            this.minToolStripMenuItem4.Size = new System.Drawing.Size(224, 26);
            this.minToolStripMenuItem4.Tag = "1800";
            this.minToolStripMenuItem4.Text = "30 min";
            this.minToolStripMenuItem4.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.CheckOnClick = true;
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.hToolStripMenuItem.Tag = "3600";
            this.hToolStripMenuItem.Text = "1 h";
            this.hToolStripMenuItem.Click += new System.EventHandler(this.RefreshIntervalClick);
            // 
            // iconsLookAndFeelToolStripMenuItem
            // 
            this.iconsLookAndFeelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeToolStripMenuItem,
            this.doubleWidthToolStripMenuItem});
            this.iconsLookAndFeelToolStripMenuItem.Name = "iconsLookAndFeelToolStripMenuItem";
            this.iconsLookAndFeelToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.iconsLookAndFeelToolStripMenuItem.Text = "Look and feel";
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.darkModeToolStripMenuItem.Text = "Dark Mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // doubleWidthToolStripMenuItem
            // 
            this.doubleWidthToolStripMenuItem.Name = "doubleWidthToolStripMenuItem";
            this.doubleWidthToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.doubleWidthToolStripMenuItem.Text = "Double Width Icons";
            this.doubleWidthToolStripMenuItem.Visible = false;
            // 
            // priceChangeNotificationToolStripMenuItem
            // 
            this.priceChangeNotificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disabledToolStripMenuItem,
            this._1perctToolStripMenuItem,
            this._3perctToolStripMenuItem,
            this._5perctToolStripMenuItem,
            this._10perctToolStripMenuItem});
            this.priceChangeNotificationToolStripMenuItem.Name = "priceChangeNotificationToolStripMenuItem";
            this.priceChangeNotificationToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.priceChangeNotificationToolStripMenuItem.Text = "Price change notification";
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.disabledToolStripMenuItem.Tag = "0";
            this.disabledToolStripMenuItem.Text = "Disabled";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.PercentageNotificationClick);
            // 
            // _1perctToolStripMenuItem
            // 
            this._1perctToolStripMenuItem.Name = "_1perctToolStripMenuItem";
            this._1perctToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this._1perctToolStripMenuItem.Tag = "1";
            this._1perctToolStripMenuItem.Text = "1%";
            this._1perctToolStripMenuItem.Click += new System.EventHandler(this.PercentageNotificationClick);
            // 
            // _3perctToolStripMenuItem
            // 
            this._3perctToolStripMenuItem.Name = "_3perctToolStripMenuItem";
            this._3perctToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this._3perctToolStripMenuItem.Tag = "3";
            this._3perctToolStripMenuItem.Text = "3%";
            this._3perctToolStripMenuItem.Click += new System.EventHandler(this.PercentageNotificationClick);
            // 
            // _5perctToolStripMenuItem
            // 
            this._5perctToolStripMenuItem.Name = "_5perctToolStripMenuItem";
            this._5perctToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this._5perctToolStripMenuItem.Tag = "5";
            this._5perctToolStripMenuItem.Text = "5%";
            this._5perctToolStripMenuItem.Click += new System.EventHandler(this.PercentageNotificationClick);
            // 
            // _10perctToolStripMenuItem
            // 
            this._10perctToolStripMenuItem.Name = "_10perctToolStripMenuItem";
            this._10perctToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this._10perctToolStripMenuItem.Tag = "10";
            this._10perctToolStripMenuItem.Text = "10%";
            this._10perctToolStripMenuItem.Click += new System.EventHandler(this.PercentageNotificationClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(291, 6);
            // 
            // autoRunToolStripMenuItem
            // 
            this.autoRunToolStripMenuItem.Name = "autoRunToolStripMenuItem";
            this.autoRunToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.autoRunToolStripMenuItem.Text = "Run on Windows startup";
            this.autoRunToolStripMenuItem.Click += new System.EventHandler(this.AutorunClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(291, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitClick);
            // 
            // ContextMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ContextMenuControl";
            this.Size = new System.Drawing.Size(1201, 891);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem providerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem autoRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceChangeNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _1perctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _3perctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _5perctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _10perctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clickToOpenWebPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem iconsLookAndFeelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newVersionIsAvailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
    }
}