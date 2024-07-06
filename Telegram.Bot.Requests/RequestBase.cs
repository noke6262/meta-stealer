using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
using Telegram.Bot.Requests.Abstractions;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    [JsonIgnore]
    public HttpMethod Method { get; }

    [JsonIgnore]
    public string MethodName { get; protected set; }

    [JsonIgnore]
    public bool IsWebhookResponse { get; set; }

    [JsonProperty("method", DefaultValueHandling = DefaultValueHandling.Ignore)]
    internal string WebHookMethodName
    {
        get
        {
            if (!IsWebhookResponse)
            {
                return null;
            }
            return MethodName;
        }
    }

    protected RequestBase(string methodName)
        : this(methodName, HttpMethod.Post)
    {
    }

    protected RequestBase(string methodName, HttpMethod method)
    {
        MethodName = methodName;
        Method = method;
    }

    public virtual HttpContent ToHttpContent()
    {
        return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
    }
}
