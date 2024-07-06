using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AnswerPreCheckoutQueryRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("pre_checkout_query_id", Required = Required.Always)]
    public string PreCheckoutQueryId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("ok", Required = Required.Always)]
    public bool Ok
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
    }

    [JsonProperty("error_message", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ErrorMessage
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

    private AnswerPreCheckoutQueryRequest()
        : base("answerPreCheckoutQuery")
    {
    }

    public AnswerPreCheckoutQueryRequest(string preCheckoutQuery)
        : this(preCheckoutQuery, null)
    {
        intptr_0 = (IntPtr)1;
    }

    public AnswerPreCheckoutQueryRequest(string preCheckoutQuery, string errorMessage)
        : this()
    {
        object_0 = preCheckoutQuery;
        ErrorMessage = errorMessage;
    }
}
