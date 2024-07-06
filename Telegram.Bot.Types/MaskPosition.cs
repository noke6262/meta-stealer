using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class MaskPosition
{
    [CompilerGenerated]
    private MaskPositionPoint maskPositionPoint_0;

    [CompilerGenerated]
    private float float_0;

    [CompilerGenerated]
    private float float_1;

    [CompilerGenerated]
    private float float_2;

    [JsonProperty("Point", Required = Required.Always)]
    public MaskPositionPoint Point
    {
        [CompilerGenerated]
        get
        {
            return maskPositionPoint_0;
        }
        [CompilerGenerated]
        set
        {
            maskPositionPoint_0 = value;
        }
    }

    [JsonProperty("x_shift", Required = Required.Always)]
    public float XShift
    {
        [CompilerGenerated]
        get
        {
            return float_0;
        }
        [CompilerGenerated]
        set
        {
            float_0 = value;
        }
    }

    [JsonProperty("y_shift", Required = Required.Always)]
    public float YShift
    {
        [CompilerGenerated]
        get
        {
            return float_1;
        }
        [CompilerGenerated]
        set
        {
            float_1 = value;
        }
    }

    [JsonProperty("scale", Required = Required.Always)]
    public float Scale
    {
        [CompilerGenerated]
        get
        {
            return float_2;
        }
        [CompilerGenerated]
        set
        {
            float_2 = value;
        }
    }
}
