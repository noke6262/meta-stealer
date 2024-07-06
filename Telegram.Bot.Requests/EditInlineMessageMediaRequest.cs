using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditInlineMessageMediaRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineMessage, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private object object_2;

    [JsonProperty("inline_message_id", Required = Required.Always)]
    public string InlineMessageId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("media", Required = Required.Always)]
    public InputMediaBase Media
    {
        [CompilerGenerated]
        get
        {
            return (InputMediaBase)object_1;
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (InlineKeyboardMarkup)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    public EditInlineMessageMediaRequest(string inlineMessageId, InputMediaBase media)
        : base("editMessageMedia")
    {
        object_0 = inlineMessageId;
        object_1 = media;
    }
}
