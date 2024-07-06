using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetChatPermissionsRequest : RequestBase<bool>
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

    [JsonProperty("permissions", Required = Required.Always)]
    public ChatPermissions Permissions
    {
        [CompilerGenerated]
        get
        {
            return (ChatPermissions)object_1;
        }
    }

    public SetChatPermissionsRequest(ChatId chatId, ChatPermissions permissions)
        : base("setChatPermissions")
    {
        object_0 = chatId;
        object_1 = permissions;
    }
}
