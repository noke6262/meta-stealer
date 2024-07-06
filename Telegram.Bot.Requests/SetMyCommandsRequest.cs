using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetMyCommandsRequest : RequestBase<bool>
{
    [CompilerGenerated]
    private readonly object object_0;

    [JsonProperty("commands", Required = Required.Always)]
    public IEnumerable<BotCommand> Commands
    {
        [CompilerGenerated]
        get
        {
            return (IEnumerable<BotCommand>)object_0;
        }
    }

    public SetMyCommandsRequest(IEnumerable<BotCommand> commands)
        : base("setMyCommands")
    {
        object_0 = commands;
    }
}
