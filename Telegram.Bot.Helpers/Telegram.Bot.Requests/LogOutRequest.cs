using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class LogOutRequest : RequestBase<bool>
{
	public LogOutRequest()
		: base("logOut")
	{
	}
}
