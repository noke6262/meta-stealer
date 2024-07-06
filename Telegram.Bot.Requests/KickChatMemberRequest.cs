using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class KickChatMemberRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private DateTime dateTime_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("until_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime UntilDate
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

    [JsonProperty("revoke_messages", Required = Required.Always)]
    public bool RevokeMessages
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

    public KickChatMemberRequest(ChatId chatId, long userId)
        : base("kickChatMember")
    {
        object_0 = chatId;
        long_0 = userId;
    }
}
