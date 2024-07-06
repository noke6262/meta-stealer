using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetChatRequest : RequestBase<Chat>
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	[JsonConverter(typeof(ChatIdConverter))]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
	}

	public GetChatRequest(ChatId chatId)
		: base("getChat")
	{
		object_0 = chatId;
	}
}
