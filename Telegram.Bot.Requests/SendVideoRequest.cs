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
public class SendVideoRequest : FileRequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, IFormattableMessage, INotifiableMessage, IReplyMessage, IThumbMediaMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr a;

    [CompilerGenerated]
    private IntPtr b;

    [CompilerGenerated]
    private IntPtr c;

    [CompilerGenerated]
    private object d;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("video", Required = Required.Always)]
    public InputOnlineFile Video
    {
        [CompilerGenerated]
        get
        {
            return (InputOnlineFile)object_1;
        }
    }

    [JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Duration
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)value;
        }
    }

    [JsonProperty("width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Width
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

    [JsonProperty("height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Height
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_2;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)value;
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
            return (MessageEntity[])object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("supports_streaming", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool SupportsStreaming
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

    [JsonProperty("thumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMedia Thumb
    {
        [CompilerGenerated]
        get
        {
            return (InputMedia)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)a != 0;
        }
        [CompilerGenerated]
        set
        {
            a = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_to_message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ReplyToMessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)b;
        }
        [CompilerGenerated]
        set
        {
            b = (IntPtr)value;
        }
    }

    [JsonProperty("allow_sending_without_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowSendingWithoutReply
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)c != 0;
        }
        [CompilerGenerated]
        set
        {
            c = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IReplyMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (IReplyMarkup)d;
        }
        [CompilerGenerated]
        set
        {
            d = value;
        }
    }

    public SendVideoRequest(ChatId chatId, InputOnlineFile video)
        : base("sendVideo")
    {
        object_0 = chatId;
        object_1 = video;
    }

    public override HttpContent ToHttpContent()
    {
        if (Video.FileType != 0)
        {
            InputMedia thumb = Thumb;
            if (thumb == null || thumb.FileType != 0)
            {
                return base.ToHttpContent();
            }
        }
        MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent("video", "thumb");
        if (Video.FileType == FileType.Stream)
        {
            multipartFormDataContent.smethod_1(Video.Content, "video", Video.FileName);
        }
        InputMedia thumb2 = Thumb;
        if (thumb2 != null && thumb2.FileType == FileType.Stream)
        {
            multipartFormDataContent.smethod_1(Thumb.Content, "thumb", Thumb.FileName);
        }
        return multipartFormDataContent;
    }
}
