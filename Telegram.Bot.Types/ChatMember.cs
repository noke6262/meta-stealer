using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ChatMember
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private ChatMemberStatus chatMemberStatus_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private DateTime? nullable_0;

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
    private bool? a;

    [CompilerGenerated]
    private bool? b;

    [CompilerGenerated]
    private bool? c;

    [CompilerGenerated]
    private bool? d;

    [CompilerGenerated]
    private bool? e;

    [CompilerGenerated]
    private bool? f;

    [CompilerGenerated]
    private bool? nullable_6;

    [CompilerGenerated]
    private bool? nullable_7;

    [CompilerGenerated]
    private bool? nullable_8;

    [CompilerGenerated]
    private bool? nullable_9;

    [CompilerGenerated]
    private bool? nullable_10;

    [CompilerGenerated]
    private bool? nullable_11;

    [JsonProperty("user", Required = Required.Always)]
    public User User
    {
        [CompilerGenerated]
        get
        {
            return (User)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("status", Required = Required.Always)]
    public ChatMemberStatus Status
    {
        [CompilerGenerated]
        get
        {
            return chatMemberStatus_0;
        }
        [CompilerGenerated]
        set
        {
            chatMemberStatus_0 = value;
        }
    }

    [JsonProperty("custom_title", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CustomTitle
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

    [JsonProperty("is_anonymous", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsAnonymous
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

    [JsonProperty("until_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? UntilDate
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

    [JsonProperty("can_be_edited", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanBeEdited
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

    [JsonProperty("can_manage_chat", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanManageChat
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

    [JsonProperty("can_change_info", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanChangeInfo
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

    [JsonProperty("can_post_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPostMessages
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

    [JsonProperty("can_edit_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanEditMessages
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

    [JsonProperty("can_delete_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanDeleteMessages
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

    [JsonProperty("can_manage_voice_chats", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanManageVoiceChats
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

    [JsonProperty("can_invite_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanInviteUsers
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

    [JsonProperty("can_restrict_members", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanRestrictMembers
    {
        [CompilerGenerated]
        get
        {
            return d;
        }
        [CompilerGenerated]
        set
        {
            d = value;
        }
    }

    [JsonProperty("can_pin_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPinMessages
    {
        [CompilerGenerated]
        get
        {
            return e;
        }
        [CompilerGenerated]
        set
        {
            e = value;
        }
    }

    [JsonProperty("can_promote_members", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPromoteMembers
    {
        [CompilerGenerated]
        get
        {
            return f;
        }
        [CompilerGenerated]
        set
        {
            f = value;
        }
    }

    [JsonProperty("is_member", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? IsMember
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

    [JsonProperty("can_send_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendMessages
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

    [JsonProperty("can_send_media_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendMediaMessages
    {
        [CompilerGenerated]
        get
        {
            return nullable_8;
        }
        [CompilerGenerated]
        set
        {
            nullable_8 = value;
        }
    }

    [JsonProperty("can_send_polls", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendPolls
    {
        [CompilerGenerated]
        get
        {
            return nullable_9;
        }
        [CompilerGenerated]
        set
        {
            nullable_9 = value;
        }
    }

    [JsonProperty("can_send_other_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendOtherMessages
    {
        [CompilerGenerated]
        get
        {
            return nullable_10;
        }
        [CompilerGenerated]
        set
        {
            nullable_10 = value;
        }
    }

    [JsonProperty("can_add_web_page_previews", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanAddWebPagePreviews
    {
        [CompilerGenerated]
        get
        {
            return nullable_11;
        }
        [CompilerGenerated]
        set
        {
            nullable_11 = value;
        }
    }
}
