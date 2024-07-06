using Meta.MainPanel.Views.Old.Actions;
using mscoree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meta.MainPanel.Calls;

internal static class Program
{
    private static object object_0;

    public static IList<AppDomain> GetAppDomains()
    {
        IList<AppDomain> list = new List<AppDomain>();
        IntPtr hEnum = IntPtr.Zero;
        ICorRuntimeHost corRuntimeHost = (CorRuntimeHost)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CB2F6723-AB3A-11D2-9C40-00C04FA30A3E")));
        try
        {
            corRuntimeHost.EnumDomains(out hEnum);
            object pAppDomain = null;
            while (true)
            {
                corRuntimeHost.NextDomain(hEnum, out pAppDomain);
                if (pAppDomain == null)
                {
                    break;
                }
                AppDomain item = (AppDomain)pAppDomain;
                list.Add(item);
            }
            return list;
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            corRuntimeHost.CloseEnum(hEnum);
            Marshal.ReleaseComObject(corRuntimeHost);
        }
    }

    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            IList<AppDomain> domains = GetAppDomains();
            Task.Run(delegate
            {
                try
                {
                    while (true)
                    {
                        foreach (AppDomain appDomain in GetAppDomains())
                        {
                            bool flag = false;
                            foreach (AppDomain item in domains)
                            {
                                if (item.FriendlyName == appDomain.FriendlyName)
                                {
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                AppDomain.Unload(appDomain);
                            }
                        }
                        Task.Delay(TimeSpan.FromSeconds(1.0)).Wait();
                    }
                }
                catch
                {
                }
            });
            Task.Run(delegate
            {
                try
                {
                    while (true)
                    {
                        try
                        {
                            List<Proc> processesByName = GetProcessesByName("werfault");
                            if (processesByName.Count > 0)
                            {
                                foreach (Proc item2 in processesByName)
                                {
                                    try
                                    {
                                        Process.GetProcessById((int)item2.Id).Kill();
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        Task.Delay(TimeSpan.FromSeconds(1.0)).Wait();
                    }
                }
                catch
                {
                }
            });
            try
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Windows.Native.Net.dll"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Windows.Native.Net.dll");
                }
            }
            catch
            {
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Directory.SetCurrentDirectory(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName);
            if (string.IsNullOrWhiteSpace(args?.FirstOrDefault((string x) => x.Contains("--monitorParent"))))
            {
                while (true)
                {
                    try
                    {
                        Process process = null;
                        if (args != null && args.Length == 3 && args[0] == "auth")
                        {
                            ProcessStartInfo processStartInfo = new ProcessStartInfo();
                            processStartInfo.Arguments = "\"auth\" \"" + args[1] + "\" \"" + args[2] + "\" \"--monitorParent\"";
                            processStartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
                            processStartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                            process = Process.Start(processStartInfo);
                        }
                        else
                        {
                            process = Process.Start(new ProcessStartInfo
                            {
                                Arguments = "\"--monitorParent\"",
                                FileName = Process.GetCurrentProcess().MainModule.FileName,
                                WorkingDirectory = Directory.GetCurrentDirectory()
                            });
                        }
                        process.WaitForExit();
                        int exitCode = process.ExitCode;
                        Thread.Sleep(2000);
                        switch (exitCode)
                        {
                            case 0:
                                Environment.Exit(0);
                                break;
                            case -1073740771:
                            case 322:
                                Environment.Exit(0);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            object_0 = new Mutex(initiallyOwned: true, "MetaPanelMutex", out var createdNew);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, (RemoteCertificateValidationCallback)((object _, X509Certificate __, X509Chain ___, SslPolicyErrors ____) => true));
            if (createdNew)
            {
                CheckValidSetup();
                Application.Run(new MainFrm());
            }
            else
            {
                MessageBox.Show("The application is already running.", "Meta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        catch (Exception ex2)
        {
            EventLog.WriteEntry("Panel.exe", ex2.Message, EventLogEntryType.Error);
        }
    }

    public static List<Proc> GetProcessesByName(string name)
    {
        List<Proc> list = new List<Proc>();
        try
        {
            using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process Where SessionId='" + Process.GetCurrentProcess().SessionId + "'");
            using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject item in managementObjectCollection)
            {
                try
                {
                    if ((item["Name"]?.ToString()).ToLower().Contains(name.ToLower()))
                    {
                        list.Add(new Proc
                        {
                            FilePath = item["ExecutablePath"]?.ToString(),
                            Id = Convert.ToUInt32(item["ProcessId"])
                        });
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
        return list;
    }

    public static void CheckValidSetup()
    {
        try
        {
            if (Application.ExecutablePath.Contains("Rar$"))
            {
                MessageBox.Show("Don't execute Panel.exe from zip without extracting on disk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bool flag = File.Exists("chromeBrowsers.txt");
            bool flag2 = File.Exists("geckoBrowsers.txt");
            bool flag3 = File.Exists(Directory.GetCurrentDirectory() + "\\IpDb\\IpDb.bin");
            bool flag4 = File.Exists(Directory.GetCurrentDirectory() + "\\IpDb\\Ipv6Db.bin");
            if (!flag2 || !flag || !flag3 || !flag4)
            {
                MessageBox.Show("Can't find required files: " + string.Join(Environment.NewLine, flag3 ? null : (Directory.GetCurrentDirectory() + "\\IpDb\\IpDb.bin"), flag4 ? null : (Directory.GetCurrentDirectory() + "\\IpDb\\Ipv6Db.bin"), flag2 ? null : "geckoBrowsers.txt", flag ? "" : "chromeBrowsers.txt"), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        catch
        {
        }
    }
}
