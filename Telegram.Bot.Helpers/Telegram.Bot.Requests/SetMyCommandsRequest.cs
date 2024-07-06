using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetMyCommandsRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<BotCommand> Commands
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<BotCommand>)object_0;
		}
	}

	public SetMyCommandsRequest(IEnumerable<BotCommand> commands)
		: base("setMyCommands")
	{
		object_0 = commands;
	}
}
