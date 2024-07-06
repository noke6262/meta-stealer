using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AnswerCallbackQueryRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [JsonProperty("callback_query_id", Required = Required.Always)]
    public string CallbackQueryId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("text", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Text
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

    [JsonProperty("show_alert", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool ShowAlert
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

    [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Url
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

    [JsonProperty("cache_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int CacheTime
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

    public AnswerCallbackQueryRequest(string callbackQueryId)
        : base("answerCallbackQuery")
    {
        object_0 = callbackQueryId;
    }
}
