using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.Payments;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class OrderInfo
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Name
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

    [JsonProperty("phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhoneNumber
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

    [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Email
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

    [JsonProperty("shipping_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ShippingAddress ShippingAddress
    {
        [CompilerGenerated]
        get
        {
            return (ShippingAddress)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }
}
