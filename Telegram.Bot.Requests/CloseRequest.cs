using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CloseRequest : RequestBase<bool>
{
    public CloseRequest()
        : base("close")
    {
    }
}
