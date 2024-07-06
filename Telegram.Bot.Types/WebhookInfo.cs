using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class WebhookInfo
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private DateTime dateTime_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("url", Required = Required.Always)]
    public string Url
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

    [JsonProperty("has_custom_certificate", Required = Required.Always)]
    public bool HasCustomCertificate
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("pending_update_count", Required = Required.Always)]
    public int PendingUpdateCount
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

    [JsonProperty("ip_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string IpAddress
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

    [JsonProperty("last_error_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime LastErrorDate
    {
        [CompilerGenerated]
        get
        {
            return dateTime_0;
        }
        [CompilerGenerated]
        set
        {
            dateTime_0 = value;
        }
    }

    [JsonProperty("last_error_message", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastErrorMessage
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

    [JsonProperty("max_connections", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int MaxConnections
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
    public UpdateType[] AllowedUpdates
    {
        [CompilerGenerated]
        get
        {
            return (UpdateType[])object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }
}
