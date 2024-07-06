using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PromoteChatMemberRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private bool? nullable_0;

    [CompilerGenerated]
    private bool? nullable_1;

    [CompilerGenerated]
    private bool? nullable_2;

    [CompilerGenerated]
    private bool? nullable_3;

    [CompilerGenerated]
    private bool? nullable_4;

    [CompilerGenerated]
    private bool? nullable_5;

    [CompilerGenerated]
    private bool? nullable_6;

    [CompilerGenerated]
    private bool? nullable_7;

    [CompilerGenerated]
    private bool? a;

    [CompilerGenerated]
    private bool? b;

    [CompilerGenerated]
    private bool? c;

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

    [JsonProperty("is_anonymous", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? IsAnonymous
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

    [JsonProperty("can_manage_chat", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanManageChat
    {
        [CompilerGenerated]
        get
        {
            return nullable_1;
        }
        [CompilerGenerated]
        set
        {
            nullable_1 = value;
        }
    }

    [JsonProperty("can_change_info", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanChangeInfo
    {
        [CompilerGenerated]
        get
        {
            return nullable_2;
        }
        [CompilerGenerated]
        set
        {
            nullable_2 = value;
        }
    }

    [JsonProperty("can_post_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPostMessages
    {
        [CompilerGenerated]
        get
        {
            return nullable_3;
        }
        [CompilerGenerated]
        set
        {
            nullable_3 = value;
        }
    }

    [JsonProperty("can_edit_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanEditMessages
    {
        [CompilerGenerated]
        get
        {
            return nullable_4;
        }
        [CompilerGenerated]
        set
        {
            nullable_4 = value;
        }
    }

    [JsonProperty("can_delete_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanDeleteMessages
    {
        [CompilerGenerated]
        get
        {
            return nullable_5;
        }
        [CompilerGenerated]
        set
        {
            nullable_5 = value;
        }
    }

    [JsonProperty("can_manage_voice_chats", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanManageVoiceChats
    {
        [CompilerGenerated]
        get
        {
            return nullable_6;
        }
        [CompilerGenerated]
        set
        {
            nullable_6 = value;
        }
    }

    [JsonProperty("can_invite_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanInviteUsers
    {
        [CompilerGenerated]
        get
        {
            return nullable_7;
        }
        [CompilerGenerated]
        set
        {
            nullable_7 = value;
        }
    }

    [JsonProperty("can_restrict_members", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanRestrictMembers
    {
        [CompilerGenerated]
        get
        {
            return a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    [JsonProperty("can_pin_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPinMessages
    {
        [CompilerGenerated]
        get
        {
            return b;
        }
        [CompilerGenerated]
        set
        {
            b = value;
        }
    }

    [JsonProperty("can_promote_members", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPromoteMembers
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

    public PromoteChatMemberRequest(ChatId chatId, long userId)
        : base("promoteChatMember")
    {
        object_0 = chatId;
        long_0 = userId;
    }
}
