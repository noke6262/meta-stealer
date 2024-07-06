using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UploadStickerFileRequest : FileRequestBase<File>
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("png_sticker", Required = Required.Always)]
    public InputFileStream PngSticker
    {
        [CompilerGenerated]
        get
        {
            return (InputFileStream)object_0;
        }
    }

    public UploadStickerFileRequest(long userId, InputFileStream pngSticker)
        : base("uploadStickerFile")
    {
        long_0 = userId;
        object_0 = pngSticker;
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
