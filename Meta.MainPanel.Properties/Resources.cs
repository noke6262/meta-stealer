using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
internal class Resources
{
    private static object object_0;

    private static object object_1;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
        get
        {
            if (object_0 == null)
            {
                object_0 = new ResourceManager("Meta.MainPanel.Properties.Resources", typeof(Resources).Assembly);
            }
            return (ResourceManager)object_0;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
        set
        {
            object_1 = value;
        }
    }

    internal static Bitmap _250_x_250 => (Bitmap)ResourceManager.GetObject("_250_x_250", (CultureInfo)object_1);

    internal static Bitmap icons8_cookies_80 => (Bitmap)ResourceManager.GetObject("icons8_cookies_80", (CultureInfo)object_1);

    internal static Bitmap icons8_password_100 => (Bitmap)ResourceManager.GetObject("icons8_password_100", (CultureInfo)object_1);

    internal static Bitmap icons8_spreadsheet_file_64 => (Bitmap)ResourceManager.GetObject("icons8_spreadsheet_file_64", (CultureInfo)object_1);

    internal static Bitmap logotype_dyncheck_com_beta => (Bitmap)ResourceManager.GetObject("logotype_dyncheck_com_beta", (CultureInfo)object_1);

    internal static Bitmap meta_1 => (Bitmap)ResourceManager.GetObject("meta_1", (CultureInfo)object_1);

    internal static Bitmap meta_2 => (Bitmap)ResourceManager.GetObject("meta_2", (CultureInfo)object_1);

    internal static Bitmap meta_3 => (Bitmap)ResourceManager.GetObject("meta_3", (CultureInfo)object_1);

    internal static byte[] Meta_Updater => (byte[])ResourceManager.GetObject("Meta_Updater", (CultureInfo)object_1);

    internal static byte[] raw => (byte[])ResourceManager.GetObject("raw", (CultureInfo)object_1);

    internal static Bitmap telegram => (Bitmap)ResourceManager.GetObject("telegram", (CultureInfo)object_1);

    internal Resources()
    {
    }
}
