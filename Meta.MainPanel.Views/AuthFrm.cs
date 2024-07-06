using GuiLib;
using Meta.MainPanel.Data.Core;
using Meta.MainPanel.Data.Extensions;
using Meta.MainPanel.Data.Helpers;
using Meta.MainPanel.Models;
using Meta.MainPanel.Models.Communication;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meta.MainPanel.Views;

public class AuthFrm : Form
{
    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass4_0
    {
        public bool result;

        public string login;

        public string password;

        public AuthFrm _003C_003E4__this;

        internal void method_0()
        {
            if (Environment.GetCommandLineArgs()[1] != "auth")
            {
                try
                {
                    _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_1
                    {
                        CS_0024_003C_003E8__locals1 = this
                    };
                    if (AssemblyProtection.EthernetConnected())
                    {
                        CS_0024_003C_003E8__locals0.textResult = string.Empty;
                        GenericService.Use(delegate (IMainServer server)
                        {
                            StringTool.GenerateKeys(out var key2, out var iv2);
                            if (!server.Init(StringTool.Set(Convert.ToBase64String(key2)), StringTool.Set(Convert.ToBase64String(iv2))).Result)
                            {
                                CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
                            }
                            else
                            {
                                long millis2 = CurrentMillis.Millis;
                                string arg4 = StringTool.Set($"{millis2}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.login}");
                                string arg5 = StringTool.Set($"{millis2}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.password}");
                                string arg6 = StringTool.Set(millis2.ToString());
                                CS_0024_003C_003E8__locals0.textResult = server.Connect(arg4, arg5, arg6).Result;
                                if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.textResult))
                                {
                                    string header2 = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                                    if (!string.IsNullOrWhiteSpace(header2))
                                    {
                                        if (Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header2), key2, iv2), CS_0024_003C_003E8__locals0.textResult))
                                        {
                                            string[] array2 = StringTool.Get(StringTool.Get(Convert.FromBase64String(CS_0024_003C_003E8__locals0.textResult), key2, iv2)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                                            if (array2[0] == "ResultTrue" && long.TryParse(array2[1], out var num2) && array2[2] == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.login && Math.Abs(num2 - millis2) < 900000L && Math.Abs(CurrentMillis.Millis - millis2) < 900000L)
                                            {
                                                string text3 = array2[3];
                                                if (string.IsNullOrWhiteSpace(text3))
                                                {
                                                    CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
                                                }
                                                else
                                                {
                                                    ProfileSettings.Token = text3;
                                                    ProfileSettings.OnCreatorStateChanged(null, array2[4] == "TRUE");
                                                    ProfileSettings.OnHeaderStateChanged(null, array2[5] == "TRUE");
                                                    CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
                                    }
                                }
                                else
                                {
                                    CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
                                }
                            }
                        }, firstRun: true);
                    }
                    else
                    {
                        MessageBox.Show(_003C_003E4__this, "Check ethernet connection and try again");
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            try
            {
                _003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_2
                {
                    CS_0024_003C_003E8__locals2 = this,
                    tries = 0
                };
                while (CS_0024_003C_003E8__locals1.tries < 3)
                {
                    try
                    {
                        GenericService.Use(delegate (IMainServer server)
                        {
                            StringTool.GenerateKeys(out var key, out var iv);
                            if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
                            {
                                throw new Exception("Connection lost. Can't init key");
                            }
                            long millis = CurrentMillis.Millis;
                            string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.login}");
                            string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.password}");
                            string arg3 = StringTool.Set(millis.ToString());
                            string text = server.Connect(arg, arg2, arg3).Result;
                            if (string.IsNullOrWhiteSpace(text))
                            {
                                throw new Exception("Connection lost. Empty response");
                            }
                            string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                            if (string.IsNullOrWhiteSpace(header))
                            {
                                throw new Exception("Connection lost. Cant find a security token.");
                            }
                            if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), text))
                            {
                                throw new Exception("Connection lost. Server");
                            }
                            string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(text), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                            if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var num) || !(array[2] == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.login))
                            {
                                throw new Exception("Connection lost. Parts");
                            }
                            if (Math.Abs(num - millis) >= 900000L || Math.Abs(CurrentMillis.Millis - millis) >= 900000L)
                            {
                                throw new Exception("Connection lost. Mills");
                            }
                            string text2 = array[3];
                            if (string.IsNullOrWhiteSpace(text2))
                            {
                                throw new Exception("Connection lost. Cant find a token");
                            }
                            CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.result = true;
                            CS_0024_003C_003E8__locals1.tries = 0;
                            ProfileSettings.Token = text2;
                            ProfileSettings.OnCreatorStateChanged(null, array[4] == "TRUE");
                            ProfileSettings.OnHeaderStateChanged(null, array[5] == "TRUE");
                        });
                    }
                    catch (Exception)
                    {
                        CS_0024_003C_003E8__locals1.tries++;
                    }
                    if (!result)
                    {
                        Task.Delay(TimeSpan.FromMinutes(3.0)).Wait();
                        continue;
                    }
                    break;
                }
            }
            catch
            {
            }
        }

        internal void method_1()
        {
            try
            {
                _003C_003Ec__DisplayClass4_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_3
                {
                    CS_0024_003C_003E8__locals3 = this,
                    tries = 0
                };
                while (CS_0024_003C_003E8__locals0.tries < 3)
                {
                    Task.Delay(TimeSpan.FromMinutes(3.0)).Wait();
                    CS_0024_003C_003E8__locals0.tries++;
                    try
                    {
                        GenericService.Use(delegate (IMainServer server)
                        {
                            StringTool.GenerateKeys(out var key, out var iv);
                            if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
                            {
                                throw new Exception("Connection lost. Can't init key");
                            }
                            long millis = CurrentMillis.Millis;
                            string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.login}");
                            string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.password}");
                            string arg3 = StringTool.Set(millis.ToString());
                            string text = server.Connect(arg, arg2, arg3).Result;
                            if (string.IsNullOrWhiteSpace(text))
                            {
                                throw new Exception("Connection lost. Empty response");
                            }
                            string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                            if (string.IsNullOrWhiteSpace(header))
                            {
                                throw new Exception("Connection lost. Cant find a security token.");
                            }
                            if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), text))
                            {
                                throw new Exception("Connection lost. Server");
                            }
                            string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(text), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                            if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var num) || !(array[2] == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.login))
                            {
                                throw new Exception("Connection lost. Parts");
                            }
                            if (Math.Abs(num - millis) >= 900000L || Math.Abs(CurrentMillis.Millis - millis) >= 900000L)
                            {
                                throw new Exception("Connection lost. Mills");
                            }
                            string text2 = array[3];
                            if (string.IsNullOrWhiteSpace(text2))
                            {
                                throw new Exception("Connection lost. Cant find a token");
                            }
                            CS_0024_003C_003E8__locals0.tries = 0;
                            ProfileSettings.Token = text2;
                            ProfileSettings.OnCreatorStateChanged(null, array[4] == "TRUE");
                            ProfileSettings.OnHeaderStateChanged(null, array[5] == "TRUE");
                        });
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("Panel.exe", "Connection error. " + ex.Message, EventLogEntryType.Error);
                        if (ex.Message.Contains("security issue"))
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                }
                Process.GetCurrentProcess().Kill();
            }
            catch
            {
            }
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass4_1
    {
        public string textResult;

        public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

        internal void method_0(IMainServer server)
        {
            StringTool.GenerateKeys(out var key, out var iv);
            if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
            {
                CS_0024_003C_003E8__locals1.result = false;
                return;
            }
            long millis = CurrentMillis.Millis;
            string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals1.login}");
            string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals1.password}");
            string arg3 = StringTool.Set(millis.ToString());
            textResult = server.Connect(arg, arg2, arg3).Result;
            if (!string.IsNullOrWhiteSpace(textResult))
            {
                string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                if (!string.IsNullOrWhiteSpace(header))
                {
                    if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), textResult))
                    {
                        return;
                    }
                    string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(textResult), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                    if (array[0] == "ResultTrue" && long.TryParse(array[1], out var result) && array[2] == CS_0024_003C_003E8__locals1.login && Math.Abs(result - millis) < 900000L && Math.Abs(CurrentMillis.Millis - millis) < 900000L)
                    {
                        string text = array[3];
                        if (string.IsNullOrWhiteSpace(text))
                        {
                            CS_0024_003C_003E8__locals1.result = false;
                            return;
                        }
                        ProfileSettings.Token = text;
                        ProfileSettings.OnCreatorStateChanged(null, array[4] == "TRUE");
                        ProfileSettings.OnHeaderStateChanged(null, array[5] == "TRUE");
                        CS_0024_003C_003E8__locals1.result = true;
                    }
                }
                else
                {
                    CS_0024_003C_003E8__locals1.result = false;
                }
            }
            else
            {
                CS_0024_003C_003E8__locals1.result = false;
            }
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass4_2
    {
        public int tries;

        public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals2;

        internal void method_0(IMainServer server)
        {
            StringTool.GenerateKeys(out var key, out var iv);
            if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
            {
                throw new Exception("Connection lost. Can't init key");
            }
            long millis = CurrentMillis.Millis;
            string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals2.login}");
            string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals2.password}");
            string arg3 = StringTool.Set(millis.ToString());
            string result = server.Connect(arg, arg2, arg3).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                throw new Exception("Connection lost. Empty response");
            }
            string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
            if (!string.IsNullOrWhiteSpace(header))
            {
                if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), result))
                {
                    throw new Exception("Connection lost. Server");
                }
                string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(result), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                if (array[0] == "ResultTrue" && long.TryParse(array[1], out var result2) && array[2] == CS_0024_003C_003E8__locals2.login)
                {
                    if (Math.Abs(result2 - millis) >= 900000L || Math.Abs(CurrentMillis.Millis - millis) >= 900000L)
                    {
                        throw new Exception("Connection lost. Mills");
                    }
                    string text = array[3];
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        throw new Exception("Connection lost. Cant find a token");
                    }
                    CS_0024_003C_003E8__locals2.result = true;
                    tries = 0;
                    ProfileSettings.Token = text;
                    ProfileSettings.OnCreatorStateChanged(null, array[4] == "TRUE");
                    ProfileSettings.OnHeaderStateChanged(null, array[5] == "TRUE");
                    return;
                }
                throw new Exception("Connection lost. Parts");
            }
            throw new Exception("Connection lost. Cant find a security token.");
        }
    }

    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass4_3
    {
        public int tries;

        public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals3;

        internal void method_0(IMainServer server)
        {
            StringTool.GenerateKeys(out var key, out var iv);
            if (server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
            {
                long millis = CurrentMillis.Millis;
                string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals3.login}");
                string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals3.password}");
                string arg3 = StringTool.Set(millis.ToString());
                string result = server.Connect(arg, arg2, arg3).Result;
                if (!string.IsNullOrWhiteSpace(result))
                {
                    string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                    if (string.IsNullOrWhiteSpace(header))
                    {
                        throw new Exception("Connection lost. Cant find a security token.");
                    }
                    if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), result))
                    {
                        throw new Exception("Connection lost. Server");
                    }
                    string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(result), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                    if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var result2) || !(array[2] == CS_0024_003C_003E8__locals3.login))
                    {
                        throw new Exception("Connection lost. Parts");
                    }
                    if (Math.Abs(result2 - millis) >= 900000L || Math.Abs(CurrentMillis.Millis - millis) >= 900000L)
                    {
                        throw new Exception("Connection lost. Mills");
                    }
                    string text = array[3];
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        throw new Exception("Connection lost. Cant find a token");
                    }
                    tries = 0;
                    ProfileSettings.Token = text;
                    ProfileSettings.OnCreatorStateChanged(null, array[4] == "TRUE");
                    ProfileSettings.OnHeaderStateChanged(null, array[5] == "TRUE");
                    return;
                }
                throw new Exception("Connection lost. Empty response");
            }
            throw new Exception("Connection lost. Can't init key");
        }
    }

    private object object_0;

    private object topHeader;

    private object mainTitle;

    private object closeBtn;

    private object signInBtn;

    private object passwordLbl;

    private object loginLbl;

    private object loginTb;

    private object passwordTb;

    private object connectingLbl;

    public AuthFrm()
    {
        InitializeComponent();
        this.AllowDraggBy((Control)topHeader);
        try
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs[1] == "auth")
            {
                ((AnimaTextBox)loginTb).Text = DPAPI.Unprotect(commandLineArgs[2], DataProtectionScope.CurrentUser, "0x31242");
                ((AnimaTextBox)passwordTb).Text = DPAPI.Unprotect(commandLineArgs[3], DataProtectionScope.CurrentUser, "0x31242");
                SignIn();
            }
        }
        catch
        {
        }
    }

    private void AuthFrm_Paint(object sender, object e)
    {
        int num = base.Width - 1;
        int num2 = base.Height - 1;
        Pen pen = new Pen(ColorPicker.ThemeColor, 3f);
        ((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
    }

    private void topHeader_Paint(object sender, object e)
    {
        int num = ((Control)topHeader).Width - 1;
        int num2 = ((Control)topHeader).Height - 1;
        Pen pen = new Pen(ColorPicker.ThemeColor, 3f);
        ((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
    }

    private void closeBtn_Click(object sender, object e)
    {
        Close();
    }

    public async void SignIn()
    {
        try
        {
            object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
            ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0)._003C_003E4__this = this;
            ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).login = ((AnimaTextBox)loginTb).Text;
            ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).password = ((AnimaTextBox)passwordTb).Text;
            if (string.IsNullOrWhiteSpace(((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).login))
            {
                MessageBox.Show(this, "Please, enter a login");
            }
            else if (string.IsNullOrWhiteSpace(((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).password))
            {
                MessageBox.Show(this, "Please, enter a password");
            }
            else if (await Task.Factory.StartNew(() => AssemblyProtection.EthernetConnected()))
            {
                ((Control)signInBtn).Visible = false;
                ((Control)connectingLbl).Visible = true;
                ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).result = false;
                await Task.Factory.StartNew(delegate
                {
                    if (Environment.GetCommandLineArgs()[1] != "auth")
                    {
                        try
                        {
                            _003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_2 = (_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0;
                            if (AssemblyProtection.EthernetConnected())
                            {
                                string textResult = string.Empty;
                                GenericService.Use(delegate (IMainServer server)
                                {
                                    StringTool.GenerateKeys(out var key3, out var iv3);
                                    if (!server.Init(StringTool.Set(Convert.ToBase64String(key3)), StringTool.Set(Convert.ToBase64String(iv3))).Result)
                                    {
                                        _003C_003Ec__DisplayClass4_2.result = false;
                                    }
                                    else
                                    {
                                        long millis3 = CurrentMillis.Millis;
                                        string arg7 = StringTool.Set($"{millis3}[A]{_003C_003Ec__DisplayClass4_2.login}");
                                        string arg8 = StringTool.Set($"{millis3}[A]{_003C_003Ec__DisplayClass4_2.password}");
                                        string arg9 = StringTool.Set(millis3.ToString());
                                        textResult = server.Connect(arg7, arg8, arg9).Result;
                                        if (!string.IsNullOrWhiteSpace(textResult))
                                        {
                                            string header3 = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                                            if (!string.IsNullOrWhiteSpace(header3))
                                            {
                                                if (Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header3), key3, iv3), textResult))
                                                {
                                                    string[] array3 = StringTool.Get(StringTool.Get(Convert.FromBase64String(textResult), key3, iv3)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                                                    if (array3[0] == "ResultTrue" && long.TryParse(array3[1], out var result5) && array3[2] == _003C_003Ec__DisplayClass4_2.login && Math.Abs(result5 - millis3) < 900000L && Math.Abs(CurrentMillis.Millis - millis3) < 900000L)
                                                    {
                                                        string text3 = array3[3];
                                                        if (string.IsNullOrWhiteSpace(text3))
                                                        {
                                                            _003C_003Ec__DisplayClass4_2.result = false;
                                                        }
                                                        else
                                                        {
                                                            ProfileSettings.Token = text3;
                                                            ProfileSettings.OnCreatorStateChanged(null, array3[4] == "TRUE");
                                                            ProfileSettings.OnHeaderStateChanged(null, array3[5] == "TRUE");
                                                            _003C_003Ec__DisplayClass4_2.result = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                _003C_003Ec__DisplayClass4_2.result = false;
                                            }
                                        }
                                        else
                                        {
                                            _003C_003Ec__DisplayClass4_2.result = false;
                                        }
                                    }
                                }, firstRun: true);
                            }
                            else
                            {
                                MessageBox.Show(((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0)._003C_003E4__this, "Check ethernet connection and try again");
                            }
                            return;
                        }
                        catch (Exception ex3)
                        {
                            MessageBox.Show(ex3.Message);
                            return;
                        }
                    }
                    try
                    {
                        _003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_3 = (_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0;
                        int tries = 0;
                        while (tries < 3)
                        {
                            try
                            {
                                GenericService.Use(delegate (IMainServer server)
                                {
                                    StringTool.GenerateKeys(out var key2, out var iv2);
                                    if (!server.Init(StringTool.Set(Convert.ToBase64String(key2)), StringTool.Set(Convert.ToBase64String(iv2))).Result)
                                    {
                                        throw new Exception("Connection lost. Can't init key");
                                    }
                                    long millis2 = CurrentMillis.Millis;
                                    string arg4 = StringTool.Set($"{millis2}[A]{_003C_003Ec__DisplayClass4_3.login}");
                                    string arg5 = StringTool.Set($"{millis2}[A]{_003C_003Ec__DisplayClass4_3.password}");
                                    string arg6 = StringTool.Set(millis2.ToString());
                                    string result3 = server.Connect(arg4, arg5, arg6).Result;
                                    if (string.IsNullOrWhiteSpace(result3))
                                    {
                                        throw new Exception("Connection lost. Empty response");
                                    }
                                    string header2 = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                                    if (string.IsNullOrWhiteSpace(header2))
                                    {
                                        throw new Exception("Connection lost. Cant find a security token.");
                                    }
                                    if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header2), key2, iv2), result3))
                                    {
                                        throw new Exception("Connection lost. Server");
                                    }
                                    string[] array2 = StringTool.Get(StringTool.Get(Convert.FromBase64String(result3), key2, iv2)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (!(array2[0] == "ResultTrue") || !long.TryParse(array2[1], out var result4) || !(array2[2] == _003C_003Ec__DisplayClass4_3.login))
                                    {
                                        throw new Exception("Connection lost. Parts");
                                    }
                                    if (Math.Abs(result4 - millis2) >= 900000L || Math.Abs(CurrentMillis.Millis - millis2) >= 900000L)
                                    {
                                        throw new Exception("Connection lost. Mills");
                                    }
                                    string text2 = array2[3];
                                    if (string.IsNullOrWhiteSpace(text2))
                                    {
                                        throw new Exception("Connection lost. Cant find a token");
                                    }
                                    _003C_003Ec__DisplayClass4_3.result = true;
                                    tries = 0;
                                    ProfileSettings.Token = text2;
                                    ProfileSettings.OnCreatorStateChanged(null, array2[4] == "TRUE");
                                    ProfileSettings.OnHeaderStateChanged(null, array2[5] == "TRUE");
                                });
                            }
                            catch (Exception)
                            {
                                tries++;
                            }
                            if (((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).result)
                            {
                                break;
                            }
                            Task.Delay(TimeSpan.FromMinutes(3.0)).Wait();
                        }
                    }
                    catch
                    {
                    }
                });
                ((Control)connectingLbl).Visible = false;
                ((Control)signInBtn).Visible = true;
                if (((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).result)
                {
                    Task.Run(delegate
                    {
                        try
                        {
                            _003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = (_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0;
                            int tries = 0;
                            while (tries < 3)
                            {
                                Task.Delay(TimeSpan.FromMinutes(3.0)).Wait();
                                tries++;
                                try
                                {
                                    GenericService.Use(delegate (IMainServer server)
                                    {
                                        StringTool.GenerateKeys(out var key, out var iv);
                                        if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
                                        {
                                            throw new Exception("Connection lost. Can't init key");
                                        }
                                        long millis = CurrentMillis.Millis;
                                        string arg = StringTool.Set($"{millis}[A]{_003C_003Ec__DisplayClass4_.login}");
                                        string arg2 = StringTool.Set($"{millis}[A]{_003C_003Ec__DisplayClass4_.password}");
                                        string arg3 = StringTool.Set(millis.ToString());
                                        string result = server.Connect(arg, arg2, arg3).Result;
                                        if (string.IsNullOrWhiteSpace(result))
                                        {
                                            throw new Exception("Connection lost. Empty response");
                                        }
                                        string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
                                        if (string.IsNullOrWhiteSpace(header))
                                        {
                                            throw new Exception("Connection lost. Cant find a security token.");
                                        }
                                        if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), result))
                                        {
                                            throw new Exception("Connection lost. Server");
                                        }
                                        string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(result), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
                                        if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var result2) || !(array[2] == _003C_003Ec__DisplayClass4_.login))
                                        {
                                            throw new Exception("Connection lost. Parts");
                                        }
                                        if (Math.Abs(result2 - millis) >= 900000L || Math.Abs(CurrentMillis.Millis - millis) >= 900000L)
                                        {
                                            throw new Exception("Connection lost. Mills");
                                        }
                                        string text = array[3];
                                        if (string.IsNullOrWhiteSpace(text))
                                        {
                                            throw new Exception("Connection lost. Cant find a token");
                                        }
                                        tries = 0;
                                        ProfileSettings.Token = text;
                                        ProfileSettings.OnCreatorStateChanged(null, array[4] == "TRUE");
                                        ProfileSettings.OnHeaderStateChanged(null, array[5] == "TRUE");
                                    });
                                }
                                catch (Exception ex2)
                                {
                                    EventLog.WriteEntry("Panel.exe", "Connection error. " + ex2.Message, EventLogEntryType.Error);
                                    if (ex2.Message.Contains("security issue"))
                                    {
                                        Process.GetCurrentProcess().Kill();
                                    }
                                }
                            }
                            Process.GetCurrentProcess().Kill();
                        }
                        catch
                        {
                        }
                    });
                    base.DialogResult = DialogResult.OK;
                    ProfileSettings.Login = ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).login;
                    ProfileSettings.Password = ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).password;
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Unable to log in with this login and password. Try again.");
                    ProfileSettings.Login = string.Empty;
                    ProfileSettings.Password = string.Empty;
                }
            }
            else
            {
                MessageBox.Show(this, "Check ethernet connection and try again");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Error: " + ex.Message);
        }
    }

    private async void signInBtn_Click(object sender, object e)
    {
        SignIn();
    }

    private void method_0(object sender, object e)
    {
        if (((KeyEventArgs)e).KeyCode == Keys.Return)
        {
            SignIn();
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && object_0 != null)
        {
            ((IDisposable)object_0).Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meta.MainPanel.Views.AuthFrm));
        this.topHeader = new System.Windows.Forms.Panel();
        this.mainTitle = new System.Windows.Forms.Label();
        this.closeBtn = new System.Windows.Forms.Label();
        this.signInBtn = new System.Windows.Forms.Button();
        this.passwordLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.loginLbl = new MetroSet_UI.Controls.MetroSetLabel();
        this.passwordTb = new GuiLib.AnimaTextBox();
        this.loginTb = new GuiLib.AnimaTextBox();
        this.connectingLbl = new MetroSet_UI.Controls.MetroSetLabel();
        ((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
        base.SuspendLayout();
        ((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
        ((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
        ((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
        ((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
        ((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(547, 30);
        ((System.Windows.Forms.Control)this.topHeader).TabIndex = 4;
        ((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
        ((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
        ((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.FromArgb(64, 224, 208);
        ((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
        ((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
        ((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(96, 20);
        ((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
        ((System.Windows.Forms.Control)this.mainTitle).Text = "Meta | Log In";
        ((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
        ((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(524, 4);
        ((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
        ((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
        ((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
        ((System.Windows.Forms.Control)this.closeBtn).Text = "X";
        ((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
        ((System.Windows.Forms.Control)this.signInBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((System.Windows.Forms.ButtonBase)this.signInBtn).FlatAppearance.BorderSize = 0;
        ((System.Windows.Forms.ButtonBase)this.signInBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        ((System.Windows.Forms.Control)this.signInBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((System.Windows.Forms.Control)this.signInBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.signInBtn).Location = new System.Drawing.Point(234, 161);
        ((System.Windows.Forms.Control)this.signInBtn).Name = "signInBtn";
        ((System.Windows.Forms.Control)this.signInBtn).Size = new System.Drawing.Size(79, 26);
        ((System.Windows.Forms.Control)this.signInBtn).TabIndex = 13;
        ((System.Windows.Forms.Control)this.signInBtn).Text = "Sign in";
        ((System.Windows.Forms.ButtonBase)this.signInBtn).UseVisualStyleBackColor = false;
        ((System.Windows.Forms.Control)this.signInBtn).Click += new System.EventHandler(signInBtn_Click);
        ((System.Windows.Forms.Control)this.passwordLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((System.Windows.Forms.Control)this.passwordLbl).Location = new System.Drawing.Point(42, 99);
        ((System.Windows.Forms.Control)this.passwordLbl).Name = "passwordLbl";
        ((System.Windows.Forms.Control)this.passwordLbl).Size = new System.Drawing.Size(100, 23);
        ((MetroSet_UI.Controls.MetroSetLabel)this.passwordLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.passwordLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.passwordLbl).TabIndex = 10;
        ((System.Windows.Forms.Control)this.passwordLbl).Text = "Password:";
        ((MetroSet_UI.Controls.MetroSetLabel)this.passwordLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.passwordLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.loginLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((System.Windows.Forms.Control)this.loginLbl).Location = new System.Drawing.Point(42, 43);
        ((System.Windows.Forms.Control)this.loginLbl).Name = "loginLbl";
        ((System.Windows.Forms.Control)this.loginLbl).Size = new System.Drawing.Size(100, 23);
        ((MetroSet_UI.Controls.MetroSetLabel)this.loginLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.loginLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.loginLbl).TabIndex = 9;
        ((System.Windows.Forms.Control)this.loginLbl).Text = "Login:";
        ((MetroSet_UI.Controls.MetroSetLabel)this.loginLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.loginLbl).ThemeName = "MetroDark";
        ((GuiLib.AnimaTextBox)this.passwordTb).Dark = false;
        ((System.Windows.Forms.Control)this.passwordTb).Location = new System.Drawing.Point(42, 122);
        ((GuiLib.AnimaTextBox)this.passwordTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.passwordTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.passwordTb).Name = "passwordTb";
        ((GuiLib.AnimaTextBox)this.passwordTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.passwordTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.passwordTb).Size = new System.Drawing.Size(479, 23);
        ((System.Windows.Forms.Control)this.passwordTb).TabIndex = 32;
        ((GuiLib.AnimaTextBox)this.passwordTb).UseSystemPasswordChar = true;
        ((GuiLib.AnimaTextBox)this.loginTb).Dark = false;
        ((System.Windows.Forms.Control)this.loginTb).Location = new System.Drawing.Point(42, 69);
        ((GuiLib.AnimaTextBox)this.loginTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.loginTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.loginTb).Name = "loginTb";
        ((GuiLib.AnimaTextBox)this.loginTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.loginTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.loginTb).Size = new System.Drawing.Size(479, 23);
        ((System.Windows.Forms.Control)this.loginTb).TabIndex = 31;
        ((GuiLib.AnimaTextBox)this.loginTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.connectingLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((System.Windows.Forms.Control)this.connectingLbl).Location = new System.Drawing.Point(234, 163);
        ((System.Windows.Forms.Control)this.connectingLbl).Name = "connectingLbl";
        ((System.Windows.Forms.Control)this.connectingLbl).Size = new System.Drawing.Size(88, 23);
        ((MetroSet_UI.Controls.MetroSetLabel)this.connectingLbl).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.connectingLbl).StyleManager = null;
        ((System.Windows.Forms.Control)this.connectingLbl).TabIndex = 33;
        ((System.Windows.Forms.Control)this.connectingLbl).Text = "Connecting..";
        ((MetroSet_UI.Controls.MetroSetLabel)this.connectingLbl).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.connectingLbl).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.connectingLbl).Visible = false;
        base.AcceptButton = (System.Windows.Forms.IButtonControl)this.signInBtn;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        base.ClientSize = new System.Drawing.Size(547, 200);
        base.Controls.Add((System.Windows.Forms.Control)this.connectingLbl);
        base.Controls.Add((System.Windows.Forms.Control)this.passwordTb);
        base.Controls.Add((System.Windows.Forms.Control)this.loginTb);
        base.Controls.Add((System.Windows.Forms.Control)this.signInBtn);
        base.Controls.Add((System.Windows.Forms.Control)this.passwordLbl);
        base.Controls.Add((System.Windows.Forms.Control)this.loginLbl);
        base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "AuthFrm";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Meta | Log In";
        base.Paint += new System.Windows.Forms.PaintEventHandler(AuthFrm_Paint);
        ((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.topHeader).PerformLayout();
        base.ResumeLayout(false);
    }
}
