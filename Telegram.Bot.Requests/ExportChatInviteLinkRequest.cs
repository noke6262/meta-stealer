using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ExportChatInviteLinkRequest : RequestBase<string>
{
    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    public ExportChatInviteLinkRequest(ChatId chatId)
        : base("exportChatInviteLink")
    {
        object_0 = chatId;
    }
}
