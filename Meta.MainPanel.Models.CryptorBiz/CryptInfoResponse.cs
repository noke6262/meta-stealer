using System;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models.CryptorBiz;

public class CryptInfoResponse
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private double double_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    public string result
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

    public double balance
    {
        [CompilerGenerated]
        get
        {
            return double_0;
        }
        [CompilerGenerated]
        set
        {
            double_0 = value;
        }
    }

    public string task_id
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

    public string status
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

    public int duration
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

    public int paid_at
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

    public InputFile input_file
    {
        [CompilerGenerated]
        get
        {
            return (InputFile)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    public CryptedFile crypted_file
    {
        [CompilerGenerated]
        get
        {
            return (CryptedFile)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    public FreeRecrypts free_recrypts
    {
        [CompilerGenerated]
        get
        {
            return (FreeRecrypts)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }
}
