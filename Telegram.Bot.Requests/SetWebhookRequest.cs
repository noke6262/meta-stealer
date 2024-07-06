using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetWebhookRequest : FileRequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [JsonProperty("url", Required = Required.Always)]
    public string Url
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("certificate", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputFileStream Certificate
    {
        [CompilerGenerated]
        get
        {
            return (InputFileStream)object_1;
        }
    }

    [JsonProperty("ip_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string IpAddress
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
            return (int)(nint)intptr_0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)value;
        }
    }

    [JsonProperty("allowed_updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IEnumerable<UpdateType> AllowedUpdates
    {
        [CompilerGenerated]
        get
        {
            return (IEnumerable<UpdateType>)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("drop_pending_updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DropPendingUpdates
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

    public SetWebhookRequest(string url, InputFileStream certificate)
        : base("setWebhook")
    {
        object_0 = url;
        object_1 = certificate;
    }

    public override HttpContent ToHttpContent()
    {
        if (Certificate != null)
        {
            return ToMultipartFormDataContent("certificate", Certificate);
        }
        return base.ToHttpContent();
    }
}
