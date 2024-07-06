using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UnpinAllChatMessagesRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private object object_0;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    public UnpinAllChatMessagesRequest(ChatId chatId)
        : base("unpinAllChatMessage")
    {
        ChatId = chatId;
    }
}
