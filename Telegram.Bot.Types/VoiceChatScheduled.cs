using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class VoiceChatScheduled
{
    [CompilerGenerated]
    private DateTime dateTime_0;

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("start_date", Required = Required.Always)]
    public DateTime StartDate
    {
        [CompilerGenerated]
        get
        {
            return dateTime_0;
        }
        [CompilerGenerated]
        set
        {
            dateTime_0 = value;
        }
    }
}
