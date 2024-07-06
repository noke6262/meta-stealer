using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class DeleteChatStickerSetRequest : RequestBase<bool>
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

    public DeleteChatStickerSetRequest(ChatId chatId)
        : base("deleteChatStickerSet")
    {
        object_0 = chatId;
    }
}
