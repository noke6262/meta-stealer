using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetChatAdministratorCustomTitleRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private long long_0;

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

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
        [CompilerGenerated]
        set
        {
            long_0 = value;
        }
    }

    [JsonProperty("custom_title", Required = Required.Always)]
    public string CustomTitle
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    public SetChatAdministratorCustomTitleRequest(ChatId chatId, long userId, string customTitle)
        : base("setChatAdministratorCustomTitle")
    {
        object_0 = chatId;
        UserId = userId;
        object_1 = customTitle;
    }
}
