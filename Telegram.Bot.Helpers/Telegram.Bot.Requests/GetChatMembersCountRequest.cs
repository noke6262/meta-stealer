using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetChatMembersCountRequest : RequestBase<int>
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
	}

	public GetChatMembersCountRequest(ChatId chatId)
		: base("getChatMembersCount")
	{
		object_0 = chatId;
	}
}
