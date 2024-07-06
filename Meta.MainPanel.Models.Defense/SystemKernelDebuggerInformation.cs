using System.Runtime.InteropServices;

namespace Meta.MainPanel.Models.Defense;

public struct SystemKernelDebuggerInformation
{
    [MarshalAs(UnmanagedType.U1)]
    public bool KernelDebuggerEnabled;

    [MarshalAs(UnmanagedType.U1)]
    public bool KernelDebuggerNotPresent;
}
