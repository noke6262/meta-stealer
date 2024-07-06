using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetChatTitleRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("title", Required = Required.Always)]
    public string Title
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    public SetChatTitleRequest(ChatId chatId, string title)
        : base("setChatTitle")
    {
        object_0 = chatId;
        object_1 = title;
    }
}
