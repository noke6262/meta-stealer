using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UnpinChatMessageRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("message_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int MessageId
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

    public UnpinChatMessageRequest(ChatId chatId)
        : base("unpinChatMessage")
    {
        ChatId = chatId;
    }
}
