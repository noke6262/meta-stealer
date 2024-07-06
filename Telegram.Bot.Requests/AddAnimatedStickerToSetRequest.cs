using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AddAnimatedStickerToSetRequest : FileRequestBase<bool>
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

    [JsonProperty("tgs_sticker", Required = Required.Always)]
    public InputFileStream TgsSticker
    {
        [CompilerGenerated]
        get
        {
            return (InputFileStream)object_1;
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

    public AddAnimatedStickerToSetRequest(long userId, string name, InputFileStream tgsSticker, string emojis)
        : base("addStickerToSet")
    {
        long_0 = userId;
        object_0 = name;
        object_1 = tgsSticker;
        object_2 = emojis;
    }

    public override HttpContent ToHttpContent()
    {
        if (TgsSticker != null)
        {
            return ToMultipartFormDataContent("tgs_sticker", TgsSticker);
        }
        return base.ToHttpContent();
    }
}
