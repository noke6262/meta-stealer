using System.Diagnostics;

namespace Meta.MainPanel.Data.Extensions;

public static class ProcessExtensions
{
    private static object smethod_0(uint pid)
    {
        string processName = Process.GetProcessById((int)pid).ProcessName;
        Process[] processesByName = Process.GetProcessesByName(processName);
        string text = null;
        int num = 0;
        while (true)
        {
            if (num < processesByName.Length)
            {
                text = ((num == 0) ? processName : (processName + "#" + num));
                if ((int)new PerformanceCounter("Process", "ID Process", text).NextValue() == (int)pid)
                {
                    break;
                }
                num++;
                continue;
            }
            return text;
        }
        return text;
    }

    private static object smethod_1(object indexedProcessName)
    {
        return Process.GetProcessById((int)new PerformanceCounter("Process", "Creating Process ID", (string)indexedProcessName).NextValue());
    }

    public static Process Parent(this Process process)
    {
        return (Process)smethod_1(smethod_0((uint)process.Id));
    }
}
