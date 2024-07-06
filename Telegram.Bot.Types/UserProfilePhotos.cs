using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UserProfilePhotos
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_0;

    [JsonProperty("total_count", Required = Required.Always)]
    public int TotalCount
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

    [JsonProperty("photos", Required = Required.Always)]
    public PhotoSize[][] Photos
    {
        [CompilerGenerated]
        get
        {
            return (PhotoSize[][])object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }
}
