using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultArticle : InlineQueryResultBase, IInputMessageContentResult, IThumbnailInlineQueryResult, IThumbnailUrlInlineQueryResult, ITitleInlineQueryResult
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
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [JsonProperty("title", Required = Required.Always)]
    public string Title
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

    [JsonProperty("input_message_content", Required = Required.Always)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Url
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

    [JsonProperty("hide_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool HideUrl
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

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description
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

    [JsonProperty("thumb_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ThumbUrl
    {
        [CompilerGenerated]
        get
        {
            return (string)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("thumb_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbWidth
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

    [JsonProperty("thumb_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbHeight
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

    private InlineQueryResultArticle()
        : base(InlineQueryResultType.Article)
    {
    }

    public InlineQueryResultArticle(string id, string title, InputMessageContentBase inputMessageContent)
        : base(InlineQueryResultType.Article, id)
    {
        Title = title;
        InputMessageContent = inputMessageContent;
    }
}
