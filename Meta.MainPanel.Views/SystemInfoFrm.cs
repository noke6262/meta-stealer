using Meta.MainPanel.Data.Extensions;
using Meta.MainPanel.LogExt;
using Meta.SharedModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meta.MainPanel.Views;

public class SystemInfoFrm : Form
{
    private object object_0;

    private object topHeader;

    private object mainTitle;

    private object closeBtn;

    private object screenshotPb;

    private object systemInfoRtb;

    public SystemInfoFrm(UserLog user)
    {
        InitializeComponent();
        this.AllowDraggBy((Control)topHeader);
        this.ApplyShadows();
        try
        {
            byte[] screenshot = user.Screenshot;
            if (screenshot != null && screenshot.Length != 0)
            {
                using MemoryStream stream = new MemoryStream(user.Screenshot);
                ((PictureBox)screenshotPb).Image = Image.FromStream(stream);
            }
            ((Control)systemInfoRtb).Text = (string)method_0(user);
        }
        catch
        {
        }
        user = default(UserLog);
    }

    private object method_0(UserLog ClientInformation)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Action item2 in new List<Action>
        {
            delegate
            {
                sb.Append("Build ID: ").AppendLine(ClientInformation.BuildID.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("IP: ").AppendLine(ClientInformation.IP.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("UserName: ").AppendLine(ClientInformation.Username.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("MachineName: ").AppendLine(ClientInformation.MachineName);
            },
            delegate
            {
                sb.Append("Country: ").AppendLine(ClientInformation.Country.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("Zip Code: ").AppendLine(ClientInformation.PostalCode.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("Location: ").AppendLine(ClientInformation.Location.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("HWID: ").AppendLine(ClientInformation.HWID.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("Current Language: ").AppendLine(ClientInformation.CurrentLanguage.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("ScreenSize: ").AppendLine(ClientInformation.MonitorSize.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("TimeZone: ").AppendLine(ClientInformation.TimeZone.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("Operation System: ").AppendLine(ClientInformation.OS.IsNull("UNKNOWN"));
            },
            delegate
            {
                sb.Append("Log date: ").AppendLine(ClientInformation.LogDate.ToString());
            },
            delegate
            {
                IList<string> languages = ClientInformation.Credentials.Languages;
                if (languages != null && languages.Count > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("Available KeyboardLayouts: ");
                    foreach (string language in ClientInformation.Credentials.Languages)
                    {
                        sb.AppendLine(language);
                    }
                    sb.AppendLine();
                }
            },
            delegate
            {
                IList<Hardware> hardwares = ClientInformation.Credentials.Hardwares;
                if (hardwares != null && hardwares.Count > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("Hardwares: ");
                    foreach (string item in ClientInformation.Credentials.Hardwares.Select((Hardware x) => x.ToString()))
                    {
                        sb.AppendLine(item);
                    }
                    sb.AppendLine();
                }
            },
            delegate
            {
                IList<string> defenders = ClientInformation.Credentials.Defenders;
                if (defenders != null && defenders.Count > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("Anti-Viruses: ");
                    foreach (string defender in ClientInformation.Credentials.Defenders)
                    {
                        sb.AppendLine(defender);
                    }
                }
            }
        })
        {
            try
            {
                item2();
            }
            catch
            {
            }
        }
        return sb.ToString();
    }

    private void closeBtn_Click(object sender, object e)
    {
        Close();
    }

    private void SystemInfoFrm_Paint(object sender, object e)
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meta.MainPanel.Views.SystemInfoFrm));
        this.topHeader = new System.Windows.Forms.Panel();
        this.mainTitle = new System.Windows.Forms.Label();
        this.closeBtn = new System.Windows.Forms.Label();
        this.screenshotPb = new System.Windows.Forms.PictureBox();
        this.systemInfoRtb = new System.Windows.Forms.RichTextBox();
        ((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.screenshotPb).BeginInit();
        base.SuspendLayout();
        ((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
        ((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
        ((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
        ((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
        ((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(1367, 30);
        ((System.Windows.Forms.Control)this.topHeader).TabIndex = 3;
        ((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
        ((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
        ((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.FromArgb(64, 224, 208);
        ((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
        ((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
        ((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(181, 20);
        ((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
        ((System.Windows.Forms.Control)this.mainTitle).Text = "Meta | System Info Viewer";
        ((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
        ((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(1344, 4);
        ((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
        ((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
        ((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
        ((System.Windows.Forms.Control)this.closeBtn).Text = "X";
        ((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
        ((System.Windows.Forms.Control)this.screenshotPb).Location = new System.Drawing.Point(7, 36);
        ((System.Windows.Forms.Control)this.screenshotPb).Name = "screenshotPb";
        ((System.Windows.Forms.Control)this.screenshotPb).Size = new System.Drawing.Size(950, 615);
        ((System.Windows.Forms.PictureBox)this.screenshotPb).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        ((System.Windows.Forms.PictureBox)this.screenshotPb).TabIndex = 4;
        ((System.Windows.Forms.PictureBox)this.screenshotPb).TabStop = false;
        ((System.Windows.Forms.Control)this.systemInfoRtb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.TextBoxBase)this.systemInfoRtb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        ((System.Windows.Forms.Control)this.systemInfoRtb).ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.Control)this.systemInfoRtb).Location = new System.Drawing.Point(963, 36);
        ((System.Windows.Forms.Control)this.systemInfoRtb).Name = "systemInfoRtb";
        ((System.Windows.Forms.TextBoxBase)this.systemInfoRtb).ReadOnly = true;
        ((System.Windows.Forms.RichTextBox)this.systemInfoRtb).ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        ((System.Windows.Forms.Control)this.systemInfoRtb).Size = new System.Drawing.Size(392, 615);
        ((System.Windows.Forms.Control)this.systemInfoRtb).TabIndex = 5;
        ((System.Windows.Forms.Control)this.systemInfoRtb).Text = "";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        base.ClientSize = new System.Drawing.Size(1367, 665);
        base.Controls.Add((System.Windows.Forms.Control)this.systemInfoRtb);
        base.Controls.Add((System.Windows.Forms.Control)this.screenshotPb);
        base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "SystemInfoFrm";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Meta | System Info Viewer";
        base.Paint += new System.Windows.Forms.PaintEventHandler(SystemInfoFrm_Paint);
        ((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.topHeader).PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.screenshotPb).EndInit();
        base.ResumeLayout(false);
    }
}
