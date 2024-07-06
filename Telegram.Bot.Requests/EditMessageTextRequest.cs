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
public class EditMessageTextRequest : RequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IFormattableTextMessage, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("message_id", Required = Required.Always)]
    public int MessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
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
            return (byte)(nint)intptr_1 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)(value ? 1 : 0);
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

    public EditMessageTextRequest(ChatId chatId, int messageId, string text)
        : base("editMessageText")
    {
        object_0 = chatId;
        intptr_0 = (IntPtr)messageId;
        object_1 = text;
    }
}
