using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class UnpinAllChatMessagesRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public UnpinAllChatMessagesRequest(ChatId chatId)
		: base("unpinAllChatMessage")
	{
		ChatId = chatId;
	}
}
