using System;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models.CryptorBiz;

public class FreeRecrypts
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    public string option_id
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

    public int duration_in_hours
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)value;
        }
    }

    public int seconds_left
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_1;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)value;
        }
    }
}
