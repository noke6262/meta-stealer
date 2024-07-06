using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class RestrictChatMemberRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private DateTime dateTime_0;

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
	public long UserId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatPermissions Permissions
	{
		[CompilerGenerated]
		get
		{
			return (ChatPermissions)object_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime UntilDate
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

	public RestrictChatMemberRequest(ChatId chatId, long userId, ChatPermissions permissions)
		: base("restrictChatMember")
	{
		object_0 = chatId;
		long_0 = userId;
		object_1 = permissions;
	}
}
