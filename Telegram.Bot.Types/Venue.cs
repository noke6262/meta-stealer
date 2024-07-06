using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Venue
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
    private object object_6;

    [JsonProperty("location", Required = Required.Always)]
    public Location Location
    {
        [CompilerGenerated]
        get
        {
            return (Location)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("title", Required = Required.Always)]
    public string Title
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

    [JsonProperty("foursquare_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FoursquareId
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

    [JsonProperty("foursquare_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FoursquareType
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

    [JsonProperty("google_place_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string GooglePlaceId
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

    [JsonProperty("google_place_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string GooglePlaceType
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
}
