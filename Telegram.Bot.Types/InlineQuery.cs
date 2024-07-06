using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQuery
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private ChatType chatType_0;

    [CompilerGenerated]
    private object object_4;

    [JsonProperty("id", Required = Required.Always)]
    public string Id
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

    [JsonProperty("from", Required = Required.Always)]
    public User From
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

    [JsonProperty("query", Required = Required.Always)]
    public string Query
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

    [JsonProperty("offset", Required = Required.Always)]
    public string Offset
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("chat_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatType ChatType
    {
        [CompilerGenerated]
        get
        {
            return chatType_0;
        }
        [CompilerGenerated]
        set
        {
            chatType_0 = value;
        }
    }

    [JsonProperty("location", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Location Location
    {
        [CompilerGenerated]
        get
        {
            return (Location)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }
}
