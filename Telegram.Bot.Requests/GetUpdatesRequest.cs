using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetUpdatesRequest : RequestBase<Update[]>
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_0;

    [JsonProperty("offset", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Offset
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

    [JsonProperty("limit", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Limit
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

    [JsonProperty("timeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Timeout
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

    [JsonProperty("allowed_updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IEnumerable<UpdateType> AllowedUpdates
    {
        [CompilerGenerated]
        get
        {
            return (IEnumerable<UpdateType>)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    public GetUpdatesRequest()
        : base("getUpdates")
    {
    }
}
