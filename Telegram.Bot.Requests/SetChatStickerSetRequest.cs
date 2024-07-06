using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetChatStickerSetRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

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

    [JsonProperty("sticker_set_name", Required = Required.Always)]
    public string StickerSetName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public SetChatStickerSetRequest(ChatId chatId, string stickerSetName)
        : base("setChatStickerSet")
    {
        ChatId = chatId;
        StickerSetName = stickerSetName;
    }
}
