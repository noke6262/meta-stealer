using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultCachedMpeg4Gif : InlineQueryResultBase, ICaptionInlineQueryResult, IInputMessageContentResult, ITitleInlineQueryResult
{
    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [JsonProperty("mpeg4_file_id", Required = Required.Always)]
    public string Mpeg4FileId
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

    [JsonProperty("caption", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Caption
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
            return (MessageEntity[])object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Title
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

    [JsonProperty("input_message_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    private InlineQueryResultCachedMpeg4Gif()
        : base(InlineQueryResultType.Mpeg4Gif)
    {
    }

    public InlineQueryResultCachedMpeg4Gif(string id, string mpeg4FileId)
        : base(InlineQueryResultType.Mpeg4Gif, id)
    {
        Mpeg4FileId = mpeg4FileId;
    }
}
