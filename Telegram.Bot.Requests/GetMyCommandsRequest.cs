using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetMyCommandsRequest : RequestBase<BotCommand[]>
{
    public GetMyCommandsRequest()
        : base("getMyCommands")
    {
    }
}
