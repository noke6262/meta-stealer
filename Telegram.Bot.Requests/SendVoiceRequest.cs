using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendVoiceRequest : FileRequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, IFormattableMessage, INotifiableMessage, IReplyMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private object object_4;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("voice", Required = Required.Always)]
    public InputOnlineFile Voice
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

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
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

    [JsonProperty("reply_to_message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ReplyToMessageId
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

    [JsonProperty("allow_sending_without_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowSendingWithoutReply
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
            return (IReplyMarkup)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    public SendVoiceRequest(ChatId chatId, InputOnlineFile voice)
        : base("sendVoice")
    {
        object_0 = chatId;
        object_1 = voice;
    }

    public override HttpContent ToHttpContent()
    {
        if (Voice.FileType != 0)
        {
            return base.ToHttpContent();
        }
        return ToMultipartFormDataContent("voice", Voice);
    }
}
