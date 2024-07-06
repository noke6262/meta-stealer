using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SendPollRequest : RequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private readonly object object_2;

	[CompilerGenerated]
	private IntPtr intptr_0 = (IntPtr)1;

	[CompilerGenerated]
	private PollType pollType_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private ParseMode parseMode_0;

	[CompilerGenerated]
	private object object_4;

	[CompilerGenerated]
	private IntPtr a;

	[CompilerGenerated]
	private DateTime b;

	[CompilerGenerated]
	private IntPtr c;

	[CompilerGenerated]
	private IntPtr d;

	[CompilerGenerated]
	private IntPtr e;

	[CompilerGenerated]
	private IntPtr f;

	[CompilerGenerated]
	private object object_5;

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
	public string Question
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<string> Options
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<string>)object_2;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool IsAnonymous
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
	public PollType Type
	{
		[CompilerGenerated]
		get
		{
			return pollType_0;
		}
		[CompilerGenerated]
		set
		{
			pollType_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool AllowsMultipleAnswers
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int CorrectOptionId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_2;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Explanation
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ParseMode ExplanationParseMode
	{
		[CompilerGenerated]
		get
		{
			return parseMode_0;
		}
		[CompilerGenerated]
		set
		{
			parseMode_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MessageEntity[] ExplanationEntities
	{
		[CompilerGenerated]
		get
		{
			return (MessageEntity[])object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int OpenPeriod
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)a;
		}
		[CompilerGenerated]
		set
		{
			a = (IntPtr)value;
		}
	}

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime CloseDate
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool IsClosed
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)c != 0;
		}
		[CompilerGenerated]
		set
		{
			c = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool DisableNotification
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)d != 0;
		}
		[CompilerGenerated]
		set
		{
			d = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int ReplyToMessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)e;
		}
		[CompilerGenerated]
		set
		{
			e = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool AllowSendingWithoutReply
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)f != 0;
		}
		[CompilerGenerated]
		set
		{
			f = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IReplyMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (IReplyMarkup)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	public SendPollRequest(ChatId chatId, string question, IEnumerable<string> options)
		: base("sendPoll")
	{
		object_0 = chatId;
		object_1 = question;
		object_2 = options;
	}
}
