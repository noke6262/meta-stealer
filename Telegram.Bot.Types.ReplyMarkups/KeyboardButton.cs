using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class KeyboardButton : IKeyboardButton
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("text", Required = Required.Always)]
    public string Text
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

    [JsonProperty("request_location", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool RequestLocation
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

    [JsonProperty("request_contact", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool RequestContact
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

    [JsonProperty("request_poll", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public KeyboardButtonPollType RequestPoll
    {
        [CompilerGenerated]
        get
        {
            return (KeyboardButtonPollType)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public KeyboardButton()
    {
    }

    public KeyboardButton(string text)
    {
        Text = text;
    }

    public static KeyboardButton WithRequestContact(string text)
    {
        return new KeyboardButton(text)
        {
            RequestContact = true
        };
    }

    public static KeyboardButton WithRequestLocation(string text)
    {
        return new KeyboardButton(text)
        {
            RequestLocation = true
        };
    }

    public static KeyboardButton WithRequestPoll(string text, string type = null)
    {
        return new KeyboardButton(text)
        {
            RequestPoll = new KeyboardButtonPollType
            {
                Type = type
            }
        };
    }

    public static implicit operator KeyboardButton(string text)
    {
        return new KeyboardButton(text);
    }
}
