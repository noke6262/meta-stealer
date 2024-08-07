using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetGameHighScoresRequest : RequestBase<GameHighScore[]>
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly long long_1;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [JsonProperty("chat_id", Required = Required.Always)]
    public long ChatId
    {
        [CompilerGenerated]
        get
        {
            return long_0;
        }
    }

    [JsonProperty("user_id", Required = Required.Always)]
    public long UserId
    {
        [CompilerGenerated]
        get
        {
            return long_1;
        }
    }

    [JsonProperty("message_id", Required = Required.Always)]
    public int MessageId
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
    }

    public GetGameHighScoresRequest(long userId, long chatId, int messageId)
        : base("getGameHighScores")
    {
        long_1 = userId;
        long_0 = chatId;
        intptr_0 = (IntPtr)messageId;
    }
}
