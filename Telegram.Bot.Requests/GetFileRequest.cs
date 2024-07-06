using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetFileRequest : RequestBase<File>
{
    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("file_id", Required = Required.Always)]
    public string FileId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    public GetFileRequest(string fileId)
        : base("getFile")
    {
        object_0 = fileId;
    }
}
