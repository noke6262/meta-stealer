using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class RevokeChatInviteLinkRequest : RequestBase<ChatInviteLink>
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
	public string InviteLink
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
	}

	public RevokeChatInviteLinkRequest(ChatId chatId, string inviteLink)
		: base("revokeChatInviteLink")
	{
		object_0 = chatId;
		object_1 = inviteLink;
	}
}
