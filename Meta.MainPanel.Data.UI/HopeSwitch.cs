using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Meta.MainPanel.Data.UI;

public class HopeSwitch : CheckBox
{
    private readonly object object_0 = new Timer
    {
        Interval = 1
    };

    private IntPtr intptr_0 = (IntPtr)3;

    [CompilerGenerated]
    private Color color_0 = Color.White;

    [CompilerGenerated]
    private Color color_1 = HopeColors.PrimaryColor;

    [CompilerGenerated]
    private Color color_2 = HopeColors.OneLevelBorder;

    public Color BaseColor
    {
        [CompilerGenerated]
        get
        {
            return color_0;
        }
        [CompilerGenerated]
        set
        {
            color_0 = value;
        }
    }

    public Color BaseOnColor
    {
        [CompilerGenerated]
        get
        {
            return color_1;
        }
        [CompilerGenerated]
        set
        {
            color_1 = value;
        }
    }

    public Color BaseOffColor
    {
        [CompilerGenerated]
        get
        {
            return color_2;
        }
        [CompilerGenerated]
        set
        {
            color_2 = value;
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ((Timer)object_0).Start();
    }

    protected override void OnResize(EventArgs e)
    {
        base.Height = 20;
        base.Width = 40;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        Graphics graphics = pevent.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        graphics.InterpolationMode = InterpolationMode.High;
        graphics.Clear(base.Parent.BackColor);
        GraphicsPath graphicsPath = new GraphicsPath();
        graphicsPath.AddArc(new RectangleF(0.5f, 0.5f, base.Height - 1, base.Height - 1), 90f, 180f);
        graphicsPath.AddArc(new RectangleF((float)(base.Width - base.Height) + 0.5f, 0.5f, base.Height - 1, base.Height - 1), 270f, 180f);
        graphicsPath.CloseAllFigures();
        graphics.FillPath(new SolidBrush(base.Checked ? BaseOnColor : BaseOffColor), graphicsPath);
        graphics.FillEllipse(new SolidBrush(BaseColor), new RectangleF((nint)intptr_0, 2f, 16f, 16f));
    }

    public HopeSwitch()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        DoubleBuffered = true;
        base.Height = 20;
        base.Width = 42;
        ((Timer)object_0).Tick += a;
        Cursor = Cursors.Hand;
    }

    private void a(object sender, object e)
    {
        if (base.Checked)
        {
            if ((nint)intptr_0 < 21)
            {
                intptr_0 += (nint)2;
                Invalidate();
            }
        }
        else if ((nint)intptr_0 > 3)
        {
            intptr_0 -= (nint)2;
            Invalidate();
        }
    }
}
