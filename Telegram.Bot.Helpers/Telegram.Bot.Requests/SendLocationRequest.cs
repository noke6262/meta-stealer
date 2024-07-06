using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SendLocationRequest : RequestBase<Message>, IReplyMarkupMessage<IReplyMarkup>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly float float_0;

	[CompilerGenerated]
	private readonly float float_1;

	[CompilerGenerated]
	private float float_2;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private IntPtr intptr_3;

	[CompilerGenerated]
	private IntPtr intptr_4;

	[CompilerGenerated]
	private IntPtr intptr_5;

	[CompilerGenerated]
	private object a;

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
	public float Latitude
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float Longitude
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float HorizontalAccuracy
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int LivePeriod
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Heading
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
	public int ProximityAlertRadius
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
	public bool DisableNotification
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_3 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_3 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int ReplyToMessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_4;
		}
		[CompilerGenerated]
		set
		{
			intptr_4 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool AllowSendingWithoutReply
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_5 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_5 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IReplyMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (IReplyMarkup)a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	public SendLocationRequest(ChatId chatId, float latitude, float longitude)
		: base("sendLocation")
	{
		object_0 = chatId;
		float_0 = latitude;
		float_1 = longitude;
	}
}
