using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditMessageMediaRequest : FileRequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private object object_2;

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

    [JsonProperty("media", Required = Required.Always)]
    public InputMediaBase Media
    {
        [CompilerGenerated]
        get
        {
            return (InputMediaBase)object_1;
        }
    }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
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

    public EditMessageMediaRequest(ChatId chatId, int messageId, InputMediaBase media)
        : base("editMessageMedia")
    {
        object_0 = chatId;
        intptr_0 = (IntPtr)messageId;
        object_1 = media;
    }

    public override HttpContent ToHttpContent()
    {
        MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent();
        multipartFormDataContent.smethod_2(Media);
        return multipartFormDataContent;
    }
}
