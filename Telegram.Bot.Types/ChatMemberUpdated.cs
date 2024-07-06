using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ChatMemberUpdated
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private DateTime dateTime_0;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [JsonProperty("chat", Required = Required.Always)]
    public Chat Chat
    {
        [CompilerGenerated]
        get
        {
            return (Chat)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("from", Required = Required.Always)]
    public User From
    {
        [CompilerGenerated]
        get
        {
            return (User)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("date", Required = Required.Always)]
    public DateTime Date
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

    [JsonProperty("old_chat_member", Required = Required.Always)]
    public ChatMember OldChatMember
    {
        [CompilerGenerated]
        get
        {
            return (ChatMember)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("new_chat_member", Required = Required.Always)]
    public ChatMember NewChatMember
    {
        [CompilerGenerated]
        get
        {
            return (ChatMember)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("invite_link", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatInviteLink InviteLink
    {
        [CompilerGenerated]
        get
        {
            return (ChatInviteLink)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }
}
