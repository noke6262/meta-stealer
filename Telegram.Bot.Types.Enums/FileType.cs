using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum FileType
{
    [EnumMember(Value = "stream")]
    Stream,
    [EnumMember(Value = "id")]
    Id,
    [EnumMember(Value = "url")]
    Url
}
