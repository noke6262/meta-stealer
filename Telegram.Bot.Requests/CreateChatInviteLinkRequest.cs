using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreateChatInviteLinkRequest : RequestBase<ChatInviteLink>
{
    [CompilerGenerated]
    private readonly object object_0;

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

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("expire_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime ExpireDate
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

    [JsonProperty("member_limit", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int MemberLimit
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

    public CreateChatInviteLinkRequest(ChatId chatId)
        : base("createChatInviteLink")
    {
        object_0 = chatId;
    }
}
