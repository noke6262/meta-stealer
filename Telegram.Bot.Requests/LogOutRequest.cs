using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class LogOutRequest : RequestBase<bool>
{
    public LogOutRequest()
        : base("logOut")
    {
    }
}
