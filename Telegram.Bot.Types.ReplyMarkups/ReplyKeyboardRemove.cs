using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ReplyKeyboardRemove : ReplyMarkupBase
{
    [JsonProperty("remove_keyboard", Required = Required.Always)]
    public bool RemoveKeyboard => true;
}
