using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Document : FileBase
{
    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
    public PhotoSize Thumb
    {
        [CompilerGenerated]
        get
        {
            return (PhotoSize)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("file_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FileName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("mime_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string MimeType
    {
        [CompilerGenerated]
        get
        {
            return (string)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }
}
