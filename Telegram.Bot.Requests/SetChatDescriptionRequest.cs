using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetChatDescriptionRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("chat_id", Required = Required.Always)]
    public ChatId ChatId
    {
        [CompilerGenerated]
        get
        {
            return (ChatId)object_0;
        }
    }

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    public SetChatDescriptionRequest(ChatId chatId, string description = null)
        : base("setChatDescription")
    {
        object_0 = chatId;
        Description = description;
    }
}
