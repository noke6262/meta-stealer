using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetInlineGameHighScoresRequest : RequestBase<GameHighScore[]>, IInlineMessage
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("inline_message_id", Required = Required.Always)]
    public string InlineMessageId
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
    }

    public GetInlineGameHighScoresRequest(long userId, string inlineMessageId)
        : base("getGameHighScores")
    {
        long_0 = userId;
        object_0 = inlineMessageId;
    }
}
