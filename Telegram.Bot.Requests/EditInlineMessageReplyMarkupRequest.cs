using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditInlineMessageReplyMarkupRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineMessage, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("inline_message_id", Required = Required.Always)]
    public string InlineMessageId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (InlineKeyboardMarkup)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public EditInlineMessageReplyMarkupRequest(string inlineMessageId, InlineKeyboardMarkup replyMarkup = null)
        : base("editMessageReplyMarkup")
    {
        object_0 = inlineMessageId;
        ReplyMarkup = replyMarkup;
    }
}
