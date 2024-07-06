using GuiLib;
using Meta.SharedModels;
using MetroSet_UI.Controls;
using System;
using System.Windows.Forms;

namespace Meta.MainPanel.Data.UI;

public class TelegramBotSettingsControl : UserControl
{
    private object object_0;

    private object object_1;

    private object telegramSortFilesTb;

    private object label62;

    private object label49;

    private object label51;

    private object label52;

    private object label55;

    private object label56;

    private object label59;

    private object a;

    private object b;

    private object c;

    private object d;

    private object e;

    private object f;

    private object label68;

    private object label69;

    private object telegramSteamCb;

    private object telegramDesktopFilesCb;

    private object telegramSkipEmptyPassCb;

    private object telegramSkipEmptyCookiesCb;

    private object telegramColdWalletsCb;

    private object telegramSortOsTb;

    private object telegramFilesCb;

    private object telegramFtpsCb;

    private object telegramAutoFillsCb;

    private object telegramCcsCb;

    private object telegramSortCountryTb;

    private object telegramSortCookiesTb;

    private object telegramSortPasswordsTb;

    private object telegramSortBuildIDTb;

    private object panel2;

    private object telegramNoAttachCb;

    private object telegramSendScreenshotCb;

    private object telegramSendLogFileCb;

    private object telegramBotFormatTb;

    private object metroSetLabel4;

    private object label1;

    private object passMoreThan;

    private object cookiesMoreThan;

    private object label2;

    public TelegramBotSettingsControl()
    {
        InitializeComponent();
    }

    public void SetChatSettings(TelegramChatSettings chatSettings)
    {
        object_0 = chatSettings;
        ((AnimaTextBox)telegramSortBuildIDTb).Text = chatSettings.SearchParams.BuildID;
        ((MetroSetCheckBox)telegramAutoFillsCb).Checked = chatSettings.SearchParams.ContainsAFs;
        ((MetroSetCheckBox)telegramCcsCb).Checked = chatSettings.SearchParams.ContainsCCs;
        ((MetroSetCheckBox)telegramFilesCb).Checked = chatSettings.SearchParams.ContainsFiles;
        ((MetroSetCheckBox)telegramFtpsCb).Checked = chatSettings.SearchParams.ContainsFTPs;
        ((MetroSetCheckBox)telegramSteamCb).Checked = chatSettings.SearchParams.ContainsSteam;
        ((MetroSetCheckBox)telegramDesktopFilesCb).Checked = chatSettings.SearchParams.ContainsTelegram;
        ((MetroSetCheckBox)telegramColdWalletsCb).Checked = chatSettings.SearchParams.ContainsWallets;
        ((AnimaTextBox)telegramSortCookiesTb).Text = chatSettings.SearchParams.CookieDomain;
        ((AnimaTextBox)telegramSortFilesTb).Text = chatSettings.SearchParams.FilesToSearch;
        ((AnimaTextBox)telegramSortOsTb).Text = chatSettings.SearchParams.OS;
        ((AnimaTextBox)telegramSortPasswordsTb).Text = chatSettings.SearchParams.PasswordDomain;
        ((MetroSetCheckBox)telegramSkipEmptyCookiesCb).Checked = chatSettings.SearchParams.SkipCookies;
        ((MetroSetCheckBox)telegramSkipEmptyPassCb).Checked = chatSettings.SearchParams.SkipPasswords;
        ((AnimaTextBox)telegramSortCountryTb).Text = chatSettings.SearchParams.Country;
        ((NumericUpDown)passMoreThan).Value = chatSettings.SearchParams.PasswordsMoreThan;
        ((NumericUpDown)cookiesMoreThan).Value = chatSettings.SearchParams.CookiesMoreThan;
        if (chatSettings.SendingMode == SendingMode.NoAttachments)
        {
            ((RadioButton)telegramNoAttachCb).Checked = true;
        }
        if (chatSettings.SendingMode == SendingMode.SendLog)
        {
            ((RadioButton)telegramSendLogFileCb).Checked = true;
        }
        if (chatSettings.SendingMode == SendingMode.SendScreenshot)
        {
            ((RadioButton)telegramSendScreenshotCb).Checked = true;
        }
        ((AnimaTextBox)telegramBotFormatTb).Text = chatSettings.MessageFormat;
    }

