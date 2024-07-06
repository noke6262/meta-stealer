using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultCachedSticker : InlineQueryResultBase, IInputMessageContentResult
{
    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("sticker_file_id", Required = Required.Always)]
    public string StickerFileId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("input_message_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    private InlineQueryResultCachedSticker()
        : base(InlineQueryResultType.Sticker)
    {
    }

    public InlineQueryResultCachedSticker(string id, string stickerFileId)
        : base(InlineQueryResultType.Sticker, id)
    {
        StickerFileId = stickerFileId;
    }
}
