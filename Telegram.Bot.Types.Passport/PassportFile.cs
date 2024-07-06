using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.Passport;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PassportFile : FileBase
{
    [CompilerGenerated]
    private DateTime dateTime_0;

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("file_date", Required = Required.Always)]
    public DateTime FileDate
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
