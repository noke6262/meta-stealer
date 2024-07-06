using System;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models;

public static class ProfileSettings
{
    [CompilerGenerated]
    private static object object_0;

    [CompilerGenerated]
    private static object object_1;

    [CompilerGenerated]
    private static object object_2;

    public static EventHandler<bool> OnCreatorStateChanged;

    public static EventHandler<bool> OnHeaderStateChanged;

    [CompilerGenerated]
    private static IntPtr intptr_0;

    [CompilerGenerated]
    private static IntPtr intptr_1;

    public static string Login
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

    public static string Password
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

    public static string Token
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

    public static bool CreatorActivated
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

    public static bool HeaderActivated
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_1 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)(value ? 1 : 0);
        }
    }

    static ProfileSettings()
    {
        OnCreatorStateChanged = (EventHandler<bool>)Delegate.Combine(OnCreatorStateChanged, (EventHandler<bool>)delegate (object a, bool b)
        {
            CreatorActivated = b;
        });
        OnHeaderStateChanged = (EventHandler<bool>)Delegate.Combine(OnHeaderStateChanged, (EventHandler<bool>)delegate (object a, bool b)
        {
            HeaderActivated = b;
        });
    }
}
