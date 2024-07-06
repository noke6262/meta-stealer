using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class InlineQueryResultBase
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private InlineQueryResultType inlineQueryResultType_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("id", Required = Required.Always)]
    public string Id
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
        [CompilerGenerated]
        private set
        {
            object_0 = value;
        }
    }

    [JsonProperty("type", Required = Required.Always)]
    public InlineQueryResultType Type
    {
        [CompilerGenerated]
        get
        {
            return inlineQueryResultType_0;
        }
        [CompilerGenerated]
        private set
        {
            inlineQueryResultType_0 = value;
        }
    }

    [JsonProperty("reply_markup", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup ReplyMarkup
    {
        [CompilerGenerated]
        get
        {
            return (InlineKeyboardMarkup)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    protected InlineQueryResultBase(InlineQueryResultType type)
    {
        Type = type;
    }

    protected InlineQueryResultBase(InlineQueryResultType type, string id)
        : this(type)
    {
        Id = id;
    }
}
