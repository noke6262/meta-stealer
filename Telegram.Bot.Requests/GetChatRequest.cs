using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Converters;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetChatRequest : RequestBase<Chat>
{
    [CompilerGenerated]
    private readonly object object_0;

    [JsonConverter(typeof(ChatIdConverter))]
    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    public GetChatRequest(ChatId chatId)
        : base("getChat")
    {
        object_0 = chatId;
    }
}
