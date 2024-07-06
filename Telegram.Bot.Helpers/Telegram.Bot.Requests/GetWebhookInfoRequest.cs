using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetWebhookInfoRequest : ParameterlessRequest<WebhookInfo>
{
	public GetWebhookInfoRequest()
		: base("getWebhookInfo")
	{
	}
}
