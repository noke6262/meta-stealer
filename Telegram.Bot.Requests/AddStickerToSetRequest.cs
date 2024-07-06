using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AddStickerToSetRequest : FileRequestBase<bool>
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private readonly object object_2;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("name", Required = Required.Always)]
    public string Name
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("png_sticker", Required = Required.Always)]
    public InputOnlineFile PngSticker
    {
        [CompilerGenerated]
        get
        {
            return (InputOnlineFile)object_1;
        }
    }

    [JsonProperty("emojis", Required = Required.Always)]
    public string Emojis
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
    }

    [JsonProperty("mask_position", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MaskPosition MaskPosition
    {
        [CompilerGenerated]
        get
        {
            return (MaskPosition)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    public AddStickerToSetRequest(long userId, string name, InputOnlineFile pngSticker, string emojis)
        : base("addStickerToSet")
    {
        long_0 = userId;
        object_0 = name;
        object_1 = pngSticker;
        object_2 = emojis;
    }

    public override HttpContent ToHttpContent()
    {
        if (PngSticker.FileType != 0)
        {
            return base.ToHttpContent();
        }
        return ToMultipartFormDataContent("png_sticker", PngSticker);
    }
}
