using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InputInvoiceMessageContent : InputMessageContentBase
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object object_8;

    [CompilerGenerated]
    private IntPtr a;

    [CompilerGenerated]
    private IntPtr b;

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

    [JsonProperty("title", Required = Required.Always)]
    public string Title
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
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
        [CompilerGenerated]
        set
        {
            object_1 = value;
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
        [CompilerGenerated]
        set
        {
            object_2 = value;
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
        [CompilerGenerated]
        set
        {
            object_3 = value;
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
        [CompilerGenerated]
        set
        {
            object_4 = value;
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
        [CompilerGenerated]
        set
        {
            object_5 = value;
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

    [JsonProperty("provider_data", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ProviderData
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

    [JsonProperty("photo_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhotoUrl
    {
        [CompilerGenerated]
        get
        {
            return (string)object_8;
        }
        [CompilerGenerated]
        set
        {
            object_8 = value;
        }
    }

    [JsonProperty("photo_size", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Photosize
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

    [JsonProperty("photo_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int PhotoWidth
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

    [JsonProperty("photo_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int PhotoHeight
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

    [JsonProperty("need_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedName
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

    [JsonProperty("need_phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedPhoneNumber
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)e != 0;
        }
        [CompilerGenerated]
        set
        {
            e = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("need_email", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedEmail
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

    [JsonProperty("need_shipping_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool NeedShippingAddress
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

    [JsonProperty("send_phone_number_to_provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool SendPhoneNumberToProvider
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

    [JsonProperty("send_email_to_provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool SendEmailToProvider
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

    [JsonProperty("is_flexible", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsFlexible
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

    public InputInvoiceMessageContent()
    {
    }

    public InputInvoiceMessageContent(string title, string description, string payload, string providerToken, string currency, IEnumerable<LabeledPrice> prices)
    {
        Title = title;
        Description = description;
        Payload = payload;
        ProviderToken = providerToken;
        Currency = currency;
        Prices = prices;
    }
}
