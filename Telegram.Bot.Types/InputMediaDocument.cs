using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InputMediaDocument : InputMediaBase, IAlbumInputMedia, IInputMedia, IInputMediaThumb
{
    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [JsonProperty("thumb", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMedia Thumb
    {
        [CompilerGenerated]
        get
        {
            return (InputMedia)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("disable_content_type_detection", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableContentTypeDetection
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)(value ? 1 : 0);
        }
    }

    public InputMediaDocument(InputMedia media)
    {
        base.Type = "document";
        base.Media = media;
    }
}
