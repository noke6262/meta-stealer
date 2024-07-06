using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ChatPermissions
{
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

    [JsonProperty("can_send_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendMessages
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

    [JsonProperty("can_send_media_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendMediaMessages
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

    [JsonProperty("can_send_polls", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendPolls
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

    [JsonProperty("can_send_other_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSendOtherMessages
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

    [JsonProperty("can_add_web_page_previews", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanAddWebPagePreviews
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

    [JsonProperty("can_change_info", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanChangeInfo
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

    [JsonProperty("can_invite_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanInviteUsers
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

    [JsonProperty("can_pin_messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanPinMessages
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
}
