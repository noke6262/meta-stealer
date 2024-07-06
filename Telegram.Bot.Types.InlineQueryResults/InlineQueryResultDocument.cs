using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultDocument : InlineQueryResultBase, ICaptionInlineQueryResult, IInputMessageContentResult, IThumbnailInlineQueryResult, IThumbnailUrlInlineQueryResult, ITitleInlineQueryResult
{
    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object object_8;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object a;

    [JsonProperty("document_url", Required = Required.Always)]
    public string DocumentUrl
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

    [JsonProperty("title", Required = Required.Always)]
    public string Title
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

    [JsonProperty("mime_type", Required = Required.Always)]
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

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description
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

    [JsonProperty("thumb_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ThumbUrl
    {
        [CompilerGenerated]
        get
        {
            return (string)object_8;
        }
        [CompilerGenerated]
        set
        {
            object_8 = value;
        }
    }

    [JsonProperty("thumb_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbWidth
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

    [JsonProperty("thumb_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbHeight
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

    private InlineQueryResultDocument()
        : base(InlineQueryResultType.Document)
    {
    }

    public InlineQueryResultDocument(string id, string documentUrl, string title, string mimeType)
        : base(InlineQueryResultType.Document, id)
    {
        DocumentUrl = documentUrl;
        Title = title;
        MimeType = mimeType;
    }
}
