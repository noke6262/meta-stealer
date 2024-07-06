using System.Net.Http;
using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
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
