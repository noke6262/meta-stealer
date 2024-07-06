using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class UnpinChatMessageRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int MessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)value;
		}
	}

	public UnpinChatMessageRequest(ChatId chatId)
		: base("unpinChatMessage")
	{
		ChatId = chatId;
	}
}
