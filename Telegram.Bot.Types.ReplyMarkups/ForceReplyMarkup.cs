using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ForceReplyMarkup : ReplyMarkupBase
{
    [JsonProperty("force_reply", Required = Required.Always)]
    public bool ForceReply => true;
}
