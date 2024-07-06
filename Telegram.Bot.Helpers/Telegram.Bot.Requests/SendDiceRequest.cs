using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SendDiceRequest : RequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private Emoji? nullable_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

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
	public Emoji? Emoji
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool DisableNotification
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int ReplyToMessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_1;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool AllowSendingWithoutReply
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_2 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IReplyMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (IReplyMarkup)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public SendDiceRequest(ChatId chatId)
		: base("sendDice")
	{
		object_0 = chatId;
	}
}
