using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetChatDescriptionRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Description
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public SetChatDescriptionRequest(ChatId chatId, string description = null)
		: base("setChatDescription")
	{
		object_0 = chatId;
		Description = description;
	}
}
