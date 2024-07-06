using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models.Shared;

public class UpdateRoot
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    public string version
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

    public List<UpdateFile> files
    {
        [CompilerGenerated]
        get
        {
            return (List<UpdateFile>)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public bool forceUpdate
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
}
