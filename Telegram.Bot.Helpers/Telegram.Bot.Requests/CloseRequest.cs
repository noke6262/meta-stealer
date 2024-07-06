using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class CloseRequest : RequestBase<bool>
{
	public CloseRequest()
		: base("close")
	{
	}
}
