using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PollAnswer
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [JsonProperty("poll_id", Required = Required.Always)]
    public string PollId
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

    [JsonProperty("user", Required = Required.Always)]
    public User User
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

    [JsonProperty("option_ids", Required = Required.Always)]
    public int[] OptionIds
    {
        [CompilerGenerated]
        get
        {
            return (int[])object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }
}
