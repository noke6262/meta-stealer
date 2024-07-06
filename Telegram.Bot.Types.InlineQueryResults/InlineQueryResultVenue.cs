using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultVenue : InlineQueryResultBase, IInputMessageContentResult, ILocationInlineQueryResult, IThumbnailInlineQueryResult, IThumbnailUrlInlineQueryResult, ITitleInlineQueryResult
{
    [CompilerGenerated]
    private float float_0;

    [CompilerGenerated]
    private float float_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object object_8;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr a;

    [CompilerGenerated]
    private object b;

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

    [JsonProperty("address", Required = Required.Always)]
    public string Address
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

    [JsonProperty("title", Required = Required.Always)]
    public string Title
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

    [JsonProperty("foursquare_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FoursquareId
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

    [JsonProperty("foursquare_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FoursquareType
    {
        [CompilerGenerated]
        get
        {
            return (string)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    [JsonProperty("google_place_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string GooglePlaceId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("google_place_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string GooglePlaceType
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

    [JsonProperty("thumb_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ThumbUrl
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

    [JsonProperty("thumb_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbWidth
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

    [JsonProperty("thumb_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbHeight
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

    [JsonProperty("input_message_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)b;
        }
        [CompilerGenerated]
        set
        {
            b = value;
        }
    }

    private InlineQueryResultVenue()
        : base(InlineQueryResultType.Venue)
    {
    }

    public InlineQueryResultVenue(string id, float latitude, float longitude, string title, string address)
        : base(InlineQueryResultType.Venue, id)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
        Address = address;
    }
}
