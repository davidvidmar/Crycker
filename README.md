# CryptoTray

![Maintenance](https://img.shields.io/maintenance/no/2021)
![GitHub Releases (by Release)](https://img.shields.io/github/downloads/xas/CryptoTray/total?logo=github)
![GitHub Releases](https://img.shields.io/github/downloads/xas/CryptoTray/latest/total?logo=github)

## Status

This is a fork from the original code of [David Vidmar](https://github.com/davidvidmar/Crycker).

I was just playing to migrate the code to .NET5 and gone too far.

I renamed the project and I am reading about MAUI to see if it is possible to generate the tray icon even for MAC and/or Linux.

## Original README

Hey, you people that are constantly checking Bitcoin and other crypto currency prices on mobile or PC during meetings. You think we don't see you? We do!

Here is a gift for you!

> CryptoTray is a super simple tool that puts crypto currency price ticker into Windows tray.

Nothing to install, no dependencies. Just a single file you put in your tools folder and run when needed. Configure to automatically start with Windows. Right click to select source, currency and coin.

Currently shows data from Bitstamp, Coinbase or Blockchain. Supports Bitcoin, Ethereum, Ripple, Lite Coin, with EUR and USD as currencies.

**Download**    - [Version 5.0](https://github.com/xas/CryptoTray/releases/latest)

**Home Page** - [Source Code](https://github.com/xas/CryptoTray/)

Have an idea? Found a bug? [submit an issue](https://github.com/xas/CryptoTray/issues)!

---

## Changelog

**v5.0.0** - 17th Sep 2021

* migrate to .net5 project type
* migrate user settings to json file type
* refactor code
* separate to a common project and to a window specific project
* available charts are listed from the json config file

**v1.1** - 5th May 2020

* get notifications for x% change
* fixes and optimizations

**v1.0.1** - 7th Oct 2017

* check for updates automatically, can be turned off in config file
* support for generic currencies, that can be set in config file
* read config file from directory where executable is, not from current working directory
* Bitstamp sometimes returns bogus answer, ignore it
* more robust logging, that could crash the app under certain conditions

---

Donation are welcome

**ETH** to "0x2F2283eEf63bdf9D00a0a0207DbEB4abD7eC0403" or use code:

![ETH donation address](https://raw.githubusercontent.com/xas/CryptoTray/master/misc/eth.png)

**BTC** to "3LUBeBNBDPXKyK1v5dch3R5teBLj3KhMth" or use QR code:

![BTC donation address](https://raw.githubusercontent.com/xas/CryptoTray/master/misc/btc.png)
