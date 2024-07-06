using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetMeRequest : ParameterlessRequest<User>
{
	public GetMeRequest()
		: base("getMe")
	{
	}
}
