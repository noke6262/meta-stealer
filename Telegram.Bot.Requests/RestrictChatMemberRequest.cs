using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class RestrictChatMemberRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private DateTime dateTime_0;

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

    [JsonProperty("permissions", Required = Required.Always)]
    public ChatPermissions Permissions
    {
        [CompilerGenerated]
        get
        {
            return (ChatPermissions)object_1;
        }
    }

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("until_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
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

    public RestrictChatMemberRequest(ChatId chatId, long userId, ChatPermissions permissions)
        : base("restrictChatMember")
    {
        object_0 = chatId;
        long_0 = userId;
        object_1 = permissions;
    }
}
