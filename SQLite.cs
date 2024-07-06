using System;
using System.Linq;
using System.Text;

public class SQLite
{
    private readonly object object_0;

    private readonly ulong ulong_0;

    private readonly object object_1;

    private readonly ulong ulong_1;

    public string[] Fields;

    private object object_2;

    private object object_3;

    public int RowLength => Count();

    public SQLite(byte[] fileName)
    {
        object_0 = "0123468800".Select((char x) => Convert.ToByte(x - 48)).ToArray();
        object_1 = fileName;
        ulong_1 = method_2(16u, 2u);
        ulong_0 = method_2(56u, 4u);
        method_0(100L);
    }

    public string GatherValue(int rowIndex, string fieldName)
    {
        try
        {
            int num = -1;
            int num2 = Fields.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (Fields[i].ToLower().Trim().CompareTo(fieldName.ToLower().Trim()) == 0)
                {
                    num = i;
                    break;
                }
            }
            if (num != -1)
            {
                return ReadContextValue(rowIndex, num);
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    private void method_0(long offset)
    {
        try
        {
            switch (((byte[])object_1)[offset])
            {
                case 13:
                    {
                        ulong num3 = method_2((uint)((int)offset + 3), 2u) - 1L;
                        int num4 = 0;
                        if (object_2 != null)
                        {
                            num4 = ((Array)object_2).Length;
                            object_2 = ChangeSize((SME[])object_2, ((Array)object_2).Length + (int)num3 + 1);
                        }
                        else
                        {
                            checked
                            {
                                object_2 = new SME[(ulong)unchecked((long)(num3 + 1L))];
                            }
                        }
                        for (ulong num5 = 0uL; num5 <= num3; num5++)
                        {
                            ulong num6 = method_2((uint)((int)offset + 8 + (int)num5 * 2), 2u);
                            if (offset != 100L)
                            {
                                num6 += (ulong)offset;
                            }
                            int num7 = (int)method_3((uint)num6);
                            a((uint)num6, (uint)num7);
                            int num8 = (int)method_3((uint)((long)num6 + ((long)num7 - (long)num6) + 1L));
                            a((uint)((long)num6 + ((long)num7 - (long)num6) + 1L), (uint)num8);
                            ulong num9 = num6 + (ulong)((long)num8 - (long)num6 + 1L);
                            int num10 = (int)method_3((uint)num9);
                            int num11 = num10;
                            long num12 = a((uint)num9, (uint)num10);
                            long[] array = new long[5];
                            for (int j = 0; j <= 4; j++)
                            {
                                int startIdx = num11 + 1;
                                num11 = (int)method_3((uint)startIdx);
                                array[j] = a((uint)startIdx, (uint)num11);
                                array[j] = ((array[j] <= 9L) ? ((byte[])object_0)[array[j]] : ((b(array[j]) == 0) ? ((array[j] - 12L) / 2L) : ((array[j] - 13L) / 2L)));
                            }
                            if (ulong_0 == 1L || ulong_0 == 2L)
                            {
                                if (ulong_0 != 1L)
                                {
                                    if (ulong_0 == 2L)
                                    {
                                        ((SME[])object_2)[num4 + (int)num5].ItemName = Encoding.Unicode.GetString((byte[])object_1, (int)((long)num9 + num12 + array[0]), (int)array[1]);
                                    }
                                    else if (ulong_0 == 3L)
                                    {
                                        ((SME[])object_2)[num4 + (int)num5].ItemName = Encoding.BigEndianUnicode.GetString((byte[])object_1, (int)((long)num9 + num12 + array[0]), (int)array[1]);
                                    }
                                }
                                else
                                {
                                    ((SME[])object_2)[num4 + (int)num5].ItemName = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString((byte[])object_1, (int)((long)num9 + num12 + array[0]), (int)array[1]);
                                }
                            }
                            ((SME[])object_2)[num4 + (int)num5].RootNum = (long)method_2((uint)((long)num9 + num12 + array[0] + array[1] + array[2]), (uint)array[3]);
                            if (ulong_0 == 1L)
                            {
                                ((SME[])object_2)[num4 + (int)num5].SqlStatement = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString((byte[])object_1, (int)((long)num9 + num12 + array[0] + array[1] + array[2] + array[3]), (int)array[4]);
                            }
                            else if (ulong_0 == 2L)
                            {
                                ((SME[])object_2)[num4 + (int)num5].SqlStatement = Encoding.Unicode.GetString((byte[])object_1, (int)((long)num9 + num12 + array[0] + array[1] + array[2] + array[3]), (int)array[4]);
                            }
                            else if (ulong_0 == 3L)
                            {
                                ((SME[])object_2)[num4 + (int)num5].SqlStatement = Encoding.BigEndianUnicode.GetString((byte[])object_1, (int)((long)num9 + num12 + array[0] + array[1] + array[2] + array[3]), (int)array[4]);
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        uint num = (uint)(method_2((uint)((int)offset + 3), 2u) - 1L);
                        for (int i = 0; i <= (int)num; i++)
                        {
                            uint num2 = (uint)method_2((uint)((int)offset + 12 + i * 2), 2u);
                            if (offset != 100L)
                            {
                                method_0((long)((method_2((uint)(offset + num2), 4u) - 1L) * ulong_1));
                            }
                            else
                            {
                                method_0((long)((method_2(num2, 4u) - 1L) * ulong_1));
                            }
                        }
                        method_0((long)((method_2((uint)((int)offset + 8), 4u) - 1L) * ulong_1));
                        break;
                    }
            }
        }
        catch
        {
        }
    }

    public bool ReadContextTable(string tableName)
    {
        try
        {
            int num = -1;
            for (int i = 0; i <= ((Array)object_2).Length; i++)
            {
                if (string.Compare(((SME[])object_2)[i].ItemName.ToLower(), tableName.ToLower(), StringComparison.Ordinal) == 0)
                {
                    num = i;
                    break;
                }
            }
            if (num != -1)
            {
                string[] array = ((SME[])object_2)[num].SqlStatement.Substring(((SME[])object_2)[num].SqlStatement.IndexOf('(') + 1).Split(',');
                for (int j = 0; j <= array.Length - 1; j++)
                {
                    array[j] = array[j].TrimStart();
                    int num2 = array[j].IndexOf(' ');
                    if (num2 > 0)
                    {
                        array[j] = array[j].Substring(0, num2);
                    }
                    if (array[j].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
                    {
                        Fields = ChangeSize(Fields, j + 1);
                        Fields[j] = array[j];
                    }
                }
                return (byte)method_1((ulong)(((SME[])object_2)[num].RootNum - 1L) * ulong_1) != 0;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    private uint method_1(ulong offset)
    {
        try
        {
            if (((byte[])object_1)[offset] == 13)
            {
                uint num = (uint)(method_2((uint)((int)offset + 3), 2u) - 1L);
                if (num == uint.MaxValue)
                {
                    return 0u;
                }
                int num2 = 0;
                if (object_3 != null)
                {
                    num2 = ((Array)object_3).Length;
                    object_3 = ChangeSize((GStruct0[])object_3, ((Array)object_3).Length + (int)num + 1);
                }
                else
                {
                    object_3 = new GStruct0[num + 1];
                }
                for (uint num3 = 0u; (int)num3 <= (int)num; num3++)
                {
                    ulong num4 = method_2((uint)((int)offset + 8) + num3 * 2, 2u);
                    if (offset != 100L)
                    {
                        num4 += offset;
                    }
                    int num5 = (int)method_3((uint)num4);
                    a((uint)num4, (uint)num5);
                    int num6 = (int)method_3((uint)((long)num4 + ((long)num5 - (long)num4) + 1L));
                    a((uint)((long)num4 + ((long)num5 - (long)num4) + 1L), (uint)num6);
                    ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
                    int num8 = (int)method_3((uint)num7);
                    int num9 = num8;
                    long num10 = a((uint)num7, (uint)num8);
                    RecordHeaderField[] array = null;
                    long num11 = (long)num7 - (long)num8 + 1L;
                    int num12 = 0;
                    while (num11 < num10)
                    {
                        array = ChangeSize(array, num12 + 1);
                        int num13 = num9 + 1;
                        num9 = (int)method_3((uint)num13);
                        array[num12].Type = a((uint)num13, (uint)num9);
                        array[num12].Size = ((array[num12].Type <= 9L) ? ((byte[])object_0)[array[num12].Type] : ((b(array[num12].Type) == 0) ? ((array[num12].Type - 12L) / 2L) : ((array[num12].Type - 13L) / 2L)));
                        num11 = num11 + (num9 - num13) + 1L;
                        num12++;
                    }
                    if (array == null)
                    {
                        continue;
                    }
                    ((GStruct0[])object_3)[num2 + (int)num3].Content = new string[array.Length];
                    int num14 = 0;
                    for (int i = 0; i <= array.Length - 1; i++)
                    {
                        if (array[i].Type > 9L)
                        {
                            if (b(array[i].Type) != 0)
                            {
                                ((GStruct0[])object_3)[num2 + (int)num3].Content[i] = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString((byte[])object_1, (int)((long)num7 + num10 + num14), (int)array[i].Size);
                            }
                            else if (ulong_0 == 1L)
                            {
                                ((GStruct0[])object_3)[num2 + (int)num3].Content[i] = Encoding.GetEncoding("wiArrayndows-12Array51".Replace("Array", string.Empty)).GetString((byte[])object_1, (int)((long)num7 + num10 + num14), (int)array[i].Size);
                            }
                            else if (ulong_0 == 2L)
                            {
                                ((GStruct0[])object_3)[num2 + (int)num3].Content[i] = Encoding.Unicode.GetString((byte[])object_1, (int)((long)num7 + num10 + num14), (int)array[i].Size);
                            }
                            else if (ulong_0 == 3L)
                            {
                                ((GStruct0[])object_3)[num2 + (int)num3].Content[i] = Encoding.BigEndianUnicode.GetString((byte[])object_1, (int)((long)num7 + num10 + num14), (int)array[i].Size);
                            }
                        }
                        else
                        {
                            ((GStruct0[])object_3)[num2 + (int)num3].Content[i] = Convert.ToString(method_2((uint)((long)num7 + num10 + num14), (uint)array[i].Size));
                        }
                        num14 += (int)array[i].Size;
                    }
                }
            }
            else if (((byte[])object_1)[offset] == 5)
            {
                uint num15 = (uint)(method_2((uint)(offset + 3L), 2u) - 1L);
                for (uint num16 = 0u; (int)num16 <= (int)num15; num16++)
                {
                    uint num17 = (uint)method_2((uint)((int)offset + 12) + num16 * 2, 2u);
                    method_1((method_2((uint)(offset + num17), 4u) - 1L) * ulong_1);
                }
                method_1((method_2((uint)(offset + 8L), 4u) - 1L) * ulong_1);
            }
            return 1u;
        }
        catch
        {
            return 0u;
        }
    }

    public string ReadContextValue(int rowNum, int field)
    {
        try
        {
            if (rowNum >= ((Array)object_3).Length)
            {
                return null;
            }
            return (field >= ((GStruct0[])object_3)[rowNum].Content.Length) ? null : ((GStruct0[])object_3)[rowNum].Content[field];
        }
        catch
        {
            return "";
        }
    }

    private ulong method_2(uint startIndex, uint size)
    {
        try
        {
            if ((int)size > 8 || size == 0)
            {
                return 0uL;
            }
            ulong num = 0uL;
            for (int i = 0; i <= (int)(size - 1); i++)
            {
                num = (num << 8) | ((byte[])object_1)[(int)startIndex + i];
            }
            return num;
        }
        catch
        {
            return 0uL;
        }
    }

    public int Count()
    {
        return ((Array)object_3).Length;
    }

    private uint method_3(uint startIdx)
    {
        try
        {
            if ((int)startIdx > ((Array)object_1).Length)
            {
                return 0u;
            }
            for (int i = (int)startIdx; i <= (int)(startIdx + 8); i++)
            {
                if (i <= ((Array)object_1).Length - 1)
                {
                    if ((((byte[])object_1)[i] & 0x80) != 128)
                    {
                        return (uint)i;
                    }
                    continue;
                }
                return 0u;
            }
            return startIdx + 8;
        }
        catch
        {
            return 0u;
        }
    }

    private long a(uint startIdx, uint endIdx)
    {
        try
        {
            endIdx++;
            byte[] array = new byte[8];
            int num = (int)(endIdx - startIdx);
            bool flag = false;
            if (!(num == 0 || num > 9))
            {
                if (num != 1)
                {
                    if (num == 9)
                    {
                        flag = true;
                    }
                    int num2 = 1;
                    int num3 = 7;
                    int num4 = 0;
                    if (flag)
                    {
                        array[0] = ((byte[])object_1)[endIdx - 1];
                        endIdx--;
                        num4 = 1;
                    }
                    for (int i = (int)(endIdx - 1); i >= (int)startIdx; i += -1)
                    {
                        if (i - 1 >= (int)startIdx)
                        {
                            array[num4] = (byte)(((((byte[])object_1)[i] >> num2 - 1) & (255 >> num2)) | (((byte[])object_1)[i - 1] << num3));
                            num2++;
                            num4++;
                            num3--;
                        }
                        else if (!flag)
                        {
                            array[num4] = (byte)((((byte[])object_1)[i] >> num2 - 1) & (255 >> num2));
                        }
                    }
                    return BitConverter.ToInt64(array, 0);
                }
                array[0] = (byte)(((byte[])object_1)[startIdx] & 0x7Fu);
                return BitConverter.ToInt64(array, 0);
            }
            return 0L;
        }
        catch
        {
            return 0L;
        }
    }

    private static uint b(long value)
    {
        return ((value & 1L) == 1L) ? 1u : 0u;
    }

    public static T[] ChangeSize<T>(T[] oldArray, int newSize)
    {
        T[] array = oldArray;
        Array.Resize(ref array, newSize);
        return array;
    }
}
