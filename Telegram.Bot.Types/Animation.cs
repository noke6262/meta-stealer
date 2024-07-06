using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Animation
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr intptr_3;

    [JsonProperty("file_id", Required = Required.Always)]
    public string FileId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("file_unique_id", Required = Required.Always)]
    public string FileUniqueId
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

    [JsonProperty("width", Required = Required.Always)]
    public int Width
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)value;
        }
    }

    [JsonProperty("height", Required = Required.Always)]
    public int Height
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_1;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)value;
        }
    }

    [JsonProperty("duration", Required = Required.Always)]
    public int Duration
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_2;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)value;
        }
    }

    [JsonProperty("thumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
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

    [JsonProperty("file_size", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int FileSize
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_3;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)value;
        }
    }
}