    public TelegramChatSettings GetChatSettings()
    {
        ((TelegramChatSettings)object_0).SearchParams.BuildID = ((AnimaTextBox)telegramSortBuildIDTb).Text;
        ((TelegramChatSettings)object_0).SearchParams.ContainsAFs = ((MetroSetCheckBox)telegramAutoFillsCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.ContainsCCs = ((MetroSetCheckBox)telegramCcsCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.ContainsFiles = ((MetroSetCheckBox)telegramFilesCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.ContainsFTPs = ((MetroSetCheckBox)telegramFtpsCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.ContainsSteam = ((MetroSetCheckBox)telegramSteamCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.ContainsTelegram = ((MetroSetCheckBox)telegramDesktopFilesCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.ContainsWallets = ((MetroSetCheckBox)telegramColdWalletsCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.Country = ((AnimaTextBox)telegramSortCountryTb).Text;
        ((TelegramChatSettings)object_0).SearchParams.CookieDomain = ((AnimaTextBox)telegramSortCookiesTb).Text;
        ((TelegramChatSettings)object_0).SearchParams.FilesToSearch = ((AnimaTextBox)telegramSortFilesTb).Text;
        ((TelegramChatSettings)object_0).SearchParams.OS = ((AnimaTextBox)telegramSortOsTb).Text;
        ((TelegramChatSettings)object_0).SearchParams.PasswordDomain = ((AnimaTextBox)telegramSortPasswordsTb).Text;
        ((TelegramChatSettings)object_0).SearchParams.SkipCookies = ((MetroSetCheckBox)telegramSkipEmptyCookiesCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.SkipPasswords = ((MetroSetCheckBox)telegramSkipEmptyPassCb).Checked;
        ((TelegramChatSettings)object_0).SearchParams.LogFrom = DateTime.MinValue;
        ((TelegramChatSettings)object_0).SearchParams.LogTo = DateTime.MaxValue;
        ((TelegramChatSettings)object_0).SearchParams.PasswordsMoreThan = (int)((NumericUpDown)passMoreThan).Value;
        ((TelegramChatSettings)object_0).SearchParams.CookiesMoreThan = (int)((NumericUpDown)cookiesMoreThan).Value;
        ((TelegramChatSettings)object_0).MessageFormat = ((AnimaTextBox)telegramBotFormatTb).Text;
        if (((RadioButton)telegramNoAttachCb).Checked)
        {
            ((TelegramChatSettings)object_0).SendingMode = SendingMode.NoAttachments;
        }
        if (((RadioButton)telegramSendLogFileCb).Checked)
        {
            ((TelegramChatSettings)object_0).SendingMode = SendingMode.SendLog;
        }
        if (((RadioButton)telegramSendScreenshotCb).Checked)
        {
            ((TelegramChatSettings)object_0).SendingMode = SendingMode.SendScreenshot;
        }
        return (TelegramChatSettings)object_0;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && object_1 != null)
        {
            ((IDisposable)object_1).Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.telegramSortFilesTb = new GuiLib.AnimaTextBox();
        this.label62 = new System.Windows.Forms.Label();
        this.label49 = new System.Windows.Forms.Label();
        this.label51 = new System.Windows.Forms.Label();
        this.label52 = new System.Windows.Forms.Label();
        this.label55 = new System.Windows.Forms.Label();
        this.label56 = new System.Windows.Forms.Label();
        this.label59 = new System.Windows.Forms.Label();
        this.a = new System.Windows.Forms.Label();
        this.b = new System.Windows.Forms.Label();
        this.c = new System.Windows.Forms.Label();
        this.d = new System.Windows.Forms.Label();
        this.e = new System.Windows.Forms.Label();
        this.f = new System.Windows.Forms.Label();
        this.label68 = new System.Windows.Forms.Label();
        this.label69 = new System.Windows.Forms.Label();
        this.telegramSteamCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramDesktopFilesCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramSkipEmptyPassCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramSkipEmptyCookiesCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramColdWalletsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramSortOsTb = new GuiLib.AnimaTextBox();
        this.telegramFilesCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramFtpsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramAutoFillsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramCcsCb = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.telegramSortCountryTb = new GuiLib.AnimaTextBox();
        this.telegramSortCookiesTb = new GuiLib.AnimaTextBox();
        this.telegramSortPasswordsTb = new GuiLib.AnimaTextBox();
        this.telegramSortBuildIDTb = new GuiLib.AnimaTextBox();
        this.panel2 = new System.Windows.Forms.Panel();
        this.telegramNoAttachCb = new System.Windows.Forms.RadioButton();
        this.telegramSendScreenshotCb = new System.Windows.Forms.RadioButton();
        this.telegramSendLogFileCb = new System.Windows.Forms.RadioButton();
        this.telegramBotFormatTb = new GuiLib.AnimaTextBox();
        this.metroSetLabel4 = new MetroSet_UI.Controls.MetroSetLabel();
        this.label1 = new System.Windows.Forms.Label();
        this.passMoreThan = new System.Windows.Forms.NumericUpDown();
        this.cookiesMoreThan = new System.Windows.Forms.NumericUpDown();
        this.label2 = new System.Windows.Forms.Label();
        ((System.Windows.Forms.Control)this.panel2).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.passMoreThan).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cookiesMoreThan).BeginInit();
        base.SuspendLayout();
        ((GuiLib.AnimaTextBox)this.telegramSortFilesTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramSortFilesTb).Location = new System.Drawing.Point(370, 333);
        ((System.Windows.Forms.Control)this.telegramSortFilesTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramSortFilesTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramSortFilesTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.telegramSortFilesTb).Name = "telegramSortFilesTb";
        ((GuiLib.AnimaTextBox)this.telegramSortFilesTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramSortFilesTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramSortFilesTb).Size = new System.Drawing.Size(412, 44);
        ((System.Windows.Forms.Control)this.telegramSortFilesTb).TabIndex = 364;
        ((GuiLib.AnimaTextBox)this.telegramSortFilesTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.label62).AutoSize = true;
        ((System.Windows.Forms.Control)this.label62).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label62).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label62).Location = new System.Drawing.Point(380, 550);
        ((System.Windows.Forms.Control)this.label62).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label62).Name = "label62";
        ((System.Windows.Forms.Control)this.label62).Size = new System.Drawing.Size(68, 32);
        ((System.Windows.Forms.Control)this.label62).TabIndex = 379;
        ((System.Windows.Forms.Control)this.label62).Text = "FTPs:";
        ((System.Windows.Forms.Control)this.label49).AutoSize = true;
        ((System.Windows.Forms.Control)this.label49).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label49).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label49).Location = new System.Drawing.Point(40, 338);
        ((System.Windows.Forms.Control)this.label49).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label49).Name = "label49";
        ((System.Windows.Forms.Control)this.label49).Size = new System.Drawing.Size(238, 32);
        ((System.Windows.Forms.Control)this.label49).TabIndex = 378;
        ((System.Windows.Forms.Control)this.label49).Text = "File names to search:";
        ((System.Windows.Forms.Control)this.label51).AutoSize = true;
        ((System.Windows.Forms.Control)this.label51).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label51).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label51).Location = new System.Drawing.Point(40, 600);
        ((System.Windows.Forms.Control)this.label51).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label51).Name = "label51";
        ((System.Windows.Forms.Control)this.label51).Size = new System.Drawing.Size(86, 32);
        ((System.Windows.Forms.Control)this.label51).TabIndex = 377;
        ((System.Windows.Forms.Control)this.label51).Text = "Steam:";
        ((System.Windows.Forms.Control)this.label52).AutoSize = true;
        ((System.Windows.Forms.Control)this.label52).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label52).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label52).Location = new System.Drawing.Point(42, 644);
        ((System.Windows.Forms.Control)this.label52).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label52).Name = "label52";
        ((System.Windows.Forms.Control)this.label52).Size = new System.Drawing.Size(118, 32);
        ((System.Windows.Forms.Control)this.label52).TabIndex = 376;
        ((System.Windows.Forms.Control)this.label52).Text = "Telegram:";
        ((System.Windows.Forms.Control)this.label55).AutoSize = true;
        ((System.Windows.Forms.Control)this.label55).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label55).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label55).Location = new System.Drawing.Point(40, 463);
        ((System.Windows.Forms.Control)this.label55).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label55).Name = "label55";
        ((System.Windows.Forms.Control)this.label55).Size = new System.Drawing.Size(256, 32);
        ((System.Windows.Forms.Control)this.label55).TabIndex = 375;
        ((System.Windows.Forms.Control)this.label55).Text = "Skip empty passwords:";
        ((System.Windows.Forms.Control)this.label56).AutoSize = true;
        ((System.Windows.Forms.Control)this.label56).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label56).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label56).Location = new System.Drawing.Point(378, 462);
        ((System.Windows.Forms.Control)this.label56).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label56).Name = "label56";
        ((System.Windows.Forms.Control)this.label56).Size = new System.Drawing.Size(227, 32);
        ((System.Windows.Forms.Control)this.label56).TabIndex = 374;
        ((System.Windows.Forms.Control)this.label56).Text = "Skip empty cookies:";
        ((System.Windows.Forms.Control)this.label59).AutoSize = true;
        ((System.Windows.Forms.Control)this.label59).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label59).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label59).Location = new System.Drawing.Point(380, 596);
        ((System.Windows.Forms.Control)this.label59).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label59).Name = "label59";
        ((System.Windows.Forms.Control)this.label59).Size = new System.Drawing.Size(148, 32);
        ((System.Windows.Forms.Control)this.label59).TabIndex = 373;
        ((System.Windows.Forms.Control)this.label59).Text = "Cold wallets:";
        ((System.Windows.Forms.Control)this.a).AutoSize = true;
        ((System.Windows.Forms.Control)this.a).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.a).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.a).Location = new System.Drawing.Point(40, 158);
        ((System.Windows.Forms.Control)this.a).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.a).Name = "label60";
        ((System.Windows.Forms.Control)this.a).Size = new System.Drawing.Size(51, 32);
        ((System.Windows.Forms.Control)this.a).TabIndex = 372;
        ((System.Windows.Forms.Control)this.a).Text = "OS:";
        ((System.Windows.Forms.Control)this.b).AutoSize = true;
        ((System.Windows.Forms.Control)this.b).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.b).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.b).Location = new System.Drawing.Point(40, 552);
        ((System.Windows.Forms.Control)this.b).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.b).Name = "label61";
        ((System.Windows.Forms.Control)this.b).Size = new System.Drawing.Size(67, 32);
        ((System.Windows.Forms.Control)this.b).TabIndex = 371;
        ((System.Windows.Forms.Control)this.b).Text = "Files:";
        ((System.Windows.Forms.Control)this.c).AutoSize = true;
        ((System.Windows.Forms.Control)this.c).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.c).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.c).Location = new System.Drawing.Point(40, 508);
        ((System.Windows.Forms.Control)this.c).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.c).Name = "label63";
        ((System.Windows.Forms.Control)this.c).Size = new System.Drawing.Size(107, 32);
        ((System.Windows.Forms.Control)this.c).TabIndex = 370;
        ((System.Windows.Forms.Control)this.c).Text = "Autofills:";
        ((System.Windows.Forms.Control)this.d).AutoSize = true;
        ((System.Windows.Forms.Control)this.d).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.d).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.d).Location = new System.Drawing.Point(380, 506);
        ((System.Windows.Forms.Control)this.d).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.d).Name = "label64";
        ((System.Windows.Forms.Control)this.d).Size = new System.Drawing.Size(146, 32);
        ((System.Windows.Forms.Control)this.d).TabIndex = 369;
        ((System.Windows.Forms.Control)this.d).Text = "Credit cards:";
        ((System.Windows.Forms.Control)this.e).AutoSize = true;
        ((System.Windows.Forms.Control)this.e).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.e).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.e).Location = new System.Drawing.Point(40, 277);
        ((System.Windows.Forms.Control)this.e).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.e).Name = "label65";
        ((System.Windows.Forms.Control)this.e).Size = new System.Drawing.Size(295, 32);
        ((System.Windows.Forms.Control)this.e).TabIndex = 368;
        ((System.Windows.Forms.Control)this.e).Text = "Cookies Contains Domain:";
        ((System.Windows.Forms.Control)this.f).AutoSize = true;
        ((System.Windows.Forms.Control)this.f).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.f).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.f).Location = new System.Drawing.Point(40, 215);
        ((System.Windows.Forms.Control)this.f).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.f).Name = "label66";
        ((System.Windows.Forms.Control)this.f).Size = new System.Drawing.Size(318, 32);
        ((System.Windows.Forms.Control)this.f).TabIndex = 367;
        ((System.Windows.Forms.Control)this.f).Text = "Passwords Contains Domain:";
        ((System.Windows.Forms.Control)this.label68).AutoSize = true;
        ((System.Windows.Forms.Control)this.label68).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label68).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label68).Location = new System.Drawing.Point(40, 104);
        ((System.Windows.Forms.Control)this.label68).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label68).Name = "label68";
        ((System.Windows.Forms.Control)this.label68).Size = new System.Drawing.Size(97, 32);
        ((System.Windows.Forms.Control)this.label68).TabIndex = 366;
        ((System.Windows.Forms.Control)this.label68).Text = "BuildID:";
        ((System.Windows.Forms.Control)this.label69).AutoSize = true;
        ((System.Windows.Forms.Control)this.label69).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label69).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label69).Location = new System.Drawing.Point(40, 48);
        ((System.Windows.Forms.Control)this.label69).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label69).Name = "label69";
        ((System.Windows.Forms.Control)this.label69).Size = new System.Drawing.Size(105, 32);
        ((System.Windows.Forms.Control)this.label69).TabIndex = 365;
        ((System.Windows.Forms.Control)this.label69).Text = "Country:";
        ((System.Windows.Forms.Control)this.telegramSteamCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramSteamCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramSteamCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramSteamCb).Location = new System.Drawing.Point(306, 600);
        ((System.Windows.Forms.Control)this.telegramSteamCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramSteamCb).Name = "telegramSteamCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramSteamCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramSteamCb).TabIndex = 363;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSteamCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).Location = new System.Drawing.Point(306, 644);
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).Name = "telegramDesktopFilesCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramDesktopFilesCb).TabIndex = 362;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramDesktopFilesCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).Location = new System.Drawing.Point(306, 463);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).Name = "telegramSkipEmptyPassCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb).TabIndex = 361;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyPassCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).Location = new System.Drawing.Point(744, 462);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).Name = "telegramSkipEmptyCookiesCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb).TabIndex = 360;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramSkipEmptyCookiesCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).Location = new System.Drawing.Point(744, 596);
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).Name = "telegramColdWalletsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramColdWalletsCb).TabIndex = 359;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramColdWalletsCb).ThemeName = "MetroDark";
        ((GuiLib.AnimaTextBox)this.telegramSortOsTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramSortOsTb).Location = new System.Drawing.Point(252, 154);
        ((System.Windows.Forms.Control)this.telegramSortOsTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramSortOsTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramSortOsTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.telegramSortOsTb).Name = "telegramSortOsTb";
        ((GuiLib.AnimaTextBox)this.telegramSortOsTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramSortOsTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramSortOsTb).Size = new System.Drawing.Size(530, 44);
        ((System.Windows.Forms.Control)this.telegramSortOsTb).TabIndex = 358;
        ((GuiLib.AnimaTextBox)this.telegramSortOsTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.telegramFilesCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramFilesCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramFilesCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramFilesCb).Location = new System.Drawing.Point(306, 552);
        ((System.Windows.Forms.Control)this.telegramFilesCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramFilesCb).Name = "telegramFilesCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramFilesCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramFilesCb).TabIndex = 357;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFilesCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramFtpsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramFtpsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramFtpsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramFtpsCb).Location = new System.Drawing.Point(744, 550);
        ((System.Windows.Forms.Control)this.telegramFtpsCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramFtpsCb).Name = "telegramFtpsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramFtpsCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramFtpsCb).TabIndex = 356;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramFtpsCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).Location = new System.Drawing.Point(306, 508);
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).Name = "telegramAutoFillsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramAutoFillsCb).TabIndex = 355;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramAutoFillsCb).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.telegramCcsCb).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.telegramCcsCb).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.telegramCcsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.telegramCcsCb).Location = new System.Drawing.Point(744, 506);
        ((System.Windows.Forms.Control)this.telegramCcsCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramCcsCb).Name = "telegramCcsCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.telegramCcsCb).Size = new System.Drawing.Size(38, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).StyleManager = null;
        ((System.Windows.Forms.Control)this.telegramCcsCb).TabIndex = 354;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.telegramCcsCb).ThemeName = "MetroDark";
        ((GuiLib.AnimaTextBox)this.telegramSortCountryTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramSortCountryTb).Location = new System.Drawing.Point(252, 44);
        ((System.Windows.Forms.Control)this.telegramSortCountryTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramSortCountryTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramSortCountryTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.telegramSortCountryTb).Name = "telegramSortCountryTb";
        ((GuiLib.AnimaTextBox)this.telegramSortCountryTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramSortCountryTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramSortCountryTb).Size = new System.Drawing.Size(530, 44);
        ((System.Windows.Forms.Control)this.telegramSortCountryTb).TabIndex = 353;
        ((GuiLib.AnimaTextBox)this.telegramSortCountryTb).UseSystemPasswordChar = false;
        ((GuiLib.AnimaTextBox)this.telegramSortCookiesTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramSortCookiesTb).Location = new System.Drawing.Point(370, 271);
        ((System.Windows.Forms.Control)this.telegramSortCookiesTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramSortCookiesTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramSortCookiesTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.telegramSortCookiesTb).Name = "telegramSortCookiesTb";
        ((GuiLib.AnimaTextBox)this.telegramSortCookiesTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramSortCookiesTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramSortCookiesTb).Size = new System.Drawing.Size(412, 44);
        ((System.Windows.Forms.Control)this.telegramSortCookiesTb).TabIndex = 352;
        ((GuiLib.AnimaTextBox)this.telegramSortCookiesTb).UseSystemPasswordChar = false;
        ((GuiLib.AnimaTextBox)this.telegramSortPasswordsTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramSortPasswordsTb).Location = new System.Drawing.Point(370, 210);
        ((System.Windows.Forms.Control)this.telegramSortPasswordsTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramSortPasswordsTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramSortPasswordsTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.telegramSortPasswordsTb).Name = "telegramSortPasswordsTb";
        ((GuiLib.AnimaTextBox)this.telegramSortPasswordsTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramSortPasswordsTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramSortPasswordsTb).Size = new System.Drawing.Size(412, 44);
        ((System.Windows.Forms.Control)this.telegramSortPasswordsTb).TabIndex = 351;
        ((GuiLib.AnimaTextBox)this.telegramSortPasswordsTb).UseSystemPasswordChar = false;
        ((GuiLib.AnimaTextBox)this.telegramSortBuildIDTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramSortBuildIDTb).Location = new System.Drawing.Point(252, 98);
        ((System.Windows.Forms.Control)this.telegramSortBuildIDTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramSortBuildIDTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramSortBuildIDTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.telegramSortBuildIDTb).Name = "telegramSortBuildIDTb";
        ((GuiLib.AnimaTextBox)this.telegramSortBuildIDTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramSortBuildIDTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramSortBuildIDTb).Size = new System.Drawing.Size(530, 44);
        ((System.Windows.Forms.Control)this.telegramSortBuildIDTb).TabIndex = 350;
        ((GuiLib.AnimaTextBox)this.telegramSortBuildIDTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.panel2).Controls.Add((System.Windows.Forms.Control)this.telegramNoAttachCb);
        ((System.Windows.Forms.Control)this.panel2).Controls.Add((System.Windows.Forms.Control)this.telegramSendScreenshotCb);
        ((System.Windows.Forms.Control)this.panel2).Controls.Add((System.Windows.Forms.Control)this.telegramSendLogFileCb);
        ((System.Windows.Forms.Control)this.panel2).Location = new System.Drawing.Point(884, 550);
        ((System.Windows.Forms.Control)this.panel2).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.panel2).Name = "panel2";
        ((System.Windows.Forms.Control)this.panel2).Size = new System.Drawing.Size(698, 56);
        ((System.Windows.Forms.Control)this.panel2).TabIndex = 382;
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).AutoSize = true;
        ((System.Windows.Forms.RadioButton)this.telegramNoAttachCb).Checked = true;
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).Location = new System.Drawing.Point(466, 6);
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).Name = "telegramNoAttachCb";
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).Size = new System.Drawing.Size(216, 36);
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).TabIndex = 2;
        ((System.Windows.Forms.RadioButton)this.telegramNoAttachCb).TabStop = true;
        ((System.Windows.Forms.Control)this.telegramNoAttachCb).Text = "No attachments";
        ((System.Windows.Forms.ButtonBase)this.telegramNoAttachCb).UseVisualStyleBackColor = true;
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).AutoSize = true;
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).Location = new System.Drawing.Point(210, 6);
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).Name = "telegramSendScreenshotCb";
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).Size = new System.Drawing.Size(222, 36);
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).TabIndex = 1;
        ((System.Windows.Forms.RadioButton)this.telegramSendScreenshotCb).TabStop = true;
        ((System.Windows.Forms.Control)this.telegramSendScreenshotCb).Text = "Send screenshot";
        ((System.Windows.Forms.ButtonBase)this.telegramSendScreenshotCb).UseVisualStyleBackColor = true;
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).AutoSize = true;
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).Font = new System.Drawing.Font("Segoe UI", 9f);
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).Location = new System.Drawing.Point(10, 6);
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).Name = "telegramSendLogFileCb";
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).Size = new System.Drawing.Size(190, 36);
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).TabIndex = 0;
        ((System.Windows.Forms.RadioButton)this.telegramSendLogFileCb).TabStop = true;
        ((System.Windows.Forms.Control)this.telegramSendLogFileCb).Text = "Send Log File";
        ((System.Windows.Forms.ButtonBase)this.telegramSendLogFileCb).UseVisualStyleBackColor = true;
        ((GuiLib.AnimaTextBox)this.telegramBotFormatTb).Dark = false;
        ((System.Windows.Forms.Control)this.telegramBotFormatTb).Location = new System.Drawing.Point(794, 98);
        ((System.Windows.Forms.Control)this.telegramBotFormatTb).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((GuiLib.AnimaTextBox)this.telegramBotFormatTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.telegramBotFormatTb).MultiLine = true;
        ((System.Windows.Forms.Control)this.telegramBotFormatTb).Name = "telegramBotFormatTb";
        ((GuiLib.AnimaTextBox)this.telegramBotFormatTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.telegramBotFormatTb).ReadOnly = false;
        ((System.Windows.Forms.Control)this.telegramBotFormatTb).Size = new System.Drawing.Size(876, 446);
        ((System.Windows.Forms.Control)this.telegramBotFormatTb).TabIndex = 381;
        ((GuiLib.AnimaTextBox)this.telegramBotFormatTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.metroSetLabel4).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.metroSetLabel4).Location = new System.Drawing.Point(794, 44);
        ((System.Windows.Forms.Control)this.metroSetLabel4).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.metroSetLabel4).Name = "metroSetLabel4";
        ((System.Windows.Forms.Control)this.metroSetLabel4).Size = new System.Drawing.Size(228, 48);
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel4).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel4).StyleManager = null;
        ((System.Windows.Forms.Control)this.metroSetLabel4).TabIndex = 380;
        ((System.Windows.Forms.Control)this.metroSetLabel4).Text = "Message Format:";
        ((System.Windows.Forms.Label)this.metroSetLabel4).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel4).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetLabel)this.metroSetLabel4).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.label1).AutoSize = true;
        ((System.Windows.Forms.Control)this.label1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label1).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label1).Location = new System.Drawing.Point(42, 402);
        ((System.Windows.Forms.Control)this.label1).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label1).Name = "label1";
        ((System.Windows.Forms.Control)this.label1).Size = new System.Drawing.Size(240, 32);
        ((System.Windows.Forms.Control)this.label1).TabIndex = 383;
        ((System.Windows.Forms.Control)this.label1).Text = "Passwords more than";
        ((System.Windows.Forms.Control)this.passMoreThan).Location = new System.Drawing.Point(306, 400);
        ((System.Windows.Forms.Control)this.passMoreThan).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.NumericUpDown)this.passMoreThan).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
        ((System.Windows.Forms.NumericUpDown)this.passMoreThan).Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.passMoreThan).Name = "passMoreThan";
        ((System.Windows.Forms.Control)this.passMoreThan).Size = new System.Drawing.Size(88, 31);
        ((System.Windows.Forms.Control)this.passMoreThan).TabIndex = 384;
        ((System.Windows.Forms.NumericUpDown)this.passMoreThan).Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Location = new System.Drawing.Point(690, 400);
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        ((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
        ((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Name = "cookiesMoreThan";
        ((System.Windows.Forms.Control)this.cookiesMoreThan).Size = new System.Drawing.Size(88, 31);
        ((System.Windows.Forms.Control)this.cookiesMoreThan).TabIndex = 386;
        ((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
        ((System.Windows.Forms.Control)this.label2).AutoSize = true;
        ((System.Windows.Forms.Control)this.label2).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.label2).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.label2).Location = new System.Drawing.Point(426, 402);
        ((System.Windows.Forms.Control)this.label2).Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
        ((System.Windows.Forms.Control)this.label2).Name = "label2";
        ((System.Windows.Forms.Control)this.label2).Size = new System.Drawing.Size(217, 32);
        ((System.Windows.Forms.Control)this.label2).TabIndex = 385;
        ((System.Windows.Forms.Control)this.label2).Text = "Cookies more than";
        base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 25f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        base.Controls.Add((System.Windows.Forms.Control)this.cookiesMoreThan);
        base.Controls.Add((System.Windows.Forms.Control)this.label2);
        base.Controls.Add((System.Windows.Forms.Control)this.passMoreThan);
        base.Controls.Add((System.Windows.Forms.Control)this.label1);
        base.Controls.Add((System.Windows.Forms.Control)this.panel2);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramBotFormatTb);
        base.Controls.Add((System.Windows.Forms.Control)this.metroSetLabel4);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSortFilesTb);
        base.Controls.Add((System.Windows.Forms.Control)this.label62);
        base.Controls.Add((System.Windows.Forms.Control)this.label49);
        base.Controls.Add((System.Windows.Forms.Control)this.label51);
        base.Controls.Add((System.Windows.Forms.Control)this.label52);
        base.Controls.Add((System.Windows.Forms.Control)this.label55);
        base.Controls.Add((System.Windows.Forms.Control)this.label56);
        base.Controls.Add((System.Windows.Forms.Control)this.label59);
        base.Controls.Add((System.Windows.Forms.Control)this.a);
        base.Controls.Add((System.Windows.Forms.Control)this.b);
        base.Controls.Add((System.Windows.Forms.Control)this.c);
        base.Controls.Add((System.Windows.Forms.Control)this.d);
        base.Controls.Add((System.Windows.Forms.Control)this.e);
        base.Controls.Add((System.Windows.Forms.Control)this.f);
        base.Controls.Add((System.Windows.Forms.Control)this.label68);
        base.Controls.Add((System.Windows.Forms.Control)this.label69);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSteamCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramDesktopFilesCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSkipEmptyPassCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSkipEmptyCookiesCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramColdWalletsCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSortOsTb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramFilesCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramFtpsCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramAutoFillsCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramCcsCb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSortCountryTb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSortCookiesTb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSortPasswordsTb);
        base.Controls.Add((System.Windows.Forms.Control)this.telegramSortBuildIDTb);
        base.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
        base.Name = "TelegramBotSettingsControl";
        base.Size = new System.Drawing.Size(1714, 702);
        ((System.Windows.Forms.Control)this.panel2).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.panel2).PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.passMoreThan).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cookiesMoreThan).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}
