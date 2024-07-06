using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Meta.SharedModels;

public class TelegramChatsDb
{
    public object RootLocker = new object();

    public List<TelegramChatSettings> chatsSettings = new List<TelegramChatSettings>();

    private string SettingsFile => "telegramChatsSettings.json";

    public void LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsFile))
            {
                string text = File.ReadAllText(SettingsFile);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    JArray jArray = JArray.Parse(text);
                    chatsSettings = jArray.ToObject<List<TelegramChatSettings>>();
                }
            }
            else
            {
                SaveSettings();
            }
        }
        catch
        {
            SaveSettings();
        }
    }

    public void SaveSettings()
    {
        string contents = JsonConvert.SerializeObject(chatsSettings, Formatting.Indented);
        File.WriteAllText(SettingsFile, contents);
    }
}
