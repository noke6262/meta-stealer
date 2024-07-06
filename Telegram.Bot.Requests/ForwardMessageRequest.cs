using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ForwardMessageRequest : RequestBase<Message>, INotifiableMessage
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private readonly object object_1;

    [CompilerGenerated]
    private readonly IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("from_chat_id", Required = Required.Always)]
    public ChatId FromChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_1;
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

    [JsonProperty("disable_notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableNotification
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_1 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)(value ? 1 : 0);
        }
    }

    public ForwardMessageRequest(ChatId chatdId, ChatId fromChatId, int messageId)
        : base("forwardMessage")
    {
        object_0 = chatdId;
        object_1 = fromChatId;
        intptr_0 = (IntPtr)messageId;
    }
}
