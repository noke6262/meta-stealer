using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetStickerPositionInSetRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [JsonProperty("sticker", Required = Required.Always)]
    public string Sticker
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("position", Required = Required.Always)]
    public int Position
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
    }

    public SetStickerPositionInSetRequest(string sticker, int position)
        : base("setStickerPositionInSet")
    {
        object_0 = sticker;
        intptr_0 = (IntPtr)position;
    }
}
