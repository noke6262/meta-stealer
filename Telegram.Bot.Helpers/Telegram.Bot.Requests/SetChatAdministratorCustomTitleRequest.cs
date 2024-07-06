using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetChatAdministratorCustomTitleRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private long long_0;

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
	public long UserId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string CustomTitle
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
	}

	public SetChatAdministratorCustomTitleRequest(ChatId chatId, long userId, string customTitle)
		: base("setChatAdministratorCustomTitle")
	{
		object_0 = chatId;
		UserId = userId;
		object_1 = customTitle;
	}
}
