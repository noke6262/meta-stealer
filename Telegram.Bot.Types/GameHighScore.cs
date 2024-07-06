using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GameHighScore
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [JsonProperty("position", Required = Required.Always)]
    public int Position
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

    [JsonProperty("score", Required = Required.Always)]
    public int Score
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_1;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)value;
        }
    }
}
