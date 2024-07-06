using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultLocation : InlineQueryResultBase, IInputMessageContentResult, ILocationInlineQueryResult, IThumbnailInlineQueryResult, IThumbnailUrlInlineQueryResult, ITitleInlineQueryResult
{
    [CompilerGenerated]
    private float float_0;

    [CompilerGenerated]
    private float float_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private float float_2;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private IntPtr intptr_4;

    [CompilerGenerated]
    private object a;

    [JsonProperty("latitude", Required = Required.Always)]
    public float Latitude
    {
        [CompilerGenerated]
        get
        {
            return float_0;
        }
        [CompilerGenerated]
        set
        {
            float_0 = value;
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
        [CompilerGenerated]
        set
        {
            float_1 = value;
        }
    }

    [JsonProperty("title", Required = Required.Always)]
    public string Title
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

    [JsonProperty("live_period", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int LivePeriod
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

    [JsonProperty("heading", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Heading
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

    [JsonProperty("proximity_alert_radius", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ProximityAlertRadius
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

    [JsonProperty("thumb_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ThumbUrl
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

    [JsonProperty("thumb_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbWidth
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

    [JsonProperty("thumb_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbHeight
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_4;
        }
        [CompilerGenerated]
        set
        {
            intptr_4 = (IntPtr)value;
        }
    }

    [JsonProperty("input_message_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    private InlineQueryResultLocation()
        : base(InlineQueryResultType.Location)
    {
    }

    public InlineQueryResultLocation(string id, float latitude, float longitude, string title)
        : base(InlineQueryResultType.Location, id)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
    }
}
