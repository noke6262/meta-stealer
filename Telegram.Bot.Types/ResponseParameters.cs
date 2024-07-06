using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ResponseParameters
{
    [CompilerGenerated]
    private long long_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [JsonProperty("migrate_to_chat_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long MigrateToChatId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
        [CompilerGenerated]
        set
        {
            long_0 = value;
        }
    }

    [JsonProperty("retry_after", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int RetryAfter
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
}
