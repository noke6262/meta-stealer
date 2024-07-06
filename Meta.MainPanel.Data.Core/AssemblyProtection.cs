using Meta.MainPanel.Data.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Meta.MainPanel.Data.Core;

public static class AssemblyProtection
{
    [Flags]
    private enum InternetConnectionState_e
    {
        INTERNET_CONNECTION_MODEM = 1,
        INTERNET_CONNECTION_LAN = 2,
        INTERNET_CONNECTION_PROXY = 4,
        INTERNET_RAS_INSTALLED = 0x10,
        INTERNET_CONNECTION_OFFLINE = 0x20,
        INTERNET_CONNECTION_CONFIGURED = 0x40
    }

    [DllImport("wininet.dll", CharSet = CharSet.Auto)]
    private static extern bool InternetGetConnectedState(ref InternetConnectionState_e lpdwFlags, int dwReserved);

    [DllImport("kernel32.dll")]
    private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

    [DllImport("kernel32.dll")]
    private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

    public static bool EthernetConnected()
    {
        try
        {
            InternetConnectionState_e lpdwFlags = (InternetConnectionState_e)0;
            bool flag = InternetGetConnectedState(ref lpdwFlags, 0);
            IPStatus iPStatus = IPStatus.Unknown;
            try
            {
                iPStatus = new Ping().Send("google.com").Status;
            }
            catch (Exception)
            {
            }
            return iPStatus == IPStatus.Success && flag;
        }
        catch
        {
            return false;
        }
    }

