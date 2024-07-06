using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Runtime.CompilerServices;
using Telegram.Bot.Converters;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types.InputFiles;

[JsonConverter(typeof(InputFileConverter))]
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InputFileStream : IInputFile
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("content")]
    public Stream Content
    {
        [CompilerGenerated]
        get
        {
            return (Stream)object_0;
        }
        [CompilerGenerated]
        protected set
        {
            object_0 = value;
        }
    }

    [JsonProperty("file_name")]
    public string FileName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public virtual FileType FileType => FileType.Stream;

    protected InputFileStream()
    {
    }

    public InputFileStream(Stream content)
        : this(content, null)
    {
    }

    public InputFileStream(Stream content, string fileName)
    {
        Content = content;
        FileName = fileName;
    }

    public static implicit operator InputFileStream(Stream stream)
    {
        if (stream != null)
        {
            return new InputFileStream(stream);
        }
        return null;
    }
}
