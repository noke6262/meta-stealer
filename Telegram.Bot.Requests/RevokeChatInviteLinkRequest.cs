using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class RevokeChatInviteLinkRequest : RequestBase<ChatInviteLink>
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

    [JsonProperty("invite_link", Required = Required.Always)]
    public string InviteLink
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    public RevokeChatInviteLinkRequest(ChatId chatId, string inviteLink)
        : base("revokeChatInviteLink")
    {
        object_0 = chatId;
        object_1 = inviteLink;
    }
}
