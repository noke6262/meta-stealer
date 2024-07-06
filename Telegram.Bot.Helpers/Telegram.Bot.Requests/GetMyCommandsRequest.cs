using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetMyCommandsRequest : RequestBase<BotCommand[]>
{
	public GetMyCommandsRequest()
		: base("getMyCommands")
	{
	}
}
