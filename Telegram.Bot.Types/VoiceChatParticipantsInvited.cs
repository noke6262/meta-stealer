using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class VoiceChatParticipantsInvited
{
    [CompilerGenerated]
    private object object_0;

    [JsonProperty("users", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public User[] Users
    {
        [CompilerGenerated]
        get
        {
            return (User[])object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }
}
