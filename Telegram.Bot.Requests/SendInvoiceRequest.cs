using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendInvoiceRequest : RequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IAllowableSendWithoutReply, IInlineReplyMarkupMessage, INotifiableMessage, IReplyMessage
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private readonly object object_2;

    [CompilerGenerated]
    private readonly object object_3;

    [CompilerGenerated]
    private readonly object object_4;

    [CompilerGenerated]
    private readonly object object_5;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object a;

    [CompilerGenerated]
    private object b;

    [CompilerGenerated]
    private IntPtr c;

    [CompilerGenerated]
    private IntPtr d;

    [CompilerGenerated]
    private IntPtr e;

    [CompilerGenerated]
    private IntPtr f;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private IntPtr intptr_4;

    [CompilerGenerated]
    private IntPtr intptr_5;

    [CompilerGenerated]
    private IntPtr intptr_6;

    [CompilerGenerated]
    private IntPtr intptr_7;

    [CompilerGenerated]
    private IntPtr intptr_8;

    [CompilerGenerated]
    private IntPtr intptr_9;

    [CompilerGenerated]
    private object object_8;

    [JsonProperty("chat_id", Required = Required.Always)]
    public long ChatId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("title", Required = Required.Always)]
    public string Title
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("description", Required = Required.Always)]
    public string Description
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    [JsonProperty("payload", Required = Required.Always)]
    public string Payload
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
    }

    [JsonProperty("provider_token", Required = Required.Always)]
    public string ProviderToken
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
    }

    [JsonProperty("currency", Required = Required.Always)]
    public string Currency
    {
        [CompilerGenerated]
        get
        {
            return (string)object_4;
        }
    }

    [JsonProperty("prices", Required = Required.Always)]
    public IEnumerable<LabeledPrice> Prices
    {
        [CompilerGenerated]
        get
        {
            return (IEnumerable<LabeledPrice>)object_5;
        }
    }

    [JsonProperty("max_tip_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int MaxTipAmount
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

    [JsonProperty("suggested_tip_amounts", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int[] SuggestedTipAmounts
    {
        [CompilerGenerated]
        get
        {
            return (int[])object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("start_parameter", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string StartParameter
    {
        [CompilerGenerated]
        get
        {
            return (string)object_7;
        }
        [CompilerGenerated]
        set
        {
            object_7 = value;
        }
    }

    [JsonProperty("provider_data", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ProviderData
    {
        [CompilerGenerated]
        get
        {
            return (string)a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    [JsonProperty("photo_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhotoUrl
    {
        [CompilerGenerated]
        get
        {
            return (string)b;
        }
        [CompilerGenerated]
        set
        {
            b = value;
        }
    }

    [JsonProperty("photo_size", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int PhotoSize
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)c;
        }
        [CompilerGenerated]
        set
        {
            c = (IntPtr)value;
        }
    }

    [JsonProperty("photo_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int PhotoWidth
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)d;
        }
        [CompilerGenerated]
        set
        {
            d = (IntPtr)value;
        }
    }

    [JsonProperty("photo_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int PhotoHeight
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

    [JsonProperty("need_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedName
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

    [JsonProperty("need_phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedPhoneNumber
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

    [JsonProperty("need_email", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedEmail
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

    [JsonProperty("need_shipping_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedShippingAddress
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

    [JsonProperty("send_phone_number_to_provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool SendPhoneNumberToProvider
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

    [JsonProperty("send_email_to_provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool SendEmailToProvider
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_5 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_5 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("is_flexible", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsFlexible
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_6 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_6 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_7 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_7 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_to_message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ReplyToMessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_8;
        }
        [CompilerGenerated]
        set
        {
            intptr_8 = (IntPtr)value;
        }
    }

    [JsonProperty("allow_sending_without_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool AllowSendingWithoutReply
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_9 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_9 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (InlineKeyboardMarkup)object_8;
        }
        [CompilerGenerated]
        set
        {
            object_8 = value;
        }
    }

    public SendInvoiceRequest(int chatId, string title, string description, string payload, string providerToken, string currency, IEnumerable<LabeledPrice> prices)
        : base("sendInvoice")
    {
        long_0 = chatId;
        object_0 = title;
        object_1 = description;
        object_2 = payload;
        object_3 = providerToken;
        object_4 = currency;
        object_5 = prices;
    }
}
