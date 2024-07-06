using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class EditInlineMessageMediaRequest : RequestBase<bool>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineMessage, IInlineReplyMarkupMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private object object_2;

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
	public InputMediaBase Media
	{
		[CompilerGenerated]
		get
		{
			return (InputMediaBase)object_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InlineKeyboardMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (InlineKeyboardMarkup)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	public EditInlineMessageMediaRequest(string inlineMessageId, InputMediaBase media)
		: base("editMessageMedia")
	{
		object_0 = inlineMessageId;
		object_1 = media;
	}
}
