using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
	[JsonIgnore]
	public HttpMethod Method { get; }

	[JsonIgnore]
	public string MethodName { get; protected set; }

	[JsonIgnore]
	public bool IsWebhookResponse { get; set; }

	[JsonProperty(/*Could not decode attribute arguments.*/)]
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
		return new StringContent(JsonConvert.SerializeObject((object)this), Encoding.UTF8, "application/json");
	}
}
