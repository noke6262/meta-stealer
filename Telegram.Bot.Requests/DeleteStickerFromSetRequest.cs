using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class DeleteStickerFromSetRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("sticker", Required = Required.Always)]
    public string Sticker
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    public DeleteStickerFromSetRequest(string sticker)
        : base("deleteStickerFromSet")
    {
        object_0 = sticker;
    }
}
