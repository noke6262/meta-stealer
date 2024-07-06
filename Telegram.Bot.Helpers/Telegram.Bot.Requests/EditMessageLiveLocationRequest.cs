using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class EditMessageLiveLocationRequest : RequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineReplyMarkupMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[CompilerGenerated]
	private readonly float float_0;

	[CompilerGenerated]
	private readonly float float_1;

	[CompilerGenerated]
	private float float_2;

	[CompilerGenerated]
	private float float_3;

	[CompilerGenerated]
	private float float_4;

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
	public float Heading
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float ProximityAlertRadius
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
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

	public EditMessageLiveLocationRequest(ChatId chatId, int messageId, float latitude, float longitude)
		: base("editMessageLiveLocation")
	{
		object_0 = chatId;
		intptr_0 = (IntPtr)messageId;
		float_0 = latitude;
		float_1 = longitude;
	}
}
