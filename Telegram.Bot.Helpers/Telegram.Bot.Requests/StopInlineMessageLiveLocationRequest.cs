using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class StopInlineMessageLiveLocationRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineMessage, IInlineReplyMarkupMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string InlineMessageId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
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

	public StopInlineMessageLiveLocationRequest(string inlineMessageId)
		: base("stopMessageLiveLocation")
	{
		object_0 = inlineMessageId;
	}
}
