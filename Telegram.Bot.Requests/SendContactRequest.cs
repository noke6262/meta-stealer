using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendContactRequest : RequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private readonly object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

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

    [JsonProperty("phone_number", Required = Required.Always)]
    public string PhoneNumber
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    [JsonProperty("first_name", Required = Required.Always)]
    public string FirstName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
    }

    [JsonProperty("last_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastName
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

    [JsonProperty("vcard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Vcard
    {
        [CompilerGenerated]
        get
        {
            return (string)object_4;
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

    public SendContactRequest(ChatId chatId, string phoneNumber, string firstName)
        : base("sendContact")
    {
        object_0 = chatId;
        object_1 = phoneNumber;
        object_2 = firstName;
    }
}
