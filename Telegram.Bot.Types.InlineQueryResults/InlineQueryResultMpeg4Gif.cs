using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultMpeg4Gif : InlineQueryResultBase, ICaptionInlineQueryResult, IInputMessageContentResult, IThumbnailUrlInlineQueryResult, ITitleInlineQueryResult
{
    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object a;

    [JsonProperty("mpeg4_url", Required = Required.Always)]
    public string Mpeg4Url
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("thumb_url", Required = Required.Always)]
    public string ThumbUrl
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

    [JsonProperty("thumb_mime_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ThumbMimeType
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

    [JsonProperty("mpeg4_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Mpeg4Width
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

    [JsonProperty("mpeg4_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Mpeg4Height
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

    [JsonProperty("mpeg4_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Mpeg4Duration
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

    [JsonProperty("caption", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Caption
    {
        [CompilerGenerated]
        get
        {
            return (string)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    [JsonProperty("parse_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode ParseMode
    {
        [CompilerGenerated]
        get
        {
            return parseMode_0;
        }
        [CompilerGenerated]
        set
        {
            parseMode_0 = value;
        }
    }

    [JsonProperty("caption_entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[] CaptionEntities
    {
        [CompilerGenerated]
        get
        {
            return (MessageEntity[])object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Title
    {
        [CompilerGenerated]
        get
        {
            return (string)object_7;
        }
        [CompilerGenerated]
        set
        {
            object_7 = value;
        }
    }

    [JsonProperty("input_message_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    private InlineQueryResultMpeg4Gif()
        : base(InlineQueryResultType.Mpeg4Gif)
    {
    }

    public InlineQueryResultMpeg4Gif(string id, string mpeg4Url, string thumbUrl)
        : base(InlineQueryResultType.Mpeg4Gif, id)
    {
        Mpeg4Url = mpeg4Url;
        ThumbUrl = thumbUrl;
    }
}
