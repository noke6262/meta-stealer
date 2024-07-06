using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetGameScoreRequest : RequestBase<Message>
{
    [CompilerGenerated]
    private readonly long long_0;

    [CompilerGenerated]
    private readonly long long_1;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [CompilerGenerated]
    private readonly IntPtr intptr_1;

    [CompilerGenerated]
    private IntPtr intptr_2;

    [CompilerGenerated]
    private IntPtr intptr_3;

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

    [JsonProperty("score", Required = Required.Always)]
    public int Score
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_1;
        }
    }

    [JsonProperty("force", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Force
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_2 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_2 = (IntPtr)(value ? 1 : 0);
        }
    }

    [JsonProperty("disable_edit_message", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableEditMessage
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_3 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_3 = (IntPtr)(value ? 1 : 0);
        }
    }

    public SetGameScoreRequest(long userId, int score, long chatId, int messageId)
        : base("setGameScore")
    {
        long_1 = userId;
        intptr_1 = (IntPtr)score;
        long_0 = chatId;
        intptr_0 = (IntPtr)messageId;
    }
}
