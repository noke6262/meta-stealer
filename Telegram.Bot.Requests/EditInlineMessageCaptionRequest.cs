using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditInlineMessageCaptionRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IFormattableMessage, IInlineMessage, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("inline_message_id", Required = Required.Always)]
    public string InlineMessageId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("caption", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Caption
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

    [JsonProperty("parse_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode ParseMode
    {
        [CompilerGenerated]
        get
        {
            return parseMode_0;
        }
        [CompilerGenerated]
        set
        {
            parseMode_0 = value;
        }
    }

    [JsonProperty("caption_entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[] CaptionEntities
    {
        [CompilerGenerated]
        get
        {
            return (MessageEntity[])object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (InlineKeyboardMarkup)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    public EditInlineMessageCaptionRequest(string inlineMessageId, string caption = null)
        : base("editMessageCaption")
    {
        InlineMessageId = inlineMessageId;
        Caption = caption;
    }
}
