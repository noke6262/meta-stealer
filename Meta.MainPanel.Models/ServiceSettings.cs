using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Models;

public class ServiceSettings
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [JsonIgnore]
    private object object_0 = new Random();

    public int Port
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

    public int GuestPort
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

    private string SettingsFile => "serviceSettings.json";

    public void LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsFile))
            {
                string text = File.ReadAllText(SettingsFile);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    ServiceSettings serviceSettings = JObject.Parse(text).ToObject<ServiceSettings>();
                    Port = serviceSettings.Port;
                    if (!text.Contains("GuestPort"))
                    {
                        GuestPort = ((Random)object_0).Next(1024, 49151);
                        SaveSettings();
                    }
                    else
                    {
                        GuestPort = serviceSettings.GuestPort;
                    }
                }
                else
                {
                    method_0();
                }
            }
            else
            {
                method_0();
                SaveSettings();
            }
        }
        catch
        {
            method_0();
        }
    }

    public void SaveSettings()
    {
        string contents = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(SettingsFile, contents);
    }

    private void method_0()
    {
        Port = ((Random)object_0).Next(1024, 49151);
        GuestPort = ((Random)object_0).Next(1024, 49151);
    }
}
