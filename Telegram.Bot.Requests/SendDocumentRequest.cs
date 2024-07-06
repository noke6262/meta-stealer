using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendDocumentRequest : FileRequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, IFormattableMessage, INotifiableMessage, IReplyMessage, IThumbMediaMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private object a;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("document", Required = Required.Always)]
    public InputOnlineFile Document
    {
        [CompilerGenerated]
        get
        {
            return (InputOnlineFile)object_1;
        }
    }

    [JsonProperty("caption", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Caption
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

    [JsonProperty("thumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMedia Thumb
    {
        [CompilerGenerated]
        get
        {
            return (InputMedia)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
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
            return (MessageEntity[])object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("disable_content_type_detection", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableContentTypeDetection
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

    [JsonProperty("reply_to_message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ReplyToMessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_1;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)value;
        }
    }

    [JsonProperty("allow_sending_without_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowSendingWithoutReply
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_2 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_3 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IReplyMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (IReplyMarkup)a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    public SendDocumentRequest(ChatId chatId, InputOnlineFile document)
        : base("sendDocument")
    {
        object_0 = chatId;
        object_1 = document;
    }

    public override HttpContent ToHttpContent()
    {
        if (Document.FileType != 0)
        {
            InputMedia thumb = Thumb;
            if (thumb == null || thumb.FileType != 0)
            {
                return base.ToHttpContent();
            }
        }
        MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent("document", "thumb");
        if (Document.FileType == FileType.Stream)
        {
            multipartFormDataContent.smethod_1(Document.Content, "document", Document.FileName);
        }
        InputMedia thumb2 = Thumb;
        if (thumb2 != null && thumb2.FileType == FileType.Stream)
        {
            multipartFormDataContent.smethod_1(Thumb.Content, "thumb", Thumb.FileName);
        }
        return multipartFormDataContent;
    }
}
