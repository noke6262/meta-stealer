using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditMessageReplyMarkupRequest : RequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

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

    public EditMessageReplyMarkupRequest(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null)
        : base("editMessageReplyMarkup")
    {
        object_0 = chatId;
        intptr_0 = (IntPtr)messageId;
        ReplyMarkup = replyMarkup;
    }
}
