using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class StopMessageLiveLocationRequest : RequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineReplyMarkupMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

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
	public int MessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InlineKeyboardMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (InlineKeyboardMarkup)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public StopMessageLiveLocationRequest(ChatId chatId, int messageId)
		: base("stopMessageLiveLocation")
	{
		object_0 = chatId;
		intptr_0 = (IntPtr)messageId;
	}
}
