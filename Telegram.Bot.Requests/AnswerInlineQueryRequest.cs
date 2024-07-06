using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.InlineQueryResults;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AnswerInlineQueryRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private int? nullable_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [JsonProperty("inline_query_id", Required = Required.Always)]
    public string InlineQueryId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("results", Required = Required.Always)]
    public IEnumerable<InlineQueryResultBase> Results
    {
        [CompilerGenerated]
        get
        {
            return (IEnumerable<InlineQueryResultBase>)object_1;
        }
    }

    [JsonProperty("cache_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? CacheTime
    {
        [CompilerGenerated]
        get
        {
            return nullable_0;
        }
        [CompilerGenerated]
        set
        {
            nullable_0 = value;
        }
    }

    [JsonProperty("is_personal", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsPersonal
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

    [JsonProperty("next_offset", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NextOffset
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

    [JsonProperty("switch_pm_text", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SwitchPmText
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

    [JsonProperty("switch_pm_parameter", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SwitchPmParameter
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

    public AnswerInlineQueryRequest(string inlineQueryId, IEnumerable<InlineQueryResultBase> results)
        : base("answerInlineQuery")
    {
        object_0 = inlineQueryId;
        object_1 = results;
    }
}
