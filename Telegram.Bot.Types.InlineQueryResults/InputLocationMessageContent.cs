using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InputLocationMessageContent : InputMessageContentBase
{
    [CompilerGenerated]
    private float float_0;

    [CompilerGenerated]
    private float float_1;

    [CompilerGenerated]
    private float float_2;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [JsonProperty("latitude", Required = Required.Always)]
    public float Latitude
    {
        [CompilerGenerated]
        get
        {
            return float_0;
        }
        [CompilerGenerated]
        private set
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
        private set
        {
            float_1 = value;
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

    private InputLocationMessageContent()
    {
    }

    public InputLocationMessageContent(float latitude, float longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
