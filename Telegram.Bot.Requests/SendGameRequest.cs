using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendGameRequest : RequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IAllowableSendWithoutReply, IInlineReplyMarkupMessage, INotifiableMessage, IReplyMessage
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("chat_id", Required = Required.Always)]
    public long ChatId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("game_short_name", Required = Required.Always)]
    public string GameShortName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
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

    public SendGameRequest(long chatId, string gameShortName)
        : base("sendGame")
    {
        long_0 = chatId;
        object_0 = gameShortName;
    }
}
