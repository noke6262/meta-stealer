using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class MessageEntity
{
    [CompilerGenerated]
    private MessageEntityType messageEntityType_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [JsonProperty("type", Required = Required.Always)]
    public MessageEntityType Type
    {
        [CompilerGenerated]
        get
        {
            return messageEntityType_0;
        }
        [CompilerGenerated]
        set
        {
            messageEntityType_0 = value;
        }
    }

    [JsonProperty("offset", Required = Required.Always)]
    public int Offset
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

    [JsonProperty("length", Required = Required.Always)]
    public int Length
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

    [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Url
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

    [JsonProperty("user", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public User User
    {
        [CompilerGenerated]
        get
        {
            return (User)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    [JsonProperty("language", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Language
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
}
