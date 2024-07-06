using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SendChatActionRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly ChatAction chatAction_0;

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
	public ChatAction Action
	{
		[CompilerGenerated]
		get
		{
			return chatAction_0;
		}
	}

	public SendChatActionRequest(ChatId chatId, ChatAction action)
		: base("sendChatAction")
	{
		object_0 = chatId;
		chatAction_0 = action;
	}
}
