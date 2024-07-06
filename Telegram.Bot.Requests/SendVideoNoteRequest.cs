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
public class SendVideoNoteRequest : FileRequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage, IThumbMediaMessage
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
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private IntPtr intptr_4;

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

    [JsonProperty("video_note", Required = Required.Always)]
    public InputTelegramFile VideoNote
    {
        [CompilerGenerated]
        get
        {
            return (InputTelegramFile)object_1;
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

    [JsonProperty("length", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Length
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

    [JsonProperty("thumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMedia Thumb
    {
        [CompilerGenerated]
        get
        {
            return (InputMedia)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
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

    [JsonProperty("reply_to_message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ReplyToMessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_3;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)value;
        }
    }

    [JsonProperty("allow_sending_without_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowSendingWithoutReply
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_4 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_4 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IReplyMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (IReplyMarkup)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    public SendVideoNoteRequest(ChatId chatId, InputTelegramFile videoNote)
        : base("sendVideoNote")
    {
        object_0 = chatId;
        object_1 = videoNote;
    }

    public override HttpContent ToHttpContent()
    {
        if (VideoNote.FileType != 0)
        {
            InputMedia thumb = Thumb;
            if (thumb == null || thumb.FileType != 0)
            {
                return base.ToHttpContent();
            }
        }
        MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent("video_note", "thumb");
        if (VideoNote.FileType == FileType.Stream)
        {
            multipartFormDataContent.smethod_1(VideoNote.Content, "video_note", VideoNote.FileName);
        }
        InputMedia thumb2 = Thumb;
        if (thumb2 != null && thumb2.FileType == FileType.Stream)
        {
            multipartFormDataContent.smethod_1(Thumb.Content, "thumb", Thumb.FileName);
        }
        return multipartFormDataContent;
    }
}
