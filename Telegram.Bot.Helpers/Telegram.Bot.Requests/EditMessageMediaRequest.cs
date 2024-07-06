using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class EditMessageMediaRequest : FileRequestBase<Message>, IReplyMarkupMessage<InlineKeyboardMarkup>, IInlineReplyMarkupMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private object object_2;

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

	public EditMessageMediaRequest(ChatId chatId, int messageId, InputMediaBase media)
		: base("editMessageMedia")
	{
		object_0 = chatId;
		intptr_0 = (IntPtr)messageId;
		object_1 = media;
	}

	public override HttpContent ToHttpContent()
	{
		MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent();
		multipartFormDataContent.smethod_2(Media);
		return multipartFormDataContent;
	}
}
