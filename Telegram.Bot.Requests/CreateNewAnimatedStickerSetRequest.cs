using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreateNewAnimatedStickerSetRequest : FileRequestBase<bool>
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
    private readonly object object_3;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_4;

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

    [JsonProperty("title", Required = Required.Always)]
    public string Title
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
    }

    [JsonProperty("tgs_sticker", Required = Required.Always)]
    public InputFileStream TgsSticker
    {
        [CompilerGenerated]
        get
        {
            return (InputFileStream)object_2;
        }
    }

    [JsonProperty("emojis", Required = Required.Always)]
    public string Emojis
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
    }

    [JsonProperty("contains_masks", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool ContainsMasks
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

    [JsonProperty("mask_position", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MaskPosition MaskPosition
    {
        [CompilerGenerated]
        get
        {
            return (MaskPosition)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    public CreateNewAnimatedStickerSetRequest(long userId, string name, string title, InputFileStream tgsSticker, string emojis)
        : base("createNewStickerSet")
    {
        long_0 = userId;
        object_0 = name;
        object_1 = title;
        object_2 = tgsSticker;
        object_3 = emojis;
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
