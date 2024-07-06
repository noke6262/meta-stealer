using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetStickerSetThumbRequest : FileRequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("name", Required = Required.Always)]
    public string Name
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("thumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputOnlineFile Thumb
    {
        [CompilerGenerated]
        get
        {
            return (InputOnlineFile)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public SetStickerSetThumbRequest(string name, long userId, InputOnlineFile thumb = null)
        : base("setStickerSetThumb")
    {
        object_0 = name;
        long_0 = userId;
        Thumb = thumb;
    }

    public override HttpContent ToHttpContent()
    {
        InputOnlineFile thumb = Thumb;
        if (thumb != null && thumb.FileType == FileType.Stream)
        {
            return ToMultipartFormDataContent("thumb", Thumb);
        }
        return base.ToHttpContent();
    }
}
