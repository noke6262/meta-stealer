using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditInlineMessageLiveLocationRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineMessage, IInlineReplyMarkupMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly float float_0;

    [CompilerGenerated]
    private readonly float float_1;

    [CompilerGenerated]
    private float float_2;

    [CompilerGenerated]
    private float float_3;

    [CompilerGenerated]
    private float float_4;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("inline_message_id", Required = Required.Always)]
    public string InlineMessageId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("latitude", Required = Required.Always)]
    public float Latitude
    {
        [CompilerGenerated]
        get
        {
            return float_0;
        }
    }

    [JsonProperty("longitude", Required = Required.Always)]
    public float Longitude
    {
        [CompilerGenerated]
        get
        {
            return float_1;
        }
    }

    [JsonProperty("horizontal_accuracy", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public float HorizontalAccuracy
    {
        [CompilerGenerated]
        get
        {
            return float_2;
        }
        [CompilerGenerated]
        set
        {
            float_2 = value;
        }
    }

    [JsonProperty("heading", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public float Heading
    {
        [CompilerGenerated]
        get
        {
            return float_3;
        }
        [CompilerGenerated]
        set
        {
            float_3 = value;
        }
    }

    [JsonProperty("proximity_alert_radius", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public float ProximityAlertRadius
    {
        [CompilerGenerated]
        get
        {
            return float_4;
        }
        [CompilerGenerated]
        set
        {
            float_4 = value;
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

    public EditInlineMessageLiveLocationRequest(string inlineMessageId, float latitude, float longitude)
        : base("editMessageLiveLocation")
    {
        object_0 = inlineMessageId;
        float_0 = latitude;
        float_1 = longitude;
    }
}
