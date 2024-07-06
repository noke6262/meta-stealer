using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class PromoteChatMemberRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private bool? nullable_0;

	[CompilerGenerated]
	private bool? nullable_1;

	[CompilerGenerated]
	private bool? nullable_2;

	[CompilerGenerated]
	private bool? nullable_3;

	[CompilerGenerated]
	private bool? nullable_4;

	[CompilerGenerated]
	private bool? nullable_5;

	[CompilerGenerated]
	private bool? nullable_6;

	[CompilerGenerated]
	private bool? nullable_7;

	[CompilerGenerated]
	private bool? a;

	[CompilerGenerated]
	private bool? b;

	[CompilerGenerated]
	private bool? c;

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
	public bool? IsAnonymous
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanManageChat
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanChangeInfo
	{
		[CompilerGenerated]
		get
		{
			return nullable_2;
		}
		[CompilerGenerated]
		set
		{
			nullable_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanPostMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_3;
		}
		[CompilerGenerated]
		set
		{
			nullable_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanEditMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_4;
		}
		[CompilerGenerated]
		set
		{
			nullable_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanDeleteMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_5;
		}
		[CompilerGenerated]
		set
		{
			nullable_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanManageVoiceChats
	{
		[CompilerGenerated]
		get
		{
			return nullable_6;
		}
		[CompilerGenerated]
		set
		{
			nullable_6 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanInviteUsers
	{
		[CompilerGenerated]
		get
		{
			return nullable_7;
		}
		[CompilerGenerated]
		set
		{
			nullable_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanRestrictMembers
	{
		[CompilerGenerated]
		get
		{
			return a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanPinMessages
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanPromoteMembers
	{
		[CompilerGenerated]
		get
		{
			return c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	public PromoteChatMemberRequest(ChatId chatId, long userId)
		: base("promoteChatMember")
	{
		object_0 = chatId;
		long_0 = userId;
	}
}
