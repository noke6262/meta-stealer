using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetChatPhotoRequest : FileRequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("photo", Required = Required.Always)]
    public InputFileStream Photo
    {
        [CompilerGenerated]
        get
        {
            return (InputFileStream)object_1;
        }
    }

    public SetChatPhotoRequest(ChatId chatId, InputFileStream photo)
        : base("setChatPhoto")
    {
        object_0 = chatId;
        object_1 = photo;
    }

    public override HttpContent ToHttpContent()
    {
        if (Photo.FileType != 0)
        {
            return base.ToHttpContent();
        }
        return ToMultipartFormDataContent("photo", Photo);
    }
}
