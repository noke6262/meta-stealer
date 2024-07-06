using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class PinChatMessageRequest : RequestBase<bool>, INotifiableMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

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
	public int MessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool DisableNotification
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_1 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)(value ? 1 : 0);
		}
	}

	public PinChatMessageRequest(ChatId chatId, int messageId)
		: base("pinChatMessage")
	{
		object_0 = chatId;
		intptr_0 = (IntPtr)messageId;
	}
}
