using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models.CryptorBiz;

public class CryptedFile
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private object object_4;

    public string name
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

    public int size
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

    public string md5
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public int created_at
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

    public int scanned_at
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_2;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)value;
        }
    }

    public string scan_result
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    public string scan_link
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    public int scanned_av_count
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_3;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)value;
        }
    }

    public List<object> detection
    {
        [CompilerGenerated]
        get
        {
            return (List<object>)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }
}
