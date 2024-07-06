using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SendMediaGroupRequest : FileRequestBase<Message[]>, IAllowableSendWithoutReply, INotifiableMessage, IReplyMessage
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

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
	public IEnumerable<IAlbumInputMedia> Media
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<IAlbumInputMedia>)object_1;
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

	[Obsolete("Use the other constructor. Only photo and video input types are allowed.")]
	public SendMediaGroupRequest(ChatId chatId, IEnumerable<InputMediaBase> media)
		: base("sendMediaGroup")
	{
		object_0 = chatId;
		object_1 = (from m in media
			select m as IAlbumInputMedia into m
			where m != null
			select m).ToArray();
	}

	public SendMediaGroupRequest(ChatId chatId, IEnumerable<IAlbumInputMedia> media)
		: base("sendMediaGroup")
	{
		object_0 = chatId;
		object_1 = media;
	}

	public override HttpContent ToHttpContent()
	{
		MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent();
		multipartFormDataContent.smethod_2(Media.Cast<IInputMedia>().ToArray());
		return multipartFormDataContent;
	}
}
