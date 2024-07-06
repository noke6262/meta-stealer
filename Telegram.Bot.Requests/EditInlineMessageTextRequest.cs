using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditInlineMessageTextRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IFormattableTextMessage, IInlineMessage, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_0;

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
    }

    [JsonProperty("text", Required = Required.Always)]
    public string Text
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
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

    [JsonProperty("entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[] Entities
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

    [JsonProperty("disable_web_page_preview", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableWebPagePreview
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)(value ? 1 : 0);
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

    public EditInlineMessageTextRequest(string inlineMessageId, string text)
        : base("editMessageText")
    {
        object_0 = inlineMessageId;
        object_1 = text;
    }
}
