using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ParseMode
{
    [EnumMember(Value = "default")]
    Default,
    [EnumMember(Value = "markdown")]
    Markdown,
    [EnumMember(Value = "html")]
    Html,
    [EnumMember(Value = "markdownv2")]
    MarkdownV2
}
