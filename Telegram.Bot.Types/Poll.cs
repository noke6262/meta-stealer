using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Poll
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [CompilerGenerated]
    private IntPtr intptr_4;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object a;

    [CompilerGenerated]
    private IntPtr b;

    [CompilerGenerated]
    private DateTime c;

    [JsonProperty("id", Required = Required.Always)]
    public string Id
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

    [JsonProperty("question", Required = Required.Always)]
    public string Question
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

    [JsonProperty("options", Required = Required.Always)]
    public PollOption[] Options
    {
        [CompilerGenerated]
        get
        {
            return (PollOption[])object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("total_voter_count", Required = Required.Always)]
    public int TotalVoterCount
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

    [JsonProperty("is_closed", Required = Required.Always)]
    public bool IsClosed
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

    [JsonProperty("is_anonymous", Required = Required.Always)]
    public bool IsAnonymous
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_2 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("type", Required = Required.Always)]
    public string Type
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

    [JsonProperty("allows_multiple_answers", Required = Required.Always)]
    public bool AllowsMultipleAnswers
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_3 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("correct_option_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int CorrectOptionId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_4;
        }
        [CompilerGenerated]
        set
        {
            intptr_4 = (IntPtr)value;
        }
    }

    [JsonProperty("explanation", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Explanation
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

    [JsonProperty("explanation_entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[] ExplanationEntities
    {
        [CompilerGenerated]
        get
        {
            return (MessageEntity[])a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    [JsonProperty("open_period", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int OpenPeriod
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)b;
        }
        [CompilerGenerated]
        set
        {
            b = (IntPtr)value;
        }
    }

    [JsonProperty("close_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime CloseDate
    {
        [CompilerGenerated]
        get
        {
            return c;
        }
        [CompilerGenerated]
        set
        {
            c = value;
        }
    }
}
