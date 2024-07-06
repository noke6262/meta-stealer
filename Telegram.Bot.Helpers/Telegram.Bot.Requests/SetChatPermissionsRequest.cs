using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetChatPermissionsRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

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
	public ChatPermissions Permissions
	{
		[CompilerGenerated]
		get
		{
			return (ChatPermissions)object_1;
		}
	}

	public SetChatPermissionsRequest(ChatId chatId, ChatPermissions permissions)
		: base("setChatPermissions")
	{
		object_0 = chatId;
		object_1 = permissions;
	}
}
