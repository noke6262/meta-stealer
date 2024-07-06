using Meta.SharedModels;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Meta.MainPanel.Data.UI;

public class PartnerPoster : UserControl
{
    private object object_0;

    private object object_1;

    private object postImage;

    private object partnerName;

    private object openPartnerLinkBtn;

    public PartnerPoster()
    {
        InitializeComponent();
    }

    public void SetPoster(AdvertItem advertItem)
    {
        if (advertItem == null)
        {
            ((Control)partnerName).Text = string.Empty;
            ((Control)openPartnerLinkBtn).Visible = false;
            ((PictureBox)postImage).ImageLocation = null;
            ((PictureBox)postImage).Image = null;
            ((Control)postImage).Visible = false;
            return;
        }
        object_0 = advertItem;
        try
        {
            ((Control)partnerName).Text = advertItem.Name;
            ((Control)openPartnerLinkBtn).Visible = true;
            ((Control)postImage).Visible = true;
            if (string.IsNullOrWhiteSpace(advertItem.ImageLink))
            {
                ((PictureBox)postImage).ImageLocation = null;
                ((PictureBox)postImage).Image = null;
            }
            else
            {
                ((PictureBox)postImage).ImageLocation = advertItem.ImageLink;
            }
        }
        catch (Exception)
        {
        }
    }

    private void openPartnerLinkBtn_Click(object sender, object e)
    {
        if (object_0 != null)
        {
            Process.Start(((AdvertItem)object_0).Link);
        }
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
        this.postImage = new System.Windows.Forms.PictureBox();
        this.partnerName = new System.Windows.Forms.Label();
        this.openPartnerLinkBtn = new MetroSet_UI.Controls.MetroSetButton();
        ((System.ComponentModel.ISupportInitialize)this.postImage).BeginInit();
        base.SuspendLayout();
        ((System.Windows.Forms.PictureBox)this.postImage).Image = Meta.MainPanel.Properties.Resources._250_x_250;
        ((System.Windows.Forms.Control)this.postImage).Location = new System.Drawing.Point(0, 27);
        ((System.Windows.Forms.Control)this.postImage).Name = "postImage";
        ((System.Windows.Forms.Control)this.postImage).Size = new System.Drawing.Size(250, 250);
        ((System.Windows.Forms.PictureBox)this.postImage).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        ((System.Windows.Forms.PictureBox)this.postImage).TabIndex = 0;
        ((System.Windows.Forms.PictureBox)this.postImage).TabStop = false;
        ((System.Windows.Forms.Control)this.partnerName).Font = new System.Drawing.Font("Segoe UI", 10f);
        ((System.Windows.Forms.Control)this.partnerName).ForeColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.partnerName).Location = new System.Drawing.Point(0, 1);
        ((System.Windows.Forms.Control)this.partnerName).Name = "partnerName";
        ((System.Windows.Forms.Control)this.partnerName).Size = new System.Drawing.Size(250, 24);
        ((System.Windows.Forms.Control)this.partnerName).TabIndex = 379;
        ((System.Windows.Forms.Label)this.partnerName).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).DisabledForeColor = System.Drawing.Color.Gray;
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).HoverTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Location = new System.Drawing.Point(90, 280);
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Name = "openPartnerLinkBtn";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).NormalTextColor = System.Drawing.Color.White;
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).PressTextColor = System.Drawing.Color.White;
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Size = new System.Drawing.Size(70, 23);
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).Style = MetroSet_UI.Design.Style.Light;
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).StyleManager = null;
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).TabIndex = 380;
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Text = "Open link";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).ThemeAuthor = "Narwin";
        ((MetroSet_UI.Controls.MetroSetButton)this.openPartnerLinkBtn).ThemeName = "MetroLite";
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Visible = false;
        ((System.Windows.Forms.Control)this.openPartnerLinkBtn).Click += new System.EventHandler(openPartnerLinkBtn_Click);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
        this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
        base.Controls.Add((System.Windows.Forms.Control)this.openPartnerLinkBtn);
        base.Controls.Add((System.Windows.Forms.Control)this.partnerName);
        base.Controls.Add((System.Windows.Forms.Control)this.postImage);
        base.Name = "PartnerPoster";
        base.Size = new System.Drawing.Size(250, 306);
        ((System.ComponentModel.ISupportInitialize)this.postImage).EndInit();
        base.ResumeLayout(false);
    }
}