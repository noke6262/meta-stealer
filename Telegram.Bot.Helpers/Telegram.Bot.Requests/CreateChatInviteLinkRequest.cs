using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class CreateChatInviteLinkRequest : RequestBase<ChatInviteLink>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
	}

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime ExpireDate
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int MemberLimit
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

	public CreateChatInviteLinkRequest(ChatId chatId)
		: base("createChatInviteLink")
	{
		object_0 = chatId;
	}
}