    public unsafe static void Initialize()
    {
        Module module = typeof(AssemblyProtection).Module;
        byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
        byte* ptr2 = ptr + 60;
        ptr2 = ptr + (uint)(*(int*)ptr2);
        ptr2 += 6;
        ushort num = *(ushort*)ptr2;
        ptr2 += 14;
        ushort num2 = *(ushort*)ptr2;
        ptr2 = ptr2 + 4 + (int)num2;
        byte* ptr3 = stackalloc byte[11];
        uint lpflOldProtect;
        if (module.FullyQualifiedName[0] != '<')
        {
            byte* ptr4 = ptr + (uint)(*(int*)(ptr2 - 16));
            if (*(uint*)(ptr2 - 120) != 0)
            {
                byte* ptr5 = ptr + (uint)(*(int*)(ptr2 - 120));
                byte* ptr6 = ptr + (uint)(*(int*)ptr5);
                byte* ptr7 = ptr + (uint)(*(int*)(ptr5 + 12));
                byte* ptr8 = ptr + (uint)(*(int*)ptr6) + 2;
                VirtualProtect(ptr7, 11, 64u, out lpflOldProtect);
                *(int*)ptr3 = 1818522734;
                *(int*)(ptr3 + 4) = 1818504812;
                *(short*)(ptr3 + (nint)4 * (nint)2) = 108;
                ptr3[10] = 0;
                for (int i = 0; i < 11; i++)
                {
                    ptr7[i] = ptr3[i];
                }
                VirtualProtect(ptr8, 11, 64u, out lpflOldProtect);
                *(int*)ptr3 = 1866691662;
                *(int*)(ptr3 + 4) = 1852404846;
                *(short*)(ptr3 + (nint)4 * (nint)2) = 25973;
                ptr3[10] = 0;
                for (int j = 0; j < 11; j++)
                {
                    ptr8[j] = ptr3[j];
                }
            }
            for (int k = 0; k < num; k++)
            {
                VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
                Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
                ptr2 += 40;
            }
            VirtualProtect(ptr4, 72, 64u, out lpflOldProtect);
            byte* ptr9 = ptr + (uint)(*(int*)(ptr4 + 8));
            *(int*)ptr4 = 0;
            *(int*)(ptr4 + 4) = 0;
            *(int*)(ptr4 + (nint)2 * (nint)4) = 0;
            *(int*)(ptr4 + (nint)3 * (nint)4) = 0;
            VirtualProtect(ptr9, 4, 64u, out lpflOldProtect);
            *(int*)ptr9 = 0;
            ptr9 += 12;
            ptr9 += (uint)(*(int*)ptr9);
            ptr9 = (byte*)(((ulong)ptr9 + 7uL) & 0xFFFFFFFFFFFFFFFCuL);
            ptr9 += 2;
            ushort num3 = *ptr9;
            ptr9 += 2;
            for (int l = 0; l < num3; l++)
            {
                VirtualProtect(ptr9, 8, 64u, out lpflOldProtect);
                ptr9 += 4;
                ptr9 += 4;
                for (int m = 0; m < 8; m++)
                {
                    VirtualProtect(ptr9, 4, 64u, out lpflOldProtect);
                    *ptr9 = 0;
                    ptr9++;
                    if (*ptr9 != 0)
                    {
                        *ptr9 = 0;
                        ptr9++;
                        if (*ptr9 != 0)
                        {
                            *ptr9 = 0;
                            ptr9++;
                            if (*ptr9 != 0)
                            {
                                *ptr9 = 0;
                                ptr9++;
                                continue;
                            }
                            ptr9++;
                            break;
                        }
                        ptr9 += 2;
                        break;
                    }
                    ptr9 += 3;
                    break;
                }
            }
            return;
        }
        uint num4 = *(uint*)(ptr2 - 16);
        uint num5 = *(uint*)(ptr2 - 120);
        uint[] array = new uint[num];
        uint[] array2 = new uint[num];
        uint[] array3 = new uint[num];
        for (int n = 0; n < num; n++)
        {
            VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
            Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
            array[n] = *(uint*)(ptr2 + 12);
            array2[n] = *(uint*)(ptr2 + 8);
            array3[n] = *(uint*)(ptr2 + 20);
            ptr2 += 40;
        }
        if (num5 != 0)
        {
            for (int num6 = 0; num6 < num; num6++)
            {
                if (array[num6] <= num5 && num5 < array[num6] + array2[num6])
                {
                    num5 = num5 - array[num6] + array3[num6];
                    break;
                }
            }
            byte* ptr10 = ptr + num5;
            uint num7 = *(uint*)ptr10;
            for (int num8 = 0; num8 < num; num8++)
            {
                if (array[num8] <= num7 && num7 < array[num8] + array2[num8])
                {
                    num7 = num7 - array[num8] + array3[num8];
                    break;
                }
            }
            byte* ptr11 = ptr + num7;
            uint num9 = *(uint*)(ptr10 + 12);
            for (int num10 = 0; num10 < num; num10++)
            {
                if (array[num10] <= num9 && num9 < array[num10] + array2[num10])
                {
                    num9 = num9 - array[num10] + array3[num10];
                    break;
                }
            }
            uint num11 = *(uint*)ptr11 + 2;
            for (int num12 = 0; num12 < num; num12++)
            {
                if (array[num12] <= num11 && num11 < array[num12] + array2[num12])
                {
                    num11 = num11 - array[num12] + array3[num12];
                    break;
                }
            }
            VirtualProtect(ptr + num9, 11, 64u, out lpflOldProtect);
            *(int*)ptr3 = 1818522734;
            *(int*)(ptr3 + 4) = 1818504812;
            *(short*)(ptr3 + (nint)4 * (nint)2) = 108;
            ptr3[10] = 0;
            for (int num13 = 0; num13 < 11; num13++)
            {
                (ptr + num9)[num13] = ptr3[num13];
            }
            VirtualProtect(ptr + num11, 11, 64u, out lpflOldProtect);
            *(int*)ptr3 = 1866691662;
            *(int*)(ptr3 + 4) = 1852404846;
            *(short*)(ptr3 + (nint)4 * (nint)2) = 25973;
            ptr3[10] = 0;
            for (int num14 = 0; num14 < 11; num14++)
            {
                (ptr + num11)[num14] = ptr3[num14];
            }
        }
        for (int num15 = 0; num15 < num; num15++)
        {
            if (array[num15] <= num4 && num4 < array[num15] + array2[num15])
            {
                num4 = num4 - array[num15] + array3[num15];
                break;
            }
        }
        byte* ptr12 = ptr + num4;
        VirtualProtect(ptr12, 72, 64u, out lpflOldProtect);
        uint num16 = *(uint*)(ptr12 + 8);
        for (int num17 = 0; num17 < num; num17++)
        {
            if (array[num17] <= num16 && num16 < array[num17] + array2[num17])
            {
                num16 = num16 - array[num17] + array3[num17];
                break;
            }
        }
        *(int*)ptr12 = 0;
        *(int*)(ptr12 + 4) = 0;
        *(int*)(ptr12 + (nint)2 * (nint)4) = 0;
        *(int*)(ptr12 + (nint)3 * (nint)4) = 0;
        byte* ptr13 = ptr + num16;
        VirtualProtect(ptr13, 4, 64u, out lpflOldProtect);
        *(int*)ptr13 = 0;
        ptr13 += 12;
        ptr13 += (uint)(*(int*)ptr13);
        ptr13 = (byte*)(((ulong)ptr13 + 7uL) & 0xFFFFFFFFFFFFFFFCuL);
        ptr13 += 2;
        ushort num18 = *ptr13;
        ptr13 += 2;
        for (int num19 = 0; num19 < num18; num19++)
        {
            VirtualProtect(ptr13, 8, 64u, out lpflOldProtect);
            ptr13 += 4;
            ptr13 += 4;
            for (int num20 = 0; num20 < 8; num20++)
            {
                VirtualProtect(ptr13, 4, 64u, out lpflOldProtect);
                *ptr13 = 0;
                ptr13++;
                if (*ptr13 != 0)
                {
                    *ptr13 = 0;
                    ptr13++;
                    if (*ptr13 != 0)
                    {
                        *ptr13 = 0;
                        ptr13++;
                        if (*ptr13 != 0)
                        {
                            *ptr13 = 0;
                            ptr13++;
                            continue;
                        }
                        ptr13++;
                        break;
                    }
                    ptr13 += 2;
                    break;
                }
                ptr13 += 3;
                break;
            }
        }
    }

    public static void CheckAssemblies()
    {
        try
        {
            foreach (string item in from x in AppDomain.CurrentDomain.GetAssemblies()
                                    select x.Location)
            {
                try
                {
                    if (new FileInfo(item).Name.Contains("System") && !AuthenticodeTools.IsTrusted(item, extraCheck: false, "Microsoft Corporation"))
                    {
                        EventLog.WriteEntry("Panel.exe", item, EventLogEntryType.Error);
                        Environment.Exit(0);
                    }
                }
                catch
                {
                }
            }
            if (!AuthenticodeTools.IsTrusted(Application.ExecutablePath, extraCheck: true, "RADOVAS UK LIMITED", "243878596697848E173A2FB8A9133117"))
            {
                Environment.Exit(0);
            }
        }
        catch (Exception)
        {
        }
    }
}
