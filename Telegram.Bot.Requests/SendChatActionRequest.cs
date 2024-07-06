using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendChatActionRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly ChatAction chatAction_0;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("action", Required = Required.Always)]
    public ChatAction Action
    {
        [CompilerGenerated]
        get
        {
            return chatAction_0;
        }
    }

    public SendChatActionRequest(ChatId chatId, ChatAction action)
        : base("sendChatAction")
    {
        object_0 = chatId;
        chatAction_0 = action;
    }
}
