using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ParameterlessRequest<TResult> : RequestBase<TResult>
{
    public ParameterlessRequest(string methodName)
        : base(methodName)
    {
    }

    public ParameterlessRequest(string methodName, HttpMethod method)
        : base(methodName, method)
    {
    }

    public override HttpContent ToHttpContent()
    {
        if (!base.IsWebhookResponse)
        {
            return null;
        }
        return base.ToHttpContent();
    }
}
