using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Chat
{
    [CompilerGenerated]
    private long long_0;

    [CompilerGenerated]
    private ChatType chatType_0;

    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object a;

    [CompilerGenerated]
    private object b;

    [CompilerGenerated]
    private int? c;

    [CompilerGenerated]
    private object d;

    [CompilerGenerated]
    private bool? e;

    [CompilerGenerated]
    private long f;

    [CompilerGenerated]
    private object object_8;

    [JsonProperty("id", Required = Required.Always)]
    public long Id
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

    [JsonProperty("type", Required = Required.Always)]
    public ChatType Type
    {
        [CompilerGenerated]
        get
        {
            return chatType_0;
        }
        [CompilerGenerated]
        set
        {
            chatType_0 = value;
        }
    }

    [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Title
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

    [JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Username
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

    [JsonProperty("first_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FirstName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("last_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastName
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

    [JsonProperty("photo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatPhoto Photo
    {
        [CompilerGenerated]
        get
        {
            return (ChatPhoto)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("bio", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Bio
    {
        [CompilerGenerated]
        get
        {
            return (string)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description
    {
        [CompilerGenerated]
        get
        {
            return (string)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("invite_link", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string InviteLink
    {
        [CompilerGenerated]
        get
        {
            return (string)object_7;
        }
        [CompilerGenerated]
        set
        {
            object_7 = value;
        }
    }

    [JsonProperty("pinned_message", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Message PinnedMessage
    {
        [CompilerGenerated]
        get
        {
            return (Message)a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    [JsonProperty("permissions", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatPermissions Permissions
    {
        [CompilerGenerated]
        get
        {
            return (ChatPermissions)b;
        }
        [CompilerGenerated]
        set
        {
            b = value;
        }
    }

    [JsonProperty("slow_mode_delay", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? SlowModeDelay
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

    [JsonProperty("sticker_set_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string StickerSetName
    {
        [CompilerGenerated]
        get
        {
            return (string)d;
        }
        [CompilerGenerated]
        set
        {
            d = value;
        }
    }

    [JsonProperty("can_set_sticker_set", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanSetStickerSet
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

    [JsonProperty("linked_chat_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long LinkedChatId
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

    [JsonProperty("location", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatLocation Location
    {
        [CompilerGenerated]
        get
        {
            return (ChatLocation)object_8;
        }
        [CompilerGenerated]
        set
        {
            object_8 = value;
        }
    }
}
