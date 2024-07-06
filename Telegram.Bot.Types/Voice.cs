using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Voice : FileBase
{
    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object object_2;

    [JsonProperty("duration", Required = Required.Always)]
    public int Duration
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

    [JsonProperty("mime_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MimeType
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
