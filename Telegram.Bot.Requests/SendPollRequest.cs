using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendPollRequest : RequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private readonly object object_2;

    [CompilerGenerated]
    private IntPtr intptr_0 = (IntPtr)1;

    [CompilerGenerated]
    private PollType pollType_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr a;

    [CompilerGenerated]
    private DateTime b;

    [CompilerGenerated]
    private IntPtr c;

    [CompilerGenerated]
    private IntPtr d;

    [CompilerGenerated]
    private IntPtr e;

    [CompilerGenerated]
    private IntPtr f;

    [CompilerGenerated]
    private object object_5;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("question", Required = Required.Always)]
    public string Question
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    [JsonProperty("options", Required = Required.Always)]
    public IEnumerable<string> Options
    {
        [CompilerGenerated]
        get
        {
            return (IEnumerable<string>)object_2;
        }
    }

    [JsonProperty("is_anonymous", Required = Required.Always)]
    public bool IsAnonymous
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

    [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public PollType Type
    {
        [CompilerGenerated]
        get
        {
            return pollType_0;
        }
        [CompilerGenerated]
        set
        {
            pollType_0 = value;
        }
    }

    [JsonProperty("allows_multiple_answers", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowsMultipleAnswers
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

    [JsonProperty("correct_option_id", Required = Required.Always)]
    public int CorrectOptionId
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

    [JsonProperty("explanation", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Explanation
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("explanation_parse_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode ExplanationParseMode
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

    [JsonProperty("explanation_entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[] ExplanationEntities
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

    [JsonProperty("open_period", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int OpenPeriod
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)a;
        }
        [CompilerGenerated]
        set
        {
            a = (IntPtr)value;
        }
    }

    [JsonProperty("close_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime CloseDate
    {
        [CompilerGenerated]
        get
        {
            return b;
        }
        [CompilerGenerated]
        set
        {
            b = value;
        }
    }

    [JsonProperty("is_closed", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsClosed
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

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)d != 0;
        }
        [CompilerGenerated]
        set
        {
            d = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_to_message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ReplyToMessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)e;
        }
        [CompilerGenerated]
        set
        {
            e = (IntPtr)value;
        }
    }

    [JsonProperty("allow_sending_without_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowSendingWithoutReply
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)f != 0;
        }
        [CompilerGenerated]
        set
        {
            f = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IReplyMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (IReplyMarkup)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    public SendPollRequest(ChatId chatId, string question, IEnumerable<string> options)
        : base("sendPoll")
    {
        object_0 = chatId;
        object_1 = question;
        object_2 = options;
    }
}
