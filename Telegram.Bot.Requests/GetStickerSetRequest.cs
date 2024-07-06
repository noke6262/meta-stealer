using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetStickerSetRequest : RequestBase<StickerSet>
{
    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("name", Required = Required.Always)]
    public string Name
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    public GetStickerSetRequest(string name)
        : base("getStickerSet")
    {
        object_0 = name;
    }
}
